namespace HtmlForgeX.Examples.Tabler;

internal static class TablerDropdown {
    public static void Create(bool openInBrowser = false) {
        using var document = new Document { Head = { Title = "Dropdown Demo" } };
        document.Body.Page(page => {
            page.Row(row => {
                // Basic dropdown example
                row.Column(column => {
                    column.CardEnhanced(card => card
                        .WithHeader("Dropdown Demo")
                        .WithHeaderDropdown(dropdown => dropdown
                            .AddItem("Edit")
                            .AddItem("Delete", "#", true)
                            .AddDivider()
                            .AddItem("Share"))
                        .Body(body => {
                            body.Text("This card demonstrates a dropdown in the header.");
                        }));
                });

                // Dropdown with custom icon
                row.Column(column => {
                    column.CardEnhanced(card => card
                        .WithHeader("Actions")
                        .WithHeaderDropdown(dropdown => dropdown
                            .Icon(TablerIconType.Settings)
                            .AddItem("Edit")
                            .AddItem("Archive")
                            .AddDivider()
                            .AddItem("Delete", "#", true))
                        .Body(body => {
                            body.Text("Another dropdown example with a settings icon.");
                        }));
                });
            });
        });

        document.Save("TablerDropdown.html", openInBrowser);
    }
}