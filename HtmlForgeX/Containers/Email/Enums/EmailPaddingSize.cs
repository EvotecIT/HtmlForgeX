namespace HtmlForgeX;

/// <summary>
/// Predefined email padding sizes for consistent spacing throughout email layouts.
/// Provides easy-to-use options while allowing custom values for advanced users.
/// </summary>
public enum EmailPaddingSize {
    /// <summary>
    /// No padding - 0px. Use for tight layouts or when you want elements to touch edges.
    /// </summary>
    None,

    /// <summary>
    /// Extra small padding - 4px. Minimal spacing for very compact designs.
    /// </summary>
    ExtraSmall,

    /// <summary>
    /// Small padding - 8px. Compact but readable spacing.
    /// </summary>
    Small,

    /// <summary>
    /// Medium padding - 12px. Good balance of space and content density.
    /// </summary>
    Medium,

    /// <summary>
    /// Large padding - 16px. Generous spacing for comfortable reading.
    /// </summary>
    Large,

    /// <summary>
    /// Extra large padding - 24px. Very spacious layout for premium feel.
    /// </summary>
    ExtraLarge,

    /// <summary>
    /// Custom padding - allows specifying exact value.
    /// </summary>
    Custom
}

/// <summary>
/// Extension methods for EmailPaddingSize enum.
/// </summary>
public static class EmailPaddingSizeExtensions {
    /// <summary>
    /// Converts EmailPaddingSize to CSS padding value.
    /// </summary>
    /// <param name="size">The padding size.</param>
    /// <returns>CSS padding value as string.</returns>
    public static string ToCssValue(this EmailPaddingSize size) {
        return size switch {
            EmailPaddingSize.None => "0px",
            EmailPaddingSize.ExtraSmall => "4px",
            EmailPaddingSize.Small => "8px",
            EmailPaddingSize.Medium => "12px",
            EmailPaddingSize.Large => "16px",
            EmailPaddingSize.ExtraLarge => "24px",
            EmailPaddingSize.Custom => "12px", // Default fallback
            _ => "12px"
        };
    }

    /// <summary>
    /// Gets a user-friendly description of the padding size.
    /// </summary>
    /// <param name="size">The padding size.</param>
    /// <returns>Description string.</returns>
    public static string GetDescription(this EmailPaddingSize size) {
        return size switch {
            EmailPaddingSize.None => "None (0px) - No spacing",
            EmailPaddingSize.ExtraSmall => "Extra Small (4px) - Minimal spacing",
            EmailPaddingSize.Small => "Small (8px) - Compact spacing",
            EmailPaddingSize.Medium => "Medium (12px) - Balanced spacing",
            EmailPaddingSize.Large => "Large (16px) - Generous spacing",
            EmailPaddingSize.ExtraLarge => "Extra Large (24px) - Very spacious",
            EmailPaddingSize.Custom => "Custom - User-defined spacing",
            _ => "Medium (12px)"
        };
    }
}