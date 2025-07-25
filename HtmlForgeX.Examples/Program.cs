using System;
using System.Text;

using HtmlForgeX.Examples.ByHand;
using HtmlForgeX.Examples.Charts;
using HtmlForgeX.Examples.Containers;
using HtmlForgeX.Examples.Emails;
using HtmlForgeX.Examples.Experimenting;
using HtmlForgeX.Examples.Forms;
using HtmlForgeX.Examples.Icons;
using HtmlForgeX.Examples.Support;
using HtmlForgeX.Examples.Tabler;
using HtmlForgeX.Examples.Tables;
using HtmlForgeX.Examples.Tags;
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

        // Console output examples (alphabetical)
        HtmlTagDivExample.Create();
        HtmlTagFormExample.Create();
        HtmlTagSpanExample.Create();
        TablerColorHex.Create();
        TablerIconDemo.Create();
        TablerSvgIcons.Create();

        // HTML output examples (alphabetical)
        AccordionStepsShowcase.Create(openInBrowser);  // 🎛️ ACCORDION & STEPS SHOWCASE
        ChartJsBasicDemo.Create(openInBrowser);
        ChartsApexBasicDemo.Create(openInBrowser);
        ChartsApexComprehensiveDemo.Create(openInBrowser);
        ComponentHtmlContainer01.Create(openInBrowser);
        ComponentHtmlContainer02.Create(openInBrowser);
        ComponentHtmlContainer03.Create(openInBrowser);
        ComponentHtmlContainer04.Create(openInBrowser);
        ComponentQuillEditor.Create(openInBrowser);
        ComponentScrollingText.Create(openInBrowser);
        DataGridShowcase.Create(openInBrowser);
        DataTablesAdvancedDemo.Create(openInBrowser);
        DataTablesExtensionsDemo.Create(openInBrowser);
        DataTablesInteractiveFilteringDemo.Create(openInBrowser);
        DataTablesOptionsExample.Create(openInBrowser);
        DataTablesQuickStart.Create(openInBrowser);
        DataTablesRenderingDemo.Create(openInBrowser);
        DataTablesTypedObjectsExample.Create(openInBrowser);
        DocumentAnalyticsExample.Create(openInBrowser);
        DocumentAnalyticsSpecialCharsExample.Create(openInBrowser);
        DocumentBootstrapExample.Create(openInBrowser);
        DocumentSanitizedRawHtmlExample.Create(openInBrowser);
        DocumentSpanStylesExample.Create(openInBrowser);
        DomainHealthCheck.Create(openInBrowser);
        EmailAccountVerification.Create(openInBrowser);
        EmailBase64Embedding.Create(openInBrowser);
        EmailCorrectedPattern.Create(openInBrowser);
        EmailDarkMode.Create(openInBrowser);  // 🌙 DARK MODE DEMO
        EmailDecimalMargin.Create(openInBrowser);
        EmailDirectHeaderFooter.Create(openInBrowser);  // 🚀 DIRECT PATTERN DEMO
        EmailDirectPattern.Create(openInBrowser);
        EmailEnhancedDarkMode.Create(openInBrowser);  // 🚀 ENHANCED DARK MODE DEMO
        EmailFlexibleHeaderFooter.Create(openInBrowser);  // 🎯 FLEXIBLE PATTERN DEMO
        EmailImprovedConsistency.Create(openInBrowser);
        EmailInvoice.Create(openInBrowser);
        EmailLayoutConfigurationDemo.Create(openInBrowser);
        EmailLayoutPattern.Create(openInBrowser);
        EmailLinkEncoding.Create(openInBrowser);
        EmailNewsletter.Create(openInBrowser);
        EmailOrderConfirmation.Create(openInBrowser);
        EmailPasswordReset.Create(openInBrowser);
        EmailSimpleConfirmation.Create(openInBrowser);
        EmailTextWrappingDemo.Create(openInBrowser);
        EmailWelcome.Create(openInBrowser);
        ExampleComprehensiveForm.Create(openInBrowser);
        ExampleFontAwesomeOnline.Create(openInBrowser);
        GoogleFontExample.Create(openInBrowser);
        HtmlTableDocumentExample.Create(openInBrowser);
        InfocardsDemo.Create(openInBrowser);
        InfocardsRgbDemo.Create(openInBrowser);
        MultiPageDemo.Create(openInBrowser);            // 🌐 MULTI-PAGE SITE DEMO
        MultiPageParallelGeneration.Create(openInBrowser);      // ⚡ MULTI-PAGE PARALLEL GENERATION
        MultiPagePerformanceBenchmark.Create(openInBrowser);    // 📊 MULTI-PAGE PERFORMANCE BENCHMARK
        NavigationDemo.Create(openInBrowser);           // 🧭 NAVIGATION DEMO - Single Page
        NavigationStandaloneDemo.Create(openInBrowser); // 🧭 NAVIGATION DEMO - Standalone Examples
        NavigationVerticalDemo.Create(openInBrowser);   // 🧭 NAVIGATION DEMO - Vertical Layout
        SmartTabDemo.Create(openInBrowser);
        SmartTabWizardFullDemo.Create(openInBrowser);
        SmartTabWizardInteroperabilityDemo.Create(openInBrowser);
        SmartTabWizardIntroDemo.Create(openInBrowser);
        SmartWizardDemo.Create(openInBrowser);
        TablerAlerts.Create(openInBrowser);
        // Tabler cards examples
        TablerCardsApiDemo.Create(openInBrowser);
        TablerCardsExtendedDemo.Create(openInBrowser);
        TablerCardsShowcase.Create(openInBrowser);
        TablerDashboardDemo.Create(openInBrowser);
        
        // Tabler components examples
        TablerButtonShowcase.Create(openInBrowser);
        TablerDashboardWithSidebarDemo.Create(openInBrowser);
        TablerFormDemo.Create(openInBrowser);
        TablerFormInputs.Create(openInBrowser);
        TablerLogsDemo.Create(openInBrowser);
        TablerProgressBarShowcase.Create(openInBrowser);
        TablerStarRatingDemo.Create(openInBrowser);
        TablerTableStylingExample.Create(openInBrowser);
        TablerTagDemo.Create(openInBrowser);
        TablerTimelineDemo.Create(openInBrowser);
        TablerToastAdvanced.Create(openInBrowser);
        TablerToastDemo.Create(openInBrowser);
        TablerToastOptions.Create(openInBrowser);
        VisNetworkAdvancedDemo.Create(openInBrowser);
        VisNetworkAdvancedFeaturesDemo.Create(openInBrowser);
        VisNetworkAdvancedLabelsExample.Run(openInBrowser);
        VisNetworkBasicDemo.Create(openInBrowser);
        VisNetworkClusteringDemo.Create(openInBrowser);
        VisNetworkCustomShapesDemo.Create(openInBrowser);
        VisNetworkEdgeManipulationExamples.Create(openInBrowser);
        VisNetworkEventsDemo.Create(openInBrowser);
        VisNetworkExamples.VisNetworkHtmlNodesExample.Run(openInBrowser);
        VisNetworkExportImportDemo.Create(openInBrowser);
        VisNetworkGradientEdgesDemo.Create(openInBrowser);
        VisNetworkImprovementsDemo.Create(openInBrowser);
        VisNetworkInteractionExamples.Create(openInBrowser);
        VisNetworkLayoutExamples.Create(openInBrowser);
        VisNetworkMethodsDemo.Create(openInBrowser);
        VisNetworkMultiLineLabelDemo.Create(openInBrowser);
        VisNetworkNodeStylingExamples.Create(openInBrowser);
        VisNetworkPhysicsExamples.Create(openInBrowser);
    }
}