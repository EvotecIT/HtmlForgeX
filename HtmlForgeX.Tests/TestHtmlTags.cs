using HtmlForgeX.Tags;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestHtmlTags {

    [TestMethod]
    public void HtmlTagWithDictionaryAttributes() {
        HtmlTag tag = new HtmlTag("div", "Hello, World!", new Dictionary<string, object> {
            { "style", new Dictionary<string, object> {
                { "color", "red" },
                { "font-size", "24px" }
            } }
        });
        Assert.IsNotNull(tag);
        Assert.AreEqual("<div style=\"color: red; font-size: 24px\">Hello, World!</div>", tag.ToString());
    }


    [TestMethod]
    public void HtmlTags() {
        var anchor1 = new Anchor("https://evample.com", "Example").HrefLink("https://evotec.xyz").HrefLang("EN");
        Assert.AreEqual("<a href=\"https://evotec.xyz\" hreflang=\"EN\">Example</a>", anchor1.ToString());

        var anchor2 = new Anchor("https://evample.com", "Example").HrefLink("https://evotec.xyz").Name("Example Website").HrefLink("https://evotec.xyz").Target("_blank");
        Assert.AreEqual("<a href=\"https://evotec.xyz\" name=\"Example Website\" target=\"_blank\">Example</a>", anchor2.ToString());

        var abbr1 = new Abbr("HTML").Title("Hyper Text Markup Language");
        Assert.AreEqual("<abbr title=\"Hyper Text Markup Language\">HTML</abbr>", abbr1.ToString());

        var article = new Article("This is an article.");
        Assert.AreEqual("<article>This is an article.</article>", article.ToString());

        var address = new Address("This is an address.");
        Assert.AreEqual("<address>This is an address.</address>", address.ToString());

        var strong = new Strong("This is a paragraph.");
        Assert.AreEqual("<strong>This is a paragraph.</strong>", strong.ToString());
    }

}
