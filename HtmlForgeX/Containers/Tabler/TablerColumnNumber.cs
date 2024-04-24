namespace HtmlForgeX;

public enum TablerColumnNumber {
    Auto,
    None,
    Zero = 0,
    One = 1,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Eleven,
    Twelve
}

public static class ColumnNumberExtension {
    public static string EnumToString(this TablerColumnNumber columnNumber) {
        switch (columnNumber) {
            case TablerColumnNumber.None:
                return "col";
            case TablerColumnNumber.Auto:
                return "col-auto";
            default:
                return $"col-{(int)columnNumber}";
        }
    }
}
