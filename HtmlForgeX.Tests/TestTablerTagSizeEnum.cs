using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestTablerTagSizeEnum {
    [TestMethod]
    public void EnumToString_ReturnsExpectedCssClass() {
        Assert.AreEqual("tag-sm", TablerTagSize.Small.EnumToString());
        Assert.AreEqual("tag-lg", TablerTagSize.Large.EnumToString());
        Assert.AreEqual(string.Empty, TablerTagSize.Normal.EnumToString());
    }
}