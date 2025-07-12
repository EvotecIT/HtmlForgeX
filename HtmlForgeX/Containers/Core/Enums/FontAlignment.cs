using System;

namespace HtmlForgeX;

/// <summary>
/// Alignment options for text. The <c>Justify</c> value is not consistently
/// supported by many email clients and may not render as expected.
/// </summary>
public enum FontAlignment {
    Left = 1,
    Center,
    Right,
    Justify
}

public static class FontAlignmentExtensions {
    public static string ToCssValue(this FontAlignment alignment) => alignment switch
    {
        FontAlignment.Left => "left",
        FontAlignment.Center => "center",
        FontAlignment.Right => "right",
        FontAlignment.Justify => "justify",
        _ => "left"
    };

    public static void ValidateEmailAlignment(this FontAlignment alignment) {
        if (alignment is FontAlignment.Left or FontAlignment.Right or FontAlignment.Center) {
            return;
        }

        throw new ArgumentException("Only left, right, and center alignments are supported for email components.");
    }
}
