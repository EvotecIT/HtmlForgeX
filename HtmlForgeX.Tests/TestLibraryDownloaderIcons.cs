using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Threading.Tasks;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestLibraryDownloaderIcons {
    [TestMethod]
    public async Task GenerateTablerIconCodeAsync_ParsesIcons() {
        var css = ".ti-user:before{} .ti-3d-cube:before{}";
        var path = Path.Combine(TestUtilities.GetFrameworkSpecificTempPath(), "icons.css");
        await File.WriteAllTextAsync(path, css);

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
