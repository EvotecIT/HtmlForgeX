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
    private static readonly Dictionary<string, string> _sideMap = new() {
        { "Top", "t" },
        { "Bottom", "b" },
        { "Start", "s" },
        { "End", "e" },
        { "Horizontal", "x" },
        { "Vertical", "y" },
        { "All", string.Empty }
    };

    private static readonly Dictionary<string, string> _sizeMap = new() {
        { "Auto", "auto" },
        { "Zero", "0" },
        { "Quarter", "1" },
        { "Half", "2" },
        { "Normal", "3" },
        { "OneAndHalf", "4" },
        { "Triple", "5" }
    };

    public static string EnumToString(this TablerPadding padding) {
        var paddingStr = padding.ToString();
        foreach (var side in _sideMap.Keys) {
            if (!paddingStr.StartsWith(side, StringComparison.Ordinal)) {
                continue;
            }

            var size = paddingStr[side.Length..];
            return $"p{_sideMap[side]}-{_sizeMap[size]}";
        }

        throw new ArgumentOutOfRangeException(nameof(padding), padding, null);
    }
}