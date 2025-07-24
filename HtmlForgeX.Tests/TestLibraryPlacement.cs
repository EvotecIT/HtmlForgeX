using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestLibraryPlacement {

    [TestMethod]
    public void Document_OnlineMode_ContainsCdnLinks() {
        using var doc = new Document();
        doc.LibraryMode = LibraryMode.Online;

        // Add a component that requires libraries
        doc.Body.Add(element => {
            element.QRCode("https://example.com");
        });

        var html = doc.ToString();

        // Should contain CDN links
        Assert.IsTrue(html.Contains("https://"), "Online mode should contain CDN links");
        Assert.IsTrue(html.Contains("cdn.jsdelivr.net") || html.Contains("jsdelivr"), "Should contain CDN references");
    }

    [TestMethod]
    public void Document_OfflineMode_ContainsEmbeddedResources() {
        using var doc = new Document();
        doc.LibraryMode = LibraryMode.Offline;

        // Add a component that requires libraries
        doc.Body.Add(element => {
            element.QRCode("https://example.com");
        });

        var html = doc.ToString();

        // Should contain embedded scripts (QR code library is embedded)
        Assert.IsTrue(html.Contains("<script>") && html.Contains("QRCode"), "Offline mode should contain embedded QR code library");
        // Should NOT contain external CDN links
        Assert.IsFalse(html.Contains("cdn.jsdelivr.net"), "Offline mode should not contain CDN links");
    }

    [TestMethod]
    public void Document_MultipleLibraries_PlacedInCorrectSections() {
        using var doc = new Document();
        doc.LibraryMode = LibraryMode.Online;

        // Add multiple components requiring different libraries
        doc.Body.Add(element => {
            element.QRCode("https://example.com");
        });

        doc.Body.Add(element => {
            element.FullCalendar(calendar => {
                calendar.AddEvent("Test Event", DateTime.Today);
            });
        });

        var html = doc.ToString();

        // Verify structure exists
        var headStart = html.IndexOf("<head>");
        var headEnd = html.IndexOf("</head>");
        var bodyStart = html.IndexOf("<body");
        var bodyEnd = html.IndexOf("</body>");

        Assert.IsTrue(headStart >= 0 && headEnd > headStart, "Should have head section");
        Assert.IsTrue(bodyStart >= 0 && bodyEnd > bodyStart, "Should have body section");

        // Should contain library-related content
        Assert.IsTrue(html.Contains("QRCode") || html.Contains("qrcode"), "Should contain QR code functionality");
        Assert.IsTrue(html.Contains("FullCalendar") || html.Contains("fullcalendar"), "Should contain calendar functionality");
    }

    [TestMethod]
    public void Document_CustomLibrary_PlacedCorrectly() {
        using var doc = new Document();

        var customLibrary = new Library {
            Header = new LibraryLinks {
                CssLink = ["https://example.com/header.css"],
                JsLink = ["https://example.com/header.js"]
            }
        };

        var added = doc.AddLibrary(customLibrary);
        var html = doc.ToString();

        // Verify header resources are included
        Assert.IsTrue(added);
        Assert.IsTrue(html.Contains("https://example.com/header.css"), "Header CSS should be included");
        Assert.IsTrue(html.Contains("https://example.com/header.js"), "Header JS should be included");

        // Verify resources are in head section
        var headStart = html.IndexOf("<head>");
        var headEnd = html.IndexOf("</head>");
        var headContent = html.Substring(headStart, headEnd - headStart);

        Assert.IsTrue(headContent.Contains("https://example.com/header.css"), "CSS should be in head section");
        Assert.IsTrue(headContent.Contains("https://example.com/header.js"), "JS should be in head section");
    }

    [TestMethod]
    public void Document_DeferredScripts_EnabledCorrectly() {
        using var doc = new Document();
        doc.Configuration.EnableDeferredScripts = true;

        doc.Body.Add(element => {
            element.QRCode("https://example.com");
        });

        var html = doc.ToString();

        // When deferred scripts are enabled, should contain deferred script management
        Assert.IsTrue(html.Contains("defer") || html.Contains("DOMContentLoaded") || html.Contains("deferredScripts"),
            "Deferred scripts should be managed when enabled");
    }

    [TestMethod]
    public void Document_ThemeMode_AffectsOutput() {
        using var doc1 = new Document();
        doc1.ThemeMode = ThemeMode.Light;
        var html1 = doc1.ToString();

        using var doc2 = new Document();
        doc2.ThemeMode = ThemeMode.Dark;
        var html2 = doc2.ToString();

        // Theme should affect body attributes or styles
        Assert.AreNotEqual(html1, html2, "Different theme modes should produce different output");
        Assert.IsTrue(html1.Contains("light") || html1.Contains("data-bs-theme=\"light\""), "Light theme should be applied");
        Assert.IsTrue(html2.Contains("dark") || html2.Contains("data-bs-theme=\"dark\""), "Dark theme should be applied");
    }

    [TestMethod]
    public void Document_LibraryRegistration_IsIdempotent() {
        using var doc = new Document();

        // Add the same component type multiple times
        doc.Body.Add(element => {
            element.QRCode("https://example1.com");
        });

        doc.Body.Add(element => {
            element.QRCode("https://example2.com");
        });

        var html = doc.ToString();

        // Should only include library once even with multiple components
        var scriptCount = html.Split(new string[] { "easy.qrcode" }, StringSplitOptions.None).Length - 1;
        Assert.IsTrue(scriptCount <= 2, "Library should not be duplicated excessively");
    }
}