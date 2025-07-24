using System;

namespace HtmlForgeX.Examples.Emails;

/// <summary>
/// Example of creating a password reset email using flexible HtmlForgeX components.
/// Shows how to build security-focused emails with clear actions and warnings.
/// </summary>
public static class EmailPasswordReset {
    public static void Create(bool openInBrowser = false) {
        HelpersSpectre.Success("Creating password reset email example...");

        var email = new Email();

        // Email settings
        email.Head.AddTitle("Reset Your Password")
                  .AddEmailCoreStyles();

        // Header with logo using new direct pattern
        email.Header.WithPadding("20px");
        email.Header.EmailRow(row => {
            row.EmailColumn(col => {
                col.SetAlignment(Alignment.Center);
                col.EmailImage("../../../../Assets/Images/WhiteBackground/Logo-evotec.png")
                    .WithWidth("150px")
                    .WithHeight("42px")
                    .WithAlternativeText("HtmlForgeX Logo")
                    .WithLink("https://htmlforgex.com", true);
            });
        });

        // Main content
        var content = new EmailBox();

        // Security-focused heading
        var heading = new Span()
            .AppendContent("🔒 ")
            .WithFontSize("28px")
            .AppendContent("Password Reset Request")
            .WithFontSize("28px")
            .WithFontWeight(FontWeight.Bold)
            .WithAlignment(Alignment.Center)
            .WithColor(new RGBColor("#111827"));

        content.Add(new BasicElement().Add(heading));

        // Main message with user-friendly language
        var mainMessage = new Span()
            .AppendContent("We received a request to reset your password. Click the button below to create a new password:")
            .WithFontSize("16px")
            .WithColor(new RGBColor("#374151"))
            .WithLineHeight("1.6");

        content.Add(new BasicElement().Add(mainMessage));

        // Reset button
        var resetButton = new EmailButton("Reset My Password", "https://htmlforgex.com/reset-password?token=abc123");
        content.Add(new BasicElement().Add(resetButton));

        // Security information box using Span styling
        var securityBox = new EmailBox();

        // Warning heading
        var warningHeading = new Span()
            .AppendContent("⚠️ Important Security Information")
            .WithFontSize("18px")
            .WithFontWeight(FontWeight.ExtraBold)
            .WithColor(new RGBColor("#D97706"));

        securityBox.Add(new BasicElement().Add(warningHeading));

        // Security details using flexible text building
        var expiryInfo = new Span()
            .AppendContent("• This link will expire in ")
            .WithColor(new RGBColor("#6B7280"))
            .AppendContent("24 hours")
            .WithFontWeight(FontWeight.Bold)
            .WithColor(new RGBColor("#DC2626"));

        var oneTimeInfo = new Span()
            .AppendContent("• This link can only be used ")
            .WithColor(new RGBColor("#6B7280"))
            .AppendContent("once")
            .WithFontWeight(FontWeight.Bold)
            .WithColor(new RGBColor("#DC2626"));

        var notYouInfo = new Span()
            .AppendContent("• If you didn't request this, you can safely ")
            .WithColor(new RGBColor("#6B7280"))
            .AppendContent("ignore this email")
            .WithFontWeight(FontWeight.Bold)
            .WithColor(new RGBColor("#059669"));

        securityBox.Add(new BasicElement().Add(expiryInfo));
        securityBox.Add(new BasicElement().Add(oneTimeInfo));
        securityBox.Add(new BasicElement().Add(notYouInfo));

        content.Add(securityBox);

        // Help section with flexible link building
        var helpSection = new Span()
            .AppendContent("Need help? Contact our support team at ")
            .WithFontSize("14px")
            .WithColor(new RGBColor("#6B7280"))
            .AppendContent("security@htmlforgex.com")
            .WithColor(new RGBColor("#066FD1"))
            .WithTextDecoration(TextDecoration.None)
            .AppendContent(" or visit our ")
            .WithColor(new RGBColor("#6B7280"))
            .AppendContent("Help Center")
            .WithColor(new RGBColor("#066FD1"))
            .WithTextDecoration(TextDecoration.Underline);

        content.Add(new BasicElement().Add(helpSection));

        // Alternative action using rows for layout
        var alternativeRow = new EmailRow();

        var alternativeColumn = new EmailColumn()
            .SetWidth("100%")
            .WithPadding("16px");

        var alternativeText = new Span()
            .AppendContent("Can't click the button? Copy and paste this link into your browser:")
            .WithFontSize("14px")
            .WithColor(new RGBColor("#6B7280"));

        var linkText = new Span()
            .AppendContent("https://htmlforgex.com/reset-password?token=abc123")
            .WithFontSize("12px")
            .WithColor(new RGBColor("#066FD1"))
            .WithFontFamily("monospace");

        alternativeColumn.Add(new BasicElement().Add(alternativeText));
        alternativeColumn.Add(new BasicElement().Add(linkText));
        alternativeRow.Add(alternativeColumn);

        content.Add(new BasicElement().Add(alternativeRow));

        // Footer with security notice
        var footer = new EmailBox();

        var securityNotice = new Span()
            .AppendContent("🛡️ For your security, this email was sent from a secure server.")
            .WithFontSize("14px")
            .WithColor(new RGBColor("#059669"))
            .WithAlignment(Alignment.Center);

        footer.Add(new BasicElement().Add(securityNotice));

        var copyright = new Span()
            .AppendContent("© 2025 HtmlForgeX - Secure Email System")
            .WithFontSize("12px")
            .WithColor(new RGBColor("#9CA3AF"))
            .WithAlignment(Alignment.Center);

        footer.Add(new BasicElement().Add(copyright));

        // Assemble email
        email.Body.Add(content)
                  .Add(footer);

        // Save email
        email.Save("EmailPasswordReset.html", openInBrowser);
        HelpersSpectre.Success("✅ Password reset email created successfully!");
        HelpersSpectre.Success("📧 Demonstrates: Security messaging, flexible warning boxes, alternative actions, monospace fonts");
    }
}