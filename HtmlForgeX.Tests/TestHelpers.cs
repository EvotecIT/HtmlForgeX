using HtmlForgeX;

using System.Reflection;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestHelpers {
    [TestMethod]
    public void IsFileLockedDetectsOpenStream() {
        var tempDir = TestUtilities.GetFrameworkSpecificTempPath();
        var path = Path.Combine(tempDir, Path.GetRandomFileName());
        File.WriteAllText(path, "test");
        var fileInfo = new FileInfo(path);

        using var stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.None);
        var helpers = typeof(Document).Assembly.GetType("HtmlForgeX.Helpers")!;
        var fiMethod = helpers.GetMethod("IsFileLocked", BindingFlags.Public | BindingFlags.Static, null, new[] { typeof(FileInfo) }, null)!;
        var pathMethod = helpers.GetMethod("IsFileLocked", BindingFlags.Public | BindingFlags.Static, null, new[] { typeof(string) }, null)!;

        var lockedViaInfo = (bool)fiMethod.Invoke(null, new object[] { fileInfo })!;
        var lockedViaPath = (bool)pathMethod.Invoke(null, new object[] { path })!;
        Assert.IsTrue(lockedViaInfo);
        Assert.IsTrue(lockedViaPath);

        stream.Dispose();

        lockedViaInfo = (bool)fiMethod.Invoke(null, new object[] { fileInfo })!;
        lockedViaPath = (bool)pathMethod.Invoke(null, new object[] { path })!;
        Assert.IsFalse(lockedViaInfo);
        Assert.IsFalse(lockedViaPath);
        File.Delete(path);
    }
}
