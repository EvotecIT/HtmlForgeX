namespace HtmlForgeX;

/// <summary>
/// Defines spacing values for Bootstrap/Tabler spacing utilities.
/// These map to Bootstrap's spacing classes (m-*, p-*, g-*, etc.)
/// </summary>
public enum TablerSpacing {
    /// <summary>
    /// No spacing (0)
    /// </summary>
    None = 0,

    /// <summary>
    /// Extra small spacing (1)
    /// </summary>
    ExtraSmall = 1,

    /// <summary>
    /// Small spacing (2)
    /// </summary>
    Small = 2,

    /// <summary>
    /// Medium spacing (3) - Default
    /// </summary>
    Medium = 3,

    /// <summary>
    /// Large spacing (4)
    /// </summary>
    Large = 4,

    /// <summary>
    /// Extra large spacing (5)
    /// </summary>
    ExtraLarge = 5,

    /// <summary>
    /// Auto spacing (auto)
    /// </summary>
    Auto = -1
}

/// <summary>
/// Defines directions for spacing utilities
/// </summary>
public enum TablerSpacingDirection {
    /// <summary>
    /// All directions
    /// </summary>
    All,

    /// <summary>
    /// Top only
    /// </summary>
    Top,

    /// <summary>
    /// Bottom only
    /// </summary>
    Bottom,

    /// <summary>
    /// Start (left in LTR, right in RTL)
    /// </summary>
    Start,

    /// <summary>
    /// End (right in LTR, left in RTL)
    /// </summary>
    End,

    /// <summary>
    /// Horizontal (left and right)
    /// </summary>
    Horizontal,

    /// <summary>
    /// Vertical (top and bottom)
    /// </summary>
    Vertical
}

/// <summary>
/// Extension methods for spacing utilities
/// </summary>
public static class TablerSpacingExtensions {
    /// <summary>
    /// Converts spacing enum to Bootstrap spacing value
    /// </summary>
    public static string ToSpacingValue(this TablerSpacing spacing) {
        return spacing switch {
            TablerSpacing.None => "0",
            TablerSpacing.ExtraSmall => "1",
            TablerSpacing.Small => "2",
            TablerSpacing.Medium => "3",
            TablerSpacing.Large => "4",
            TablerSpacing.ExtraLarge => "5",
            TablerSpacing.Auto => "auto",
            _ => "3"
        };
    }

    /// <summary>
    /// Converts direction enum to Bootstrap direction suffix
    /// </summary>
    public static string ToDirectionSuffix(this TablerSpacingDirection direction) {
        return direction switch {
            TablerSpacingDirection.All => "",
            TablerSpacingDirection.Top => "t",
            TablerSpacingDirection.Bottom => "b",
            TablerSpacingDirection.Start => "s",
            TablerSpacingDirection.End => "e",
            TablerSpacingDirection.Horizontal => "x",
            TablerSpacingDirection.Vertical => "y",
            _ => ""
        };
    }

    /// <summary>
    /// Creates a margin class string
    /// </summary>
    public static string ToMarginClass(this TablerSpacing spacing, TablerSpacingDirection direction = TablerSpacingDirection.All) {
        var suffix = direction.ToDirectionSuffix();
        var value = spacing.ToSpacingValue();
        return $"m{suffix}-{value}";
    }

    /// <summary>
    /// Creates a padding class string
    /// </summary>
    public static string ToPaddingClass(this TablerSpacing spacing, TablerSpacingDirection direction = TablerSpacingDirection.All) {
        var suffix = direction.ToDirectionSuffix();
        var value = spacing.ToSpacingValue();
        return $"p{suffix}-{value}";
    }

    /// <summary>
    /// Creates a gap class string (for flexbox/grid)
    /// </summary>
    public static string ToGapClass(this TablerSpacing spacing) {
        var value = spacing.ToSpacingValue();
        return $"g-{value}";
    }
}