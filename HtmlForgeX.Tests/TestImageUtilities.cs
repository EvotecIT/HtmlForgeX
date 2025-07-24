using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestImageUtilities {
    private string _testImagePath = string.Empty;
    private readonly byte[] _testImageData = new byte[] {
        0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A, 0x00, 0x00, 0x00, 0x0D,
        0x49, 0x48, 0x44, 0x52, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01,
        0x08, 0x06, 0x00, 0x00, 0x00, 0x1F, 0x15, 0xC4, 0x89, 0x00, 0x00, 0x00,
        0x0A, 0x49, 0x44, 0x41, 0x54, 0x78, 0x9C, 0x63, 0x00, 0x01, 0x00, 0x00,
        0x05, 0x00, 0x01, 0x0D, 0x0A, 0x2D, 0xB4, 0x00, 0x00, 0x00, 0x00, 0x49,
        0x45, 0x4E, 0x44, 0xAE, 0x42, 0x60, 0x82
    };

    [TestInitialize]
    public void Setup() {
        _testImagePath = Path.GetTempFileName();
        File.WriteAllBytes(_testImagePath, _testImageData);
    }

    [TestCleanup]
    public void Cleanup() {
        if (File.Exists(_testImagePath)) {
            File.Delete(_testImagePath);
        }
    }

    [TestMethod]
    public void LoadImageBytes_ReturnsCorrectData() {
        var bytes = ImageUtilities.LoadImageBytes(_testImagePath);
        CollectionAssert.AreEqual(_testImageData, bytes);
    }

    [TestMethod]
    public void GetMimeTypeFromExtension_ReturnsPng() {
        var mime = ImageUtilities.GetMimeTypeFromExtension(".png");
        Assert.AreEqual("image/png", mime);
    }

    [TestMethod]
    public void GetMimeTypeFromUrl_ReturnsJpeg() {
        var mime = ImageUtilities.GetMimeTypeFromUrl("http://example.com/test.jpg");
        Assert.AreEqual("image/jpeg", mime);
    }

    [TestMethod]
    public void LoadImageFromFile_ReturnsBytesAndMime() {
        var result = ImageUtilities.LoadImageFromFile(_testImagePath);
        CollectionAssert.AreEqual(_testImageData, result.Bytes);
        Assert.AreEqual("image/png", result.MimeType);
    }

    [TestMethod]
    public void GetMimeTypeFromExtension_JpegAlias() {
        var mime = ImageUtilities.GetMimeTypeFromExtension("jpeg");
        Assert.AreEqual("image/jpeg", mime);
    }

    [TestMethod]
    public void GetExtensionFromMimeType_Jpeg() {
        var ext = ImageUtilities.GetExtensionFromMimeType("image/jpeg");
        Assert.AreEqual(".jpg", ext);
    }

    [TestMethod]
    public void UnknownTypes_ReturnDefaults() {
        Assert.AreEqual("image/png", ImageUtilities.GetMimeTypeFromExtension(".unknown"));
        Assert.AreEqual(".png", ImageUtilities.GetExtensionFromMimeType("application/unknown"));
    }
}