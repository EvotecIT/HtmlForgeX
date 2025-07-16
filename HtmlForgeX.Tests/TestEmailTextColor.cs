using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestEmailTextColor {
    [TestMethod]
    public void WithColor_ShouldRenderColorStyle() {
        var text = new EmailText("demo").WithColor("#FF0000");
        var html = text.ToString();
        StringAssert.Contains(html, "color: #FF0000");
    }
}
