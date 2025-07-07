namespace HtmlForgeX;

/// <summary>
/// Defines predefined font weights for email components.
/// </summary>
public enum EmailFontWeight {
    /// <summary>Normal text (400)</summary>
    Normal,
    /// <summary>Medium text (500)</summary>
    Medium,
    /// <summary>Semi-bold text (600)</summary>
    SemiBold,
    /// <summary>Bold text (700)</summary>
    Bold,
    /// <summary>Extra bold text (800)</summary>
    ExtraBold
}

public static class EmailFontWeightExtensions {
    public static string ToCssValue(this EmailFontWeight fontWeight) {
        return fontWeight switch {
            EmailFontWeight.Normal => "400",
            EmailFontWeight.Medium => "500",
            EmailFontWeight.SemiBold => "600",
            EmailFontWeight.Bold => "700",
            EmailFontWeight.ExtraBold => "800",
            _ => "400"
        };
    }
}