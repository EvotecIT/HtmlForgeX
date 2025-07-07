using System;

namespace HtmlForgeX.Examples.Emails;

/// <summary>
/// Invoice data for demonstrating type-safe table population.
/// </summary>
public class InvoiceItem {
    public string Product { get; set; } = "";
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal Total => Quantity * Price;
}

/// <summary>
/// Example of an invoice email using natural HtmlForgeX patterns.
/// Demonstrates professional invoice layout with tables and proper alignment.
/// </summary>
public static class ExampleInvoiceEmail
{
    public static void Create(bool openInBrowser = false)
    {
        Console.WriteLine("Creating invoice email example...");

        var email = new Email();

        // Email configuration
        email.Head.AddTitle("Invoice #INV-2025-001")
                  .AddEmailCoreStyles();

        // Build email using natural builder pattern
        email.Body.EmailBox(emailBox => {
            // Header section using EmailContent for consistent alignment
            emailBox.EmailContent(content => {
                content.EmailImage("../../../../Assets/Images/WhiteBackground/Logo-evotec.png")
                    .WithWidth("150px")
                    .WithAlignment("center")
                    .WithLink("https://evotec.xyz")
                    .WithMargin(EmailSpacing.None, EmailSpacing.None, EmailSpacing.Large, EmailSpacing.None);

                // Invoice title
                content.EmailText("📄 Invoice #INV-2025-001")
                    .WithFontSize(EmailFontSize.Heading1)
                    .WithFontWeight(EmailFontWeight.Bold)
                    .WithAlignment("center")
                    .WithColor("#111827");

                // Invoice details section
                content.EmailText("Invoice Details")
                    .WithFontSize(EmailFontSize.Heading3)
                    .WithFontWeight(EmailFontWeight.SemiBold)
                    .WithColor("#111827")
                    .WithMargin(EmailSpacing.ExtraLarge, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);
            });

            // Customer and invoice info in columns - with consistent padding
            emailBox.EmailRow(row => {
                row.DisableAutoSpacing(); // Disable automatic column spacing to align with other content
                // Left column - Customer info
                row.EmailColumn(col => {
                    col.SetWidth("50%").SetPadding("0"); // Use EmailLayout system for consistent padding
                    col.EmailText("Bill To:")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(EmailFontWeight.SemiBold)
                        .WithColor("#111827");
                    col.EmailText("Evotec Technologies")
                        .WithFontSize(EmailFontSize.Regular)
                        .WithColor("#374151");
                    col.EmailText("contact@evotec.xyz")
                        .WithFontSize(EmailFontSize.Regular)
                        .WithColor("#374151");
                    col.EmailText("Warsaw, Poland")
                        .WithFontSize(EmailFontSize.Regular)
                        .WithColor("#374151");
                });

                // Right column - Invoice details
                row.EmailColumn(col => {
                    col.SetWidth("50%").SetPadding("0").SetAlignment("right"); // Use EmailLayout system, align right
                    col.EmailText("Invoice Date: January 6, 2025")
                        .WithFontSize(EmailFontSize.Regular)
                        .WithColor("#374151");
                    col.EmailText("Due Date: February 6, 2025")
                        .WithFontSize(EmailFontSize.Regular)
                        .WithColor("#374151");
                    col.EmailText("Payment Terms: Net 30")
                        .WithFontSize(EmailFontSize.Regular)
                        .WithColor("#374151");
                });
            });

            // Invoice items section using EmailContent for consistent alignment
            emailBox.EmailContent(content => {
                content.EmailText("Items")
                    .WithFontSize(EmailFontSize.Large)
                    .WithFontWeight(EmailFontWeight.SemiBold)
                    .WithColor("#111827")
                    .WithMargin(EmailSpacing.ExtraLarge, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);
            });

            var invoiceItems = new List<InvoiceItem> {
                new InvoiceItem { Product = "HtmlForgeX Pro License", Quantity = 1, Price = 299.00m },
                new InvoiceItem { Product = "Premium Support Package", Quantity = 1, Price = 99.00m },
                new InvoiceItem { Product = "Custom Training Session", Quantity = 2, Price = 150.00m }
            };

            emailBox.EmailTable(invoiceItems)
                .SetStyle(EmailTableStyle.Invoice);

            // Total section using EmailContent for consistent alignment
            emailBox.EmailContent(content => {
                content.EmailText("Total: $697.00 USD")
                    .WithFontSize(EmailFontSize.Large)
                    .WithFontWeight(EmailFontWeight.Bold)
                    .WithAlignment("right")
                    .WithColor("#059669")
                    .WithMargin(EmailSpacing.Medium, EmailSpacing.None);
            });

            // Action buttons with proper spacing
            emailBox.EmailRow(row => {
                // Use default spacing for buttons
                row.EmailColumn(col => {
                    col.SetWidth("50%");
                    var payButton = new EmailButton("Pay Invoice", "https://evotec.xyz/contact/");
                    col.Add(payButton);
                });

                row.EmailColumn(col => {
                    col.SetWidth("50%");
                    var downloadButton = new EmailButton("Download PDF", "https://evotec.xyz/contact/");
                    col.Add(downloadButton);
                });
            });

            // Footer using EmailContent for consistent alignment
            emailBox.EmailContent(content => {
                content.EmailText("Questions about this invoice? Contact us at contact@evotec.xyz")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithColor("#6B7280")
                    .WithAlignment("center")
                    .WithMargin(EmailSpacing.ExtraLarge, EmailSpacing.None, EmailSpacing.None, EmailSpacing.None);
            });
        });

        // Save email
        email.Save("invoice-email.html", openInBrowser);
        Console.WriteLine("✅ Invoice email created successfully!");
        Console.WriteLine("📧 Demonstrates: Professional invoice layout, type-safe tables, proper alignment, button spacing");
    }
}