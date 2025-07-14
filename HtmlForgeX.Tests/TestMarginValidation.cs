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
        Assert.ThrowsException<ArgumentException>(() => new EmailBox().SetOuterMargin("invalid"));
    }
}
