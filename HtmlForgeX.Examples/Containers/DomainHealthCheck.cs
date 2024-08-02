using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HtmlForgeX.Tags;

namespace HtmlForgeX.Examples.Containers;
internal class DomainHealthCheck {
    public static void Demo01(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("Domain Health Check Idea");

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
                Title = "Domain Health Check Idea", Author = "Przemysław Kłys", Revised = DateTime.Now
            },
            LibraryMode = LibraryMode.Online,
            ThemeMode = ThemeMode.Light
        };
        document.Body.Page(page => {
            page.Layout = TablerLayout.Boxed;
            page.Row(row => {

                row.Column(TablerColumnNumber.Twelve, column => {
                    column.Card(card => {
                        card.Row(cardTitle => {
                            cardTitle.HeaderLevel(HeaderLevelTag.H4, "Security Rating").Class("card-title");
                        });
                        card.Row(cardRow => {
                            //cardRow.Column(TablerColumnNumber.Auto, avatarColumn => {
                            //    avatarColumn.Avatar().Icon(TablerIcon.License).BackgroundColor(TablerColor.Gray300).TextColor(TablerColor.Pink);
                            //});
                            cardRow.Column(TablerColumnNumber.Three, textColumn => {
                                textColumn.Add(new TablerIconElement(TablerIcon.ShieldCheck).FontSize(115).Color(RGBColor.LightGreen));
                            });
                            cardRow.Column(TablerColumnNumber.Three, textColumn => {
                                textColumn.HeaderLevel(HeaderLevelTag.H4, "OUTBOUND EMAIL").Class("card-title");
                                textColumn.DataGrid(dataGrid => {
                                    dataGrid.AddItem("SPF", new TablerBadgeSpan("soft fail", TablerColor.Green, TablerBadgeStyle.Normal, TablerColor.White));
                                    dataGrid.AddItem("DKIM", new TablerBadgeSpan("yes, 2 selectors known", TablerColor.GreenLight));
                                    dataGrid.AddItem("DMARC", new TablerBadgeSpan("reject", TablerColor.GreenLight));
                                    dataGrid.AddItem("BIMI", new TablerBadgeSpan("yes, 1 selector is known", TablerColor.GreenLight));
                                });
                            });

                            cardRow.Column(TablerColumnNumber.Three, textColumn => {
                                textColumn.HeaderLevel(HeaderLevelTag.H4, "INBOUND EMAIL").Class("card-title");
                                textColumn.DataGrid(dataGrid => {
                                    dataGrid.AddItem("TLS (STARTTLS)", new TablerBadgeSpan("supported by all MX", TablerColor.Green, TablerBadgeStyle.Normal, TablerColor.White));
                                    dataGrid.AddItem("MTA-STS", "enforce");
                                    dataGrid.AddItem("TLSA (DANE)", new TablerBadgeSpan("no", TablerColor.RedLight));
                                    dataGrid.AddItem("TLS reporting", new TablerBadgeSpan("yes", TablerColor.GreenLight));
                                });
                            });

                            cardRow.Column(TablerColumnNumber.Three, textColumn => {
                                textColumn.HeaderLevel(HeaderLevelTag.H4, "DOMAIN").Class("card-title");
                                textColumn.DataGrid(dataGrid => {
                                    dataGrid.AddItem("Name", "evotec.xyz");
                                    dataGrid.AddItem("DNSSEC", new TablerBadgeSpan("yes", TablerColor.GreenLight));
                                    dataGrid.AddItem("Monitoring", new TablerBadgeSpan("yes", TablerColor.GreenLight));

                                });
                            });
                        });

                    });
                });

                // first line of 4 cards
                //row.Column(TablerColumnNumber.Three, column => {
                //    column.CardMini().Avatar(TablerIcon.BrandFacebook).BackgroundColor(TablerColor.Facebook)
                //        .TextColor(TablerColor.White).Title("172 likes").Subtitle("2 today");
                //});
                //row.Column(TablerColumnNumber.Three, column => {
                //    column.CardMini().Avatar(TablerIcon.BrandTwitter).BackgroundColor(TablerColor.Twitter)
                //        .TextColor(TablerColor.White).Title("600 shares").Subtitle("16 today");
                //});
                //row.Column(TablerColumnNumber.Three, column => {
                //    column.CardMini().Avatar(TablerIcon.ShoppingCart).BackgroundColor(TablerColor.Gray200)
                //        .TextColor(TablerColor.Orange).Title("100 orders").Subtitle("0 today");
                //});
                //row.Column(TablerColumnNumber.Three, column => {
                //    column.CardMini().Avatar(TablerIcon.CurrencyDollar).BackgroundColor(TablerColor.CyanLight)
                //        .TextColor(TablerColor.White).Title("5 sales").Subtitle("3 waiting");
                //});
                // second line of 3 cards
                //row.Column(TablerColumnNumber.Four, column => {
                //    // let's build a card with an avatar manually
                //    column.Card(card => {
                //        card.Row(cardTitle => {
                //            cardTitle.HeaderLevel(HeaderLevelTag.H4, "Title").Class("card-title");
                //        });
                //        card.Row(cardRow => {
                //            cardRow.Column(TablerColumnNumber.Auto, avatarColumn => {
                //                avatarColumn.Avatar().Icon(TablerIcon.License).BackgroundColor(TablerColor.Cyan)
                //                    .TextColor(TablerColor.Blue);
                //            });
                //            cardRow.Column(textColumn => {
                //                textColumn.Text("132 sales").Weight(TablerFontWeight.Medium);
                //                textColumn.Text("12 waiting payments").Style(TablerTextStyle.Muted);
                //            });
                //        });
                //    });
                //});
                //row.Column(TablerColumnNumber.Four, column => {
                //    column.Card(card => {
                //        card.Add(new TablerAvatar().Icon(TablerIcon.License).BackgroundColor(TablerColor.Cyan)
                //            .TextColor(TablerColor.Blue));
                //    });
                //});
                //row.Column(TablerColumnNumber.Four, column => {
                //    column.Card(card => {
                //        card.ProgressBar(TablerProgressBarType.Small)
                //            .Item(TablerColor.Primary, 44, "")
                //            .Item(TablerColor.Info, 23, "")
                //            .Item(TablerColor.Success, 33, "");
                //        card.LineBreak();
                //        card.ProgressBar(TablerProgressBarType.Small)
                //            .Item(TablerColor.Primary, 44, "Test");
                //        card.LineBreak();
                //        card.ProgressBar(TablerProgressBarType.Separated)
                //            .Item(TablerColor.Primary, 44, "Test")
                //            .Item(TablerColor.Info, 23, "Test")
                //            .Item(TablerColor.Success, 33, "Test");
                //        card.LineBreak();
                //        card.ProgressBar(TablerProgressBarType.Small, 50, TablerColor.Facebook);
                //        card.LineBreak();
                //        card.ProgressBar(TablerProgressBarType.Indeterminate, 100, TablerColor.Facebook);
                //    });
                //});
                //row.Column(TablerColumnNumber.Four, column => {
                //    column.Row(rowNested => {
                //        rowNested.Column(TablerColumnNumber.Twelve, column => {
                //            column.CardBasic("Currently Up for", "14 days 2 hours 54 minutes 32 seconds");
                //        });
                //        rowNested.Column(TablerColumnNumber.Twelve, column => {
                //            column.CardBasic().Title("Last checked at").Text("27 seconds ago");
                //        });
                //        rowNested.Column(TablerColumnNumber.Twelve, column => {
                //            column.CardBasic("Incidents", "3");
                //        });
                //        rowNested.Column(TablerColumnNumber.Twelve, column => {
                //            column.CardBasic().Title("Uptime").Text("99.98%");
                //        });
                //    });
                //});
                //row.Column(TablerColumnNumber.Eight, column => {
                //    column.Card(card => {
                //        card.Logs("HTTP/1.1 200 Connection established").Title(HeaderLevelTag.H4, "Connection");
                //        card.Logs(logs).Title(HeaderLevelTag.H4, "Timings");
                //    });

                //});
                //row.Column(TablerColumnNumber.Four, column => {
                //    column.Card(card => {
                //        card.Steps().Color(TablerColor.AzureLight)
                //            .AddStep("Order received", false)
                //            .AddStep("Processing", true)
                //            .AddStep("Shipped", false)
                //            .AddStep("Delivered", false);

                //    });
                //});
                //row.Column(TablerColumnNumber.Four, column => {
                //    column.Card(card => {
                //        card.Steps().Orientation(StepsOrientation.Vertical).Color(TablerColor.Facebook)
                //            .AddStep("Order received", "text", false)
                //            .AddStep("Processing", "more text", true)
                //            .AddStep("Shipped", "oops", false)
                //            .AddStep("Delivered", "opps", false);
                //    });
                //});
                //row.Column(TablerColumnNumber.Four, column => {
                //    column.Card(card => {
                //        card.Steps().StepCounting().Color(TablerColor.Red)
                //            .AddStep("Order received", false)
                //            .AddStep("Processing", true)
                //            .AddStep("Shipped", false)
                //            .AddStep("Delivered", false);
                //    });
                //});
                //row.Column(TablerColumnNumber.Twelve, column => {
                //    column.Card(card => {
                //        card.Accordion(accordion => {
                //            // works
                //            accordion.AddItem("John", new Span().AddContent("Test1"));
                //            // works
                //            accordion.AddItem("Jane", new Span().AddContent("Test2"));
                //            // works 
                //            accordion.AddItem("Johny", item => {
                //                item.Content(new Span().AddContent("Test2"));
                //                item.Content(new TablerSteps().StepCounting().Color(TablerColor.Red)
                //                    .AddStep("Order received", false)
                //                    .AddStep("Processing", true)
                //                    .AddStep("Shipped", false)
                //                    .AddStep("Delivered", false));
                //            });
                //            accordion.AddItem("Johny 2").Content(item => {
                //                item.Steps().StepCounting().Color(TablerColor.Red)
                //                    .AddStep("Order received", false)
                //                    .AddStep("Processing", true)
                //                    .AddStep("Shipped", false)
                //                    .AddStep("Delivered", false);
                //            });

                //            accordion.AddItem("Johny 2").Content(item => {
                //                item.DataGrid(grid => {
                //                    grid.AddItem("Test", "Ok");
                //                    grid.AddItem("Test2", "Ok2");
                //                });
                //            });
                //        });
                //    });
                //});
                //row.Column(TablerColumnNumber.Six, column => {
                //    column.Card(card => {
                //        card.Logs("HTTP/1.1 200 Connection established").Title(HeaderLevelTag.H4, "Connection");
                //        card.Footer().Logs(logs).Title(HeaderLevelTag.H4, "Timings");

                //    });
                //});

                //row.Column(TablerColumnNumber.Six, column => {
                //    column.Card(card => {
                //        card.Logs("HTTP/1.1 200 Connection established").Title(HeaderLevelTag.H4, "Connection");

                //        card.Footer(cardFooter => {
                //            cardFooter.Logs(logs).Title(HeaderLevelTag.H4, "Timings");
                //            cardFooter.Logs(logs).Title(HeaderLevelTag.H4, "Timings");
                //        });

                //    });
                //});

                //row.Column(TablerColumnNumber.Six, column => {
                //    column.Card(card => {
                //        card.Row(rowWithinCard => {
                //            rowWithinCard.Column(TablerColumnNumber.Twelve, column => {
                //                column.CardBasic("Currently Up for", "14 days 2 hours 54 minutes 32 seconds");
                //            });
                //            rowWithinCard.Column(TablerColumnNumber.Twelve, column => {
                //                column.CardBasic().Title("Last checked at").Text("27 seconds ago");
                //            });
                //        });
                //    });
                //});
                //row.Column(TablerColumnNumber.Six, column => {
                //    column.Card(card => {
                //        card.Row(rowWithinCard => {
                //            rowWithinCard.Column(TablerColumnNumber.MediumAuto, column => {
                //                column.CardBasic("Currently Up for", "14 days 2 hours 54 minutes 32 seconds");
                //            });
                //            rowWithinCard.Column(TablerColumnNumber.MediumAuto, column => {
                //                column.CardBasic().Title("Last checked at").Text("27 seconds ago");
                //            });
                //        });
                //    });
                //});

                //row.Column(TablerColumnNumber.Six, column => {
                //    column.Tabs(tabs => {
                //        //tabs.Navigation(TabNavigation.Fill);
                //        tabs.AddTab("Tab 1", new Strong("Content 1")).Active();
                //        tabs.AddTab("Tab 2", new Strong("Content 2")).Disabled();
                //        tabs.AddTab("Tab 3", new Strong("Content 3")).MoveTabs(TabState.MoveStart);
                //    });
                //});


            });

            page.Divider("Test2");

            page.Row(row => {
                // first line of 4 cards
                //row.Column(TablerColumnNumber.Three, column => {
                //    column.Card(card => {
                //        card.Alert("Wow! Everything worked!", "Your account has been created!")
                //            .Icon(TablerIcon.BrandTwitter).Color(TablerColor.Danger);
                //    });
                //});
                //row.Column(TablerColumnNumber.Three, column => {
                //    column.Card(card => {
                //        card.Alert("Wow! Everything worked!", "Your account has been created!")
                //            .Color(TablerColor.Facebook);
                //    });
                //});
                //row.Column(TablerColumnNumber.Three, column => {
                //    column.Card(card => {
                //        card.Alert("Did you know?", "Here is something that you might like to know.", TablerColor.Green,
                //            TablerAlertType.Dismissible).Icon(TablerIcon.InfoCircle);
                //    });
                //});
                //row.Column(TablerColumnNumber.Three, column => {
                //    column.Card(card => {
                //        card.Alert("Wow! Everything worked!", "Your account has been created!")
                //            .Icon(TablerIcon.ExclamationCircle).Color(TablerColor.Twitter);
                //    });
                //});
                //row.Column(TablerColumnNumber.Three, column => {
                //    column.Card(card => {
                //        card.Alert("I'm so sorry…", "Your account has been deleted and can't be restored.")
                //            .Icon(TablerIcon.FaceIdError).Color(TablerColor.Warning);
                //    });
                //});
                //row.Column(TablerColumnNumber.Three, column => {
                //    column.Card(card => {
                //        card.Tracking()
                //            .Block("Operational", TablerColor.Success)
                //            .Block("Operational", TablerColor.Success)
                //            .Block("Operational", TablerColor.Success)
                //            .Block("Operational", TablerColor.Success)
                //            .Block("Operational", TablerColor.Success)
                //            .Block("No data", TablerColor.Failed)
                //            .Block("No data", TablerColor.Failed)
                //            .Block("Operational", TablerColor.Success)
                //            .Block("Operational", TablerColor.Success)
                //            .Block("Operational", TablerColor.Success)
                //            .Block("Operational", TablerColor.Success)
                //            .Block("Operational", TablerColor.Success)
                //            .Block("Downtime", TablerColor.Danger)
                //            .Block("Operational", TablerColor.Success)
                //            .Block("Operational", TablerColor.Success)
                //            .Block("Operational", TablerColor.Success)
                //            .Block("Operational", TablerColor.Success)
                //            .Block("Operational", TablerColor.Success)
                //            .Block("Operational", TablerColor.Success);
                //    });
                //});
                //row.Column(TablerColumnNumber.Three, column => {
                //    column.Card(card => {
                //        card.Avatar().Icon(TablerIcon.BrandTwitter).Margin(TablerMarginStyle.M2);
                //    });
                //});
                //row.Column(TablerColumnNumber.Three, column => {
                //    column.Card(card => {
                //        card.Avatar()
                //            .Image(
                //                "https://upload.wikimedia.org/wikipedia/commons/thumb/6/61/HTML5_logo_and_wordmark.svg/1920px-HTML5_logo_and_wordmark.svg.png")
                //            .Size(AvatarSize.MD)
                //            .Margin(TablerMarginStyle.M2);
                //    });
                //});
            });
        });
        document.Save("DomainHealthCheck.html", openInBrowser);
    }
}
