using System;

namespace HtmlForgeX.Examples.Emails;

/// <summary>
/// Example demonstrating comprehensive dark mode support in HtmlForgeX emails.
/// Shows how dark mode affects all components: text, buttons, tables, backgrounds, etc.
/// </summary>
public static class ExampleDarkModeEmail
{
    public static void Create(bool openInBrowser = false)
    {
        Console.WriteLine("Creating dark mode email example...");

        // Create email with dark mode enabled
        var email = new Email()
            .EnableImageEmbedding(timeout: 30, optimize: true)
            .SetThemeMode(EmailThemeMode.Dark) // Enable dark mode!
            .ConfigureLayout(containerPadding: "16px", contentPadding: "12px", maxWidth: "600px");

        // Email configuration
        email.Head.AddTitle("Dark Mode Demo - HtmlForgeX")
                  .AddEmailCoreStyles();

        // Build email demonstrating dark mode
        email.Body.EmailBox(emailBox => {
            // Header using flexible pattern
            var header = new EmailHeader()
                .WithPadding("20px");

            header.EmailBox(headerBox => {
                headerBox.EmailRow(row => {
                    // Logo column
                    row.EmailColumn(col => {
                        col.SetWidth("50%");
                        col.EmailImage("../../../../Assets/Images/WhiteBackground/Logo-evotec.png")
                            .WithWidth("150px")
                            .WithHeight("42px")
                            .WithAlternativeText("Evotec Logo")
                            .WithLink("https://evotec.xyz", true)
                            .WithAutoEmbedding(); // Smart embedding
                    });

                    // View online link column
                    row.EmailColumn(col => {
                        col.SetWidth("50%").SetAlignment(Alignment.Right);
                        col.EmailLink("View online", "https://evotec.xyz/newsletter")
                            .WithColor("#8491a1")
                            .WithFontSize("14px");
                    });
                });
            });

            emailBox.Add(header);

            // Main content
            emailBox.EmailContent(content => {
                content.EmailText("🌙 Dark Mode Demo")
                    .WithFontSize(EmailFontSize.Heading1)
                    .WithFontWeight(FontWeight.Bold)
                    .WithAlignment(Alignment.Center)
                    .WithColor("#ffffff");

                content.EmailText("This email demonstrates comprehensive dark mode support across all components!")
                    .WithFontSize(EmailFontSize.Large)
                    .WithAlignment(Alignment.Center)
                    .WithLineHeight("1.6");
            });

            // Theme comparison section
            emailBox.EmailContent(content => {
                content.EmailText("🎨 Theme Features")
                    .WithFontSize(EmailFontSize.Heading2)
                    .WithFontWeight(FontWeight.Bold)
                    .WithColor("#ffffff");

                content.EmailText("✅ Dark backgrounds automatically applied")
                    .WithFontSize(EmailFontSize.Regular);

                content.EmailText("✅ Light text colors for readability")
                    .WithFontSize(EmailFontSize.Regular);

                content.EmailText("✅ Adjusted button and link colors")
                    .WithFontSize(EmailFontSize.Regular);

                content.EmailText("✅ Dark mode table styling")
                    .WithFontSize(EmailFontSize.Regular);

                content.EmailText("✅ Proper contrast ratios maintained")
                    .WithFontSize(EmailFontSize.Regular);
            });

            // Button demonstration
            emailBox.EmailContent(content => {
                content.EmailText("🔘 Dark Mode Buttons")
                    .WithFontSize(EmailFontSize.Heading2)
                    .WithFontWeight(FontWeight.Bold)
                    .WithColor("#ffffff");
            });

            emailBox.EmailRow(row => {
                row.SetColumnSpacing("16px");

                                 row.EmailColumn(col => {
                     col.SetWidth("33.33%");
                     var primaryButton = new EmailButton("Primary Action", "https://evotec.xyz")
                         .SetStyle(EmailButtonStyle.Primary)
                         .SetSize(EmailButtonSize.Medium);
                     col.Add(primaryButton);
                 });

                 row.EmailColumn(col => {
                     col.SetWidth("33.33%");
                     var secondaryButton = new EmailButton("Secondary", "https://evotec.xyz")
                         .SetStyle(EmailButtonStyle.Secondary)
                         .SetSize(EmailButtonSize.Medium);
                     col.Add(secondaryButton);
                 });

                 row.EmailColumn(col => {
                     col.SetWidth("33.33%");
                     var successButton = new EmailButton("Success", "https://evotec.xyz")
                         .SetStyle(EmailButtonStyle.Success)
                         .SetSize(EmailButtonSize.Medium);
                     col.Add(successButton);
                 });
            });

            // Link demonstration
            emailBox.EmailContent(content => {
                content.EmailText("🔗 Dark Mode Links")
                    .WithFontSize(EmailFontSize.Heading2)
                    .WithFontWeight(FontWeight.Bold)
                    .WithColor("#ffffff")
                    .WithMargin(EmailSpacing.ExtraLarge, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);

                content.EmailText("Links automatically adjust their colors for dark mode. Here are some examples:")
                    .WithFontSize(EmailFontSize.Regular);

                content.EmailLink("Visit our website", "https://evotec.xyz")
                    .WithFontSize(EmailFontSize.Regular);

                content.EmailText(" | ")
                    .WithFontSize(EmailFontSize.Regular);

                content.EmailLink("Contact support", "mailto:support@evotec.xyz")
                    .WithFontSize(EmailFontSize.Regular);

                content.EmailText(" | ")
                    .WithFontSize(EmailFontSize.Regular);

                content.EmailLink("GitHub repository", "https://github.com/EvotecIT/HtmlForgeX")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithNewWindow(true);
            });

            // Image demonstration with dark mode variants
            emailBox.EmailContent(content => {
                content.EmailText("🖼️ Dark Mode Images")
                    .WithFontSize(EmailFontSize.Heading2)
                    .WithFontWeight(FontWeight.Bold)
                    .WithColor("#ffffff")
                    .WithMargin(EmailSpacing.ExtraLarge, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);

                content.EmailText("Images can automatically switch between light and dark variants:")
                    .WithFontSize(EmailFontSize.Regular);
            });

            // Example of image with dark mode variant
            emailBox.EmailRow(row => {
                row.EmailColumn(col => {
                    col.SetWidth("50%");
                    col.EmailText("Logo with Dark Mode Support")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(FontWeight.SemiBold)
                        .WithAlignment(Alignment.Center);

                    // This demonstrates automatic image switching
                    col.EmailImage()
                        .WithImagePair(
                            "../../../../Assets/Images/WhiteBackground/Logo-evotec.png", // Light mode
                            "../../../../Assets/Images/BlackBackground/Logo-evotec.png", // Dark mode
                            "Evotec Logo"
                        )
                        .WithWidth("120px")
                        .WithHeight("34px")
                        .WithAlignment(Alignment.Center);
                });

                row.EmailColumn(col => {
                    col.SetWidth("50%");
                    col.EmailText("Regular Image (No Dark Mode)")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(FontWeight.SemiBold)
                        .WithAlignment(Alignment.Center);

                    // This image doesn't change in dark mode
                    col.EmailImage("../../../../Assets/Images/WhiteBackground/Logo-evotec.png")
                        .WithWidth("120px")
                        .WithHeight("34px")
                        .WithAlignment(Alignment.Center)
                        .WithoutDarkModeSwapping(); // Explicitly disable dark mode switching
                });
            });

            // Enhanced table demonstration
            emailBox.EmailContent(content => {
                content.EmailText("📊 Enhanced Dark Mode Tables")
                    .WithFontSize(EmailFontSize.Heading2)
                    .WithFontWeight(FontWeight.Bold)
                    .WithColor("#ffffff")
                    .WithMargin(EmailSpacing.ExtraLarge, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);

                content.EmailText("Tables now have comprehensive dark mode styling with proper contrast and borders:")
                    .WithFontSize(EmailFontSize.Regular);
            });

            // Enhanced dark mode table with more data
            var enhancedDarkModeData = new List<dynamic> {
                new { Feature = "🎨 Background Colors", Light = "#ffffff", Dark = "#2b3648", Status = "✅ Implemented" },
                new { Feature = "📝 Text Colors", Light = "#4b5563", Dark = "rgba(255,255,255,0.8)", Status = "✅ Implemented" },
                new { Feature = "🔗 Link Colors", Light = "#066FD1", Dark = "#60a5fa", Status = "✅ Enhanced" },
                new { Feature = "🖼️ Image Variants", Light = "Single image", Dark = "Auto-switching", Status = "🆕 New Feature" },
                new { Feature = "📊 Table Styling", Light = "Basic", Dark = "Enhanced borders", Status = "🆕 Improved" },
                new { Feature = "🎯 Button Styling", Light = "#066FD1", Dark = "#1d4ed8", Status = "✅ Implemented" }
            };

            emailBox.EmailTable(enhancedDarkModeData)
                .SetStyle(EmailTableStyle.Striped)
                .SetClass("email-table");

            // Usage examples section
            emailBox.EmailContent(content => {
                content.EmailText("💡 Usage Examples")
                    .WithFontSize(EmailFontSize.Heading2)
                    .WithFontWeight(FontWeight.Bold)
                    .WithColor("#ffffff")
                    .WithMargin(EmailSpacing.ExtraLarge, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);

                content.EmailText("Here's how to use the new dark mode features:")
                    .WithFontSize(EmailFontSize.Regular);
            });

            // Code examples in a styled box
            emailBox.EmailRow(row => {
                row.EmailColumn(col => {
                    col.SetWidth("100%");
                    col.EmailText("🖼️ Image with Dark Mode Variant:")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(FontWeight.SemiBold)
                        .WithColor("#60a5fa");

                    col.EmailText("emailImage.WithImagePair(\"logo-light.png\", \"logo-dark.png\", \"Logo\")")
                        .WithFontSize(EmailFontSize.Small)
                        .WithFontFamily("'Courier New', monospace")
                        .WithColor("rgba(255,255,255,0.7)")
                        .WithMargin(EmailSpacing.Small, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);

                    col.EmailText("🔗 Theme-Aware Links:")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(FontWeight.SemiBold)
                        .WithColor("#60a5fa");

                    col.EmailText("emailLink.WithColor(\"#custom-color\") // Overrides theme defaults")
                        .WithFontSize(EmailFontSize.Small)
                        .WithFontFamily("'Courier New', monospace")
                        .WithColor("rgba(255,255,255,0.7)")
                        .WithMargin(EmailSpacing.Small, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);

                    col.EmailText("📊 Enhanced Tables:")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(FontWeight.SemiBold)
                        .WithColor("#60a5fa");

                    col.EmailText("emailTable.SetCssClass(\"email-table\") // Enables dark mode styling")
                        .WithFontSize(EmailFontSize.Small)
                        .WithFontFamily("'Courier New', monospace")
                        .WithColor("rgba(255,255,255,0.7)");
                });
            });

            // Theme mode options
            emailBox.EmailContent(content => {
                content.EmailText("⚙️ Theme Mode Options")
                    .WithFontSize(EmailFontSize.Heading2)
                    .WithFontWeight(FontWeight.Bold)
                    .WithColor("#ffffff")
                    .WithMargin(EmailSpacing.ExtraLarge, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);
            });

            emailBox.EmailRow(row => {
                row.SetColumnSpacing("16px");

                row.EmailColumn(col => {
                    col.SetWidth("33.33%");
                    col.EmailText("Light Mode")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(FontWeight.SemiBold)
                        .WithAlignment(Alignment.Center)
                        .WithColor("#ffffff");

                    col.EmailText(".SetThemeMode(EmailThemeMode.Light)")
                        .WithFontSize(EmailFontSize.Small)
                        .WithFontFamily("monospace")
                        .WithAlignment(Alignment.Center);
                });

                row.EmailColumn(col => {
                    col.SetWidth("33.33%");
                    col.EmailText("Dark Mode")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(FontWeight.SemiBold)
                        .WithAlignment(Alignment.Center)
                        .WithColor("#ffffff");

                    col.EmailText(".SetThemeMode(EmailThemeMode.Dark)")
                        .WithFontSize(EmailFontSize.Small)
                        .WithFontFamily("monospace")
                        .WithAlignment(Alignment.Center);
                });

                row.EmailColumn(col => {
                    col.SetWidth("33.33%");
                    col.EmailText("Auto Mode")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(FontWeight.SemiBold)
                        .WithAlignment(Alignment.Center)
                        .WithColor("#ffffff");

                    col.EmailText(".SetThemeMode(EmailThemeMode.Auto)")
                        .WithFontSize(EmailFontSize.Small)
                        .WithFontFamily("monospace")
                        .WithAlignment(Alignment.Center);
                });
            });

            // Code example
            emailBox.EmailContent(content => {
                content.EmailText("💻 Implementation")
                    .WithFontSize(EmailFontSize.Heading2)
                    .WithFontWeight(FontWeight.Bold)
                    .WithColor("#ffffff")
                    .WithMargin(EmailSpacing.ExtraLarge, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);

                content.EmailText("var email = new Email()")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithFontFamily("monospace");

                content.EmailText("    .SetThemeMode(EmailThemeMode.Dark)")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithFontFamily("monospace");

                content.EmailText("    .EnableImageEmbedding()")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithFontFamily("monospace");

                content.EmailText("    .ConfigureLayout();")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithFontFamily("monospace");
            });

            // Features summary
            emailBox.EmailContent(content => {
                content.EmailText("🌟 Dark Mode Features")
                    .WithFontSize(EmailFontSize.Heading2)
                    .WithFontWeight(FontWeight.Bold)
                    .WithColor("#ffffff")
                    .WithAlignment(Alignment.Center)
                    .WithMargin(EmailSpacing.ExtraLarge, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);

                content.EmailText("✅ Automatic color scheme detection")
                    .WithFontSize(EmailFontSize.Regular);

                content.EmailText("✅ Email client compatibility (Apple Mail, Outlook, etc.)")
                    .WithFontSize(EmailFontSize.Regular);

                content.EmailText("✅ Comprehensive component support")
                    .WithFontSize(EmailFontSize.Regular);

                content.EmailText("✅ Proper contrast ratios for accessibility")
                    .WithFontSize(EmailFontSize.Regular);

                content.EmailText("✅ CSS media query support for auto mode")
                    .WithFontSize(EmailFontSize.Regular);
            });

            // Call to action
            emailBox.EmailContent(content => {
                content.EmailText("Ready to implement dark mode in your emails?")
                    .WithFontSize(EmailFontSize.Large)
                    .WithAlignment(Alignment.Center)
                    .WithColor("#ffffff")
                    .WithMargin(EmailSpacing.ExtraLarge, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);
            });

                         var ctaButton = new EmailButton("Get Started with Dark Mode", "https://evotec.xyz/htmlforgex/")
                 .SetStyle(EmailButtonStyle.Primary)
                 .SetSize(EmailButtonSize.Large);
            emailBox.Add(ctaButton);

            // Footer
            emailBox.EmailContent(content => {
                content.EmailText("Dark mode that actually works in email clients! 🎉")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithAlignment(Alignment.Center)
                    .WithMargin(EmailSpacing.ExtraLarge, EmailSpacing.None, EmailSpacing.None, EmailSpacing.None);
            });
        });

        // Save email
        email.Save("dark-mode-demo.html", openInBrowser);

        Console.WriteLine("✅ Dark mode email created successfully!");
        Console.WriteLine($@"🌙 Demonstrates: Comprehensive dark mode implementation
🔧 Key Features:
  🎨 Dark backgrounds and light text
  🔘 Dark mode button styling
  📊 Dark mode table support
  🔗 Adjusted link colors
  ⚙️ Three theme modes: Light, Dark, Auto
  📱 Email client compatibility
💡 Use .SetThemeMode(EmailThemeMode.Dark) to enable dark mode!");
    }

    public static void CreateLightModeComparison(bool openInBrowser = false)
    {
        Console.WriteLine("Creating light mode comparison email...");

        // Create the same email but in light mode for comparison
        var email = new Email()
            .EnableImageEmbedding(timeout: 30, optimize: true)
            .SetThemeMode(EmailThemeMode.Light) // Light mode
            .ConfigureLayout(containerPadding: "16px", contentPadding: "12px", maxWidth: "600px");

        email.Head.AddTitle("Light Mode Demo - HtmlForgeX")
                  .AddEmailCoreStyles();

        email.Body.EmailBox(emailBox => {
            emailBox.EmailContent(content => {
                content.EmailText("☀️ Light Mode Demo")
                    .WithFontSize(EmailFontSize.Heading1)
                    .WithFontWeight(FontWeight.Bold)
                    .WithAlignment(Alignment.Center)
                    .WithColor("#111827");

                content.EmailText("This is the same email in light mode for comparison!")
                    .WithFontSize(EmailFontSize.Large)
                    .WithAlignment(Alignment.Center)
                    .WithLineHeight("1.6");
            });

                     var ctaButton = new EmailButton("Light Mode Version", "https://evotec.xyz/htmlforgex/")
             .SetStyle(EmailButtonStyle.Primary)
             .SetSize(EmailButtonSize.Large);
            emailBox.Add(ctaButton);
        });

        email.Save("light-mode-demo.html", openInBrowser);
        Console.WriteLine("✅ Light mode comparison email created!");
    }

    public static void CreateAutoModeExample(bool openInBrowser = false)
    {
        Console.WriteLine("Creating auto mode email example...");

        // Create email with auto mode - adapts to user's system preference
        var email = new Email()
            .EnableImageEmbedding(timeout: 30, optimize: true)
            .SetThemeMode(EmailThemeMode.Auto) // Auto mode!
            .ConfigureLayout(containerPadding: "16px", contentPadding: "12px", maxWidth: "600px");

        email.Head.AddTitle("Auto Mode Demo - HtmlForgeX")
                  .AddEmailCoreStyles();

        email.Body.EmailBox(emailBox => {
            emailBox.EmailContent(content => {
                content.EmailText("🔄 Auto Mode Demo")
                    .WithFontSize(EmailFontSize.Heading1)
                    .WithFontWeight(FontWeight.Bold)
                    .WithAlignment(Alignment.Center);

                content.EmailText("This email automatically adapts to your system's dark/light mode preference!")
                    .WithFontSize(EmailFontSize.Large)
                    .WithAlignment(Alignment.Center)
                    .WithLineHeight("1.6");

                content.EmailText("Try switching your system's theme to see the email change!")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithAlignment(Alignment.Center);
            });

                     var ctaButton = new EmailButton("Auto Mode Magic", "https://evotec.xyz/htmlforgex/")
             .SetStyle(EmailButtonStyle.Primary)
             .SetSize(EmailButtonSize.Large);
            emailBox.Add(ctaButton);
        });

        email.Save("auto-mode-demo.html", openInBrowser);
        Console.WriteLine("✅ Auto mode email created!");
        Console.WriteLine("📧 Demonstrates: System preference detection, media queries, CSS fallbacks");
        Console.WriteLine("🎯 This email adapts to the user's system dark mode setting!");
    }
}

/// <summary>
/// Comprehensive example demonstrating all enhanced dark mode features.
/// Shows image variants, improved links, enhanced tables, and usage examples.
/// </summary>
public static class ExampleEnhancedDarkModeEmail
{
    public static void Create(bool openInBrowser = false)
    {
        Console.WriteLine("Creating comprehensive enhanced dark mode email example...");

        // Create email with dark mode and all enhancements
        var email = new Email()
            .EnableImageEmbedding(timeout: 30, optimize: true)
            .SetThemeMode(EmailThemeMode.Dark)
            .ConfigureLayout(containerPadding: "16px", contentPadding: "12px", maxWidth: "600px");

        // Email configuration
        email.Head.AddTitle("Enhanced Dark Mode Demo - All Features")
                  .AddEmailCoreStyles();

        // Build comprehensive email
        email.Body.EmailBox(emailBox => {
            // Header with dark mode logo using flexible pattern
            var header = new EmailHeader()
                .WithPadding("20px");

            header.EmailBox(headerBox => {
                headerBox.EmailRow(row => {
                    // Logo column with dark mode support
                    row.EmailColumn(col => {
                        col.SetWidth("50%");
                        col.EmailImage()
                            .WithImagePair(
                                "../../../../Assets/Images/WhiteBackground/Logo-evotec.png", // Light mode
                                "../../../../Assets/Images/BlackBackground/Logo-evotec.png", // Dark mode
                                "Evotec Logo"
                            )
                            .WithWidth("150px")
                            .WithHeight("42px")
                            .WithLink("https://evotec.xyz", true)
                            .WithAutoEmbedding(); // Smart embedding
                    });

                    // View online link column
                    row.EmailColumn(col => {
                        col.SetWidth("50%").SetAlignment(Alignment.Right);
                        col.EmailLink("View online", "https://evotec.xyz/newsletter")
                            .WithColor("#8491a1")
                            .WithFontSize("14px");
                    });
                });
            });

            emailBox.Add(header);

            // Main title
            emailBox.EmailContent(content => {
                content.EmailText("🚀 Enhanced Dark Mode Features")
                    .WithFontSize(EmailFontSize.Heading1)
                    .WithFontWeight(FontWeight.Bold)
                    .WithAlignment(Alignment.Center)
                    .WithColor("#ffffff");

                content.EmailText("Comprehensive dark mode support with image variants, enhanced links, and improved tables")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithAlignment(Alignment.Center)
                    .WithColor("rgba(255,255,255,0.7)");
            });

            // Feature showcase section
            emailBox.EmailContent(content => {
                content.EmailText("✨ What's New")
                    .WithFontSize(EmailFontSize.Heading2)
                    .WithFontWeight(FontWeight.Bold)
                    .WithMargin(EmailSpacing.ExtraLarge, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);
            });

            // Feature grid
            emailBox.EmailRow(row => {
                row.EmailColumn(col => {
                    col.SetWidth("33.33%");
                    col.EmailText("🖼️")
                        .WithFontSize(EmailFontSize.ExtraLarge)
                        .WithAlignment(Alignment.Center);
                    col.EmailText("Image Variants")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(FontWeight.SemiBold)
                        .WithAlignment(Alignment.Center);
                    col.EmailText("Automatic switching between light and dark images")
                        .WithFontSize(EmailFontSize.Small)
                        .WithAlignment(Alignment.Center)
                        .WithColor("rgba(255,255,255,0.7)");
                });

                row.EmailColumn(col => {
                    col.SetWidth("33.33%");
                    col.EmailText("🔗")
                        .WithFontSize(EmailFontSize.ExtraLarge)
                        .WithAlignment(Alignment.Center);
                    col.EmailText("Enhanced Links")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(FontWeight.SemiBold)
                        .WithAlignment(Alignment.Center);
                    col.EmailText("Better contrast and hover states")
                        .WithFontSize(EmailFontSize.Small)
                        .WithAlignment(Alignment.Center)
                        .WithColor("rgba(255,255,255,0.7)");
                });

                row.EmailColumn(col => {
                    col.SetWidth("33.33%");
                    col.EmailText("📊")
                        .WithFontSize(EmailFontSize.ExtraLarge)
                        .WithAlignment(Alignment.Center);
                    col.EmailText("Better Tables")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(FontWeight.SemiBold)
                        .WithAlignment(Alignment.Center);
                    col.EmailText("Improved borders and cell styling")
                        .WithFontSize(EmailFontSize.Small)
                        .WithAlignment(Alignment.Center)
                        .WithColor("rgba(255,255,255,0.7)");
                });
            });

            // Image demonstration
            emailBox.EmailContent(content => {
                content.EmailText("🖼️ Smart Image Switching")
                    .WithFontSize(EmailFontSize.Heading2)
                    .WithFontWeight(FontWeight.Bold)
                    .WithMargin(EmailSpacing.ExtraLarge, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);

                content.EmailText("Images can now automatically switch between light and dark variants based on the theme:")
                    .WithFontSize(EmailFontSize.Regular);
            });

            // Image comparison
            emailBox.EmailRow(row => {
                row.EmailColumn(col => {
                    col.SetWidth("50%");
                    col.EmailText("✅ With Dark Mode Variant")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(FontWeight.SemiBold)
                        .WithAlignment(Alignment.Center)
                        .WithColor("#10b981");

                                                              col.EmailImage()
                         .WithImagePair(
                             "../../../../Assets/Images/WhiteBackground/Logo-evotec.png",
                             "../../../../Assets/Images/BlackBackground/Logo-evotec.png",
                             "Smart Logo"
                         )
                         .WithWidth("120px")
                         .WithHeight("34px")
                         .WithAlignment(Alignment.Center)
                         .WithLink("https://evotec.xyz");

                    col.EmailText("Automatically switches to dark variant")
                        .WithFontSize(EmailFontSize.Small)
                        .WithAlignment(Alignment.Center)
                        .WithColor("rgba(255,255,255,0.6)");
                });

                row.EmailColumn(col => {
                    col.SetWidth("50%");
                    col.EmailText("⚠️ Without Dark Mode")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(FontWeight.SemiBold)
                        .WithAlignment(Alignment.Center)
                        .WithColor("#f59e0b");

                    col.EmailImage("../../../../Assets/Images/WhiteBackground/Logo-evotec.png")
                        .WithWidth("120px")
                        .WithHeight("34px")
                        .WithAlignment(Alignment.Center)
                        .WithoutDarkModeSwapping();

                    col.EmailText("May be hard to see on dark background")
                        .WithFontSize(EmailFontSize.Small)
                        .WithAlignment(Alignment.Center)
                        .WithColor("rgba(255,255,255,0.6)");
                });
            });

            // Link demonstration
            emailBox.EmailContent(content => {
                content.EmailText("🔗 Enhanced Link Styling")
                    .WithFontSize(EmailFontSize.Heading2)
                    .WithFontWeight(FontWeight.Bold)
                    .WithMargin(EmailSpacing.ExtraLarge, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);

                content.EmailText("Links now have better contrast and hover states in dark mode:")
                    .WithFontSize(EmailFontSize.Regular);
            });

            // Link examples
            emailBox.EmailRow(row => {
                row.EmailColumn(col => {
                    col.SetWidth("33.33%");
                    col.EmailText("Standard Link")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(FontWeight.SemiBold)
                        .WithAlignment(Alignment.Center);

                    col.EmailLink("Visit Website", "https://evotec.xyz")
                        .WithAlignment(Alignment.Center);
                });

                row.EmailColumn(col => {
                    col.SetWidth("33.33%");
                    col.EmailText("Email Link")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(FontWeight.SemiBold)
                        .WithAlignment(Alignment.Center);

                    col.EmailLink("Contact Support", "mailto:support@evotec.xyz")
                        .WithAlignment(Alignment.Center);
                });

                row.EmailColumn(col => {
                    col.SetWidth("33.33%");
                    col.EmailText("External Link")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(FontWeight.SemiBold)
                        .WithAlignment(Alignment.Center);

                    col.EmailLink("GitHub Repo", "https://github.com/EvotecIT/HtmlForgeX")
                        .WithAlignment(Alignment.Center)
                        .WithNewWindow(true);
                });
            });

            // Table demonstration
            emailBox.EmailContent(content => {
                content.EmailText("📊 Enhanced Table Styling")
                    .WithFontSize(EmailFontSize.Heading2)
                    .WithFontWeight(FontWeight.Bold)
                    .WithMargin(EmailSpacing.ExtraLarge, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);

                content.EmailText("Tables now have comprehensive dark mode styling with proper contrast and borders:")
                    .WithFontSize(EmailFontSize.Regular);
            });

            // Feature comparison table
            var featureData = new List<dynamic> {
                new { Feature = "🎨 Background Colors", Before = "Basic inversion", After = "Theme-aware colors", Status = "✅ Enhanced" },
                new { Feature = "📝 Text Contrast", Before = "May be hard to read", After = "Proper contrast ratios", Status = "✅ Improved" },
                new { Feature = "🔗 Link Colors", Before = "Default blue", After = "Light blue (#60a5fa)", Status = "✅ Enhanced" },
                new { Feature = "🖼️ Image Support", Before = "Single image only", After = "Light/dark variants", Status = "🆕 New" },
                new { Feature = "📊 Table Borders", Before = "Basic styling", After = "Enhanced borders", Status = "✅ Improved" },
                new { Feature = "🎯 Button Styling", Before = "May disappear", After = "Proper dark colors", Status = "✅ Fixed" }
            };

                         emailBox.EmailTable(featureData)
                 .SetStyle(EmailTableStyle.Striped)
                 .SetClass("email-table");

            // Usage guide
            emailBox.EmailContent(content => {
                content.EmailText("💡 How to Use")
                    .WithFontSize(EmailFontSize.Heading2)
                    .WithFontWeight(FontWeight.Bold)
                    .WithMargin(EmailSpacing.ExtraLarge, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);

                content.EmailText("Here's how to implement these features in your emails:")
                    .WithFontSize(EmailFontSize.Regular);
            });

            // Usage examples
            emailBox.EmailRow(row => {
                row.EmailColumn(col => {
                    col.SetWidth("100%");

                    // Image pair example
                    col.EmailText("🖼️ Image with Dark Mode Variant")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(FontWeight.SemiBold)
                        .WithColor("#60a5fa");

                    col.EmailText("var image = new EmailImage()\n    .WithImagePair(\"logo-light.png\", \"logo-dark.png\", \"Logo\")\n    .WithWidth(\"120px\")\n    .WithAlignment(\"center\");")
                        .WithFontSize(EmailFontSize.Small)
                        .WithFontFamily("'Courier New', Consolas, monospace")
                        .WithColor("rgba(255,255,255,0.8)")
                        .WithMargin(EmailSpacing.Small, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);

                    // Link example
                    col.EmailText("🔗 Theme-Aware Links")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(FontWeight.SemiBold)
                        .WithColor("#60a5fa");

                    col.EmailText("var link = new EmailLink(\"Visit Website\", \"https://example.com\")\n    .WithAlignment(\"center\");\n// Colors automatically adjust for dark mode")
                        .WithFontSize(EmailFontSize.Small)
                        .WithFontFamily("'Courier New', Consolas, monospace")
                        .WithColor("rgba(255,255,255,0.8)")
                        .WithMargin(EmailSpacing.Small, EmailSpacing.None, EmailSpacing.Medium, EmailSpacing.None);

                    // Table example
                    col.EmailText("📊 Enhanced Tables")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(FontWeight.SemiBold)
                        .WithColor("#60a5fa");

                    col.EmailText("emailBox.EmailTable(data)\n    .SetStyle(EmailTableStyle.Striped)\n    .SetCssClass(\"email-table\"); // Enables dark mode styling")
                        .WithFontSize(EmailFontSize.Small)
                        .WithFontFamily("'Courier New', Consolas, monospace")
                        .WithColor("rgba(255,255,255,0.8)");
                });
            });

            // Footer using flexible pattern
            var footer = new EmailFooter()
                .WithPadding("24px");

            footer.EmailBox(footerBox => {
                // Social links
                footerBox.EmailRow(row => {
                    row.EmailColumn(col => {
                        col.SetWidth("100%").SetAlignment(Alignment.Center);
                        col.EmailLink("Twitter", "https://twitter.com/evotecit")
                            .WithFontSize("14px")
                            .WithColor("#8491a1");
                        col.EmailText(" | ")
                            .WithFontSize("14px")
                            .WithColor("#8491a1");
                        col.EmailLink("GitHub", "https://github.com/EvotecIT")
                            .WithFontSize("14px")
                            .WithColor("#8491a1");
                    });
                });

                // Contact info
                footerBox.EmailText("If you have any questions, feel free to message us at ")
                    .WithFontSize("14px")
                    .WithColor("#8491a1")
                    .WithAlignment(Alignment.Center);
                footerBox.EmailLink("contact@evotec.xyz", "mailto:contact@evotec.xyz")
                    .WithFontSize("14px")
                    .WithColor("#8491a1")
                    .WithAlignment(Alignment.Center);

                // Unsubscribe
                footerBox.EmailText("You are receiving this email because you have bought or downloaded one of our products. ")
                    .WithFontSize("14px")
                    .WithColor("#8491a1")
                    .WithAlignment(Alignment.Center);
                footerBox.EmailLink("Unsubscribe", "https://evotec.xyz/unsubscribe")
                    .WithFontSize("14px")
                    .WithColor("#8491a1")
                    .WithAlignment(Alignment.Center);

                // Copyright
                footerBox.EmailText($"Copyright © {DateTime.Now.Year} Evotec. All rights reserved.")
                    .WithFontSize("14px")
                    .WithColor("#8491a1")
                    .WithAlignment(Alignment.Center);
            });

            emailBox.Add(footer);
        });

        // Save email
        email.Save("enhanced-dark-mode-demo.html", openInBrowser);

        Console.WriteLine("✅ Enhanced dark mode email created successfully!");
        Console.WriteLine("🚀 New Features: Image variants, enhanced links, improved tables");
        Console.WriteLine("📧 Demonstrates: Comprehensive dark mode support with all enhancements");
        Console.WriteLine("🎯 This showcases the complete dark mode feature set!");
    }
}