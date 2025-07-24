using System;

namespace HtmlForgeX.Examples.Emails;

/// <summary>
/// Demonstrates using decimal margin values in email components.
/// </summary>
public static class EmailDecimalMargin {
    public static void Create(bool openInBrowser = false) {
        HelpersSpectre.Success("Creating decimal margin email example...");

        var email = new Email();

        email.Head.AddTitle("Decimal Margin Demo")
                  .AddEmailCoreStyles();

        email.Body.EmailBox(box => {
            box.WithOuterMargin("0 auto 1.5em auto").WithMaxWidth("600px");
            box.EmailContent(content => {
                content.EmailText("This paragraph uses decimal margin values.")
                    .WithMargin("1.5em 0");
            });
        });

        email.Save("EmailDecimalMargin.html", openInBrowser);
        HelpersSpectre.Success("✅ Decimal margin email created successfully!");
        HelpersSpectre.Success("📧 Demonstrates: Using decimal margins (1.5em).\n");
    }
}