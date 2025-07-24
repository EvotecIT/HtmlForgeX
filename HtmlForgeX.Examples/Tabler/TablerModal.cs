namespace HtmlForgeX.Examples.Tabler;

internal static class TablerModal {
    public static void Create(bool openInBrowser = false) {
        using var document = new Document { Head = { Title = "Modal Demo" } };
        document.Body.Page(page => {
            page.Row(row => {
                row.Column(column => {
                    column.Modal(modal => {
                        modal.Title("Confirm Action")
                             .Size(TablerModalSize.Large)
                             .Scrollable()
                             .Content(content => {
                                 content.Text("Are you sure?");
                             })
                             .Footer(footer => {
                                 footer.Button("Cancel", TablerColor.Light).Dismiss()
                                       .Button("Confirm", TablerColor.Primary).Submit();
                             });
                    });
                });
            });
        });

        document.Save("TablerModal.html", openInBrowser);
    }
}