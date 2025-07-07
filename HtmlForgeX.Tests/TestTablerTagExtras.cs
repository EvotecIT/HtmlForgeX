using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestTablerTagExtras {
    [TestMethod]
    public void TablerTag_GeneratesExpectedHtml() {
        var tag = new TablerTag("Hi", TablerColor.Primary)
            .Dismissable()
            .TagSize(TablerTagSize.Large);

        var html = tag.ToString();
        Assert.IsTrue(html.Contains("bg-primary"));
        Assert.IsTrue(html.Contains("btn-close"));
        Assert.IsTrue(html.Contains("tag-lg"));
    }
}
