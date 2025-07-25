namespace HtmlForgeX.Examples.Tabler;

internal static class TablerToastDemo {
    public static void Create(bool openInBrowser = false) {
        using var document = new Document { Head = { Title = "Toast Demo" } };
        document.Body.Page(page => {
            page.Row(row => {
                row.Column(column => {
                    column.Card(card => {
                        card.Toast(toast => {
                            toast.Title("Success!")
                                 .Message("Operation completed")
                                 .Type(TablerToastType.Success)
                                 .Position(TablerToastPosition.BottomRight)
                                 .AutoDismiss(3000);
                        });
                    });
                });
            });
        });

        document.Save("TablerToastDemo.html", openInBrowser);
    }
}