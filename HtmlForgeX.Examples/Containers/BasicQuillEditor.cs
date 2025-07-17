namespace HtmlForgeX.Examples.Containers;

internal class BasicQuillEditor {
    public static void Demo(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("Quill Editor Demo");

        using var document = new Document {
            Head = { Title = "Quill Editor Showcase", Author = "HtmlForgeX" },
            LibraryMode = LibraryMode.Online,
            ThemeMode = ThemeMode.Light
        };

        document.Body.Page(page => {
            page.Row(row => {
                // Basic Editor
                row.Column(TablerColumnNumber.Six, column => {
                    column.Card(card => {
                        card.Header(header => header.Title("Basic Editor"));
                        card.Body(body => {
                            body.QuillEditor(editor => {
                                editor.Height = "200px";
                                editor.Options.Placeholder = "Compose an epic...";
                                editor.Options.Theme = QuillTheme.Snow;
                                editor.Options.Modules.Toolbar = new List<QuillFormat> { 
                                    QuillFormat.Bold, 
                                    QuillFormat.Italic, 
                                    QuillFormat.Underline,
                                    QuillFormat.Strike,
                                    QuillFormat.Link
                                };
                            });
                        });
                    });
                });

                // Bubble Theme Editor
                row.Column(TablerColumnNumber.Six, column => {
                    column.Card(card => {
                        card.Header(header => header.Title("Bubble Theme Editor"));
                        card.Body(body => {
                            body.QuillEditor(editor => {
                                editor.Height = "200px";
                                editor.Options.Placeholder = "Select text to see options...";
                                editor.Options.Theme = QuillTheme.Bubble;
                                editor.Options.Modules.Toolbar = new List<QuillFormat> { 
                                    QuillFormat.Bold, 
                                    QuillFormat.Italic, 
                                    QuillFormat.Link,
                                    QuillFormat.Blockquote
                                };
                            });
                        });
                    });
                });
            });

            page.Row(row => {
                // Grouped Toolbar
                row.Column(TablerColumnNumber.Six, column => {
                    column.Card(card => {
                        card.Header(header => header.Title("Grouped Toolbar"));
                        card.Body(body => {
                            body.QuillEditor(editor => {
                                editor.Height = "250px";
                                editor.Options.Placeholder = "Toolbar with grouped buttons...";
                                editor.Options.Modules.Toolbar = new List<List<QuillFormat>> {
                                    new() { QuillFormat.Bold, QuillFormat.Italic, QuillFormat.Underline, QuillFormat.Strike },
                                    new() { QuillFormat.List, QuillFormat.Indent },
                                    new() { QuillFormat.Link, QuillFormat.Image },
                                    new() { QuillFormat.Code, QuillFormat.CodeBlock }
                                };
                            });
                        });
                    });
                });

                // Advanced Toolbar
                row.Column(TablerColumnNumber.Six, column => {
                    column.Card(card => {
                        card.Header(header => header.Title("Advanced Toolbar"));
                        card.Body(body => {
                            body.QuillEditor(editor => {
                                editor.Height = "250px";
                                editor.Options.Placeholder = "Full featured editor...";
                                var config = new QuillToolbarConfig();
                                config.Group(QuillFormat.Bold, QuillFormat.Italic, QuillFormat.Underline, QuillFormat.Strike)
                                      .Group(QuillFormat.Blockquote, QuillFormat.CodeBlock)
                                      .Dropdown("header", null, "1", "2", "3")
                                      .Button(QuillFormat.List)
                                      .Button(QuillFormat.Indent)
                                      .Dropdown("align", null, "center", "right", "justify")
                                      .Group(QuillFormat.Link, QuillFormat.Image, QuillFormat.Video);
                                editor.Options.Modules.Toolbar = config;
                            });
                        });
                    });
                });
            });
        });

        document.Save("QuillEditorShowcase.html", openInBrowser);
    }
}