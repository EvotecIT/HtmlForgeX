using System;
using System.IO;
using System.Reflection;
using HtmlForgeX.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestDocumentSaveErrors {
    private static InternalLogger GetLogger() {
        var field = typeof(Document).GetField("_logger", BindingFlags.NonPublic | BindingFlags.Static);
        Assert.IsNotNull(field);
        return (InternalLogger)field!.GetValue(null)!;
    }

    [TestMethod]
    public void Save_PathIsDirectory_LogsError() {
        var logger = GetLogger();
        string? received = null;
        EventHandler<LogEventArgs> handler = (_, e) => received = e.FullMessage;
        logger.OnErrorMessage += handler;
        var doc = new Document();
        var dir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(dir);
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
        var doc = new Document();
        var path = Path.Combine(Path.GetTempPath(), $"file_{Guid.NewGuid()}.html");
        using (File.Open(path, FileMode.Create, FileAccess.ReadWrite, FileShare.None)) {
            doc.Save(path);
        }
        logger.OnErrorMessage -= handler;
        File.Delete(path);
        Assert.IsNotNull(received);
        StringAssert.Contains(received!, path);
    }
}
