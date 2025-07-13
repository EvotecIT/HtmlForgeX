using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestTablerToast {
    [TestMethod]
    public void Toast_GeneratesBasicHtml() {
        var toast = new TablerToast().Title("Hi").Message("Test");
        var html = toast.ToString();
        Assert.IsTrue(html.Contains("toast-body"));
        Assert.IsTrue(html.Contains("toast-header"));
    }

    [TestMethod]
    public void Toast_PositionAndType() {
        var toast = new TablerToast("T","M")
            .Type(TablerToastType.Success)
            .Position(TablerToastPosition.TopLeft);
        var html = toast.ToString();
        Assert.IsTrue(html.Contains("text-bg-success"));
        Assert.IsTrue(html.Contains("top-0"));
        Assert.IsTrue(html.Contains("start-0"));
    }

    [TestMethod]
    public void Toast_AutoDismissScript() {
        var toast = new TablerToast("T","M").AutoDismiss(1000);
        var html = toast.ToString();
        Assert.IsTrue(html.Contains("bootstrap.Toast"));
        Assert.IsTrue(html.Contains("delay: 1000"));
    }
}
