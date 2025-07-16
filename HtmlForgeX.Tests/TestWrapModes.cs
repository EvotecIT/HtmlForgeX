using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestWrapModes
{
    [DataTestMethod]
    [DataRow(EmailTextWrapMode.Default, "word-wrap: break-word")]
    [DataRow(EmailTextWrapMode.Natural, "white-space: normal")]
    [DataRow(EmailTextWrapMode.Aggressive, "word-break: break-all")]
    [DataRow(EmailTextWrapMode.Preserve, "white-space: pre")]
    [DataRow(EmailTextWrapMode.Hyphenated, "hyphens: auto")]
    [DataRow(EmailTextWrapMode.Smart, "letter-spacing: -0.02em")]
    public void EmailText_WithWrapMode_AddsCss(EmailTextWrapMode mode, string expected)
    {
        var html = new EmailText("demo").WithWrapMode(mode).ToString();
        StringAssert.Contains(html, expected);
    }
}
