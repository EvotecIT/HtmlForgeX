namespace HtmlForgeX.Examples.Containers;

/// <summary>
/// Class for storing examples of basic scrolling text.
/// </summary>
internal class BasicScrollingText {
    /// <summary>
    /// Basic demo of scrolling text.
    /// </summary>
    /// <param name="openInBrowser"></param>
    public static void Create(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("Basic Demo Scrolling Text");

        using var document = new Document {
            Head = { Title = "Basic Demo Scrolling Text", Author = "Przemysław Kłys", Revised = DateTime.Now },
            LibraryMode = LibraryMode.Online,
            ThemeMode = ThemeMode.Light
        };
        document.Body.Page(page => {
            page.Layout = TablerLayout.Fluid;

            page.ScrollingText(scroll => {
                scroll.AddItem("Section 1", item => {
                    item.Text("Section 1 - Text 1");
                });
                scroll.AddItem("Section 2", item => {
                    item.Text("Section 2 - Text 1");
                });
                scroll.AddItem("MyTitle", item => {
                    item.Text("Text within MyTitle");
                    item.Text("Text within MyTitle2");
                    item.AddItem("Another title", subItem => {
                        subItem.Row(row => {
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
                                column.CardMini().Avatar(TablerIconType.BasketDollar)
                                    .BackgroundColor(TablerColor.OrangeLight)
                                    .TextColor(TablerColor.White).Title("5 sales").Subtitle("3 waiting");
                            });
                            subItem.AddItem("Sub Title 1", item2 => {
                                item2.Text("Text in theory in Sub Title 1");
                                item2.Text("Text in theory in Sub Title 2");
                            });
                        });
                        subItem.AddItem("Sub Title 2", item3 => {
                            item3.ApexChart(chart => {
                                chart.Title.Text("Pie Chart").Color(RGBColor.FruitSalad);
                                chart.AddPie("Pie 1", 30).AddPie("Pie 2", 40).AddPie("Pie 3", 50);
                            });
                        });
                    });

                });
                scroll.AddItem("Another section", item => {
                    item.ApexChart(chart => {
                        chart.Title.Text("Donut Chart").Color(RGBColor.FruitSalad);
                        chart.AddDonut("Donut 1", 30).AddDonut("Donut 2", 40).AddDonut("Donut 3", 50);
                    });
                });
                scroll.AddItem("More sections", item => {
                    item.DiagramNetwork(diagam => {
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

        });
        document.Save("BasicScrollingText.html", openInBrowser);
    }
}
