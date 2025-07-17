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
        var result = doc.Head.AddAnalytics(AnalyticsProvider.GoogleAnalytics, "G-TEST");
        Assert.IsTrue(result);
        var html = doc.Head.ToString();
        StringAssert.Contains(html, "googletagmanager.com/gtag/js?id=G-TEST");
        StringAssert.Contains(html, "gtag('config', 'G-TEST');");
    }

    [TestMethod]
    public void AddAnalytics_Cloudflare_ShouldIncludeScript()
    {
        using var doc = new Document();
        var result = doc.Head.AddAnalytics(AnalyticsProvider.CloudflareInsights, "token-123");
        Assert.IsTrue(result);
        var html = doc.Head.ToString();
        StringAssert.Contains(html, "static.cloudflareinsights.com/beacon.min.js");
        StringAssert.Contains(html, "token-123");
    }

    [TestMethod]
    public void AddAnalytics_Google_ShouldEncodeSpecialCharacters()
    {
        var doc = new Document();
        var result = doc.Head.AddAnalytics(AnalyticsProvider.GoogleAnalytics, "G-\"A&B<C>'");
        Assert.IsTrue(result);
        var html = doc.Head.ToString();
        StringAssert.Contains(html, "googletagmanager.com/gtag/js?id=G-%22A%26B%3CC%3E%27");
        StringAssert.Contains(html, "gtag('config', 'G-%22A%26B%3CC%3E%27');");
    }

    [TestMethod]
    public void AddAnalytics_Cloudflare_ShouldEncodeSpecialCharacters()
    {
        var doc = new Document();
        var result = doc.Head.AddAnalytics(AnalyticsProvider.CloudflareInsights, "tok'en\"<>");
        Assert.IsTrue(result);
        var html = doc.Head.ToString();
        StringAssert.Contains(html, "tok%27en%22%3C%3E");
    }

    [TestMethod]
    public void AddAnalytics_InvalidProvider_ShouldThrow()
    {
        using var doc = new Document();
        var result = doc.Head.AddAnalytics((AnalyticsProvider)int.MaxValue, "id");
        Assert.IsFalse(result);
    }
}
