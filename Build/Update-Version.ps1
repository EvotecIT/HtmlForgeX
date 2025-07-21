Import-Module PSPublishModule -Force

Get-ProjectVersion -Path "C:\Support\GitHub\HtmlForgeX" -ExcludeFolders @('C:\Support\GitHub\HtmlForgeX\Module\Artefacts') | Format-Table

Set-ProjectVersion -Path "C:\Support\GitHub\HtmlForgeX" -NewVersion "0.2.0" -Verbose -ExcludeFolders @('C:\Support\GitHub\HtmlForgeX\Module\Artefacts') -WhatIf
