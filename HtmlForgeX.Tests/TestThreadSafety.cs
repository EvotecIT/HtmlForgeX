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
}
