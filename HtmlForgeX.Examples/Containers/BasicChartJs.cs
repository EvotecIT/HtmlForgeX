namespace HtmlForgeX.Examples.Containers;

internal class BasicChartJs {
    public static void Demo(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("ChartJs Demo");

        using var document = new Document {
            Head = { Title = "ChartJs Demo", Author = "HtmlForgeX" },
            LibraryMode = LibraryMode.Online,
            ThemeMode = ThemeMode.Light
        };

        document.Body.Page(page => {
            page.Row(row => {
                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.ChartJs(chart => {
                            chart.Line()
                                 .AddData("Jan", 3)
                                 .AddData("Feb", 7)
                                 .AddData("Mar", 4);
                        });
                    });
                });
                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.ChartJs(chart => {
                            chart.Pie()
                                 .AddData("Chrome", 60)
                                 .AddData("Edge", 20)
                                 .AddData("Firefox", 20);
                        });
                    });
                });
            });

            page.Row(row => {
                row.Column(TablerColumnNumber.Four, col => {
                    col.Card(card => {
                        card.ChartJs(c => {
                            c.Radar()
                             .AddData("A", 5)
                             .AddData("B", 3)
                             .AddData("C", 8);
                        });
                    });
                });
                row.Column(TablerColumnNumber.Four, col => {
                    col.Card(card => {
                        card.ChartJs(c => {
                            c.Scatter()
                             .AddPoint(0, 1)
                             .AddPoint(1, 4)
                             .AddPoint(2, 2);
                        });
                    });
                });
                row.Column(TablerColumnNumber.Four, col => {
                    col.Card(card => {
                        card.ChartJs(c => {
                            c.Bubble()
                             .AddBubble(1, 3, 5)
                             .AddBubble(2, 6, 8)
                             .AddBubble(3, 2, 4);
                        });
                    });
                });
            });
        });

        document.Save("ChartJsDemo.html", openInBrowser);
    }
}