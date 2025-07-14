namespace HtmlForgeX;

/// <summary>
/// Card states for interactive behavior
/// </summary>
public enum TablerCardState {
    Default,
    Active,
    Inactive,
    Hover,
    Disabled,
    Loading
}

/// <summary>
/// Card layout styles
/// </summary>
public enum TablerCardLayout {
    Default,
    Stacked,
    Borderless,
    Flush,
    Overlay
}

/// <summary>
/// Card header styles
/// </summary>
public enum TablerCardHeaderStyle {
    Default,
    Light,
    Dark,
    Transparent,
    Borderless
}

/// <summary>
/// Card footer styles
/// </summary>
public enum TablerCardFooterStyle {
    Default,
    Transparent,
    Borderless,
    Light,
    Dark
}

/// <summary>
/// Image positions for cards
/// </summary>
public enum TablerCardImagePosition {
    Top,
    Bottom,
    Left,
    Right,
    Background,
    Overlay
}

/// <summary>
/// Card content alignment
/// </summary>
public enum TablerCardAlignment {
    Start,
    Center,
    End,
    Stretch
}

/// <summary>
/// Card sizes
/// </summary>
public enum TablerCardSize {
    Small,
    Default,
    Large
}

public static class TablerCardStyleExtensions {
    public static string ToTablerCardStateClass(this TablerCardState state) {
        return state switch {
            TablerCardState.Active => "card-active",
            TablerCardState.Inactive => "card-inactive", 
            TablerCardState.Disabled => "card-disabled",
            TablerCardState.Loading => "card-loading",
            _ => ""
        };
    }
    
    public static string ToTablerCardLayoutClass(this TablerCardLayout layout) {
        return layout switch {
            TablerCardLayout.Stacked => "card-stacked",
            TablerCardLayout.Borderless => "card-borderless",
            TablerCardLayout.Flush => "card-flush",
            TablerCardLayout.Overlay => "card-overlay",
            _ => ""
        };
    }
    
    public static string ToTablerCardHeaderClass(this TablerCardHeaderStyle style) {
        return style switch {
            TablerCardHeaderStyle.Light => "card-header-light",
            TablerCardHeaderStyle.Dark => "card-header-dark",
            TablerCardHeaderStyle.Transparent => "card-header-transparent",
            TablerCardHeaderStyle.Borderless => "card-header-borderless",
            _ => ""
        };
    }
    
    public static string ToTablerCardFooterClass(this TablerCardFooterStyle style) {
        return style switch {
            TablerCardFooterStyle.Transparent => "card-footer-transparent",
            TablerCardFooterStyle.Borderless => "card-footer-borderless",
            TablerCardFooterStyle.Light => "card-footer-light",
            TablerCardFooterStyle.Dark => "card-footer-dark",
            _ => ""
        };
    }
    
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
    
    public static string ToTablerCardAlignmentClass(this TablerCardAlignment alignment) {
        return alignment switch {
            TablerCardAlignment.Start => "text-start",
            TablerCardAlignment.Center => "text-center",
            TablerCardAlignment.End => "text-end",
            TablerCardAlignment.Stretch => "d-flex flex-column h-100",
            _ => ""
        };
    }
    
    public static string ToTablerCardSizeClass(this TablerCardSize size) {
        return size switch {
            TablerCardSize.Small => "card-sm",
            TablerCardSize.Large => "card-lg",
            _ => ""
        };
    }
}