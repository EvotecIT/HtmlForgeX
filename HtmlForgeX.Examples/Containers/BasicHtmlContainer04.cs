using HtmlForgeX.Tags;

namespace HtmlForgeX.Examples.Containers;
internal class BasicHtmlContainer04 {
    public static void Demo01(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("Basic Demo Document Container 4");

        // Create a list of simple objects
        var data = new List<dynamic> {
            new { Name = "John", Age = 30, Occupation = "Engineer" },
            new { Name = "Jane", Age = 28, Occupation = "Doctor" },
            new { Name = "Bob", Age = 35, Occupation = "Architect" }
        };

        var logs =
             """
            Effective URL            https://evotec.xyz
            Redirect count           0
            Name lookup time         3.4e-05
            Connect time             0.000521
            Pre-transfer time        0.0
            Start-transfer time      0.0
            App connect time         0.0
            Redirect time            0.0
            Total time               28.000601
            Response code            0
            Return keyword           operation_timedout
            """;

        var document = new Document {
            Head = {
                Title = "Basic Demo Document Container 4", Author = "Przemysław Kłys", Revised = DateTime.Now,
                AutoRefresh = 30
            },
            LibraryMode = LibraryMode.Online,
            ThemeMode = ThemeMode.Light
        };
        document.Body.Page(page => {
            page.Layout = TablerLayout.Fluid;
            page.Row(row => {
                // first line of 4 cards - now with custom RGBColor backgrounds!
                row.Column(TablerColumnNumber.Three, column => {
                    column.CardMini().Avatar(TablerIconType.BrandFacebook).BackgroundColor("#1877F2", "#FFFFFF") // Facebook blue
                        .Title("172 likes").Subtitle("2 today");
                });
                row.Column(TablerColumnNumber.Three, column => {
                    column.CardMini().Avatar(TablerIconType.BrandTwitter).BackgroundColor("#1DA1F2", "#FFFFFF") // Twitter blue
                        .Title("600 shares").Subtitle("16 today");
                });
                row.Column(TablerColumnNumber.Three, column => {
                    column.CardMini().Avatar(TablerIconType.ShoppingCart).BackgroundColor("#FF6B35", "#FFFFFF") // Custom orange
                        .Title("100 orders").Subtitle("0 today");
                });
                row.Column(TablerColumnNumber.Three, column => {
                    column.CardMini().Avatar(TablerIconType.CurrencyDollar).BackgroundColor("#10B981", "#FFFFFF") // Custom green
                        .Title("5 sales").Subtitle("3 waiting");
                });
                // second line of 3 cards
                row.Column(TablerColumnNumber.Four, column => {
                    // let's build a card with an avatar manually
                    column.Card(card => {
                        card.Row(cardTitle => {
                            cardTitle.HeaderLevel(HeaderLevelTag.H4, "Title").Class("card-title");
                        });
                        card.Row(cardRow => {
                            cardRow.Column(TablerColumnNumber.Auto, avatarColumn => {
                                avatarColumn.Avatar().Icon(TablerIconType.License).BackgroundColor(TablerColor.Cyan)
                                    .TextColor(TablerColor.Blue);
                            });
                            cardRow.Column(textColumn => {
                                textColumn.Text("132 sales").Weight(TablerFontWeight.Medium);
                                textColumn.Text("12 waiting payments").Style(TablerTextStyle.Muted);
                            });
                        });
                    });
                });
                row.Column(TablerColumnNumber.Four, column => {
                    column.Card(card => {
                        card.Add(new TablerAvatar().Icon(TablerIconType.License).BackgroundColor(TablerColor.Cyan)
                            .TextColor(TablerColor.Blue));
                    });
                });
                row.Column(TablerColumnNumber.Four, column => {
                    column.Card(card => {
                        card.ProgressBar(TablerProgressBarType.Small)
                            .Item(TablerColor.Primary, 44, "")
                            .Item(TablerColor.Info, 23, "")
                            .Item(TablerColor.Success, 33, "");
                        card.LineBreak();
                        card.ProgressBar(TablerProgressBarType.Small)
                            .Item(TablerColor.Primary, 44, "Test");
                        card.LineBreak();
                        card.ProgressBar(TablerProgressBarType.Separated)
                            .Item(TablerColor.Primary, 44, "Test")
                            .Item(TablerColor.Info, 23, "Test")
                            .Item(TablerColor.Success, 33, "Test");
                        card.LineBreak();
                        card.ProgressBar(TablerProgressBarType.Small, 50, TablerColor.Facebook);
                        card.LineBreak();
                        card.ProgressBar(TablerProgressBarType.Indeterminate, 100, TablerColor.Facebook);
                    });
                });
                row.Column(TablerColumnNumber.Four, column => {
                    column.Row(rowNested => {
                        rowNested.Column(TablerColumnNumber.Twelve, column => {
                            column.CardBasic("Currently Up for", "14 days 2 hours 54 minutes 32 seconds");
                        });
                        rowNested.Column(TablerColumnNumber.Twelve, column => {
                            column.CardBasic().Title("Last checked at").Text("27 seconds ago");
                        });
                        rowNested.Column(TablerColumnNumber.Twelve, column => {
                            column.CardBasic("Incidents", "3");
                        });
                        rowNested.Column(TablerColumnNumber.Twelve, column => {
                            column.CardBasic().Title("Uptime").Text("99.98%");
                        });
                    });
                });
                row.Column(TablerColumnNumber.Eight, column => {
                    column.Card(card => {
                        card.Logs("HTTP/1.1 200 Connection established", TablerLogsTheme.Primary).Title(HeaderLevelTag.H4, "Connection");
                        card.Logs(logs, TablerLogsTheme.Light).Title(HeaderLevelTag.H4, "Timings");
                    });

                });
                row.Column(TablerColumnNumber.Four, column => {
                    column.Card(card => {
                        card.Steps().Color(TablerColor.AzureLight)
                            .AddStep("Order received", TablerStepState.Completed)
                            .AddStep("Processing", TablerStepState.Active)
                            .AddStep("Shipped", TablerStepState.Pending)
                            .AddStep("Delivered", TablerStepState.Pending);

                    });
                });
                row.Column(TablerColumnNumber.Four, column => {
                    column.Card(card => {
                        card.Steps().Orientation(StepsOrientation.Vertical).Color(TablerColor.Facebook)
                            .AddStep("Order received", "Order confirmed and payment processed", TablerStepState.Completed)
                            .AddStep("Processing", "Items being prepared for shipment", TablerStepState.Active)
                            .AddStep("Shipped", "Package in transit", TablerStepState.Pending)
                            .AddStep("Delivered", "Package delivered to customer", TablerStepState.Pending);
                    });
                });
                row.Column(TablerColumnNumber.Four, column => {
                    column.Card(card => {
                        card.Steps().StepCounting().Color(TablerColor.Red)
                            .AddStep("Order received", TablerStepState.Completed)
                            .AddStep("Processing", TablerStepState.Active)
                            .AddStep("Shipped", TablerStepState.Pending)
                            .AddStep("Delivered", TablerStepState.Pending);
                    });
                });
                row.Column(TablerColumnNumber.Twelve, column => {
                    column.Card(card => {
                        card.Accordion(accordion => {
                            // Enhanced accordion with new features
                            accordion.Type(TablerAccordionType.Flush)
                                    .Color(TablerColor.Primary);

                            accordion.AddItem("📊 Project Overview", item => {
                                item.Icon(TablerIconType.FileDescription)
                                    .Expanded(true)
                                    .Content(new Span().AddContent("Enhanced accordion demonstration with icons and expanded state"));
                            });

                            accordion.AddItem("🔄 Order Processing", item => {
                                item.Icon(TablerIconType.Package)
                                    .Content(content => {
                                        content.Add(new Span().AddContent("Order tracking with enhanced steps:"));
                                        content.Add(new TablerSteps().StepCounting().Color(TablerColor.Success)
                                            .AddStep("Order received", TablerStepState.Completed)
                                            .AddStep("Processing", TablerStepState.Active)
                                            .AddStep("Shipped", TablerStepState.Pending)
                                            .AddStep("Delivered", TablerStepState.Pending));
                                    });
                            });

                            accordion.AddItem("⚙️ System Status", item => {
                                item.Icon(TablerIconType.Settings)
                                    .Content(content => {
                                        content.Add(new Span().AddContent("Service monitoring dashboard:"));
                                        content.Add(new TablerSteps().Orientation(StepsOrientation.Vertical).Color(TablerColor.Info)
                                            .AddStep("Web Server", "Running normally", TablerStepState.Completed)
                                            .AddStep("Database", "Connection healthy", TablerStepState.Completed)
                                            .AddStep("Cache", "Performance optimized", TablerStepState.Active));
                                    });
                            });

                            accordion.AddItem("📋 Data Summary", item => {
                                item.Icon(TablerIconType.Table)
                                    .Content(content => {
                                        content.DataGrid(grid => {
                                            grid.AddItem("Total Orders", "1,247");
                                            grid.AddItem("Active Users", "892");
                                            grid.AddItem("Revenue", "$45,234");
                                        });
                                    });
                            });
                        });
                    });
                });
                row.Column(TablerColumnNumber.Six, column => {
                    column.Card(card => {
                        card.Logs("HTTP/1.1 200 Connection established").Title(HeaderLevelTag.H4, "Connection");
                        card.Footer().Logs(logs).Title(HeaderLevelTag.H4, "Timings");

                    });
                });

                row.Column(TablerColumnNumber.Six, column => {
                    column.Card(card => {
                        card.Logs("HTTP/1.1 200 Connection established").Title(HeaderLevelTag.H4, "Connection");

                        card.Footer(cardFooter => {
                            cardFooter.Logs(logs).Title(HeaderLevelTag.H4, "Timings");
                            cardFooter.Logs(logs).Title(HeaderLevelTag.H4, "Timings");
                        });

                    });
                });

                row.Column(TablerColumnNumber.Six, column => {
                    column.Card(card => {
                        card.Row(rowWithinCard => {
                            rowWithinCard.Column(TablerColumnNumber.Twelve, column => {
                                column.CardBasic("Currently Up for", "14 days 2 hours 54 minutes 32 seconds");
                            });
                            rowWithinCard.Column(TablerColumnNumber.Twelve, column => {
                                column.CardBasic().Title("Last checked at").Text("27 seconds ago");
                            });
                        });
                    });
                });
                row.Column(TablerColumnNumber.Six, column => {
                    column.Card(card => {
                        card.Row(rowWithinCard => {
                            rowWithinCard.Column(TablerColumnNumber.MediumAuto, column => {
                                column.CardBasic("Currently Up for", "14 days 2 hours 54 minutes 32 seconds");
                            });
                            rowWithinCard.Column(TablerColumnNumber.MediumAuto, column => {
                                column.CardBasic().Title("Last checked at").Text("27 seconds ago");
                            });
                        });
                    });
                });

                row.Column(TablerColumnNumber.Six, column => {
                    column.Tabs(tabs => {
                        //tabs.Navigation(TabNavigation.Fill);
                        tabs.AddTab("Tab 1", new Strong("Content 1")).Active();
                        tabs.AddTab("Tab 2", new Strong("Content 2")).Disabled();
                        tabs.AddTab("Tab 3", new Strong("Content 3")).MoveTabs(TabState.MoveStart);
                    });
                });
                row.Column(TablerColumnNumber.Six, column => {
                    column.Tabs(tabs => {
                        //tabs.Navigation(TabNavigation.Fill);
                        tabs.AddTab("Tab With Tracking", tab => {
                            tab.Text("This is tracking");
                            tab.Tracking()
                                .Block("Operational", TablerColor.Success)
                                .Block("Operational", TablerColor.Success)
                                .Block("Operational", TablerColor.Success)
                                .Block("Operational", TablerColor.Success)
                                .Block("Operational", TablerColor.Success)
                                .Block("No data", TablerColor.Failed)
                                .Block("No data", TablerColor.Failed)
                                .Block("Operational", TablerColor.Success)
                                .Block("Operational", TablerColor.Success)
                                .Block("Operational", TablerColor.Success)
                                .Block("Operational", TablerColor.Success)
                                .Block("Operational", TablerColor.Success)
                                .Block("Downtime", TablerColor.Danger)
                                .Block("Operational", TablerColor.Success)
                                .Block("Operational", TablerColor.Success)
                                .Block("Operational", TablerColor.Success)
                                .Block("Operational", TablerColor.Success)
                                .Block("Operational", TablerColor.Success)
                                .Block("Operational", TablerColor.Success);
                        }).Active();

                        tabs.AddTab("Tab 2", new Strong("Content 2")).Disabled();
                        tabs.AddTab("Tab 3", new Strong("Content 3")).MoveTabs(TabState.MoveStart);
                    });
                });

            });

            page.Divider("Test2");

            page.Row(row => {
                // first line of 4 cards
                row.Column(TablerColumnNumber.Three, column => {
                    column.Card(card => {
                        card.Alert("Wow! Everything worked!", "Your account has been created!")
                            .Icon(TablerIconType.BrandTwitter).Color(TablerColor.Danger);
                    });
                });
                row.Column(TablerColumnNumber.Three, column => {
                    column.Card(card => {
                        card.Alert("Wow! Everything worked!", "Your account has been created!")
                            .Color(TablerColor.Facebook);
                    });
                });
                row.Column(TablerColumnNumber.Three, column => {
                    column.Card(card => {
                        card.Alert("Did you know?", "Here is something that you might like to know.", TablerColor.Green,
                            TablerAlertType.Dismissible).Icon(TablerIconType.InfoCircle);
                    });
                });
                row.Column(TablerColumnNumber.Three, column => {
                    column.Card(card => {
                        card.Alert("Wow! Everything worked!", "Your account has been created!")
                            .Icon(TablerIconType.ExclamationCircle).Color(TablerColor.Twitter);
                    });
                });
                row.Column(TablerColumnNumber.Three, column => {
                    column.Card(card => {
                        card.Alert("I'm so sorry…", "Your account has been deleted and can't be restored.")
                            .Icon(TablerIconType.FaceIdError).Color(TablerColor.Warning);
                    });
                });
                row.Column(TablerColumnNumber.Three, column => {
                    column.Card(card => {
                        card.Tracking()
                            .Block("Operational", TablerColor.Success)
                            .Block("Operational", TablerColor.Success)
                            .Block("Operational", TablerColor.Success)
                            .Block("Operational", TablerColor.Success)
                            .Block("Operational", TablerColor.Success)
                            .Block("No data", TablerColor.Failed)
                            .Block("No data", TablerColor.Failed)
                            .Block("Operational", TablerColor.Success)
                            .Block("Operational", TablerColor.Success)
                            .Block("Operational", TablerColor.Success)
                            .Block("Operational", TablerColor.Success)
                            .Block("Operational", TablerColor.Success)
                            .Block("Downtime", TablerColor.Danger)
                            .Block("Operational", TablerColor.Success)
                            .Block("Operational", TablerColor.Success)
                            .Block("Operational", TablerColor.Success)
                            .Block("Operational", TablerColor.Success)
                            .Block("Operational", TablerColor.Success)
                            .Block("Operational", TablerColor.Success);
                    });
                });
                row.Column(TablerColumnNumber.Three, column => {
                    column.Card(card => {
                        card.Avatar().Icon(TablerIconType.BrandTwitter).Margin(TablerMarginStyle.M2);
                    });
                });
                row.Column(TablerColumnNumber.Three, column => {
                    column.Card(card => {
                        card.Avatar()
                            .Image(
                                "https://upload.wikimedia.org/wikipedia/commons/thumb/6/61/HTML5_logo_and_wordmark.svg/1920px-HTML5_logo_and_wordmark.svg.png")
                            .Size(AvatarSize.MD)
                            .Margin(TablerMarginStyle.M2);
                    });
                });
            });
        });
        document.Save("BasicDemoDocumentContainer04.html", openInBrowser);
    }
}
