#Requires -Version 7.0

<#
.SYNOPSIS
    Generates SVG icon library by downloading tabler-icons on demand
.DESCRIPTION
    This script downloads only the SVG files needed and generates C# code with embedded content
    - Downloads SVG files from GitHub directly (no local repo needed)
    - Generates TablerIcon enum with all icon names
    - Generates SvgIconLibrary with embedded SVG content
    - No separate resource files needed
.PARAMETER Force
    Force regeneration even if files haven't changed
.PARAMETER IconSet
    Which icon set to include: 'outline', 'filled', or 'both' (default: 'both')
.PARAMETER MaxIcons
    Maximum number of icons to include (for testing/smaller builds)
#>

param(
    [switch]$Force,
    [ValidateSet('outline', 'filled', 'both')]
    [string]$IconSet = 'both',
    [int]$MaxIcons = 0
)

Write-Host "🚀 Generating SVG Icon Library (Download-on-demand)..." -ForegroundColor Cyan

# Set correct paths
$projectRoot = Split-Path -Parent (Split-Path -Parent $PSScriptRoot)
Set-Location $projectRoot
$ProjectPath = Join-Path $projectRoot "HtmlForgeX"
$TempPath = Join-Path $projectRoot "Temp\tabler-icons"

Write-Host "Project Root: $projectRoot" -ForegroundColor Gray
Write-Host "Project: $ProjectPath" -ForegroundColor Gray

# Check if regeneration is needed
if (-not $Force) {
    $TablerIconFile = Join-Path $ProjectPath "Containers\Tabler\TablerIcon.cs"
    $libraryFile = Join-Path $ProjectPath "Containers\Tabler\TablerIconLibrary.cs"

    if ((Test-Path $TablerIconFile) -and (Test-Path $libraryFile)) {
        $oldestTarget = @(Get-Item $TablerIconFile), @(Get-Item $libraryFile) | Sort-Object LastWriteTime | Select-Object -First 1
        $daysSinceGeneration = (Get-Date) - $oldestTarget.LastWriteTime

        if ($daysSinceGeneration.TotalDays -lt 7) {
            Write-Host "✅ Icon library is recent (generated $([int]$daysSinceGeneration.TotalDays) days ago). Use -Force to regenerate." -ForegroundColor Green
            return
        }
    }
}

# Create temp directory
New-Item -ItemType Directory -Path $TempPath -Force | Out-Null

# Function to convert filename to enum name
function Convert-ToEnumName($fileName) {
    # Convert kebab-case to PascalCase (e.g., "ad-circle" -> "AdCircle")
    $name = $fileName -replace '\.svg$', ''
    $parts = $name -split '-'
    $enumName = ($parts | ForEach-Object {
        $_.Substring(0,1).ToUpper() + $_.Substring(1).ToLower()
    }) -join ''

    # Handle numbers at start
    $enumName = $enumName -replace '^3d', 'ThreeD'
    $enumName = $enumName -replace '^2fa', 'TwoFa'
    $enumName = $enumName -replace '^\d+', { 'Number' + $_.Value }

    return $enumName
}

# Function to escape SVG content for C# string literal
function Escape-CSharpString($content) {
    # Escape backslashes first (must be done before quotes)
    $escaped = $content -replace '\\', '\\'
    # Escape double quotes
    $escaped = $escaped -replace '"', '\"'
    # Handle newlines and tabs
    $escaped = $escaped -replace "`n", '\n'
    $escaped = $escaped -replace "`r", '\r'
    $escaped = $escaped -replace "`t", '\t'
    return $escaped
}

# Download icon list from GitHub API with pagination
Write-Host "📡 Fetching icon list from GitHub..." -ForegroundColor Yellow
$baseUrl = "https://api.github.com/repos/tabler/tabler-icons/contents/icons"

function Get-AllIconsFromAPI($path) {
    try {
        # First try the simple contents API
        $url = "$baseUrl/$path"
        Write-Host "   Fetching from: $url" -ForegroundColor Gray

        $response = Invoke-RestMethod -Uri $url -Headers @{ 'User-Agent' = 'HtmlForgeX-IconGenerator' }
        $svgFiles = $response | Where-Object { $_.name -like "*.svg" }

        Write-Host "   Found $($svgFiles.Count) SVG files in $path" -ForegroundColor Green

        # If we got exactly 1000 files, the directory might be truncated
        # For tabler-icons, we know outline has 4963+ files, so we need Git Trees API
        if ($svgFiles.Count -eq 1000) {
            Write-Host "   Directory might be truncated, trying Git Trees API..." -ForegroundColor Yellow
            return Get-AllIconsViaTreesAPI $path
        }

        return $svgFiles
    } catch {
        Write-Warning "Contents API failed for $path, trying Git Trees API: $_"
        return Get-AllIconsViaTreesAPI $path
    }
}

