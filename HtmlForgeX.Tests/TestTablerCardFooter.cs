using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestTablerCardFooter {
    private class DummyElement : Element {
        public int AddedCount { get; private set; }

        protected internal override void OnAddedToDocument() {
            AddedCount++;
            base.OnAddedToDocument();
        }

        public override string ToString() => "<span>dummy</span>";
    }

    [TestMethod]
    public void EnsureChildrenHaveDocumentReference_CalledMultipleTimes_ShouldNotDuplicateOnAdded() {
        var dummy = new DummyElement();
        var card = new TablerCard();
        card.Footer(f => f.Add(dummy));

        var document = new Document();
        document.Body.Add(card);

        _ = document.ToString();
        _ = document.ToString();

        Assert.AreEqual(1, dummy.AddedCount, "OnAddedToDocument should be called once");
    }

    [TestMethod]
    public void EmptyFooter_SuppressesRendering_ChildProducesFooterHtml() {
        var footer = new TablerCardFooter();

        var html = footer.ToString();
        Assert.AreEqual(string.Empty, html, "Empty footer should not render");

        footer.Add(new Span { Content = "child" });
        var htmlWithChild = footer.ToString();

        Assert.AreEqual("<div class=\"card-footer\"><span>child</span></div>", htmlWithChild);
    }
}
