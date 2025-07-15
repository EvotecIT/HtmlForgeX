using HtmlForgeX;

class TestPrismJsLibraryRegistration
{
    static void Main()
    {
        // Test 1: Check if PrismJS registers when added to page directly
        Console.WriteLine("=== Test 1: Page-level PrismJS ===");
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
        
        // Test 2: Check if PrismJS registers when added in card body
        Console.WriteLine("\n=== Test 2: Card body PrismJS ===");
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
        Console.WriteLine($"HTML contains PrismJS CSS: {html2.Contains("prism")}");
        
        // Test 3: Check what's actually in the head
        Console.WriteLine("\n=== Test 3: Head content analysis ===");
        var headStart = html2.IndexOf("<head>");
        var headEnd = html2.IndexOf("</head>", headStart);
        if (headStart >= 0 && headEnd >= 0)
        {
            var headContent = html2.Substring(headStart, headEnd - headStart + 7);
            Console.WriteLine("Head content:");
            Console.WriteLine(headContent);
            Console.WriteLine($"Head contains prism: {headContent.Contains("prism")}");
        }
        
        // Save both files for comparison
        document1.Save("test1_page_level.html", false);
        document2.Save("test2_card_body.html", false);
        
        Console.WriteLine("\nFiles saved: test1_page_level.html, test2_card_body.html");
    }
}