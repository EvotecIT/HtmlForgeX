namespace HtmlForgeX.Tests;

[TestClass]
public class TestRGBColorHex {

    [TestMethod]
    public void RGBColorHexConstructor_BasicSixDigitHex_CreatesCorrectColor() {
        // Arrange & Act
        var color = new RGBColor("#111827");

        // Assert
        Assert.AreEqual("#111827", color.ToHex());
    }

    [TestMethod]
    public void RGBColorHexConstructor_SixDigitHexWithoutHash_CreatesCorrectColor() {
        // Arrange & Act
        var color = new RGBColor("123456");

        // Assert
        Assert.AreEqual("#123456", color.ToHex());
    }

    [TestMethod]
    public void RGBColorHexConstructor_ThreeDigitHex_ExpandsCorrectly() {
        // Arrange & Act
        var color = new RGBColor("#FFF");

        // Assert
        Assert.AreEqual("#FFFFFF", color.ToHex());
    }

    [TestMethod]
    public void RGBColorHexConstructor_ThreeDigitHexWithoutHash_ExpandsCorrectly() {
        // Arrange & Act
        var color = new RGBColor("F0A");

        // Assert
        Assert.AreEqual("#FF00AA", color.ToHex());
    }

    [TestMethod]
    public void RGBColorHexConstructor_EightDigitHex_IgnoresAlpha() {
        // Arrange & Act
        var color = new RGBColor("#FF123456");

        // Assert
        Assert.AreEqual("#123456", color.ToHex());
    }

    [TestMethod]
    public void RGBColorHexConstructor_EightDigitHexWithoutHash_IgnoresAlpha() {
        // Arrange & Act
        var color = new RGBColor("80ABCDEF");

        // Assert
        Assert.AreEqual("#ABCDEF", color.ToHex());
    }

    [TestMethod]
    public void RGBColorHexConstructor_LowercaseHex_WorksCorrectly() {
        // Arrange & Act
        var color = new RGBColor("#abc123");

        // Assert
        Assert.AreEqual("#ABC123", color.ToHex());
    }

    [TestMethod]
    public void RGBColorHexConstructor_MixedCaseHex_WorksCorrectly() {
        // Arrange & Act
        var color = new RGBColor("#aBc123");

        // Assert
        Assert.AreEqual("#ABC123", color.ToHex());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RGBColorHexConstructor_EmptyString_ThrowsArgumentException() {
        // Act & Assert
        new RGBColor("");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RGBColorHexConstructor_NullString_ThrowsArgumentException() {
        // Act & Assert
        new RGBColor(null!);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RGBColorHexConstructor_OnlyHashSymbol_ThrowsArgumentException() {
        // Act & Assert
        new RGBColor("#");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RGBColorHexConstructor_InvalidHexCharacters_ThrowsArgumentException() {
        // Act & Assert
        new RGBColor("#GGHHII");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RGBColorHexConstructor_InvalidLength_ThrowsArgumentException() {
        // Act & Assert
        new RGBColor("#12345");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RGBColorHexConstructor_SevenDigitHex_ThrowsArgumentException() {
        // Act & Assert
        new RGBColor("#1234567");
    }

    [TestMethod]
    public void RGBColorFromHex_StaticMethod_WorksCorrectly() {
        // Arrange & Act
        var color = RGBColor.FromHex("#111827");

        // Assert
        Assert.AreEqual("#111827", color.ToHex());
    }

    [TestMethod]
    public void RGBColorTryFromHex_ValidHex_ReturnsTrue() {
        // Arrange & Act
        bool success = RGBColor.TryFromHex("#123456", out RGBColor? result);

        // Assert
        Assert.IsTrue(success);
        Assert.IsNotNull(result);
        Assert.AreEqual("#123456", result.ToHex());
    }

    [TestMethod]
    public void RGBColorTryFromHex_InvalidHex_ReturnsFalse() {
        // Arrange & Act
        bool success = RGBColor.TryFromHex("invalid", out RGBColor? result);

        // Assert
        Assert.IsFalse(success);
        Assert.IsNull(result);
    }

    [TestMethod]
    public void RGBColorTryFromHex_EmptyString_ReturnsFalse() {
        // Arrange & Act
        bool success = RGBColor.TryFromHex("", out RGBColor? result);

        // Assert
        Assert.IsFalse(success);
        Assert.IsNull(result);
    }

    [TestMethod]
    public void RGBColorTryFromHex_NullString_ReturnsFalse() {
        // Arrange & Act
        bool success = RGBColor.TryFromHex(null!, out RGBColor? result);

        // Assert
        Assert.IsFalse(success);
        Assert.IsNull(result);
    }

    [TestMethod]
    public void RGBColorHex_RoundTrip_MaintainsConsistency() {
        // Arrange
        var originalHex = "#ABCDEF";

        // Act
        var color = new RGBColor(originalHex);
        var roundTripHex = color.ToHex();
        var roundTripColor = new RGBColor(roundTripHex);

        // Assert
        Assert.AreEqual(originalHex, roundTripHex);
        Assert.AreEqual(originalHex, roundTripColor.ToHex());
    }

    [TestMethod]
    public void RGBColorHex_SpecificColorValues_ParseCorrectly() {
        // Test specific color values to ensure RGB parsing works correctly
        var testCases = new Dictionary<string, string> {
            { "#000000", "#000000" }, // Black
            { "#FFFFFF", "#FFFFFF" }, // White
            { "#FF0000", "#FF0000" }, // Red
            { "#00FF00", "#00FF00" }, // Green
            { "#0000FF", "#0000FF" }, // Blue
            { "#111827", "#111827" }, // Original requirement
            { "#FFF", "#FFFFFF" },    // White (3-digit)
            { "#F00", "#FF0000" },    // Red (3-digit)
            { "#0F0", "#00FF00" },    // Green (3-digit)
            { "#00F", "#0000FF" }     // Blue (3-digit)
        };

        foreach (var testCase in testCases) {
            // Arrange & Act
            var color = new RGBColor(testCase.Key);

            // Assert
            Assert.AreEqual(testCase.Value, color.ToHex(),
                $"Failed for input '{testCase.Key}', expected '{testCase.Value}', got '{color.ToHex()}'");
        }
    }

    [TestMethod]
    public void RGBColorHex_CaseInsensitive_WorksCorrectly() {
        // Arrange
        var lowerCase = new RGBColor("#abc123");
        var upperCase = new RGBColor("#ABC123");
        var mixedCase = new RGBColor("#aBc123");

        // Assert - All should produce the same result
        Assert.AreEqual("#ABC123", lowerCase.ToHex());
        Assert.AreEqual("#ABC123", upperCase.ToHex());
        Assert.AreEqual("#ABC123", mixedCase.ToHex());
    }
}