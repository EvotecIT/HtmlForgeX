using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestTablerCardHeader {
    [TestMethod]
    public void TablerCardHeader_NoAvatar_Renders() {
        var header = new TablerCardHeader().Title("Test");
        var html = header.ToString();
        Assert.IsTrue(html.Contains("card-header"));
    }
}
