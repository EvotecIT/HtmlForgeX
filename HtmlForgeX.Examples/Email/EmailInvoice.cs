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
/// Uses the natural Document-style configuration approach.
/// </summary>
public static class EmailInvoice
{
    public static void Create(bool openInBrowser = false)
    {
        HelpersSpectre.Success("Creating invoice email example with Document-style configuration...");

        // Natural Document-style configuration - just like document.Head.AddTitle()!
        var email = new Email()
            .EnableImageEmbedding(timeout: 30, optimize: true)  // Auto-embed images with optimization
            .ConfigureImageOptimization(maxWidth: 600, maxHeight: 400, quality: 90)
            .SetMaxEmbedFileSize(1 * 1024 * 1024) // 1MB limit for invoices
            .SetSmartImageDetection(true)
            .SetDarkModeSupport(true)
            .ConfigureLayout(containerPadding: "16px", contentPadding: "12px", maxWidth: "600px");

        // Email configuration
        email.Head.AddTitle("Invoice #INV-2025-001")
                  .AddEmailCoreStyles();

        // Build email using natural builder pattern
        email.Body.EmailBox(emailBox => {
            // Header section using EmailContent for consistent alignment
            emailBox.EmailContent(content => {
                // Logo automatically embeds based on email configuration - no duplication!
                content.EmailImage("../../../../Assets/Images/WhiteBackground/Logo-evotec.png")
                    .WithWidth("150px")
                    .WithAlignment(Alignment.Center)
                    .WithLink("https://evotec.xyz")
                    .WithAlternativeText("Evotec Logo")
                    .WithMargin(EmailSpacing.None, EmailSpacing.None, EmailSpacing.Large, EmailSpacing.None);

                // Invoice title
                content.EmailText("📄 Invoice #INV-2025-001")
                    .WithFontSize(EmailFontSize.Heading1)
                    .WithFontWeight(FontWeight.Bold)
                    .WithAlignment(Alignment.Center)
                    .WithColor("#111827");

                // Invoice details section
                content.EmailText("Invoice Details")
                    .WithFontSize(EmailFontSize.Heading3)
                    .WithFontWeight(FontWeight.SemiBold)
                    .WithColor("#111827")
                    .WithMargin(EmailSpacing.ExtraLarge, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);
            });

            // Customer and invoice info in columns - with consistent padding
            emailBox.EmailRow(row => {
                row.DisableAutoSpacing(); // Disable automatic column spacing to align with other content
                // Left column - Customer info
                row.EmailColumn(col => {
                    col.SetWidth("50%").WithPadding("0"); // Use EmailLayout system for consistent padding
                    col.EmailText("Bill To:")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(FontWeight.SemiBold)
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
                    col.SetWidth("50%").WithPadding("0").SetAlignment(Alignment.Right); // Use EmailLayout system, align right
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
                    .WithFontWeight(FontWeight.SemiBold)
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
                    .WithFontWeight(FontWeight.Bold)
                    .WithAlignment(Alignment.Right)
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
                content.EmailText("Questions about this invoice?")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithColor("#6B7280")
                    .WithAlignment(Alignment.Center)
                    .WithMargin(EmailSpacing.ExtraLarge, EmailSpacing.None, EmailSpacing.Small, EmailSpacing.None);

                // Use EmailLink instead of Span for better consistency
                content.EmailLink("Contact us at contact@evotec.xyz", "mailto:contact@evotec.xyz")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithColor("#066FD1")
                    .WithAlignment(Alignment.Center);
            });
        });

        // Save email
        email.Save("invoice-email.html", openInBrowser);

        HelpersSpectre.Success("✅ Invoice email created successfully!");
        HelpersSpectre.Success($@"📧 Demonstrates: Professional invoice layout, type-safe tables, proper alignment
🔧 Improved Features: Document-style configuration, automatic base64 embedding, EmailLink usage
📁 Logo automatically embedded as base64 data URI via email configuration!
💡 Natural configuration: email.EnableImageEmbedding().ConfigureLayout() - just like Document!");
    }
}