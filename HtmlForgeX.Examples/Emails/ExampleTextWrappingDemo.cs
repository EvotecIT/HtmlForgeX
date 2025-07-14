using System;

namespace HtmlForgeX.Examples.Emails;

/// <summary>
/// Demonstrates different text wrapping modes for controlling how text breaks and wraps.
/// Shows how to handle long method names, technical content, and various wrapping scenarios.
/// </summary>
public static class ExampleTextWrappingDemo
{
    public static void Create(bool openInBrowser = false)
    {
        Console.WriteLine("Creating text wrapping demonstration...");

        var email = new Email();
        email.Head.AddTitle("Text Wrapping Modes Demo - Professional Control")
                  .AddEmailCoreStyles();

        email.Body.EmailBox(emailBox => {
            emailBox.SetPadding("16px");

            // Header
            emailBox.EmailContent(content => {
                content.EmailText("📝 Text Wrapping Modes Demo")
                    .WithFontSize(EmailFontSize.Heading1)
                    .WithFontWeight(FontWeight.Bold)
                    .WithAlignment(Alignment.Center)
                    .WithColor("#111827")
                    .WithMargin(EmailSpacing.None, EmailSpacing.None, EmailSpacing.Large, EmailSpacing.None);

                content.EmailText("Compare how different wrapping modes handle long method names and technical content")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithAlignment(Alignment.Center)
                    .WithColor("#6B7280")
                    .WithMargin(EmailSpacing.None, EmailSpacing.None, EmailSpacing.ExtraLarge, EmailSpacing.None);
            });

            // Demo content with long method names
            var longMethodName = "ConfigureImageOptimization().SetMaxEmbedFileSize().EnableAutomaticDetection()";
            var technicalContent = "The email.EnableImageEmbedding().ConfigureImageOptimization().SetSmartImageDetection() method chain provides comprehensive image handling capabilities for professional email templates.";

            // Default wrapping example
            emailBox.EmailRow(row => {
                row.EmailColumn(col => {
                    col.SetWidth("150px");
                    col.EmailText("Default Wrapping:")
                        .WithFontWeight(FontWeight.Bold)
                        .WithColor("#059669");
                });
                row.EmailColumn(col => {
                    col.SetWidth("450px");
                    col.EmailText(longMethodName)
                        .WithWrapMode(EmailTextWrapMode.Default)
                        .WithFontFamily("'Courier New', monospace")
                        .WithFontSize("13px")
                        .WithColor("#374151");
                });
            });

            // Natural wrapping example
            emailBox.EmailRow(row => {
                row.EmailColumn(col => {
                    col.SetWidth("150px");
                    col.EmailText("Natural Wrapping:")
                        .WithFontWeight(FontWeight.Bold)
                        .WithColor("#2563EB");
                });
                row.EmailColumn(col => {
                    col.SetWidth("450px");
                    col.EmailText(longMethodName)
                        .WithNaturalWrapping()
                        .WithFontFamily("'Courier New', monospace")
                        .WithFontSize("13px")
                        .WithColor("#374151");
                });
            });

            // Smart wrapping example
            emailBox.EmailRow(row => {
                row.EmailColumn(col => {
                    col.SetWidth("150px");
                    col.EmailText("Smart Wrapping:")
                        .WithFontWeight(FontWeight.Bold)
                        .WithColor("#7C3AED");
                });
                row.EmailColumn(col => {
                    col.SetWidth("450px");
                    col.EmailText(longMethodName)
                        .WithSmartWrapping()
                        .WithFontFamily("'Courier New', monospace")
                        .WithFontSize("13px")
                        .WithColor("#374151");
                });
            });

            // Aggressive wrapping example
            emailBox.EmailRow(row => {
                row.EmailColumn(col => {
                    col.SetWidth("150px");
                    col.EmailText("Aggressive Wrapping:")
                        .WithFontWeight(FontWeight.Bold)
                        .WithColor("#DC2626");
                });
                row.EmailColumn(col => {
                    col.SetWidth("450px");
                    col.EmailText(longMethodName)
                        .WithAggressiveWrapping()
                        .WithFontFamily("'Courier New', monospace")
                        .WithFontSize("13px")
                        .WithColor("#374151");
                });
            });

            // Separator
            emailBox.EmailContent(content => {
                content.EmailText("Technical Content Example")
                    .WithFontSize(EmailFontSize.Heading2)
                    .WithFontWeight(FontWeight.Bold)
                    .WithColor("#111827")
                    .WithMargin(EmailSpacing.ExtraLarge, EmailSpacing.None, EmailSpacing.Large, EmailSpacing.None);
            });

            // Technical content with different wrapping modes
            emailBox.EmailRow(row => {
                row.EmailColumn(col => {
                    col.SetWidth("300px").WithNaturalWrapping();
                    col.EmailText("Natural Wrapping Column")
                        .WithFontWeight(FontWeight.Bold)
                        .WithColor("#2563EB")
                        .WithMargin(EmailSpacing.None, EmailSpacing.None, EmailSpacing.Small, EmailSpacing.None);
                    col.EmailText(technicalContent)
                        .WithNaturalWrapping()
                        .WithFontSize("14px")
                        .WithColor("#374151");
                });
                row.EmailColumn(col => {
                    col.SetWidth("300px").WithSmartWrapping();
                    col.EmailText("Smart Wrapping Column")
                        .WithFontWeight(FontWeight.Bold)
                        .WithColor("#7C3AED")
                        .WithMargin(EmailSpacing.None, EmailSpacing.None, EmailSpacing.Small, EmailSpacing.None);
                    col.EmailText(technicalContent)
                        .WithSmartWrapping()
                        .WithFontSize("14px")
                        .WithColor("#374151");
                });
            });

            // Code example with preserved formatting
            emailBox.EmailContent(content => {
                content.EmailText("Code Example with Preserved Formatting")
                    .WithFontSize(EmailFontSize.Heading3)
                    .WithFontWeight(FontWeight.Bold)
                    .WithColor("#111827")
                    .WithMargin(EmailSpacing.ExtraLarge, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);

                var codeExample = @"var email = new Email()
    .EnableImageEmbedding()
    .ConfigureImageOptimization()
    .SetMaxEmbedFileSize(1024 * 1024);";

                content.EmailText(codeExample)
                    .WithPreservedFormatting()
                    .WithFontFamily("'Courier New', monospace")
                    .WithFontSize("12px")
                    .WithColor("#1F2937")
                    .WithMargin(EmailSpacing.Medium);
            });

            // Usage guide
            emailBox.EmailContent(content => {
                content.EmailText("Usage Guide")
                    .WithFontSize(EmailFontSize.Heading2)
                    .WithFontWeight(FontWeight.Bold)
                    .WithColor("#111827")
                    .WithMargin(EmailSpacing.ExtraLarge, EmailSpacing.None, EmailSpacing.Large, EmailSpacing.None);

                content.EmailText("• Natural Wrapping: .WithNaturalWrapping() - Perfect for method names and URLs")
                    .WithFontSize("14px")
                    .WithColor("#374151")
                    .WithMargin(EmailSpacing.Small, EmailSpacing.None);

                content.EmailText("• Smart Wrapping: .WithSmartWrapping() - Best for technical documentation")
                    .WithFontSize("14px")
                    .WithColor("#374151")
                    .WithMargin(EmailSpacing.Small, EmailSpacing.None);

                content.EmailText("• Column-level: col.WithNaturalWrapping() - Apply to entire column")
                    .WithFontSize("14px")
                    .WithColor("#374151")
                    .WithMargin(EmailSpacing.Small, EmailSpacing.None);

                content.EmailText("• Configurable: .WithWrapMode(EmailTextWrapMode.Natural) - Full control")
                    .WithFontSize("14px")
                    .WithColor("#374151")
                    .WithMargin(EmailSpacing.Small, EmailSpacing.None);
            });
        });

        // Save email
        email.Save("text-wrapping-demo.html", openInBrowser);
        Console.WriteLine("✅ Text wrapping demo created successfully!");
        Console.WriteLine("📧 Demonstrates: Natural, Smart, Default, Aggressive, and Preserved text wrapping modes");
        Console.WriteLine("🎯 Perfect for: Technical documentation, method names, code examples, and professional layouts");
        Console.WriteLine("💡 Pro tip: Use .WithNaturalWrapping() for method names like 'ConfigureImageOptimization'!");
    }
}