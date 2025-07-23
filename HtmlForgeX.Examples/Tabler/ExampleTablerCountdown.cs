namespace HtmlForgeX.Examples.Tabler;

internal static class ExampleTablerCountdown {
    public static void Create(bool openInBrowser = false) {
        using var document = new Document { Head = { Title = "Countdown Demo" } };
        document.Body.Page(page => {
            page.Row(row => {
                row.Column(column => {
                    column.Card(card => {
                        card.Countdown(c => c
                            .EndTime(DateTime.Now.AddMinutes(1))
                            .Format("MM:SS")
                            .OnComplete("console.log('Finished')"));
                    });
                });
            });
        });

        document.Save("TablerCountdownDemo.html", openInBrowser);
    }
}
