namespace HtmlForgeX;

/// <summary>
/// Defines predefined spacing values for email components.
/// </summary>
public enum EmailSpacing {
    /// <summary>No spacing (0)</summary>
    None,
    /// <summary>Extra small spacing (4px)</summary>
    ExtraSmall,
    /// <summary>Small spacing (8px)</summary>
    Small,
    /// <summary>Medium spacing (16px)</summary>
    Medium,
    /// <summary>Large spacing (24px)</summary>
    Large,
    /// <summary>Extra large spacing (32px)</summary>
    ExtraLarge,
    /// <summary>Double extra large spacing (48px)</summary>
    DoubleExtraLarge
}

public static class EmailSpacingExtensions {
    public static string ToCssValue(this EmailSpacing spacing) {
        return spacing switch {
            EmailSpacing.None => "0",
            EmailSpacing.ExtraSmall => "4px",
            EmailSpacing.Small => "8px",
            EmailSpacing.Medium => "16px",
            EmailSpacing.Large => "24px",
            EmailSpacing.ExtraLarge => "32px",
            EmailSpacing.DoubleExtraLarge => "48px",
            _ => "0"
        };
    }
}