using HtmlForgeX.Examples;

namespace HtmlForgeX.Examples.ByHand;

internal class GoogleFontExample {
    public static void Create(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("Google Font Example");

        var document = new Document();
        document.Head.AddTitle("Google Font Example");
        document.Head.AddFontLink("https://fonts.googleapis.com/css2?family=Roboto&display=swap");
        document.Head.AddFontLink("https://fonts.googleapis.com/css2?family=Lobster&display=swap");
        document.Head.AddFontLink("https://fonts.googleapis.com/css2?family=Open+Sans&display=swap");
        document.Head.SetBodyFontFamily("Roboto", "'Open Sans'", "Lobster", "sans-serif");

        document.Body.Span("Hello with Google Font!");
        document.Body.Span("Fallback to Lobster if Roboto missing")
            .WithFontFamily("Lobster, cursive");

        document.Save("GoogleFontExample.html", openInBrowser);
    }
}