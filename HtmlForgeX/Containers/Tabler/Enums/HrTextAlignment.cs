namespace HtmlForgeX;

public enum HrTextAlignment {
    Center,
    Left,
    Right
}

public static class HrTextAlignmentExtensions {
    public static string ToClassString(this HrTextAlignment alignment) {
        return alignment switch {
            HrTextAlignment.Center => "",
            HrTextAlignment.Left => "hr-text-left",
            HrTextAlignment.Right => "hr-text-right",
            _ => throw new ArgumentOutOfRangeException(nameof(alignment), alignment, null)
        };
    }
}