using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Runtime.InteropServices;
using HtmlForgeX.Logging;

namespace HtmlForgeX.Tests;

/// <summary>
/// Verifies encoding helper methods to ensure HTML output is safe.
/// </summary>
[TestClass]
public class TestHelpersEncoding {
    [TestMethod]
    public void HtmlEncode_EncodesSpecialCharacters() {
        var encoded = Helpers.HtmlEncode("<div class=\"t\">&</div>");
        Assert.AreEqual("&lt;div class=&quot;t&quot;&gt;&amp;&lt;/div&gt;", encoded);
    }

    [TestMethod]
    public void Open_ReturnsTrueWhenDisabled() {
        var result = Helpers.Open("dummy", false);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Open_ReturnsFalseForMissingFile() {
        var path = Path.Combine(TestUtilities.GetFrameworkSpecificTempPath(), Path.GetRandomFileName());
        var result = Helpers.Open(path, true);
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void Open_UnsupportedOS_LogsError() {
        var tempDir = TestUtilities.GetFrameworkSpecificTempPath();
        var path = Path.Combine(tempDir, Path.GetRandomFileName());
        File.WriteAllText(path, "test");
        string? message = null;
        EventHandler<LogEventArgs> handler = (_, e) => message = e.FullMessage;
        Document._logger.OnErrorMessage += handler;
        Helpers.PlatformOverride = OSPlatform.Create("other");
        var result = Helpers.Open(path, true);
        Helpers.PlatformOverride = null;
        Document._logger.OnErrorMessage -= handler;
        File.Delete(path);
        Assert.IsFalse(result);
        Assert.IsNotNull(message);
    }
}