using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

/// <summary>
/// Validates newline handling in <see cref="HtmlTag"/> across platforms.
/// </summary>
[TestClass]
public class TestHtmlTagNewLine {
    [TestMethod]
    public void HtmlTag_ToString_RespectsEnvironmentNewLine() {
        var newline = Environment.NewLine;
        var tag = new HtmlTag("pre").Value($"line1{newline}line2");
        var expected = $"<pre>line1{newline}line2</pre>";
        Assert.AreEqual(expected, tag.ToString());
    }
}