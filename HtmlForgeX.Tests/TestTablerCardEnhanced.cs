using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestTablerCardEnhanced {
    [TestMethod]
    public void TablerCardEnhanced_HeaderFooterRendering() {
        var card = new TablerCardEnhanced()
            .WithHeader("Title")
            .WithFooter("Footer");

        var html = card.ToString();
        StringAssert.Contains(html, "card-header");
        StringAssert.Contains(html, "card-footer");
    }
}