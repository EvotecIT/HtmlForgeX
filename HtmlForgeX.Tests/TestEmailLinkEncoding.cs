using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestEmailLinkEncoding {
    [TestMethod]
    public void EmailLink_EncodesHrefValue() {
        var link = new EmailLink("Open Search", "https://example.com/search?q=C# tutorial&lang=en us");
        var html = link.ToString();
        StringAssert.Contains(html, "href=\"https://example.com/search?q=C%23%20tutorial&amp;lang=en%20us\"");
    }
}