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

        var logs = @"
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
";

        var document = new Document {
            Head = {
                Title = "Basic Demo Document Container 4", Author = "Przemysław Kłys", Revised = DateTime.Now
            },
            LibraryMode = LibraryMode.Online,
            ThemeMode = ThemeMode.Light
        };
        document.Body.Page(page => {
            page.Layout = TablerLayout.Fluid;
            page.Row(row => {
                // first line of 4 cards
                row.Column(TablerColumnNumber.Three, column => {
                    column.CardMini().Avatar(TablerIcon.BrandFacebook).BackgroundColor(TablerBadgeColor.Blue).TextColor(TablerBadgeColor.White).Title("172 likes").Subtitle("2 today");
                });
                row.Column(TablerColumnNumber.Three, column => {
                    column.CardMini().Avatar(TablerIcon.BrandTwitter).BackgroundColor(TablerBadgeColor.Blue).TextColor(TablerBadgeColor.White).Title("600 shares").Subtitle("16 today");
                });
                row.Column(TablerColumnNumber.Three, column => {
                    column.CardMini().Avatar(TablerIcon.ShoppingCart).BackgroundColor(TablerBadgeColor.Cyan).TextColor(TablerBadgeColor.Orange).Title("100 orders").Subtitle("0 today");
                });
                row.Column(TablerColumnNumber.Three, column => {
                    column.CardMini().Avatar(TablerIcon.CurrencyDollar).BackgroundColor(TablerBadgeColor.Azure).TextColor(TablerBadgeColor.White).Title("5 sales").Subtitle("3 waiting");
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
                                avatarColumn.Avatar().Icon(TablerIcon.License).BackgroundColor(TablerBadgeColor.Cyan).TextColor(TablerBadgeColor.Blue);
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
                        card.Add(new TablerAvatar().Icon(TablerIcon.License).BackgroundColor(TablerBadgeColor.Cyan).TextColor(TablerBadgeColor.Blue));
                    });
                });
                row.Column(TablerColumnNumber.Four, column => {
                    column.Card(card => {
                        // card.Add(new TablerProgressBar(TablerProgressBarType.Regular, TablerProgressBarType.Small));
                        card.ProgressBar(TablerProgressBarType.Small).AddItem(TablerBackground.Primary, 44, "")
                            .AddItem(TablerBackground.Info, 23, "")
                            .AddItem(TablerBackground.Success, 33, "");
                        card.LineBreak();
                        card.ProgressBar(TablerProgressBarType.Small).AddItem(TablerBackground.Primary, 44, "Test");
                        card.LineBreak();
                        card.ProgressBar(TablerProgressBarType.Separated).AddItem(TablerBackground.Primary, 44, "Test")
                            .AddItem(TablerBackground.Info, 23, "Test")
                            .AddItem(TablerBackground.Success, 33, "Test");
                        card.LineBreak();
                        card.ProgressBar(TablerProgressBarType.Small, 50, TablerBackground.FaceBook);

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
                        card.Logs("HTTP/1.1 200 Connection established").Title(HeaderLevelTag.H4, "Connection");
                        card.Logs(logs).Title(HeaderLevelTag.H4, "Timings");
                    });

                });
                row.Column(TablerColumnNumber.Four, column => {
                    column.Card(card => {
                        card.Steps()
                            .AddStep("Order received", false)
                            .AddStep("Processing", true)
                            .AddStep("Shipped", false)
                            .AddStep("Delivered", false);

                    });
                });
                row.Column(TablerColumnNumber.Four, column => {
                    column.Card(card => {
                        card.Steps().Orientation(StepsOrientation.Vertical)
                            .AddStep("Order received", "text", false)
                            .AddStep("Processing", "more text", true)
                            .AddStep("Shipped", "oops", false)
                            .AddStep("Delivered", "opps", false);
                    });
                });
                row.Column(TablerColumnNumber.Four, column => {
                    column.Card(card => {
                        card.Steps().StepCounting().Color(TablerStepsColor.Red)
                            .AddStep("Order received", false)
                            .AddStep("Processing", true)
                            .AddStep("Shipped", false)
                            .AddStep("Delivered", false);
                    });
                });
                row.Column(TablerColumnNumber.Twelve, column => {
                    column.Card(card => {
                        card.Accordion(accordion => {
                            // works
                            accordion.AddItem("John", new Span().AddContent("Test1"));
                            // works
                            accordion.AddItem("Jane", new Span().AddContent("Test2"));
                            // works 
                            accordion.AddItem("Johny", item => {
                                item.Content(new Span().AddContent("Test2"));
                                item.Content(new TablerSteps().StepCounting().Color(TablerStepsColor.Red)
                                    .AddStep("Order received", false)
                                    .AddStep("Processing", true)
                                    .AddStep("Shipped", false)
                                    .AddStep("Delivered", false));
                            });
                            accordion.AddItem("Johny 2").Content(item => {
                                item.Steps().StepCounting().Color(TablerStepsColor.Red)
                                     .AddStep("Order received", false)
                                     .AddStep("Processing", true)
                                     .AddStep("Shipped", false)
                                     .AddStep("Delivered", false);
                            });

                            accordion.AddItem("Johny 2").Content(item => {
                                item.DataGrid(grid => {
                                    grid.AddItem("Test", "Ok");
                                    grid.AddItem("Test2", "Ok2");
                                });
                            });
                        });
                    });
                });

            });
        });

        document.Save("BasicDemoDocumentContainer04.html", openInBrowser);
    }
}
