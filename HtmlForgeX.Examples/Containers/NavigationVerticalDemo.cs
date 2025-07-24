using HtmlForgeX.Tags;

namespace HtmlForgeX.Examples.Containers;

internal class NavigationVerticalDemo {
    public static void Create(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("Navigation Demo - Vertical Layout");

        using var document = new Document {
            Head = {
                Title = "Vertical Navigation Demo - HtmlForgeX",
                Author = "HtmlForgeX Examples"
            },
            LibraryMode = LibraryMode.Online,
            ThemeMode = ThemeMode.Light
        };

        // Create a vertical layout with sidebar navigation using fluent API
        document.Body.Layout(layout => layout
            .WithLayout(TablerLayout.Vertical)
            .WithNavbar(nav => {
                nav.WithBrand("HtmlForgeX", "#")
                   .AddItem(item => item
                       .WithText("Home")
                       .WithIcon(TablerIconType.Home, TablerColor.Blue)
                       .WithInternalPageId("home")
                       .Active())
                   .AddItem(item => item
                       .WithText("Analytics")
                       .WithIcon(TablerIconType.ChartBar, TablerColor.Green)
                       .WithInternalPageId("analytics")
                       .WithBadge("New", TablerColor.Success))
                   .AddItem(item => item
                       .WithText("Projects")
                       .WithIcon(TablerIconType.Briefcase, TablerColor.Purple)
                       .AddDropdownItem("Active Projects", "#active-projects")
                       .AddDropdownItem("Archived", "#archived")
                       .AddDropdownItem("Create New", "#create-new"))
                   .AddItem(item => item
                       .WithText("Team")
                       .WithIcon(TablerIconType.Users, TablerColor.Orange)
                       .WithInternalPageId("team"))
                   .AddItem(item => item
                       .WithText("Settings")
                       .WithIcon(TablerIconType.Settings, TablerColor.Gray500)
                       .WithInternalPageId("settings"));
            })
            .AddPage("home", "Home", page => {
                page.Section(section => section
                    .WithTitle("Welcome to HtmlForgeX")
                    .WithBackgroundColor(TablerColor.BlueLight)
                    .WithPadding(TablerSpacing.Large)
                    .Add(new TablerText("Build beautiful web interfaces with C# using our fluent API.")));

                page.Row(row => {
                    row.Column(TablerColumnNumber.Four, col => {
                        col.Card(card => {
                            card.Steps().Orientation(StepsOrientation.Vertical)
                                .AddStep("Setup", "Install HtmlForgeX NuGet package", TablerStepState.Completed)
                                .AddStep("Create", "Build your UI with fluent API", TablerStepState.Active)
                                .AddStep("Generate", "Export to HTML", TablerStepState.Pending)
                                .AddStep("Deploy", "Share your creation", TablerStepState.Pending);
                        });
                    });
                    row.Column(TablerColumnNumber.Eight, col => {
                        col.Card(card => {
                            card.Header(h => h.Title("Quick Stats"));
                            card.Row(cardRow => {
                                cardRow.Column(TablerColumnNumber.Six, statsCol => {
                                    statsCol.CardBasic("Total Components", "150+");
                                });
                                cardRow.Column(TablerColumnNumber.Six, statsCol => {
                                    statsCol.CardBasic("Active Users", "10,234");
                                });
                            });
                        });
                    });
                });
            })
            .AddPage("analytics", "Analytics Dashboard", page => {
                page.Row(row => {
                    row.Column(TablerColumnNumber.Three, col => {
                        col.CardMini()
                            .Avatar(TablerIconType.TrendingUp)
                            .BackgroundColor("#10B981", "#FFFFFF")
                            .Title("Revenue")
                            .Subtitle("$45,234");
                    });
                    row.Column(TablerColumnNumber.Three, col => {
                        col.CardMini()
                            .Avatar(TablerIconType.Users)
                            .BackgroundColor("#3B82F6", "#FFFFFF")
                            .Title("Users")
                            .Subtitle("8,234");
                    });
                    row.Column(TablerColumnNumber.Three, col => {
                        col.CardMini()
                            .Avatar(TablerIconType.ShoppingBag)
                            .BackgroundColor("#8B5CF6", "#FFFFFF")
                            .Title("Orders")
                            .Subtitle("1,234");
                    });
                    row.Column(TablerColumnNumber.Three, col => {
                        col.CardMini()
                            .Avatar(TablerIconType.Percentage)
                            .BackgroundColor("#F59E0B", "#FFFFFF")
                            .Title("Conversion")
                            .Subtitle("3.4%");
                    });
                });

                page.Row(row => {
                    row.Column(TablerColumnNumber.Twelve, col => {
                        col.Card(card => {
                            card.Tracking()
                                .Block("Normal", TablerColor.Success)
                                .Block("Normal", TablerColor.Success)
                                .Block("High Load", TablerColor.Warning)
                                .Block("Normal", TablerColor.Success)
                                .Block("Normal", TablerColor.Success)
                                .Block("Downtime", TablerColor.Danger)
                                .Block("Recovery", TablerColor.Warning)
                                .Block("Normal", TablerColor.Success)
                                .Block("Normal", TablerColor.Success)
                                .Block("Normal", TablerColor.Success);
                        });
                    });
                });
            })
            .AddPage("team", "Team Management", page => {
                var teamData = new List<dynamic> {
                    new { Name = "Alice Johnson", Role = "Team Lead", Department = "Engineering", Status = "Active" },
                    new { Name = "Bob Smith", Role = "Developer", Department = "Engineering", Status = "Active" },
                    new { Name = "Carol White", Role = "Designer", Department = "Design", Status = "Active" },
                    new { Name = "David Brown", Role = "Product Manager", Department = "Product", Status = "On Leave" }
                };

                page.Row(row => {
                    row.Column(TablerColumnNumber.Twelve, col => {
                        col.Card(card => {
                            card.Header(h => h.Title("Team Members"));
                            card.Add(new TablerTable(teamData, TableType.DataTables));
                        });
                    });
                });
            })
            .AddPage("settings", "Settings", page => {
                page.Row(row => {
                    row.Column(TablerColumnNumber.Twelve, col => {
                        col.Card(card => {
                            card.Accordion(accordion => {
                                accordion.Type(TablerAccordionType.Flush)
                                         .Color(TablerColor.Primary);

                                accordion.AddItem("General Settings", item => {
                                    item.Icon(TablerIconType.Settings)
                                        .Expanded(true)
                                        .Content(content => {
                                            content.DataGrid(grid => {
                                                grid.AddItem("Application Name", "HtmlForgeX Demo");
                                                grid.AddItem("Version", "1.0.0");
                                                grid.AddItem("Language", "English");
                                                grid.AddItem("Time Zone", "UTC");
                                            });
                                        });
                                });

                                accordion.AddItem("Security", item => {
                                    item.Icon(TablerIconType.Shield)
                                        .Content(new TablerText("Two-factor authentication and password policies"));
                                });

                                accordion.AddItem("Notifications", item => {
                                    item.Icon(TablerIconType.Bell)
                                        .Content(new TablerText("Email and push notification preferences"));
                                });

                                accordion.AddItem("Privacy", item => {
                                    item.Icon(TablerIconType.Lock)
                                        .Content(new TablerText("Data collection and sharing settings"));
                                });
                            });
                        });
                    });
                });
            })
            .WithFooter("© 2024 HtmlForgeX. Built with Tabler UI.")
        );

        document.Save("NavigationVerticalDemo.html", openInBrowser);
    }
}