namespace HtmlForgeX.Examples.Tags;

internal static class ExampleTablerToastAdvanced {
    public static void Create(bool openInBrowser = false) {
        var data = new[] {
            new { Name = "Alice", Age = 30 },
            new { Name = "Bob", Age = 25 }
        };

        using var document = new Document { Head = { Title = "Advanced Toast Demo" } };
        document.Body.Page(page => {
            page.Row(row => {
                row.Column(column => {
                    column.Card(card => {
                        card.Content("Demonstrates toasts with other Tabler components.");
                        card.Alert(string.Empty, "Operation finished", TablerColor.Success)
                            .Icon(TablerIconType.Check);
                        card.ProgressBar(TablerProgressBarType.Separated)
                            .Item(TablerColor.Primary, 70, "Uploading")
                            .Item(TablerColor.Success, 30, "Processing");
                        card.Table(data, TableType.Tabler);
                        card.Toast(toast => {
                            toast.Title("Upload Complete")
                                .Message("Files uploaded successfully.")
                                .Type(TablerToastType.Success)
                                .Position(TablerToastPosition.TopRight)
                                .AutoDismiss(5000);
                        });
                        card.Toast(toast => {
                            toast.Title("Warning")
                                .Message("Low disk space.")
                                .Type(TablerToastType.Warning)
                                .Position(TablerToastPosition.BottomLeft)
                                .AutoDismiss(7000);
                        });
                    });
                });
            });
        });

        document.Save("AdvancedToastDemo.html", openInBrowser);
    }
}
