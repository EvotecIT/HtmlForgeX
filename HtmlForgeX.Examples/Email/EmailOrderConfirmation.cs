using System;

namespace HtmlForgeX.Examples.Emails;

/// <summary>
/// Example of creating an order confirmation email with tables and complex layouts.
/// Demonstrates e-commerce email patterns using flexible HtmlForgeX components.
/// </summary>
public static class EmailOrderConfirmation {
    public static void Create(bool openInBrowser = false) {
        HelpersSpectre.Success("Creating order confirmation email example...");

        var email = new Email();

        // Email settings
        email.Head.AddTitle("Order Confirmation #12345")
                  .AddEmailCoreStyles();

        // Header box with logo and basic info
        email.Body.EmailBox(emailBox => {
            emailBox.WithOuterMargin("0 auto 16px auto").WithMaxWidth("600px");

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

            // View online link using EmailContent for consistent alignment
            emailBox.EmailContent(content => {
                content.EmailText("Having trouble viewing this email? View it online")
                    .WithFontSize("12px")
                    .WithColor("#9CA3AF")
                    .WithAlignment(Alignment.Center);
            });
        });

        // Success message box
        email.Body.EmailBox(emailBox => {
            emailBox.WithOuterMargin("0 auto 16px auto").WithMaxWidth("600px");

            // Success section using EmailContent for consistent alignment
            emailBox.EmailContent(content => {
                content.EmailText("✅ Order Confirmed!")
                    .WithFontSize("32px")
                    .WithFontWeight("bold")
                    .WithAlignment(Alignment.Center)
                    .WithColor("#059669");

                content.EmailText("Thank you for your order! We're getting everything ready for shipment.")
                    .WithFontSize("18px")
                    .WithColor("#6B7280")
                    .WithAlignment(Alignment.Center)
                    .WithLineHeight("1.6");
            });
        });

        // Order details box
        email.Body.EmailBox(emailBox => {
            emailBox.WithOuterMargin("0 auto 16px auto").WithMaxWidth("600px");

            // Order details in a two-column layout
            emailBox.EmailRow(row => {
                row.DisableAutoSpacing(); // Disable automatic column spacing to align with other content
                // Left column - Customer info
                row.EmailColumn(col => {
                    col.SetWidth("50%").WithPadding("0");
                    col.EmailText("📋 Order Details")
                        .WithFontSize("18px")
                        .WithFontWeight("bold")
                        .WithColor("#111827");
                    col.EmailText("Order #: #12345")
                        .WithFontWeight("600")
                        .WithColor("#374151");
                    col.EmailText("Date: January 6, 2025")
                        .WithFontWeight("600")
                        .WithColor("#374151");
                });

                // Right column - Shipping info
                row.EmailColumn(col => {
                    col.SetWidth("50%").WithPadding("0");
                    col.EmailText("🚚 Shipping Info")
                        .WithFontSize("18px")
                        .WithFontWeight("bold")
                        .WithColor("#111827");
                    col.EmailText("Estimated Delivery: Jan 10-12, 2025")
                        .WithFontWeight("600")
                        .WithColor("#059669");
                    col.EmailText("Tracking available once shipped")
                        .WithFontSize("14px")
                        .WithColor("#9CA3AF");
                });
            });

        });

        // Order items table box
        email.Body.EmailBox(emailBox => {
            emailBox.WithOuterMargin("0 auto 16px auto").WithMaxWidth("600px");

            // Order items title using EmailContent for consistent alignment
            emailBox.EmailContent(content => {
                content.EmailText("📦 Your Order")
                    .WithFontSize("20px")
                    .WithFontWeight("bold")
                    .WithColor("#111827");
            });

            // Order items table
            emailBox.EmailTable(table => {
                table.AddHeader(new[] { "Item", "Quantity", "Price" });
                table.AddRow(new[] { "HtmlForgeX Pro License", "1", "$99.00" });
                table.AddRow(new[] { "Premium Support Package", "1", "$29.00" });
                table.AddRow(new[] { "Tax", "", "$12.80" });
                table.AddRow(new[] { "", "Total:", "$140.80" });
                table.SetStyle(EmailTableStyle.Invoice);
            });
        });

        // Action buttons box
        email.Body.EmailBox(emailBox => {
            emailBox.WithOuterMargin("0 auto 16px auto").WithMaxWidth("600px");

            // Action buttons using row layout
            emailBox.EmailRow(row => {
                // Use default spacing for buttons (wider spacing appropriate for buttons)
                row.EmailColumn(col => {
                    col.SetWidth("50%");
                    var trackButton = new EmailButton("Track Order", "https://htmlforgex.com/orders/12345/track");
                    col.Add(trackButton);
                });

                row.EmailColumn(col => {
                    col.SetWidth("50%");
                    var supportButton = new EmailButton("Contact Support", "https://htmlforgex.com/support");
                    col.Add(supportButton);
                });
            });

            // Help section using EmailContent for consistent alignment
            emailBox.EmailContent(content => {
                content.EmailText("Questions about your order? Email us or call 1-800-HTMLFX")
                    .WithFontSize("14px")
                    .WithColor("#6B7280")
                    .WithAlignment(Alignment.Center);
            });
        });

        // Footer box
        email.Body.EmailBox(emailBox => {
            emailBox.WithOuterMargin("0 auto 0 auto").WithMaxWidth("600px"); // No bottom margin for last box

            // Footer section using EmailContent for consistent alignment
            emailBox.EmailContent(content => {
                content.EmailText("Stay Connected")
                    .WithFontSize("16px")
                    .WithFontWeight("bold")
                    .WithAlignment(Alignment.Center)
                    .WithColor("#111827");

                content.EmailText("Follow us: GitHub | Twitter | LinkedIn")
                    .WithColor("#066FD1")
                    .WithAlignment(Alignment.Center);

                content.EmailText("HtmlForgeX Inc. | 123 Developer St, Code City, CA 90210")
                    .WithFontSize("12px")
                    .WithColor("#9CA3AF")
                    .WithAlignment(Alignment.Center);

                content.EmailText("Don't want order updates? Manage preferences")
                    .WithFontSize("12px")
                    .WithColor("#9CA3AF")
                    .WithAlignment(Alignment.Center);
            });
        });

        // Save email
        email.Save("EmailOrderConfirmation.html", openInBrowser);
        HelpersSpectre.Success("✅ Order confirmation email created successfully!");
        HelpersSpectre.Success("📧 Demonstrates: E-commerce layouts, two-column design, tables, multiple action buttons, social links");
    }
}