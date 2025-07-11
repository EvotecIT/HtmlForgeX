namespace HtmlForgeX;

/// <summary>
/// Defines additional text style utilities.
/// </summary>
public enum TablerTextStyle {
    Muted,
    Truncate
    // Add more options here as needed
}

public static class TextStyleExtensions {
    public static string EnumToString(this TablerTextStyle style) {
        return "text-" + style.ToString().ToLower();
    }
}
