using System;

namespace HtmlForgeX;

/// <summary>
/// Specifies the hex color code for a <see cref="TablerColor"/> value.
/// </summary>
[AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
public sealed class HexColorAttribute : Attribute {
    /// <summary>
    /// Gets the hex color code (e.g., "#ffffff").
    /// </summary>
    public string Hex { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="HexColorAttribute"/> class.
    /// </summary>
    /// <param name="hex">The hex color code.</param>
    public HexColorAttribute(string hex) {
        Hex = hex;
    }
}