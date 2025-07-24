using System;

namespace HtmlForgeX.Examples.Emails;

/// <summary>
/// Example demonstrating the new enum-based layout configuration system.
/// Shows all predefined layout sizes and padding options, plus custom configurations.
/// </summary>
public static class EmailLayoutConfigurationDemo {
    public static void Create(bool openInBrowser = false) {
        HelpersSpectre.Success("Creating layout configuration demonstration with enum-based settings...");

        // Example 1: Using predefined enums (easiest)
        var email1 = new Email()
            .ConfigureLayout(EmailLayoutSize.ExtraWide, EmailPaddingSize.Large, EmailPaddingSize.Medium)
            .SetThemeMode(EmailThemeMode.Light);

        email1.Head.AddTitle("Layout Demo 1: Extra Wide with Large Padding")
              .AddEmailCoreStyles();

        email1.Body.EmailBox(emailBox => {
            emailBox.EmailContent(content => {
                content.EmailText("📐 Layout Configuration Demo #1")
                    .WithFontSize(EmailFontSize.Heading1)
                    .WithFontWeight(FontWeight.Bold)
                    .WithAlignment(Alignment.Center)
                    .WithColor("#111827");

                content.EmailText($"Layout: {EmailLayoutSize.ExtraWide.GetDescription()}")
                    .WithFontSize(EmailFontSize.Large)
                    .WithColor("#059669")
                    .WithAlignment(Alignment.Center);

                content.EmailText($"Container Padding: {EmailPaddingSize.Large.GetDescription()}")
                    .WithFontSize(EmailFontSize.Medium)
                    .WithColor("#374151")
                    .WithAlignment(Alignment.Center);

                content.EmailText($"Content Padding: {EmailPaddingSize.Medium.GetDescription()}")
                    .WithFontSize(EmailFontSize.Medium)
                    .WithColor("#374151")
                    .WithAlignment(Alignment.Center);
            });

            emailBox.EmailRow(row => {
                row.EmailColumn(col => {
                    col.SetWidth("33.33%");
                    col.EmailText("Left Column")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(FontWeight.SemiBold)
                        .WithAlignment(Alignment.Center)
                        .WithColor("#DC2626");
                    col.EmailText("This demonstrates the extra-wide layout with generous padding. Perfect for newsletters and content-heavy emails.")
                        .WithFontSize(EmailFontSize.Regular)
                        .WithColor("#374151");
                });

                row.EmailColumn(col => {
                    col.SetWidth("33.33%");
                    col.EmailText("Center Column")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(FontWeight.SemiBold)
                        .WithAlignment(Alignment.Center)
                        .WithColor("#059669");
                    col.EmailText("Notice how the 1000px width gives us plenty of room for three columns without feeling cramped.")
                        .WithFontSize(EmailFontSize.Regular)
                        .WithColor("#374151");
                });

                row.EmailColumn(col => {
                    col.SetWidth("33.33%");
                    col.EmailText("Right Column")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(FontWeight.SemiBold)
                        .WithAlignment(Alignment.Center)
                        .WithColor("#7C3AED");
                    col.EmailText("The large container padding (16px) and medium content padding (12px) create a comfortable reading experience.")
                        .WithFontSize(EmailFontSize.Regular)
                        .WithColor("#374151");
                });
            });
        });

        // Example 2: Mixed approach - custom width with enum padding
        var email2 = new Email()
            .ConfigureLayout("750px", EmailPaddingSize.Small, EmailPaddingSize.ExtraSmall)
            .SetThemeMode(EmailThemeMode.Light);

        email2.Head.AddTitle("Layout Demo 2: Custom Width with Enum Padding")
              .AddEmailCoreStyles();

        email2.Body.EmailBox(emailBox => {
            emailBox.EmailContent(content => {
                content.EmailText("⚙️ Layout Configuration Demo #2")
                    .WithFontSize(EmailFontSize.Heading1)
                    .WithFontWeight(FontWeight.Bold)
                    .WithAlignment(Alignment.Center)
                    .WithColor("#111827");

                content.EmailText("Custom Width: 750px (between Wide and ExtraWide)")
                    .WithFontSize(EmailFontSize.Large)
                    .WithColor("#059669")
                    .WithAlignment(Alignment.Center);

                content.EmailText($"Container Padding: {EmailPaddingSize.Small.GetDescription()}")
                    .WithFontSize(EmailFontSize.Medium)
                    .WithColor("#374151")
                    .WithAlignment(Alignment.Center);

                content.EmailText($"Content Padding: {EmailPaddingSize.ExtraSmall.GetDescription()}")
                    .WithFontSize(EmailFontSize.Medium)
                    .WithColor("#374151")
                    .WithAlignment(Alignment.Center);
            });

            emailBox.EmailContent(content => {
                content.EmailText("🎯 Perfect for Professionals")
                    .WithFontSize(EmailFontSize.Heading2)
                    .WithFontWeight(FontWeight.Bold)
                    .WithColor("#059669");

                content.EmailText("This configuration gives you exact control over width while using convenient enum-based padding. Great when you know exactly what width you need but want the convenience of predefined padding sizes.")
                    .WithFontSize(EmailFontSize.Regular)
                    .WithColor("#374151")
                    .WithLineHeight("1.6");
            });
        });

        // Example 3: All layout sizes comparison
        var email3 = new Email()
            .ConfigureLayout(EmailLayoutSize.Standard, EmailPaddingSize.Medium, EmailPaddingSize.Small)
            .SetThemeMode(EmailThemeMode.Light);

        email3.Head.AddTitle("Layout Demo 3: All Layout Sizes Overview")
              .AddEmailCoreStyles();

        email3.Body.EmailBox(emailBox => {
            emailBox.EmailContent(content => {
                content.EmailText("📏 All Layout Sizes Overview")
                    .WithFontSize(EmailFontSize.Heading1)
                    .WithFontWeight(FontWeight.Bold)
                    .WithAlignment(Alignment.Center)
                    .WithColor("#111827");

                content.EmailText("Choose the perfect size for your email's purpose")
                    .WithFontSize(EmailFontSize.Large)
                    .WithColor("#6B7280")
                    .WithAlignment(Alignment.Center)
                    .WithLineHeight("1.6");
            });

            // Layout sizes table
            emailBox.EmailRow(row => {
                row.EmailColumn(col => {
                    col.SetWidth("50%");
                    col.EmailText("📱 Compact (480px)")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(FontWeight.Bold)
                        .WithColor("#DC2626");
                    col.EmailText("Perfect for mobile-first designs. Great for simple notifications and alerts.")
                        .WithFontSize(EmailFontSize.Small)
                        .WithColor("#374151");

                    col.EmailText("📧 Standard (600px)")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(FontWeight.Bold)
                        .WithColor("#059669")
                        .WithMargin(EmailSpacing.Medium, EmailSpacing.None, EmailSpacing.Small, EmailSpacing.None);
                    col.EmailText("Most common email width. Works well across all email clients. Recommended for most use cases.")
                        .WithFontSize(EmailFontSize.Small)
                        .WithColor("#374151");

                    col.EmailText("🖥️ Wide (800px)")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(FontWeight.Bold)
                        .WithColor("#7C3AED")
                        .WithMargin(EmailSpacing.Medium, EmailSpacing.None, EmailSpacing.Small, EmailSpacing.None);
                    col.EmailText("Good for desktop-focused emails with more content. Suitable for dashboards and reports.")
                        .WithFontSize(EmailFontSize.Small)
                        .WithColor("#374151");
                });

                row.EmailColumn(col => {
                    col.SetWidth("50%");
                    col.EmailText("📰 Extra Wide (1000px)")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(FontWeight.Bold)
                        .WithColor("#059669");
                    col.EmailText("For newsletters and content-heavy emails. Allows for complex multi-column layouts.")
                        .WithFontSize(EmailFontSize.Small)
                        .WithColor("#374151");

                    col.EmailText("↔️ Full Width (100%)")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(FontWeight.Bold)
                        .WithColor("#F59E0B")
                        .WithMargin(EmailSpacing.Medium, EmailSpacing.None, EmailSpacing.Small, EmailSpacing.None);
                    col.EmailText("Adapts to container size. Use with caution in emails - some clients may not handle this well.")
                        .WithFontSize(EmailFontSize.Small)
                        .WithColor("#374151");

                    col.EmailText("🛠️ Custom")
                        .WithFontSize(EmailFontSize.Medium)
                        .WithFontWeight(FontWeight.Bold)
                        .WithColor("#6B7280")
                        .WithMargin(EmailSpacing.Medium, EmailSpacing.None, EmailSpacing.Small, EmailSpacing.None);
                    col.EmailText("Specify exact pixel value or percentage. Perfect when you need precise control.")
                        .WithFontSize(EmailFontSize.Small)
                        .WithColor("#374151");
                });
            });
        });

        // Example 4: All padding sizes comparison
        var email4 = new Email()
            .ConfigureLayout(EmailLayoutSize.Wide, EmailPaddingSize.Medium, EmailPaddingSize.Small)
            .SetThemeMode(EmailThemeMode.Light);

        email4.Head.AddTitle("Layout Demo 4: All Padding Sizes Overview")
              .AddEmailCoreStyles();

        email4.Body.EmailBox(emailBox => {
            emailBox.EmailContent(content => {
                content.EmailText("📐 All Padding Sizes Overview")
                    .WithFontSize(EmailFontSize.Heading1)
                    .WithFontWeight(FontWeight.Bold)
                    .WithAlignment(Alignment.Center)
                    .WithColor("#111827");

                content.EmailText("From tight layouts to spacious designs")
                    .WithFontSize(EmailFontSize.Large)
                    .WithColor("#6B7280")
                    .WithAlignment(Alignment.Center)
                    .WithLineHeight("1.6");
            });

            // Padding sizes demonstration
            emailBox.EmailRow(row => {
                row.EmailColumn(col => {
                    col.SetWidth("50%");
                    col.EmailText("Tight Layouts")
                        .WithFontSize(EmailFontSize.Large)
                        .WithFontWeight(FontWeight.Bold)
                        .WithColor("#DC2626")
                        .WithAlignment(Alignment.Center);

                    col.EmailText($"🚫 None: {EmailPaddingSize.None.GetDescription()}")
                        .WithFontSize(EmailFontSize.Small)
                        .WithColor("#374151");

                    col.EmailText($"📱 Extra Small: {EmailPaddingSize.ExtraSmall.GetDescription()}")
                        .WithFontSize(EmailFontSize.Small)
                        .WithColor("#374151");

                    col.EmailText($"📧 Small: {EmailPaddingSize.Small.GetDescription()}")
                        .WithFontSize(EmailFontSize.Small)
                        .WithColor("#374151");
                });

                row.EmailColumn(col => {
                    col.SetWidth("50%");
                    col.EmailText("Spacious Layouts")
                        .WithFontSize(EmailFontSize.Large)
                        .WithFontWeight(FontWeight.Bold)
                        .WithColor("#059669")
                        .WithAlignment(Alignment.Center);

                    col.EmailText($"⚖️ Medium: {EmailPaddingSize.Medium.GetDescription()}")
                        .WithFontSize(EmailFontSize.Small)
                        .WithColor("#374151");

                    col.EmailText($"🏠 Large: {EmailPaddingSize.Large.GetDescription()}")
                        .WithFontSize(EmailFontSize.Small)
                        .WithColor("#374151");

                    col.EmailText($"🏰 Extra Large: {EmailPaddingSize.ExtraLarge.GetDescription()}")
                        .WithFontSize(EmailFontSize.Small)
                        .WithColor("#374151");
                });
            });
        });

        // Save all examples
        email1.Save("EmailLayoutConfigurationDemo_ExtraWide.html", openInBrowser);
        email2.Save("EmailLayoutConfigurationDemo_CustomWidth.html", false);
        email3.Save("EmailLayoutConfigurationDemo_AllSizes.html", false);
        email4.Save("EmailLayoutConfigurationDemo_AllPadding.html", false);

        HelpersSpectre.Success("✅ Layout configuration demos created successfully!");
        HelpersSpectre.Success("📧 Demonstrates: Enum-based configuration, predefined sizes, custom options");
        HelpersSpectre.Success("🎯 Files created:");
        HelpersSpectre.Success("   • layout-demo-1-extra-wide.html - ExtraWide layout with Large padding");
        HelpersSpectre.Success("   • layout-demo-2-custom-width.html - Custom 750px width with enum padding");
        HelpersSpectre.Success("   • layout-demo-3-all-sizes.html - Overview of all layout sizes");
        HelpersSpectre.Success("   • layout-demo-4-all-padding.html - Overview of all padding sizes");
        HelpersSpectre.Success("💡 Key Benefits:");
        HelpersSpectre.Success("   ✅ Easy-to-use predefined options (EmailLayoutSize.Standard)");
        HelpersSpectre.Success("   ✅ Professional control for experts (custom values)");
        HelpersSpectre.Success("   ✅ Clear descriptions (.GetDescription() method)");
        HelpersSpectre.Success("   ✅ Proper configuration integration (affects all components)");
        HelpersSpectre.Success("   ✅ Backward compatibility (string values still work)");
    }
}