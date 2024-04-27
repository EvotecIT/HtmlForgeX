namespace HtmlForgeX;

public enum TablerProgressBarType {
    Regular,
    Separated,
    Small,
    // Add more types here
}


public static class TablerProgressBarTypeExtensions {
    public static string ToClassString(this TablerProgressBarType type) {
        return type switch {
            TablerProgressBarType.Regular => "progress",
            TablerProgressBarType.Separated => "progress-separated",
            TablerProgressBarType.Small => "progress-sm",
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
}
