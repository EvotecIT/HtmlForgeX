#Requires -Version 7.0

<#
.SYNOPSIS
    Generates Font Awesome 5 and 6 icon enums by parsing the Font Awesome metadata
.DESCRIPTION
    This script downloads Font Awesome metadata and generates C# enums with all available icons
    - Downloads icon metadata from Font Awesome CDN
    - Generates FontAwesome5Solid, FontAwesome5Regular, FontAwesome5Brands enums
    - Generates FontAwesome6Solid, FontAwesome6Regular, FontAwesome6Brands enums
    - Preserves hand-coded extension methods in separate files
.PARAMETER Force
    Force regeneration even if files haven't changed
.PARAMETER Version
    Which version to generate: '5', '6', or 'both' (default: 'both')
#>

param(
    [switch]$Force,
    [ValidateSet('5', '6', 'both')]
    [string]$Version = 'both'
)

Write-Host "🚀 Generating Font Awesome Icon Enums..." -ForegroundColor Cyan

# Set correct paths
$projectRoot = Split-Path -Parent $PSScriptRoot
Set-Location $projectRoot
$ProjectPath = Join-Path $projectRoot "HtmlForgeX"
$TempPath = Join-Path $projectRoot "Temp\fontawesome-icons"

Write-Host "Project Root: $projectRoot" -ForegroundColor Gray
Write-Host "Project: $ProjectPath" -ForegroundColor Gray

# Create temp directory
New-Item -ItemType Directory -Path $TempPath -Force | Out-Null

# Function to convert icon name to enum name
function ConvertTo-EnumName($iconName) {
    # Convert kebab-case to PascalCase (e.g., "address-book" -> "AddressBook")
    $parts = $iconName -split '-'
    $enumName = ($parts | ForEach-Object {
        $_.Substring(0,1).ToUpper() + $_.Substring(1).ToLower()
    }) -join ''
    
    # Handle special cases
    $enumName = $enumName -replace '^500px', 'FiveHundredPx'
    $enumName = $enumName -replace '^\d+', { 'Number' + $_.Value }
    
    # No brand-specific naming needed - we now store the icon name in the IconName attribute
    
    return $enumName
}

# Function to download and parse Font Awesome metadata
function Get-FontAwesomeIcons($version) {
    Write-Host "📡 Downloading Font Awesome $version metadata..." -ForegroundColor Yellow
    
    $metadataUrl = if ($version -eq '5') {
        "https://raw.githubusercontent.com/FortAwesome/Font-Awesome/5.x/metadata/icons.json"
    } else {
        "https://raw.githubusercontent.com/FortAwesome/Font-Awesome/6.x/metadata/icons.json"
    }
    
    $metadataFile = Join-Path $TempPath "fontawesome-$version-icons.json"
    
    try {
        Invoke-WebRequest -Uri $metadataUrl -OutFile $metadataFile -UseBasicParsing
        $metadata = Get-Content $metadataFile -Raw | ConvertFrom-Json
        
        $solidIcons = @{}
        $regularIcons = @{}
        $brandsIcons = @{}
        
        foreach ($iconName in $metadata.PSObject.Properties.Name) {
            $icon = $metadata.$iconName
            
            # Skip pro-only icons
            if ($icon.free -contains 'solid') {
                $solidIcons[$iconName] = $icon
            }
            if ($icon.free -contains 'regular') {
                $regularIcons[$iconName] = $icon
            }
            if ($icon.free -contains 'brands') {
                $brandsIcons[$iconName] = $icon
            }
        }
        
        Write-Host "   Found $($solidIcons.Count) solid icons" -ForegroundColor Green
        Write-Host "   Found $($regularIcons.Count) regular icons" -ForegroundColor Green
        Write-Host "   Found $($brandsIcons.Count) brand icons" -ForegroundColor Green
        
        return @{
            Solid = $solidIcons
            Regular = $regularIcons
            Brands = $brandsIcons
        }
    }
    catch {
        Write-Host "❌ Failed to download Font Awesome $version metadata: $_" -ForegroundColor Red
        return $null
    }
}

