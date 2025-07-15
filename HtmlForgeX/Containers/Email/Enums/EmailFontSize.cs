namespace HtmlForgeX;

/// <summary>
/// Defines predefined font sizes for email components.
/// </summary>
public enum EmailFontSize {
    /// <summary>Small text (12px)</summary>
    Small,
    /// <summary>Regular text (14px)</summary>
    Regular,
    /// <summary>Medium text (16px)</summary>
    Medium,
    /// <summary>Large text (18px)</summary>
    Large,
    /// <summary>Extra large text (20px)</summary>
    ExtraLarge,
    /// <summary>Heading 1 (32px)</summary>
    Heading1,
    /// <summary>Heading 2 (24px)</summary>
    Heading2,
    /// <summary>Heading 3 (20px)</summary>
    Heading3
}

/// <summary>
/// Helper methods for <see cref="EmailFontSize"/> values.
/// </summary>
public static class EmailFontSizeExtensions {
    public static string ToCssValue(this EmailFontSize fontSize) {
        return fontSize switch {
            EmailFontSize.Small => "12px",
            EmailFontSize.Regular => "14px",
            EmailFontSize.Medium => "16px",
            EmailFontSize.Large => "18px",
            EmailFontSize.ExtraLarge => "20px",
            EmailFontSize.Heading1 => "32px",
            EmailFontSize.Heading2 => "24px",
            EmailFontSize.Heading3 => "20px",
            _ => "14px"
        };
    }

    /// <summary>
    /// Gets the appropriate line height for the font size to ensure proper alignment.
    /// </summary>
    public static string ToLineHeight(this EmailFontSize fontSize) {
        return fontSize switch {
            EmailFontSize.Small => "140%",      // 12px with tight line height
            EmailFontSize.Regular => "150%",    // 14px with normal line height
            EmailFontSize.Medium => "150%",     // 16px with normal line height
            EmailFontSize.Large => "140%",      // 18px with slightly tighter
            EmailFontSize.ExtraLarge => "130%", // 20px with tighter line height
            EmailFontSize.Heading1 => "110%",   // 32px with tight line height for headings
            EmailFontSize.Heading2 => "120%",   // 24px with tight line height for headings
            EmailFontSize.Heading3 => "125%",   // 20px with tight line height for headings
            _ => "150%"
        };
    }

    /// <summary>
    /// Gets the appropriate margin for the font size to ensure proper spacing.
    /// </summary>
    public static string ToDefaultMargin(this EmailFontSize fontSize) {
        return fontSize switch {
            EmailFontSize.Small => "0 0 8px 0",       // Small spacing after small text
            EmailFontSize.Regular => "0 0 12px 0",     // Normal spacing after regular text
            EmailFontSize.Medium => "0 0 14px 0",      // Slightly more space after medium text
            EmailFontSize.Large => "0 0 16px 0",       // More space after large text
            EmailFontSize.ExtraLarge => "0 0 18px 0",  // More space after extra large text
            EmailFontSize.Heading1 => "0 0 24px 0",    // Large space after main heading
            EmailFontSize.Heading2 => "0 0 20px 0",    // Medium space after sub heading
            EmailFontSize.Heading3 => "0 0 16px 0",    // Small space after minor heading
            _ => "0 0 12px 0"
        };
    }
}