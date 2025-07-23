using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

using HtmlForgeX.Logging;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestDocumentSaveOpenInBrowser {
    [TestMethod]
    public void Save_OpenInBrowserFalse_DoesNotAttemptToOpen() {
        var logger = Document._logger;
        string? message = null;
        EventHandler<LogEventArgs> handler = (_, e) => message = e.FullMessage;
        logger.OnErrorMessage += handler;
        Helpers.PlatformOverride = OSPlatform.Create("other");
        using var doc = new Document();
        var path = Path.Combine(TempPath.Get(), Path.GetRandomFileName() + ".html");
        doc.Save(path, false);
        logger.OnErrorMessage -= handler;
        Helpers.PlatformOverride = null;
        Assert.IsTrue(File.Exists(path));
        File.Delete(path);
        Assert.IsNull(message);
    }

    [TestMethod]
    public async Task SaveAsync_OpenInBrowserFalse_DoesNotAttemptToOpen() {
        var logger = Document._logger;
        string? message = null;
        EventHandler<LogEventArgs> handler = (_, e) => message = e.FullMessage;
        logger.OnErrorMessage += handler;
        Helpers.PlatformOverride = OSPlatform.Create("other");
        using var doc = new Document();
        var path = Path.Combine(TempPath.Get(), Path.GetRandomFileName() + ".html");
        await doc.SaveAsync(path, false);
        logger.OnErrorMessage -= handler;
        Helpers.PlatformOverride = null;
        Assert.IsTrue(File.Exists(path));
        File.Delete(path);
        Assert.IsNull(message);
    }
}