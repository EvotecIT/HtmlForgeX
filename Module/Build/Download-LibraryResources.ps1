# Downloads HTMLForgeX library resources and copies them to the PowerShell module
param(
    [string] $Configuration = 'Release'
)

$projectRoot = Resolve-Path "$PSScriptRoot\..\.."
$csprojPath = Join-Path $projectRoot 'HtmlForgeX' 'HtmlForgeX.csproj'

# build the main library to make sure the assembly exists
& dotnet build $csprojPath -c $Configuration

# locate built dll
$assembly = Get-ChildItem -Path (Join-Path $projectRoot 'HtmlForgeX' 'bin' $Configuration) -Filter 'HtmlForgeX.dll' -Recurse | Select-Object -First 1
if (-not $assembly) {
    Write-Error 'HtmlForgeX.dll not found after build.'
    exit 1
}

Add-Type -Path $assembly.FullName

$resourcesPath = Join-Path $projectRoot 'HtmlForgeX' 'Resources'
$downloader = [HtmlForgeX.LibraryDownloader]::new()
$downloader.DownloadLibraryAsync($resourcesPath).GetAwaiter().GetResult()

$moduleResources = Join-Path $projectRoot 'Module' 'Resources'
Copy-Item -Path (Join-Path $resourcesPath 'Scripts' '*') -Destination (Join-Path $moduleResources 'Scripts') -Recurse -Force
Copy-Item -Path (Join-Path $resourcesPath 'Styles' '*') -Destination (Join-Path $moduleResources 'Styles') -Recurse -Force

