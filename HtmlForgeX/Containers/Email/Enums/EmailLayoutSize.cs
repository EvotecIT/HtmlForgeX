namespace HtmlForgeX;

/// <summary>
/// Predefined email layout sizes for common email width standards.
/// Provides easy-to-use options while allowing custom values for advanced users.
/// </summary>
public enum EmailLayoutSize {
    /// <summary>
    /// Compact layout - 480px width. Perfect for mobile-first designs.
    /// </summary>
    Compact,

    /// <summary>
    /// Standard layout - 600px width. Most common email width, works well across all clients.
    /// </summary>
    Standard,

    /// <summary>
    /// Wide layout - 800px width. Good for desktop-focused emails with more content.
    /// </summary>
    Wide,

    /// <summary>
    /// Extra wide layout - 1000px width. For newsletters and content-heavy emails.
    /// </summary>
    ExtraWide,

    /// <summary>
    /// Full width layout - 100% width. Adapts to container size, use with caution in emails.
    /// </summary>
    FullWidth,

    /// <summary>
    /// Custom size - allows specifying exact pixel value or percentage.
    /// </summary>
    Custom
}

/// <summary>
/// Extension methods for EmailLayoutSize enum.
/// </summary>
public static class EmailLayoutSizeExtensions {
    /// <summary>
    /// Converts EmailLayoutSize to CSS width value.
    /// </summary>
    /// <param name="size">The layout size.</param>
    /// <returns>CSS width value as string.</returns>
    public static string ToCssValue(this EmailLayoutSize size) {
        return size switch {
            EmailLayoutSize.Compact => "480px",
            EmailLayoutSize.Standard => "600px",
            EmailLayoutSize.Wide => "800px",
            EmailLayoutSize.ExtraWide => "1000px",
            EmailLayoutSize.FullWidth => "100%",
            EmailLayoutSize.Custom => "600px", // Default fallback
            _ => "600px"
        };
    }

    /// <summary>
    /// Gets a user-friendly description of the layout size.
    /// </summary>
    /// <param name="size">The layout size.</param>
    /// <returns>Description string.</returns>
    public static string GetDescription(this EmailLayoutSize size) {
        return size switch {
            EmailLayoutSize.Compact => "Compact (480px) - Mobile-first design",
            EmailLayoutSize.Standard => "Standard (600px) - Most common email width",
            EmailLayoutSize.Wide => "Wide (800px) - Desktop-focused emails",
            EmailLayoutSize.ExtraWide => "Extra Wide (1000px) - Content-heavy emails",
            EmailLayoutSize.FullWidth => "Full Width (100%) - Adaptive layout",
            EmailLayoutSize.Custom => "Custom - User-defined size",
            _ => "Standard (600px)"
        };
    }
}