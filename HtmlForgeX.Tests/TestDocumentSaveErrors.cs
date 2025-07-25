using System;
using System.IO;
using System.Threading.Tasks;

using HtmlForgeX.Logging;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

/// <summary>
/// Tests error handling when saving documents fails.
/// </summary>
[TestClass]
public class TestDocumentSaveErrors {
    private static InternalLogger GetLogger() {
        return Document._logger;
    }



    [TestMethod]
    public void Save_PathIsDirectory_LogsError() {
        var logger = GetLogger();
        string? received = null;
        EventHandler<LogEventArgs> handler = (_, e) => received = e.FullMessage;
        logger.OnErrorMessage += handler;
        using var doc = new Document();
        var tempDir = TempPath.Get();
        var dir = Path.Combine(tempDir, Guid.NewGuid().ToString());
        try {
            Directory.CreateDirectory(dir);
        } catch (Exception ex) {
            Document._logger.WriteError($"Failed to create directory '{dir}'. {ex.Message}");
        }
        doc.Save(dir);
        logger.OnErrorMessage -= handler;
        Directory.Delete(dir, true);
        Assert.IsNotNull(received);
        StringAssert.Contains(received!, dir);
    }

    [TestMethod]
    public void Save_UnwritableLocation_LogsError() {
        var logger = GetLogger();
        string? received = null;
        EventHandler<LogEventArgs> handler = (_, e) => received = e.FullMessage;
        logger.OnErrorMessage += handler;
        using var doc = new Document();
        var tempDir = TempPath.Get();
        var path = Path.Combine(tempDir, $"file_{Guid.NewGuid()}.html");
        using (File.Open(path, FileMode.Create, FileAccess.ReadWrite, FileShare.None)) {
            doc.Save(path);
        }
        logger.OnErrorMessage -= handler;
        File.Delete(path);
        Assert.IsNotNull(received);
        StringAssert.Contains(received!, path);
    }

    [TestMethod]
    public async Task SaveAsync_UnwritableLocation_LogsError() {
        var logger = GetLogger();
        string? received = null;
        EventHandler<LogEventArgs> handler = (_, e) => received = e.FullMessage;
        logger.OnErrorMessage += handler;
        using var doc = new Document();
        var tempDir = TempPath.Get();
        var path = Path.Combine(tempDir, $"file_{Guid.NewGuid():N}.html");
        using (File.Open(path, FileMode.Create, FileAccess.ReadWrite, FileShare.None)) {
            await doc.SaveAsync(path);
        }
        logger.OnErrorMessage -= handler;
        File.Delete(path);
        Assert.IsNotNull(received);
        StringAssert.Contains(received!, path);
    }

    [TestMethod]
    public void Save_DirectoryCreationFails_LogsError() {
        var logger = GetLogger();
        string? received = null;
        EventHandler<LogEventArgs> handler = (_, e) => received ??= e.FullMessage;
        logger.OnErrorMessage += handler;
        using var doc = new Document();
        var tempDir = TempPath.Get();
        var dirPath = Path.Combine(tempDir, $"dir_{Guid.NewGuid()}");
        File.WriteAllText(dirPath, string.Empty);
        var filePath = Path.Combine(dirPath, "file.html");
        doc.Save(filePath);
        logger.OnErrorMessage -= handler;
        File.Delete(dirPath);
        Assert.IsNotNull(received);
        StringAssert.Contains(received!, dirPath);
    }

    [TestMethod]
    public void Save_UnwritableLocation_ReleasesSemaphore() {
        using var doc = new Document();
        var tempDir = TempPath.Get();
        var path = Path.Combine(tempDir, $"file_{Guid.NewGuid():N}.html");
        using var stream = File.Open(path, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
        doc.Save(path);
        Assert.AreEqual(1, FileWriteLock.Semaphore.CurrentCount);
        stream.Dispose();
        File.Delete(path);
    }
}