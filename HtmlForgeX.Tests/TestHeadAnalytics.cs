using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestHeadAnalytics
{
    [TestMethod]
    public void AddAnalytics_Google_ShouldIncludeScript()
    {
        var doc = new Document();
        doc.Head.AddAnalytics(AnalyticsProvider.GoogleAnalytics, "G-TEST");
        var html = doc.Head.ToString();
        StringAssert.Contains(html, "googletagmanager.com/gtag/js?id=G-TEST");
        StringAssert.Contains(html, "gtag('config', 'G-TEST');");
    }

    [TestMethod]
    public void AddAnalytics_Cloudflare_ShouldIncludeScript()
    {
        var doc = new Document();
        doc.Head.AddAnalytics(AnalyticsProvider.CloudflareInsights, "token-123");
        var html = doc.Head.ToString();
        StringAssert.Contains(html, "static.cloudflareinsights.com/beacon.min.js");
        StringAssert.Contains(html, "token-123");
    }
}
