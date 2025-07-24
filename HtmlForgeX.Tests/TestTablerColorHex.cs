using System;
using System.Reflection;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestTablerColorHex {
    [TestMethod]
    public void TablerColorToHex_WorksForVariousColors() {
        Assert.AreEqual("#066fd1", TablerColor.Blue.ToHex());
        Assert.AreEqual("#e6f1fa", TablerColor.BlueLight.ToHex());
        Assert.AreEqual("#374151", TablerColor.Gray700.ToHex());
        Assert.AreEqual("#1877f2", TablerColor.Facebook.ToHex());
        Assert.AreEqual("#d63939", TablerColor.Failed.ToHex());
        Assert.AreEqual("#00000000", TablerColor.Transparent.ToHex());
    }

    [TestMethod]
    public void TablerColorToHex_AllColorsHaveAttributes() {
        foreach (var color in (TablerColor[])Enum.GetValues(typeof(TablerColor))) {
            var field = typeof(TablerColor).GetField(color.ToString());
            var attr = field?.GetCustomAttribute<HexColorAttribute>();
            Assert.IsNotNull(attr, $"Missing HexColorAttribute for {color}");
            Assert.IsFalse(string.IsNullOrWhiteSpace(attr!.Hex), $"Empty hex for {color}");
        }
    }
}