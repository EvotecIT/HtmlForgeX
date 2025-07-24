using HtmlForgeX;
namespace HtmlForgeX.Examples.ByHand;

internal static class DocumentAnalyticsExample {
    public static void Create(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("Analytics Example");

        using var document = new Document();
        document.Head.AddTitle("DocumentAnalyticsExample");
        document.Head.AddAnalytics(AnalyticsProvider.GoogleAnalytics, "G-XXXXXXX");

        document.Body.Span("Hello Analytics!");

        document.Save("DocumentAnalyticsExample.html", openInBrowser);
    }
}