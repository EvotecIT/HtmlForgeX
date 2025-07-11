using System;
using System.Text;
using HtmlForgeX.Examples.Containers;
using HtmlForgeX.Examples.Emails;
using HtmlForgeX.Examples.Tags;
using HtmlForgeX.Examples.Tables;
using HtmlForgeX.Examples.ByHand;
using HtmlForgeX.Examples.Experimenting;
using HtmlForgeX.Examples.Support;
using Spectre.Console;

namespace HtmlForgeX.Examples;

internal class Program {
    static void Main(string[] args) {
        // Enable UTF-8 console output
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        HelpersSpectre.PrintTitle("HtmlForgeX Examples - Document-Style Configuration");

        // Configuration for opening files in browser (set to true to open automatically)
        bool openInBrowser = true;

        // Support examples (uncomment to run)
        // Support.DownloadLibraries();
        // Support.GenerateTableIcons();

        // Basic HTML Tag Building examples
        // BasicHtmlTagBuilding01.Demo1(openInBrowser);
        // BasicHtmlTagBuilding01.Demo2(openInBrowser);
        // BasicHtmlTagBuilding02.Demo3(openInBrowser);

        // Container examples
        // BasicHtmlContainer01.Demo01(openInBrowser);
        // BasicHtmlContainer02.Demo02(openInBrowser);
        // BasicHtmlContainer03.Demo03(openInBrowser);
        // BasicHtmlContainer04.Demo04(openInBrowser);
        // BasicScrollingText.Create(openInBrowser);
        // DomainHealthCheck.Create(openInBrowser);

        // Table examples
        // BasicHtmlTable01.Create(openInBrowser);

        // Experimental examples
        // Experiments01.Create(openInBrowser);

        // Email examples - showcasing the new Document-style configuration!
        Console.WriteLine("📧 Running Email Examples with Document-Style Configuration:");
        Console.WriteLine();

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
        // ExampleEnhancedDarkModeEmail.Create(openInBrowser);  // 🚀 ENHANCED DARK MODE DEMO

        // Flexible header/footer example (NEW - demonstrates the flexible pattern)
        ExampleFlexibleHeaderFooter.Create(openInBrowser);  // 🎯 FLEXIBLE PATTERN DEMO

        // Direct header/footer pattern (NEWEST - demonstrates email.Header.EmailRow())
        ExampleDirectHeaderFooter.Create(openInBrowser);  // 🚀 DIRECT PATTERN DEMO

        // Header test (DEBUG - minimal test for header layout)
        // ExampleHeaderTest.Create(openInBrowser);  // 🐛 DEBUG HEADER LAYOUT

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

        // Improved consistency demonstration - ACTIVE by default to show new features!
        ExampleImprovedConsistencyEmail.Create(openInBrowser);

        // Tabler examples
        // ExampleTablerIcon.Create(openInBrowser);
        // ExampleTablerTag.Create(openInBrowser);
        // ExampleTablerAlerts.Create(openInBrowser);
        // ExampleSvgIcons.Create(openInBrowser);

        // Manual HTML building examples
        // BasicHtmlBuilding.CreateStaticFiles(openInBrowser);

        Console.WriteLine();
        Console.WriteLine("🎉 Email generated with Document-style configuration!");
        Console.WriteLine("📁 Check 'improved-consistency-demo.html' to see the results!");
        Console.WriteLine();
        Console.WriteLine("💡 To enable other examples, uncomment them in Program.cs");
        Console.WriteLine("💡 To open files automatically in browser, set openInBrowser = true");
        Console.WriteLine("💡 Much more natural than separate configuration objects!");
    }
}