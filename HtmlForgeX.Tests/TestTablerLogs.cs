using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestTablerLogs {
    [TestMethod]
    public void TablerLogs_DefaultTheme() {
        var logs = new TablerLogs("Test");
        var html = logs.ToString();
        Assert.IsTrue(html.Contains("bg-dark"));
        Assert.IsTrue(html.Contains("text-white"));
    }

    [TestMethod]
    public void TablerLogs_LightTheme() {
        var logs = new TablerLogs("Test").Theme(TablerLogsTheme.Light);
        var html = logs.ToString();
        Assert.IsTrue(html.Contains("bg-light"));
        Assert.IsTrue(html.Contains("text-dark"));
    }

    [TestMethod]
    public void TablerLogs_LimeTheme() {
        var logs = new TablerLogs("Test").Theme(TablerLogsTheme.Lime);
        var html = logs.ToString();
        Assert.IsTrue(html.Contains("bg-lime"));
        Assert.IsTrue(html.Contains("text-dark"));
    }

    [TestMethod]
    public void TablerLogs_CustomTheme() {
        var logs = new TablerLogs("Test").CustomTheme("bg-purple", "text-yellow");
        var html = logs.ToString();
        Assert.IsTrue(html.Contains("bg-purple"));
        Assert.IsTrue(html.Contains("text-yellow"));
    }

    [TestMethod]
    public void TablerLogs_CustomColors() {
        var logs = new TablerLogs("Test").CustomColors(new RGBColor("#6f42c1"), new RGBColor("#ffd43b"));
        var html = logs.ToString();
        Assert.IsTrue(html.Contains("background-color: #6F42C1"));
        Assert.IsTrue(html.Contains("color: #FFD43B"));
    }
}
