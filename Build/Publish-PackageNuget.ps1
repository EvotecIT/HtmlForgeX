﻿Import-Module PSPublishModule -Force -ErrorAction Stop

$NugetAPI = Get-Content -Raw -LiteralPath "C:\Support\Important\NugetOrgEvotec.txt"
Publish-NugetPackage -Path "$PSScriptRoot\..\HtmlForgeX\bin\Release" -ApiKey $NugetAPI
