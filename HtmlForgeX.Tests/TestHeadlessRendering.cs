using System;
using System.IO;
using System.Threading.Tasks;

using HtmlTinkerX;

using Microsoft.Playwright;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

/// <summary>
/// Integration tests verifying rendered HTML layout using Playwright.
/// </summary>
[TestClass]
public class TestHeadlessRendering {
    [TestMethod]
    public async Task GeneratedHtml_ShouldMatchBaselineScreenshot() {
        string tempDir = Path.Combine(TempPath.Get(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(tempDir);
        string htmlPath = Path.Combine(tempDir, "index.html");

        using var doc = new Document();
        doc.Head.Title = "Integration Test";
        doc.Body.Add(new HtmlTag("h1", "Hello world!"));
        doc.Save(htmlPath);

        await HtmlBrowser.EnsureInstalledAsync(HtmlBrowserEngine.Chromium);
        using var playwright = await Playwright.CreateAsync();
        IBrowser? browser;
        try {
            browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
        } catch (PlaywrightException ex) {
            Assert.Inconclusive($"Playwright is unavailable: {ex.Message}");
            return;
        }
        await using var _ = browser;
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
#if NET472
            byte[] baselineBytes = File.ReadAllBytes(baselinePath);
            byte[] screenshotBytes = File.ReadAllBytes(screenshotPath);
#else
            byte[] baselineBytes = await File.ReadAllBytesAsync(baselinePath);
            byte[] screenshotBytes = await File.ReadAllBytesAsync(screenshotPath);
#endif
            CollectionAssert.AreEqual(baselineBytes, screenshotBytes, "Rendered layout does not match baseline screenshot.");
        }
    }
}