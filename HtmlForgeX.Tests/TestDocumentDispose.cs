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

    [TestMethod]
    public void Dispose_SemaphoreCountRemainsOne() {
        using var doc = new Document();
        var path = System.IO.Path.GetTempFileName();
        doc.Save(path);
        doc.Dispose();
        Assert.AreEqual(1, FileWriteLock.Semaphore.CurrentCount);
        System.IO.File.Delete(path);
    }

    [TestMethod]
    public void Dispose_DecrementsActiveDocumentsAndClearsLibraries() {
        var field = typeof(Document).GetField("_activeDocuments", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
        Assert.IsNotNull(field);
        var before = (int)field!.GetValue(null)!;

        var doc = new Document();
        var during = (int)field.GetValue(null)!;
        Assert.AreEqual(before + 1, during);

        doc.AddLibrary(Libraries.Bootstrap);
        Assert.AreNotEqual(0, doc.Configuration.Libraries.Count);

        doc.Dispose();

        var after = (int)field.GetValue(null)!;
        Assert.AreEqual(before, after);
        Assert.AreEqual(0, doc.Configuration.Libraries.Count);
    }
}