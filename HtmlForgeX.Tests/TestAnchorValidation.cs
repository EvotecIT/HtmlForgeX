using Microsoft.VisualStudio.TestTools.UnitTesting;
using HtmlForgeX.Tags;

namespace HtmlForgeX.Tests;

/// <summary>
/// Checks that the <see cref="Anchor"/> tag enforces valid <c>href</c> values.
/// </summary>
[TestClass]
public class TestAnchorValidation {
    [TestMethod]
    public void AnchorThrowsOnInvalidHref() {
        Assert.ThrowsException<ArgumentException>(() => new Anchor(""));
    }

    [TestMethod]
    public void AnchorThrowsOnInvalidHrefMethod() {
        var anchor = new Anchor("https://example.com");
        Assert.ThrowsException<ArgumentException>(() => anchor.HrefLink(" "));
    }

    [TestMethod]
    public void AnchorThrowsOnInvalidTarget() {
        var anchor = new Anchor("https://example.com");
        Assert.ThrowsException<ArgumentException>(() => anchor.Target(""));
    }
}
