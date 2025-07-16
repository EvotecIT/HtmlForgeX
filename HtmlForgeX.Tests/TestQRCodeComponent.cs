using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestQRCodeComponent {

    [TestMethod]
    public void QRCode_BasicCreation() {
        using var doc = new Document();
        
        doc.Body.Add(element => {
            element.QRCode("https://evotec.xyz");
        });
        
        var html = doc.ToString();
        
        // Should contain QR code element and library
        Assert.IsTrue(html.Contains("qrcode") || html.Contains("QRCode"), "Should contain QR code element");
        Assert.IsTrue(html.Contains("https://evotec.xyz"), "Should contain QR code data");
        Assert.IsTrue(html.Contains("easy.qrcode") || html.Contains("qrcode"), "Should include QR code library");
    }

    [TestMethod]
    public void QRCode_MultipleInstances() {
        using var doc = new Document();
        
        doc.Body.Add(element => {
            element.QRCode("https://example1.com");
        });
        
        doc.Body.Add(element => {
            element.QRCode("https://example2.com");
        });
        
        var html = doc.ToString();
        
        // Should contain both QR codes
        Assert.IsTrue(html.Contains("https://example1.com"), "Should contain first QR code data");
        Assert.IsTrue(html.Contains("https://example2.com"), "Should contain second QR code data");
        
        // Library should only be included once
        var libraryCount = html.Split(new string[] { "easy.qrcode" }, StringSplitOptions.None).Length - 1;
        Assert.IsTrue(libraryCount <= 2, "QR code library should not be excessively duplicated");
    }

    [TestMethod]
    public void QRCode_OnlineMode_UsesCDN() {
        using var doc = new Document();
        doc.LibraryMode = LibraryMode.Online;
        
        doc.Body.Add(element => {
            element.QRCode("https://cdn.example.com");
        });
        
        var html = doc.ToString();
        
        // Should use CDN link in online mode
        Assert.IsTrue(html.Contains("https://cdn.jsdelivr.net"), "Should use CDN in online mode");
        Assert.IsTrue(html.Contains("easy.qrcode.min.js"), "Should reference QR code library");
    }

    [TestMethod]
    public void QRCode_OfflineMode_EmbedLibrary() {
        using var doc = new Document();
        doc.LibraryMode = LibraryMode.Offline;
        
        doc.Body.Add(element => {
            element.QRCode("https://offline.example.com");
        });
        
        var html = doc.ToString();
        
        // Should embed library in offline mode
        Assert.IsTrue(html.Contains("QRCode") && html.Contains("<script>"), "Should embed QR code library");
        Assert.IsFalse(html.Contains("cdn.jsdelivr.net"), "Should not use CDN in offline mode");
        Assert.IsTrue(html.Contains("https://offline.example.com"), "Should contain QR code data");
    }

    [TestMethod]
    public void QRCode_WithSpecialCharacters() {
        using var doc = new Document();
        
        doc.Body.Add(element => {
            element.QRCode("Hello, World! 特殊字符 🎉");
        });
        
        var html = doc.ToString();
        
        // Should handle special characters properly
        Assert.IsTrue(html.Contains("Hello, World!"), "Should contain basic text");
        Assert.IsTrue(html.Contains("特殊字符") || html.Contains("🎉"), "Should handle special characters");
    }

    [TestMethod]
    public void QRCode_EmptyString() {
        using var doc = new Document();
        
        doc.Body.Add(element => {
            element.QRCode("");
        });
        
        var html = doc.ToString();
        
        // Should handle empty string gracefully
        Assert.IsTrue(html.Contains("qrcode") || html.Contains("QRCode"), "Should still create QR code element");
        Assert.IsTrue(html.Contains("\"text\": \"\""), "Should contain empty text property");
    }

    [TestMethod]
    public void QRCode_LongURL() {
        using var doc = new Document();
        var longUrl = "https://example.com/very/long/path/with/many/parameters?param1=value1&param2=value2&param3=value3&param4=value4&param5=value5&param6=value6";
        
        doc.Body.Add(element => {
            element.QRCode(longUrl);
        });
        
        var html = doc.ToString();
        
        // Should handle long URLs
        Assert.IsTrue(html.Contains("https://example.com/very/long/path"), "Should contain part of long URL");
        Assert.IsTrue(html.Contains("qrcode") || html.Contains("QRCode"), "Should create QR code element");
    }

    [TestMethod]
    public void QRCode_UniqueIDs() {
        using var doc = new Document();
        
        doc.Body.Add(element => {
            element.QRCode("QR1");
        });
        
        doc.Body.Add(element => {
            element.QRCode("QR2");
        });
        
        var html = doc.ToString();
        
        // Should generate unique IDs for each QR code
        var qrCodeMatches = System.Text.RegularExpressions.Regex.Matches(html, @"id=""QrCode-[^""]+""");
        Assert.IsTrue(qrCodeMatches.Count >= 2, "Should have at least 2 QR code elements with unique IDs");
        
        // Verify IDs are different
        if (qrCodeMatches.Count >= 2) {
            Assert.AreNotEqual(qrCodeMatches[0].Value, qrCodeMatches[1].Value, "QR code IDs should be unique");
        }
    }

    [TestMethod]
    public void QRCode_TextWithQuotesAndNewlines() {
        using var doc = new Document();

        doc.Body.Add(element => {
            element.QRCode("Line1\n\"Quoted\"");
        });

        var html = doc.ToString();

        var encoded = JsonSerializer.Serialize("Line1\n\"Quoted\"",
            new JsonSerializerOptions { Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping });

        Assert.IsTrue(html.Contains(encoded), "QR data should be JSON-encoded with escaped characters");
    }

    [TestMethod]
    public void QRCode_LibraryRegistration() {
        using var doc = new Document();
        
        // Before adding QR code
        Assert.IsFalse(doc.Configuration.Libraries.ContainsKey(Libraries.EasyQRCode), 
            "EasyQRCode library should not be registered initially");
        
        doc.Body.Add(element => {
            element.QRCode("test");
        });
        
        // Generate HTML to trigger library registration
        var html = doc.ToString();
        
        // After adding QR code, library should be registered
        Assert.IsTrue(doc.Configuration.Libraries.ContainsKey(Libraries.EasyQRCode), 
            "EasyQRCode library should be registered after adding QR code");
    }
}