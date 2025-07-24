using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

/// <summary>
/// Ensures concurrent saves do not produce conflicting output files.
/// </summary>
[TestClass]
public class TestDocumentSaveMultithreaded {
    [TestMethod]
    public void Save_MultipleThreads_OneFileProduced() {
        using var doc = new Document();
        var path = Path.Combine(TempPath.Get(), Path.GetRandomFileName() + ".html");

        const int taskCount = 20;
        var tasks = Enumerable.Range(0, taskCount).Select(_ => Task.Run(() => doc.Save(path)));
        Task.WaitAll(tasks.ToArray());

        Assert.IsTrue(File.Exists(path));
        var files = Directory.GetFiles(Path.GetDirectoryName(path)!, Path.GetFileName(path));
        Assert.AreEqual(1, files.Length);
        var content = File.ReadAllText(path, Encoding.UTF8);
        Assert.AreEqual(doc.ToString(), content);
        Assert.AreEqual(1, FileWriteLock.Semaphore.CurrentCount);
        File.Delete(path);
    }

    [TestMethod]
    public async Task SaveAsync_MultipleThreads_OneFileProduced() {
        using var doc = new Document();
        var path = Path.Combine(TempPath.Get(), Path.GetRandomFileName() + ".html");

        const int taskCount = 20;
        var tasks = Enumerable.Range(0, taskCount).Select(_ => Task.Run(() => doc.SaveAsync(path)));
        await Task.WhenAll(tasks);

        Assert.IsTrue(File.Exists(path));
        var files = Directory.GetFiles(Path.GetDirectoryName(path)!, Path.GetFileName(path));
        Assert.AreEqual(1, files.Length);
        var content = File.ReadAllText(path, Encoding.UTF8);
        Assert.AreEqual(doc.ToString(), content);
        Assert.AreEqual(1, FileWriteLock.Semaphore.CurrentCount);
        File.Delete(path);
    }
}