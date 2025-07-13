using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestEmailLibrary {
    [TestMethod]
    public void AddCss_DoesNotInsertDuplicates() {
        var library = new EmailLibrary();
        library.AddCss("body { color: red; }");
        library.AddCss("body { color: red; }");

        Assert.AreEqual(1, library.InlineCss.Count);
    }
}