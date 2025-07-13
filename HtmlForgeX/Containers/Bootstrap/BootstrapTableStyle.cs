namespace HtmlForgeX;

/// <summary>
/// Styles that can be applied to a Bootstrap table.
/// </summary>
public enum BootStrapTableStyle {
    /// <summary>
    /// Wrap the table in a responsive container.
    /// </summary>
    Responsive,
    /// <summary>
    /// Apply alternating row striping.
    /// </summary>
    Striped,
    /// <summary>
    /// Render the table using a dark theme.
    /// </summary>
    DarkMode,
    /// <summary>
    /// Add borders to all table cells.
    /// </summary>
    Borders,
    /// <summary>
    /// Highlight rows on hover.
    /// </summary>
    Hover,
    /// <summary>
    /// Use the small table style.
    /// </summary>
    Small,
    /// <summary>
    /// Use the medium table style.
    /// </summary>
    Medium,
    /// <summary>
    /// Use the large table style.
    /// </summary>
    Large
}

/// <summary>
/// Extension helpers for <see cref="BootStrapTableStyle"/> collections.
/// </summary>
public static class BootStrapTableStyleExtensions {
    /// <summary>
    /// Converts the style flags to the corresponding CSS class string.
    /// </summary>
    /// <param name="styles">Styles to convert.</param>
    /// <returns>A string with space separated CSS class names.</returns>
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