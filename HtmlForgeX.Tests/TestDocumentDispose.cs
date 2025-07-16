using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestDocumentDispose {
    [TestMethod]
    public void Dispose_MultipleCalls_DoesNotThrow() {
        using var doc = new Document();
        doc.Dispose();
        doc.Dispose();
    }
}
