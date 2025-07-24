using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestAddFontLink {
    [TestMethod]
    public void AddFontLink_DeduplicatesAndRendersCorrectly() {
        var doc = new Document();
        const string url = "https://fonts.googleapis.com/css2?family=Open+Sans";
        doc.Head.AddFontLink(url);
        doc.Head.AddFontLink(url); // duplicate

        var html = doc.Head.ToString();
        var count = CountOccurrences(html, url);
        Assert.AreEqual(1, count);
        StringAssert.Contains(html, url);
    }

    [TestMethod]
    public void AddFontLink_AllowsMultipleUrls() {
        var doc = new Document();
        const string url1 = "https://fonts.example.com/a.css";
        const string url2 = "https://fonts.example.com/b.css";
        doc.Head.AddFontLink(url1);
        doc.Head.AddFontLink(url2);

        var html = doc.Head.ToString();
        StringAssert.Contains(html, url1);
        StringAssert.Contains(html, url2);
    }

    [TestMethod]
    public void SetBodyFontFamily_AddsCssOnce() {
        var doc = new Document();
        const string expected = "Roboto, sans-serif";
        doc.Head.SetBodyFontFamily("Roboto", "sans-serif");
        doc.Head.SetBodyFontFamily("Roboto", "sans-serif"); // duplicate

        var html = doc.Head.ToString();
        var count = CountOccurrences(html, expected);
        Assert.AreEqual(1, count);
        StringAssert.Contains(html, expected);
    }

    [TestMethod]
    public void SetBodyFontFamily_QuotesFontsWithSpaces() {
        var doc = new Document();
        doc.Head.SetBodyFontFamily("Open Sans", "Arial", "sans-serif");

        var html = doc.Head.ToString();
        StringAssert.Contains(html, "'Open Sans', Arial, sans-serif");
    }

    [TestMethod]
    public void SetBodyFontFamily_SanitizesQuotedFonts() {
        var doc = new Document();
        doc.Head.SetBodyFontFamily("'Open Sans'", "Arial", "sans-serif");

        var html = doc.Head.ToString();
        StringAssert.Contains(html, "'Open Sans', Arial, sans-serif");
    }

    [TestMethod]
    public void SetBodyFontFamily_MultipleFonts() {
        var doc = new Document();
        doc.Head.SetBodyFontFamily("Lobster", "cursive");

        var html = doc.Head.ToString();
        StringAssert.Contains(html, "font-family: Lobster, cursive;");
    }

    [TestMethod]
    public void SetBodyFontFamily_IgnoresEmptyValues() {
        var doc = new Document();
        doc.Head.SetBodyFontFamily("Roboto", string.Empty, "  ", null!, "sans-serif");

        var html = doc.Head.ToString();
        StringAssert.Contains(html, "font-family: Roboto, sans-serif;");
    }

    private static int CountOccurrences(string text, string pattern) {
        int count = 0;
        int index = 0;
        while ((index = text.IndexOf(pattern, index, System.StringComparison.Ordinal)) != -1) {
            count++;
            index += pattern.Length;
        }
        return count;
    }
}