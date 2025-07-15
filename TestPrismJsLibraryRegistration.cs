using HtmlForgeX;

class TestPrismJsLibraryRegistration
{
    static void Main()
    {
        Console.WriteLine("=== Testing PrismJS Library Registration Fix ===");
        Console.WriteLine();

        // Test 1: Check if PrismJS registers when added to page directly
        Console.WriteLine("=== Test 1: Page-level PrismJS (should work) ===");
        var document1 = new Document();
        document1.Body.Page(page =>
        {
            page.CSharpCode("var x = 42;", config => config.GitHubTheme());
        });

        // Check libraries before ToString()
        Console.WriteLine($"Libraries before ToString(): {document1.Configuration.Libraries.Count}");
        foreach (var lib in document1.Configuration.Libraries.Keys)
        {
            Console.WriteLine($"  - {lib}");
        }

        var html1 = document1.ToString();
        Console.WriteLine($"Libraries after ToString(): {document1.Configuration.Libraries.Count}");
        Console.WriteLine($"HTML contains PrismJS CSS: {html1.Contains("prism")}");

        // Verify specific libraries are registered
        bool hasBasePrismJs = document1.Configuration.Libraries.ContainsKey(Libraries.PrismJs);
        bool hasGitHubTheme = document1.Configuration.Libraries.ContainsKey(Libraries.PrismJsGitHubTheme);
        Console.WriteLine($"✅ Base PrismJS registered: {hasBasePrismJs}");
        Console.WriteLine($"✅ GitHub theme registered: {hasGitHubTheme}");

        // Test 2: Check if PrismJS registers when added in card body (THE FIX TEST)
        Console.WriteLine("\n=== Test 2: Card body PrismJS (THE FIX TEST) ===");
        var document2 = new Document();
        document2.Body.Page(page =>
        {
            page.Card(card =>
            {
                card.Body(body =>
                {
                    body.CSharpCode("var x = 42;", config => config.GitHubTheme());
                });
            });
        });

        // Check libraries before ToString()
        Console.WriteLine($"Libraries before ToString(): {document2.Configuration.Libraries.Count}");
        foreach (var lib in document2.Configuration.Libraries.Keys)
        {
            Console.WriteLine($"  - {lib}");
        }

        var html2 = document2.ToString();
        Console.WriteLine($"Libraries after ToString(): {document2.Configuration.Libraries.Count}");
        foreach (var lib in document2.Configuration.Libraries.Keys)
        {
            Console.WriteLine($"  - {lib}");
        }
        Console.WriteLine($"HTML contains PrismJS CSS: {html2.Contains("prism")}");

        // Verify specific libraries are registered (THIS SHOULD NOW WORK!)
        bool hasBasePrismJs2 = document2.Configuration.Libraries.ContainsKey(Libraries.PrismJs);
        bool hasGitHubTheme2 = document2.Configuration.Libraries.ContainsKey(Libraries.PrismJsGitHubTheme);
        Console.WriteLine($"✅ Base PrismJS registered: {hasBasePrismJs2}");
        Console.WriteLine($"✅ GitHub theme registered: {hasGitHubTheme2}");

        // Test 3: Advanced test - nested card with multiple PrismJS blocks
        Console.WriteLine("\n=== Test 3: Multiple PrismJS blocks in nested structure ===");
        var document3 = new Document();
        document3.Body.Page(page =>
        {
            page.Row(row =>
            {
                row.Column(TablerColumnNumber.Six, col =>
                {
                    col.Card(card =>
                    {
                        card.Header(header =>
                        {
                            header.Title("Code Examples");
                        });
                        card.Body(body =>
                        {
                            body.CSharpCode("var hello = \"Hello World\";", config => config.GitHubTheme().EnableLineNumbers());
                            body.JavaScriptCode("console.log('Hello World');", config => config.VsTheme().EnableCopyButton());
                        });
                    });
                });
                row.Column(TablerColumnNumber.Six, col =>
                {
                    col.Card(card =>
                    {
                        card.Body(body =>
                        {
                            body.SqlCode("SELECT * FROM users;", config => config.OkaidiaTheme());
                        });
                    });
                });
            });
        });

        var html3 = document3.ToString();
        Console.WriteLine($"Libraries registered: {document3.Configuration.Libraries.Count}");
        foreach (var lib in document3.Configuration.Libraries.Keys)
        {
            Console.WriteLine($"  - {lib}");
        }

        // Check for multiple themes
        bool hasVsTheme = document3.Configuration.Libraries.ContainsKey(Libraries.PrismJsVsTheme);
        bool hasOkaidiaTheme = document3.Configuration.Libraries.ContainsKey(Libraries.PrismJsOkaidiaTheme);
        Console.WriteLine($"✅ VS theme registered: {hasVsTheme}");
        Console.WriteLine($"✅ Okaidia theme registered: {hasOkaidiaTheme}");

        // Test 4: Save files to verify HTML output
        Console.WriteLine("\n=== Test 4: Saving HTML files for inspection ===");
        document1.Save("test_page_level_prismjs.html", false);
        document2.Save("test_card_body_prismjs.html", false);
        document3.Save("test_multiple_prismjs.html", false);
        Console.WriteLine("✅ HTML files saved for manual inspection");

        // Summary
        Console.WriteLine("\n=== SUMMARY ===");
        if (hasBasePrismJs2 && hasGitHubTheme2)
        {
            Console.WriteLine("🎉 SUCCESS: PrismJS library registration fix is working!");
            Console.WriteLine("   Libraries are now properly registered in card.Body contexts.");
        }
        else
        {
            Console.WriteLine("❌ FAILURE: PrismJS library registration is still broken.");
            Console.WriteLine("   The fix needs more work.");
        }
    }
}