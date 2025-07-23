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

    [TestMethod]
    public void AddLibrary_DuplicateWeight_Ignored() {
        using var doc = new Document();
        doc.AddLibrary(Libraries.SmartWizard, 10);
        doc.AddLibrary(Libraries.SmartWizard, 5);

        Assert.AreEqual(1, doc.Configuration.Libraries.Count);
        Assert.IsTrue(doc.Configuration.Libraries.TryGetValue(Libraries.SmartWizard, out var weight));
        Assert.AreEqual((byte)10, weight);
    }

    [TestMethod]
    public void AddLibrary_SecondDifferentWeight_Ignored() {
        using var doc = new Document();
        doc.AddLibrary(Libraries.SmartWizard, 0);
        doc.AddLibrary(Libraries.SmartWizard, 10);

        Assert.AreEqual(1, doc.Configuration.Libraries.Count);
        Assert.IsTrue(doc.Configuration.Libraries.TryGetValue(Libraries.SmartWizard, out var weight));
        Assert.AreEqual((byte)0, weight);
    }
}