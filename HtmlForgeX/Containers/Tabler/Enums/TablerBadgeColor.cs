namespace HtmlForgeX;

public enum TablerBadgeColor {
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
    public static string EnumToString(this TablerBadgeColor color) {
        return color.ToString().ToLower();
    }
}