using System;

namespace HtmlForgeX;

/// <summary>
/// Alignment options for text. The <c>Justify</c> value is not consistently
/// supported by many email clients and may not render as expected.
/// </summary>
public enum Alignment {
    /// <summary>Left aligned.</summary>
    Left = 1,

    /// <summary>Centered.</summary>
    Center,

    /// <summary>Right aligned.</summary>
    Right,

    /// <summary>Justified text.</summary>
    Justify
}

/// <summary>
/// Extension methods for the <see cref="Alignment"/> enum.
/// </summary>
public static class AlignmentExtensions {
    /// <summary>
    /// Converts an alignment value to its CSS representation.
    /// </summary>
    /// <param name="alignment">Alignment option.</param>
    /// <returns>CSS text-align value.</returns>
    public static string ToCssValue(this Alignment alignment) => alignment switch {
        Alignment.Left => "left",
        Alignment.Center => "center",
        Alignment.Right => "right",
        Alignment.Justify => "justify",
        _ => "left"
    };

    /// <summary>
    /// Validates that the alignment is allowed for email components.
    /// </summary>
    /// <param name="alignment">Alignment to validate.</param>
    public static void ValidateEmailAlignment(this Alignment alignment) {
        if (alignment is Alignment.Left or Alignment.Right or Alignment.Center) {
            return;
        }

        throw new ArgumentException("Only left, right, and center alignments are supported for email components.");
    }
}