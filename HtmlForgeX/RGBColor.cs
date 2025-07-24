using System;
using System.Globalization;
using System.Linq;

namespace HtmlForgeX;

public partial class RGBColor {
    private byte A { get; set; }
    private byte R { get; set; }
    private byte G { get; set; }
    private byte B { get; set; }

    // Parameterless constructor
    private RGBColor() {
        A = 0;
        R = 0;
        G = 0;
        B = 0;
    }

    // Private constructor to set RGBColor components
    private RGBColor(byte a, byte r, byte g, byte b) : this() {
        A = a;
        R = r;
        G = g;
        B = b;
    }

    /// <summary>
    /// Public constructor that accepts hex color strings like "#111827", "#FFF", "111827" or RGBA format like "rgba(255, 0, 0, 0.5)"
    /// </summary>
    /// <param name="colorString">Color string in hex or RGBA format</param>
    public RGBColor(string colorString) : this() {
        ParseColorString(colorString);
    }

    /// <summary>
    /// Parses a color string in hex or RGBA format and sets the RGB values
    /// Supports formats: "#RRGGBB", "#RGB", "RRGGBB", "RGB", "rgba(r,g,b,a)", "rgb(r,g,b)"
    /// </summary>
    /// <param name="colorString">The color string to parse</param>
    private void ParseColorString(string colorString) {
        if (string.IsNullOrWhiteSpace(colorString)) {
            throw new ArgumentException("Color string cannot be null or empty.", nameof(colorString));
        }

        // Check if it's RGBA or RGB format
        if (colorString.StartsWith("rgba(") || colorString.StartsWith("rgb(")) {
            ParseRgbaColor(colorString);
        } else {
            ParseHexColor(colorString);
        }
    }

    /// <summary>
    /// Parses an RGBA color string like "rgba(255, 0, 0, 0.5)" or "rgb(255, 0, 0)"
    /// </summary>
    /// <param name="rgbaColor">The RGBA color string to parse</param>
    private void ParseRgbaColor(string rgbaColor) {
        // Remove rgba( or rgb( prefix and ) suffix
        string content = rgbaColor.Substring(rgbaColor.IndexOf('(') + 1);
        content = content.Substring(0, content.LastIndexOf(')'));

        // Split by comma and trim spaces
        string[] parts = content.Split(',').Select(p => p.Trim()).ToArray();

        if (parts.Length < 3 || parts.Length > 4) {
            throw new ArgumentException($"Invalid RGBA format: {rgbaColor}. Expected rgba(r,g,b,a) or rgb(r,g,b).", nameof(rgbaColor));
        }

        // Parse RGB values
        if (!int.TryParse(parts[0], out int r) || r < 0 || r > 255) {
            throw new ArgumentException($"Invalid red value in RGBA format: {rgbaColor}. Expected 0-255.", nameof(rgbaColor));
        }
        if (!int.TryParse(parts[1], out int g) || g < 0 || g > 255) {
            throw new ArgumentException($"Invalid green value in RGBA format: {rgbaColor}. Expected 0-255.", nameof(rgbaColor));
        }
        if (!int.TryParse(parts[2], out int b) || b < 0 || b > 255) {
            throw new ArgumentException($"Invalid blue value in RGBA format: {rgbaColor}. Expected 0-255.", nameof(rgbaColor));
        }

        // Parse alpha value (optional)
        double alpha = 1.0;
        if (parts.Length == 4) {
            // Use InvariantCulture to handle decimal points correctly
            if (!double.TryParse(parts[3], System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out alpha) || alpha < 0 || alpha > 1) {
                throw new ArgumentException($"Invalid alpha value in RGBA format: {rgbaColor}. Expected 0.0-1.0.", nameof(rgbaColor));
            }
        }

        R = (byte)r;
        G = (byte)g;
        B = (byte)b;
        A = (byte)(alpha * 255);
    }

