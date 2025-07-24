namespace HtmlForgeX;

/// <summary>
/// Border styles for Tabler cards and components
/// </summary>
public enum TablerBorderStyle {
    /// <summary>
    /// None.
    /// </summary>
    None,
    /// <summary>
    /// Solid.
    /// </summary>
    Solid,
    /// <summary>
    /// Dashed.
    /// </summary>
    Dashed,
    /// <summary>
    /// Dotted.
    /// </summary>
    Dotted
}

/// <summary>
/// Border positions for Tabler cards
/// </summary>
public enum TablerBorderPosition {
    /// <summary>
    /// All.
    /// </summary>
    All,
    /// <summary>
    /// Top.
    /// </summary>
    Top,
    /// <summary>
    /// Bottom.
    /// </summary>
    Bottom,
    /// <summary>
    /// Start.
    /// </summary>
    Start,
    /// <summary>
    /// End.
    /// </summary>
    End,
    /// <summary>
    /// Horizontal.
    /// </summary>
    Horizontal,
    /// <summary>
    /// Vertical.
    /// </summary>
    Vertical
}

/// <summary>
/// Border widths for Tabler cards
/// </summary>
public enum TablerBorderWidth {
    /// <summary>
    /// Default.
    /// </summary>
    Default,
    /// <summary>
    /// Thin.
    /// </summary>
    Thin,
    /// <summary>
    /// Thick.
    /// </summary>
    Thick,
    /// <summary>
    /// None.
    /// </summary>
    None
}

/// <summary>
/// Shadow intensities for Tabler cards
/// </summary>
public enum TablerShadow {
    /// <summary>
    /// None.
    /// </summary>
    None,
    /// <summary>
    /// Small.
    /// </summary>
    Small,
    /// <summary>
    /// Medium.
    /// </summary>
    Medium,
    /// <summary>
    /// Large.
    /// </summary>
    Large,
    /// <summary>
    /// Extra large.
    /// </summary>
    ExtraLarge
}

/// <summary>
/// Border radius options for Tabler cards
/// </summary>
public enum TablerBorderRadius {
    /// <summary>
    /// None.
    /// </summary>
    None,
    /// <summary>
    /// Small.
    /// </summary>
    Small,
    /// <summary>
    /// Medium.
    /// </summary>
    Medium,
    /// <summary>
    /// Large.
    /// </summary>
    Large,
    /// <summary>
    /// Extra large.
    /// </summary>
    ExtraLarge,
    /// <summary>
    /// Round.
    /// </summary>
    Round,
    /// <summary>
    /// Pill.
    /// </summary>
    Pill
}

/// <summary>
/// Extension methods for Tabler border-related enums.
/// </summary>
public static class TablerBorderExtensions {
    /// <summary>
    /// Initializes or configures ToTablerBorderClass.
    /// </summary>
    public static string ToTablerBorderClass(this TablerBorderStyle style, TablerBorderPosition position = TablerBorderPosition.All, TablerBorderWidth width = TablerBorderWidth.Default) {
        var classes = new List<string>();

        // Position classes
        var positionClass = position switch {
            TablerBorderPosition.Top => "border-top",
            TablerBorderPosition.Bottom => "border-bottom",
            TablerBorderPosition.Start => "border-start",
            TablerBorderPosition.End => "border-end",
            TablerBorderPosition.Horizontal => "border-top border-bottom",
            TablerBorderPosition.Vertical => "border-start border-end",
            _ => "border"
        };

        if (style != TablerBorderStyle.None) {
            classes.Add(positionClass);
        }

        // Width classes
        var widthClass = width switch {
            TablerBorderWidth.Thin => "border-1",
            TablerBorderWidth.Thick => "border-3",
            TablerBorderWidth.None => "border-0",
            _ => ""
        };

        if (!string.IsNullOrEmpty(widthClass)) {
            classes.Add(widthClass);
        }

        // Style classes
        var styleClass = style switch {
            TablerBorderStyle.Dashed => "border-dashed",
            TablerBorderStyle.Dotted => "border-dotted",
            _ => ""
        };

        if (!string.IsNullOrEmpty(styleClass)) {
            classes.Add(styleClass);
        }

        return string.Join(" ", classes);
    }

    /// <summary>
    /// Initializes or configures ToTablerShadowClass.
    /// </summary>
    public static string ToTablerShadowClass(this TablerShadow shadow) {
        return shadow switch {
            TablerShadow.Small => "shadow-sm",
            TablerShadow.Medium => "shadow",
            TablerShadow.Large => "shadow-lg",
            TablerShadow.ExtraLarge => "shadow-xl",
            _ => ""
        };
    }

    /// <summary>
    /// Initializes or configures ToTablerRadiusClass.
    /// </summary>
    public static string ToTablerRadiusClass(this TablerBorderRadius radius) {
        return radius switch {
            TablerBorderRadius.Small => "rounded-1",
            TablerBorderRadius.Medium => "rounded-2",
            TablerBorderRadius.Large => "rounded-3",
            TablerBorderRadius.ExtraLarge => "rounded-4",
            TablerBorderRadius.Round => "rounded-circle",
            TablerBorderRadius.Pill => "rounded-pill",
            TablerBorderRadius.None => "rounded-0",
            _ => ""
        };
    }
}