using System;
using System.IO;
using System.Text;
using Xunit;
using Assert = Xunit.Assert;

namespace HtmlForgeX.Tests;

/// <summary>
/// Tests for EmailImage base64 embedding functionality.
/// </summary>
public class TestEmailImageBase64Embedding
{
    private readonly string _testImagePath;
    private readonly byte[] _testImageData;

    public TestEmailImageBase64Embedding()
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

    [Fact]
    public void EmailImage_EmbedFromFile_ShouldEmbedValidImage()
    {
        // Arrange
        var emailImage = new EmailImage();

        // Act
        emailImage.EmbedFromFile(_testImagePath);

        // Assert
        Assert.True(emailImage.EmbedAsBase64);
        Assert.Equal("image/png", emailImage.MimeType);
        Assert.NotEmpty(emailImage.Base64Data);
        Assert.StartsWith("data:image/png;base64,", emailImage.Source);
    }

    [Fact]
    public void EmailImage_EmbedFromFile_WithNonExistentFile_ShouldFallbackToPath()
    {
        // Arrange
        var emailImage = new EmailImage();
        var nonExistentPath = "non-existent-file.png";

        // Act
        emailImage.EmbedFromFile(nonExistentPath);

        // Assert
        Assert.False(emailImage.EmbedAsBase64);
        Assert.Equal(nonExistentPath, emailImage.Source);
    }

    [Fact]
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

