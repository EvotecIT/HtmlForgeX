using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlForgeX;

/// <summary>
/// Defines orientation for a steps component.
/// </summary>
public enum StepsOrientation {
    Horizontal,
    Vertical
}


/// <summary>
/// Extension helpers for <see cref="StepsOrientation"/> values.
/// </summary>
public static class StepsOrientationExtensions {
    /// <summary>
    /// Converts the orientation to the corresponding Tabler class.
    /// </summary>
    /// <param name="orientation">Steps orientation.</param>
    /// <returns>CSS class string.</returns>
    public static string EnumToString(this StepsOrientation orientation) {
        return orientation switch {
            StepsOrientation.Horizontal => "steps-horizontal",
            StepsOrientation.Vertical => "steps-vertical",
            _ => throw new ArgumentOutOfRangeException(nameof(orientation), orientation, null)
        };
    }
}