using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestWhitespaceOutput {
    [TestMethod]
    public void Document_ToString_WhitespaceMatchesBaseline() {
        using var doc = new Document();
        doc.Body.Add(new HtmlTag("p", "Hello"));
        var html = doc.ToString();

        string baselinePath = Path.Combine(AppContext.BaseDirectory, "Baselines", "whitespace_basic.txt");
        bool updateBaselines = Environment.GetEnvironmentVariable("UPDATE_BASELINES")?.Equals("true", StringComparison.OrdinalIgnoreCase) == true;
        if (!File.Exists(baselinePath) || updateBaselines) {
            File.WriteAllText(baselinePath, html);
        } else {
            string baseline = File.ReadAllText(baselinePath);
            Assert.AreEqual(baseline, html, "Generated HTML does not match baseline.");
        }
    }
}