            Assert.Equal(expectedMimeType, emailImage.MimeType);
            File.Delete(testFile);
        }
    }

    [Fact]
    public void EmailImage_EmbedFromBase64_ShouldSetPropertiesCorrectly()
    {
        // Arrange
        var emailImage = new EmailImage();
        var base64Data = Convert.ToBase64String(_testImageData);
        var mimeType = "image/png";

        // Act
        emailImage.EmbedFromBase64(base64Data, mimeType);

        // Assert
        Assert.True(emailImage.EmbedAsBase64);
        Assert.Equal(mimeType, emailImage.MimeType);
        Assert.Equal(base64Data, emailImage.Base64Data);
        Assert.Equal($"data:{mimeType};base64,{base64Data}", emailImage.Source);
    }

    [Fact]
    public void EmailImage_EmbedSmart_WithFilePath_ShouldEmbedFile()
    {
        // Arrange
        var emailImage = new EmailImage();

        // Act
        emailImage.EmbedSmart(_testImagePath);

        // Assert
        Assert.True(emailImage.EmbedAsBase64);
        Assert.Equal("image/png", emailImage.MimeType);
        Assert.NotEmpty(emailImage.Base64Data);
    }

    [Fact]
    public void EmailImage_EmbedSmart_WithNonExistentPath_ShouldFallbackToSource()
    {
        // Arrange
        var emailImage = new EmailImage();
        var nonExistentPath = "non-existent-file.png";

        // Act
        emailImage.EmbedSmart(nonExistentPath);

        // Assert
        Assert.False(emailImage.EmbedAsBase64);
        Assert.Equal(nonExistentPath, emailImage.Source);
    }

    [Fact]
    public void EmailImage_EmbedSmart_WithEmptyString_ShouldReturnSelf()
    {
        // Arrange
        var emailImage = new EmailImage();

        // Act
        var result = emailImage.EmbedSmart("");

        // Assert
        Assert.Same(emailImage, result);
        Assert.False(emailImage.EmbedAsBase64);
    }

    [Fact]
    public void EmailImage_WithOptimization_ShouldSetOptimizationProperties()
    {
        // Arrange
        var emailImage = new EmailImage();

        // Act
        emailImage.WithOptimization(800, 600, 90);

        // Assert
        Assert.True(emailImage.OptimizeImage);
        Assert.Equal(800, emailImage.MaxWidth);
        Assert.Equal(600, emailImage.MaxHeight);
        Assert.Equal(90, emailImage.Quality);
    }

    [Fact]
    public void EmailImage_WithOptimization_ShouldClampQuality()
    {
        // Arrange
        var emailImage = new EmailImage();

        // Act & Assert
        emailImage.WithOptimization(0, 0, 150);
        Assert.Equal(100, emailImage.Quality);

        emailImage.WithOptimization(0, 0, -10);
        Assert.Equal(0, emailImage.Quality);
    }

    [Fact]
    public void EmailImage_WithoutOptimization_ShouldDisableOptimization()
    {
        // Arrange
        var emailImage = new EmailImage();
        emailImage.WithOptimization(800, 600, 90);

        // Act
        emailImage.WithoutOptimization();

        // Assert
        Assert.False(emailImage.OptimizeImage);
    }

    [Fact]
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
        Assert.Contains("data:image/png;base64,", html);
        Assert.Contains("width=\"100px\"", html);
        Assert.Contains("alt=\"Test Image\"", html);
        Assert.Contains("<img", html);
    }

    [Fact]
    public void EmailImage_ToString_WithLink_ShouldWrapInAnchor()
    {
        // Arrange
        var emailImage = new EmailImage();
        emailImage.EmbedFromFile(_testImagePath);
        emailImage.WithLink("https://example.com", true);

        // Act
        var html = emailImage.ToString();

        // Assert
        Assert.Contains("<a href=\"https://example.com\"", html);
        Assert.Contains("target=\"_blank\"", html);
        Assert.Contains("</a>", html);
    }

    [Fact]
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
        Assert.Contains("border: 2px solid red", html);
        Assert.Contains("border-radius: 8px", html);
        Assert.Contains("text-align: center", html);
    }

    [Fact]
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
        Assert.Same(emailImage, result);
        Assert.True(emailImage.EmbedAsBase64);
        Assert.Equal("100px", emailImage.Width);
        Assert.Equal("100px", emailImage.Height);
        Assert.True(emailImage.OptimizeImage);
        Assert.Equal("center", emailImage.Alignment);
        Assert.Equal("1px solid black", emailImage.Border);
        Assert.Equal("4px", emailImage.BorderRadius);
        Assert.Equal("https://example.com", emailImage.LinkUrl);
        Assert.Equal("Chained image", emailImage.AlternativeText);
    }

    [Fact]
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

            Assert.Equal(expectedMimeType, emailImage.MimeType);
            File.Delete(testFile);
        }
    }

    [Fact]
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
            Assert.Contains("Note: Image optimization is enabled but not yet implemented", output);
        }
        finally
        {
            Console.SetOut(originalOut);
        }
    }

    [Fact]
    public void EmailImage_EmbedFromUrl_WithInvalidUrl_ShouldFallbackToUrl()
    {
        // Arrange
        var emailImage = new EmailImage();
        var invalidUrl = "https://invalid-url-that-does-not-exist.com/image.png";

        // Act
        emailImage.EmbedFromUrl(invalidUrl, 1); // 1 second timeout

        // Assert
        Assert.False(emailImage.EmbedAsBase64);
        Assert.Equal(invalidUrl, emailImage.Source);
    }

    [Fact]
    public void EmailImage_EmbedSmart_WithHttpUrl_ShouldAttemptUrlEmbedding()
    {
        // Arrange
        var emailImage = new EmailImage();
        var httpUrl = "http://example.com/image.png";

        // Act
        emailImage.EmbedSmart(httpUrl, 1); // 1 second timeout

        // Assert
        // Should fallback to URL since it's not a valid image URL
        Assert.False(emailImage.EmbedAsBase64);
        Assert.Equal(httpUrl, emailImage.Source);
    }

    [Fact]
    public void EmailImage_EmbedSmart_WithHttpsUrl_ShouldAttemptUrlEmbedding()
    {
        // Arrange
        var emailImage = new EmailImage();
        var httpsUrl = "https://example.com/image.png";

        // Act
        emailImage.EmbedSmart(httpsUrl, 1); // 1 second timeout

        // Assert
        // Should fallback to URL since it's not a valid image URL
        Assert.False(emailImage.EmbedAsBase64);
        Assert.Equal(httpsUrl, emailImage.Source);
    }

    // Cleanup
    public void Dispose()
    {
        if (File.Exists(_testImagePath))
        {
            File.Delete(_testImagePath);
        }
    }
}