namespace HtmlForgeX;

/// <summary>
/// Specifies progress bar variations.
/// </summary>
public enum TablerProgressBarType {
    Separated,
    Small,
    Indeterminate
}


public static class TablerProgressBarTypeExtensions {
    public static string ToClassString(this TablerProgressBarType type) {
        return type switch {
            TablerProgressBarType.Separated => "progress-separated",
            TablerProgressBarType.Small => "progress-sm",
            TablerProgressBarType.Indeterminate => "progress-bar-indeterminate",

            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
}
