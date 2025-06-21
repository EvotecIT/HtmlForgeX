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

        var expected = "<!DOCTYPE html>\n" +
                       "<html>\n" +
                       "<head>\n" +
                       "\t<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">\n" +
                       "</head>\n" +
                       "\n" +
                       "<body data-bs-theme=\"light\">\n" +
                       "<span style=\"color: #FD0E35; text-align: Center\">This is table with DataTables</span><span> continue?</span>\n" +
                       "</body>\n" +
                       "\n" +
                       "</html>";

        Assert.AreEqual(expected.Trim(), value.ToString().Trim());

        Assert.AreEqual(value.ToString(), value1.ToString());
    }
}
