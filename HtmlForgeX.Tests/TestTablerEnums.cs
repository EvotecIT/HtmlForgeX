using System.Text.RegularExpressions;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestTablerEnums {

    [TestMethod]
    public void TablerColorConversion() {
        // test random colors to see if they are converted correctly manually
        var color = TablerColor.Facebook;
        Assert.AreEqual("facebook", color.ToTablerString());

        var color1 = TablerColor.Gray300;
        Assert.AreEqual("gray-300", color1.ToTablerString());

        var color2 = TablerColor.AzureLight;
        Assert.AreEqual("azure-lt", color2.ToTablerString());

        var color3 = TablerColor.Red;
        Assert.AreEqual("bg-red", color3.ToTablerBackground());

        var color4 = TablerColor.Gray600;
        Assert.AreEqual("bg-gray-600", color4.ToTablerBackground());

        var color5 = TablerColor.AzureLight;
        Assert.AreEqual("text-azure-lt", color5.ToTablerText());

        // test all colors to see if they are converted correctly automatically
        foreach (TablerColor color6 in Enum.GetValues(typeof(TablerColor))) {
            var colorString = color6.ToString().ToLower();
            if (colorString.EndsWith("light")) {
                Assert.AreEqual(colorString.Replace("light", "-lt"), color6.ToTablerString());
            }
            var regex = new Regex(@"(\d+)");
            if (regex.IsMatch(colorString)) {
                Assert.AreEqual(regex.Replace(colorString, "-$1"), color6.ToTablerString());
            }
            Assert.AreEqual("text-" + color6.ToTablerString(), color6.ToTablerText());
            Assert.AreEqual("bg-" + color6.ToTablerString(), color6.ToTablerBackground());
            Assert.AreEqual("steps-" + color6.ToTablerString(), color6.ToTablerSteps());
            Assert.AreEqual("status-" + color6.ToTablerString(), color6.ToTablerStatus());
            Assert.AreEqual("alert-" + color6.ToTablerString(), color6.ToTablerAlert());
        }
    }
}