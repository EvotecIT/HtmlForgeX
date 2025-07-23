using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
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
        var path = Path.Combine(TempPath.Get(), Path.GetRandomFileName());
        var result = Helpers.Open(path, true);
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void Open_UnsupportedOS_LogsError() {
        var tempDir = TempPath.Get();
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

    [TestMethod]
    public void Open_ReturnsFalseForFailedProcess() {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) {
            Assert.Inconclusive("Test requires Linux");
            return;
        }

        var tempDir = TempPath.Get();
        var path = Path.Combine(tempDir, Path.GetRandomFileName());
        File.WriteAllText(path, "test");

        var scriptDir = Path.Combine(tempDir, "script_" + Path.GetRandomFileName());
        Directory.CreateDirectory(scriptDir);
        var scriptPath = Path.Combine(scriptDir, "xdg-open");
        File.WriteAllText(scriptPath, "#!/bin/sh\nexit 1");
        Process.Start("chmod", $"+x {scriptPath}")?.WaitForExit();

        var originalPath = Environment.GetEnvironmentVariable("PATH");
        Environment.SetEnvironmentVariable("PATH", scriptDir + Path.PathSeparator + originalPath);

        Helpers.PlatformOverride = OSPlatform.Linux;
        var result = Helpers.Open(path, true);
        Helpers.PlatformOverride = null;

        Environment.SetEnvironmentVariable("PATH", originalPath);

        File.Delete(path);
        Directory.Delete(scriptDir, true);

        Assert.IsFalse(result);
    }
}