using System;
using System.IO;
using System.Text;
using Xunit;
using Assert = Xunit.Assert;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

/// <summary>
/// Tests for EmailImage base64 embedding functionality.
/// </summary>
[TestClass]
public class TestEmailImageBase64Embedding
{
    private string _testImagePath = string.Empty;
    private byte[] _testImageData = Array.Empty<byte>();

    [TestInitialize]
    public void TestInitialize()
    {
        // Create a simple test image (1x1 PNG)
        _testImageData = new byte[]
        {
            0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A, 0x00, 0x00, 0x00, 0x0D,
            0x49, 0x48, 0x44, 0x52, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01,
            0x08, 0x06, 0x00, 0x00, 0x00, 0x1F, 0x15, 0xC4, 0x89, 0x00, 0x00, 0x00,
            0x0A, 0x49, 0x44, 0x41, 0x54, 0x78, 0x9C, 0x63, 0x00, 0x01, 0x00, 0x00,
            0x05, 0x00, 0x01, 0x0D, 0x0A, 0x2D, 0xB4, 0x00, 0x00, 0x00, 0x00, 0x49,
            0x45, 0x4E, 0x44, 0xAE, 0x42, 0x60, 0x82
        };

        _testImagePath = Path.GetTempFileName();
        File.WriteAllBytes(_testImagePath, _testImageData);
    }

    [TestMethod]
    public void EmailImage_EmbedFromFile_ShouldEmbedValidImage()
    {
        // Arrange
        var emailImage = new EmailImage();

        // Act
        emailImage.EmbedFromFile(_testImagePath);

        // Assert
        Assert.IsTrue(emailImage.EmbedAsBase64);
        Assert.AreEqual("image/png", emailImage.MimeType);
        Assert.IsFalse(string.IsNullOrEmpty(emailImage.Base64Data));
        Assert.IsTrue(emailImage.Source.StartsWith("data:image/png;base64,"));
    }

    [TestMethod]
    public void EmailImage_EmbedFromFile_WithNonExistentFile_ShouldFallbackToPath()
    {
        // Arrange
        var emailImage = new EmailImage();
        var nonExistentPath = "non-existent-file.png";

        // Act
        emailImage.EmbedFromFile(nonExistentPath);

        // Assert
        Assert.IsFalse(emailImage.EmbedAsBase64);
        Assert.AreEqual(nonExistentPath, emailImage.Source);
    }

    [TestMethod]
    public void EmailImage_EmbedFromFile_WithDifferentExtensions_ShouldSetCorrectMimeType()
    {
        // Arrange & Act & Assert
        var testCases = new[]
        {
            (".jpg", "image/jpeg"),
            (".jpeg", "image/jpeg"),
            (".png", "image/png"),
            (".gif", "image/gif"),
            (".svg", "image/svg+xml"),
            (".webp", "image/webp"),
            (".bmp", "image/bmp"),
            (".tiff", "image/tiff"),
            (".ico", "image/x-icon"),
            (".unknown", "image/png") // Default fallback
        };

        foreach (var (extension, expectedMimeType) in testCases)
        {
            var tempFile = Path.GetTempFileName();
            var testFile = Path.ChangeExtension(tempFile, extension);
            File.Move(tempFile, testFile);
            File.WriteAllBytes(testFile, _testImageData);

            var emailImage = new EmailImage();
            emailImage.EmbedFromFile(testFile);

            Assert.AreEqual(expectedMimeType, emailImage.MimeType);
            File.Delete(testFile);
        }
    }

    [TestMethod]
    public void EmailImage_EmbedFromBase64_ShouldSetPropertiesCorrectly()
    {
        // Arrange
        var emailImage = new EmailImage();
        var base64Data = Convert.ToBase64String(_testImageData);
        var mimeType = "image/png";

        // Act
        emailImage.EmbedFromBase64(base64Data, mimeType);

        // Assert
        Assert.IsTrue(emailImage.EmbedAsBase64);
        Assert.AreEqual(mimeType, emailImage.MimeType);
        Assert.AreEqual(base64Data, emailImage.Base64Data);
        Assert.AreEqual($"data:{mimeType};base64,{base64Data}", emailImage.Source);
    }

    [TestMethod]
    public void EmailImage_EmbedSmart_WithFilePath_ShouldEmbedFile()
    {
        // Arrange
        var emailImage = new EmailImage();

        // Act
        emailImage.EmbedSmart(_testImagePath);

        // Assert
        Assert.IsTrue(emailImage.EmbedAsBase64);
        Assert.AreEqual("image/png", emailImage.MimeType);
        Assert.IsFalse(string.IsNullOrEmpty(emailImage.Base64Data));
    }

