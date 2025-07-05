using System;

namespace HtmlForgeX.Examples;

/// <summary>
/// Demonstrates various email examples using the HtmlForgeX email components.
/// </summary>
public static class EmailExamples
{

    /// <summary>
    /// Creates a simple confirmation email example.
    /// </summary>
    public static void CreateConfirmationEmail(bool openInBrowser = false)
    {
        var email = new Email();

        // Configure email head
        email.Head.AddTitle("Email Confirmation")
                  .AddEmailCoreStyles();

        // Add header
        var header = new EmailHeader()
            .SetLogo("./assets/sample-logo.png", "./assets/sample-logo-white.png")
            .SetLogoLink("https://example.com")
            .SetViewOnlineLink("https://example.com/emails/view/123");

        // Create main content box
        var contentBox = new EmailBox()
            .Add(content =>
            {
                content.SetHtml("<h1 class=\"text-center m-0 font-strong h1\">Email Confirmed!</h1>");
            })
            .Add(content =>
            {
                content.SetHtml("<p>Thank you for confirming your email address. Your account is now active and ready to use.</p>");
            })
            .Add(content =>
            {
                var button = new EmailButton("Get Started", "https://example.com/dashboard");
                content.Children.Add(button);
            });

        // Add footer
        var footer = new EmailFooter()
            .AddSocialLink("Twitter", "https://twitter.com/example", "./assets/icons-gray-brand-x.png")
            .AddSocialLink("GitHub", "https://github.com/example", "./assets/icons-gray-brand-github.png")
            .SetContactEmail("support@example.com")
            .SetUnsubscribeLink("https://example.com/unsubscribe")
            .SetCopyright("Example Company", 2025);

        // Build email body
        email.Body.Add(header)
                  .Add(contentBox)
                  .Add(footer);

        // Save the email
        email.Save("confirmation-email.html", openInBrowser);
        Console.WriteLine("Confirmation email created successfully!");
    }

