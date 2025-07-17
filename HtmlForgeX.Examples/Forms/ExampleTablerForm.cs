namespace HtmlForgeX.Examples.Forms;

internal static class ExampleTablerForm {
    public static void Create(bool openInBrowser = false) {
        using var document = new Document { Head = { Title = "Basic Form Demo" } };
        document.Body.Page(page => {
            page.Row(row => {
                // Left column - Contact Information
                row.Column(TablerColumnNumber.Six, column => {
                    column.Card(card => {
                        card.Header(header => header.Title("Contact Information"));
                        card.Form(form => {
                            form.Input("email", input => {
                                input.Type(InputType.Email)
                                     .Label("Email Address")
                                     .Placeholder("name@example.com")
                                     .Required()
                                     .Icon(TablerIconType.Mail);
                            });
                            
                            form.Select("country", select => {
                                select.Label("Country")
                                      .Options(new[] { "USA", "Canada", "UK", "Germany", "France" })
                                      .Searchable();
                            });
                            
                            form.InputMask("phone", mask => {
                                mask.Label("Phone")
                                    .Pattern("+1 (999) 999-9999");
                            });
                            
                            form.CheckboxGroup("contact-prefs", group => {
                                group.Label("Contact Preferences")
                                     .Option("email", "Email", true)
                                     .Option("phone", "Phone")
                                     .Option("sms", "SMS");
                            });
                        });
                    });
                });
                
                // Right column - Additional Information
                row.Column(TablerColumnNumber.Six, column => {
                    column.Card(card => {
                        card.Header(header => header.Title("Additional Information"));
                        card.Form(form => {
                            form.RadioGroup("experience", group => {
                                group.Label("Experience Level")
                                     .Option("new", "New User", true)
                                     .Option("experienced", "Experienced")
                                     .Option("expert", "Expert");
                            });
                            
                            form.Wysiwyg("notes", editor => {
                                editor.Label("Notes")
                                      .Placeholder("Write something...")
                                      .Height("150px")
                                      .Theme(QuillTheme.Snow)
                                      .Toolbar(new() { 
                                          QuillFormat.Bold, 
                                          QuillFormat.Italic, 
                                          QuillFormat.Link 
                                      });
                            });
                            
                            form.Switch("newsletter", switch_ => {
                                switch_.Label("Subscribe to Newsletter")
                                       .Checked();
                            });
                            
                            form.Checkbox("terms", checkbox => {
                                checkbox.Label("I agree to the Terms of Service")
                                        .Required();
                            });
                        });
                    });
                });
            });
        });
        document.Save("BasicFormDemo.html", openInBrowser);
    }
}
