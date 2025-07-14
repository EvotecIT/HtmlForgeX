namespace HtmlForgeX;

/// <summary>
/// Enumeration TablerLogsTheme.
/// </summary>
public enum TablerLogsTheme {
    Dark,
    Light,
    Primary,
    Secondary,
    Success,
    Danger,
    Warning,
    Info,
    Azure,
    Indigo,
    Purple,
    Pink,
    Red,
    Orange,
    Yellow,
    Lime,
    Green,
    Teal,
    Blue,
    Gray,
    Custom
}

public static class TablerLogsThemeExtensions {
/// <summary>
/// Method ToClassString.
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