using HtmlForgeX.Containers.Tabler;

namespace HtmlForgeX.Examples.Tabler
{
    internal class TablerButtonShowcase
    {
        public static void Create(bool openInBrowser = false)
        {
            HelpersSpectre.PrintTitle("Tabler Button Component Showcase");

            using var document = new Document {
                LibraryMode = LibraryMode.Online,
                ThemeMode = ThemeMode.Light
            };

            document.Head.Title = "Tabler Button Showcase - HtmlForgeX";
            document.Head.Author = "HtmlForgeX";
            document.Head.Revised = DateTime.Now;

            document.Body.Page(page => {
                page.Layout = TablerLayout.Fluid;
                
                page.H1("Button Component Showcase");
                page.Text("All button variations and features available in HtmlForgeX").Style(TablerTextStyle.Muted);

                // Button Variants Section
                page.H2("Button Variants");
                page.Row(row => {
                    row.Column(TablerColumnNumber.Twelve, column => {
                        column.Card(card => {
                            card.Header(header => header.Title("All Color Variants"));
                            card.Body(body => {
                                body.Text("Available button color variants:");
                                body.Add(new TablerRow()
                                    .WithGutter(TablerSpacing.Small)
                                    .WithMargin(TablerSpacing.Medium, TablerSpacingDirection.Top)
                                    .Column(TablerColumnNumber.Auto, col => col.Add(new TablerButton("Primary", TablerButtonVariant.Primary)))
                                    .Column(TablerColumnNumber.Auto, col => col.Add(new TablerButton("Secondary", TablerButtonVariant.Secondary)))
                                    .Column(TablerColumnNumber.Auto, col => col.Add(new TablerButton("Success", TablerButtonVariant.Success)))
                                    .Column(TablerColumnNumber.Auto, col => col.Add(new TablerButton("Warning", TablerButtonVariant.Warning)))
                                    .Column(TablerColumnNumber.Auto, col => col.Add(new TablerButton("Danger", TablerButtonVariant.Danger)))
                                    .Column(TablerColumnNumber.Auto, col => col.Add(new TablerButton("Info", TablerButtonVariant.Info)))
                                    .Column(TablerColumnNumber.Auto, col => col.Add(new TablerButton("Light", TablerButtonVariant.Light)))
                                    .Column(TablerColumnNumber.Auto, col => col.Add(new TablerButton("Dark", TablerButtonVariant.Dark)))
                                    .Column(TablerColumnNumber.Auto, col => col.Add(new TablerButton("Link", TablerButtonVariant.Link)))
                                );
                            });
                        });
                    });
                });

                // Button Sizes Section
                page.H2("Button Sizes");
                page.Row(row => {
                    row.Column(TablerColumnNumber.Twelve, column => {
                        column.Card(card => {
                            card.Header(header => header.Title("Size Variations"));
                            card.Body(body => {
                                body.Add(new TablerRow()
                                    .WithGutter(TablerSpacing.Small)
                                    .WithClass("align-items-center")
                                    .Column(TablerColumnNumber.Auto, col => col.Add(new TablerButton("Small", TablerButtonVariant.Primary).Size(TablerButtonSize.Small)))
                                    .Column(TablerColumnNumber.Auto, col => col.Add(new TablerButton("Default", TablerButtonVariant.Primary).Size(TablerButtonSize.Default)))
                                    .Column(TablerColumnNumber.Auto, col => col.Add(new TablerButton("Large", TablerButtonVariant.Primary).Size(TablerButtonSize.Large)))
                                );
                            });
                        });
                    });
                });

                // Buttons with Icons Section
                page.H2("Buttons with Icons");
                page.Row(row => {
                    row.Column(TablerColumnNumber.Twelve, column => {
                        column.Card(card => {
                            card.Header(header => header.Title("Icon Integration"));
                            card.Body(body => {
                                body.Add(new TablerRow()
                                    .WithGutter(TablerSpacing.Small)
                                    .Column(TablerColumnNumber.Auto, col => col.Add(
                                        new TablerButton("Save")
                                            .Variant(TablerButtonVariant.Success)
                                            .Icon(TablerIconType.DeviceFloppy)
                                    ))
                                    .Column(TablerColumnNumber.Auto, col => col.Add(
                                        new TablerButton("Delete")
                                            .Variant(TablerButtonVariant.Danger)
                                            .Icon(TablerIconType.Trash, TablerIconPosition.Right)
                                    ))
                                    .Column(TablerColumnNumber.Auto, col => col.Add(
                                        new TablerButton("Settings")
                                            .Variant(TablerButtonVariant.Secondary)
                                            .Icon(TablerIconType.Settings)
                                    ))
                                );

                                body.Text("Icon-only buttons:");
                                body.Add(new TablerRow()
                                    .WithGutter(TablerSpacing.Small)
                                    .WithMargin(TablerSpacing.Small, TablerSpacingDirection.Top)
                                    .Column(TablerColumnNumber.Auto, col => col.Add(
                                        new TablerButton("")
                                            .Variant(TablerButtonVariant.Primary)
                                            .Icon(TablerIconType.Plus)
                                            .IconOnly()
                                            .Tooltip("Add new item")
                                    ))
                                    .Column(TablerColumnNumber.Auto, col => col.Add(
                                        new TablerButton("")
                                            .Variant(TablerButtonVariant.Info)
                                            .Icon(TablerIconType.Edit)
                                            .IconOnly()
                                            .Tooltip("Edit")
                                    ))
                                    .Column(TablerColumnNumber.Auto, col => col.Add(
                                        new TablerButton("")
                                            .Variant(TablerButtonVariant.Danger)
                                            .Icon(TablerIconType.X)
                                            .IconOnly()
                                            .Tooltip("Close")
                                    ))
                                );
                            });
                        });
                    });
                });

                // Ghost Buttons Section
                page.H2("Ghost Buttons");
                page.Row(row => {
                    row.Column(TablerColumnNumber.Twelve, column => {
                        column.Card(card => {
                            card.Header(header => header.Title("Ghost Style (Outline Only)"));
                            card.Body(body => {
                                body.Text("Ghost buttons have transparent background:");
                                body.Add(new TablerRow()
                                    .WithGutter(TablerSpacing.Small)
                                    .WithMargin(TablerSpacing.Medium, TablerSpacingDirection.Top)
                                    .Column(TablerColumnNumber.Auto, col => col.Add(new TablerButton("Primary", TablerButtonVariant.Primary).Ghost()))
                                    .Column(TablerColumnNumber.Auto, col => col.Add(new TablerButton("Success", TablerButtonVariant.Success).Ghost()))
                                    .Column(TablerColumnNumber.Auto, col => col.Add(new TablerButton("Warning", TablerButtonVariant.Warning).Ghost()))
                                    .Column(TablerColumnNumber.Auto, col => col.Add(new TablerButton("Danger", TablerButtonVariant.Danger).Ghost()))
                                    .Column(TablerColumnNumber.Auto, col => col.Add(new TablerButton("Info", TablerButtonVariant.Info).Ghost()))
                                );
                            });
                        });
                    });
                });

                // Button States Section
                page.H2("Button States");
                page.Row(row => {
                    row.Column(TablerColumnNumber.Twelve, column => {
                        column.Card(card => {
                            card.Header(header => header.Title("Different States"));
                            card.Body(body => {
                                body.Add(new TablerRow()
                                    .WithGutter(TablerSpacing.Small)
                                    .Column(TablerColumnNumber.Auto, col => col.Add(new TablerButton("Normal", TablerButtonVariant.Primary)))
                                    .Column(TablerColumnNumber.Auto, col => col.Add(new TablerButton("Disabled", TablerButtonVariant.Primary).Disabled()))
                                    .Column(TablerColumnNumber.Auto, col => col.Add(new TablerButton("Loading...", TablerButtonVariant.Primary).Loading()))
                                );
                            });
                        });
                    });
                });

                // Block Buttons Section
                page.H2("Block Buttons");
                page.Row(row => {
                    row.Column(TablerColumnNumber.Six, column => {
                        column.Card(card => {
                            card.Header(header => header.Title("Full Width Buttons"));
                            card.Body(body => {
                                body.Add(new TablerButton("Full Width Button", TablerButtonVariant.Primary).Block());
                                body.Add(new HtmlTag("div").Class("mt-2").Add(
                                    new TablerButton("Another Full Width", TablerButtonVariant.Secondary).FullWidth()
                                ));
                            });
                        });
                    });
                });

                // Link Buttons Section
                page.H2("Link Buttons");
                page.Row(row => {
                    row.Column(TablerColumnNumber.Twelve, column => {
                        column.Card(card => {
                            card.Header(header => header.Title("Buttons as Links"));
                            card.Body(body => {
                                body.Add(new TablerRow()
                                    .WithGutter(TablerSpacing.Small)
                                    .Column(TablerColumnNumber.Auto, col => col.Add(
                                        new TablerButton("Go to GitHub", "https://github.com", TablerButtonVariant.Primary)
                                            .Icon(TablerIconType.BrandGithub)
                                    ))
                                    .Column(TablerColumnNumber.Auto, col => col.Add(
                                        new TablerButton("Documentation", "/docs", TablerButtonVariant.Info)
                                    ))
                                    .Column(TablerColumnNumber.Auto, col => col.Add(
                                        new TablerButton("External Link", "https://example.com", TablerButtonVariant.Link)
                                            .Icon(TablerIconType.ExternalLink, TablerIconPosition.Right)
                                    ))
                                );
                            });
                        });
                    });
                });

                // Form Buttons Section
                page.H2("Form Buttons");
                page.Row(row => {
                    row.Column(TablerColumnNumber.Twelve, column => {
                        column.Card(card => {
                            card.Header(header => header.Title("Form-specific Button Types"));
                            card.Body(body => {
                                var form = new TablerForm();
                                form.Add(new TablerRow()
                                    .WithGutter(TablerSpacing.Small)
                                    .Column(TablerColumnNumber.Auto, col => col.Add(new TablerButton("Submit", TablerButtonVariant.Primary).Submit()))
                                    .Column(TablerColumnNumber.Auto, col => col.Add(new TablerButton("Reset", TablerButtonVariant.Secondary).Reset()))
                                    .Column(TablerColumnNumber.Auto, col => col.Add(new TablerButton("Cancel", TablerButtonVariant.Light).Type("button")))
                                );
                                body.Add(form);
                            });
                        });
                    });
                });

                // Advanced Examples
                page.H2("Advanced Examples");
                page.Row(row => {
                    row.Column(TablerColumnNumber.Twelve, column => {
                        column.Card(card => {
                            card.Header(header => header.Title("Complex Button Configurations"));
                            card.Body(body => {
                                body.Add(new TablerRow()
                                    .WithGutter(TablerSpacing.Medium)
                                    .Column(TablerColumnNumber.Auto, col => col.Add(
                                        new TablerButton("Click Me")
                                            .Variant(TablerButtonVariant.Warning)
                                            .Icon(TablerIconType.HandClick)
                                            .Tooltip("This button has a tooltip!")
                                            .OnClick("alert('Button clicked!');")
                                    ))
                                    .Column(TablerColumnNumber.Auto, col => col.Add(
                                        new TablerButton("Download Report")
                                            .Variant(TablerButtonVariant.Success)
                                            .Size(TablerButtonSize.Large)
                                            .Ghost()
                                            .Icon(TablerIconType.Download)
                                    ))
                                    .Column(TablerColumnNumber.Auto, col => col.Add(
                                        new TablerButton("Disabled Link", "#", TablerButtonVariant.Info)
                                            .Disabled()
                                            .Icon(TablerIconType.Ban)
                                    ))
                                );
                            });
                        });
                    });
                });
            });

            document.Save("TablerButtonShowcase.html", openInBrowser);
        }
    }
}