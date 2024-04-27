namespace HtmlForgeX;

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
        var side = paddingStr.Substring(0, paddingStr.IndexOfAny("0123456789".ToCharArray()));
        var size = paddingStr.Substring(side.Length);

        return $"{property}{side}-{size}";
    }
}