using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace HtmlForgeX.Tests;

/// <summary>
/// Covers a full document creation workflow from setup to rendering.
/// </summary>
[TestClass]
public class TestDocumentWorkflow {

    [TestMethod]
    public void Document_BasicCreation() {
        var doc = new Document();
        
        Assert.IsNotNull(doc.Head);
        Assert.IsNotNull(doc.Body);
        Assert.IsNotNull(doc.Configuration);
        Assert.AreEqual(LibraryMode.Online, doc.LibraryMode);
        Assert.AreEqual(ThemeMode.System, doc.ThemeMode);
    }

    [TestMethod]
    public void Document_ConfigurationProperties() {
        var doc = new Document();
        
        doc.LibraryMode = LibraryMode.Offline;
        doc.ThemeMode = ThemeMode.Dark;
        doc.Path = "/custom/path";
        doc.StylePath = "/styles/";
        doc.ScriptPath = "/scripts/";
        
        Assert.AreEqual(LibraryMode.Offline, doc.LibraryMode);
        Assert.AreEqual(ThemeMode.Dark, doc.ThemeMode);
        Assert.AreEqual("/custom/path", doc.Path);
        Assert.AreEqual("/styles/", doc.StylePath);
        Assert.AreEqual("/scripts/", doc.ScriptPath);
    }

    [TestMethod]
    public void Document_AddLibrary() {
        var doc = new Document();
        var customLibrary = new Library {
            Header = new LibraryLinks {
                CssLink = ["https://example.com/custom.css"],
                JsLink = ["https://example.com/custom.js"]
            }
        };
        
        doc.AddLibrary(customLibrary);
        var html = doc.ToString();
        
        Assert.IsTrue(html.Contains("https://example.com/custom.css"));
        Assert.IsTrue(html.Contains("https://example.com/custom.js"));
    }

    [TestMethod]
    public void Document_ToStringContainsBasicStructure() {
        var doc = new Document();
        var html = doc.ToString();
        
        Assert.IsTrue(html.Contains("<!DOCTYPE html>"));
        Assert.IsTrue(html.Contains("<html"));
        Assert.IsTrue(html.Contains("<head>") || html.Contains("<head "));
        Assert.IsTrue(html.Contains("</head>"));
        Assert.IsTrue(html.Contains("<body"));
        Assert.IsTrue(html.Contains("</body>"));
        Assert.IsTrue(html.Contains("</html>"));
    }

    [TestMethod]
    public void Document_WithContentInBody() {
        var doc = new Document();
        doc.Body.Add(new HtmlTag("p", "Hello World"));
        
        var html = doc.ToString();
        Assert.IsTrue(html.Contains("Hello World"));
    }

    [TestMethod]
    public void Document_WithHeadTitle() {
        var doc = new Document();
        doc.Head.AddTitle("Test Page");

        var html = doc.ToString();
        Assert.IsTrue(html.Contains("<title>Test Page</title>"));
    }

    [TestMethod]
    public void Document_AddTitle_EncodesInput() {
        var doc = new Document();
        doc.Head.AddTitle("<b>Title & Test</b>");

        Assert.AreEqual("&lt;b&gt;Title &amp; Test&lt;/b&gt;", doc.Head.Title);
    }

    [TestMethod]
    public void Document_SaveToFile() {
        var doc = new Document();
        doc.Body.Add(new HtmlTag("p", "Test content"));
        
        var tempFile = Path.Combine(TestUtilities.GetFrameworkSpecificTempPath(), $"test_{System.Guid.NewGuid()}.html");
        
        doc.Save(tempFile);
        
        Assert.IsTrue(File.Exists(tempFile));
        var content = File.ReadAllText(tempFile, Encoding.UTF8);
        Assert.AreEqual(doc.ToString(), content);
        
        File.Delete(tempFile);
    }

    [TestMethod]
    public async Task Document_SaveAsyncToFile() {
        var doc = new Document();
        doc.Body.Add(new HtmlTag("p", "Async test content"));
        
        var tempFile = Path.Combine(TestUtilities.GetFrameworkSpecificTempPath(), $"async_test_{System.Guid.NewGuid()}.html");
        
        await doc.SaveAsync(tempFile);
        
        Assert.IsTrue(File.Exists(tempFile));
        var content = File.ReadAllText(tempFile, Encoding.UTF8);
        Assert.AreEqual(doc.ToString(), content);
        
        File.Delete(tempFile);
    }

    [TestMethod]
    public void Document_MultipleLibraries() {
        var doc = new Document();
        
        var lib1 = new Library {
            Header = new LibraryLinks {
                CssLink = ["https://lib1.com/style.css"]
            }
        };
        
        var lib2 = new Library {
            Header = new LibraryLinks {
                JsLink = ["https://lib2.com/script.js"]
            }
        };
        
        doc.AddLibrary(lib1);
        doc.AddLibrary(lib2);
        
        var html = doc.ToString();
        Assert.IsTrue(html.Contains("https://lib1.com/style.css"));
        Assert.IsTrue(html.Contains("https://lib2.com/script.js"));
    }

    [TestMethod]
    public void Document_DuplicateCustomLibrariesSkipped() {
        var doc = new Document();

        var customLibrary = new Library {
            Header = new LibraryLinks {
                CssLink = ["https://dup.example.com/style.css"],
                JsLink = ["https://dup.example.com/script.js"]
            }
        };

        doc.AddLibrary(customLibrary);
        doc.AddLibrary(customLibrary);

        var html = doc.ToString();

        var cssCount = Regex.Matches(html, "https://dup.example.com/style.css").Count;
        var jsCount = Regex.Matches(html, "https://dup.example.com/script.js").Count;

        Assert.AreEqual(1, cssCount, "CSS link should be included only once");
        Assert.AreEqual(1, jsCount, "JS link should be included only once");
    }

    [TestMethod]
    public void Document_ErrorHandling() {
        var doc = new Document();
        
        doc.Configuration.Errors.Add("Test error");
        
        Assert.AreEqual(1, doc.Configuration.Errors.Count);
        Assert.IsTrue(doc.Configuration.Errors.Contains("Test error"));
    }
}