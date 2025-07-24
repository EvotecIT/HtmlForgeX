using HtmlForgeX.Examples;

namespace HtmlForgeX.Examples.Containers;

/// <summary>
/// Basic SmartTab demo showcasing the fluent API capabilities.
/// </summary>
internal class SmartTabDemo {
    public static void Create(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("SmartTab Basic Demo - Fluent C# API");

        // Sample data for tables
        var data = new List<dynamic> {
            new { Name = "John", Age = 30, Occupation = "Engineer" },
            new { Name = "Jane", Age = 28, Occupation = "Doctor" },
            new { Name = "Bob", Age = 35, Occupation = "Architect" }
        };

        using var document = new Document {
            LibraryMode = LibraryMode.Online,
            ThemeMode = ThemeMode.Light
        };

        document.Head.Title = "SmartTab Basic Demo";
        document.Head.Author = "HtmlForgeX";
        document.Head.Revised = DateTime.Now;

        document.Body.Page(page => {
            page.Layout = TablerLayout.Fluid;

            // SECTION: Basic SmartTab Example
            page.H2("Basic SmartTab Example");
            page.Text("Simple tabbed interface using SmartTab fluent API").Weight(TablerFontWeight.Medium);

            page.Row(row => {
                row.Column(TablerColumnNumber.Twelve, column => {
                    column.Card(card => {
                        card.Body(body => {
                            body.SmartTab(smartTab => {
                                smartTab.WithTheme(SmartTabTheme.Bootstrap)
                                       .WithTransition(SmartTabAnimation.Fade, 300)
                                       .WithSelectedTab(0);

                                // Tab 1: Overview
                                smartTab.AddTab("Overview", TablerIconType.Home, panel => {
                                    panel.Text("Welcome to the SmartTab demo! This component provides a powerful and flexible tabbed interface.")
                                         .Weight(TablerFontWeight.Medium);
                                    panel.LineBreak();
                                    panel.Text("Key features include:")
                                         .Style(TablerTextStyle.Muted);
                                    panel.TablerList().AddItem("Responsive design", TablerIconType.DeviceDesktop)
                                                             .AddItem("Multiple themes", TablerIconType.Palette)
                                                             .AddItem("Smooth animations", TablerIconType.PlayerPlay)
                                                             .AddItem("Keyboard navigation", TablerIconType.Keyboard)
                                                             .AddItem("Ajax content loading", TablerIconType.CloudDown);
                                });

                                // Tab 2: Data Table
                                smartTab.AddTab("Data", TablerIconType.Table, panel => {
                                    panel.Text("Interactive data table with sorting and filtering capabilities.")
                                         .Weight(TablerFontWeight.Medium);
                                    panel.LineBreak();
                                    var table = (DataTablesTable)panel.Table(data, TableType.DataTables);
                                    table.EnableOrdering(true)
                                         .EnableSearching(true)
                                         .Style(BootStrapTableStyle.Striped)
                                         .PagingType(DataTablesPagingType.Simple);
                                });

                                // Tab 3: Cards
                                smartTab.AddTab("Cards", TablerIconType.Cards, panel => {
                                    panel.Text("Example cards with various configurations.")
                                         .Weight(TablerFontWeight.Medium);
                                    panel.LineBreak();
                                    
                                    panel.Row(cardRow => {
                                        cardRow.Column(TablerColumnNumber.Four, cardCol => {
                                            cardCol.Card(card => {
                                                card.Stamp(TablerIconType.Star, TablerColor.Yellow);
                                                card.Header(header => {
                                                    header.Title("Featured Card");
                                                });
                                                card.Body(body => {
                                                    body.Text("This is a featured card with a star stamp.");
                                                });
                                            });
                                        });
                                        cardRow.Column(TablerColumnNumber.Four, cardCol => {
                                            cardCol.Card(card => {
                                                card.Background(TablerColor.Primary, isLight: true);
                                                card.Header(header => {
                                                    header.Title("Primary Card");
                                                });
                                                card.Body(body => {
                                                    body.Text("This card has a light primary background.");
                                                });
                                            });
                                        });
                                        cardRow.Column(TablerColumnNumber.Four, cardCol => {
                                            cardCol.Card(card => {
                                                card.Progress(75, TablerColor.Success);
                                                card.Header(header => {
                                                    header.Title("Progress Card");
                                                });
                                                card.Body(body => {
                                                    body.Text("This card shows a progress bar at 75%.");
                                                });
                                            });
                                        });
                                    });
                                });

                                // Tab 4: Settings
                                smartTab.AddTab("Settings", TablerIconType.Settings, panel => {
                                    panel.Text("Configuration options and settings.")
                                         .Weight(TablerFontWeight.Medium);
                                    panel.LineBreak();
                                    
                                    panel.DataGrid(dataGrid => {
                                        dataGrid.WithLayout(TablerDataGridLayout.Default)
                                               .WithSpacing(TablerDataGridSpacing.Medium);

                                        dataGrid.AddCheckboxItem("Enable notifications", true, "Receive email notifications");
                                        dataGrid.AddCheckboxItem("Auto-save", false, "Automatically save changes");
                                        dataGrid.AddFormControlItem("Theme", "select", "Choose theme", "light");
                                        dataGrid.AddFormControlItem("Language", "select", "Select language", "en");
                                        dataGrid.AddBadgeItem("Status", "Active", TablerColor.Success);
                                        dataGrid.AddStatusItem("Last Updated", "2 hours ago", TablerColor.Info);
                                    });
                                });
                            });
                        });
                    });
                });
            });

            // SECTION: Advanced SmartTab with Animations
            page.H2("Advanced SmartTab with Animations");
            page.Text("SmartTab with different themes and animations").Weight(TablerFontWeight.Medium);

            page.Row(row => {
                row.Column(TablerColumnNumber.Six, column => {
                    column.Card(card => {
                        card.Header(header => {
                            header.Title("Slide Animation");
                        });
                        card.Body(body => {
                            body.SmartTab(smartTab => {
                                smartTab.WithTheme(SmartTabTheme.Classic)
                                       .WithTransition(SmartTabAnimation.SlideHorizontal, 400)
                                       .WithSelectedTab(0);

                                smartTab.AddTab("Profile", TablerIconType.User, panel => {
                                    panel.Text("User profile information with slide animation.")
                                         .Weight(TablerFontWeight.Medium);
                                    panel.LineBreak();
                                    panel.Add(new TablerAvatar()
                                        .Icon(TablerIconType.User)
                                        .Size(AvatarSize.XL)
                                        .BackgroundColor(TablerColor.Primary)
                                        .TextColor(TablerColor.White));
                                    panel.Text("John Doe").Weight(TablerFontWeight.Bold);
                                    panel.LineBreak();
                                    panel.Text("Software Engineer").Style(TablerTextStyle.Muted);
                                });

                                smartTab.AddTab("Activity", TablerIconType.Activity, panel => {
                                    panel.Text("Recent activity timeline.")
                                         .Weight(TablerFontWeight.Medium);
                                    panel.LineBreak();
                                    panel.Add(new TablerTimeline()
                                        .Item(item => item
                                            .Time("2 hours ago")
                                            .Title("Project completed")
                                            .Color(TablerColor.Success))
                                        .Item(item => item
                                            .Time("4 hours ago")
                                            .Title("Meeting scheduled")
                                            .Color(TablerColor.Info))
                                        .Item(item => item
                                            .Time("1 day ago")
                                            .Title("Task assigned")
                                            .Color(TablerColor.Warning)));
                                });

                                smartTab.AddTab("Messages", TablerIconType.Mail, panel => {
                                    panel.Text("Inbox messages with notifications.")
                                         .Weight(TablerFontWeight.Medium);
                                    panel.LineBreak();
                                    panel.TablerList()
                                        .AddItem("New message from Alice", TablerIconType.Mail)
                                        .AddItem("Team meeting reminder", TablerIconType.Calendar)
                                        .AddItem("Project update", TablerIconType.FileText);
                                });
                            });
                        });
                    });
                });

                row.Column(TablerColumnNumber.Six, column => {
                    column.Card(card => {
                        card.Header(header => {
                            header.Title("Vertical Tabs");
                        });
                        card.Body(body => {
                            body.SmartTab(smartTab => {
                                smartTab.WithTheme(SmartTabTheme.Material)
                                       .AsVertical()
                                       .WithTransition(SmartTabAnimation.Fade, 250)
                                       .WithSelectedTab(0);

                                smartTab.AddTab("Dashboard", TablerIconType.Dashboard, panel => {
                                    panel.Text("System dashboard overview.")
                                         .Weight(TablerFontWeight.Medium);
                                    panel.LineBreak();
                                    panel.Row(dashRow => {
                                        dashRow.Column(TablerColumnNumber.Six, dashCol => {
                                            dashCol.CardMini()
                                                  .Avatar(TablerIconType.Users)
                                                  .BackgroundColor(TablerColor.Primary)
                                                  .TextColor(TablerColor.White)
                                                  .Title("1,234")
                                                  .Subtitle("Active Users");
                                        });
                                        dashRow.Column(TablerColumnNumber.Six, dashCol => {
                                            dashCol.CardMini()
                                                  .Avatar(TablerIconType.ShoppingCart)
                                                  .BackgroundColor(TablerColor.Success)
                                                  .TextColor(TablerColor.White)
                                                  .Title("567")
                                                  .Subtitle("Orders");
                                        });
                                    });
                                });

                                smartTab.AddTab("Analytics", TablerIconType.ChartBar, panel => {
                                    panel.Text("Performance analytics and metrics.")
                                         .Weight(TablerFontWeight.Medium);
                                    panel.LineBreak();
                                    panel.Text("Analytics charts and graphs would go here.")
                                         .Style(TablerTextStyle.Muted);
                                });

                                smartTab.AddTab("Reports", TablerIconType.FileText, panel => {
                                    panel.Text("Generated reports and exports.")
                                         .Weight(TablerFontWeight.Medium);
                                    panel.LineBreak();
                                    panel.Text("Report generation interface would be displayed here.")
                                         .Style(TablerTextStyle.Muted);
                                });
                            });
                        });
                    });
                });
            });

            // SECTION: Auto-Progress SmartTab
            page.H2("Auto-Progress SmartTab");
            page.Text("SmartTab with automatic progression through tabs").Weight(TablerFontWeight.Medium);

            page.Row(row => {
                row.Column(TablerColumnNumber.Twelve, column => {
                    column.Card(card => {
                        card.Header(header => {
                            header.Title("Image Slideshow");
                        });
                        card.Body(body => {
                            body.SmartTab(smartTab => {
                                smartTab.WithTheme(SmartTabTheme.Dark)
                                       .WithTransition(SmartTabAnimation.Fade, 500)
                                       .EnableAutoProgress(4000, true)
                                       .WithSelectedTab(0);

                                smartTab.AddTab("Nature", TablerIconType.Plant, panel => {
                                    panel.Text("Beautiful nature landscapes").Weight(TablerFontWeight.Medium);
                                    panel.LineBreak();
                                    panel.Add(new HtmlTag("img")
                                        .Attribute("src", "https://picsum.photos/800/400?random=1")
                                        .Attribute("alt", "Nature landscape")
                                        .Class("img-fluid rounded"));
                                });

                                smartTab.AddTab("Architecture", TablerIconType.Building, panel => {
                                    panel.Text("Modern architectural designs").Weight(TablerFontWeight.Medium);
                                    panel.LineBreak();
                                    panel.Add(new HtmlTag("img")
                                        .Attribute("src", "https://picsum.photos/800/400?random=2")
                                        .Attribute("alt", "Architecture")
                                        .Class("img-fluid rounded"));
                                });

                                smartTab.AddTab("Technology", TablerIconType.DeviceDesktop, panel => {
                                    panel.Text("Latest technology innovations").Weight(TablerFontWeight.Medium);
                                    panel.LineBreak();
                                    panel.Add(new HtmlTag("img")
                                        .Attribute("src", "https://picsum.photos/800/400?random=3")
                                        .Attribute("alt", "Technology")
                                        .Class("img-fluid rounded"));
                                });

                                smartTab.AddTab("Abstract", TablerIconType.Palette, panel => {
                                    panel.Text("Abstract art and patterns").Weight(TablerFontWeight.Medium);
                                    panel.LineBreak();
                                    panel.Add(new HtmlTag("img")
                                        .Attribute("src", "https://picsum.photos/800/400?random=4")
                                        .Attribute("alt", "Abstract art")
                                        .Class("img-fluid rounded"));
                                });
                            });
                        });
                    });
                });
            });
        });

        document.Save("SmartTabDemo.html", openInBrowser);

        HelpersSpectre.Success("🎉 SmartTab Basic Demo created!");
        HelpersSpectre.Success("📋 Features demonstrated:");
        HelpersSpectre.Success("   ✅ Basic tabbed interface with fluent API");
        HelpersSpectre.Success("   ✅ Multiple themes (Bootstrap, Classic, Material, Dark)");
        HelpersSpectre.Success("   ✅ Various animations (Fade, SlideHorizontal)");
        HelpersSpectre.Success("   ✅ Vertical tab orientation");
        HelpersSpectre.Success("   ✅ Auto-progress functionality");
        HelpersSpectre.Success("   ✅ Integration with existing components (DataTables, Cards, DataGrid)");
        HelpersSpectre.Success("   ✅ Icon support with Tabler icons");
        HelpersSpectre.Success("   ✅ Responsive design");
        HelpersSpectre.Success("   ✅ Zero HTML knowledge required - Pure C# fluent API!");
    }
}