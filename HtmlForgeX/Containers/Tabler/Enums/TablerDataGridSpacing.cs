namespace HtmlForgeX;

/// <summary>
/// Defines spacing values for DataGrid components, allowing fine-grained control over item spacing.
/// </summary>
public enum TablerDataGridSpacing {
    /// <summary>No spacing (0px)</summary>
    None,
    /// <summary>Extra small spacing (4px)</summary>
    ExtraSmall,
    /// <summary>Small spacing (8px)</summary>
    Small,
    /// <summary>Medium spacing (12px) - default</summary>
    Medium,
    /// <summary>Large spacing (16px)</summary>
    Large,
    /// <summary>Extra large spacing (24px)</summary>
    ExtraLarge,
    /// <summary>Custom spacing - allows custom CSS value</summary>
    Custom
}

/// <summary>
/// Extension helpers for <see cref="TablerDataGridSpacing"/> values.
/// </summary>
public static class TablerDataGridSpacingExtensions {
    /// <summary>
    /// Converts TablerDataGridSpacing to CSS value.
    /// </summary>
    /// <param name="spacing">The spacing enum value.</param>
    /// <returns>CSS spacing value as string.</returns>
    public static string ToCssValue(this TablerDataGridSpacing spacing) {
        return spacing switch {
            TablerDataGridSpacing.None => "0px",
            TablerDataGridSpacing.ExtraSmall => "4px",
            TablerDataGridSpacing.Small => "8px",
            TablerDataGridSpacing.Medium => "12px",
            TablerDataGridSpacing.Large => "16px",
            TablerDataGridSpacing.ExtraLarge => "24px",
            TablerDataGridSpacing.Custom => "12px", // Default fallback
            _ => "12px"
        };
    }

    /// <summary>
    /// Gets a user-friendly description of the spacing value.
    /// </summary>
    /// <param name="spacing">The spacing enum value.</param>
    /// <returns>Description string.</returns>
    public static string GetDescription(this TablerDataGridSpacing spacing) {
        return spacing switch {
            TablerDataGridSpacing.None => "None (0px) - No spacing",
            TablerDataGridSpacing.ExtraSmall => "Extra Small (4px) - Minimal spacing",
            TablerDataGridSpacing.Small => "Small (8px) - Compact spacing",
            TablerDataGridSpacing.Medium => "Medium (12px) - Balanced spacing",
            TablerDataGridSpacing.Large => "Large (16px) - Generous spacing",
            TablerDataGridSpacing.ExtraLarge => "Extra Large (24px) - Very spacious",
            TablerDataGridSpacing.Custom => "Custom - User-defined spacing",
            _ => "Medium (12px)"
        };
    }
}