function Get-AllIconsViaTreesAPI($path) {
    try {
        # Get the latest commit SHA
        $repoApiUrl = "https://api.github.com/repos/tabler/tabler-icons"
        $repoInfo = Invoke-RestMethod -Uri "$repoApiUrl/branches/main" -Headers @{ 'User-Agent' = 'HtmlForgeX-IconGenerator' }
        $commitSha = $repoInfo.commit.sha

        # Get the tree for the icons directory
        $treeUrl = "$repoApiUrl/git/trees/$commitSha`:icons/$path"
        Write-Host "   Fetching tree: $treeUrl" -ForegroundColor Gray

        $treeResponse = Invoke-RestMethod -Uri $treeUrl -Headers @{ 'User-Agent' = 'HtmlForgeX-IconGenerator' }

        # Convert tree items to content-like objects
        $svgFiles = $treeResponse.tree | Where-Object { $_.path -like "*.svg" } | ForEach-Object {
            @{
                name = $_.path
                download_url = "https://raw.githubusercontent.com/tabler/tabler-icons/main/icons/$path/$($_.path)"
            }
        }

        Write-Host "   Found $($svgFiles.Count) SVG files via Trees API" -ForegroundColor Green
        return $svgFiles
    } catch {
        Write-Error "Failed to fetch icons from $path via Trees API: $_"
        return @()
    }
}

# Get all icons from both folders
$allIcons = @()

if ($IconSet -in @('outline', 'both')) {
    Write-Host "📋 Fetching ALL outline icons..." -ForegroundColor Yellow
    $outlineIcons = Get-AllIconsFromAPI 'outline'
    $allIcons += $outlineIcons | ForEach-Object { @{ Name = $_.name; Type = 'outline'; Url = $_.download_url } }
}

if ($IconSet -in @('filled', 'both')) {
    Write-Host "📋 Fetching ALL filled icons..." -ForegroundColor Yellow
    $filledIcons = Get-AllIconsFromAPI 'filled'
    $allIcons += $filledIcons | ForEach-Object { @{ Name = $_.name; Type = 'filled'; Url = $_.download_url } }
}

Write-Host "📊 Found $($allIcons.Count) total icons" -ForegroundColor Green

# Limit icons if specified (for testing)
if ($MaxIcons -gt 0 -and $allIcons.Count -gt $MaxIcons) {
    $allIcons = $allIcons | Select-Object -First $MaxIcons
    Write-Host "🔧 Limited to $($allIcons.Count) icons for testing" -ForegroundColor Yellow
}

# Download SVG files
Write-Host "📥 Downloading SVG content..." -ForegroundColor Yellow
$downloadedIcons = @{}
$progressCount = 0

foreach ($icon in $allIcons) {
    $progressCount++
    if ($progressCount % 100 -eq 0) {
        Write-Host "   Downloaded $progressCount/$($allIcons.Count) icons..." -ForegroundColor Gray
    }

    try {
        # Use curl instead of Invoke-RestMethod for better compatibility
        $svgContentArray = & curl -s $icon.Url
        $svgContent = $svgContentArray -join "`n"

        # Extract just the inner SVG content (paths, etc.)
        if ($svgContent -match '(?s)<svg[^>]*>(.*?)</svg>') {
            $innerContent = $matches[1].Trim()
            $enumName = Convert-ToEnumName $icon.Name

            # Avoid duplicates (prefer filled over outline)
            if (-not $downloadedIcons.ContainsKey($enumName) -or $icon.Type -eq 'filled') {
                $downloadedIcons[$enumName] = @{
                    Content = $innerContent
                    FileName = $icon.Name
                    Type = $icon.Type
                }
            }
        } else {
            Write-Warning "No SVG content found in $($icon.Name)"
        }
    } catch {
        Write-Warning "Failed to download $($icon.Name): $_"
    }
}

Write-Host "✅ Downloaded $($downloadedIcons.Count) unique icons" -ForegroundColor Green

# Generate TablerIcon enum
Write-Host "🔧 Generating TablerIcon enum..." -ForegroundColor Yellow

$enumContent = @'
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by HtmlForgeX Icon Generator.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
//
//     Generated from tabler-icons: https://github.com/tabler/tabler-icons
//     Total icons: {ICON_COUNT}
//     Generation date: {GENERATION_DATE}
// </auto-generated>
//------------------------------------------------------------------------------

namespace HtmlForgeX;

