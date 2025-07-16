using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

/// <summary>
/// Tests adding analytics scripts to the document head.
/// </summary>
[TestClass]
public class TestHeadAnalytics
{
    [TestMethod]
    public void AddAnalytics_Google_ShouldIncludeScript()
    {
        using var doc = new Document();
        doc.Head.AddAnalytics(AnalyticsProvider.GoogleAnalytics, "G-TEST");
        var html = doc.Head.ToString();
        StringAssert.Contains(html, "googletagmanager.com/gtag/js?id=G-TEST");
        StringAssert.Contains(html, "gtag('config', 'G-TEST');");
    }

    [TestMethod]
    public void AddAnalytics_Cloudflare_ShouldIncludeScript()
    {
        using var doc = new Document();
        doc.Head.AddAnalytics(AnalyticsProvider.CloudflareInsights, "token-123");
        var html = doc.Head.ToString();
        StringAssert.Contains(html, "static.cloudflareinsights.com/beacon.min.js");
        StringAssert.Contains(html, "token-123");
    }

    [TestMethod]
    public void AddAnalytics_Google_ShouldEncodeSpecialCharacters()
    {
        var doc = new Document();
        doc.Head.AddAnalytics(AnalyticsProvider.GoogleAnalytics, "G-\"A&B<C>'");
        var html = doc.Head.ToString();
        StringAssert.Contains(html, "googletagmanager.com/gtag/js?id=G-&quot;A&amp;B&lt;C&gt;&#39;");
        StringAssert.Contains(html, "gtag('config', 'G-&quot;A&amp;B&lt;C&gt;&#39;');");
    }

    [TestMethod]
    public void AddAnalytics_Cloudflare_ShouldEncodeSpecialCharacters()
    {
        var doc = new Document();
        doc.Head.AddAnalytics(AnalyticsProvider.CloudflareInsights, "tok'en\"<>");
        var html = doc.Head.ToString();
        StringAssert.Contains(html, "tok&#39;en&quot;&lt;&gt;");
    }
}
