using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;

namespace HtmlForgeX.Tests;

/// <summary>
/// Ensures that library files encoded with UTF-8 characters load correctly.
/// </summary>
[TestClass]
public class TestAddLibraryUtf8 {
    [TestMethod]
    public void AddLibrary_LoadsUtf8Files() {
        var tempDir = TestUtilities.GetFrameworkSpecificTempPath();
        var cssPath = Path.Combine(tempDir, $"utf8_{System.Guid.NewGuid():N}.css");
        var jsPath = Path.Combine(tempDir, $"utf8_{System.Guid.NewGuid():N}.js");
        var cssContent = "body::after { content: 'żółć'; }";
        var jsContent = "console.log('żółć');";
        File.WriteAllText(cssPath, cssContent, Encoding.UTF8);
        File.WriteAllText(jsPath, jsContent, Encoding.UTF8);

        var lib = new Library {
            Header = new LibraryLinks {
                Css = [cssPath],
                Js = [jsPath]
            }
        };
        var doc = new Document { LibraryMode = LibraryMode.Offline };
        doc.AddLibrary(lib);
        var headHtml = doc.Head.ToString();

        File.Delete(cssPath);
        File.Delete(jsPath);

        StringAssert.Contains(headHtml, cssContent);
        StringAssert.Contains(headHtml, jsContent);
    }
}
