using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestMarginValidation {
    [TestMethod]
    public void WithMargin_InvalidValue_Throws() {
        Assert.ThrowsException<ArgumentException>(() => new EmailText().WithMargin("abc"));
        Assert.ThrowsException<ArgumentException>(() => new EmailImage().WithMargin("10"));
        Assert.ThrowsException<ArgumentException>(() => new EmailLink("demo", "#").WithMargin("5p"));
        Assert.ThrowsException<ArgumentException>(() => new EmailBox().CenterWithMargin("invalid"));
        Assert.ThrowsException<ArgumentException>(() => new EmailBox().WithOuterMargin("invalid"));
    }

    [TestMethod]
    public void WithMargin_DecimalValue_Accepts() {
        var text = new EmailText().WithMargin("1.5em");
        Assert.AreEqual("1.5em", text.Margin);

        var link = new EmailLink("demo", "#").WithMargin("0 1.5em");
        Assert.AreEqual("0 1.5em", link.Margin);

        var box = new EmailBox().WithOuterMargin("0 auto 1.5em auto");
        Assert.AreEqual("0 auto 1.5em auto", box.OuterMargin);
    }
}