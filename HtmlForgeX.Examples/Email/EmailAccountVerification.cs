using System;

namespace HtmlForgeX.Examples.Emails;

/// <summary>
/// Example of creating an account verification email using flexible HtmlForgeX components.
/// Demonstrates clean verification messaging with clear action buttons and security information.
/// </summary>
public static class EmailAccountVerification {
    public static void Create(bool openInBrowser = false) {
        HelpersSpectre.Success("Creating account verification email example...");

        var email = new Email();

        // Email settings
        email.Head.AddTitle("Verify Your Account")
                  .AddEmailCoreStyles();

        // Build email using natural builder pattern with EmailContent for consistent alignment
        email.Body.EmailBox(emailBox => {
            emailBox.EmailContent(content => {
                // Header section
                content.EmailText("✉️ Verify Your Email Address")
                    .WithFontSize("32px")
                    .WithFontWeight("bold")
                    .WithAlignment(Alignment.Center)
                    .WithColor("#111827");

                content.EmailText("Thanks for signing up! We're excited to have you on board.")
                    .WithFontSize("18px")
                    .WithColor("#374151")
                    .WithAlignment(Alignment.Center)
                    .WithLineHeight("1.6");

                content.EmailText("To complete your registration, please verify your email address by clicking the button below:")
                    .WithFontSize("16px")
                    .WithColor("#6B7280")
                    .WithLineHeight("1.6")
                    .WithMargin("16px 0");

                // Verification button using direct Add since no EmailButton extension method yet
                var verifyButton = new EmailButton("Verify My Email", "https://htmlforgex.com/verify?token=xyz789");
                content.Add(verifyButton);

                // Account details section
                content.EmailText("📋 Account Details")
                    .WithFontSize("18px")
                    .WithFontWeight("600")
                    .WithColor("#111827")
                    .WithMargin("32px 0 16px 0");

                content.EmailText("Email: user@example.com")
                    .WithFontSize("16px")
                    .WithColor("#066FD1")
                    .WithFontWeight("bold");

                content.EmailText("Registration: January 6, 2025")
                    .WithFontSize("16px")
                    .WithColor("#374151");

                // Security notice section
                content.EmailText("🔐 Security Notice")
                    .WithFontSize("16px")
                    .WithFontWeight("600")
                    .WithColor("#059669")
                    .WithMargin("32px 0 16px 0");

                content.EmailList(list => {
                    list.AddItem("This verification link expires in 72 hours")
                        .WithColor("#D97706")
                        .WithFontWeight("bold");
                    list.AddItem("If you didn't create this account, please ignore this email")
                        .WithColor("#059669")
                        .WithFontWeight("bold");
                });

                // Alternative verification
                content.EmailText("Can't click the button? Copy this link into your browser:")
                    .WithFontSize("14px")
                    .WithColor("#6B7280")
                    .WithMargin("32px 0 8px 0");

                content.EmailText("https://htmlforgex.com/verify?token=xyz789")
                    .WithFontSize("12px")
                    .WithColor("#066FD1")
                    .WithFontFamily("monospace");

                // Help section
                content.EmailText("Questions about verification? Contact support or visit our Help Center")
                    .WithFontSize("14px")
                    .WithColor("#6B7280")
                    .WithMargin("32px 0 16px 0");

                // Footer
                content.EmailText("© 2025 HtmlForgeX - Simple email verification system")
                    .WithFontSize("12px")
                    .WithColor("#9CA3AF")
                    .WithAlignment(Alignment.Center)
                    .WithMargin("48px 0 0 0");
            });
        });

        // Save email
        email.Save("account-verification-email.html", openInBrowser);
        HelpersSpectre.Success("✅ Account verification email created successfully!");
        HelpersSpectre.Success("📧 Demonstrates: Clean verification messaging, security notices, alternative methods, account details");
    }
}