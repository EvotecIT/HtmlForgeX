Clear-Host

Import-Module $PSScriptRoot\..\HtmlForgeX.psd1 -Force

$Document = [HtmlForgeX.Document]::new()
$Document.LibraryMode = [HtmlForgeX.LibraryMode]::Online
$Document.Body.Page({ param($Page)
        $Page.Layout = [HtmlForgeX.TablerLayout]::Fluid
        $Page.Row({ param($Row)
                $Row.Column([HtmlForgeX.TablerColumnNumber]::Three, { param($Column)
                        $Column.CardMini().Avatar([HtmlForgeX.TablerIcon]::BrandFacebook).BackgroundColor([HtmlForgeX.TablerColor]::Facebook).TextColor([HtmlForgeX.TablerColor]::White).Title("172 likes").Subtitle("2 today")
                    }
                )
                $Row.Column([HtmlForgeX.TablerColumnNumber]::Three, { param($Column)
                        $Column.CardMini().Avatar([HtmlForgeX.TablerIcon]::BrandFacebook).BackgroundColor([HtmlForgeX.TablerColor]::Facebook).TextColor([HtmlForgeX.TablerColor]::White).Title("172 likes").Subtitle("2 today")
                    }
                )
                $Row.Column([HtmlForgeX.TablerColumnNumber]::Three, { param($Column)
                        $Column.CardMini().Avatar([HtmlForgeX.TablerIcon]::BrandTwitter).BackgroundColor([HtmlForgeX.TablerColor]::Twitter).TextColor([HtmlForgeX.TablerColor]::White).Title("172 likes").Subtitle("2 today")
                    }
                )
                $Row.Column([HtmlForgeX.TablerColumnNumber]::Three, { param([HtmlForgeX.TablerColumn]$Column4)
                        $Column4.CardMini().BackgroundColor([HtmlForgeX.TablerColor]::Facebook).TextColor([HtmlForgeX.TablerColor]::White).Title("172 likes").Subtitle("2 today")
                    }
                )
            }
        )
    }
)
$Document.Save("$PSScriptRoot\Example.HTML.html", $true)