using System;

namespace HtmlForgeX.Examples.Emails;

/// <summary>
/// Demonstrates using decimal margin values in email components.
/// </summary>
public static class ExampleDecimalMarginEmail {
    public static void Create(bool openInBrowser = false) {
        Console.WriteLine("Creating decimal margin email example...");

        var email = new Email();

        email.Head.AddTitle("Decimal Margin Demo")
                  .AddEmailCoreStyles();

        email.Body.EmailBox(box => {
            box.SetOuterMargin("0 auto 1.5em auto").SetMaxWidth("600px");
            box.EmailContent(content => {
                content.EmailText("This paragraph uses decimal margin values.")
                    .WithMargin("1.5em 0");
            });
        });

        email.Save("decimal-margin-email.html", openInBrowser);
        Console.WriteLine("✅ Decimal margin email created successfully!");
        Console.WriteLine("📧 Demonstrates: Using decimal margins (1.5em).\n");
    }
}