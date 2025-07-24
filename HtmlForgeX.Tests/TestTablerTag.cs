using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestTablerTag {
    [TestMethod]
    public void TagGeneratesCorrectHtml() {
        var tag = new TablerTag("New", TablerColor.Blue);
        Assert.AreEqual("<span class=\"tag bg-blue\">New</span>", tag.ToString());
    }

    [TestMethod]
    public void TagDismissAndSize() {
        var tag = new TablerTag("Close", TablerColor.Red).Dismissable().TagSize(TablerTagSize.Small);
        var expected = "<span class=\"tag tag-sm bg-red\">Close<a class=\"btn-close\" href=\"#\"></a></span>";
        Assert.AreEqual(expected, tag.ToString());
    }
    [TestMethod]
    public void DismissableAndSize_GeneratesExpectedHtml() {
        var tag = new TablerTag("Close", TablerColor.Red).Dismissable().TagSize(TablerTagSize.Small);
        var expected = "<span class=\"tag tag-sm bg-red\">Close<a class=\"btn-close\" href=\"#\"></a></span>";
        Assert.AreEqual(expected, tag.ToString());
    }

}