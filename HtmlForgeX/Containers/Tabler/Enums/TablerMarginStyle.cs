namespace HtmlForgeX;

/// <summary>
/// Represents the margin spacing scale including directional margins.
/// </summary>
public enum TablerMarginStyle {
    M0,
    M1,
    M2,
    M3,
    M4,
    M5,
    // Margin top
    MT0,
    MT1,
    MT2,
    MT3,
    MT4,
    MT5,
    // Margin bottom
    MB0,
    MB1,
    MB2,
    MB3,
    MB4,
    MB5,
    // Margin start (left in LTR)
    MS0,
    MS1,
    MS2,
    MS3,
    MS4,
    MS5,
    // Margin end (right in LTR)
    ME0,
    ME1,
    ME2,
    ME3,
    ME4,
    ME5,
    // Margin x-axis (horizontal)
    MX0,
    MX1,
    MX2,
    MX3,
    MX4,
    MX5,
    // Margin y-axis (vertical)
    MY0,
    MY1,
    MY2,
    MY3,
    MY4,
    MY5
}

public static class MarginStyleExtensions {
    /// <summary>
    /// Initializes or configures EnumToString.
    /// </summary>
    public static string EnumToString(this TablerMarginStyle style) {
        var styleString = style.ToString();

        // Handle directional margins
        if (styleString.StartsWith("MT")) return "mt-" + styleString.Substring(2);
        if (styleString.StartsWith("MB")) return "mb-" + styleString.Substring(2);
        if (styleString.StartsWith("MS")) return "ms-" + styleString.Substring(2);
        if (styleString.StartsWith("ME")) return "me-" + styleString.Substring(2);
        if (styleString.StartsWith("MX")) return "mx-" + styleString.Substring(2);
        if (styleString.StartsWith("MY")) return "my-" + styleString.Substring(2);

        // Handle regular margins
        return "m-" + styleString.Substring(1);
    }
}