using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestDataTablesScrolling {
    [TestMethod]
    public void Scrolling_ShouldResetScrollY_WhenNull() {
        var table = new DataTablesTable();
        table.Scrolling("200px");
        table.Scrolling(null);

        var html = table.ToString();

        Assert.IsNull(table.Options.ScrollY, "ScrollY should be reset to null");
        StringAssert.Contains(html, "\"scrollY\": false");
    }
}