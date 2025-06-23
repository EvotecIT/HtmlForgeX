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

    [TestMethod]
    public void TablerSpacingConversion() {
        Assert.AreEqual("mt-auto", TablerMargin.TopAuto.EnumToString());
        Assert.AreEqual("mb-0", TablerMargin.BottomZero.EnumToString());
        Assert.AreEqual("mx-2", TablerMargin.HorizontalHalf.EnumToString());
        Assert.AreEqual("my-3", TablerMargin.VerticalNormal.EnumToString());
        Assert.AreEqual("m-5", TablerMargin.AllTriple.EnumToString());

        Assert.AreEqual("pt-auto", TablerPadding.TopAuto.EnumToString());
        Assert.AreEqual("pb-0", TablerPadding.BottomZero.EnumToString());
        Assert.AreEqual("px-2", TablerPadding.HorizontalHalf.EnumToString());
        Assert.AreEqual("py-3", TablerPadding.VerticalNormal.EnumToString());
        Assert.AreEqual("p-5", TablerPadding.AllTriple.EnumToString());
    }

    [TestMethod]
    public void TablerMarginEnumToStringAllValues() {
        foreach (TablerMargin margin in Enum.GetValues(typeof(TablerMargin))) {
            var marginStr = margin.ToString();
            var property = "m";

            string side;
            string size;

            if (marginStr.StartsWith("Top")) {
                side = "t";
                size = marginStr.Substring(3);
            } else if (marginStr.StartsWith("Bottom")) {
                side = "b";
                size = marginStr.Substring(6);
            } else if (marginStr.StartsWith("Start")) {
                side = "s";
                size = marginStr.Substring(5);
            } else if (marginStr.StartsWith("End")) {
                side = "e";
                size = marginStr.Substring(3);
            } else if (marginStr.StartsWith("Horizontal")) {
                side = "x";
                size = marginStr.Substring(10);
            } else if (marginStr.StartsWith("Vertical")) {
                side = "y";
                size = marginStr.Substring(8);
            } else if (marginStr.StartsWith("All")) {
                side = string.Empty;
                size = marginStr.Substring(3);
            } else {
                side = string.Empty;
                size = marginStr;
            }

            size = size switch {
                "Auto" => "auto",
                "Zero" => "0",
                "Quarter" => "1",
                "Half" => "2",
                "Normal" => "3",
                "OneAndHalf" => "4",
                "Triple" => "5",
                _ => size.ToLower()
            };

            var expected = $"{property}{side}-{size}";
            Assert.AreEqual(expected, margin.EnumToString(), $"Mismatch for {marginStr}");
        }
    }

    [TestMethod]
    public void TablerPaddingEnumToStringAllValues() {
        foreach (TablerPadding padding in Enum.GetValues(typeof(TablerPadding))) {
            var paddingStr = padding.ToString();
            var property = "p";

            string side;
            string size;

            if (paddingStr.StartsWith("Top")) {
                side = "t";
                size = paddingStr.Substring(3);
            } else if (paddingStr.StartsWith("Bottom")) {
                side = "b";
                size = paddingStr.Substring(6);
            } else if (paddingStr.StartsWith("Start")) {
                side = "s";
                size = paddingStr.Substring(5);
            } else if (paddingStr.StartsWith("End")) {
                side = "e";
                size = paddingStr.Substring(3);
            } else if (paddingStr.StartsWith("Horizontal")) {
                side = "x";
                size = paddingStr.Substring(10);
            } else if (paddingStr.StartsWith("Vertical")) {
                side = "y";
                size = paddingStr.Substring(8);
            } else if (paddingStr.StartsWith("All")) {
                side = string.Empty;
                size = paddingStr.Substring(3);
            } else {
                side = string.Empty;
                size = paddingStr;
            }

            size = size switch {
                "Auto" => "auto",
                "Zero" => "0",
                "Quarter" => "1",
                "Half" => "2",
                "Normal" => "3",
                "OneAndHalf" => "4",
                "Triple" => "5",
                _ => size.ToLower()
            };

            var expected = $"{property}{side}-{size}";
            Assert.AreEqual(expected, padding.EnumToString(), $"Mismatch for {paddingStr}");
        }
    }
}