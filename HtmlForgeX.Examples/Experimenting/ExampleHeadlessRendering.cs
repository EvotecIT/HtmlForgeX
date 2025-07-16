using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace HtmlForgeX.Examples.Experimenting;

internal class ExampleHeadlessRendering {
    public static async Task CreateAsync(bool openInBrowser = false) {
        var doc = new Document();
        doc.Head.Title = "Headless Rendering Example";
        doc.Body.Add(new HtmlTag("h1", "Hello from Headless Browser"));
        var path = Path.Combine(Path.GetTempPath(), "headless_example.html");
        doc.Save(path, openInBrowser);

        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
        var page = await browser.NewPageAsync();
        await page.GotoAsync(new Uri(path).AbsoluteUri);
        await page.SetViewportSizeAsync(800, 600);
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = Path.Combine(Path.GetTempPath(), "headless_example.png") });
    }
}
