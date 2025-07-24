using System;

namespace HtmlForgeX.Examples.Emails;

/// <summary>
/// Example demonstrating all base64 image embedding features in HtmlForgeX.
/// Shows how to embed images from files, URLs, and use smart embedding for offline email compatibility.
/// </summary>
public static class EmailBase64Embedding
{
    public static void Create(bool openInBrowser = false)
    {
        HelpersSpectre.Success("Creating comprehensive base64 image embedding example...");

        var email = new Email();

        // Email configuration
        email.Head.AddTitle("Base64 Image Embedding Demo - HtmlForgeX")
                  .AddEmailCoreStyles();

        // Build email demonstrating all embedding features
        email.Body.EmailBox(emailBox => {
            // Header section
            emailBox.EmailContent(content => {
                content.EmailText("🖼️ Base64 Image Embedding Demo")
                    .WithFontSize(EmailFontSize.Heading1)
                    .WithFontWeight(FontWeight.Bold)
                    .WithAlignment(Alignment.Center)
                    .WithColor("#111827");

                content.EmailText("Comprehensive demonstration of offline image embedding capabilities")
                    .WithFontSize(EmailFontSize.Large)
                    .WithColor("#6B7280")
                    .WithAlignment(Alignment.Center)
                    .WithLineHeight("1.6")
                    .WithMargin(EmailSpacing.None, EmailSpacing.None, EmailSpacing.ExtraLarge, EmailSpacing.None);
            });

            // Method 1: File Embedding
            emailBox.EmailContent(content => {
                content.EmailText("📁 Method 1: File Embedding (.EmbedFromFile)")
                    .WithFontSize(EmailFontSize.Heading2)
                    .WithFontWeight(FontWeight.Bold)
                    .WithColor("#059669")
                    .WithMargin(EmailSpacing.None, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);

                content.EmailText("Embed images from local file paths as base64 data URIs:")
                    .WithFontSize(EmailFontSize.Medium)
                    .WithColor("#374151")
                    .WithMargin(EmailSpacing.None, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);
            });

            // Demonstrate file embedding with different options
            emailBox.EmailRow(row => {
                row.SetColumnSpacing("16px");

                // Basic file embedding
                row.EmailColumn(col => {
                    col.SetWidth("33.33%");
                    col.EmailText("Basic Embedding")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(FontWeight.SemiBold)
                        .WithAlignment(Alignment.Center);

                    col.EmailImage("../../../../Assets/Images/WhiteBackground/Logo-evotec.png")
                        .EmbedFromFile("../../../../Assets/Images/WhiteBackground/Logo-evotec.png")
                        .WithWidth("120px")
                        .WithAlignment(Alignment.Center)
                        .WithAlternativeText("Basic embedded logo");

                    col.EmailText($@"emailImage
.EmbedFromFile(""path/to/image.png"")")
                        .WithFontSize(EmailFontSize.Small)
                        .WithColor("#6B7280")
                        .WithAlignment(Alignment.Center);
                });

                // File embedding with optimization
                row.EmailColumn(col => {
                    col.SetWidth("33.33%");
                    col.EmailText("With Optimization")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(FontWeight.SemiBold)
                        .WithAlignment(Alignment.Center);

                    col.EmailImage("../../../../Assets/Images/WhiteBackground/Logo-evotec.png")
                        .EmbedFromFile("../../../../Assets/Images/WhiteBackground/Logo-evotec.png")
                        .WithOptimization(100, 100, 75) // Max 100x100, 75% quality
                        .WithWidth("120px")
                        .WithAlignment(Alignment.Center)
                        .WithAlternativeText("Optimized embedded logo");

                    col.EmailText($@"emailImage
.EmbedFromFile(""path/to/image.png"")
.WithOptimization(100, 100, 75)")
                        .WithFontSize(EmailFontSize.Small)
                        .WithColor("#6B7280")
                        .WithAlignment(Alignment.Center);
                });

                // File embedding with styling
                row.EmailColumn(col => {
                    col.SetWidth("33.33%");
                    col.EmailText("With Styling")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(FontWeight.SemiBold)
                        .WithAlignment(Alignment.Center);

                    col.EmailImage("../../../../Assets/Images/WhiteBackground/Logo-evotec.png")
                        .EmbedFromFile("../../../../Assets/Images/WhiteBackground/Logo-evotec.png")
                        .WithWidth("120px")
                        .WithAlignment(Alignment.Center)
                        .WithBorder("2px solid #059669")
                        .WithBorderRadius("8px")
                        .WithAlternativeText("Styled embedded logo");

                    col.EmailText($@"emailImage
.EmbedFromFile(""path/to/image.png"")
.WithBorder(""2px solid #059669"")
.WithBorderRadius(""8px"")")
                        .WithFontSize(EmailFontSize.Small)
                        .WithColor("#6B7280")
                        .WithAlignment(Alignment.Center);
                });
            });

            // Method 2: URL Embedding
            emailBox.EmailContent(content => {
                content.EmailText("🌐 Method 2: URL Embedding (.EmbedFromUrl)")
                    .WithFontSize(EmailFontSize.Heading2)
                    .WithFontWeight(FontWeight.Bold)
                    .WithColor("#0EA5E9")
                    .WithMargin(EmailSpacing.ExtraLarge, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);

                content.EmailText("Embed images from remote URLs as base64 data URIs:")
                    .WithFontSize(EmailFontSize.Medium)
                    .WithColor("#374151")
                    .WithMargin(EmailSpacing.None, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);
            });

            // URL embedding examples (commented for demo)
            emailBox.EmailRow(row => {
                row.SetColumnSpacing("16px");

                row.EmailColumn(col => {
                    col.SetWidth("50%");
                    col.EmailText("Basic URL Embedding")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(FontWeight.SemiBold)
                        .WithAlignment(Alignment.Center);

                    col.EmailText("(Demo - URL embedding disabled)")
                        .WithFontSize(EmailFontSize.Regular)
                        .WithColor("#6B7280")
                        .WithAlignment(Alignment.Center);

                    col.EmailText($@"emailImage
.EmbedFromUrlAsync(""https://example.com/image.png"")")
                        .WithFontSize(EmailFontSize.Small)
                        .WithColor("#6B7280")
                        .WithAlignment(Alignment.Center);
                });

                row.EmailColumn(col => {
                    col.SetWidth("50%");
                    col.EmailText("With Timeout Control")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(FontWeight.SemiBold)
                        .WithAlignment(Alignment.Center);

                    col.EmailText("(Demo - URL embedding disabled)")
                        .WithFontSize(EmailFontSize.Regular)
                        .WithColor("#6B7280")
                        .WithAlignment(Alignment.Center);

                    col.EmailText($@"emailImage
.EmbedFromUrlAsync(""https://example.com/image.png"", 60)")
                        .WithFontSize(EmailFontSize.Small)
                        .WithColor("#6B7280")
                        .WithAlignment(Alignment.Center);
                });
            });

            // Method 3: Smart Embedding
            emailBox.EmailContent(content => {
                content.EmailText("🧠 Method 3: Smart Embedding (.EmbedSmart)")
                    .WithFontSize(EmailFontSize.Heading2)
                    .WithFontWeight(FontWeight.Bold)
                    .WithColor("#7C3AED")
                    .WithMargin(EmailSpacing.ExtraLarge, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);

                content.EmailText("Automatically detects file paths vs URLs and handles appropriately:")
                    .WithFontSize(EmailFontSize.Medium)
                    .WithColor("#374151")
                    .WithMargin(EmailSpacing.None, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);
            });

            // Smart embedding examples
            emailBox.EmailRow(row => {
                row.SetColumnSpacing("16px");

                row.EmailColumn(col => {
                    col.SetWidth("50%");
                    col.EmailText("Auto-detect File Path")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(FontWeight.SemiBold)
                        .WithAlignment(Alignment.Center);

                    col.EmailImage("../../../../Assets/Images/WhiteBackground/Logo-evotec.png")
                        .EmbedSmart("../../../../Assets/Images/WhiteBackground/Logo-evotec.png")
                        .WithWidth("100px")
                        .WithAlignment(Alignment.Center)
                        .WithAlternativeText("Smart embedded file");

                    col.EmailText($@"emailImage
.EmbedSmart(""path/to/image.png"")")
                        .WithFontSize(EmailFontSize.Small)
                        .WithColor("#6B7280")
                        .WithAlignment(Alignment.Center);
                });

                row.EmailColumn(col => {
                    col.SetWidth("50%");
                    col.EmailText("Auto-detect URL")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(FontWeight.SemiBold)
                        .WithAlignment(Alignment.Center);

                    col.EmailText("(Demo - would auto-detect URL)")
                        .WithFontSize(EmailFontSize.Regular)
                        .WithColor("#6B7280")
                        .WithAlignment(Alignment.Center);

                    col.EmailText($@"emailImage
.EmbedSmart(""https://example.com/image.png"")")
                        .WithFontSize(EmailFontSize.Small)
                        .WithColor("#6B7280")
                        .WithAlignment(Alignment.Center);
                });
            });

            // Method 4: Direct Base64 Embedding
            emailBox.EmailContent(content => {
                content.EmailText("📋 Method 4: Direct Base64 (.EmbedFromBase64)")
                    .WithFontSize(EmailFontSize.Heading2)
                    .WithFontWeight(FontWeight.Bold)
                    .WithColor("#DC2626")
                    .WithMargin(EmailSpacing.ExtraLarge, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);

                content.EmailText("Embed images using pre-encoded base64 data:")
                    .WithFontSize(EmailFontSize.Medium)
                    .WithColor("#374151")
                    .WithMargin(EmailSpacing.None, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);
            });

            emailBox.EmailRow(row => {
                row.EmailColumn(col => {
                    col.SetWidth("100%");
                    col.EmailText("Direct Base64 Embedding")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(FontWeight.SemiBold)
                        .WithAlignment(Alignment.Center);

                    col.EmailText("(Demo - would use pre-encoded base64 data)")
                        .WithFontSize(EmailFontSize.Regular)
                        .WithColor("#6B7280")
                        .WithAlignment(Alignment.Center);

                    col.EmailText($@"emailImage
.EmbedFromBase64(base64String, ""image/png"")")
                        .WithFontSize(EmailFontSize.Small)
                        .WithColor("#6B7280")
                        .WithAlignment(Alignment.Center);
                });
            });

            // Benefits section
            emailBox.EmailContent(content => {
                content.EmailText("✅ Benefits of Base64 Embedding")
                    .WithFontSize(EmailFontSize.Heading2)
                    .WithFontWeight(FontWeight.Bold)
                    .WithColor("#111827")
                    .WithMargin(EmailSpacing.ExtraLarge, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);
            });

            emailBox.EmailRow(row => {
                row.SetColumnSpacing("16px");

                row.EmailColumn(col => {
                    col.SetWidth("50%");
                    col.EmailText("🔒 Offline Compatibility")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(FontWeight.SemiBold)
                        .WithColor("#059669");
                    col.EmailText("• Works without internet connection")
                        .WithFontSize(EmailFontSize.Regular)
                        .WithColor("#374151");
                    col.EmailText("• No broken image links")
                        .WithFontSize(EmailFontSize.Regular)
                        .WithColor("#374151");
                    col.EmailText("• Consistent email appearance")
                        .WithFontSize(EmailFontSize.Regular)
                        .WithColor("#374151");
                });

                row.EmailColumn(col => {
                    col.SetWidth("50%");
                    col.EmailText("📧 Email Client Support")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(FontWeight.SemiBold)
                        .WithColor("#0EA5E9");
                    col.EmailText("• Bypasses image blocking")
                        .WithFontSize(EmailFontSize.Regular)
                        .WithColor("#374151");
                    col.EmailText("• Works in most email clients")
                        .WithFontSize(EmailFontSize.Regular)
                        .WithColor("#374151");
                    col.EmailText("• No external dependencies")
                        .WithFontSize(EmailFontSize.Regular)
                        .WithColor("#374151");
                });
            });

            // Considerations section
            emailBox.EmailContent(content => {
                content.EmailText("⚠️ Important Considerations")
                    .WithFontSize(EmailFontSize.Heading2)
                    .WithFontWeight(FontWeight.Bold)
                    .WithColor("#DC2626")
                    .WithMargin(EmailSpacing.ExtraLarge, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);

                content.EmailText("• Base64 encoding increases file size by ~33%")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithColor("#374151");
                content.EmailText("• Large images may cause email size limits to be exceeded")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithColor("#374151");
                content.EmailText("• Some email clients have base64 size limits")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithColor("#374151");
                content.EmailText("• Use image optimization to reduce file sizes")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithColor("#374151");
            });

            // Footer
            emailBox.EmailContent(content => {
                content.EmailText("🎯 Best Practices")
                    .WithFontSize(EmailFontSize.Heading3)
                    .WithFontWeight(FontWeight.Bold)
                    .WithColor("#111827")
                    .WithMargin(EmailSpacing.ExtraLarge, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);

                content.EmailText("1. Use .EmbedSmart() for automatic detection")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithColor("#374151");
                content.EmailText("2. Enable optimization for large images")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithColor("#374151");
                content.EmailText("3. Test in target email clients")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithColor("#374151");
                content.EmailText("4. Keep total email size under 100KB when possible")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithColor("#374151");
            });
        });

        // Save email
        email.Save("base64-embedding-demo.html", openInBrowser);

        HelpersSpectre.Success("✅ Base64 embedding demo email created successfully!");
        HelpersSpectre.Success($@"📧 Demonstrates: All base64 embedding methods and best practices
🔧 Features Shown:
  📁 .EmbedFromFile() - Local file embedding
  🌐 .EmbedFromUrlAsync() - Remote URL embedding
  🧠 .EmbedSmart() - Auto-detection embedding
  📋 .EmbedFromBase64() - Direct base64 embedding
  ⚡ .WithOptimization() - Image optimization
💡 Perfect for offline email compatibility and bypassing image blocking!");
    }
}