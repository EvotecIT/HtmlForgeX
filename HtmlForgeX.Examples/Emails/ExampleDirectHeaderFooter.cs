using System;

namespace HtmlForgeX.Examples.Emails;

/// <summary>
/// Example demonstrating the direct email.Header.EmailRow() pattern.
/// Shows how to use email.Header and email.Footer directly like email.Body.
/// </summary>
public static class ExampleDirectHeaderFooter
{
    public static void Create(bool openInBrowser = false)
    {
        HelpersSpectre.Success("Creating direct header/footer pattern example...");

        var email = new Email()
            .SetThemeMode(EmailThemeMode.Light)
            .ConfigureLayout(containerPadding: "16px", contentPadding: "12px", maxWidth: "600px");

        email.Head.AddTitle("Direct Header/Footer Pattern Demo")
                  .AddEmailCoreStyles();

        // ✅ NEW PATTERN: Direct access to Header - no more header.EmailBox()!
        email.Header.EmailRow(row => {
            // Logo column
            row.EmailColumn(col => {
                col.SetWidth("60%");
                col.EmailImage("../../../../Assets/Images/WhiteBackground/Logo-evotec.png")
                    .WithWidth("150px")
                    .WithHeight("42px")
                    .WithAlternativeText("Company Logo")
                    .WithLink("https://evotec.xyz", true);
            });

            // View online link column
            row.EmailColumn(col => {
                col.SetWidth("40%").SetAlignment(Alignment.Right);
                col.EmailLink("View in browser", "https://evotec.xyz/newsletter")
                    .WithColor("#8491a1")
                    .WithFontSize("14px")
                    .WithAlignment(Alignment.Right);
            });
        });

        // Main content in Body
        email.Body.EmailBox(emailBox => {
            emailBox.EmailContent(content => {
                content.EmailText("🎯 Direct Header/Footer Pattern")
                    .WithFontSize("32px")
                    .WithFontWeight("bold")
                    .WithAlignment(Alignment.Center)
                    .WithColor("#111827");

                content.EmailText("Now you can use email.Header.EmailRow() and email.Footer.EmailRow() directly!")
                    .WithFontSize("18px")
                    .WithColor("#6B7280")
                    .WithAlignment(Alignment.Center)
                    .WithLineHeight("1.6");

                content.EmailText("✅ No more header.EmailBox() pattern")
                    .WithFontSize("16px")
                    .WithColor("#059669");

                content.EmailText("✅ Works just like email.Body.EmailBox()")
                    .WithFontSize("16px")
                    .WithColor("#059669");

                content.EmailText("✅ Direct access: email.Header.EmailRow()")
                    .WithFontSize("16px")
                    .WithColor("#059669");

                content.EmailText("✅ Proper alignment and positioning")
                    .WithFontSize("16px")
                    .WithColor("#059669");
            });
        });

        // ✅ NEW PATTERN: Direct access to Footer - clean and simple!
        email.Footer.EmailRow(row => {
            row.EmailColumn(col => {
                col.SetAlignment(Alignment.Center);
                col.EmailText("Questions? Contact us at ")
                    .WithFontSize("14px")
                    .WithColor("#6B7280");

                col.EmailLink("support@evotec.xyz", "mailto:support@evotec.xyz")
                    .WithFontSize("14px")
                    .WithColor("#066FD1");
            });
        });

        email.Footer.EmailRow(row => {
            row.EmailColumn(col => {
                col.SetAlignment(Alignment.Center);
                col.EmailText($"© {DateTime.Now.Year} Evotec. All rights reserved.")
                    .WithFontSize("12px")
                    .WithColor("#9CA3AF");
            });
        });

        // Save email
        email.Save("direct-header-footer-pattern.html", openInBrowser);
        HelpersSpectre.Success("✅ Direct header/footer pattern created successfully!");
        HelpersSpectre.Success("🎯 Key Benefits:");
        HelpersSpectre.Success("   • email.Header.EmailRow() - Direct access like Body");
        HelpersSpectre.Success("   • email.Footer.EmailRow() - No more confusing patterns");
        HelpersSpectre.Success("   • Proper alignment and positioning");
        HelpersSpectre.Success("   • Clean, intuitive API");
        HelpersSpectre.Success("💡 This is the new HtmlForgeX way - direct and simple!");
    }
}