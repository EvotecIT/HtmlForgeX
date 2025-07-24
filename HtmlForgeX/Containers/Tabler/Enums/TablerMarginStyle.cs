namespace HtmlForgeX;

/// <summary>
/// Represents the margin spacing scale including directional margins.
/// </summary>
public enum TablerMarginStyle {
    /// <summary>
    /// M 0.
    /// </summary>
    M0,
    /// <summary>
    /// M 1.
    /// </summary>
    M1,
    /// <summary>
    /// M 2.
    /// </summary>
    M2,
    /// <summary>
    /// M 3.
    /// </summary>
    M3,
    /// <summary>
    /// M 4.
    /// </summary>
    M4,
    /// <summary>
    /// M 5.
    /// </summary>
    M5,
    // Margin top
    /// <summary>
    /// M t 0.
    /// </summary>
    MT0,
    /// <summary>
    /// M t 1.
    /// </summary>
    MT1,
    /// <summary>
    /// M t 2.
    /// </summary>
    MT2,
    /// <summary>
    /// M t 3.
    /// </summary>
    MT3,
    /// <summary>
    /// M t 4.
    /// </summary>
    MT4,
    /// <summary>
    /// M t 5.
    /// </summary>
    MT5,
    // Margin bottom
    /// <summary>
    /// M b 0.
    /// </summary>
    MB0,
    /// <summary>
    /// M b 1.
    /// </summary>
    MB1,
    /// <summary>
    /// M b 2.
    /// </summary>
    MB2,
    /// <summary>
    /// M b 3.
    /// </summary>
    MB3,
    /// <summary>
    /// M b 4.
    /// </summary>
    MB4,
    /// <summary>
    /// M b 5.
    /// </summary>
    MB5,
    // Margin start (left in LTR)
    /// <summary>
    /// M s 0.
    /// </summary>
    MS0,
    /// <summary>
    /// M s 1.
    /// </summary>
    MS1,
    /// <summary>
    /// M s 2.
    /// </summary>
    MS2,
    /// <summary>
    /// M s 3.
    /// </summary>
    MS3,
    /// <summary>
    /// M s 4.
    /// </summary>
    MS4,
    /// <summary>
    /// M s 5.
    /// </summary>
    MS5,
    // Margin end (right in LTR)
    /// <summary>
    /// M e 0.
    /// </summary>
    ME0,
    /// <summary>
    /// M e 1.
    /// </summary>
    ME1,
    /// <summary>
    /// M e 2.
    /// </summary>
    ME2,
    /// <summary>
    /// M e 3.
    /// </summary>
    ME3,
    /// <summary>
    /// M e 4.
    /// </summary>
    ME4,
    /// <summary>
    /// M e 5.
    /// </summary>
    ME5,
    // Margin x-axis (horizontal)
    /// <summary>
    /// M x 0.
    /// </summary>
    MX0,
    /// <summary>
    /// M x 1.
    /// </summary>
    MX1,
    /// <summary>
    /// M x 2.
    /// </summary>
    MX2,
    /// <summary>
    /// M x 3.
    /// </summary>
    MX3,
    /// <summary>
    /// M x 4.
    /// </summary>
    MX4,
    /// <summary>
    /// M x 5.
    /// </summary>
    MX5,
    // Margin y-axis (vertical)
    /// <summary>
    /// M y 0.
    /// </summary>
    MY0,
    /// <summary>
    /// M y 1.
    /// </summary>
    MY1,
    /// <summary>
    /// M y 2.
    /// </summary>
    MY2,
    /// <summary>
    /// M y 3.
    /// </summary>
    MY3,
    /// <summary>
    /// M y 4.
    /// </summary>
    MY4,
    /// <summary>
    /// M y 5.
    /// </summary>
    MY5
}

/// <summary>
/// Extension helpers for <see cref="TablerMarginStyle"/> values.
/// </summary>
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