/// <summary>
/// Enumeration of all available SVG icons from tabler-icons
/// This is an auto-generated partial class - do not modify manually
/// </summary>
public enum TablerIcon {
'@

$enumValues = $downloadedIcons.Keys | Sort-Object | ForEach-Object {
    $icon = $downloadedIcons[$_]
    "    /// <summary>$($icon.FileName -replace '\.svg$', '') ($($icon.Type))</summary>`n    $_,"
}

$enumContent += "`n" + ($enumValues -join "`n") + "`n}"

# Replace placeholders
$enumContent = $enumContent -replace '\{ICON_COUNT\}', $downloadedIcons.Count
$enumContent = $enumContent -replace '\{GENERATION_DATE\}', (Get-Date -Format "yyyy-MM-dd HH:mm:ss UTC")

# Write TablerIcon.cs
Set-Content "$ProjectPath/Containers/Core/TablerIcon.cs" $enumContent -Encoding UTF8
Write-Host "✅ Generated TablerIcon.cs with $($downloadedIcons.Count) icons" -ForegroundColor Green

# Generate SvgIconLibrary with embedded content
Write-Host "🔧 Generating SvgIconLibrary with embedded content..." -ForegroundColor Yellow

$libraryContent = @'
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by HtmlForgeX Icon Generator.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
//
//     Generated from tabler-icons: https://github.com/tabler/tabler-icons
//     Total icons: {ICON_COUNT}
//     Generation date: {GENERATION_DATE}
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace HtmlForgeX;

/// <summary>
/// Static library for SVG icons with embedded content from tabler-icons
/// This is an auto-generated class - do not modify manually
/// </summary>
public static class TablerIconLibrary {
    private static readonly Dictionary<TablerIcon, string> _iconContent = new() {
'@

# Add embedded icon content
foreach ($enumName in ($downloadedIcons.Keys | Sort-Object)) {
    $icon = $downloadedIcons[$enumName]
    $escapedContent = Escape-CSharpString $icon.Content
    $libraryContent += "`n        { TablerIcon.$enumName, `"$escapedContent`" },"
}

$libraryContent += @'

    };

    /// <summary>
    /// Get an SVG icon by type
    /// </summary>
    public static TablerIcon GetIcon(TablerIcon TablerIcon) {
        var svgContent = GetSvgContent(TablerIcon);
        return new TablerIcon(svgContent);
    }

    /// <summary>
    /// Get raw SVG content for an icon
    /// </summary>
    public static string GetSvgContent(TablerIcon TablerIcon) {
        if (_iconContent.TryGetValue(TablerIcon, out var content)) {
            return content;
        }

        throw new ArgumentException($"Icon not found: {TablerIcon}");
    }

    /// <summary>
    /// Check if an icon exists
    /// </summary>
    public static bool HasIcon(TablerIcon TablerIcon) {
        return _iconContent.ContainsKey(TablerIcon);
    }

    /// <summary>
    /// Get all available icon types
    /// </summary>
    public static IEnumerable<TablerIcon> GetAllIcons() {
        return _iconContent.Keys;
    }
'@

# Add common icon static properties
$commonIcons = @('Home', 'User', 'Settings', 'Search', 'Heart', 'Star', 'Check', 'X', 'Plus', 'Minus')
$libraryContent += "`n`n    // Common icons as static properties`n"

foreach ($iconName in $commonIcons) {
    if ($downloadedIcons.ContainsKey($iconName)) {
        $libraryContent += "    public static TablerIcon $iconName => GetIcon(TablerIcon.$iconName);`n"
    }
}

$libraryContent += "}"

# Replace placeholders in library content
$libraryContent = $libraryContent -replace '\{ICON_COUNT\}', $downloadedIcons.Count
$libraryContent = $libraryContent -replace '\{GENERATION_DATE\}', (Get-Date -Format "yyyy-MM-dd HH:mm:ss UTC")

# Write TablerIconLibrary.cs
Set-Content "$ProjectPath/Containers/Core/TablerIconLibrary.cs" $libraryContent -Encoding UTF8
Write-Host "✅ Generated TablerIconLibrary.cs with embedded content" -ForegroundColor Green

# Clean up temp directory
Remove-Item $TempPath -Recurse -Force -ErrorAction SilentlyContinue

Write-Host "🎉 Icon library generated successfully!" -ForegroundColor Green
Write-Host "   📦 $($downloadedIcons.Count) icons embedded directly in code" -ForegroundColor Green
Write-Host "   🚀 No external files or dependencies needed" -ForegroundColor Green
Write-Host "   💾 Repository stays clean and lightweight" -ForegroundColor Green
