using HtmlForgeX;
namespace HtmlForgeX.Examples.ByHand;

internal static class DocumentSanitizedRawHtmlExample {
    public static void Create(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("Sanitized RawHtml Example");

        var document = new Document();
        document.Head.AddTitle("DocumentSanitizedRawHtmlExample");

        var div = new HtmlTag("div")
            .ValueRaw("<script>alert('x')</script><span>Safe</span>", true);

        document.Body.Add(div);

        document.Save("DocumentSanitizedRawHtmlExample.html", openInBrowser);
    }
}