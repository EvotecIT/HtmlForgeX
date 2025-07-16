using System;
using System.IO;
using System.Reflection;
using HtmlForgeX.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

/// <summary>
/// Tests validation of error logging when library files fail to load.
/// </summary>
[TestClass]
public class TestAddLibraryErrors {
    private static InternalLogger GetLogger() {
        var field = typeof(Document).GetField("_logger", BindingFlags.NonPublic | BindingFlags.Static);
        Assert.IsNotNull(field);
        return (InternalLogger)field!.GetValue(null)!;
    }

    [TestMethod]
    public void AddLibrary_CssFileLocked_LogsError() {
        var logger = GetLogger();
        string? received = null;
        EventHandler<LogEventArgs> handler = (_, e) => received = e.FullMessage;
        logger.OnErrorMessage += handler;

        var tempDir = TestUtilities.GetFrameworkSpecificTempPath();
        var cssPath = Path.Combine(tempDir, $"locked_{Guid.NewGuid():N}.css");
        File.WriteAllText(cssPath, "body {}", System.Text.Encoding.UTF8);
        using (File.Open(cssPath, FileMode.Open, FileAccess.ReadWrite, FileShare.None)) {
            var lib = new Library { Header = new LibraryLinks { Css = [cssPath] } };
            using var doc = new Document { LibraryMode = LibraryMode.Offline };
            doc.AddLibrary(lib);
        }

        logger.OnErrorMessage -= handler;
        File.Delete(cssPath);
        Assert.IsNotNull(received);
        StringAssert.Contains(received!, cssPath);
    }

    [TestMethod]
    public void AddLibrary_JsFileLocked_LogsError() {
        var logger = GetLogger();
        string? received = null;
        EventHandler<LogEventArgs> handler = (_, e) => received = e.FullMessage;
        logger.OnErrorMessage += handler;

        var tempDir = TestUtilities.GetFrameworkSpecificTempPath();
        var jsPath = Path.Combine(tempDir, $"locked_{Guid.NewGuid():N}.js");
        File.WriteAllText(jsPath, "console.log('hi');", System.Text.Encoding.UTF8);
        using (File.Open(jsPath, FileMode.Open, FileAccess.ReadWrite, FileShare.None)) {
            var lib = new Library { Header = new LibraryLinks { Js = [jsPath] } };
            using var doc = new Document { LibraryMode = LibraryMode.Offline };
            doc.AddLibrary(lib);
        }

        logger.OnErrorMessage -= handler;
        File.Delete(jsPath);
        Assert.IsNotNull(received);
        StringAssert.Contains(received!, jsPath);
    }
}
