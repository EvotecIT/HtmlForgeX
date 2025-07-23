using HtmlForgeX;


namespace HtmlForgeX.Tests;

/// <summary>
/// Tests utility helper methods used within the library.
/// </summary>
[TestClass]
public class TestHelpers {
    [TestMethod]
    public void IsFileLockedDetectsOpenStream() {
        var tempDir = TempPath.Get();
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

    [TestMethod]
    public void IsFileLocked_ReturnsFalseForMissingFileInfo() {
        var tempDir = TempPath.Get();
        var path = Path.Combine(tempDir, Path.GetRandomFileName());
        var fileInfo = new FileInfo(path);
        var lockedViaInfo = fileInfo.IsFileLocked();
        Assert.IsFalse(lockedViaInfo);
    }

    [TestMethod]
    public void IsFileLocked_ReturnsFalseForMissingPath() {
        var tempDir = TempPath.Get();
        var path = Path.Combine(tempDir, Path.GetRandomFileName());
        var lockedViaPath = path.IsFileLocked();
        Assert.IsFalse(lockedViaPath);
    }
}