using System.Reflection;
using HtmlForgeX.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestLibraryIntegration {
    private static InternalLogger GetLogger() {
        var field = typeof(Document).GetField("_logger", BindingFlags.NonPublic | BindingFlags.Static);
        Assert.IsNotNull(field);
        return (InternalLogger)field!.GetValue(null)!;
    }

    [TestMethod]
    public void CustomLibraryOfflineAddsInlineAndLogsErrors() {
        var globalStorage = typeof(Document).Assembly.GetType("HtmlForgeX.GlobalStorage")!;
        var prop = globalStorage.GetProperty("LibraryMode", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Public)!;
        var originalMode = (LibraryMode)prop.GetValue(null)!;
        prop.SetValue(null, LibraryMode.Offline);

        var cssPath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid():N}.css");
        var jsPath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid():N}.js");
        var missingPath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid():N}.css");
        File.WriteAllText(cssPath, "body { color: red; }");
        File.WriteAllText(jsPath, "console.log('ok');");

        var library = new Library {
            Header = new LibraryLinks {
                Css = new List<string> { cssPath, missingPath },
                Js = new List<string> { jsPath }
            }
        };

        var logger = GetLogger();
        string? error = null;
        EventHandler<LogEventArgs> handler = (_, e) => error = e.FullMessage;
        logger.OnErrorMessage += handler;

        var doc = new Document();
        doc.AddLibrary(library);
        var head = doc.Head.ToString();

        logger.OnErrorMessage -= handler;
        prop.SetValue(null, originalMode);
        File.Delete(cssPath);
        File.Delete(jsPath);

        StringAssert.Contains(head, "<style>body { color: red; }</style>");
        StringAssert.Contains(head, "<script>console.log('ok');</script>");
        Assert.IsNotNull(error);
        StringAssert.Contains(error!, missingPath);
    }
}
