using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestTablerCardActionReferences
{
    [TestMethod]
    public void TablerCardEnhanced_Actions_GetDocumentReference_BeforeRender()
    {
        using var document = new Document();
        var card = new TablerCardEnhanced()
            .WithHeaderAction("A")
            .WithFooterButton("B");

        document.Body.Add(card);
        _ = document.ToString();

        foreach (var action in card.HeaderActions.Concat(card.FooterActions))
        {
            Assert.AreSame(document, action.Document, "Action should reference parent Document");
        }
    }
}
