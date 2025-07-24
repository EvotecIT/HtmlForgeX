using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestTablerProgressBarItem {
    [TestMethod]
    public void ProgressBelowZero_IsClampedToZero() {
        var item = new TablerProgressBarItem(TablerColor.Primary, -1);
        StringAssert.Contains(item.ToString(), "width: 0%");
    }

    [TestMethod]
    public void ProgressAboveHundred_IsClampedToHundred() {
        var item = new TablerProgressBarItem(TablerColor.Primary, 101);
        StringAssert.Contains(item.ToString(), "width: 100%");
    }
}