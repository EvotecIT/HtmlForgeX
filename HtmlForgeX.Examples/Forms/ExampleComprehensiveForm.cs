namespace HtmlForgeX.Examples.Forms;

internal static class ExampleComprehensiveForm {
    public static void Create(bool openInBrowser = false) {
        using var document = new Document { Head = { Title = "Comprehensive Form Demo" } };
        document.Body.Page(page => {
            page.Row(row => {
                row.Column(column => {
                    column.Card(card => {
                        card.Header(header => header.Title("Comprehensive Form Elements"));
                        card.Form(form => {
                            // Basic inputs
                            form.Input("fullname", input => {
                                input.Type(InputType.Text)
                                     .Label("Full Name")
                                     .Placeholder("Enter your full name")
                                     .Required()
                                     .Icon(TablerIconType.User);
                            });

                            form.Input("email", input => {
                                input.Type(InputType.Email)
                                     .Label("Email Address")
                                     .Placeholder("name@example.com")
                                     .Required()
                                     .Icon(TablerIconType.Mail)
                                     .Validation(ValidationState.Invalid, "Please enter a valid email");
                            });

                            form.Input("password", input => {
                                input.Type(InputType.Password)
                                     .Label("Password")
                                     .Placeholder("Enter secure password")
                                     .Required();
                            });

                            // Select with searchable option
                            form.Select("country", select => {
                                select.Label("Country")
                                      .Options(new[] { "USA", "Canada", "UK", "Germany", "France", "Japan", "Australia" })
                                      .Searchable()
                                      .Required();
                            });

                            // Textarea
                            form.Textarea("bio", textarea => {
                                textarea.Label("Bio")
                                        .Placeholder("Tell us about yourself...")
                                        .Rows(4);
                            });

                            // Checkbox group
                            form.CheckboxGroup("interests", group => {
                                group.Label("Interests")
                                     .Option("sports", "Sports", true)
                                     .Option("music", "Music")
                                     .Option("travel", "Travel", true)
                                     .Option("reading", "Reading")
                                     .Inline();
                            });

                            // Radio group
                            form.RadioGroup("experience", group => {
                                group.Label("Experience Level")
                                     .Option("beginner", "Beginner")
                                     .Option("intermediate", "Intermediate", true)
                                     .Option("advanced", "Advanced")
                                     .Option("expert", "Expert");
                            });

                            // Toggle switches
                            form.Switch("notifications", switch_ => {
                                switch_.Label("Enable Email Notifications")
                                       .Checked();
                            });

                            form.Switch("marketing", switch_ => {
                                switch_.Label("Receive Marketing Emails")
                                       .Size(SwitchSize.Small);
                            });

                            // Single checkbox for terms
                            form.Checkbox("terms", checkbox => {
                                checkbox.Label("I agree to the Terms & Conditions")
                                        .Required();
                            });

                            // WYSIWYG editors with different configurations
                            form.Wysiwyg("description", editor => {
                                editor.Label("Product Description")
                                      .Placeholder("Enter detailed product description...")
                                      .Height("200px")
                                      .Toolbar(new() { 
                                          QuillFormat.Bold, 
                                          QuillFormat.Italic, 
                                          QuillFormat.Underline,
                                          QuillFormat.Link,
                                          QuillFormat.List,
                                          QuillFormat.Header
                                      });
                            });

                            form.Wysiwyg("notes", editor => {
                                editor.Label("Additional Notes")
                                      .Placeholder("Any additional comments...")
                                      .Theme(QuillTheme.Bubble)
                                      .Height("150px")
                                      .ToolbarGroups(
                                          new() { QuillFormat.Bold, QuillFormat.Italic, QuillFormat.Underline },
                                          new() { QuillFormat.List, QuillFormat.Indent },
                                          new() { QuillFormat.Link, QuillFormat.Image }
                                      );
                            });

                            form.Wysiwyg("advanced", editor => {
                                editor.Label("Advanced Editor")
                                      .Placeholder("Full-featured editor...")
                                      .Height("300px")
                                      .ToolbarAdvanced(toolbar => {
                                          toolbar.Group(QuillFormat.Bold, QuillFormat.Italic, QuillFormat.Underline, QuillFormat.Strike)
                                                 .Group(QuillFormat.Blockquote, QuillFormat.CodeBlock)
                                                 .Dropdown("header", null, "1", "2", "3", "4", "5", "6")
                                                 .Group(QuillFormat.List, QuillFormat.Indent)
                                                 .Dropdown("align", null, "center", "right", "justify")
                                                 .Group(QuillFormat.Link, QuillFormat.Image, QuillFormat.Video);
                                      });
                            });
                        });
                    });
                });
            });
        });
        document.Save("ComprehensiveFormDemo.html", openInBrowser);
    }
}