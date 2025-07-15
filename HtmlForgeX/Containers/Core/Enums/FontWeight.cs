namespace HtmlForgeX;

/// <summary>
/// Common font-weight values mapped to numeric CSS representations.
/// </summary>
public enum FontWeight {
    /// <summary>Thin text (100)</summary>
    Thin,
    /// <summary>Extra light text (200)</summary>
    ExtraLight,
    /// <summary>Light text (300)</summary>
    Light,
    /// <summary>Normal text (400)</summary>
    Normal,
    /// <summary>Medium text (500)</summary>
    Medium,
    /// <summary>Semi-bold text (600)</summary>
    SemiBold,
    /// <summary>Bold text (700)</summary>
    Bold,
    /// <summary>Extra bold text (800)</summary>
    ExtraBold,
    /// <summary>Black text (900)</summary>
    Black
}

/// <summary>
/// Extension methods for the <see cref="FontWeight"/> enum.
/// </summary>
public static class FontWeightExtensions {
    /// <summary>
    /// Converts the enum value to the numeric CSS weight string.
    /// </summary>
    /// <param name="value">Font weight value.</param>
    /// <returns>Numeric CSS representation of the weight.</returns>
    public static string EnumToString(this FontWeight value) {
        return value switch {
            FontWeight.Thin => "100",
            FontWeight.ExtraLight => "200",
            FontWeight.Light => "300",
            FontWeight.Normal => "400",
            FontWeight.Medium => "500",
            FontWeight.SemiBold => "600",
            FontWeight.Bold => "700",
            FontWeight.ExtraBold => "800",
            FontWeight.Black => "900",
            _ => "400"
        };
    }

    /// <summary>
    /// Converts the font weight to its CSS representation.
    /// </summary>
    public static string ToCssValue(this FontWeight value) => value.EnumToString();
}
