using System.Text.RegularExpressions;
using System.Reflection;

namespace HtmlForgeX;

/// <summary>
/// Defines the standard Tabler color palette.
/// </summary>
public enum TablerColor {
    // Base colors

    /// <summary>
    /// Blue.
    /// </summary>
    [HexColor("#066fd1")]
    Blue,
    /// <summary>
    /// Azure.
    /// </summary>
    [HexColor("#4299e1")]
    Azure,
    /// <summary>
    /// Indigo.
    /// </summary>
    [HexColor("#4263eb")]
    Indigo,
    /// <summary>
    /// Purple.
    /// </summary>
    [HexColor("#ae3ec9")]
    Purple,
    /// <summary>
    /// Pink.
    /// </summary>
    [HexColor("#d6336c")]
    Pink,
    /// <summary>
    /// Red.
    /// </summary>
    [HexColor("#d63939")]
    Red,
    /// <summary>
    /// Orange.
    /// </summary>
    [HexColor("#f76707")]
    Orange,
    /// <summary>
    /// Yellow.
    /// </summary>
    [HexColor("#f59f00")]
    Yellow,
    /// <summary>
    /// Lime.
    /// </summary>
    [HexColor("#74b816")]
    Lime,
    /// <summary>
    /// Green.
    /// </summary>
    [HexColor("#2fb344")]
    Green,
    /// <summary>
    /// Teal.
    /// </summary>
    [HexColor("#0ca678")]
    Teal,
    /// <summary>
    /// Cyan.
    /// </summary>
    [HexColor("#17a2b8")]
    Cyan,
    /// <summary>
    /// White.
    /// </summary>
    [HexColor("#ffffff")]
    White,
    /// <summary>
    /// Black.
    /// </summary>
    [HexColor("#000000")]
    Black,

    // Light colors

    /// <summary>
    /// Blue light.
    /// </summary>
    [HexColor("#e6f1fa")]
    BlueLight,
    /// <summary>
    /// Azure light.
    /// </summary>
    [HexColor("#ecf5fc")]
    AzureLight,
    /// <summary>
    /// Indigo light.
    /// </summary>
    [HexColor("#eceffd")]
    IndigoLight,
    /// <summary>
    /// Purple light.
    /// </summary>
    [HexColor("#f7ecfa")]
    PurpleLight,
    /// <summary>
    /// Pink light.
    /// </summary>
    [HexColor("#fbebf0")]
    PinkLight,
    /// <summary>
    /// Red light.
    /// </summary>
    [HexColor("#fbebeb")]
    RedLight,
    /// <summary>
    /// Orange light.
    /// </summary>
    [HexColor("#fef0e6")]
    OrangeLight,
    /// <summary>
    /// Yellow light.
    /// </summary>
    [HexColor("#fef5e6")]
    YellowLight,
    /// <summary>
    /// Lime light.
    /// </summary>
    [HexColor("#f1f8e8")]
    LimeLight,
    /// <summary>
    /// Green light.
    /// </summary>
    [HexColor("#eaf7ec")]
    GreenLight,
    /// <summary>
    /// Teal light.
    /// </summary>
    [HexColor("#e7f6f2")]
    TealLight,
    /// <summary>
    /// Cyan light.
    /// </summary>
    [HexColor("#e8f6f8")]
    CyanLight,

    // Gray colors

    /// <summary>
    /// Gray 50.
    /// </summary>
    [HexColor("#f9fafb")]
    Gray50,
    /// <summary>
    /// Gray 100.
    /// </summary>
    [HexColor("#f3f4f6")]
    Gray100,
    /// <summary>
    /// Gray 200.
    /// </summary>
    [HexColor("#e5e7eb")]
    Gray200,
    /// <summary>
    /// Gray 300.
    /// </summary>
    [HexColor("#d1d5db")]
    Gray300,
    /// <summary>
    /// Gray 400.
    /// </summary>
    [HexColor("#9ca3af")]
    Gray400,
    /// <summary>
    /// Gray 500.
    /// </summary>
    [HexColor("#6b7280")]
    Gray500,
    /// <summary>
    /// Gray 600.
    /// </summary>
    [HexColor("#4b5563")]
    Gray600,
    /// <summary>
    /// Gray 700.
    /// </summary>
    [HexColor("#374151")]
    Gray700,
    /// <summary>
    /// Gray 800.
    /// </summary>
    [HexColor("#1f2937")]
    Gray800,
    /// <summary>
    /// Gray 900.
    /// </summary>
    [HexColor("#111827")]
    Gray900,

