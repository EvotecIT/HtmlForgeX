namespace HtmlForgeX;

/// <summary>
/// Vertical alignment options for table cells in email layouts.
/// </summary>
public enum VerticalAlignment
{
    /// <summary>Align content to the top.</summary>
    Top,

    /// <summary>Center content vertically.</summary>
    Middle,

    /// <summary>Align content to the bottom.</summary>
    Bottom
}

/// <summary>
/// Extension methods for <see cref="VerticalAlignment"/>.
/// </summary>
public static class VerticalAlignmentExtensions
{
    /// <summary>
    /// Converts the alignment value to its CSS representation.
    /// </summary>
    /// <param name="alignment">Alignment option.</param>
    /// <returns>CSS vertical-align value.</returns>
    public static string ToCssValue(this VerticalAlignment alignment) => alignment switch
    {
        VerticalAlignment.Top => "top",
        VerticalAlignment.Middle => "middle",
        VerticalAlignment.Bottom => "bottom",
        _ => "top"
    };
}
