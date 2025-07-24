using System.ComponentModel;

using HtmlForgeX.Extensions;

namespace HtmlForgeX;

/// <summary>
/// Predefined dash patterns for borders and edges in VisNetwork.
/// </summary>
public enum VisNetworkDashPattern {
    /// <summary>
    /// Solid line with no dashes
    /// </summary>
    [Description("solid")]
    Solid,

    /// <summary>
    /// Short dashes: [5, 5]
    /// </summary>
    [Description("5,5")]
    ShortDash,

    /// <summary>
    /// Medium dashes: [10, 5]
    /// </summary>
    [Description("10,5")]
    MediumDash,

    /// <summary>
    /// Long dashes: [20, 5]
    /// </summary>
    [Description("20,5")]
    LongDash,

    /// <summary>
    /// Dots: [2, 5]
    /// </summary>
    [Description("2,5")]
    Dot,

    /// <summary>
    /// Dash-dot pattern: [15, 5, 5, 5]
    /// </summary>
    [Description("15,5,5,5")]
    DashDot,

    /// <summary>
    /// Dash-dot-dot pattern: [15, 5, 5, 5, 5, 5]
    /// </summary>
    [Description("15,5,5,5,5,5")]
    DashDotDot,

    /// <summary>
    /// Wide gaps: [10, 10]
    /// </summary>
    [Description("10,10")]
    WideGap,

    /// <summary>
    /// Railway pattern: [20, 10, 5, 10]
    /// </summary>
    [Description("20,10,5,10")]
    Railway
}

/// <summary>
/// Extension methods for VisNetworkDashPattern enum.
/// </summary>
public static class VisNetworkDashPatternExtensions {
    /// <summary>
    /// Converts the dash pattern enum to an integer array.
    /// </summary>
    /// <param name="pattern">The dash pattern to convert</param>
    /// <returns>An array of integers representing the dash pattern</returns>
    public static int[] ToArray(this VisNetworkDashPattern pattern) {
        var description = pattern.GetDescription();
        if (description == "solid") return new int[0];

        var parts = description.Split(',');
        var result = new int[parts.Length];
        for (int i = 0; i < parts.Length; i++) {
            result[i] = int.Parse(parts[i]);
        }
        return result;
    }
}