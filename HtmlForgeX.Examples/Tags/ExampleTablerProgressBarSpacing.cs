namespace HtmlForgeX.Examples.Tags;

internal static class ExampleTablerProgressBarSpacing {
    public static void Create(bool openInBrowser = false) {
        var document = new Document { Head = { Title = "Progress Bar Spacing Demo" } };
        document.Body.Page(page => {
            page.Row(row => {
                row.Column(column => {
                    column.Card(card => {
                        card.ProgressBar(TablerProgressBarType.Small)
                            .Margin(TablerMargin.BottomNormal)
                            .Padding(TablerPadding.VerticalHalf)
                            .Item(TablerColor.Primary, 40, "Upload")
                            .Item(TablerColor.Success, 60, "Process");
                    });
                });
            });
        });

        document.Save("ProgressBarSpacingDemo.html", openInBrowser);
    }
}
