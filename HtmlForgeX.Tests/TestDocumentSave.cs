using System;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestDocumentSave {
    [TestMethod]
    public void Save_CreatesDirectoryAndWritesUtf8() {
        var doc = new Document();
        string tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        string dir = Path.Combine(tempDir, "sub");
        string path = Path.Combine(dir, "test.html");
        doc.Save(path);
        Assert.IsTrue(Directory.Exists(dir));
        string content = File.ReadAllText(path, Encoding.UTF8);
        Assert.AreEqual(doc.ToString(), content);
        Directory.Delete(tempDir, true);
    }
}
