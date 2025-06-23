namespace HtmlForgeX;

/// <summary>
/// Defines padding utility classes.
/// </summary>
public enum TablerPadding {
    TopAuto,
    TopZero,
    TopQuarter,
    TopHalf,
    TopNormal,
    TopOneAndHalf,
    TopTriple,
    BottomAuto,
    BottomZero,
    BottomQuarter,
    BottomHalf,
    BottomNormal,
    BottomOneAndHalf,
    BottomTriple,
    StartAuto,
    StartZero,
    StartQuarter,
    StartHalf,
    StartNormal,
    StartOneAndHalf,
    StartTriple,
    EndAuto,
    EndZero,
    EndQuarter,
    EndHalf,
    EndNormal,
    EndOneAndHalf,
    EndTriple,
    HorizontalAuto,
    HorizontalZero,
    HorizontalQuarter,
    HorizontalHalf,
    HorizontalNormal,
    HorizontalOneAndHalf,
    HorizontalTriple,
    VerticalAuto,
    VerticalZero,
    VerticalQuarter,
    VerticalHalf,
    VerticalNormal,
    VerticalOneAndHalf,
    VerticalTriple,
    AllAuto,
    AllZero,
    AllQuarter,
    AllHalf,
    AllNormal,
    AllOneAndHalf,
    AllTriple
}



public static class TablerPaddingExtensions {
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