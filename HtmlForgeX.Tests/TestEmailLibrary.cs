using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

/// <summary>
/// Tests features of the <see cref="EmailLibrary"/> helper class.
/// </summary>
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