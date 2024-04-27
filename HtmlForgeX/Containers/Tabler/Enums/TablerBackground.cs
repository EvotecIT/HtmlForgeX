namespace HtmlForgeX;

public enum TablerBackground {
    Primary,
    Info,
    Success,
    Facebook,
    Failed,
    Red,
    Green,
    Blue,
    Yellow,
    Twitter,
    Danger,
    Warning
    // Add more backgrounds here
}

public static class TablerBackgroundExtensions {
    public static string EnumToString(this TablerBackground background) {
        return background switch {
            TablerBackground.Primary => "bg-primary",
            TablerBackground.Info => "bg-info",
            TablerBackground.Success => "bg-success",
            TablerBackground.Facebook => "bg-facebook",
            TablerBackground.Failed => "bg-failed",
            TablerBackground.Red => "bg-red",
            TablerBackground.Green => "bg-green",
            TablerBackground.Blue => "bg-blue",
            TablerBackground.Yellow => "bg-yellow",
            TablerBackground.Twitter => "bg-twitter",
            TablerBackground.Danger => "bg-danger",
            TablerBackground.Warning => "bg-warning",
            _ => throw new ArgumentOutOfRangeException(nameof(background), background, null)
        };
    }
}
