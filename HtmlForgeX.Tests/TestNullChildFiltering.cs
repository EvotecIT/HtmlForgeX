using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestNullChildFiltering {
    [TestMethod]
    public void DocumentToString_IgnoresNullChildren() {
        var document = new Document();
        document.Body.Children.Add(null);
        document.Body.Children.Add(new Span().AddContent("Test"));

        var html = document.ToString();

        Assert.IsTrue(html.Contains("Test"));
    }

    [TestMethod]
    public void SpanToString_IgnoresNullChildren() {
        var span = new Span();
        span.Children.Add(null);
        span.Children.Add(new Span { Content = "Inner" });

        var html = span.ToString();

        Assert.IsTrue(html.Contains("Inner"));
    }
}
