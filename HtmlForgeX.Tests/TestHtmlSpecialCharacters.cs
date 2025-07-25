using System.Collections.Generic;

using HtmlForgeX.Tags;

namespace HtmlForgeX.Tests;

/// <summary>
/// Ensures special characters inside tags are handled as expected.
/// </summary>
[TestClass]
public class TestHtmlSpecialCharacters {
    [TestMethod]
    public void HtmlTagEscapesContentWithSpecialCharacters() {
        var tag = new HtmlTag("p", "5 > 3 & \"quote\" 'single' <tag>");
        Assert.AreEqual("<p>5 > 3 & \"quote\" 'single' <tag></p>", tag.ToString());
    }

    [TestMethod]
    public void HtmlTagEscapesAttributeValuesWithSpecialCharacters() {
        var tag = new HtmlTag("input", string.Empty, new Dictionary<string, object> { { "value", "He said \"Hello\" & <welcome>" } }, TagMode.SelfClosing);
        Assert.AreEqual("<input value=\"He said &quot;Hello&quot; &amp; &lt;welcome&gt;\"/>", tag.ToString());
    }
}