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


public static class StepsOrientationExtensions {
    public static string EnumToString(this StepsOrientation orientation) {
        return orientation switch {
            StepsOrientation.Horizontal => "steps-horizontal",
            StepsOrientation.Vertical => "steps-vertical",
            _ => throw new ArgumentOutOfRangeException(nameof(orientation), orientation, null)
        };
    }
}
