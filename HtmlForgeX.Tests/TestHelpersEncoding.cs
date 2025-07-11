using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestHelpersEncoding {
    [TestMethod]
    public void HtmlEncode_EncodesSpecialCharacters() {
        var encoded = Helpers.HtmlEncode("<div class=\"t\">&</div>");
        Assert.AreEqual("&lt;div class=&quot;t&quot;&gt;&amp;&lt;/div&gt;", encoded);
    }

    [TestMethod]
    public void Open_ReturnsTrueWhenDisabled() {
        var result = Helpers.Open("dummy", false);
        Assert.IsTrue(result);
    }
}