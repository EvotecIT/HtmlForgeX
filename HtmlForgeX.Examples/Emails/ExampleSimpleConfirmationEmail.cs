using System;

namespace HtmlForgeX.Examples.Emails;

/// <summary>
/// Example of a simple email confirmation using natural HtmlForgeX patterns.
/// Demonstrates clean confirmation messaging with clear action buttons.
/// </summary>
public static class ExampleSimpleConfirmationEmail
{
    public static void Create(bool openInBrowser = false)
    {
        Console.WriteLine("Creating simple confirmation email example...");

        var email = new Email();

        // Email configuration
        email.Head.AddTitle("Email Confirmation")
                  .AddEmailCoreStyles();

        // Build email using natural builder pattern with EmailContent for consistent alignment
        email.Body.EmailBox(emailBox => {
            emailBox.EmailContent(content => {
                // Header with logo (using correct asset path)
                content.EmailImage("../../../../Assets/Images/WhiteBackground/Logo-evotec.png")
                    .WithWidth("120px")
                    .WithAlignment("center")
                    .WithLink("https://evotec.xyz")
                    .WithMargin(EmailSpacing.None, EmailSpacing.None, EmailSpacing.Large, EmailSpacing.None);

                // Confirmation heading
                content.EmailText("✅ Email Confirmed!")
                    .WithFontSize(EmailFontSize.Heading1)
                    .WithFontWeight(EmailFontWeight.Bold)
                    .WithAlignment("center")
                    .WithColor("#059669");

                // Confirmation message
                content.EmailText("Thank you for confirming your email address. Your account is now active and ready to use.")
                    .WithFontSize(EmailFontSize.Large)
                    .WithColor("#374151")
                    .WithAlignment("center")
                    .WithLineHeight("1.6")
                    .WithMargin(EmailSpacing.Medium, EmailSpacing.None);

                // Action button with proper spacing
                var getStartedButton = new EmailButton("Get Started", "https://evotec.xyz/contact/");
                content.Add(getStartedButton);

                // Help text
                content.EmailText("Questions? Contact our support team or visit our help center.")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithColor("#6B7280")
                    .WithAlignment("center")
                    .WithMargin(EmailSpacing.ExtraLarge, EmailSpacing.None, EmailSpacing.None, EmailSpacing.None);

                // Footer
                content.EmailText("© 2025 Evotec - Simple email confirmation system")
                    .WithFontSize(EmailFontSize.Small)
                    .WithColor("#9CA3AF")
                    .WithAlignment("center")
                    .WithMargin(EmailSpacing.Large, EmailSpacing.None, EmailSpacing.None, EmailSpacing.None);
            });
        });

        // Save email
        email.Save("simple-confirmation-email.html", openInBrowser);
        Console.WriteLine("✅ Simple confirmation email created successfully!");
        Console.WriteLine("📧 Demonstrates: Clean confirmation messaging, proper asset paths, natural flow");
    }
}