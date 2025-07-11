using System;

namespace HtmlForgeX.Examples.Emails;

/// <summary>
/// Example demonstrating the improved consistency in HtmlForgeX email components.
/// Shows: No path duplication, EmailLink component, consistent padding, and consolidated EmailHeader.
/// Uses the natural Document-style configuration approach.
/// </summary>
public static class ExampleImprovedConsistencyEmail {
    public static void Create(bool openInBrowser = false) {
        Console.WriteLine("Creating improved consistency email example with Document-style configuration...");

        // Natural Document-style approach - configure the email directly!
        var email = new Email()
            .EnableImageEmbedding(timeout: 30, optimize: true)  // Enable auto-embedding with optimization
            .ConfigureImageOptimization(maxWidth: 800, maxHeight: 600, quality: 85)
            .SetMaxEmbedFileSize(2 * 1024 * 1024) // 2MB limit
            .SetSmartImageDetection(true)
            .SetDarkModeSupport(true)
            .ConfigureLayout(containerPadding: "12px", contentPadding: "8px", maxWidth: "1000px");

        // Or use pre-configured approach
        // var email = new Email(DocumentConfiguration.ForEmail());

        // Email configuration
        email.Head.AddTitle("Improved Consistency Demo - HtmlForgeX")
                  .AddEmailCoreStyles();

                // Header with consolidated EmailImage integration using new direct pattern
        email.Header.SetPadding("20px");
        email.Header.EmailRow(row => {
            // Logo column
            row.EmailColumn(col => {
                col.SetWidth("70%");
                col.EmailImage("../../../../Assets/Images/WhiteBackground/Logo-evotec.png")
                    .WithWidth("150px")
                    .WithHeight("42px")
                    .WithAlternativeText("Evotec Logo")
                    .WithLink("https://evotec.xyz", true);
            });

            // View online link column
            row.EmailColumn(col => {
                col.SetWidth("30%").SetAlignment("right");
                col.EmailLink("View Online", "https://evotec.xyz/newsletter")
                    .WithFontSize(EmailFontSize.Small)
                    .WithColor("#6B7280");
            });
        });

        // Build email demonstrating all improvements
        email.Body.EmailBox(emailBox => {
            // Main content
            emailBox.EmailContent(content => {
                content.EmailText("🎯 Document-Style Configuration")
                    .WithFontSize(EmailFontSize.Heading1)
                    .WithFontWeight(EmailFontWeight.Bold)
                    .WithAlignment("center")
                    .WithColor("#111827");

                content.EmailText("Configure your email just like Document - natural and intuitive!")
                    .WithFontSize(EmailFontSize.Large)
                    .WithColor("#6B7280")
                    .WithAlignment("center")
                    .WithLineHeight("1.6");
            });

            // Configuration approach demonstration
            emailBox.EmailContent(content => {
                content.EmailText("✅ 1. Natural Email Configuration")
                    .WithFontSize(EmailFontSize.Heading2)
                    .WithFontWeight(EmailFontWeight.Bold)
                    .WithColor("#059669");

                content.EmailText("Just like Document.Head.AddTitle() - configure email directly!")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithColor("#059669")
                    .WithFontFamily("monospace");

                content.EmailText("email.EnableImageEmbedding().ConfigureLayout().SetDarkModeSupport()")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithColor("#059669")
                    .WithFontFamily("monospace");
            });

            // Configuration examples
            emailBox.EmailContent(content => {
                content.EmailText("Configuration Methods:")
                    .WithFontSize(EmailFontSize.Medium)
                    .WithFontWeight(EmailFontWeight.SemiBold)
                    .WithColor("#111827");

                content.EmailText("• .EnableImageEmbedding(timeout, optimize) - Auto-embed images")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithColor("#374151");

                content.EmailText("• .ConfigureImageOptimization(width, height, quality) - Image settings")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithColor("#374151");

                content.EmailText("• .ConfigureLayout(padding, maxWidth) - Layout settings")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithColor("#374151");

                content.EmailText("• .SetDarkModeSupport() - Dark mode configuration")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithColor("#374151");
            });

            // Demo images with automatic embedding based on email configuration
            emailBox.EmailRow(row => {
                row.SetColumnSpacing("16px");

                row.EmailColumn(col => {
                    col.SetWidth("50%");
                    col.EmailText("Auto-embedded (Email Config)")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(EmailFontWeight.SemiBold)
                        .WithAlignment("center");

                    // Automatically embedded based on email configuration - no duplication!
                    col.EmailImage("../../../../Assets/Images/WhiteBackground/Logo-evotec.png")
                        .WithWidth("120px")
                        .WithAlignment("center")
                        .WithAlternativeText("Auto-embedded via email config");
                });

                row.EmailColumn(col => {
                    col.SetWidth("50%");
                    col.EmailText("Override Per-Image")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(EmailFontWeight.SemiBold)
                        .WithAlignment("center");

                    // Can still override email configuration for specific images
                    col.EmailImage("../../../../Assets/Images/WhiteBackground/Logo-evotec.png")
                        .WithoutAutoEmbedding() // Override config for this image
                        .WithWidth("120px")
                        .WithAlignment("center")
                        .WithAlternativeText("Config overridden");
                });
            });

            // EmailLink demonstration
            emailBox.EmailContent(content => {
                content.EmailText("✅ 2. Dedicated EmailLink Component")
                    .WithFontSize(EmailFontSize.Heading2)
                    .WithFontWeight(EmailFontWeight.Bold)
                    .WithColor("#0EA5E9");

                content.EmailText("Before: new Span().AppendContent(url).WithFontSize()... - verbose!")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithColor("#EF4444")
                    .WithFontFamily("monospace");

                content.EmailText("After: EmailLink(text, url) - clean and consistent!")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithColor("#0EA5E9")
                    .WithFontFamily("monospace");
            });

            // EmailLink examples
            emailBox.EmailRow(row => {
                row.SetColumnSpacing("16px");

                row.EmailColumn(col => {
                    col.SetWidth("33.33%");
                    col.EmailText("Basic Link")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(EmailFontWeight.SemiBold)
                        .WithAlignment("center");

                    col.EmailLink("Visit our website", "https://evotec.xyz")
                        .WithAlignment("center")
                        .WithFontSize(EmailFontSize.Regular);
                });

                row.EmailColumn(col => {
                    col.SetWidth("33.33%");
                    col.EmailText("Styled Link")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(EmailFontWeight.SemiBold)
                        .WithAlignment("center");

                    col.EmailLink("Contact Support", "mailto:support@evotec.xyz")
                        .WithAlignment("center")
                        .WithFontSize(EmailFontSize.Regular)
                        .WithColor("#059669")
                        .WithFontWeight(EmailFontWeight.SemiBold);
                });

                row.EmailColumn(col => {
                    col.SetWidth("33.33%");
                    col.EmailText("New Window Link")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(EmailFontWeight.SemiBold)
                        .WithAlignment("center");

                    col.EmailLink("Open GitHub", "https://github.com/EvotecIT/HtmlForgeX")
                        .WithAlignment("center")
                        .WithFontSize(EmailFontSize.Regular)
                        .WithNewWindow(true)
                        .WithColor("#7C3AED");
                });
            });

            // Natural configuration demonstration
            emailBox.EmailContent(content => {
                content.EmailText("🌟 Natural Configuration Pattern")
                    .WithFontSize(EmailFontSize.Heading2)
                    .WithFontWeight(EmailFontWeight.Bold)
                    .WithColor("#059669");

                content.EmailText("Follows the same pattern as Document class - intuitive and familiar!")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithColor("#6B7280");

                content.EmailText("document.Head.AddTitle(\"Title\").AddMeta(\"description\", \"desc\")")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithColor("#059669")
                    .WithFontFamily("monospace");

                content.EmailText("email.EnableImageEmbedding().ConfigureLayout().SetDarkModeSupport()")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithColor("#059669")
                    .WithFontFamily("monospace");
            });

            // Configuration method categories
            emailBox.EmailRow(row => {
                row.SetColumnSpacing("16px");

                row.EmailColumn(col => {
                    col.SetWidth("33.33%");
                    col.EmailText("Image Methods")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(EmailFontWeight.SemiBold)
                        .WithAlignment("center")
                        .WithColor("#0EA5E9");

                    col.EmailText("• EnableImageEmbedding()")
                        .WithFontSize(EmailFontSize.Small)
                        .WithColor("#374151")
                        .WithNaturalWrapping();

                    col.EmailText("• DisableImageEmbedding()")
                        .WithFontSize(EmailFontSize.Small)
                        .WithColor("#374151")
                        .WithNaturalWrapping();

                    col.EmailText("• ConfigureImageOptimization()")
                        .WithFontSize(EmailFontSize.Small)
                        .WithColor("#374151")
                        .WithNaturalWrapping();

                    col.EmailText("• SetMaxEmbedFileSize()")
                        .WithFontSize(EmailFontSize.Small)
                        .WithColor("#374151")
                        .WithNaturalWrapping();
                });

                row.EmailColumn(col => {
                    col.SetWidth("33.33%");
                    col.EmailText("Detection Methods")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(EmailFontWeight.SemiBold)
                        .WithAlignment("center")
                        .WithColor("#7C3AED");

                    col.EmailText("• SetSmartImageDetection()")
                        .WithFontSize(EmailFontSize.Small)
                        .WithColor("#374151")
                        .WithNaturalWrapping();

                    col.EmailText("• SetEmbeddingWarnings()")
                        .WithFontSize(EmailFontSize.Small)
                        .WithColor("#374151")
                        .WithNaturalWrapping();

                    col.EmailText("• Auto file vs URL detection")
                        .WithFontSize(EmailFontSize.Small)
                        .WithColor("#374151");

                    col.EmailText("• Configurable timeouts")
                        .WithFontSize(EmailFontSize.Small)
                        .WithColor("#374151");
                });

                row.EmailColumn(col => {
                    col.SetWidth("33.33%");
                    col.EmailText("Layout Methods")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(EmailFontWeight.SemiBold)
                        .WithAlignment("center")
                        .WithColor("#DC2626");

                    col.EmailText("• ConfigureLayout()")
                        .WithFontSize(EmailFontSize.Small)
                        .WithColor("#374151")
                        .WithNaturalWrapping();

                    col.EmailText("• SetDarkModeSupport()")
                        .WithFontSize(EmailFontSize.Small)
                        .WithColor("#374151")
                        .WithNaturalWrapping();

                    col.EmailText("• Container padding")
                        .WithFontSize(EmailFontSize.Small)
                        .WithColor("#374151");

                    col.EmailText("• Max content width")
                        .WithFontSize(EmailFontSize.Small)
                        .WithColor("#374151");
                });
            });

            // Per-image override demonstration
            emailBox.EmailContent(content => {
                content.EmailText("🎛️ Per-Image Override System")
                    .WithFontSize(EmailFontSize.Heading2)
                    .WithFontWeight(EmailFontWeight.Bold)
                    .WithColor("#7C3AED");

                content.EmailText("Images respect email configuration but can override individually:")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithColor("#6B7280");

                content.EmailText(".WithAutoEmbedding() - Force embedding even if email config disables it")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithColor("#059669")
                    .WithFontFamily("monospace");

                content.EmailText(".WithoutAutoEmbedding() - Skip embedding even if email config enables it")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithColor("#EF4444")
                    .WithFontFamily("monospace");
            });

            // Comparison with Document pattern
            emailBox.EmailContent(content => {
                content.EmailText("📋 Follows Document Pattern")
                    .WithFontSize(EmailFontSize.Heading2)
                    .WithFontWeight(EmailFontWeight.Bold)
                    .WithColor("#111827");

                content.EmailText("Document Pattern:")
                    .WithFontSize(EmailFontSize.Medium)
                    .WithFontWeight(EmailFontWeight.SemiBold)
                    .WithColor("#374151");

                content.EmailText("document.Head.AddTitle(\"Title\").AddMeta(\"description\", \"desc\")")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithColor("#6B7280")
                    .WithFontFamily("monospace")
                    .WithNaturalWrapping();

                content.EmailText("Email Pattern:")
                    .WithFontSize(EmailFontSize.Medium)
                    .WithFontWeight(EmailFontWeight.SemiBold)
                    .WithColor("#374151");

                content.EmailText("email.EnableImageEmbedding().ConfigureLayout().SetDarkModeSupport()")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithColor("#6B7280")
                    .WithFontFamily("monospace")
                    .WithNaturalWrapping();
            });

            // Summary
            emailBox.EmailContent(content => {
                content.EmailText("🎉 Benefits of Document-Style Configuration")
                    .WithFontSize(EmailFontSize.Heading2)
                    .WithFontWeight(EmailFontWeight.Bold)
                    .WithColor("#111827")
                    .WithAlignment("center");

                content.EmailText("✅ Natural and intuitive - follows Document pattern")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithColor("#059669");

                content.EmailText("✅ Method chaining - configure multiple settings fluently")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithColor("#0EA5E9");

                content.EmailText("✅ Per-component overrides - fine-grained control when needed")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithColor("#7C3AED");

                content.EmailText("✅ Consistent with existing HtmlForgeX patterns")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithColor("#DC2626");

                content.EmailText("✅ No separate configuration objects to manage")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithColor("#059669");
            });

            // Call to action
            emailBox.EmailContent(content => {
                content.EmailText("Ready to experience Document-style email configuration?")
                    .WithFontSize(EmailFontSize.Large)
                    .WithAlignment("center")
                    .WithColor("#111827")
                    .WithMargin(EmailSpacing.ExtraLarge, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);
            });

            var ctaButton = new EmailButton("Get Started Now", "https://evotec.xyz/htmlforgex/");
            emailBox.Add(ctaButton);

            // Footer
            emailBox.EmailContent(content => {
                content.EmailText("Natural configuration that feels just like Document!")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithColor("#6B7280")
                    .WithAlignment("center")
                    .WithMargin(EmailSpacing.ExtraLarge, EmailSpacing.None, EmailSpacing.None, EmailSpacing.None);
            });
        });

        // Save email
        email.Save("improved-consistency-demo.html", openInBrowser);

        Console.WriteLine("✅ Improved consistency email created successfully!");
        Console.WriteLine($@"🎯 Demonstrates: Document-style configuration pattern
🔧 Key Features:
  🏗️ Natural email configuration - email.EnableImageEmbedding()
  ⚙️ Method chaining - configure multiple settings fluently
  🎛️ Per-component overrides - fine-grained control
  📋 Follows Document pattern - document.Head.AddTitle()
  🚫 No separate configuration objects to manage
💡 Much more natural and intuitive than separate configuration objects!");
    }
}