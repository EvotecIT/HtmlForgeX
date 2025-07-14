using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

/// <summary>
/// Tests encoding behavior when building nested HTML tags.
/// </summary>
[TestClass]
public class TestHtmlTagEncoding {
    [TestMethod]
    public void HtmlTagNestedValueCallsPreserveOrder() {
        var tag = new HtmlTag("div")
            .Value("Start ")
            .Value(new HtmlTag("span").Value("inner"))
            .Value(" middle ")
            .Value(new HtmlTag("strong").Value("bold"))
            .Value(" end");

        const string expected = "<div>Start <span>inner</span> middle <strong>bold</strong> end</div>";
        Assert.AreEqual(expected, tag.ToString());
    }
}
