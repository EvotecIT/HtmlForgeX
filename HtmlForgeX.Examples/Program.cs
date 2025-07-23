using System;
using System.Text;
using HtmlForgeX.Examples.Containers;
using HtmlForgeX.Examples.Emails;
using HtmlForgeX.Examples.Tags;
using HtmlForgeX.Examples.Tables;
using HtmlForgeX.Examples.ByHand;
using HtmlForgeX.Examples.Experimenting;
using HtmlForgeX.Examples.Support;
using HtmlForgeX.Examples.Forms;
using HtmlForgeX.Examples.Tabler;
using HtmlForgeX.Examples.VisNetwork;

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
        ExampleTablerIcon.Create();
        ExampleSvgIcons.Create();

        // Tabler examples html output
        ExampleTablerTag.Create(openInBrowser);
        ExampleTablerAlerts.Create(openInBrowser);

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
        ExampleTablerToast.Create(openInBrowser);
        ExampleTablerToastAdvanced.Create(openInBrowser);
        ExampleTablerProgressBarShowcase.Create(openInBrowser);
        ExampleTablerTimeline.Create(openInBrowser);
        ExampleTablerLogs.Create(openInBrowser);

        // Forms examples
        ExampleTablerForm.Create(openInBrowser);
        ExampleComprehensiveForm.Create(openInBrowser);

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

        // Enhanced Accordion & Steps showcase
        EnhancedAccordionStepsShowcase.Demo01(openInBrowser);  // 🎛️ ENHANCED ACCORDION & STEPS DEMO

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

        // Link encoding demonstration
        ExampleLinkEncodingEmail.Create(openInBrowser);

        // Base64 embedding examples (if they exist)
        ExampleBase64EmbeddingEmail.Create(openInBrowser);

        // Decimal margin demonstration
        ExampleDecimalMarginEmail.Create(openInBrowser);

        // Layout configuration demonstration - NEW enum-based configuration system!
        ExampleLayoutConfigurationDemo.Create(openInBrowser);

        // ChartJs examples
        BasicChartJs.Demo(openInBrowser);
        BasicApexCharts.Demo(openInBrowser);
        ApexChartsComprehensive.Demo(openInBrowser);

        // VisNetwork images demo
        BasicVisNetwork.Demo(true);
        AdvancedVisNetwork.Demo(true);
        VisNetworkPhysicsExamples.Demo(true);
        VisNetworkLayoutExamples.Demo(true);
        VisNetworkNodeStylingExamples.Demo(true);
        VisNetworkEdgeManipulationExamples.Demo(true);
        VisNetworkInteractionExamples.Demo(true);
        VisNetworkImprovementsDemo.Create(true);
        VisNetworkMultiLineLabelDemo.Create(true);
        VisNetworkGradientEdgesDemo.Create(true);
        VisNetworkEventsDemo.Create(true);
        VisNetworkClusteringDemo.Create(true);
        VisNetworkMethodsDemo.Create(true);
        VisNetworkExportImportDemo.Create(true);
        VisNetworkCustomShapesDemo.Create(true);
        VisNetworkAdvancedFeaturesDemo.Create(true);

        // VisNetwork HTML Nodes example (with visjs-html-nodes plugin)
        VisNetworkExamples.VisNetworkHtmlNodesExample.Run(true);

        // VisNetwork Advanced Labels example (HTML tooltips, \n line breaks, markdown)
        VisNetworkAdvancedLabelsExample.Run(true);

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