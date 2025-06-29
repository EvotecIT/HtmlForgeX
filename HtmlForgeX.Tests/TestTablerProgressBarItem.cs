using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestTablerProgressBarItem {
    [TestMethod]
    public void ConstructorThrowsWhenProgressBelowZero() {
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => new TablerProgressBarItem(TablerColor.Primary, -1));
    }

    [TestMethod]
    public void ConstructorThrowsWhenProgressAboveHundred() {
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => new TablerProgressBarItem(TablerColor.Primary, 101));
    }
}
