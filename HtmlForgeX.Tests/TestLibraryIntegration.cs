using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestLibraryIntegration {
    [TestMethod]
    public void DocumentIncludesCustomLibraryLinks() {
        var customLibrary = new Library {
            Header = new LibraryLinks {
                CssLink = ["https://example.com/style.css"],
                JsLink = ["https://example.com/script.js"]
            }
        };

        using var doc = new Document();
        doc.LibraryMode = LibraryMode.Online;
        var added = doc.AddLibrary(customLibrary);
        var html = doc.ToString();

        Assert.IsTrue(added);

        StringAssert.Contains(html, "<link rel=\"stylesheet\" href=\"https://example.com/style.css\">");
        StringAssert.Contains(html, "<script src=\"https://example.com/script.js\"></script>");
    }
}