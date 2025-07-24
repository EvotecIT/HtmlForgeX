using System;

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

    [TestMethod]
    public void TablerCardHeader_NullActions_DoesNotThrow() {
        var header = new TablerCardHeader().Title("Title");
        var prop = typeof(TablerCardHeader).GetProperty("Actions", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        prop!.SetValue(header, null);

        try {
            var html = header.ToString();
            StringAssert.Contains(html, "card-header");
        } catch (Exception ex) {
            Assert.Fail($"Exception was thrown: {ex.Message}");
        }

        var valueAfter = prop.GetValue(header);
        Assert.IsNotNull(valueAfter);
    }

    [TestMethod]
    public void TablerCardButtonUrl_ThrowsOnNull() {
        var button = new TablerCardButton();
        Assert.ThrowsException<ArgumentException>(() => button.Url(null!));
    }

    [TestMethod]
    public void TablerCardButtonUrl_ThrowsOnWhitespace() {
        var button = new TablerCardButton();
        Assert.ThrowsException<ArgumentException>(() => button.Url(" "));
    }

    [TestMethod]
    public void TablerCardActionBuilder_ButtonThrowsOnNull() {
        var builder = new TablerCardActionBuilder();
        Assert.ThrowsException<ArgumentException>(() => builder.Button(null!));
    }

    [TestMethod]
    public void TablerCardActionBuilder_ButtonThrowsOnWhitespace() {
        var builder = new TablerCardActionBuilder();
        Assert.ThrowsException<ArgumentException>(() => builder.Button(" "));
    }
}