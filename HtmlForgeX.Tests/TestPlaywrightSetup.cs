using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Playwright;

namespace HtmlForgeX.Tests;

[TestClass]
public static class TestPlaywrightSetup {
    [AssemblyInitialize]
    public static void AssemblyInit(TestContext context) {
        try {
            Microsoft.Playwright.Program.Main(new[] { "install" });
        } catch (Exception ex) {
            Assert.Inconclusive($"Playwright browser install failed: {ex.Message}");
        }
    }
}
