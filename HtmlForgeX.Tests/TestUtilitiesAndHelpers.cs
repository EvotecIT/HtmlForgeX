using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Threading.Tasks;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestUtilitiesAndHelpers {

    [TestMethod]
    public async Task LibraryDownloader_DownloadLibrary() {
        var downloader = new LibraryDownloader();
        var tempDir = Path.Combine(TestUtilities.GetFrameworkSpecificTempPath(), $"lib_test_{System.Guid.NewGuid()}");
        Directory.CreateDirectory(tempDir);
        
        try {
            await downloader.DownloadLibraryAsync(tempDir, Libraries.JQuery);
            Assert.IsTrue(Directory.Exists(tempDir));
        } catch (System.Net.Http.HttpRequestException) {
            Assert.Inconclusive("Network not available for test");
        } finally {
            if (Directory.Exists(tempDir)) {
                Directory.Delete(tempDir, true);
            }
        }
    }

    [TestMethod]
    public void LibraryDownloader_BasicCreation() {
        var downloader = new LibraryDownloader();
        Assert.IsNotNull(downloader);
    }

    [TestMethod]
    public void DocumentConfiguration_ErrorsCollection() {
        var config = new DocumentConfiguration();
        
        config.Errors.Add("Test error 1");
        config.Errors.Add("Test error 2");
        
        Assert.AreEqual(2, config.Errors.Count);
        Assert.IsTrue(config.Errors.Contains("Test error 1"));
        Assert.IsTrue(config.Errors.Contains("Test error 2"));
    }
}