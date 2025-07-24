namespace HtmlForgeX;

/// <summary>
/// Defines padding utility classes.
/// </summary>
public enum TablerPadding {
    /// <summary>
    /// Top auto.
    /// </summary>
    TopAuto,
    /// <summary>
    /// Top zero.
    /// </summary>
    TopZero,
    /// <summary>
    /// Top quarter.
    /// </summary>
    TopQuarter,
    /// <summary>
    /// Top half.
    /// </summary>
    TopHalf,
    /// <summary>
    /// Top normal.
    /// </summary>
    TopNormal,
    /// <summary>
    /// Top one and half.
    /// </summary>
    TopOneAndHalf,
    /// <summary>
    /// Top triple.
    /// </summary>
    TopTriple,
    /// <summary>
    /// Bottom auto.
    /// </summary>
    BottomAuto,
    /// <summary>
    /// Bottom zero.
    /// </summary>
    BottomZero,
    /// <summary>
    /// Bottom quarter.
    /// </summary>
    BottomQuarter,
    /// <summary>
    /// Bottom half.
    /// </summary>
    BottomHalf,
    /// <summary>
    /// Bottom normal.
    /// </summary>
    BottomNormal,
    /// <summary>
    /// Bottom one and half.
    /// </summary>
    BottomOneAndHalf,
    /// <summary>
    /// Bottom triple.
    /// </summary>
    BottomTriple,
    /// <summary>
    /// Start auto.
    /// </summary>
    StartAuto,
    /// <summary>
    /// Start zero.
    /// </summary>
    StartZero,
    /// <summary>
    /// Start quarter.
    /// </summary>
    StartQuarter,
    /// <summary>
    /// Start half.
    /// </summary>
    StartHalf,
    /// <summary>
    /// Start normal.
    /// </summary>
    StartNormal,
    /// <summary>
    /// Start one and half.
    /// </summary>
    StartOneAndHalf,
    /// <summary>
    /// Start triple.
    /// </summary>
    StartTriple,
    /// <summary>
    /// End auto.
    /// </summary>
    EndAuto,
    /// <summary>
    /// End zero.
    /// </summary>
    EndZero,
    /// <summary>
    /// End quarter.
    /// </summary>
    EndQuarter,
    /// <summary>
    /// End half.
    /// </summary>
    EndHalf,
    /// <summary>
    /// End normal.
    /// </summary>
    EndNormal,
    /// <summary>
    /// End one and half.
    /// </summary>
    EndOneAndHalf,
    /// <summary>
    /// End triple.
    /// </summary>
    EndTriple,
    /// <summary>
    /// Horizontal auto.
    /// </summary>
    HorizontalAuto,
    /// <summary>
    /// Horizontal zero.
    /// </summary>
    HorizontalZero,
    /// <summary>
    /// Horizontal quarter.
    /// </summary>
    HorizontalQuarter,
    /// <summary>
    /// Horizontal half.
    /// </summary>
    HorizontalHalf,
    /// <summary>
    /// Horizontal normal.
    /// </summary>
    HorizontalNormal,
    /// <summary>
    /// Horizontal one and half.
    /// </summary>
    HorizontalOneAndHalf,
    /// <summary>
    /// Horizontal triple.
    /// </summary>
    HorizontalTriple,
    /// <summary>
    /// Vertical auto.
    /// </summary>
    VerticalAuto,
    /// <summary>
    /// Vertical zero.
    /// </summary>
    VerticalZero,
    /// <summary>
    /// Vertical quarter.
    /// </summary>
    VerticalQuarter,
    /// <summary>
    /// Vertical half.
    /// </summary>
    VerticalHalf,
    /// <summary>
    /// Vertical normal.
    /// </summary>
    VerticalNormal,
    /// <summary>
    /// Vertical one and half.
    /// </summary>
    VerticalOneAndHalf,
    /// <summary>
    /// Vertical triple.
    /// </summary>
    VerticalTriple,
    /// <summary>
    /// All auto.
    /// </summary>
    AllAuto,
    /// <summary>
    /// All zero.
    /// </summary>
    AllZero,
    /// <summary>
    /// All quarter.
    /// </summary>
    AllQuarter,
    /// <summary>
    /// All half.
    /// </summary>
    AllHalf,
    /// <summary>
    /// All normal.
    /// </summary>
    AllNormal,
    /// <summary>
    /// All one and half.
    /// </summary>
    AllOneAndHalf,
    /// <summary>
    /// All triple.
    /// </summary>
    AllTriple
}



/// <summary>
/// Extension helpers for <see cref="TablerPadding"/> values.
/// </summary>
public static class TablerPaddingExtensions {
    /// <summary>
    /// Initializes or configures EnumToString.
    /// </summary>
    public static string EnumToString(this TablerPadding padding) {
        var paddingStr = padding.ToString();
        var property = "p";

        string side;
        string size;

        if (paddingStr.StartsWith("Top")) {
            side = "t";
            size = paddingStr.Substring(3);
        } else if (paddingStr.StartsWith("Bottom")) {
            side = "b";
            size = paddingStr.Substring(6);
        } else if (paddingStr.StartsWith("Start")) {
            side = "s";
            size = paddingStr.Substring(5);
        } else if (paddingStr.StartsWith("End")) {
            side = "e";
            size = paddingStr.Substring(3);
        } else if (paddingStr.StartsWith("Horizontal")) {
            side = "x";
            size = paddingStr.Substring(10);
        } else if (paddingStr.StartsWith("Vertical")) {
            side = "y";
            size = paddingStr.Substring(8);
        } else if (paddingStr.StartsWith("All")) {
            side = string.Empty;
            size = paddingStr.Substring(3);
        } else {
            side = string.Empty;
            size = paddingStr;
        }

        size = size switch {
            "Auto" => "auto",
            "Zero" => "0",
            "Quarter" => "1",
            "Half" => "2",
            "Normal" => "3",
            "OneAndHalf" => "4",
            "Triple" => "5",
            _ => size.ToLower()
        };

        return $"{property}{side}-{size}";
    }
}