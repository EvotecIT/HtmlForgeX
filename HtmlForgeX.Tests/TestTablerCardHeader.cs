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

    [TestMethod]
    public void TablerCardHeader_Actions_AssignDocument() {
        using var document = new Document();
        var page = new TablerPage();
        var card = new TablerCard();
        page.Add(card);
        document.Body.Add(page);

        TablerCardButton? captured = null;

        // Add header after card has document reference so builder receives it
        card.Header(h => {
            h.WithActions(actions => {
                actions.Button("Click", btn => captured = btn);
            });
        });

        document.ToString();

        Assert.IsNotNull(captured);
        Assert.AreSame(document, captured!.Document);
    }

    [TestMethod]
    public void TablerCardHeader_Actions_LibraryRegistration() {
        using var document = new Document();
        var page = new TablerPage();
        var card = new TablerCard();
        page.Add(card);
        document.Body.Add(page);

        card.Header(h => {
            h.WithActions(a => a.Button("Test"));
        });

        document.ToString();

        Assert.IsTrue(document.Configuration.Libraries.ContainsKey(Libraries.Bootstrap));
        Assert.IsTrue(document.Configuration.Libraries.ContainsKey(Libraries.Tabler));
    }
}
