using System;

namespace HtmlForgeX.Examples.Emails;

/// <summary>
/// Demonstrates URL encoding support in <see cref="EmailLink"/>.
/// </summary>
public static class EmailLinkEncoding {
    public static void Create(bool openInBrowser = false) {
        HelpersSpectre.Success("Creating link encoding email example...");

        var email = new Email();

        email.Head.AddTitle("Link Encoding Demo")
                  .AddEmailCoreStyles();

        email.Body.EmailBox(box => {
            box.EmailContent(content => {
                content.EmailText("Link with spaces and special characters:")
                    .WithAlignment(Alignment.Center);

                content.EmailLink(
                        "Search Now",
                        "https://example.com/search?q=C# tutorial&lang=en us")
                    .WithAlignment(Alignment.Center);
            });
        });

        email.Save("link-encoding-email.html", openInBrowser);
        HelpersSpectre.Success("✅ Link encoding email created successfully!");
    }
}
