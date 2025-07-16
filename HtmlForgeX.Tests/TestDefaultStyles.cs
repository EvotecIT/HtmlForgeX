using System;
using System.Linq;
using System.Text.RegularExpressions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

/// <summary>
/// Validates that the built-in style helpers inject expected CSS rules.
/// </summary>
[TestClass]
public class TestDefaultStyles {
    [TestMethod]
    public void DefaultStyles_ShouldParseCss() {
        using var doc = new Document();
        doc.Head.AddDefaultStyles();
        string headHtml = doc.Head.ToString();
        var match = Regex.Match(headHtml, "<style.*?>(.*?)</style>", RegexOptions.Singleline);
        Assert.IsTrue(match.Success, "Style tag not found");
        string css = match.Groups[1].Value;
        var lines = css.Split('\n');
        foreach (var line in lines) {
            var trimmed = line.Trim();
            if (string.IsNullOrEmpty(trimmed) || trimmed.StartsWith("/*") || trimmed.EndsWith("{") || trimmed.EndsWith("}")) {
                continue;
            }
            if (trimmed.Contains(":")) {
                Assert.IsTrue(trimmed.TrimEnd().EndsWith(";"), $"CSS line missing semicolon: {trimmed}");
            }
        }
    }
}