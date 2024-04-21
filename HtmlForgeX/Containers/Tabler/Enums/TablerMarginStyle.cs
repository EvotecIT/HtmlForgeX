namespace HtmlForgeX;

public enum TablerMarginStyle {
    M0,
    M1,
    M2,
    M3,
    M4,
    M5
    // Add more options here as needed
}

public static class MarginStyleExtensions {
    public static string EnumToString(this TablerMarginStyle style) {
        return "m-" + style.ToString().Substring(1);
    }
}