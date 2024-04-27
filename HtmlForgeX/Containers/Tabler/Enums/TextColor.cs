namespace HtmlForgeX;

public enum TextColor {
    Default,
    Green,
    Primary,
    Warning,
    Danger,
    Info,
    Success,
    Facebook,
    Twitter,
    // Add more colors here
}
public static class TextColorExtensions {
    public static string ToClassString(this TextColor color) {
        return color switch {
            TextColor.Default => "",
            TextColor.Green => "text-success",
            TextColor.Primary => "text-primary",
            TextColor.Warning => "text-warning",
            TextColor.Danger => "text-danger",
            TextColor.Info => "text-info",
            TextColor.Success => "text-success",
            TextColor.Facebook => "text-facebook",
            TextColor.Twitter => "text-twitter",
            _ => throw new ArgumentOutOfRangeException(nameof(color), color, null)
        };
    }
}