# Function to generate enum file
function New-EnumFile($icons, $enumName, $outputPath, $description) {
    Write-Host "✍️ Generating $enumName..." -ForegroundColor Yellow
    
    $sb = [System.Text.StringBuilder]::new()
    
    # File header
    $null = $sb.AppendLine("using System;")
    $null = $sb.AppendLine("using System.ComponentModel;")
    $null = $sb.AppendLine("")
    $null = $sb.AppendLine("namespace HtmlForgeX;")
    $null = $sb.AppendLine("")
    $null = $sb.AppendLine("/// <summary>")
    $null = $sb.AppendLine("/// $description")
    $null = $sb.AppendLine("/// </summary>")
    $null = $sb.AppendLine("public enum $enumName {")
    
    # Sort icons by name for consistent output
    $sortedIcons = $icons.GetEnumerator() | Sort-Object Name
    
    $count = 0
    foreach ($icon in $sortedIcons) {
        $iconName = $icon.Key
        $iconData = $icon.Value
        $enumMember = ConvertTo-EnumName $iconName
        $unicode = "0x" + $iconData.unicode
        
        # Add XML documentation
        $label = if ($iconData.label) { $iconData.label } else { $iconName }
        # Escape XML special characters
        $label = $label -replace '&', '&amp;' -replace '<', '&lt;' -replace '>', '&gt;' -replace '"', '&quot;' -replace "'", '&apos;'
        $null = $sb.AppendLine("    /// <summary>$label icon (fa-$iconName)</summary>")
        # Ensure Unicode is exactly 4 characters by padding with zeros
        $paddedUnicode = $iconData.unicode.PadLeft(4, '0')
        $null = $sb.AppendLine("    [Description(""\u$paddedUnicode"")]")
        $null = $sb.AppendLine("    [IconName(""$iconName"")]")
        $null = $sb.AppendLine("    $enumMember = $unicode,")
        
        $count++
    }
    
    # Remove last comma
    if ($count -gt 0) {
        $sb.Length -= 3
        $null = $sb.AppendLine("")
    }
    
    $null = $sb.AppendLine("}")
    
    # Write file
    [System.IO.File]::WriteAllText($outputPath, $sb.ToString(), [System.Text.Encoding]::UTF8)
    Write-Host "   ✅ Generated $count icons in $enumName" -ForegroundColor Green
}

# Generate Font Awesome 5
if ($Version -eq '5' -or $Version -eq 'both') {
    Write-Host "`n📦 Processing Font Awesome 5..." -ForegroundColor Cyan
    $fa5Icons = Get-FontAwesomeIcons '5'
    
    if ($fa5Icons) {
        $fa5Path = Join-Path $ProjectPath "Icons\FontAwesome5"
        
        # Generate enums
        New-EnumFile $fa5Icons.Solid "FontAwesome5Solid" `
            (Join-Path $fa5Path "FontAwesome5Solid.cs") `
            "Font Awesome 5 Solid icons (Free) - Generated automatically by GenerateFontAwesomeIcons.ps1"
            
        New-EnumFile $fa5Icons.Regular "FontAwesome5Regular" `
            (Join-Path $fa5Path "FontAwesome5Regular.cs") `
            "Font Awesome 5 Regular icons (Free) - Generated automatically by GenerateFontAwesomeIcons.ps1"
            
        New-EnumFile $fa5Icons.Brands "FontAwesome5Brands" `
            (Join-Path $fa5Path "FontAwesome5Brands.cs") `
            "Font Awesome 5 Brand icons (Free) - Generated automatically by GenerateFontAwesomeIcons.ps1"
    }
}

# Generate Font Awesome 6
if ($Version -eq '6' -or $Version -eq 'both') {
    Write-Host "`n📦 Processing Font Awesome 6..." -ForegroundColor Cyan
    $fa6Icons = Get-FontAwesomeIcons '6'
    
    if ($fa6Icons) {
        $fa6Path = Join-Path $ProjectPath "Icons\FontAwesome"
        
        # Generate enums
        New-EnumFile $fa6Icons.Solid "FontAwesomeSolid" `
            (Join-Path $fa6Path "FontAwesomeSolid.cs") `
            "Font Awesome 6 Solid icons (Free) - Generated automatically by GenerateFontAwesomeIcons.ps1"
            
        New-EnumFile $fa6Icons.Regular "FontAwesomeRegular" `
            (Join-Path $fa6Path "FontAwesomeRegular.cs") `
            "Font Awesome 6 Regular icons (Free) - Generated automatically by GenerateFontAwesomeIcons.ps1"
            
        New-EnumFile $fa6Icons.Brands "FontAwesomeBrands" `
            (Join-Path $fa6Path "FontAwesomeBrands.cs") `
            "Font Awesome 6 Brand icons (Free) - Generated automatically by GenerateFontAwesomeIcons.ps1"
    }
}

# Clean up
Remove-Item -Path $TempPath -Recurse -Force -ErrorAction SilentlyContinue

Write-Host "`n✅ Font Awesome icon generation complete!" -ForegroundColor Green
Write-Host "   Remember to rebuild the project to use the new icons." -ForegroundColor Yellow