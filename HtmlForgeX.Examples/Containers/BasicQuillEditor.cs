namespace HtmlForgeX.Examples.Containers;

internal class BasicQuillEditor {
    public static void Demo(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("Quill Editor Demo");

        var document = new Document {
            Head = { Title = "Quill Demo", Author = "HtmlForgeX" },
            LibraryMode = LibraryMode.Online,
            ThemeMode = ThemeMode.Light
        };

        document.Body.Page(page => {
            page.Card(card => {
                card.QuillEditor(editor => {
                    editor.Options.Placeholder = "Compose an epic...";
                });
            });
        });

        document.Save("QuillDemo.html", openInBrowser);
    }
}