    /// <summary>
    /// Creates an invoice email example based on the Tabler email template.
    /// </summary>
    public static void CreateInvoiceEmail(bool openInBrowser = false)
    {
        var email = new Email();

        // Configure email head
        email.Head.AddTitle("Invoice #72")
                  .AddEmailCoreStyles();

        // Add header
        var header = new EmailHeader()
            .SetLogo("./assets/sample-logo.png", "./assets/sample-logo-white.png")
            .SetLogoLink("https://tabler.io/emails")
            .SetViewOnlineLink("https://tabler.io/emails/view/invoice");

        // Create main content box
        var contentBox = new EmailBox();

        // Invoice title
        contentBox.Add(content =>
        {
            content.SetHtml("<h1 class=\"text-center m-0 font-strong h1\">Invoice</h1>");
        });

        // Bill to and Invoice details row
        contentBox.Add(content =>
        {
            var row = new EmailRow();

            // Bill to column
            var billToCol = new EmailColumn()
                .SetPadding("24px")
                .AddText("<h4>Bill to</h4>")
                .AddText("<p>Clara Palmer<br />clara.palmer@customservice.eu<br />555-555-5555</p>")
                .AddText("<p class=\"mb-0\">3333 Poplar Street<br />Chicago, IL 60603<br />United States</p>");

            row.Add(billToCol);
            row.AddSpacer();

            // Invoice details column
            var detailsCol = new EmailColumn()
                .Add(detailsContent =>
                {
                    detailsContent.SetHtml("<div class=\"rounded p-lg bg-light\" style=\"background-color: #f6f6f6; border-radius: 4px; padding: 24px;\">" +
                                         "<h4>Invoice details</h4>" +
                                         "<p class=\"mb-0\">" +
                                         "Invoice Number: 72<br />" +
                                         "P.O./S.O. Number: TB962046<br /><br />" +
                                         "Invoice Date: March 15, 2022<br />" +
                                         "Payment Due: June 15, 2022<br /><br />" +
                                         "<strong>Amount Due: $2,632.75 USD</strong>" +
                                         "</p>" +
                                         "</div>");
                });

            row.Add(detailsCol);
            content.Children.Add(row);
        });

        // Order items table
        contentBox.Add(content =>
        {
            content.SetHtml("<h4>Your order</h4>");

            var table = new EmailTable()
                .AddHeader("", "left", 2)
                .AddHeader("Qty", "center")
                .AddHeader("Price", "right");

            // Add product rows
            table.AddRow(row =>
            {
                row.AddImageCell("./assets/sample-product-5.png", 64, 64);
                row.AddCell(cell =>
                {
                    cell.SetHtml("<strong>Magical notebook</strong><br /><span class=\"text-muted\">Superheroes things</span>");
                    cell.SetWidth("100%");
                });
                row.AddCell("1", "center");
                row.AddCell("$399", "right");
            });

            table.AddRow(row =>
            {
                row.AddImageCell("./assets/sample-product-6.png", 64, 64);
                row.AddCell(cell =>
                {
                    cell.SetHtml("<strong>Dragonfly eyes</strong><br /><span class=\"text-muted\">Unnecessary things</span>");
                    cell.SetWidth("100%");
                });
                row.AddCell("1", "center");
                row.AddCell("$145", "right");
            });

            // Totals rows
            table.AddRow(row =>
            {
                row.AddCell(cell =>
                {
                    cell.SetText("Subtotal");
                    cell.SetAlign("right");
                    cell.ColSpan = 3;
                    cell.EnableTopBorder();
                });
                row.AddCell(cell =>
                {
                    cell.SetText("$544");
                    cell.SetAlign("right");
                    cell.EnableTopBorder();
                });
            });

            table.AddRow("", "", "", "Shipping", "$5");
            table.AddRow("", "", "", "Tax", "$25");

            table.AddRow(row =>
            {
                row.AddCell(cell =>
                {
                    cell.SetHtml("<strong>Total</strong>");
                    cell.SetAlign("right");
                    cell.ColSpan = 3;
                    cell.CssClass = "font-strong h3 m-0";
                });
                row.AddCell(cell =>
                {
                    cell.SetHtml("<strong>$574</strong>");
                    cell.SetAlign("right");
                    cell.CssClass = "font-strong h3 m-0";
                });
            });

            content.Children.Add(table);
        });

        // Action buttons
        contentBox.Add(content =>
        {
            var row = new EmailRow();

            row.AddColumn(col =>
            {
                var printButton = new EmailButton("Print invoice", "https://tabler.io/emails/print")
                    .SetStyle(EmailButtonStyle.Primary);
                col.Add(printButton);
            });

            row.AddSpacer();

            row.AddColumn(col =>
            {
                var contactButton = new EmailButton("Contact us", "https://tabler.io/emails/contact")
                    .SetStyle(EmailButtonStyle.Secondary);
                col.Add(contactButton);
            });

            content.Children.Add(row);
        });

        // Add footer
        var footer = new EmailFooter()
            .AddSocialLink("Twitter", "https://x.com/tabler_io", "./assets/icons-gray-brand-x.png")
            .AddSocialLink("GitHub", "https://github.com/tabler", "./assets/icons-gray-brand-github.png")
            .AddSocialLink("LinkedIn", "https://www.linkedin.com/company/tabler-io", "./assets/icons-gray-brand-linkedin.png")
            .SetContactEmail("hello@tabler.io")
            .SetUnsubscribeLink("https://tabler.io/emails/unsubscribe")
            .SetCopyright("Tabler", 2025);

        // Build email body
        email.Body.Add(header)
                  .Add(contentBox)
                  .Add(footer);

        // Save the email
        email.Save("invoice-email.html", openInBrowser);
        Console.WriteLine("Invoice email created successfully!");
    }