    /// <summary>
    /// Parses a hex color string and sets the RGB values
    /// Supports formats: "#RRGGBB", "#RGB", "RRGGBB", "RGB"
    /// </summary>
    /// <param name="hexColor">The hex color string to parse</param>
    private void ParseHexColor(string hexColor) {
        if (string.IsNullOrWhiteSpace(hexColor)) {
            throw new ArgumentException("Hex color string cannot be null or empty.", nameof(hexColor));
        }

        // Remove # prefix if present
        string cleanHex = hexColor.TrimStart('#');

        // Validate that we only have valid hex characters
        if (!System.Text.RegularExpressions.Regex.IsMatch(cleanHex, "^[0-9A-Fa-f]+$")) {
            throw new ArgumentException($"Invalid hex color format: {hexColor}. Only hex characters (0-9, A-F) are allowed.", nameof(hexColor));
        }

        switch (cleanHex.Length) {
            case 3: // RGB format (e.g., "F0A")
                R = Convert.ToByte(cleanHex.Substring(0, 1) + cleanHex.Substring(0, 1), 16);
                G = Convert.ToByte(cleanHex.Substring(1, 1) + cleanHex.Substring(1, 1), 16);
                B = Convert.ToByte(cleanHex.Substring(2, 1) + cleanHex.Substring(2, 1), 16);
                A = 255; // Full opacity
                break;

            case 6: // RRGGBB format (e.g., "111827")
                R = Convert.ToByte(cleanHex.Substring(0, 2), 16);
                G = Convert.ToByte(cleanHex.Substring(2, 2), 16);
                B = Convert.ToByte(cleanHex.Substring(4, 2), 16);
                A = 255; // Full opacity
                break;

            case 8: // AARRGGBB format (e.g., "FF111827")
                A = Convert.ToByte(cleanHex.Substring(0, 2), 16);
                R = Convert.ToByte(cleanHex.Substring(2, 2), 16);
                G = Convert.ToByte(cleanHex.Substring(4, 2), 16);
                B = Convert.ToByte(cleanHex.Substring(6, 2), 16);
                break;

            default:
                throw new ArgumentException($"Invalid hex color length: {hexColor}. Expected 3, 6, or 8 characters (excluding #).", nameof(hexColor));
        }
    }

    // FromArgb with alpha value
    private static RGBColor FromArgb(int alpha, int red, int green, int blue) {
        return new RGBColor((byte)alpha, (byte)red, (byte)green, (byte)blue);
    }

    // FromArgb without explicit alpha value (assumes full opacity)
    private static RGBColor FromArgb(int red, int green, int blue) {
        return new RGBColor(255, (byte)red, (byte)green, (byte)blue);
    }

    /// <summary>
    /// Creates an RGBColor from a hex color string like "#111827", "#FFF", or "111827"
    /// </summary>
    /// <param name="hexColor">Hex color string with or without # prefix</param>
    /// <returns>RGBColor instance</returns>
    public static RGBColor FromHex(string hexColor) {
        return new RGBColor(hexColor);
    }

    /// <summary>
    /// Tries to create an RGBColor from a hex color string
    /// </summary>
    /// <param name="hexColor">Hex color string with or without # prefix</param>
    /// <param name="result">The parsed RGBColor, or null if parsing failed</param>
    /// <returns>True if parsing succeeded, false otherwise</returns>
    public static bool TryFromHex(string hexColor, out RGBColor? result) {
        try {
            result = new RGBColor(hexColor);
            return true;
        } catch {
            result = null;
            return false;
        }
    }

    /// <summary>
    /// Converts this color to a hexadecimal string suitable for HTML use.
    /// </summary>
    /// <returns>The hex representation beginning with <c>#</c>.</returns>
    public string ToHex() {
        return $"#{R:X2}{G:X2}{B:X2}";
    }

    /// <summary>
    /// Returns the string representation of this color.
    /// Returns RGBA format when alpha is not full opacity, otherwise hex format.
    /// </summary>
    public override string ToString() {
        if (A < 255) {
            // Return RGBA format for transparency
            double alpha = A / 255.0;
            // Use InvariantCulture to ensure decimal point is used
            return $"rgba({R}, {G}, {B}, {alpha.ToString("F2", CultureInfo.InvariantCulture)})";
        }

        // Return hex format for full opacity
        return $"#{R:X2}{G:X2}{B:X2}";
    }
}