    [TestMethod]
    public void EmailImage_EmbedSmart_WithNonExistentPath_ShouldFallbackToSource()
    {
        // Arrange
        var emailImage = new EmailImage();
        var nonExistentPath = "non-existent-file.png";

        // Act
        emailImage.EmbedSmart(nonExistentPath);

        // Assert
        Assert.IsFalse(emailImage.EmbedAsBase64);
        Assert.AreEqual(nonExistentPath, emailImage.Source);
    }

    [TestMethod]
    public void EmailImage_EmbedSmart_WithEmptyString_ShouldReturnSelf()
    {
        // Arrange
        var emailImage = new EmailImage();

        // Act
        var result = emailImage.EmbedSmart("");

        // Assert
        Assert.AreSame(emailImage, result);
        Assert.IsFalse(emailImage.EmbedAsBase64);
    }

    [TestMethod]
    public void EmailImage_WithOptimization_ShouldSetOptimizationProperties()
    {
        // Arrange
        var emailImage = new EmailImage();

        // Act
        emailImage.WithOptimization(800, 600, 90);

        // Assert
        Assert.IsTrue(emailImage.OptimizeImage);
        Assert.AreEqual(800, emailImage.MaxWidth);
        Assert.AreEqual(600, emailImage.MaxHeight);
        Assert.AreEqual(90, emailImage.Quality);
    }

    [TestMethod]
    public void EmailImage_WithOptimization_ShouldClampQuality()
    {
        // Arrange
        var emailImage = new EmailImage();

        // Act & Assert
        emailImage.WithOptimization(0, 0, 150);
        Assert.AreEqual(100, emailImage.Quality);

        emailImage.WithOptimization(0, 0, -10);
        Assert.AreEqual(0, emailImage.Quality);
    }

    [TestMethod]
    public void EmailImage_WithoutOptimization_ShouldDisableOptimization()
    {
        // Arrange
        var emailImage = new EmailImage();
        emailImage.WithOptimization(800, 600, 90);

        // Act
        emailImage.WithoutOptimization();

        // Assert
        Assert.IsFalse(emailImage.OptimizeImage);
    }

    [TestMethod]
    public void EmailImage_ToString_WithEmbeddedImage_ShouldContainBase64Data()
    {
        // Arrange
        var emailImage = new EmailImage();
        emailImage.EmbedFromFile(_testImagePath);
        emailImage.WithWidth("100px");
        emailImage.WithAlternativeText("Test Image");

        // Act
        var html = emailImage.ToString();

        // Assert
        Assert.IsTrue(html.Contains("data:image/png;base64,"));
        Assert.IsTrue(html.Contains("width=\"100px\""));
        Assert.IsTrue(html.Contains("alt=\"Test Image\""));
        Assert.IsTrue(html.Contains("<img"));
    }

    [TestMethod]
    public void EmailImage_ToString_WithLink_ShouldWrapInAnchor()
    {
        // Arrange
        var emailImage = new EmailImage();
        emailImage.EmbedFromFile(_testImagePath);
        emailImage.WithLink("https://example.com", true);

        // Act
        var html = emailImage.ToString();

        // Assert
        Assert.IsTrue(html.Contains("<a href=\"https://example.com\""));
        Assert.IsTrue(html.Contains("target=\"_blank\""));
        Assert.IsTrue(html.Contains("</a>"));
    }

    [TestMethod]
    public void EmailImage_ToString_WithStyling_ShouldIncludeStyles()
    {
        // Arrange
        var emailImage = new EmailImage();
        emailImage.EmbedFromFile(_testImagePath);
        emailImage.WithBorder("2px solid red");
        emailImage.WithBorderRadius("8px");
        emailImage.WithAlignment("center");

        // Act
        var html = emailImage.ToString();

        // Assert
        Assert.IsTrue(html.Contains("border: 2px solid red"));
        Assert.IsTrue(html.Contains("border-radius: 8px"));
        Assert.IsTrue(html.Contains("text-align: center"));
    }

    [TestMethod]
    public void EmailImage_ChainedMethods_ShouldReturnSelf()
    {
        // Arrange
        var emailImage = new EmailImage();

        // Act
        var result = emailImage
            .EmbedFromFile(_testImagePath)
            .WithWidth("100px")
            .WithHeight("100px")
            .WithOptimization(200, 200, 80)
            .WithAlignment("center")
            .WithBorder("1px solid black")
            .WithBorderRadius("4px")
            .WithLink("https://example.com")
            .WithAlternativeText("Chained image");

        // Assert
        Assert.AreSame(emailImage, result);
        Assert.IsTrue(emailImage.EmbedAsBase64);
        Assert.AreEqual("100px", emailImage.Width);
        Assert.AreEqual("100px", emailImage.Height);
        Assert.IsTrue(emailImage.OptimizeImage);
        Assert.AreEqual("center", emailImage.Alignment);
        Assert.AreEqual("1px solid black", emailImage.Border);
        Assert.AreEqual("4px", emailImage.BorderRadius);
        Assert.AreEqual("https://example.com", emailImage.LinkUrl);
        Assert.AreEqual("Chained image", emailImage.AlternativeText);
    }

