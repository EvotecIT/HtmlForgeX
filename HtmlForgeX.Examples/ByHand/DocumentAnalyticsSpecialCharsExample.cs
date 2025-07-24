using HtmlForgeX;
namespace HtmlForgeX.Examples.ByHand;

internal static class DocumentAnalyticsSpecialCharsExample {
    public static void Create(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("Analytics Special Characters Example");

        var document = new Document();
        document.Head.AddTitle("DocumentAnalyticsSpecialCharsExample");
        document.Head.AddAnalytics(AnalyticsProvider.GoogleAnalytics, "G-\"A&B<C>'");

        document.Body.Span("Hello Analytics Special Characters!");

        document.Save("DocumentAnalyticsSpecialCharsExample.html", openInBrowser);
    }
}
