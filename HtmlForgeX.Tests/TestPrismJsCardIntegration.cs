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
}