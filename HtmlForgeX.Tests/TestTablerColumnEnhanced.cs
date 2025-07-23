using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestTablerColumnEnhanced {
    [TestMethod]
    public void TablerColumn_CardEnhanced_AddsCard() {
        var column = new TablerColumn();

        column.CardEnhanced(card => card.WithHeader("Header"));

        var html = column.ToString();

        StringAssert.Contains(html, "card-header");
        StringAssert.Contains(html, "Header");
    }
}

