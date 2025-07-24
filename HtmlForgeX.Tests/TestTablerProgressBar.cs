using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestTablerProgressBar {
    [TestMethod]
    public void ProgressBarItem_WritesAriaAttributes() {
        var item = new TablerProgressBarItem(TablerColor.Success, 30, "Label", 30, 0, 100);
        var html = item.ToString();
        Assert.IsTrue(html.Contains("aria-valuenow=\"30\""));
        Assert.IsTrue(html.Contains("aria-valuemin=\"0\""));
        Assert.IsTrue(html.Contains("aria-valuemax=\"100\""));
        Assert.IsTrue(html.Contains("Label"));
    }

    [TestMethod]
    public void ProgressBar_RendersItems() {
        var bar = new TablerProgressBar();
        bar.Item(TablerColor.Primary, 50, "Done");
        var html = bar.ToString();
        Assert.IsTrue(html.Contains("progress-bar"));
        Assert.IsTrue(html.Contains("Done"));
    }

    [TestMethod]
    public void ProgressBar_WithSpacingClasses() {
        var bar = new TablerProgressBar()
            .Margin(TablerMargin.BottomNormal)
            .Padding(TablerPadding.VerticalHalf);
        var html = bar.ToString();
        Assert.IsTrue(html.Contains("mb-3"));
        Assert.IsTrue(html.Contains("py-2"));
    }
}