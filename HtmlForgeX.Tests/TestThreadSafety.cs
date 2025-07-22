using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestThreadSafety {
    [TestMethod]
    public void DocumentConfiguration_Errors_ConcurrentAdd() {
        var config = new DocumentConfiguration();
        var tasks = new List<Task>();
        for (int i = 0; i < 100; i++) {
            int copy = i;
            tasks.Add(Task.Run(() => config.Errors.Add($"err {copy}")));
        }
        Task.WaitAll(tasks.ToArray());
        Assert.AreEqual(100, config.Errors.Count);
    }

    [TestMethod]
    public void EmailConfiguration_Errors_ConcurrentAdd() {
        var config = new EmailConfiguration();
        var tasks = new List<Task>();
        for (int i = 0; i < 100; i++) {
            int copy = i;
            tasks.Add(Task.Run(() => config.Errors.Add($"err {copy}")));
        }
        Task.WaitAll(tasks.ToArray());
        Assert.AreEqual(100, config.Errors.Count);
    }

    [TestMethod]
    public void LibraryRegistration_DynamicAdd_ShouldWork() {
        using var document = new Document(LibraryMode.Online);

        var tasks = new List<Task>();
        for (int i = 0; i < 20; i++) {
            tasks.Add(Task.Run(() => {
                var page = new TablerPage();
                document.Body.Add(page);
            }));
        }

        Task.WaitAll(tasks.ToArray());

        var htmlOutput = document.ToString();

        Assert.IsTrue(document.Configuration.Libraries.ContainsKey(Libraries.Bootstrap),
            "Dynamically added pages should register Bootstrap library");
        Assert.IsTrue(document.Configuration.Libraries.ContainsKey(Libraries.Tabler),
            "Dynamically added pages should register Tabler library");
        Assert.IsTrue(htmlOutput.Contains("bootstrap"), "HTML should contain Bootstrap library reference");
        Assert.IsTrue(htmlOutput.Contains("tabler"), "HTML should contain Tabler library reference");
    }

    [TestMethod]
    public void DocumentConfiguration_Path_ConcurrentSet() {
        var config = new DocumentConfiguration();
        var tasks = new List<Task>();

        for (int i = 0; i < 100; i++) {
            int copy = i;
            tasks.Add(Task.Run(() => config.Path = $"path_{copy}"));
        }

        Task.WaitAll(tasks.ToArray());

        StringAssert.StartsWith(config.Path, "path_");
    }
}
