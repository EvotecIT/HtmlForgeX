namespace HtmlForgeX;

/// <summary>
/// Vertical alignment options for table cells in email layouts.
/// </summary>
public enum EmailVerticalAlignment
{
    /// <summary>Align content to the top.</summary>
    Top,

    /// <summary>Center content vertically.</summary>
    Middle,

    /// <summary>Align content to the bottom.</summary>
    Bottom
}

/// <summary>
/// Extension methods for <see cref="EmailVerticalAlignment"/>.
/// </summary>
public static class EmailVerticalAlignmentExtensions
{
    /// <summary>
    /// Converts the alignment value to its CSS representation.
    /// </summary>
    /// <param name="alignment">Alignment option.</param>
    /// <returns>CSS vertical-align value.</returns>
    public static string ToCssValue(this EmailVerticalAlignment alignment) => alignment switch
    {
        EmailVerticalAlignment.Top => "top",
        EmailVerticalAlignment.Middle => "middle",
        EmailVerticalAlignment.Bottom => "bottom",
        _ => "top"
    };
}