    // Social colors

    /// <summary>
    /// Facebook.
    /// </summary>
    [HexColor("#1877f2")]
    Facebook,
    /// <summary>
    /// Twitter.
    /// </summary>
    [HexColor("#1da1f2")]
    Twitter,
    /// <summary>
    /// Linkedin.
    /// </summary>
    [HexColor("#0a66c2")]
    Linkedin,
    /// <summary>
    /// Google.
    /// </summary>
    [HexColor("#dc4e41")]
    Google,
    /// <summary>
    /// Youtube.
    /// </summary>
    [HexColor("#ff0000")]
    Youtube,
    /// <summary>
    /// Vimeo.
    /// </summary>
    [HexColor("#1ab7ea")]
    Vimeo,
    /// <summary>
    /// Dribbble.
    /// </summary>
    [HexColor("#ea4c89")]
    Dribbble,
    /// <summary>
    /// Github.
    /// </summary>
    [HexColor("#181717")]
    Github,
    /// <summary>
    /// Instagram.
    /// </summary>
    [HexColor("#e4405f")]
    Instagram,
    /// <summary>
    /// Pinterest.
    /// </summary>
    [HexColor("#bd081c")]
    Pinterest,
    /// <summary>
    /// Vk.
    /// </summary>
    [HexColor("#6383a8")]
    Vk,
    /// <summary>
    /// Rss.
    /// </summary>
    [HexColor("#ffa500")]
    Rss,
    /// <summary>
    /// Flickr.
    /// </summary>
    [HexColor("#0063dc")]
    Flickr,
    /// <summary>
    /// Bitbucket.
    /// </summary>
    [HexColor("#0052cc")]
    Bitbucket,
    /// <summary>
    /// Tabler.
    /// </summary>
    [HexColor("#066fd1")]
    Tabler,

    // Status colors

    /// <summary>
    /// Default.
    /// </summary>
    [HexColor("#d1d5db")]
    Default,
    /// <summary>
    /// Primary.
    /// </summary>
    [HexColor("#066fd1")]
    Primary,
    /// <summary>
    /// Success.
    /// </summary>
    [HexColor("#2fb344")]
    Success,
    /// <summary>
    /// Failed.
    /// </summary>
    [HexColor("#d63939")]
    Failed,
    /// <summary>
    /// Info.
    /// </summary>
    [HexColor("#4299e1")]
    Info,
    /// <summary>
    /// Warning.
    /// </summary>
    [HexColor("#f59f00")]
    Warning,
    /// <summary>
    /// Danger.
    /// </summary>
    [HexColor("#d63939")]
    Danger,
    /// <summary>
    /// Light.
    /// </summary>
    [HexColor("#f9fafb")]
    Light,
    /// <summary>
    /// Dark.
    /// </summary>
    [HexColor("#1f2937")]
    Dark,
    /// <summary>
    /// Transparent.
    /// </summary>
    [HexColor("#00000000")]
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

    /// <summary>
    /// Returns the hexadecimal color code for the given <see cref="TablerColor"/>.
    /// </summary>
    public static string ToHex(this TablerColor color) {
        if (HexMap.TryGetValue(color, out var hex)) {
            return hex;
        }

        return "#000000";
    }

    private static readonly IReadOnlyDictionary<TablerColor, string> HexMap =
        ((TablerColor[])Enum.GetValues(typeof(TablerColor)))
            .Select(value => new {
                Value = value,
                Hex = typeof(TablerColor)
                    .GetField(value.ToString())?
                    .GetCustomAttribute<HexColorAttribute>()?
                    .Hex
            })
            .Where(x => x.Hex is not null)
            .ToDictionary(x => x.Value, x => x.Hex!);
}