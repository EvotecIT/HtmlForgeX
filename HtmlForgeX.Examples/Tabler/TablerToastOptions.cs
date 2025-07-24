namespace HtmlForgeX.Examples.Tabler;

internal static class TablerToastOptions {
    public static void Create(bool openInBrowser = false) {
        using var document = new Document { Head = { Title = "Toast Options Demo" } };
        document.Body.Page(page => {
            page.Row(row => {
                row.Column(column => {
                    column.Card(card => {
                        card.Toast(toast => {
                            toast.Title("Information")
                                .Message("Just letting you know")
                                .Type(TablerToastType.Info)
                                .Position(TablerToastPosition.TopCenter)
                                .AutoDismiss(2000);
                        });

                        card.Toast(toast => {
                            toast.Title("Warning")
                                .Message("Low disk space")
                                .Type(TablerToastType.Warning)
                                .Position(TablerToastPosition.BottomCenter)
                                .AutoDismiss(3000);
                        });

                        card.Toast(toast => {
                            toast.Title("Success")
                                .Message("Operation completed")
                                .Type(TablerToastType.Success)
                                .Position(TablerToastPosition.TopRight)
                                .AutoDismiss(2500);
                        });

                        card.Toast(toast => {
                            toast.Title("Error")
                                .Message("Something went wrong")
                                .Type(TablerToastType.Danger)
                                .Position(TablerToastPosition.BottomLeft)
                                .AutoDismiss(3500);
                        });
                    });
                });
            });
        });

        document.Save("ToastOptionsDemo.html", openInBrowser);
    }
}

