using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

/// <summary>
/// Tests adding libraries from relative file paths in both online and offline modes.
/// </summary>
[TestClass]
public class TestAddLibraryRelativePaths {
    [TestMethod]
    public void AddLibrary_RelativePathsWorkOffline() {
        var baseDir = Path.Combine(TestUtilities.GetFrameworkSpecificTempPath(), $"rel_{Guid.NewGuid():N}");
        Directory.CreateDirectory(baseDir);
        var cssFile = Path.Combine(baseDir, "style.css");
        var jsFile = Path.Combine(baseDir, "script.js");
        File.WriteAllText(cssFile, "body{color:red;}");
        File.WriteAllText(jsFile, "console.log('test');");

        var lib = new Library {
            Header = new LibraryLinks {
                Css = ["style.css"],
                Js = ["script.js"]
            }
        };

        using var doc = new Document { LibraryMode = LibraryMode.Offline, Path = baseDir };
        doc.AddLibrary(lib);
        var html = doc.ToString();

        Directory.Delete(baseDir, true);

        StringAssert.Contains(html, "body{color:red;}");
        StringAssert.Contains(html, "console.log('test');");
    }
}
