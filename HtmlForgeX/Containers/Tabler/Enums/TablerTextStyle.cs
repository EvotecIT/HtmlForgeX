namespace HtmlForgeX;

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
