namespace HtmlForgeX.Examples.Tabler;

internal static class ExampleTablerFormInputs {
    public static void Create(bool openInBrowser = false) {
        using var document = new Document { Head = { Title = "Form Inputs Demo" } };
        document.Body.Page(page => {
            page.Card(card => {
                card.Header(header => header.Title("Form Inputs"));
                card.Form(form => {
                    form.Input("email", input => {
                        input.Type(InputType.Email)
                             .Label("Email")
                             .Placeholder("name@example.com")
                             .Required();
                    });
                    form.Input("password", input => {
                        input.Type(InputType.Password)
                             .Label("Password")
                             .Placeholder("********")
                             .Required();
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
                });
            });
        });
        document.Save("FormInputsDemo.html", openInBrowser);
    }
}