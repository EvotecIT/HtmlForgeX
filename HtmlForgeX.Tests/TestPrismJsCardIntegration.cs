using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestPrismJsCardIntegration {
    [TestMethod]
    public void PrismCodeBlockInsideCard_ShouldRegisterLibraries() {
        using var doc = new Document(LibraryMode.Online);
        var card = new TablerCard();
        card.Body(body => {
            body.CSharpCode("Console.WriteLine(\"Hello\");");
        });
        doc.Body.Add(card);

        var html = doc.ToString();

        Assert.IsTrue(doc.Configuration.Libraries.ContainsKey(Libraries.PrismJs), "PrismJS library should be registered");
        Assert.IsTrue(html.Contains("prism"), "HTML should contain PrismJS references");
    }

    [TestMethod]
    public void PrismCodeBlock_OfflineMode_ShouldEmbedResources() {
        using var doc = new Document(LibraryMode.Offline);
        var card = new TablerCard();
        card.Body(body => {
            body.CSharpCode("int x = 1;");
        });
        doc.Body.Add(card);

        var html = doc.ToString();

        Assert.IsTrue(html.Contains("prism"), "HTML should contain PrismJS code");
        Assert.IsFalse(html.Contains("cdn.jsdelivr.net") || html.Contains("cdnjs"), "Offline mode should not use CDN links");
    }
}