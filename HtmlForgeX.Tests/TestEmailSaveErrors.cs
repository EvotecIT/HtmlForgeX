using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using HtmlForgeX.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

/// <summary>
/// Checks that errors encountered during email saving are logged.
/// </summary>
[TestClass]
public class TestEmailSaveErrors {
    private static InternalLogger GetLogger() {
        var field = typeof(Email).GetField("_logger", BindingFlags.NonPublic | BindingFlags.Static);
        Assert.IsNotNull(field);
        return (InternalLogger)field!.GetValue(null)!;
    }

    [TestMethod]
    public void Save_PathIsDirectory_LogsError() {
        var logger = GetLogger();
        string? received = null;
        EventHandler<LogEventArgs> handler = (_, e) => received = e.FullMessage;
        logger.OnErrorMessage += handler;
        var email = new Email();
        var tempDir = TestUtilities.GetFrameworkSpecificTempPath();
        var dir = Path.Combine(tempDir, Guid.NewGuid().ToString());
        try {
            Directory.CreateDirectory(dir);
        } catch (Exception ex) {
            logger.WriteError($"Failed to create directory '{dir}'. {ex.Message}");
        }
        email.Save(dir);
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
        var email = new Email();
        var tempDir = TestUtilities.GetFrameworkSpecificTempPath();
        var path = Path.Combine(tempDir, $"file_{Guid.NewGuid()}.html");
        using (File.Open(path, FileMode.Create, FileAccess.ReadWrite, FileShare.None)) {
            email.Save(path);
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
        var email = new Email();
        var tempDir = TestUtilities.GetFrameworkSpecificTempPath();
        var path = Path.Combine(tempDir, $"file_{Guid.NewGuid():N}.html");
        using (File.Open(path, FileMode.Create, FileAccess.ReadWrite, FileShare.None)) {
            await email.SaveAsync(path);
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
        var email = new Email();
        var tempDir = TestUtilities.GetFrameworkSpecificTempPath();
        var dirPath = Path.Combine(tempDir, $"dir_{Guid.NewGuid()}");
        File.WriteAllText(dirPath, string.Empty);
        var filePath = Path.Combine(dirPath, "file.html");
        email.Save(filePath);
        logger.OnErrorMessage -= handler;
        File.Delete(dirPath);
        Assert.IsNotNull(received);
        StringAssert.Contains(received!, dirPath);
    }
}
