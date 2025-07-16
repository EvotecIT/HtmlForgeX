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
        });

        document.Save("ChartJsDemo.html", openInBrowser);
    }
}
