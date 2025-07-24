using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestLibraryPathFormatting {
    [TestMethod]
    public void OfflineWithFiles_ForwardsSlashInLinks() {
        using var doc = new Document { LibraryMode = LibraryMode.OfflineWithFiles };
        doc.StylePath = "assets\\styles";
        doc.ScriptPath = "assets\\scripts";
        doc.AddLibrary(Libraries.Bootstrap);

        var html = doc.ToString();

        StringAssert.Contains(html, "assets/styles/bootstrap.min.css");
        StringAssert.Contains(html, "assets/scripts/bootstrap.bundle.min.js");
        Assert.IsFalse(html.Contains("assets\\styles"));
        Assert.IsFalse(html.Contains("assets\\scripts"));
    }
}