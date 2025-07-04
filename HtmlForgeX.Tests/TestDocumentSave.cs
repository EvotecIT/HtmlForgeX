using System;
using System.IO;
using System.Threading.Tasks;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestDocumentSave {
    [TestMethod]
    public async Task SaveAsync_WritesFile() {
        var doc = new Document();
        var tempPath = Path.Combine(Path.GetTempPath(), $"file_{Guid.NewGuid():N}.html");
        await doc.SaveAsync(tempPath);
        Assert.IsTrue(File.Exists(tempPath));
        var contents = File.ReadAllText(tempPath);
        File.Delete(tempPath);
        Assert.AreEqual(doc.ToString(), contents);
    }
}
