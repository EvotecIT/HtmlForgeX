using HtmlForgeX;

class TestPrismJsSimple
{
    static void Main()
    {
        var document = new Document
        {
            Head = { Title = "PrismJS Test" }
        };

        document.Body.Page(page =>
        {
            page.Layout = TablerLayout.Fluid;

            // Test 1: Direct PrismJsCodeBlock creation
            var codeBlock = new PrismJsCodeBlock("console.log('Hello World');", PrismJsLanguage.JavaScript);
            codeBlock.EnableLineNumbers().EnableCopyButton().GitHubTheme();
            page.Add(codeBlock);

            // Test 2: Extension method
            page.CSharpCode("var x = 42;", config => config.EnableLineNumbers().GitHubTheme());
        });

        document.Save("test_prismjs_simple.html", false);

        // Check if PrismJS library was registered
        var hasLibrary = document.Configuration.Libraries.ContainsKey(Libraries.PrismJs);
        Console.WriteLine($"PrismJS library registered: {hasLibrary}");

        // Read the generated HTML to check for PrismJS references
        var html = System.IO.File.ReadAllText("test_prismjs_simple.html");
        var hasPrismCss = html.Contains("prism");
        Console.WriteLine($"HTML contains PrismJS references: {hasPrismCss}");
    }
}