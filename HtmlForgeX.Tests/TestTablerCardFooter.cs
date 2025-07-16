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
}
