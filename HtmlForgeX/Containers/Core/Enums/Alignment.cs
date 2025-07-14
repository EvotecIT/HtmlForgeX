using System;

namespace HtmlForgeX;

/// <summary>
/// Alignment options for text. The <c>Justify</c> value is not consistently
/// supported by many email clients and may not render as expected.
/// </summary>
public enum Alignment {
    Left = 1,
    Center,
    Right,
    Justify
}

/// <summary>
/// Extension methods for the <see cref="Alignment"/> enum.
/// </summary>
public static class AlignmentExtensions {
    public static string ToCssValue(this Alignment alignment) => alignment switch
    {
        Alignment.Left => "left",
        Alignment.Center => "center",
        Alignment.Right => "right",
        Alignment.Justify => "justify",
        _ => "left"
    };

    public static void ValidateEmailAlignment(this Alignment alignment) {
        if (alignment is Alignment.Left or Alignment.Right or Alignment.Center) {
            return;
        }

        throw new ArgumentException("Only left, right, and center alignments are supported for email components.");
    }
}
