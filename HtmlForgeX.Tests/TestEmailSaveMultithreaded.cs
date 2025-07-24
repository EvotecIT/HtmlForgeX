using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

/// <summary>
/// Ensures multithreaded email saves do not generate conflicts.
/// </summary>
[TestClass]
public class TestEmailSaveMultithreaded {
    [TestMethod]
    public void Save_MultipleThreads_OneFileProduced() {
        var email = new Email();
        var path = Path.Combine(TempPath.Get(), Path.GetRandomFileName() + ".html");

        var tasks = Enumerable.Range(0, 5).Select(_ => Task.Run(() => email.Save(path)));
        Task.WaitAll(tasks.ToArray());

        Assert.IsTrue(File.Exists(path));
        var files = Directory.GetFiles(Path.GetDirectoryName(path)!, Path.GetFileName(path));
        Assert.AreEqual(1, files.Length);
        var content = File.ReadAllText(path, Encoding.UTF8);
        Assert.AreEqual(email.ToString(), content);
        File.Delete(path);
    }

    [TestMethod]
    public async Task SaveAsync_MultipleThreads_OneFileProduced() {
        var email = new Email();
        var path = Path.Combine(TempPath.Get(), Path.GetRandomFileName() + ".html");

        var tasks = Enumerable.Range(0, 5).Select(_ => Task.Run(() => email.SaveAsync(path)));
        await Task.WhenAll(tasks);

        Assert.IsTrue(File.Exists(path));
        var files = Directory.GetFiles(Path.GetDirectoryName(path)!, Path.GetFileName(path));
        Assert.AreEqual(1, files.Length);
        var content = File.ReadAllText(path, Encoding.UTF8);
        Assert.AreEqual(email.ToString(), content);
        File.Delete(path);
    }
}