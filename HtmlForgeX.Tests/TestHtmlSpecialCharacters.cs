using HtmlForgeX.Tags;
using System.Collections.Generic;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestHtmlSpecialCharacters {
    [TestMethod]
    public void HtmlTagEscapesContentWithSpecialCharacters() {
        var tag = new HtmlTag("p", "5 > 3 & \"quote\" 'single' <tag>");
        Assert.AreEqual("<p>5 &gt; 3 &amp; &quot;quote&quot; &#39;single&#39; &lt;tag&gt;</p>", tag.ToString());
    }

    [TestMethod]
    public void HtmlTagEscapesAttributeValuesWithSpecialCharacters() {
        var tag = new HtmlTag("input", string.Empty, new Dictionary<string, object> { { "value", "He said \"Hello\" & <welcome>" } }, TagMode.SelfClosing);
        Assert.AreEqual("<input value=\"He said &quot;Hello&quot; &amp; &lt;welcome&gt;\"/>", tag.ToString());
    }
}
