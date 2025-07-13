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
                    editor.Height = "200px";
                    editor.Options.Placeholder = "Compose an epic...";
                    // THOSE OPTIONS don't really work correctly, at least theme, formats, it needs improvements
                    //editor.Options.Theme = QuillTheme.Bubble;
                    // editor.Options.Modules = new QuillModules {
                    //     Toolbar = new() { QuillFormat.Bold, QuillFormat.Italic, QuillFormat.Underline, QuillFormat.Image, QuillFormat.Code, QuillFormat.CodeBlock }
                    // };
                    editor.Options.Formats = new() { QuillFormat.Bold, QuillFormat.Italic, QuillFormat.Underline, QuillFormat.Image };
                });
            });
        });

        document.Save("QuillDemo.html", openInBrowser);
    }
}
