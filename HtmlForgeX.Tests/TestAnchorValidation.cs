using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using HtmlForgeX.Logging;
using HtmlForgeX.Tags;

namespace HtmlForgeX.Tests;

/// <summary>
/// Checks that the <see cref="Anchor"/> tag enforces valid <c>href</c> values.
/// </summary>
[TestClass]
public class TestAnchorValidation {
    private static InternalLogger GetLogger() {
        var field = typeof(Anchor).GetField("_logger", BindingFlags.NonPublic | BindingFlags.Static);
        Assert.IsNotNull(field);
        return (InternalLogger)field!.GetValue(null)!;
    }
    [TestMethod]
    public void Anchor_InvalidHref_LogsError() {
        var logger = GetLogger();
        string? received = null;
        EventHandler<LogEventArgs> handler = (_, e) => received = e.FullMessage;
        logger.OnErrorMessage += handler;
        var anchor = new Anchor("");
        logger.OnErrorMessage -= handler;
        Assert.IsNotNull(received);
        Assert.IsFalse(anchor.Attributes.ContainsKey("href"));
    }

    [TestMethod]
    public void Anchor_InvalidHrefMethod_LogsError() {
        var logger = GetLogger();
        string? received = null;
        EventHandler<LogEventArgs> handler = (_, e) => received = e.FullMessage;
        logger.OnErrorMessage += handler;
        var anchor = new Anchor("https://example.com");
        anchor.HrefLink(" ");
        logger.OnErrorMessage -= handler;
        Assert.IsNotNull(received);
        Assert.AreEqual("https://example.com", anchor.Attributes["href"]);
    }

    [TestMethod]
    public void AnchorThrowsOnInvalidTarget() {
        var anchor = new Anchor("https://example.com");
        Assert.ThrowsException<ArgumentException>(() => anchor.Target(""));
    }
}
