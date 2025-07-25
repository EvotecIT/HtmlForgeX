using System;

using HtmlTinkerX;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public static class TestPlaywrightSetup {
    [AssemblyInitialize]
    public static void AssemblyInit(TestContext context) {
        try {
            HtmlBrowser.EnsureInstalledAsync(HtmlBrowserEngine.Chromium).GetAwaiter().GetResult();
        } catch (Exception ex) {
            Assert.Inconclusive($"Playwright browser install failed: {ex.Message}");
        }
    }
}