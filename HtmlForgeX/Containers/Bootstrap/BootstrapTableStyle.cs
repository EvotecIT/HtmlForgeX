namespace HtmlForgeX;

public enum BootStrapTableStyle {
    Responsive,
    Striped,
    DarkMode,
    Borders,
    Hover,
    Small,
    Medium,
    Large
}

public static class BootStrapTableStyleExtensions {
    public static string BuildTableStyles(this IEnumerable<BootStrapTableStyle> styles) {
        var classes = new List<string> { "table" };
        foreach (var style in styles) {
            switch (style) {
                case BootStrapTableStyle.Responsive:
                    classes.Add("table-responsive");
                    break;
                case BootStrapTableStyle.Striped:
                    classes.Add("table-striped");
                    break;
                case BootStrapTableStyle.DarkMode:
                    classes.Add("table-dark");
                    break;
                case BootStrapTableStyle.Borders:
                    classes.Add("table-bordered");
                    break;
                case BootStrapTableStyle.Hover:
                    classes.Add("table-hover");
                    break;
                case BootStrapTableStyle.Small:
                    classes.Add("table-sm");
                    break;
                case BootStrapTableStyle.Medium:
                    classes.Add("table-md");
                    break;
                case BootStrapTableStyle.Large:
                    classes.Add("table-lg");
                    break;
            }
        }
        return string.Join(" ", classes);
    }
}