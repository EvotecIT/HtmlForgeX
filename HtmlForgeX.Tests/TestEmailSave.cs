using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestEmailSave {
    [TestMethod]
    public void Save_CreatesDirectoryAndWritesUtf8() {
        var email = new Email();
        string tempDir = Path.Combine(TestUtilities.GetFrameworkSpecificTempPath(), Guid.NewGuid().ToString());
        string dir = Path.Combine(tempDir, "subDirectory");
        string path = Path.Combine(dir, "testSubDirectory.html");
        email.Save(path);
        Assert.IsTrue(Directory.Exists(dir));
        string content = File.ReadAllText(path, Encoding.UTF8);
        Assert.AreEqual(email.ToString(), content);
        Directory.Delete(tempDir, true);
    }

    [TestMethod]
    public async Task SaveAsync_WritesFile() {
        var email = new Email();
        var tempPath = Path.Combine(TestUtilities.GetFrameworkSpecificTempPath(), $"file_{Guid.NewGuid():N}.html");

        await email.SaveAsync(tempPath);
        Assert.IsTrue(File.Exists(tempPath));
        var contents = File.ReadAllText(tempPath);
        File.Delete(tempPath);
        Assert.AreEqual(email.ToString(), contents);
    }

    [TestMethod]
    public async Task SaveAsync_InvalidPath_ThrowsArgumentException() {
        var email = new Email();
        await Assert.ThrowsExceptionAsync<ArgumentException>(async () => await email.SaveAsync("invalid\0path.html"));
    }
}
