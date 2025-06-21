namespace HtmlForgeX.Tests;


[TestClass]
public class TestHtmlSpan {
    [TestMethod]
    public void HtmlSpan01() {
        var value = new Span().AddContent("This is table with DataTables").WithAlignment(FontAlignment.Center).WithColor(RGBColor.TractorRed);
        Assert.AreEqual("<span style=\"color: #FD0E35; text-align: Center\">This is table with DataTables</span>", value.ToString());
    }

    [TestMethod]
    public void HtmlSpanChaining() {
        var value = new Span().AddContent("This is table with DataTables").WithAlignment(FontAlignment.Center)
            .WithColor(RGBColor.TractorRed).AppendContent(" continue?");
        Assert.AreEqual("<span style=\"color: #FD0E35; text-align: Center\">This is table with DataTables</span><span> continue?</span>", value.ToString());
    }

    [TestMethod]
    public void HtmlSpanChainingWithDocument() {
        var value = new Document();
        value.Body.Span("This is table with DataTables").WithAlignment(FontAlignment.Center)
            .WithColor(RGBColor.TractorRed).AppendContent(" continue?");

        var value1 = new Document();
        value1.Body.Span("This is table with DataTables").WithAlignment(FontAlignment.Center)
            .WithColor(RGBColor.TractorRed).AppendContent(" continue?");

        var expected = value1.ToString();

        Assert.AreEqual(expected, value.ToString());

        Assert.AreEqual(value.ToString(), value1.ToString());
    }
}
