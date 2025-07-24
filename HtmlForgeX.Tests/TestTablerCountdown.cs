using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestTablerCountdown {
    [TestMethod]
    public void Countdown_GeneratesHtml() {
        var card = new TablerCard();
        card.Countdown(c => c.EndTime(DateTime.UtcNow.AddHours(1)));
        var html = card.ToString();
        Assert.IsTrue(html.Contains("setInterval"));
        Assert.IsTrue(html.Contains("DOMContentLoaded"));
    }

    [TestMethod]
    public void Countdown_CompletionCallback() {
        var card = new TablerCard();
        card.Countdown(c => c.OnComplete("done"));
        var html = card.ToString();
        Assert.IsTrue(html.Contains("done()"));
    }
}