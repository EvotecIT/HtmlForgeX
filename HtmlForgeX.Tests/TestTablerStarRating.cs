using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestTablerStarRating {
    [TestMethod]
    public void StarRating_RendersSelectAndScript() {
        var rating = new TablerStarRating("r1").MaxStars(3).Value(2).OnChange("handler");
        var html = rating.ToString();
        StringAssert.Contains(html, "new StarRating");
        StringAssert.Contains(html, "id=\"r1\"");
    }

    [TestMethod]
    public void StarRating_RegistersLibrary() {
        using var doc = new Document();
        doc.Body.Add(new TablerStarRating("r"));
        _ = doc.ToString();
        Assert.IsTrue(doc.Configuration.Libraries.ContainsKey(Libraries.StarRating));
    }
}