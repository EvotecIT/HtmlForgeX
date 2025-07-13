namespace HtmlForgeX.Examples.Tags;

internal static class ExampleTablerDropdown {
    public static void Create(bool openInBrowser = false) {
        var document = new Document { Head = { Title = "Dropdown Demo" } };
        document.Body.Page(page => {
            page.Row(row => {
                row.Column(column => {
                    column.Card(card => {
                        card.Dropdown("Options", dropdown => {
                            dropdown.Item("Edit").Icon(TablerIconType.Edit);
                            dropdown.Separator();
                            dropdown.Item("Delete").Icon(TablerIconType.Trash).Danger();
                            dropdown.CheckboxItem("Enabled", true);
                            dropdown.RadioItem("Choice A", "group1", true);
                        }).WithArrow();
                    });
                });
            });
        });

        document.Save("DropdownDemo.html", openInBrowser);
    }
}
