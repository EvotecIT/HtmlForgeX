using System.Text.RegularExpressions;

namespace HtmlForgeX;

/// <summary>
/// Defines the standard Tabler color palette.
/// </summary>
public enum TablerColor {
    // Base colors

    /// <summary>
    /// Blue.
    /// </summary>
    Blue,
    /// <summary>
    /// Azure.
    /// </summary>
    Azure,
    /// <summary>
    /// Indigo.
    /// </summary>
    Indigo,
    /// <summary>
    /// Purple.
    /// </summary>
    Purple,
    /// <summary>
    /// Pink.
    /// </summary>
    Pink,
    /// <summary>
    /// Red.
    /// </summary>
    Red,
    /// <summary>
    /// Orange.
    /// </summary>
    Orange,
    /// <summary>
    /// Yellow.
    /// </summary>
    Yellow,
    /// <summary>
    /// Lime.
    /// </summary>
    Lime,
    /// <summary>
    /// Green.
    /// </summary>
    Green,
    /// <summary>
    /// Teal.
    /// </summary>
    Teal,
    /// <summary>
    /// Cyan.
    /// </summary>
    Cyan,
    /// <summary>
    /// White.
    /// </summary>
    White,
    /// <summary>
    /// Black.
    /// </summary>
    Black,

    // Light colors

    /// <summary>
    /// Blue light.
    /// </summary>
    BlueLight,
    /// <summary>
    /// Azure light.
    /// </summary>
    AzureLight,
    /// <summary>
    /// Indigo light.
    /// </summary>
    IndigoLight,
    /// <summary>
    /// Purple light.
    /// </summary>
    PurpleLight,
    /// <summary>
    /// Pink light.
    /// </summary>
    PinkLight,
    /// <summary>
    /// Red light.
    /// </summary>
    RedLight,
    /// <summary>
    /// Orange light.
    /// </summary>
    OrangeLight,
    /// <summary>
    /// Yellow light.
    /// </summary>
    YellowLight,
    /// <summary>
    /// Lime light.
    /// </summary>
    LimeLight,
    /// <summary>
    /// Green light.
    /// </summary>
    GreenLight,
    /// <summary>
    /// Teal light.
    /// </summary>
    TealLight,
    /// <summary>
    /// Cyan light.
    /// </summary>
    CyanLight,

    // Gray colors

    /// <summary>
    /// Gray 50.
    /// </summary>
    Gray50,
    /// <summary>
    /// Gray 100.
    /// </summary>
    Gray100,
    /// <summary>
    /// Gray 200.
    /// </summary>
    Gray200,
    /// <summary>
    /// Gray 300.
    /// </summary>
    Gray300,
    /// <summary>
    /// Gray 400.
    /// </summary>
    Gray400,
    /// <summary>
    /// Gray 500.
    /// </summary>
    Gray500,
    /// <summary>
    /// Gray 600.
    /// </summary>
    Gray600,
    /// <summary>
    /// Gray 700.
    /// </summary>
    Gray700,
    /// <summary>
    /// Gray 800.
    /// </summary>
    Gray800,
    /// <summary>
    /// Gray 900.
    /// </summary>
    Gray900,

    // Social colors

    /// <summary>
    /// Facebook.
    /// </summary>
    Facebook,
    /// <summary>
    /// Twitter.
    /// </summary>
    Twitter,
    /// <summary>
    /// Linkedin.
    /// </summary>
    Linkedin,
    /// <summary>
    /// Google.
    /// </summary>
    Google,
    /// <summary>
    /// Youtube.
    /// </summary>
    Youtube,
    /// <summary>
    /// Vimeo.
    /// </summary>
    Vimeo,
    /// <summary>
    /// Dribbble.
    /// </summary>
    Dribbble,
    /// <summary>
    /// Github.
    /// </summary>
    Github,
    /// <summary>
    /// Instagram.
    /// </summary>
    Instagram,
    /// <summary>
    /// Pinterest.
    /// </summary>
    Pinterest,
    /// <summary>
    /// Vk.
    /// </summary>
    Vk,
    /// <summary>
    /// Rss.
    /// </summary>
    Rss,
    /// <summary>
    /// Flickr.
    /// </summary>
    Flickr,
    /// <summary>
    /// Bitbucket.
    /// </summary>
    Bitbucket,
    /// <summary>
    /// Tabler.
    /// </summary>
    Tabler,

    // Status colors

    /// <summary>
    /// Default.
    /// </summary>
    Default,
    /// <summary>
    /// Primary.
    /// </summary>
    Primary,
    /// <summary>
    /// Success.
    /// </summary>
    Success,
    /// <summary>
    /// Failed.
    /// </summary>
    Failed,
    /// <summary>
    /// Info.
    /// </summary>
    Info,
    /// <summary>
    /// Warning.
    /// </summary>
    Warning,
    /// <summary>
    /// Danger.
    /// </summary>
    Danger,
    /// <summary>
    /// Light.
    /// </summary>
    Light,
    /// <summary>
    /// Dark.
    /// </summary>
    Dark,
    /// <summary>
    /// Transparent.
    /// </summary>
    Transparent
}

/// <summary>
/// Helper methods for working with <see cref="TablerColor"/> values.
/// </summary>
public static class ColorExtensions {
    private static readonly Regex NumberRegex = new(@"(\d+)", RegexOptions.Compiled);
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
        if (NumberRegex.IsMatch(colorString)) {
            return NumberRegex.Replace(colorString, "-$1");
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
