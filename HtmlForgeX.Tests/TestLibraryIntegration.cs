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

        GlobalStorage.LibraryMode = LibraryMode.Online;
        var doc = new Document();
        doc.AddLibrary(customLibrary);
        var html = doc.ToString();

        StringAssert.Contains(html, "<link rel=\"stylesheet\" href=\"https://example.com/style.css\">");
        StringAssert.Contains(html, "<script src=\"https://example.com/script.js\"></script>");
    }
}