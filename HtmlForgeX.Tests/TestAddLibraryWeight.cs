using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestAddLibraryWeight {
    [TestMethod]
    public void AddLibrary_WithWeight_RegistersCorrectOrder() {
        using var doc = new Document();
        doc.AddLibrary(Libraries.SmartWizard, 10);
        Assert.IsTrue(doc.Configuration.Libraries.TryGetValue(Libraries.SmartWizard, out var weight));
        Assert.AreEqual((byte)10, weight);
    }
}