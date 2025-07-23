namespace HtmlForgeX.Examples.Tabler;

internal static class ExampleTablerLogs {
    public static void Create(bool openInBrowser = false) {
        using var document = new Document { Head = { Title = "Logs Demo" } };
        document.Body.Page(page => {
            page.Row(row => {
                row.Column(column => {
                    column.Card(card => {
                        card.Logs(new[] { "Line 1", "Line 2" }, TablerLogsTheme.Light)
                            .Title(HeaderLevelTag.H4, "Light Theme");
                    });
                });
                row.Column(column => {
                    column.Card(card => {
                        card.Logs(new[] { "Line 3", "Line 4" }, TablerLogsTheme.Lime)
                            .Title(HeaderLevelTag.H4, "Lime Theme");
                    });
                });
                row.Column(column => {
                    column.Card(card => {
                        card.Logs(new[] { "Custom A", "Custom B" }, new RGBColor("#6f42c1"), new RGBColor("#ffd43b"))
                            .Title(HeaderLevelTag.H4, "Custom Colors");
                    });
                });
            });
        });

        document.Save("TablerLogsDemo.html", openInBrowser);
    }
}
