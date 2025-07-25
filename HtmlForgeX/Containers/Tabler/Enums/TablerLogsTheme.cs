namespace HtmlForgeX;

/// <summary>
/// TablerLogsTheme enumeration.
/// </summary>
public enum TablerLogsTheme {
    /// <summary>
    /// Dark.
    /// </summary>
    Dark,
    /// <summary>
    /// Light.
    /// </summary>
    Light,
    /// <summary>
    /// Primary.
    /// </summary>
    Primary,
    /// <summary>
    /// Secondary.
    /// </summary>
    Secondary,
    /// <summary>
    /// Success.
    /// </summary>
    Success,
    /// <summary>
    /// Danger.
    /// </summary>
    Danger,
    /// <summary>
    /// Warning.
    /// </summary>
    Warning,
    /// <summary>
    /// Info.
    /// </summary>
    Info,
    /// <summary>
    /// Azure.
    /// </summary>
    Azure,
    /// <summary>
    /// Indigo.
    /// </summary>
    Indigo,
    /// <summary>
    /// Purple.
    /// </summary>
    Purple,
    /// <summary>
    /// Pink.
    /// </summary>
    Pink,
    /// <summary>
    /// Red.
    /// </summary>
    Red,
    /// <summary>
    /// Orange.
    /// </summary>
    Orange,
    /// <summary>
    /// Yellow.
    /// </summary>
    Yellow,
    /// <summary>
    /// Lime.
    /// </summary>
    Lime,
    /// <summary>
    /// Green.
    /// </summary>
    Green,
    /// <summary>
    /// Teal.
    /// </summary>
    Teal,
    /// <summary>
    /// Blue.
    /// </summary>
    Blue,
    /// <summary>
    /// Gray.
    /// </summary>
    Gray,
    /// <summary>
    /// Custom.
    /// </summary>
    Custom
}

/// <summary>
/// Extension methods for <see cref="TablerLogsTheme"/> values.
/// </summary>
public static class TablerLogsThemeExtensions {
    /// <summary>
    /// Initializes or configures ToClassString.
    /// </summary>
    public static string ToClassString(this TablerLogsTheme theme) {
        return theme switch {
            TablerLogsTheme.Dark => "bg-dark text-white",
            TablerLogsTheme.Light => "bg-light text-dark",
            TablerLogsTheme.Primary => "bg-primary text-white",
            TablerLogsTheme.Secondary => "bg-secondary text-white",
            TablerLogsTheme.Success => "bg-success text-white",
            TablerLogsTheme.Danger => "bg-danger text-white",
            TablerLogsTheme.Warning => "bg-warning text-dark",
            TablerLogsTheme.Info => "bg-info text-white",
            TablerLogsTheme.Azure => "bg-azure text-white",
            TablerLogsTheme.Indigo => "bg-indigo text-white",
            TablerLogsTheme.Purple => "bg-purple text-white",
            TablerLogsTheme.Pink => "bg-pink text-white",
            TablerLogsTheme.Red => "bg-red text-white",
            TablerLogsTheme.Orange => "bg-orange text-white",
            TablerLogsTheme.Yellow => "bg-yellow text-dark",
            TablerLogsTheme.Lime => "bg-lime text-dark",
            TablerLogsTheme.Green => "bg-green text-white",
            TablerLogsTheme.Teal => "bg-teal text-white",
            TablerLogsTheme.Blue => "bg-blue text-white",
            TablerLogsTheme.Gray => "bg-gray text-white",
            TablerLogsTheme.Custom => string.Empty,
            _ => throw new ArgumentOutOfRangeException(nameof(theme), theme, null)
        };
    }
}