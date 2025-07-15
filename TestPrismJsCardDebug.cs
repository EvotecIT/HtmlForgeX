using HtmlForgeX;

class TestPrismJsCardDebug
{
    static void Main()
    {
        Console.WriteLine("=== PrismJS Card Debug Test ===");

        var document = new Document
        {
            Head = { Title = "PrismJS Card Debug" }
        };

        Console.WriteLine($"Document created. Libraries: {document.Configuration.Libraries.Count}");

        document.Body.Page(page =>
        {
            Console.WriteLine($"Page created. Document ref: {page.Document != null}");

            page.Card(card =>
            {
                Console.WriteLine($"Card created. Document ref: {card.Document != null}");

                card.Body(body =>
                {
                    Console.WriteLine($"Card body created. Document ref: {body.Document != null}");
                    Console.WriteLine($"Libraries before adding PrismJS: {document.Configuration.Libraries.Count}");

                    body.CSharpCode("var x = 42;", config => config.GitHubTheme());

                    Console.WriteLine($"Libraries after adding PrismJS: {document.Configuration.Libraries.Count}");
                    Console.WriteLine("Added PrismJS to card body");
                });
            });
        });

        Console.WriteLine($"Before ToString() - Libraries: {document.Configuration.Libraries.Count}");
        foreach (var lib in document.Configuration.Libraries.Keys)
        {
            Console.WriteLine($"  - {lib}");
        }

        var html = document.ToString();

        Console.WriteLine($"After ToString() - Libraries: {document.Configuration.Libraries.Count}");
        foreach (var lib in document.Configuration.Libraries.Keys)
        {
            Console.WriteLine($"  - {lib}");
        }

        // Check if PrismJS CSS is in the HTML
        var hasPrismCss = html.Contains("prism");
        Console.WriteLine($"HTML contains PrismJS: {hasPrismCss}");

        // Save the file
        System.IO.File.WriteAllText("TestPrismJsCardDebug.html", html);
        Console.WriteLine("Saved TestPrismJsCardDebug.html");
    }
}