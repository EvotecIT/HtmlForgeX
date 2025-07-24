using System;
using System.Text;
using HtmlForgeX.Examples.Containers;
using HtmlForgeX.Examples.Charts;
using HtmlForgeX.Examples.Emails;
using HtmlForgeX.Examples.Tags;
using HtmlForgeX.Examples.Tables;
using HtmlForgeX.Examples.ByHand;
using HtmlForgeX.Examples.Experimenting;
using HtmlForgeX.Examples.Support;
using HtmlForgeX.Examples.Forms;
using HtmlForgeX.Examples.Tabler;
using HtmlForgeX.Examples.VisNetwork;
using HtmlForgeX.Examples.Icons;

namespace HtmlForgeX.Examples;

internal class Program {
    static void Main(string[] args) {
        // Enable UTF-8 console output
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        HelpersSpectre.PrintTitle("HtmlForgeX Examples - Document-Style Configuration");

        // Configuration for opening files in browser (set to openInBrowser to open automatically)
        bool openInBrowser = false;

        // Not real examples, but useful for development
        // Support.DownloadLibrariesAsync();
        // Support.GenerateTableIconsAsync();

        // Basic HTML Tag Building examples (console output)
        BasicHtmlTagBuilding.Demo1();
        BasicHtmlTagBuilding.Demo2();
        BasicHtmlTagBuilding.Demo3();

        // Tabler examples (console output)
        TablerIconDemo.Create();
        TablerSvgIcons.Create();
        ExampleFontAwesomeOnline.Create(openInBrowser);

        // Tabler examples html output
        TablerTagDemo.Create(openInBrowser);
        TablerColorHex.Create();
        TablerAlerts.Create(openInBrowser);

        // Experimental examples (console output)
        Experiments01.Create();
        ExampleThreadSafeErrors.Create();

        // Manual HTML building examples
        BasicHtmlBuilding.Demo1(openInBrowser);
        BasicHtmlBuilding.Demo2(openInBrowser);
        BasicHtmlBuilding.DemoAnalytics(openInBrowser);
        GoogleFontExample.Demo(openInBrowser);
        BasicHtmlBuilding.DemoSanitizedRawHtml(openInBrowser);

        // Toast examples
        TablerToastDemo.Create(openInBrowser);
        TablerToastAdvanced.Create(openInBrowser);
        TablerToastOptions.Create(openInBrowser);
        TablerProgressBarShowcase.Create(openInBrowser);
        TablerTimelineDemo.Create(openInBrowser);
        TablerLogsDemo.Create(openInBrowser);

        // Forms examples
        TablerFormDemo.Create(openInBrowser);
        TablerFormInputs.Create(openInBrowser);
        ExampleComprehensiveForm.Create(openInBrowser);
        TablerStarRatingDemo.Create(openInBrowser);

        // Quill editor example
        BasicQuillEditor.Demo(openInBrowser);

        // Container examples
        BasicHtmlContainer01.Demo01(openInBrowser);
        BasicHtmlContainer02.Demo02(openInBrowser);
        BasicHtmlContainer03.Demo03(openInBrowser);
        BasicHtmlContainer04.Demo01(openInBrowser);

        // Infocards
        InfocardsDemo.Demo01(openInBrowser);
        InfocardsCleanDemo.Demo01(openInBrowser);
        BasicScrollingText.Demo01(openInBrowser);
        DomainHealthCheck.Demo01(openInBrowser);
        EnhancedDataGridDemo.Create(openInBrowser);

        // Complete Tabler Cards demo - ALL features
        TablerCardsCompleteDemo.Demo01(openInBrowser);
        TablerCardsEnhancedDemo.Demo01(openInBrowser);
        TablerCardsProperDemo.Demo01(openInBrowser);

        // Table examples
        BasicHtmlTable01.Create(openInBrowser);
        BasicHtmlTable02.Create(openInBrowser);
        BasicHtmlTable03.Create(openInBrowser);
        BasicHtmlTable04.Create(openInBrowser);

        // Email examples - showcasing the new Document-style configuration!
        HelpersSpectre.Success("📧 Running Email Examples with Document-Style Configuration:");
        HelpersSpectre.Break();

        // Text wrapping demo
        EmailTextWrappingDemo.Create(openInBrowser);

        // // Improved consistency email with Document-style configuration
        EmailImprovedConsistency.Create(openInBrowser);

        // Text wrapping demo
        EmailTextWrappingDemo.Create(openInBrowser);

        // Direct email pattern
        EmailDirectPattern.Create(openInBrowser);

        // Corrected email pattern
        EmailCorrectedPattern.Create(openInBrowser);

        // Layout email pattern
        EmailLayoutPattern.Create(openInBrowser);

        // Invoice email with Document-style configuration
        EmailInvoice.Create(openInBrowser);

        // Newsletter email
        EmailNewsletter.Create(openInBrowser);

        // Account verification email
        EmailAccountVerification.Create(openInBrowser);

        // Dark mode email examples (comprehensive dark mode implementation)
        EmailDarkMode.Create(openInBrowser);  // 🌙 DARK MODE DEMO
        EmailDarkMode.CreateLightModeComparison(openInBrowser);  // ☀️ LIGHT MODE COMPARISON
        EmailDarkMode.CreateAutoModeExample(openInBrowser);  // 🔄 AUTO MODE

        // Enhanced dark mode example (NEW - showcases all improvements)
        EmailEnhancedDarkMode.Create(openInBrowser);  // 🚀 ENHANCED DARK MODE DEMO

        // Enhanced Accordion & Steps showcase
        EnhancedAccordionStepsShowcase.Demo01(openInBrowser);  // 🎛️ ENHANCED ACCORDION & STEPS DEMO

        // Flexible header/footer example (NEW - demonstrates the flexible pattern)
        EmailFlexibleHeaderFooter.Create(openInBrowser);  // 🎯 FLEXIBLE PATTERN DEMO

        // Direct header/footer pattern (NEWEST - demonstrates email.Header.EmailRow())
        EmailDirectHeaderFooter.Create(openInBrowser);  // 🚀 DIRECT PATTERN DEMO

        // Order confirmation email
        EmailOrderConfirmation.Create(openInBrowser);

        // Password reset email
        EmailPasswordReset.Create(openInBrowser);

        // Simple confirmation email
        EmailSimpleConfirmation.Create(openInBrowser);

        // Welcome email
        EmailWelcome.Create(openInBrowser);

        // Link encoding demonstration
        EmailLinkEncoding.Create(openInBrowser);

        // Base64 embedding examples (if they exist)
        EmailBase64Embedding.Create(openInBrowser);

        // Decimal margin demonstration
        EmailDecimalMargin.Create(openInBrowser);

        // Layout configuration demonstration - NEW enum-based configuration system!
        EmailLayoutConfigurationDemo.Create(openInBrowser);

        // Chart examples
        ChartJsBasicDemo.Demo(openInBrowser);
        ChartsApexBasicDemo.Demo(openInBrowser);
        ChartsApexComprehensiveDemo.Demo(openInBrowser);

        // VisNetwork images demo
        VisNetworkBasicDemo.Demo(openInBrowser);
        VisNetworkAdvancedDemo.Demo(openInBrowser);
        VisNetworkPhysicsExamples.Demo(openInBrowser);
        VisNetworkLayoutExamples.Demo(openInBrowser);
        VisNetworkNodeStylingExamples.Demo(openInBrowser);
        VisNetworkEdgeManipulationExamples.Demo(openInBrowser);
        VisNetworkInteractionExamples.Demo(openInBrowser);
        VisNetworkImprovementsDemo.Create(openInBrowser);
        VisNetworkMultiLineLabelDemo.Create(openInBrowser);
        VisNetworkGradientEdgesDemo.Create(openInBrowser);
        VisNetworkEventsDemo.Create(openInBrowser);
        VisNetworkClusteringDemo.Create(openInBrowser);
        VisNetworkMethodsDemo.Create(openInBrowser);
        VisNetworkExportImportDemo.Create(openInBrowser);
        VisNetworkCustomShapesDemo.Create(openInBrowser);
        VisNetworkAdvancedFeaturesDemo.Create(openInBrowser);

        // VisNetwork HTML Nodes example (with visjs-html-nodes plugin)
        VisNetworkExamples.VisNetworkHtmlNodesExample.Run(openInBrowser);

        // VisNetwork Advanced Labels example (HTML tooltips, \n line breaks, markdown)
        VisNetworkAdvancedLabelsExample.Run(openInBrowser);

        // Table examples
        DataTablesQuickStart.Create(openInBrowser);
        AdvancedDataTablesDemo.Create(openInBrowser);
        DataTablesExtensionsDemo.Create(openInBrowser);
        DataTablesFeatureTest.RunAllTests(openInBrowser);
        DataTablesRenderingDemo.Create(openInBrowser);
        DataTablesInteractiveFilteringDemo.Create(openInBrowser);

        // Demonstrates rendering HTML in a headless browser
        // ExampleHeadlessRendering.CreateAsync(openInBrowser).GetAwaiter().GetResult();

        // Show basic usage of ImageUtilities
        ExampleImageUtilities.Demonstrate();

        // SmartTab & SmartWizard examples
        SmartWizardBasicDemo.Demo01(openInBrowser);
        SmartTabBasicDemo.Demo01(openInBrowser);
        SmartTabWizardCompleteDemo.Demo01(openInBrowser);
        SmartTabWizardSimpleDemo.Demo01(openInBrowser);
        SmartTabWizardInteroperabilityDemo.Demo01(openInBrowser);
    }
}