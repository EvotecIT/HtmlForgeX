namespace HtmlForgeX;

public enum TablerStepsColor {
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
}

public static class TablerStepsColorExtensions {
    public static string EnumToString(this TablerStepsColor color) {
        return "steps-" + color.ToString().ToLower();
    }
}