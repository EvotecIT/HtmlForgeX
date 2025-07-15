using HtmlForgeX;

class TestLibraryRegistration
{
    static void Main()
    {
        var document = new Document();
        
        // Create a PrismJS code block with card context
        document.Body.Page(page =>
        {
            page.Layout = TablerLayout.Fluid;
            
            page.Card(card =>
            {
                card.Header(header =>
                {
                    header.Title("PrismJS Test");
                });
                
                card.Body(body =>
                {
                    body.CSharpCode(@"
var x = 42;
console.log(x);", config => config
                        .EnableLineNumbers()
                        .EnableCopyButton()
                        .GitHubTheme());
                });
            });
        });
        
        // Check libraries before ToString()
        Console.WriteLine($"Libraries before ToString(): {document.Configuration.Libraries.Count}");
        foreach (var lib in document.Configuration.Libraries.Keys)
        {
            Console.WriteLine($"  - {lib}");
        }
        
        // Generate HTML
        var html = document.ToString();
        
        // Check libraries after ToString()
        Console.WriteLine($"Libraries after ToString(): {document.Configuration.Libraries.Count}");
        foreach (var lib in document.Configuration.Libraries.Keys)
        {
            Console.WriteLine($"  - {lib}");
        }
        
        // Check if PrismJS CSS is in the HTML
        var hasPrismCss = html.Contains("prism");
        Console.WriteLine($"HTML contains PrismJS references: {hasPrismCss}");
        
        // Save the file
        document.Save("test_library_registration.html", false);
        
        // Read and check the head section
        var lines = html.Split('\n');
        Console.WriteLine("\n=== HEAD SECTION ===");
        bool inHead = false;
        foreach (var line in lines)
        {
            if (line.Contains("<head>")) inHead = true;
            if (inHead) Console.WriteLine(line);
            if (line.Contains("</head>")) break;
        }
    }
}