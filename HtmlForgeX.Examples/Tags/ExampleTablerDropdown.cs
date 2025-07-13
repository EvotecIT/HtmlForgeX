namespace HtmlForgeX.Examples.Tags;

internal static class ExampleTablerDropdown {
    public static void Create(bool openInBrowser = false) {
        var document = new Document { Head = { Title = "Dropdown Demo" } };
        document.Body.Page(page => {
            page.Row(row => {
                row.Column(column =>
                    column.Card(card =>
                        card.Dropdown("Basic", d => {
                            d.Item("First");
                            d.Item("Second");
                        })));

                row.Column(column =>
                    column.Card(card =>
                        card.Dropdown("Arrow", d => {
                            d.Item("One");
                        }).WithArrow()));

                row.Column(column =>
                    column.Card(card =>
                        card.Dropdown("Dark", d => {
                            d.Item("Alpha");
                            d.Item("Beta");
                        }).Dark()));

                row.Column(column =>
                    column.Card(card =>
                        card.Dropdown("Icons", d => {
                            d.Item("Edit").Icon(TablerIconType.Edit);
                            d.Item("Delete").Icon(TablerIconType.Trash);
                        })));

                row.Column(column =>
                    column.Card(card =>
                        card.Dropdown("Separator", d => {
                            d.Item("Top");
                            d.Separator();
                            d.Item("Bottom");
                        })));
            });

            page.Row(row => {
                row.Column(column =>
                    column.Card(card =>
                        card.Dropdown("Checkbox", d => {
                            d.CheckboxItem("Enable feature", true);
                            d.CheckboxItem("Another option", false);
                        })));

                row.Column(column =>
                    column.Card(card =>
                        card.Dropdown("Radio", d => {
                            d.RadioItem("Choice A", "grp", true);
                            d.RadioItem("Choice B", "grp");
                        })));

                row.Column(column =>
                    column.Card(card =>
                        card.Dropdown("Combined", d => {
                            d.Item("Edit").Icon(TablerIconType.Edit);
                            d.Separator();
                            d.CheckboxItem("Enabled", true);
                            d.RadioItem("A", "g", true);
                        }).WithArrow().Dark()));

                row.Column(column =>
                    column.Card(card =>
                        card.Dropdown("Builder", d => {
                            d.Item("Item 1");
                            d.Item("Item 2");
                            d.Item("Item 3");
                        })));

                row.Column(column =>
                    column.Card(card =>
                        card.Dropdown("Everything", d => {
                            d.Item("Save").Icon(TablerIconType.Download);
                            d.Separator();
                            d.CheckboxItem("Remember", true);
                            d.RadioItem("X", "grp2", true);
                            d.RadioItem("Y", "grp2");
                        }).WithArrow().Dark()));
            });
        });

        document.Save("DropdownDemo.html", openInBrowser);
    }
}
