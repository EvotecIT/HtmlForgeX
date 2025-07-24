using System.IO;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestLibraryDownloaderIcons {
    [TestMethod]
    public async Task GenerateTablerIconCodeAsync_ParsesIcons() {
        var css = ".ti-user:before{} .ti-3d-cube:before{}";
        var path = Path.Combine(TempPath.Get(), "icons.css");
#if NET8_0_OR_GREATER
        await File.WriteAllTextAsync(path, css);
#else
        File.WriteAllText(path, css);
#endif

        try {
            var dl = new LibraryDownloader();
            var icons = await dl.GenerateTablerIconCodeAsync(path);
            Assert.IsTrue(icons.Contains("public static TablerIcon User => new TablerIcon(\"ti-user\");"));
            Assert.IsTrue(icons.Contains("public static TablerIcon ThreedCube => new TablerIcon(\"ti-3d-cube\");"));
        } finally {
            File.Delete(path);
        }
    }
}