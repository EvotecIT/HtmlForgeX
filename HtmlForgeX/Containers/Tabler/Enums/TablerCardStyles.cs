namespace HtmlForgeX;

/// <summary>
/// Card states for interactive behavior
/// </summary>
public enum TablerCardState {
    /// <summary>
    /// Default.
    /// </summary>
    Default,
    /// <summary>
    /// Active.
    /// </summary>
    Active,
    /// <summary>
    /// Inactive.
    /// </summary>
    Inactive,
    /// <summary>
    /// Hover.
    /// </summary>
    Hover,
    /// <summary>
    /// Disabled.
    /// </summary>
    Disabled,
    /// <summary>
    /// Loading.
    /// </summary>
    Loading
}

/// <summary>
/// Card layout styles
/// </summary>
public enum TablerCardLayout {
    /// <summary>
    /// Default.
    /// </summary>
    Default,
    /// <summary>
    /// Stacked.
    /// </summary>
    Stacked,
    /// <summary>
    /// Borderless.
    /// </summary>
    Borderless,
    /// <summary>
    /// Flush.
    /// </summary>
    Flush,
    /// <summary>
    /// Overlay.
    /// </summary>
    Overlay
}

/// <summary>
/// Card header styles
/// </summary>
public enum TablerCardHeaderStyle {
    /// <summary>
    /// Default.
    /// </summary>
    Default,
    /// <summary>
    /// Light.
    /// </summary>
    Light,
    /// <summary>
    /// Dark.
    /// </summary>
    Dark,
    /// <summary>
    /// Transparent.
    /// </summary>
    Transparent,
    /// <summary>
    /// Borderless.
    /// </summary>
    Borderless
}

/// <summary>
/// Card footer styles
/// </summary>
public enum TablerCardFooterStyle {
    /// <summary>
    /// Default.
    /// </summary>
    Default,
    /// <summary>
    /// Transparent.
    /// </summary>
    Transparent,
    /// <summary>
    /// Borderless.
    /// </summary>
    Borderless,
    /// <summary>
    /// Light.
    /// </summary>
    Light,
    /// <summary>
    /// Dark.
    /// </summary>
    Dark
}

/// <summary>
/// Image positions for cards
/// </summary>
public enum TablerCardImagePosition {
    /// <summary>
    /// Top.
    /// </summary>
    Top,
    /// <summary>
    /// Bottom.
    /// </summary>
    Bottom,
    /// <summary>
    /// Left.
    /// </summary>
    Left,
    /// <summary>
    /// Right.
    /// </summary>
    Right,
    /// <summary>
    /// Background.
    /// </summary>
    Background,
    /// <summary>
    /// Overlay.
    /// </summary>
    Overlay
}

/// <summary>
/// Card content alignment
/// </summary>
public enum TablerCardAlignment {
    /// <summary>
    /// Start.
    /// </summary>
    Start,
    /// <summary>
    /// Center.
    /// </summary>
    Center,
    /// <summary>
    /// End.
    /// </summary>
    End,
    /// <summary>
    /// Stretch.
    /// </summary>
    Stretch
}

/// <summary>
/// Card sizes
/// </summary>
public enum TablerCardSize {
    /// <summary>
    /// Small.
    /// </summary>
    Small,
    /// <summary>
    /// Default.
    /// </summary>
    Default,
    /// <summary>
    /// Large.
    /// </summary>
    Large
}

/// <summary>
/// Extension methods for card style enums.
/// </summary>
public static class TablerCardStyleExtensions {
    /// <summary>
    /// Converts a card state to its corresponding CSS class.
    /// </summary>
    public static string ToTablerCardStateClass(this TablerCardState state) {
        return state switch {
            TablerCardState.Active => "card-active",
            TablerCardState.Inactive => "card-inactive",
            TablerCardState.Disabled => "card-disabled",
            TablerCardState.Loading => "card-loading",
            _ => ""
        };
    }

    /// <summary>
    /// Converts a card layout option to its CSS class.
    /// </summary>
    public static string ToTablerCardLayoutClass(this TablerCardLayout layout) {
        return layout switch {
            TablerCardLayout.Stacked => "card-stacked",
            TablerCardLayout.Borderless => "card-borderless",
            TablerCardLayout.Flush => "card-flush",
            TablerCardLayout.Overlay => "card-overlay",
            _ => ""
        };
    }

    /// <summary>
    /// Converts a header style value to its Tabler CSS class.
    /// </summary>
    public static string ToTablerCardHeaderClass(this TablerCardHeaderStyle style) {
        return style switch {
            TablerCardHeaderStyle.Light => "card-header-light",
            TablerCardHeaderStyle.Dark => "card-header-dark",
            TablerCardHeaderStyle.Transparent => "card-header-transparent",
            TablerCardHeaderStyle.Borderless => "card-header-borderless",
            _ => ""
        };
    }

    /// <summary>
    /// Converts a footer style value to its Tabler CSS class.
    /// </summary>
    public static string ToTablerCardFooterClass(this TablerCardFooterStyle style) {
        return style switch {
            TablerCardFooterStyle.Transparent => "card-footer-transparent",
            TablerCardFooterStyle.Borderless => "card-footer-borderless",
            TablerCardFooterStyle.Light => "card-footer-light",
            TablerCardFooterStyle.Dark => "card-footer-dark",
            _ => ""
        };
    }

    /// <summary>
    /// Gets the CSS class for positioning a card image.
    /// </summary>
    public static string ToTablerCardImageClass(this TablerCardImagePosition position) {
        return position switch {
            TablerCardImagePosition.Top => "card-img-top",
            TablerCardImagePosition.Bottom => "card-img-bottom",
            TablerCardImagePosition.Left => "card-img-start",
            TablerCardImagePosition.Right => "card-img-end",
            TablerCardImagePosition.Background => "card-img-background",
            TablerCardImagePosition.Overlay => "card-img-overlay",
            _ => ""
        };
    }

    /// <summary>
    /// Converts an alignment option to the respective text or layout class.
    /// </summary>
    public static string ToTablerCardAlignmentClass(this TablerCardAlignment alignment) {
        return alignment switch {
            TablerCardAlignment.Start => "text-start",
            TablerCardAlignment.Center => "text-center",
            TablerCardAlignment.End => "text-end",
            TablerCardAlignment.Stretch => "d-flex flex-column h-100",
            _ => ""
        };
    }

    /// <summary>
    /// Converts a card size value to its Tabler CSS class.
    /// </summary>
    public static string ToTablerCardSizeClass(this TablerCardSize size) {
        return size switch {
            TablerCardSize.Small => "card-sm",
            TablerCardSize.Large => "card-lg",
            _ => ""
        };
    }
}
