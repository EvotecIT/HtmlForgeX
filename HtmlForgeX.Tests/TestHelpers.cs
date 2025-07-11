using HtmlForgeX;


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
        var lockedViaInfo = fileInfo.IsFileLocked();
        var lockedViaPath = path.IsFileLocked();
        Assert.IsTrue(lockedViaInfo);
        Assert.IsTrue(lockedViaPath);

        stream.Dispose();

        lockedViaInfo = fileInfo.IsFileLocked();
        lockedViaPath = path.IsFileLocked();
        Assert.IsFalse(lockedViaInfo);
        Assert.IsFalse(lockedViaPath);
        File.Delete(path);
    }
}