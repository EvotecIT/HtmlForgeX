using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Playwright;

namespace HtmlForgeX.Tests;

/// <summary>
/// Integration tests verifying rendered HTML layout using Playwright.
/// </summary>
[TestClass]
public class TestHeadlessRendering {
    [TestMethod]
    public async Task GeneratedHtml_ShouldMatchBaselineScreenshot() {
        string tempDir = Path.Combine(TestUtilities.GetFrameworkSpecificTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(tempDir);
        string htmlPath = Path.Combine(tempDir, "index.html");

        var doc = new Document();
        doc.Head.Title = "Integration Test";
        doc.Body.Add(new HtmlTag("h1", "Hello world!"));
        doc.Save(htmlPath);

        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
        var page = await browser.NewPageAsync();
        await page.GotoAsync(new Uri(htmlPath).AbsoluteUri);
        await page.SetViewportSizeAsync(800, 600);
        string screenshotPath = Path.Combine(tempDir, "screenshot.png");
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = screenshotPath });

        string baselinePath = Path.Combine(AppContext.BaseDirectory, "Baselines", "basic_layout.png");

        bool updateBaselines = Environment.GetEnvironmentVariable("UPDATE_BASELINES")?.Equals("true", StringComparison.OrdinalIgnoreCase) == true;
        if (!File.Exists(baselinePath) || updateBaselines) {
            File.Copy(screenshotPath, baselinePath, true);
        } else {
            byte[] baselineBytes = await File.ReadAllBytesAsync(baselinePath);
            byte[] screenshotBytes = await File.ReadAllBytesAsync(screenshotPath);
            CollectionAssert.AreEqual(baselineBytes, screenshotBytes, "Rendered layout does not match baseline screenshot.");
        }
    }
}
