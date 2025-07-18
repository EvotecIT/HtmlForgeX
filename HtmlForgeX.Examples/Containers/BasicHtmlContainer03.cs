namespace HtmlForgeX.Examples.Containers;

internal class BasicHtmlContainer03 {
    public static void Demo03(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("Basic Demo Document Container 3");

        // Create a list of simple objects
        var data = new List<dynamic> {
            new { Name = "John", Age = 30, Occupation = "Engineer" },
            new { Name = "Jane", Age = 28, Occupation = "Doctor" },
            new { Name = "Bob", Age = 35, Occupation = "Architect" }
        };

        var data1 = new List<dynamic> {
            new { Name = "John", Age = 30, Occupation = "Engineer" },
            new { Name = "Jane", Age = 28, Occupation = "Doctor" },
            new { Name = "Bob", Age = 35, Occupation = "Architect" },
            new { Name = "John", Age = 30, Occupation = "Engineer" },
        };

        var data2 = new List<dynamic> {
            new { Name = "John", Age = 30, Occupation = "Engineer" },
            new { Name = "Jane", Age = 28, Occupation = "Doctor" },
        };

        using var document = new Document {
            Head = {
                Title = "Basic Demo Document Container 3", Author = "Przemysław Kłys", Revised = DateTime.Now
            },
            LibraryMode = LibraryMode.Online,
            ThemeMode = ThemeMode.Light
        };
        document.Body.Page(page => {
            page.Layout = TablerLayout.Fluid;
            page.Row(row => {
                // first line of 4 cards
                row.Column(TablerColumnNumber.Three, column => {
                    column.CardMini().Avatar(TablerIconType.BrandFacebook).BackgroundColor(TablerColor.Facebook)
                        .TextColor(TablerColor.White).Title("172 likes").Subtitle("2 today");
                });
                row.Column(TablerColumnNumber.Three, column => {
                    column.CardMini().Avatar(TablerIconType.BrandTwitter).BackgroundColor(TablerColor.Twitter)
                        .TextColor(TablerColor.White).Title("600 shares").Subtitle("16 today");
                });
                row.Column(TablerColumnNumber.Three, column => {
                    column.CardMini().Avatar(TablerIconType.Basket).BackgroundColor(TablerColor.CyanLight)
                        .TextColor(TablerColor.Orange).Title("100 orders").Subtitle("0 today");
                });
                row.Column(TablerColumnNumber.Three, column => {
                    column.CardMini().Avatar(TablerIconType.BasketDollar).BackgroundColor(TablerColor.OrangeLight)
                        .TextColor(TablerColor.White).Title("5 sales").Subtitle("3 waiting");
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
                                avatarColumn.Avatar().Icon(TablerIconType.BrandMastercard).BackgroundColor(TablerColor.Gray300)
                                    .TextColor(TablerColor.Pink);
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
                        card.Add(new TablerAvatar().Icon(TablerIconType.BrandMastercard).BackgroundColor(TablerColor.BlueLight)
                            .TextColor(TablerColor.Flickr));
                    });
                });
                row.Column(TablerColumnNumber.Four, column => {
                    column.CardMini().Avatar(TablerIconType.BrandMastercard);

                });

                row.Column(TablerColumnNumber.Four, column => {
                    column.Card(card => {
                        card.Span("This is inside card").AddContent(" with some color").WithColor(RGBColor.Amber);
                        card.LineBreak();
                        card.Span("This is continuing after").AppendContent(" linebreak ").WithColor(RGBColor.RedDevil)
                            .AppendContent(" cool?");
                    });
                });
                row.Column(TablerColumnNumber.Eight, column => {
                    column.Card(card => {
                        var table1 = (DataTablesTable)card.Table(data, TableType.DataTables);
                        table1.EnableOrdering(false).EnableSearching(false);
                    });
                });
                row.Column(TablerColumnNumber.Eight, column => {
                    column.Card(card => {
                        card.DataGrid(dataGrid => {
                            dataGrid.AddItem("Registrar", "Third Party");
                            dataGrid.AddItem("Port number", "3306");
                            dataGrid.AddItem("Creator", "Przemysław Kłys");
                            dataGrid.AddItem("Edge network", new TablerBadgeStatus("Active", TablerColor.Green));
                            dataGrid.Title("Domain Information").Content("This is the domain information");
                            dataGrid.AddItem("Expiration date", DateTime.Now.AddDays(5).ToString());
                            dataGrid.AddItem("Age", "5 days");
                            dataGrid.Title("Expiring").Content(new TablerBadgeSpan("Soon", TablerColor.Azure,
                                textColor: TablerColor.White));
                            dataGrid.Title("Registrar").Content(new TablerBadgeSpan("Testing", TablerColor.OrangeLight,
                                TablerBadgeStyle.Normal));
                            dataGrid.Title("Pill").Content(new TablerBadgeSpan("1", TablerColor.Azure,
                                TablerBadgeStyle.Pill, TablerColor.White));
                            dataGrid.Title("Outline").Content(new TablerBadgeSpan("Testing", TablerColor.Azure,
                                TablerBadgeStyle.Outline, TablerColor.Cyan));
                            dataGrid.Title("Text Color").Content(new TablerBadgeSpan("Testing", TablerColor.Facebook,
                                TablerBadgeStyle.Normal, TablerColor.Green));
                            dataGrid.Title("Normal").Content(new TablerBadgeSpan("Testing", TablerColor.AzureLight,
                                TablerBadgeStyle.Normal));
                            dataGrid.Title("Tag").Content(new TablerTag("New", TablerColor.Lime).Dismissable());
                            dataGrid.Title("Large Tag").Content(new TablerTag("Download", TablerColor.Green).TagSize(TablerTagSize.Large).Dismissable());

                        });
                    });
                });
                row.Column(TablerColumnNumber.Four, column => {
                    column.Card(4, card => {
                        card.FancyTree(fancyTree => {
                            fancyTree.AutoScroll(true).MinimumExpandLevel(2);
                            fancyTree.Title("Enable TSDebugMode")
                                .Icon("https://cdn-icons-png.flaticon.com/512/5610/5610944.png");
                            fancyTree.Title("Check OS UBR")
                                .Icon("https://cdn-icons-png.flaticon.com/512/1294/1294758.png");
                            fancyTree.Title("OS is not supported - Needs to be Updated");
                            fancyTree.Title("OS Supported")
                                .AddNode(new FancyTreeNode("Pre-Check",
                                    "https://cdn-icons-png.flaticon.com/512/1294/1294758.png", true))
                                .AddNode(node => {
                                    node.Title("Checking if DB is up and running");
                                    node.AddNode(nextNode => {
                                        nextNode.Title("DB is up and running");
                                        nextNode.AddNode("Testing DB Connection");
                                        nextNode.AddNode("DB Connection Successful");
                                    });
                                });

                            fancyTree.Title("Test");
                            fancyTree.Title("OS Not Supported").AddNode(node => {
                                node.Title("Shutdown PC");
                                node.AddNode("Node nested under Shutdown 2-1");
                                node.AddNode("Node nested under Shutdown 2-2");
                            });
                            fancyTree.Title("Other").Icon("https://cdn-icons-png.flaticon.com/512/5610/5610944.png")
                                .AddNode(node => {
                                    node.Title("PC Start Up")
                                        .Icon("https://cdn-icons-png.flaticon.com/512/1294/1294758.png").AddNode(
                                            nestedNode => {
                                                nestedNode.Title("Cleanup");
                                            });
                                });
                            // Creates nesting of node, within node, within node, within node
                            fancyTree.Title("Test")
                                .AddNode("PC Start Up")
                                .AddNode("Cleanup")
                                .AddNode("PC Shut Down", "https://cdn-icons-png.flaticon.com/512/10309/10309341.png");

                        });
                    });
                });
                row.Column(TablerColumnNumber.Four, column => {
                    column.Card(4, card => {
                        card.ApexChart(chart => {
                            chart.Title.Text("Pie Chart").Color(RGBColor.FruitSalad);
                            chart.AddPie("Pie 1", 30).AddPie("Pie 2", 40).AddPie("Pie 3", 50);
                        });
                    });
                });
                row.Column(TablerColumnNumber.Four, column => {
                    column.Card(card => {
                        card.ApexChart(chart => {
                            chart.Title.Text("Bar chart");
                            chart.AddBar("Bar 1", 30).AddBar("Bar 2", 40).AddBar("Barat 3", 50);
                        });
                    });
                });
                row.Column(TablerColumnNumber.Four, column => {
                    column.Card(card => {
                        card.ApexChart(chart => {
                            chart.Title.Text("Donut Chart").Color(RGBColor.FruitSalad);
                            chart.AddDonut("Donut 1", 30).AddDonut("Donut 2", 40).AddDonut("Donut 3", 50);
                        });
                    });
                });
                row.Column(TablerColumnNumber.Eight, column => {
                    column.Card(card => {
                        card.DiagramNetwork(diagam => {
                            diagam.AddNode(new { id = 1, label = "Node 1" });
                            diagam.AddNode(new { id = 2, label = "Node 2" });
                            diagam.AddNode(new { id = 3, label = "Node 3" });
                            diagam.AddEdge(new { from = 1, to = 2 });
                            diagam.AddEdge(new { from = 2, to = 3 });
                            diagam.WithOptions(options => {
                                options.WithNodes(nodes => {
                                    nodes.WithShape(VisNetworkNodeShape.Box);
                                });
                                options.WithEdges(edges => {
                                    edges.WithArrows(new VisNetworkArrowOptions().WithTo(true));
                                });
                            });
                        });
                    });
                });
                row.Column(TablerColumnNumber.Four, column => {
                    column.Card(card => {
                        card.QRCode("https://evotec.xyz");
                    });
                });
                // this will add a new row and push it all wide
                row.Column(TablerColumnNumber.Twelve, column => {
                    column.Card(card => {
                        card.Span("This is inside card").AddContent(" with some color").WithColor(RGBColor.Amber);
                        card.LineBreak();
                        card.Span("This is continuing after").AppendContent(" linebreak ").WithColor(RGBColor.RedDevil)
                            .AppendContent(" cool?");
                        var table1 =
                            ((DataTablesTable)card.Table(data, TableType.DataTables))
                            .Style(BootStrapTableStyle.Striped);
                        table1.EnableOrdering();
                        table1.EnableSearching();
                        table1.Scrolling(scrollX: true);
                    });
                });
                row.Column(TablerColumnNumber.Eight, column => {
                    column.Card(card => {
                        card.FullCalendar(calendar => {
                            calendar.NowIndicator(true).NavLinks(true).BusinessHours(true);
                            calendar.AddEvent("Test Event", "Special event", DateTime.Today.AddHours(16))
                                .Url("https://evotec.xyz").TextColor(RGBColor.BlueMarguerite);
                            calendar
                                .AddEvent("Test Event 2", "Special event 2", DateTime.Today.AddDays(1).AddHours(13))
                                .Color(RGBColor.Yellow);

                            calendar.Options.EventClick = @"function(info) {
                                alert('Clicked ' + info.event.title);
                            }";

                            calendar.AddHeaderToolbar()
                                .Left(FullCalendarToolbarOption.Prev, FullCalendarToolbarOption.Next,
                                    FullCalendarToolbarOption.Today)
                                .Center(FullCalendarToolbarOption.Title)
                                .Right(FullCalendarToolbarOption.DayGridMonth, FullCalendarToolbarOption.TimeGridWeek,
                                    FullCalendarToolbarOption.TimeGridDay, FullCalendarToolbarOption.ListMonth);
                        });

                    });
                });
                row.Column(TablerColumnNumber.Three, column => {
                    column.Card(card => {
                        card.TablerList().AddItem("Test", TablerIconType.BrandAirtable).AddItem("test2", TablerIconType.AB);
                    });
                });
            });
        });

        document.Save("BasicDemoDocumentContainer03.html", openInBrowser);
    }
}
