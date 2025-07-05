namespace HtmlForgeX.Tests;


[TestClass]
public class TestHtmlSpan {
    [TestMethod]
    public void HtmlSpan01() {
        var value = new Span().AddContent("This is table with DataTables").WithAlignment(FontAlignment.Center).WithColor(RGBColor.TractorRed);
        // After fix: AddContent creates child spans with individual styling, root span manages the container
        Assert.AreEqual("<span><span style=\"color: #FD0E35; text-align: Center\">This is table with DataTables</span></span>", value.ToString());
    }

    [TestMethod]
    public void HtmlSpanChaining() {
        var value = new Span().AddContent("This is table with DataTables").WithAlignment(FontAlignment.Center)
            .WithColor(RGBColor.TractorRed).AppendContent(" continue?");
        // After fix: Both AddContent and AppendContent create properly structured child spans
        Assert.AreEqual("<span><span style=\"color: #FD0E35; text-align: Center\">This is table with DataTables</span></span><span> continue?</span>", value.ToString());
    }

    [TestMethod]
    public void HtmlSpanChainingWithDocument() {
        var value = new Document();
        value.Body.Span("This is table with DataTables").WithAlignment(FontAlignment.Center)
            .WithColor(RGBColor.TractorRed).AppendContent(" continue?");

        var expectedLines = new[] {
            "<!DOCTYPE html>",
            "<html>",
            "<head>",
            "\t<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">",
            "</head>",
            string.Empty,
            "<body data-bs-theme=\"light\">",
            "<span style=\"color: #FD0E35; text-align: Center\">This is table with DataTables</span><span> continue?</span>",
            "</body>",
            string.Empty,
            "</html>"
        };
        var expected = string.Join(Environment.NewLine, expectedLines) + Environment.NewLine;

        Assert.AreEqual(expected, value.ToString());
    }
}
