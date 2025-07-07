using HtmlForgeX;
using HtmlForgeX.Examples;
using HtmlForgeX.Examples.ByHand;
using HtmlForgeX.Examples.Containers;
using HtmlForgeX.Examples.Experimenting;
using HtmlForgeX.Examples.Support;
using HtmlForgeX.Examples.Tables;
using HtmlForgeX.Examples.Tags;
using HtmlForgeX.Examples.Emails;

// Those are support examples that help with maintaining library, not a demo material
// Support.DownloadLibraries();
// Support.GenerateTableIcons();

// NOTE: Email layout consistency is now managed through EmailLayout static class
// You can customize spacing globally by setting EmailLayout.ContainerPadding,
// EmailLayout.TableCellPaddingVertical, etc. before generating emails.

// Those are to display examples in console
// BasicHtmlTagBuilding.Demo1();
// BasicHtmlTagBuilding.Demo2();
// BasicHtmlTagBuilding.Demo3();
// BasicHtmlTagBuilding.Demo4();
// BasicHtmlTagBuilding.Demo5();
// BasicHtmlTagBuilding.Demo6();
// ExampleTablerIcon.Demo();
// ExampleSvgIcons.Demo();

// ExampleTablerTag.Demo();
// ExampleTablerAlerts.Demo();
// BasicHtmlBuilding.Demo1(true);
// BasicHtmlContainer01.Demo(true);
// BasicHtmlContainer02.Demo(true);
// BasicHtmlContainer03.Demo(true);
// BasicHtmlContainer04.Demo(true);
// BasicHtmlContainer05.Demo(true);
// BasicHtmlContainer06.Demo(true);
// DomainHealthCheck.Demo(true);
// BasicHtmlTable01.Demo(true);

// Email Examples - Generate all email examples
ExampleCorrectedEmailPattern.Create(true);
ExampleDirectEmailPattern.Create(true);
ExampleInvoiceEmail.Create(true);
ExampleLayoutEmailPattern.Create(true);
ExampleNewsletterEmail.Create(true);
ExampleOrderConfirmationEmail.Create(true);
ExamplePasswordResetEmail.Create(true);
ExampleSimpleConfirmationEmail.Create(true);
ExampleWelcomeEmail.Create(true);