    [TestMethod]
    public void EmailImage_GetMimeTypeFromExtension_ShouldReturnCorrectTypes()
    {
        // This tests the private method indirectly through EmbedFromFile
        var testCases = new[]
        {
            (".jpg", "image/jpeg"),
            (".jpeg", "image/jpeg"),
            (".png", "image/png"),
            (".gif", "image/gif"),
            (".svg", "image/svg+xml"),
            (".webp", "image/webp"),
            (".bmp", "image/bmp"),
            (".tiff", "image/tiff"),
            (".tif", "image/tiff"),
            (".ico", "image/x-icon"),
            (".unknown", "image/png")
        };

        foreach (var (extension, expectedMimeType) in testCases)
        {
            var tempFile = Path.GetTempFileName();
            var testFile = Path.ChangeExtension(tempFile, extension);
            File.Move(tempFile, testFile);
            File.WriteAllBytes(testFile, _testImageData);

            var emailImage = new EmailImage();
            emailImage.EmbedFromFile(testFile);

            Assert.AreEqual(expectedMimeType, emailImage.MimeType);
            File.Delete(testFile);
        }
    }

    [TestMethod]
    public void EmailImage_EmbedFromFile_WithOptimization_ShouldLogOptimizationNote()
    {
        // Arrange
        var emailImage = new EmailImage();
        emailImage.WithOptimization(100, 100, 80);

        // Capture console output
        var originalOut = Console.Out;
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        try
        {
            // Act
            emailImage.EmbedFromFile(_testImagePath);

            // Assert
            var output = stringWriter.ToString();
            Assert.IsTrue(output.Contains("Note: Image optimization is enabled but not yet implemented"));
        }
        finally
        {
            Console.SetOut(originalOut);
        }
    }

    [TestMethod]
    public void EmailImage_EmbedFromUrl_WithInvalidUrl_ShouldFallbackToUrl()
    {
        // Arrange
        var emailImage = new EmailImage();
        var invalidUrl = "https://invalid-url-that-does-not-exist.com/image.png";

        // Act
        emailImage.EmbedFromUrl(invalidUrl, 1); // 1 second timeout

        // Assert
        Assert.IsFalse(emailImage.EmbedAsBase64);
        Assert.AreEqual(invalidUrl, emailImage.Source);
    }

    [TestMethod]
    public void EmailImage_EmbedSmart_WithHttpUrl_ShouldAttemptUrlEmbedding()
    {
        // Arrange
        var emailImage = new EmailImage();
        var httpUrl = "http://example.com/image.png";

        // Act
        emailImage.EmbedSmart(httpUrl, 1); // 1 second timeout

        // Assert
        // Should fallback to URL since it's not a valid image URL
        Assert.IsFalse(emailImage.EmbedAsBase64);
        Assert.AreEqual(httpUrl, emailImage.Source);
    }

    [TestMethod]
    public void EmailImage_EmbedSmart_WithHttpsUrl_ShouldAttemptUrlEmbedding()
    {
        // Arrange
        var emailImage = new EmailImage();
        var httpsUrl = "https://example.com/image.png";

        // Act
        emailImage.EmbedSmart(httpsUrl, 1); // 1 second timeout

        // Assert
        // Should fallback to URL since it's not a valid image URL
        Assert.IsFalse(emailImage.EmbedAsBase64);
        Assert.AreEqual(httpsUrl, emailImage.Source);
    }

    [TestMethod]
    public void EmailImage_ToString_WithEmbedAsBase64WithoutMimeType_ShouldThrow()
    {
        // Arrange
        var emailImage = new EmailImage
        {
            Base64Data = Convert.ToBase64String(_testImageData),
            EmbedAsBase64 = true,
            Source = $"data:;base64,{Convert.ToBase64String(_testImageData)}"
        };

        // Act & Assert
        Assert.ThrowsException<InvalidOperationException>(() => emailImage.ToString());
    }

    [TestMethod]
    public void EmailImage_ToString_WithEmbedFromBase64_ShouldContainDataUri()
    {
        // Arrange
        var emailImage = new EmailImage();
        var base64Data = Convert.ToBase64String(_testImageData);
        emailImage.EmbedFromBase64(base64Data, "image/png");

        // Act
        var html = emailImage.ToString();

        // Assert
        Assert.IsTrue(html.Contains($"data:image/png;base64,{base64Data}"));
    }

    [TestCleanup]
    public void TestCleanup()
    {
        if (File.Exists(_testImagePath))
        {
            File.Delete(_testImagePath);
        }
    }
}