using System;

namespace HtmlForgeX.Examples.Emails;

/// <summary>
/// Example demonstrating the flexible header/footer pattern using EmailBox.
/// Shows how to build custom headers and footers using EmailImage, EmailLink, EmailText, etc.
/// This replaces the old preset methods like SetLogo, SetViewOnlineLink, etc.
/// </summary>
public static class ExampleFlexibleHeaderFooter
{
    public static void Create(bool openInBrowser = false)
    {
        Console.WriteLine("Creating flexible header/footer example...");

        var email = new Email()
            .SetThemeMode(EmailThemeMode.Light)
            .ConfigureLayout(containerPadding: "16px", contentPadding: "12px", maxWidth: "600px");

        email.Head.AddTitle("Flexible Header/Footer Demo")
                  .AddEmailCoreStyles();

        email.Body.EmailBox(emailBox => {
            // ✅ FLEXIBLE HEADER - Build your own using EmailBox
            var header = new EmailHeader()
                .SetPadding("24px");

                        header.EmailBox(headerBox => {
                headerBox.EmailRow(row => {
                    // Logo column
                    row.EmailColumn(col => {
                        col.SetWidth("50%").SetAlignment("left");
                        col.EmailImage("../../../../Assets/Images/WhiteBackground/Logo-evotec.png")
                            .WithWidth("150px")
                            .WithHeight("42px")
                            .WithAlternativeText("Company Logo")
                            .WithLink("https://evotec.xyz", true)
                            .WithAutoEmbedding();
                    });

                    // View online link column - properly positioned on the right
                    row.EmailColumn(col => {
                        col.SetWidth("50%").SetAlignment("right");
                        col.EmailText("") // Empty spacer to push link to the right
                            .WithAlignment("right");
                        col.EmailLink("View in browser", "https://evotec.xyz/newsletter")
                            .WithColor("#8491a1")
                            .WithFontSize("14px")
                            .WithAlignment("right")
                            .WithTextDecoration("none");
                    });
                });
            });

            emailBox.Add(header);

            // Main content
            emailBox.EmailContent(content => {
                content.EmailText("🎉 Flexible Pattern Demo")
                    .WithFontSize(EmailFontSize.Heading1)
                    .WithFontWeight(EmailFontWeight.Bold)
                    .WithAlignment("center");

                content.EmailText("This email demonstrates the new flexible header/footer pattern!")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithAlignment("center");

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
                    .WithFontWeight(EmailFontWeight.Bold);

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
                .SetPadding("20px")
                .SetBackgroundColor("#f8f9fa")
                .SetBorderColor("#e9ecef")
                .SetBorderRadius("8px");

            visualBox.EmailText("📦 This is a Visual Mode EmailBox")
                .WithFontSize(EmailFontSize.Medium)
                .WithFontWeight(EmailFontWeight.SemiBold)
                .WithAlignment("center");

            visualBox.EmailText("It has borders, background color, and styling - perfect for content sections!")
                .WithFontSize(EmailFontSize.Regular)
                .WithAlignment("center");

            emailBox.Add(visualBox);

            // Example of structural mode EmailBox
            var structuralBox = new EmailBox()
                .EnableStructuralMode()
                .SetPadding("20px");

            structuralBox.EmailText("🏗️ This is a Structural Mode EmailBox")
                .WithFontSize(EmailFontSize.Medium)
                .WithFontWeight(EmailFontWeight.SemiBold)
                .WithAlignment("center");

            structuralBox.EmailText("It provides layout structure without visual styling - perfect for headers and footers!")
                .WithFontSize(EmailFontSize.Regular)
                .WithAlignment("center");

            emailBox.Add(structuralBox);

            // ✅ FLEXIBLE FOOTER - Build your own using EmailBox
            var footer = new EmailFooter()
                .SetPadding("32px");

            footer.EmailBox(footerBox => {
                // Social links row
                footerBox.EmailRow(row => {
                    row.EmailColumn(col => {
                        col.SetWidth("100%").SetAlignment("center");

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
                    .WithAlignment("center");

                footerBox.EmailLink("support@evotec.xyz", "mailto:support@evotec.xyz")
                    .WithFontSize("14px")
                    .WithColor("#066FD1")
                    .WithAlignment("center");

                // Unsubscribe section
                footerBox.EmailText("Don't want these emails? ")
                    .WithFontSize("14px")
                    .WithColor("#8491a1")
                    .WithAlignment("center");

                footerBox.EmailLink("Unsubscribe here", "https://evotec.xyz/unsubscribe")
                    .WithFontSize("14px")
                    .WithColor("#066FD1")
                    .WithAlignment("center");

                // Copyright
                footerBox.EmailText($"© {DateTime.Now.Year} Evotec. All rights reserved.")
                    .WithFontSize("12px")
                    .WithColor("#8491a1")
                    .WithAlignment("center");
            });

            emailBox.Add(footer);
        });

        // Save email
        email.Save("flexible-header-footer.html", openInBrowser);

        Console.WriteLine("✅ Flexible header/footer email created successfully!");
        Console.WriteLine("🎯 Key Benefits:");
        Console.WriteLine("   • No preset methods - full flexibility");
        Console.WriteLine("   • Use any combination of EmailImage, EmailLink, EmailText");
        Console.WriteLine("   • Custom layouts with EmailRow and EmailColumn");
        Console.WriteLine("   • Complete control over styling and positioning");
        Console.WriteLine("💡 This is the HtmlForgeX way - build what you need!");
    }
}