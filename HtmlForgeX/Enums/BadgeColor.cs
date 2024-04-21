namespace HtmlForgeX;

public enum BadgeColor {
    Blue,
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
    Cyan,
    White
}

public static class BadgeColorExtensions {
    public static string ToLowerString(this BadgeColor color) {
        return color.ToString().ToLower();
    }
}