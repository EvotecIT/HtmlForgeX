using System;
using System.Text;
using HtmlForgeX.Examples.Containers;
using HtmlForgeX.Examples.Emails;
using HtmlForgeX.Examples.Tags;
using HtmlForgeX.Examples.Tables;
using HtmlForgeX.Examples.ByHand;
using HtmlForgeX.Examples.Experimenting;
using HtmlForgeX.Examples.Support;

namespace HtmlForgeX.Examples;

internal class Program {
    static void Main(string[] args) {
        // Enable UTF-8 console output
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        HelpersSpectre.PrintTitle("HtmlForgeX Examples - Document-Style Configuration");

        // Configuration for opening files in browser (set to true to open automatically)
        bool openInBrowser = false;

        // Not real examples, but useful for development
        // Support.DownloadLibrariesAsync();
        //Support.GenerateTableIconsAsync();

        // Basic HTML Tag Building examples (console output)
        BasicHtmlTagBuilding.Demo1();
        BasicHtmlTagBuilding.Demo2();
        BasicHtmlTagBuilding.Demo3();

        // Tabler examples (console output)
        ExampleTablerIcon.Create();
        ExampleTablerTag.Create();
        ExampleTablerAlerts.Create();
        ExampleSvgIcons.Create();

        // Experimental examples (console output)
        Experiments01.Create();
        ExampleThreadSafeErrors.Create();

        // Manual HTML building examples
        BasicHtmlBuilding.Demo1(openInBrowser);
        BasicHtmlBuilding.Demo2(openInBrowser);
        BasicHtmlBuilding.DemoAnalytics(openInBrowser);

        // Container examples
        BasicHtmlContainer01.Demo01(openInBrowser);
        BasicHtmlContainer02.Demo02(openInBrowser);
        BasicHtmlContainer03.Demo03(openInBrowser);
        BasicHtmlContainer04.Demo01(openInBrowser);
        BasicScrollingText.Demo01(openInBrowser);
        DomainHealthCheck.Demo01(openInBrowser);

        // Table examples
        BasicHtmlTable01.Create(openInBrowser);
        BasicHtmlTable02.Create(openInBrowser);
        BasicHtmlTable03.Create(openInBrowser);

        // Email examples - showcasing the new Document-style configuration!
        Console.WriteLine("📧 Running Email Examples with Document-Style Configuration:");
        Console.WriteLine();

        // Text wrapping demo
        ExampleTextWrappingDemo.Create(openInBrowser);

        // // Improved consistency email with Document-style configuration
        ExampleImprovedConsistencyEmail.Create(openInBrowser);

        // Text wrapping demo
        ExampleTextWrappingDemo.Create(openInBrowser);

        // Direct email pattern
        ExampleDirectEmailPattern.Create(openInBrowser);

        // Corrected email pattern
        ExampleCorrectedEmailPattern.Create(openInBrowser);

        // Layout email pattern
        ExampleLayoutEmailPattern.Create(openInBrowser);

        // Invoice email with Document-style configuration
        ExampleInvoiceEmail.Create(openInBrowser);

        // Newsletter email
        ExampleNewsletterEmail.Create(openInBrowser);

        // Account verification email
        ExampleAccountVerificationEmail.Create(openInBrowser);

        // Dark mode email examples (comprehensive dark mode implementation)
        ExampleDarkModeEmail.Create(openInBrowser);  // 🌙 DARK MODE DEMO
        ExampleDarkModeEmail.CreateLightModeComparison(openInBrowser);  // ☀️ LIGHT MODE COMPARISON
        ExampleDarkModeEmail.CreateAutoModeExample(openInBrowser);  // 🔄 AUTO MODE

        // Enhanced dark mode example (NEW - showcases all improvements)
        ExampleEnhancedDarkModeEmail.Create(openInBrowser);  // 🚀 ENHANCED DARK MODE DEMO

        // Flexible header/footer example (NEW - demonstrates the flexible pattern)
        ExampleFlexibleHeaderFooter.Create(openInBrowser);  // 🎯 FLEXIBLE PATTERN DEMO

        // Direct header/footer pattern (NEWEST - demonstrates email.Header.EmailRow())
        ExampleDirectHeaderFooter.Create(openInBrowser);  // 🚀 DIRECT PATTERN DEMO

        // Order confirmation email
        ExampleOrderConfirmationEmail.Create(openInBrowser);

        // Password reset email
        ExamplePasswordResetEmail.Create(openInBrowser);

        // Simple confirmation email
        ExampleSimpleConfirmationEmail.Create(openInBrowser);

        // Welcome email
        ExampleWelcomeEmail.Create(openInBrowser);

        // Base64 embedding examples (if they exist)
        ExampleBase64EmbeddingEmail.Create(openInBrowser);

        // Layout configuration demonstration - NEW enum-based configuration system!
        ExampleLayoutConfigurationDemo.Create(openInBrowser);

        // ChartJs examples
        BasicChartJs.Demo(openInBrowser);

        // Quill editor example
        BasicQuillEditor.Demo(openInBrowser);
    }
}