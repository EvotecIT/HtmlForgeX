namespace HtmlForgeX.Examples.Tags;

internal static class ExampleTablerToast {
    public static void Create() {
        var document = new Document { Head = { Title = "Toast Demo" } };
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

        document.Save("ToastDemo.html", true);
    }
}
