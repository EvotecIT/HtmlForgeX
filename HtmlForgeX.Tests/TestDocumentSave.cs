using System;
using System.IO;
using System.Threading.Tasks;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

/// <summary>
/// Verifies document saving, including file creation and UTF-8 handling.
/// </summary>
[TestClass]
public class TestDocumentSave {

    [TestMethod]
    public void Save_CreatesDirectoryAndWritesUtf8() {
        var doc = new Document();
        string tempDir = Path.Combine(TestUtilities.GetFrameworkSpecificTempPath(), Guid.NewGuid().ToString());
        string dir = Path.Combine(tempDir, "subDirectory");
        string path = Path.Combine(dir, "testSubDirectory.html");
        doc.Save(path);
        Assert.IsTrue(Directory.Exists(dir));
        string content = File.ReadAllText(path, Encoding.UTF8);
        Assert.AreEqual(doc.ToString(), content);
        Directory.Delete(tempDir, true);
    }

    [TestMethod]
    public async Task SaveAsync_WritesFile() {
        var doc = new Document();
        var tempPath = Path.Combine(TestUtilities.GetFrameworkSpecificTempPath(), $"file_{Guid.NewGuid():N}.html");

        await doc.SaveAsync(tempPath);
        Assert.IsTrue(File.Exists(tempPath));
        var contents = File.ReadAllText(tempPath);
        File.Delete(tempPath);
        Assert.AreEqual(doc.ToString(), contents);
    }

    [TestMethod]
    public async Task SaveAsync_InvalidPath_ThrowsArgumentException() {
        var doc = new Document();
        await Assert.ThrowsExceptionAsync<ArgumentException>(async () => await doc.SaveAsync("invalid\0path.html"));
    }
}
