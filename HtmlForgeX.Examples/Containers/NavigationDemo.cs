using HtmlForgeX.Tags;

namespace HtmlForgeX.Examples.Containers;

internal class NavigationDemo {
    public static void Create(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("Navigation Demo - Single Page with Multiple Views");

        // Sample data for tables
        var sampleData = new List<dynamic> {
            new { Name = "John Doe", Role = "Developer", Status = "Active", LastLogin = "2024-01-15" },
            new { Name = "Jane Smith", Role = "Designer", Status = "Active", LastLogin = "2024-01-14" },
            new { Name = "Bob Johnson", Role = "Manager", Status = "Inactive", LastLogin = "2024-01-10" }
        };

        using var document = new Document {
            Head = {
                Title = "Navigation Demo - HtmlForgeX",
                Author = "HtmlForgeX Examples"
            },
            LibraryMode = LibraryMode.Online,
            ThemeMode = ThemeMode.Light
        };

        // Create a layout with navigation using fluent API
        document.Body.Layout(layout => layout
            .WithLayout(TablerLayout.Horizontal)
            .WithNavbar(nav => {
                nav.WithLogo("../../../../Assets/Images/WhiteBackground/Logo-evotec.png", "#")
                   .WithSticky()
                   .AddItem("Dashboard", "#dashboard")
                   .AddItem(item => item
                       .WithText("Components")
                       .WithIcon(TablerIconType.Package)
                       .AddDropdownItem("Cards", "#cards")
                       .AddDropdownItem("Tables", "#tables")
                       .AddDropdownItem("Charts", "#charts"))
                   .AddItem(item => item
                       .WithText("Pages")
                       .WithIcon(TablerIconType.Files)
                       .AddDropdownItem("Profile", "#profile")
                       .AddDropdownItem("Settings", "#settings"))
                   .AddRightItem(item => item
                       .WithText("Notifications")
                       .WithIcon(TablerIconType.Bell)
                       .WithBadge("5", TablerColor.Danger));
            })
            .AddPage("dashboard", "Dashboard", page => {
                page.Row(row => {
                    // Stats cards
                    row.Column(TablerColumnNumber.Three, col => {
                        col.CardMini()
                            .Avatar(TablerIconType.Users)
                            .BackgroundColor(TablerColor.Primary)
                            .Title("Total Users")
                            .Subtitle("1,234");
                    });
                    row.Column(TablerColumnNumber.Three, col => {
                        col.CardMini()
                            .Avatar(TablerIconType.ShoppingCart)
                            .BackgroundColor(TablerColor.Success)
                            .Title("Sales")
                            .Subtitle("$12,345");
                    });
                    row.Column(TablerColumnNumber.Three, col => {
                        col.CardMini()
                            .Avatar(TablerIconType.TrendingUp)
                            .BackgroundColor(TablerColor.Info)
                            .Title("Growth")
                            .Subtitle("+23%");
                    });
                    row.Column(TablerColumnNumber.Three, col => {
                        col.CardMini()
                            .Avatar(TablerIconType.Activity)
                            .BackgroundColor(TablerColor.Warning)
                            .Title("Active Now")
                            .Subtitle("423");
                    });
                });

                page.Row(row => {
                    row.Column(TablerColumnNumber.Twelve, col => {
                        col.Card(card => {
                            card.Header(h => h.Title("Recent Activity"));
                            card.Alert("Welcome to the Dashboard!", "This is your main overview page.")
                                .Color(TablerColor.Success);
                        });
                    });
                });
            })
            .AddPage("cards", "Cards Demo", page => {
                page.Row(row => {
                    row.Column(TablerColumnNumber.Six, col => {
                        col.Card(card => {
                            card.Header(h => h.Title("Basic Card"));
                            card.Text("This is a basic card with some content.");
                            card.Footer(f => f.Text("Card footer"));
                        });
                    });
                    row.Column(TablerColumnNumber.Six, col => {
                        col.Card(card => {
                            card.Header(h => h.Title("Card with Progress"));
                            card.ProgressBar(TablerProgressBarType.Small)
                                .Item(TablerColor.Primary, 60, "Progress");
                            card.Text("Task completion status");
                        });
                    });
                });
            })
            .AddPage("tables", "Tables Demo", page => {
                page.Row(row => {
                    row.Column(TablerColumnNumber.Twelve, col => {
                        col.Card(card => {
                            card.Header(h => h.Title("User Table"));
                            card.Add(new TablerTable(sampleData, TableType.DataTables));
                        });
                    });
                });
            })
            .AddPage("charts", "Charts Demo", page => {
                page.Row(row => {
                    row.Column(TablerColumnNumber.Twelve, col => {
                        col.Card(card => {
                            card.Alert("Charts Coming Soon", "Chart components will be demonstrated here.")
                                .Color(TablerColor.Info);
                        });
                    });
                });
            })
            .AddPage("profile", "User Profile", page => {
                page.Row(row => {
                    row.Column(TablerColumnNumber.Four, col => {
                        col.Card(card => {
                            card.Avatar()
                                .Size(AvatarSize.XL)
                                .Icon(TablerIconType.User)
                                .BackgroundColor(TablerColor.Primary);
                            card.H3("John Doe");
                            card.Add(new TablerText("john.doe@example.com").Style(TablerTextStyle.Muted));
                        });
                    });
                    row.Column(TablerColumnNumber.Eight, col => {
                        col.Card(card => {
                            card.Header(h => h.Title("Profile Information"));
                            card.DataGrid(grid => {
                                grid.AddItem("Full Name", "John Doe");
                                grid.AddItem("Email", "john.doe@example.com");
                                grid.AddItem("Role", "Administrator");
                                grid.AddItem("Department", "IT");
                                grid.AddItem("Location", "New York, USA");
                            });
                        });
                    });
                });
            })
            .AddPage("settings", "Settings", page => {
                page.Row(row => {
                    row.Column(TablerColumnNumber.Twelve, col => {
                        col.Card(card => {
                            card.Header(h => h.Title("Application Settings"));
                            card.Tabs(tabs => {
                                tabs.AddTab("General", new TablerText("General settings content")).Active();
                                tabs.AddTab("Security", new TablerText("Security settings content"));
                                tabs.AddTab("Notifications", new TablerText("Notification preferences"));
                                tabs.AddTab("Advanced", new TablerText("Advanced settings"));
                            });
                        });
                    });
                });
            })
            .WithFooter("© 2024 HtmlForgeX. All rights reserved.")
        );

        document.Save("NavigationDemo.html", openInBrowser);
    }
}