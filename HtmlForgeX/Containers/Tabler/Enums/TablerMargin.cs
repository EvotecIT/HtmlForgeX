namespace HtmlForgeX;

public enum TablerMargin {
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

public static class TablerMarginExtensions {
    public static string EnumToString(this TablerMargin margin) {
        var marginStr = margin.ToString();
        var property = "m";

        string side;
        string size;

        if (marginStr.StartsWith("Top")) {
            side = "t";
            size = marginStr[3..];
        } else if (marginStr.StartsWith("Bottom")) {
            side = "b";
            size = marginStr[6..];
        } else if (marginStr.StartsWith("Start")) {
            side = "s";
            size = marginStr[5..];
        } else if (marginStr.StartsWith("End")) {
            side = "e";
            size = marginStr[3..];
        } else if (marginStr.StartsWith("Horizontal")) {
            side = "x";
            size = marginStr[10..];
        } else if (marginStr.StartsWith("Vertical")) {
            side = "y";
            size = marginStr[8..];
        } else if (marginStr.StartsWith("All")) {
            side = string.Empty;
            size = marginStr[3..];
        } else {
            side = string.Empty;
            size = marginStr;
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