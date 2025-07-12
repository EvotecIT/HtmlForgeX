using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestDocumentSaveMultithreaded {
    [TestMethod]
    public void Save_MultipleThreads_OneFileProduced() {
        var doc = new Document();
        var path = Path.Combine(TestUtilities.GetFrameworkSpecificTempPath(), Path.GetRandomFileName() + ".html");

        var tasks = Enumerable.Range(0, 5).Select(_ => Task.Run(() => doc.Save(path)));
        Task.WaitAll(tasks.ToArray());

        Assert.IsTrue(File.Exists(path));
        var files = Directory.GetFiles(Path.GetDirectoryName(path)!, Path.GetFileName(path));
        Assert.AreEqual(1, files.Length);
        var content = File.ReadAllText(path, Encoding.UTF8);
        Assert.AreEqual(doc.ToString(), content);
        File.Delete(path);
    }

    [TestMethod]
    public async Task SaveAsync_MultipleThreads_OneFileProduced() {
        var doc = new Document();
        var path = Path.Combine(TestUtilities.GetFrameworkSpecificTempPath(), Path.GetRandomFileName() + ".html");

        var tasks = Enumerable.Range(0, 5).Select(_ => Task.Run(() => doc.SaveAsync(path)));
        await Task.WhenAll(tasks);

        Assert.IsTrue(File.Exists(path));
        var files = Directory.GetFiles(Path.GetDirectoryName(path)!, Path.GetFileName(path));
        Assert.AreEqual(1, files.Length);
        var content = File.ReadAllText(path, Encoding.UTF8);
        Assert.AreEqual(doc.ToString(), content);
        File.Delete(path);
    }
}
