using System;

namespace HtmlForgeX.Examples.Emails;

/// <summary>
/// News update data for demonstrating newsletter content.
/// </summary>
public class NewsUpdate {
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string Category { get; set; } = "";
}

/// <summary>
/// Example of a newsletter email using natural HtmlForgeX patterns.
/// Demonstrates newsletter layout with multiple content sections and social links.
/// </summary>
public static class ExampleNewsletterEmail {
    public static void Create(bool openInBrowser = false) {
        Console.WriteLine("Creating newsletter email example...");

        var email = new Email();

        // Email configuration
        email.Head.AddTitle("Evotec Monthly Newsletter - January 2025")
                  .AddEmailCoreStyles();

        // Build email using natural builder pattern
        email.Body.EmailBox(emailBox => {
            // Header section using EmailContent for consistent alignment
            emailBox.EmailContent(content => {
                content.EmailImage("../../../../Assets/Images/WhiteBackground/Logo-evotec.png")
                    .WithWidth("200px")
                    .WithAlignment("center")
                    .WithLink("https://evotec.xyz")
                    .WithMargin(EmailSpacing.None, EmailSpacing.None, EmailSpacing.Large, EmailSpacing.None);

                content.EmailText("📰 January 2025 Newsletter")
                    .WithFontSize(EmailFontSize.Heading1)
                    .WithFontWeight(EmailFontWeight.Bold)
                    .WithAlignment("center")
                    .WithColor("#111827");

                content.EmailText("Your monthly dose of updates, insights, and innovations from Evotec")
                    .WithFontSize(EmailFontSize.Large)
                    .WithColor("#6B7280")
                    .WithAlignment("center")
                    .WithLineHeight("1.6")
                    .WithMargin(EmailSpacing.None, EmailSpacing.None, EmailSpacing.ExtraLarge, EmailSpacing.None);
            });

            // Featured article section using EmailContent for consistent alignment
            emailBox.EmailContent(content => {
                content.EmailText("🔥 Featured Article")
                    .WithFontSize(EmailFontSize.Heading2)
                    .WithFontWeight(EmailFontWeight.Bold)
                    .WithColor("#111827")
                    .WithMargin(EmailSpacing.None, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);

                content.EmailText("HtmlForgeX: The Future of Email Development")
                    .WithFontSize(EmailFontSize.Large)
                    .WithFontWeight(EmailFontWeight.SemiBold)
                    .WithColor("#059669");

                content.EmailText("Discover how HtmlForgeX is revolutionizing email template development with type-safe, user-friendly components that make creating beautiful emails as easy as writing C# code.")
                    .WithFontSize(EmailFontSize.Medium)
                    .WithColor("#374151")
                    .WithLineHeight("1.6")
                    .WithMargin(EmailSpacing.Small, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);
            });

            var readMoreButton = new EmailButton("Read Full Article", "https://evotec.xyz/htmlforgex/");
            emailBox.Add(readMoreButton);

            // News updates heading using EmailContent for consistent alignment
            emailBox.EmailContent(content => {
                content.EmailText("📈 Latest Updates")
                    .WithFontSize(EmailFontSize.Heading2)
                    .WithFontWeight(EmailFontWeight.Bold)
                    .WithColor("#111827")
                    .WithMargin(EmailSpacing.ExtraLarge, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);
            });

            // Two-column news layout with proper alignment
            emailBox.EmailRow(row => {
                row.SetColumnSpacing("24px"); // Automatic spacing between columns

                // Left column - Product Updates
                row.EmailColumn(col => {
                    col.SetWidth("50%");
                    col.EmailText("🚀 Product Updates")
                        .WithFontSize(EmailFontSize.Large)
                        .WithFontWeight(EmailFontWeight.SemiBold)
                        .WithColor("#059669");
                    col.EmailText("• New email components released")
                        .WithFontSize(EmailFontSize.Regular)
                        .WithColor("#374151");
                    col.EmailText("• Enhanced table styling options")
                        .WithFontSize(EmailFontSize.Regular)
                        .WithColor("#374151");
                    col.EmailText("• Improved type safety for data binding")
                        .WithFontSize(EmailFontSize.Regular)
                        .WithColor("#374151");
                });

                // Right column - Community News
                row.EmailColumn(col => {
                    col.SetWidth("50%");
                    col.EmailText("👥 Community News")
                        .WithFontSize(EmailFontSize.Large)
                        .WithFontWeight(EmailFontWeight.SemiBold)
                        .WithColor("#0EA5E9");
                    col.EmailText("• 1,000+ developers using HtmlForgeX")
                        .WithFontSize(EmailFontSize.Regular)
                        .WithColor("#374151");
                    col.EmailText("• New community forum launched")
                        .WithFontSize(EmailFontSize.Regular)
                        .WithColor("#374151");
                    col.EmailText("• Monthly webinar series started")
                        .WithFontSize(EmailFontSize.Regular)
                        .WithColor("#374151");
                });
            });

            // Highlights section using EmailContent for consistent alignment
            emailBox.EmailContent(content => {
                content.EmailText("📊 This Month's Highlights")
                    .WithFontSize(EmailFontSize.Large)
                    .WithFontWeight(EmailFontWeight.SemiBold)
                    .WithColor("#111827")
                    .WithMargin(EmailSpacing.ExtraLarge, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);
            });

            var newsData = new List<NewsUpdate> {
                new NewsUpdate { Title = "Email Components 2.0", Description = "Major release with new features", Category = "Product" },
                new NewsUpdate { Title = "PowerShell Integration", Description = "Seamless PowerShell support added", Category = "Feature" },
                new NewsUpdate { Title = "Community Growth", Description = "Reached 1000+ active users", Category = "Milestone" }
            };

            emailBox.EmailTable(newsData)
                .SetStyle(EmailTableStyle.DataReport);

            // Call to action section using EmailContent for consistent alignment
            emailBox.EmailContent(content => {
                content.EmailText("🎯 Ready to Get Started?")
                    .WithFontSize(EmailFontSize.Heading3)
                    .WithFontWeight(EmailFontWeight.Bold)
                    .WithAlignment("center")
                    .WithColor("#111827")
                    .WithMargin(EmailSpacing.ExtraLarge, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);

                content.EmailText("Join thousands of developers already using HtmlForgeX for their email templates.")
                    .WithFontSize(EmailFontSize.Medium)
                    .WithColor("#6B7280")
                    .WithAlignment("center")
                    .WithMargin(EmailSpacing.None, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);
            });

            var ctaButton = new EmailButton("Start Building", "https://evotec.xyz/contact/");
            emailBox.Add(ctaButton);

            // Footer section using EmailContent for consistent alignment
            emailBox.EmailContent(content => {
                content.EmailText("Follow us for more updates:")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithColor("#6B7280")
                    .WithAlignment("center")
                    .WithMargin(EmailSpacing.ExtraLarge, EmailSpacing.None, EmailSpacing.Small, EmailSpacing.None);

                content.EmailText("🐦 Twitter: @evotecpl | 🌐 Website: evotec.xyz | 📧 Email: contact@evotec.xyz")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithColor("#0EA5E9")
                    .WithAlignment("center");

                content.EmailText("© 2025 Evotec - Monthly Newsletter | Unsubscribe | Privacy Policy")
                    .WithFontSize(EmailFontSize.Small)
                    .WithColor("#9CA3AF")
                    .WithAlignment("center")
                    .WithMargin(EmailSpacing.ExtraLarge, EmailSpacing.None, EmailSpacing.None, EmailSpacing.None);
            });
        });

        // Save email
        email.Save("newsletter-email.html", openInBrowser);
        Console.WriteLine("✅ Newsletter email created successfully!");
        Console.WriteLine("📧 Demonstrates: Newsletter layout, multiple sections, data tables, social links, proper column spacing");
    }
}