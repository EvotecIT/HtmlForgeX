using HtmlForgeX;

namespace HtmlForgeX.Examples;

/// <summary>
/// Debug test for PrismJS functionality
/// </summary>
public class TestPrismJsDebug
{
    public static void RunDebugTest(bool openInBrowser = false)
    {
        Console.WriteLine("=== PrismJS Debug Test ===");

        var document = new Document
        {
            Head = {
                Title = "PrismJS Debug Test"
            }
        };

        document.Body.Page(page =>
        {
            page.Layout = TablerLayout.Fluid;

            // Test 1: Direct page-level PrismJS (this should work)
            page.Text("Test 1: Direct page-level PrismJS");
            page.CSharpCode(@"
// Direct page test
console.log('Hello World');", config => config
                .EnableLineNumbers()
                .EnableCopyButton()
                .GitHubTheme());

            // Test 2: Card body PrismJS (this is failing)
            page.Text("Test 2: Card body PrismJS");
            page.Row(row =>
            {
                row.Column(TablerColumnNumber.Twelve, column =>
                {
                    column.Card(card =>
                    {
                        card.Header(header =>
                        {
                            header.Title("Card Test");
                        });
                        card.Body(body =>
                        {
                            body.CSharpCode(@"
// Card body test
console.log('Card Test');", config => config
                                .EnableLineNumbers()
                                .EnableCopyButton()
                                .VsTheme());
                        });
                    });
                });
            });
        });

        // Check what libraries were registered
        Console.WriteLine("=== Registered Libraries ===");
        foreach (var lib in document.Configuration.Libraries)
        {
            Console.WriteLine($"Library: {lib.Key} (Order: {lib.Value})");
        }

        document.Save("PrismJsDebugTest.html", openInBrowser);
        Console.WriteLine("Debug test saved to PrismJsDebugTest.html");
    }
}