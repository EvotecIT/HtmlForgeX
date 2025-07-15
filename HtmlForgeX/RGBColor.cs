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
    /// Public constructor that accepts hex color strings like "#111827", "#FFF", or "111827"
    /// </summary>
    /// <param name="hexColor">Hex color string with or without # prefix</param>
    public RGBColor(string hexColor) : this() {
        ParseHexColor(hexColor);
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
    /// Returns the hexadecimal string representation of this color.
    /// </summary>
    public override string ToString() {
        return $"#{R:X2}{G:X2}{B:X2}";
        // return $"RGBColor [A={A}, R={R}, G={G}, B={B}]";
    }
}
