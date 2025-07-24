using System;

namespace HtmlForgeX.Examples.Emails;

/// <summary>
/// Example demonstrating the flexible header/footer pattern using EmailBox.
/// Shows how to build custom headers and footers using EmailImage, EmailLink, EmailText, etc.
/// This replaces the old preset methods like SetLogo, SetViewOnlineLink, etc.
/// </summary>
public static class EmailFlexibleHeaderFooter
{
    public static void Create(bool openInBrowser = false)
    {
        HelpersSpectre.Success("Creating flexible header/footer example...");

        var email = new Email()
            .SetThemeMode(EmailThemeMode.Light)
            .ConfigureLayout(containerPadding: "16px", contentPadding: "12px", maxWidth: "600px");

        email.Head.AddTitle("Flexible Header/Footer Demo")
                  .AddEmailCoreStyles();

        email.Body.EmailBox(emailBox => {
            // ✅ FLEXIBLE HEADER - Build your own using EmailBox
            var header = new EmailHeader()
                .WithPadding("24px");

                        header.EmailBox(headerBox => {
                headerBox.EmailRow(row => {
                    // Logo column
                    row.EmailColumn(col => {
                        col.SetWidth("50%").SetAlignment(Alignment.Left);
                        col.EmailImage("../../../../Assets/Images/WhiteBackground/Logo-evotec.png")
                            .WithWidth("150px")
                            .WithHeight("42px")
                            .WithAlternativeText("Company Logo")
                            .WithLink("https://evotec.xyz", true)
                            .WithAutoEmbedding();
                    });

                    // View online link column - properly positioned on the right
                    row.EmailColumn(col => {
                        col.SetWidth("50%").SetAlignment(Alignment.Right);
                        col.EmailText("") // Empty spacer to push link to the right
                            .WithAlignment(Alignment.Right);
                        col.EmailLink("View in browser", "https://evotec.xyz/newsletter")
                            .WithColor("#8491a1")
                            .WithFontSize("14px")
                            .WithAlignment(Alignment.Right)
                            .WithTextDecoration("none");
                    });
                });
            });

            emailBox.Add(header);

            // Main content
            emailBox.EmailContent(content => {
                content.EmailText("🎉 Flexible Pattern Demo")
                    .WithFontSize(EmailFontSize.Heading1)
                    .WithFontWeight(FontWeight.Bold)
                    .WithAlignment(Alignment.Center);

                content.EmailText("This email demonstrates the new flexible header/footer pattern!")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithAlignment(Alignment.Center);

                content.EmailText("✅ No more preset methods like SetLogo() or SetViewOnlineLink()")
                    .WithFontSize(EmailFontSize.Regular);

                content.EmailText("✅ Build custom layouts using EmailBox, EmailRow, EmailColumn")
                    .WithFontSize(EmailFontSize.Regular);

                content.EmailText("✅ Full control over positioning, styling, and content")
                    .WithFontSize(EmailFontSize.Regular);

                content.EmailText("✅ Use any combination of EmailImage, EmailLink, EmailText")
                    .WithFontSize(EmailFontSize.Regular);
            });

            // Demonstrate EmailBox modes
            emailBox.EmailContent(content => {
                content.EmailText("📦 EmailBox Modes")
                    .WithFontSize(EmailFontSize.Heading2)
                    .WithFontWeight(FontWeight.Bold);

                content.EmailText("EmailBox now supports two modes:")
                    .WithFontSize(EmailFontSize.Regular);

                content.EmailText("• Structural Mode (.EnableStructuralMode()) - Layout only, no visual styling")
                    .WithFontSize(EmailFontSize.Regular);

                content.EmailText("• Visual Mode (.EnableVisualMode()) - Full styling with borders, shadows, background")
                    .WithFontSize(EmailFontSize.Regular);
            });

            // Example of visual mode EmailBox
            var visualBox = new EmailBox()
                .EnableVisualMode()
                .WithPadding("20px")
                .WithBackground("#f8f9fa")
                .WithBorderColor("#e9ecef")
                .WithBorderRadius("8px");

            visualBox.EmailText("📦 This is a Visual Mode EmailBox")
                .WithFontSize(EmailFontSize.Medium)
                .WithFontWeight(FontWeight.SemiBold)
                .WithAlignment(Alignment.Center);

            visualBox.EmailText("It has borders, background color, and styling - perfect for content sections!")
                .WithFontSize(EmailFontSize.Regular)
                .WithAlignment(Alignment.Center);

            emailBox.Add(visualBox);

            // Example of structural mode EmailBox
            var structuralBox = new EmailBox()
                .EnableStructuralMode()
                .WithPadding("20px");

            structuralBox.EmailText("🏗️ This is a Structural Mode EmailBox")
                .WithFontSize(EmailFontSize.Medium)
                .WithFontWeight(FontWeight.SemiBold)
                .WithAlignment(Alignment.Center);

            structuralBox.EmailText("It provides layout structure without visual styling - perfect for headers and footers!")
                .WithFontSize(EmailFontSize.Regular)
                .WithAlignment(Alignment.Center);

            emailBox.Add(structuralBox);

            // ✅ FLEXIBLE FOOTER - Build your own using EmailBox
            var footer = new EmailFooter()
                .WithPadding("32px");

            footer.EmailBox(footerBox => {
                // Social links row
                footerBox.EmailRow(row => {
                    row.EmailColumn(col => {
                        col.SetWidth("100%").SetAlignment(Alignment.Center);

                        // Build social links however you want
                        col.EmailLink("🐦 Twitter", "https://twitter.com/evotecit")
                            .WithFontSize("14px")
                            .WithColor("#1da1f2");

                        col.EmailText(" | ")
                            .WithFontSize("14px")
                            .WithColor("#8491a1");

                        col.EmailLink("📧 GitHub", "https://github.com/EvotecIT")
                            .WithFontSize("14px")
                            .WithColor("#333");

                        col.EmailText(" | ")
                            .WithFontSize("14px")
                            .WithColor("#8491a1");

                        col.EmailLink("🌐 Website", "https://evotec.xyz")
                            .WithFontSize("14px")
                            .WithColor("#066FD1");
                    });
                });

                // Contact section
                footerBox.EmailText("Questions? Contact us at ")
                    .WithFontSize("14px")
                    .WithColor("#8491a1")
                    .WithAlignment(Alignment.Center);

                footerBox.EmailLink("support@evotec.xyz", "mailto:support@evotec.xyz")
                    .WithFontSize("14px")
                    .WithColor("#066FD1")
                    .WithAlignment(Alignment.Center);

                // Unsubscribe section
                footerBox.EmailText("Don't want these emails? ")
                    .WithFontSize("14px")
                    .WithColor("#8491a1")
                    .WithAlignment(Alignment.Center);

                footerBox.EmailLink("Unsubscribe here", "https://evotec.xyz/unsubscribe")
                    .WithFontSize("14px")
                    .WithColor("#066FD1")
                    .WithAlignment(Alignment.Center);

                // Copyright
                footerBox.EmailText($"© {DateTime.Now.Year} Evotec. All rights reserved.")
                    .WithFontSize("12px")
                    .WithColor("#8491a1")
                    .WithAlignment(Alignment.Center);
            });

            emailBox.Add(footer);
        });

        // Save email
        email.Save("EmailFlexibleHeaderFooter.html", openInBrowser);

        HelpersSpectre.Success("✅ Flexible header/footer email created successfully!");
        HelpersSpectre.Success("🎯 Key Benefits:");
        HelpersSpectre.Success("   • No preset methods - full flexibility");
        HelpersSpectre.Success("   • Use any combination of EmailImage, EmailLink, EmailText");
        HelpersSpectre.Success("   • Custom layouts with EmailRow and EmailColumn");
        HelpersSpectre.Success("   • Complete control over styling and positioning");
        HelpersSpectre.Success("💡 This is the HtmlForgeX way - build what you need!");
    }
}