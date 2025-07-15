using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestTablerCardActions {
    [TestMethod]
    public void TablerCardActionBuilder_ReturnsSameList() {
        var builder = new TablerCardActionBuilder()
            .Button("Action1")
            .IconButton(TablerIconType.Abacus);

        var actions1 = builder.GetActions();
        var actions2 = builder.GetActions();

        Assert.AreEqual(2, actions1.Count);
        Assert.AreSame(actions1, actions2);
    }
}
