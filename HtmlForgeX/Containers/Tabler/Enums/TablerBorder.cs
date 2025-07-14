namespace HtmlForgeX;

/// <summary>
/// Border styles for Tabler cards and components
/// </summary>
public enum TablerBorderStyle {
    None,
    Solid,
    Dashed,
    Dotted
}

/// <summary>
/// Border positions for Tabler cards
/// </summary>
public enum TablerBorderPosition {
    All,
    Top,
    Bottom,
    Start,
    End,
    Horizontal,
    Vertical
}

/// <summary>
/// Border widths for Tabler cards
/// </summary>
public enum TablerBorderWidth {
    Default,
    Thin,
    Thick,
    None
}

/// <summary>
/// Shadow intensities for Tabler cards
/// </summary>
public enum TablerShadow {
    None,
    Small,
    Medium,
    Large,
    ExtraLarge
}

/// <summary>
/// Border radius options for Tabler cards
/// </summary>
public enum TablerBorderRadius {
    None,
    Small,
    Medium,
    Large,
    ExtraLarge,
    Round,
    Pill
}

public static class TablerBorderExtensions {
/// <summary>
/// Method ToTablerBorderClass.
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
/// Method ToTablerShadowClass.
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
/// Method ToTablerRadiusClass.
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