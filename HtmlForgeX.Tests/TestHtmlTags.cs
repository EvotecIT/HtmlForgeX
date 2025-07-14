using HtmlForgeX.Tags;

namespace HtmlForgeX.Tests;

/// <summary>
/// Covers additional scenarios when building <see cref="HtmlTag"/> instances.
/// </summary>
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

        var br = new BR();
        Assert.AreEqual("<br>", br.ToString());

        var br2 = new LineBreak();
        Assert.AreEqual("<br>", br2.ToString());

        var h1 = new H1("This is a header 1.");
        Assert.AreEqual("<h1>This is a header 1.</h1>", h1.ToString());

        var h2 = new H2("This is a header 2.");
        Assert.AreEqual("<h2>This is a header 2.</h2>", h2.ToString());

        var h3 = new H3("This is a header 3.");
        Assert.AreEqual("<h3>This is a header 3.</h3>", h3.ToString());

        var h4 = new H4("This is a header 4.");
        Assert.AreEqual("<h4>This is a header 4.</h4>", h4.ToString());

        var h5 = new H5("This is a header 5.");
        Assert.AreEqual("<h5>This is a header 5.</h5>", h5.ToString());

        var h6 = new H6("This is a header 6.");
        Assert.AreEqual("<h6>This is a header 6.</h6>", h6.ToString());

        var hr = new HR();
        Assert.AreEqual("<hr>", hr.ToString());

        var hr2 = new HorizontalRule();
        Assert.AreEqual("<hr>", hr2.ToString());

        var nbsp = new NonBreakingSpace();
        Assert.AreEqual("&nbsp;", nbsp.ToString());

        var ensp = new EnSpace();
        Assert.AreEqual("&ensp;", ensp.ToString());

        var mnsp = new EmSpace();
        Assert.AreEqual("&emsp;", mnsp.ToString());

        var strong = new Strong("This is a paragraph.");
        Assert.AreEqual("<strong>This is a paragraph.</strong>", strong.ToString());

    }

}
