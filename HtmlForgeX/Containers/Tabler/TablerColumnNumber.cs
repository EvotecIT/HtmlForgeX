namespace HtmlForgeX;
/// <summary>
///
/// Link: https://getbootstrap.com/docs/4.0/layout/grid/
/// </summary>
public enum TablerColumnNumber {
    Auto,
    None,
    /// <summary>
    /// The zero 'col-0' column
    /// </summary>
    Zero = 0,
    /// <summary>
    /// The one 'col-1' column
    /// </summary>
    One = 1,
    Two = 2,
    Three = 3,
    Four = 4,
    Five = 5,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Eleven,
    Twelve,

    /// <summary>
    /// The medium automatic column
    /// </summary>
    MediumAuto,
    /// <summary>
    /// The medium six 'col-md-6' column
    /// </summary>
    MediumSix,
    SmallSix,
    LargeSix,
    ExtraLargeSix
}

public static class ColumnNumberExtension {
    public static string EnumToString(this TablerColumnNumber numberOfColumns) {
        switch (numberOfColumns) {
            case TablerColumnNumber.None:
                return "col";
            case TablerColumnNumber.Auto:
                return "col-auto";
            case TablerColumnNumber.MediumAuto:
                return "col-md-auto";
            case TablerColumnNumber.SmallSix:
                return "col-sm-6";
            case TablerColumnNumber.MediumSix:
                return "col-md-6";
            case TablerColumnNumber.LargeSix:
                return "col-lg-6";
            case TablerColumnNumber.ExtraLargeSix:
                return "col-xl-6";
            default:
                return $"col-{(int)numberOfColumns}";
        }
    }
}
