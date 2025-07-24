using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestLibraryRegistrarThreadSafety {
    [TestMethod]
    public void AddLibrary_ConcurrentCalls_NoDuplicateLinks() {
        var lib = new Library {
            Header = new LibraryLinks {
                CssLink = ["https://example.com/style.css"],
                JsLink = ["https://example.com/script.js"]
            }
        };

        using var doc = new Document();

        var tasks = Enumerable.Range(0, 10)
            .Select(_ => Task.Run(() => doc.AddLibrary(lib)));
        Task.WaitAll(tasks.ToArray());

        var html = doc.ToString();
        var cssCount = Regex.Matches(html, "https://example.com/style.css").Count;
        var jsCount = Regex.Matches(html, "https://example.com/script.js").Count;

        Assert.AreEqual(1, cssCount, "CSS link should be added only once");
        Assert.AreEqual(1, jsCount, "JS link should be added only once");
    }
}