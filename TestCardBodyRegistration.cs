using HtmlForgeX;

class TestCardBodyRegistration
{
    static void Main()
    {
        Console.WriteLine("=== Testing Card Body Registration ===");
        
        var document = new Document();
        
        // Create a card with PrismJS in the body
        document.Body.Page(page =>
        {
            page.Layout = TablerLayout.Fluid;
            
            page.Card(card =>
            {
                card.Body(body =>
                {
                    Console.WriteLine("About to add CSharpCode to card body...");
                    Console.WriteLine($"Document reference in body: {body.Document != null}");
                    
                    body.CSharpCode("var x = 42;", config => config.GitHubTheme());
                    
                    Console.WriteLine($"Document reference in codeBlock: {codeBlock.Document != null}");
                    Console.WriteLine($"Libraries before RegisterLibraries: {document.Configuration.Libraries.Count}");
                    
                    // Manually call RegisterLibraries to see what happens
                    codeBlock.RegisterLibraries();
                    
                    Console.WriteLine($"Libraries after RegisterLibraries: {document.Configuration.Libraries.Count}");
                    foreach (var lib in document.Configuration.Libraries.Keys)
                    {
                        Console.WriteLine($"  - {lib}");
                    }
                });
            });
        });
        
        Console.WriteLine($"Final libraries count: {document.Configuration.Libraries.Count}");
        
        // Generate HTML to see what happens
        var html = document.ToString();
        Console.WriteLine($"HTML contains PrismJS CSS: {html.Contains("prism")}");
        
        // Check head section
        var headStart = html.IndexOf("<head>");
        var headEnd = html.IndexOf("</head>", headStart);
        if (headStart >= 0 && headEnd >= 0)
        {
            var headContent = html.Substring(headStart, headEnd - headStart + 7);
            Console.WriteLine($"\nHead contains prism: {headContent.Contains("prism")}");
            if (headContent.Contains("prism"))
            {
                Console.WriteLine("PrismJS links found in head!");
            }
            else
            {
                Console.WriteLine("No PrismJS links in head - this is the problem!");
            }
        }
        
        document.Save("test_card_body_registration.html", false);
    }
}