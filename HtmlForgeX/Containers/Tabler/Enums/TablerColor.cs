using System.Text.RegularExpressions;

namespace HtmlForgeX;

/// <summary>
/// Defines the standard Tabler color palette.
/// </summary>
public enum TablerColor {
    // Base colors

    Blue,
    Azure,
    Indigo,
    Purple,
    Pink,
    Red,
    Orange,
    Yellow,
    Lime,
    Green,
    Teal,
    Cyan,
    White,
    Black,

    // Light colors

    BlueLight,
    AzureLight,
    IndigoLight,
    PurpleLight,
    PinkLight,
    RedLight,
    OrangeLight,
    YellowLight,
    LimeLight,
    GreenLight,
    TealLight,
    CyanLight,

    // Gray colors

    Gray50,
    Gray100,
    Gray200,
    Gray300,
    Gray400,
    Gray500,
    Gray600,
    Gray700,
    Gray800,
    Gray900,

    // Social colors

    Facebook,
    Twitter,
    Linkedin,
    Google,
    Youtube,
    Vimeo,
    Dribbble,
    Github,
    Instagram,
    Pinterest,
    Vk,
    Rss,
    Flickr,
    Bitbucket,
    Tabler,

    // Status colors

    Default,
    Primary,
    Success,
    Failed,
    Info,
    Warning,
    Danger,
    Light,
    Dark,
    Transparent
}

/// <summary>
/// Helper methods for working with <see cref="TablerColor"/> values.
/// </summary>
public static class ColorExtensions {
    /// <summary>
    /// Initializes or configures ToTablerString.
    /// </summary>
    public static string ToTablerString(this TablerColor color) {
        var colorString = color.ToString().ToLower();
        // if contais Light, replace with -lt
        if (colorString.EndsWith("light")) {
            return colorString.Replace("light", "-lt");
        }
        // if contains numbers add - between colorString and number
        var regex = new Regex(@"(\d+)");
        if (regex.IsMatch(colorString)) {
            return regex.Replace(colorString, "-$1");
        }

        return color.ToString().ToLower();
    }

    /// <summary>
    /// Initializes or configures ToTablerText.
    /// </summary>
    public static string ToTablerText(this TablerColor color) {
        return "text-" + color.ToTablerString();
    }

    /// <summary>
    /// Initializes or configures ToTablerBackground.
    /// </summary>
    public static string ToTablerBackground(this TablerColor color) {
        return "bg-" + color.ToTablerString();
    }

    /// <summary>
    /// Initializes or configures ToTablerSteps.
    /// </summary>
    public static string ToTablerSteps(this TablerColor color) {
        return "steps-" + color.ToTablerString();
    }

    /// <summary>
    /// Initializes or configures ToTablerStatus.
    /// </summary>
    public static string ToTablerStatus(this TablerColor color) {
        return "status-" + color.ToTablerString();
    }

    /// <summary>
    /// Converts TablerColor to TablerAlert.
    ///
    /// Note: not all colors are valid for alerts.
    /// </summary>
    /// <param name="color">The color.</param>
    /// <returns></returns>
    public static string ToTablerAlert(this TablerColor color) {
        return "alert-" + color.ToTablerString();
    }
}