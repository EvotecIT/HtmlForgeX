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
/// Now includes advanced base64 embedding with URL support and smart embedding.
/// </summary>
public static class ExampleNewsletterEmail {
    public static void Create(bool openInBrowser = false) {
        Console.WriteLine("Creating newsletter email example with advanced base64 embedding...");

        var email = new Email();

        // Email configuration
        email.Head.AddTitle("Evotec Monthly Newsletter - January 2025")
                  .AddEmailCoreStyles();

        // Build email using natural builder pattern
        email.Body.EmailBox(emailBox => {
            // Header section using EmailContent for consistent alignment
            emailBox.EmailContent(content => {
                // Use smart embedding - automatically detects file vs URL
                content.EmailImage("../../../../Assets/Images/WhiteBackground/Logo-evotec.png")
                    .EmbedSmart("../../../../Assets/Images/WhiteBackground/Logo-evotec.png") // Smart embedding
                    .WithWidth("200px")
                    .WithAlignment(Alignment.Center)
                    .WithLink("https://evotec.xyz")
                    .WithAlternativeText("Evotec Logo")
                    .WithMargin(EmailSpacing.None, EmailSpacing.None, EmailSpacing.Large, EmailSpacing.None);

                content.EmailText("📰 January 2025 Newsletter")
                    .WithFontSize(EmailFontSize.Heading1)
                    .WithFontWeight(FontWeight.Bold)
                    .WithAlignment(Alignment.Center)
                    .WithColor("#111827");

                content.EmailText("Your monthly dose of updates, insights, and innovations from Evotec")
                    .WithFontSize(EmailFontSize.Large)
                    .WithColor("#6B7280")
                    .WithAlignment(Alignment.Center)
                    .WithLineHeight("1.6")
                    .WithMargin(EmailSpacing.None, EmailSpacing.None, EmailSpacing.ExtraLarge, EmailSpacing.None);
            });

            // Featured article section using EmailContent for consistent alignment
            emailBox.EmailContent(content => {
                content.EmailText("🔥 Featured Article")
                    .WithFontSize(EmailFontSize.Heading2)
                    .WithFontWeight(FontWeight.Bold)
                    .WithColor("#111827")
                    .WithMargin(EmailSpacing.None, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);

                content.EmailText("HtmlForgeX: The Future of Email Development")
                    .WithFontSize(EmailFontSize.Large)
                    .WithFontWeight(FontWeight.SemiBold)
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
                    .WithFontWeight(FontWeight.Bold)
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
                        .WithFontWeight(FontWeight.SemiBold)
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
                    col.EmailText("• Base64 image embedding for offline emails")
                        .WithFontSize(EmailFontSize.Regular)
                        .WithColor("#374151");
                });

                // Right column - Community News
                row.EmailColumn(col => {
                    col.SetWidth("50%");
                    col.EmailText("👥 Community News")
                        .WithFontSize(EmailFontSize.Large)
                        .WithFontWeight(FontWeight.SemiBold)
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
                    col.EmailText("• Offline email support requested")
                        .WithFontSize(EmailFontSize.Regular)
                        .WithColor("#374151");
                });
            });

            // Demo section showing different embedding methods
            emailBox.EmailContent(content => {
                content.EmailText("🎯 Image Embedding Demo")
                    .WithFontSize(EmailFontSize.Large)
                    .WithFontWeight(FontWeight.SemiBold)
                    .WithColor("#111827")
                    .WithMargin(EmailSpacing.ExtraLarge, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);

                content.EmailText("This newsletter demonstrates different ways to embed images for offline compatibility:")
                    .WithFontSize(EmailFontSize.Medium)
                    .WithColor("#6B7280")
                    .WithMargin(EmailSpacing.None, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);
            });

            // Three-column demo of different embedding methods
            emailBox.EmailRow(row => {
                row.SetColumnSpacing("16px");

                // Column 1 - File embedding
                row.EmailColumn(col => {
                    col.SetWidth("33.33%");
                    col.EmailText("📁 File Embedding")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(FontWeight.SemiBold)
                        .WithColor("#059669")
                        .WithAlignment(Alignment.Center);

                    // Demonstrate file embedding with optimization
                    col.EmailImage("../../../../Assets/Images/WhiteBackground/Logo-evotec.png")
                        .EmbedFromFile("../../../../Assets/Images/WhiteBackground/Logo-evotec.png")
                        .WithOptimization(100, 100, 80) // Optimize to max 100x100, 80% quality
                        .WithWidth("80px")
                        .WithAlignment(Alignment.Center)
                        .WithAlternativeText("Local file embedded");

                    col.EmailText(".EmbedFromFile()")
                        .WithFontSize(EmailFontSize.Small)
                        .WithColor("#6B7280")
                        .WithAlignment(Alignment.Center);
                });

                // Column 2 - URL embedding (commented out for demo purposes)
                row.EmailColumn(col => {
                    col.SetWidth("33.33%");
                    col.EmailText("🌐 URL Embedding")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(FontWeight.SemiBold)
                        .WithColor("#0EA5E9")
                        .WithAlignment(Alignment.Center);

                    // Note: URL embedding is commented out for this demo to avoid external dependencies
                    // In real usage, you would use:
                    // col.EmailImage("https://example.com/image.png")
                    //     .EmbedFromUrl("https://example.com/image.png")
                    //     .WithWidth("80px")
                    //     .WithAlignment(Alignment.Center);

                    col.EmailText("(Demo: URL embedding)")
                        .WithFontSize(EmailFontSize.Small)
                        .WithColor("#6B7280")
                        .WithAlignment(Alignment.Center);

                    col.EmailText(".EmbedFromUrl()")
                        .WithFontSize(EmailFontSize.Small)
                        .WithColor("#6B7280")
                        .WithAlignment(Alignment.Center);
                });

                // Column 3 - Smart embedding
                row.EmailColumn(col => {
                    col.SetWidth("33.33%");
                    col.EmailText("🧠 Smart Embedding")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(FontWeight.SemiBold)
                        .WithColor("#7C3AED")
                        .WithAlignment(Alignment.Center);

                    col.EmailImage("../../../../Assets/Images/WhiteBackground/Logo-evotec.png")
                        .EmbedSmart("../../../../Assets/Images/WhiteBackground/Logo-evotec.png") // Auto-detects file vs URL
                        .WithWidth("80px")
                        .WithAlignment(Alignment.Center)
                        .WithAlternativeText("Smart embedded");

                    col.EmailText(".EmbedSmart()")
                        .WithFontSize(EmailFontSize.Small)
                        .WithColor("#6B7280")
                        .WithAlignment(Alignment.Center);
                });
            });

            // Highlights section using EmailContent for consistent alignment
            emailBox.EmailContent(content => {
                content.EmailText("📊 This Month's Highlights")
                    .WithFontSize(EmailFontSize.Large)
                    .WithFontWeight(FontWeight.SemiBold)
                    .WithColor("#111827")
                    .WithMargin(EmailSpacing.ExtraLarge, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);
            });

            var newsData = new List<NewsUpdate> {
                new NewsUpdate { Title = "Email Components 2.0", Description = "Major release with new features", Category = "Product" },
                new NewsUpdate { Title = "Base64 Image Embedding", Description = "Offline email support added", Category = "Feature" },
                new NewsUpdate { Title = "PowerShell Integration", Description = "Seamless PowerShell support added", Category = "Feature" },
                new NewsUpdate { Title = "Community Growth", Description = "Reached 1000+ active users", Category = "Milestone" }
            };

            emailBox.EmailTable(newsData)
                .SetStyle(EmailTableStyle.DataReport);

            // Call to action section using EmailContent for consistent alignment
            emailBox.EmailContent(content => {
                content.EmailText("🎯 Ready to Get Started?")
                    .WithFontSize(EmailFontSize.Heading3)
                    .WithFontWeight(FontWeight.Bold)
                    .WithAlignment(Alignment.Center)
                    .WithColor("#111827")
                    .WithMargin(EmailSpacing.ExtraLarge, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);

                content.EmailText("Join thousands of developers already using HtmlForgeX for their email templates.")
                    .WithFontSize(EmailFontSize.Medium)
                    .WithColor("#6B7280")
                    .WithAlignment(Alignment.Center)
                    .WithMargin(EmailSpacing.None, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);
            });

            var ctaButton = new EmailButton("Start Building", "https://evotec.xyz/contact/");
            emailBox.Add(ctaButton);

            // Footer section using EmailContent for consistent alignment
            emailBox.EmailContent(content => {
                content.EmailText("Follow us for more updates:")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithColor("#6B7280")
                    .WithAlignment(Alignment.Center)
                    .WithMargin(EmailSpacing.ExtraLarge, EmailSpacing.None, EmailSpacing.Small, EmailSpacing.None);

                content.EmailText("🐦 Twitter: @evotecpl | 🌐 Website: evotec.xyz | 📧 Email: contact@evotec.xyz")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithColor("#0EA5E9")
                    .WithAlignment(Alignment.Center);

                content.EmailText("© 2025 Evotec - Monthly Newsletter | Unsubscribe | Privacy Policy")
                    .WithFontSize(EmailFontSize.Small)
                    .WithColor("#9CA3AF")
                    .WithAlignment(Alignment.Center)
                    .WithMargin(EmailSpacing.ExtraLarge, EmailSpacing.None, EmailSpacing.None, EmailSpacing.None);
            });
        });

        // Save email
        email.Save("newsletter-email.html", openInBrowser);

        Console.WriteLine("✅ Newsletter email created successfully!");
        Console.WriteLine($@"📧 Demonstrates: Newsletter layout, multiple sections, data tables, social links, proper column spacing
🔧 New Features: Advanced base64 embedding with URL support and smart embedding
📁 Multiple embedding methods: .EmbedFromFile(), .EmbedFromUrl(), .EmbedSmart()
⚡ Image optimization: .WithOptimization() for size and quality control
💡 Smart embedding auto-detects file paths vs URLs and handles appropriately");
    }
}