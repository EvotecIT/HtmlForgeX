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
        var toast = new TablerToast("T", "M")
            .Type(TablerToastType.Success)
            .Position(TablerToastPosition.TopLeft);
        var html = toast.ToString();
        Assert.IsTrue(html.Contains("text-bg-success"));
        Assert.IsTrue(html.Contains("top-0"));
        Assert.IsTrue(html.Contains("start-0"));
    }

    [TestMethod]
    public void Toast_AutoDismissScript() {
        var toast = new TablerToast("T", "M").AutoDismiss(1000);
        var html = toast.ToString();
        Assert.IsTrue(html.Contains("bootstrap.Toast"));
        Assert.IsTrue(html.Contains("delay: 1000"));
    }

    [DataTestMethod]
    [DataRow(TablerToastType.Success, "text-bg-success")]
    [DataRow(TablerToastType.Warning, "text-bg-warning")]
    [DataRow(TablerToastType.Danger, "text-bg-danger")]
    [DataRow(TablerToastType.Info, "text-bg-info")]
    [DataRow(TablerToastType.Default, "")]
    public void Toast_TypeAddsCorrectClass(TablerToastType type, string expectedClass) {
        var toast = new TablerToast("T", "M").Type(type);
        var html = toast.ToString();
        if (string.IsNullOrEmpty(expectedClass)) {
            Assert.IsFalse(html.Contains("text-bg-"));
        } else {
            Assert.IsTrue(html.Contains(expectedClass));
        }
    }

    [DataTestMethod]
    [DataRow(TablerToastPosition.TopLeft, "top-0 start-0")]
    [DataRow(TablerToastPosition.TopCenter, "top-0 start-50 translate-middle-x")]
    [DataRow(TablerToastPosition.TopRight, "top-0 end-0")]
    [DataRow(TablerToastPosition.BottomLeft, "bottom-0 start-0")]
    [DataRow(TablerToastPosition.BottomCenter, "bottom-0 start-50 translate-middle-x")]
    [DataRow(TablerToastPosition.BottomRight, "bottom-0 end-0")]
    public void Toast_PositionAddsCorrectClass(TablerToastPosition position, string expectedClass) {
        var toast = new TablerToast("T", "M").Position(position);
        var html = toast.ToString();
        Assert.IsTrue(html.Contains(expectedClass));
    }
}