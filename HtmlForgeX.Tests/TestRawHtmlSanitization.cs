using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestRawHtmlSanitization {
    [TestMethod]
    public void RawHtml_RemovesScriptTags_WhenSanitizeEnabled() {
        var raw = new RawHtml("<script>alert('x')</script><p>ok</p>", true);
        Assert.AreEqual("<p>ok</p>", raw.ToString());
    }

    [TestMethod]
    public void HtmlTag_ValueRaw_SanitizesContent() {
        var tag = new HtmlTag("div").ValueRaw("<script>alert('x')</script><span>hi</span>", true);
        Assert.AreEqual("<div><span>hi</span></div>", tag.ToString());
    }
}