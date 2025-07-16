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
}
