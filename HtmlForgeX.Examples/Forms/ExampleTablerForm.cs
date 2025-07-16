namespace HtmlForgeX.Examples.Forms;

internal static class ExampleTablerForm {
    public static void Create(bool openInBrowser = false) {
        using var document = new Document { Head = { Title = "Form Demo" } };
        document.Body.Page(page => {
            page.Row(row => {
                row.Column(column => {
                    column.Card(card => {
                        card.Form(form => {
                            form.Input("email", input => {
                                input.Type(InputType.Email)
                                     .Label("Email Address")
                                     .Placeholder("name@example.com")
                                     .Required()
                                     .Icon(TablerIconType.Mail)
                                     .Validation(ValidationState.Invalid, "Please enter a valid email");
                            });
                            form.Select("country", select => {
                                select.Label("Country")
                                      .Options(new[] { "USA", "Canada", "UK" })
                                      .Searchable();
                            });
                            form.InputMask("phone", mask => {
                                mask.Label("Phone")
                                    .Pattern("+1 (999) 999-9999");
                            });
                            form.Wysiwyg("notes", editor => {
                                editor.Label("Notes")
                                      .Placeholder("Write something...")
                                      .Toolbar(new() { QuillFormat.Bold, QuillFormat.Italic, QuillFormat.Link });
                            });

                            form.Wysiwyg("comments", editor => {
                                editor.Label("Additional Comments")
                                      .Placeholder("Share your thoughts")
                                      .Theme(QuillTheme.Bubble)
                                      .Height("150px")
                                      .Toolbar(new() { QuillFormat.Bold, QuillFormat.Underline, QuillFormat.List });
                            });
                        });
                    });
                });
            });
        });
        document.Save("FormDemo.html", openInBrowser);
    }
}
