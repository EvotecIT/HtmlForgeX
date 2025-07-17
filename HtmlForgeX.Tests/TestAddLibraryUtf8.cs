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
        using var doc = new Document { LibraryMode = LibraryMode.Offline };
        var added = doc.AddLibrary(lib);
        var headHtml = doc.Head.ToString();

        File.Delete(cssPath);
        File.Delete(jsPath);

        Assert.IsTrue(added);
        StringAssert.Contains(headHtml, cssContent);
        StringAssert.Contains(headHtml, jsContent);
    }

    [TestMethod]
    public void AddLibrary_DeduplicatesWhitespaceVariants() {
        var tempDir = TestUtilities.GetFrameworkSpecificTempPath();
        var css1 = Path.Combine(tempDir, $"dup1_{System.Guid.NewGuid():N}.css");
        var css2 = Path.Combine(tempDir, $"dup2_{System.Guid.NewGuid():N}.css");
        var js1 = Path.Combine(tempDir, $"dup1_{System.Guid.NewGuid():N}.js");
        var js2 = Path.Combine(tempDir, $"dup2_{System.Guid.NewGuid():N}.js");

        File.WriteAllText(css1, "body { color: red; }", Encoding.UTF8);
        File.WriteAllText(css2, " body  {  color: red;   }\n", Encoding.UTF8);
        File.WriteAllText(js1, "console.log('hi');", Encoding.UTF8);
        File.WriteAllText(js2, "\nconsole.log('hi');\n", Encoding.UTF8);

        var lib = new Library {
            Header = new LibraryLinks {
                Css = [css1, css2],
                Js = [js1, js2]
            }
        };

        using var doc = new Document { LibraryMode = LibraryMode.Offline };
        var added = doc.AddLibrary(lib);

        File.Delete(css1);
        File.Delete(css2);
        File.Delete(js1);
        File.Delete(js2);

        Assert.IsTrue(added);
        Assert.AreEqual(1, doc.Head.Styles.Count);
        Assert.AreEqual(1, doc.Head.Scripts.Count);
    }
}