    /// <summary>
    /// Creates a newsletter email example.
    /// </summary>
    public static void CreateNewsletterEmail(bool openInBrowser = false)
    {
        var email = new Email();

        // Configure email head
        email.Head.AddTitle("Monthly Newsletter")
                  .AddEmailCoreStyles();

        // Set preheader
        email.Body.PreheaderText = "Check out our latest updates and featured content this month.";

        // Add header
        var header = new EmailHeader()
            .SetLogo("./assets/sample-logo.png", "./assets/sample-logo-white.png")
            .SetLogoLink("https://example.com")
            .SetViewOnlineLink("https://example.com/newsletter/march-2025");

        // Newsletter content
        var contentBox = new EmailBox();

        // Newsletter title
        contentBox.Add(content =>
        {
            content.SetHtml("<h1 class=\"text-center m-0 font-strong h1\">March 2025 Newsletter</h1>");
        });

        // Featured article
        contentBox.Add(content =>
        {
            content.SetHtml("<h2 class=\"h2\">Featured Article</h2>" +
                          "<p><strong>Introducing New Email Components</strong></p>" +
                          "<p>We're excited to announce the release of our new email component library, " +
                          "making it easier than ever to create beautiful, responsive emails that work " +
                          "across all email clients.</p>");

            var readMoreButton = new EmailButton("Read More", "https://example.com/blog/new-email-components")
                .SetStyle(EmailButtonStyle.Primary);
            content.Children.Add(readMoreButton);
        });

        // News section with table layout
        contentBox.Add(content =>
        {
            content.SetHtml("<h3 class=\"h3\">Latest Updates</h3>");

            var row = new EmailRow();

            // Update 1
            var col1 = new EmailColumn()
                .SetWidth("50%")
                .AddText("<h4>Product Launch</h4>")
                .AddText("<p>Our new dashboard is now live with enhanced analytics and reporting features.</p>");

            row.Add(col1);
            row.AddSpacer();

            // Update 2
            var col2 = new EmailColumn()
                .SetWidth("50%")
                .AddText("<h4>Community Growth</h4>")
                .AddText("<p>We've reached 10,000+ users in our developer community. Thank you for your support!</p>");

            row.Add(col2);
            content.Children.Add(row);
        });

        // CTA section
        contentBox.Add(content =>
        {
            content.SetHtml("<div class=\"rounded p-lg bg-light text-center\" style=\"background-color: #f6f6f6; border-radius: 4px; padding: 24px; text-align: center;\">" +
                          "<h3>Ready to Get Started?</h3>" +
                          "<p>Join thousands of developers already using our platform.</p>" +
                          "</div>");

            var signupButton = new EmailButton("Sign Up Free", "https://example.com/signup")
                .SetStyle(EmailButtonStyle.Success)
                .SetFullWidth();
            content.Children.Add(signupButton);
        });

        // Add footer
        var footer = new EmailFooter()
            .AddSocialLink("Twitter", "https://twitter.com/example", "./assets/icons-gray-brand-x.png")
            .AddSocialLink("LinkedIn", "https://linkedin.com/company/example", "./assets/icons-gray-brand-linkedin.png")
            .SetContactEmail("newsletter@example.com", "Questions about this newsletter? Contact us at")
            .SetUnsubscribeLink("https://example.com/unsubscribe", "Don't want to receive these emails anymore?")
            .SetCopyright("Example Company", 2025);

        // Build email body
        email.Body.Add(header)
                  .Add(contentBox)
                  .Add(footer);

        // Save the email
        email.Save("newsletter-email.html", openInBrowser);
        Console.WriteLine("Newsletter email created successfully!");
    }

    /// <summary>
    /// Demonstrates all email examples.
    /// </summary>
    public static void RunAllExamples(bool openInBrowser = false)
    {
        Console.WriteLine("Creating email examples...");

        CreateConfirmationEmail(openInBrowser);
        CreateInvoiceEmail(openInBrowser);
        CreateNewsletterEmail(openInBrowser);

        Console.WriteLine("All email examples created successfully!");
    }
}