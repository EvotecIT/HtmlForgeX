namespace HtmlForgeX;

public class TablerColumnNumber {
    private readonly string _value;

    private TablerColumnNumber(string value) {
        _value = value;
    }

    public override string ToString() {
        return _value;
    }

    public static TablerColumnNumber Auto = new TablerColumnNumber("col-auto");
    public static TablerColumnNumber None = new TablerColumnNumber("col");
    public static TablerColumnNumber Zero = new TablerColumnNumber("col-0");
    public static TablerColumnNumber One = new TablerColumnNumber("col-1");
    public static TablerColumnNumber Two = new TablerColumnNumber("col-2");
    public static TablerColumnNumber Three = new TablerColumnNumber("col-3");
    public static TablerColumnNumber Four = new TablerColumnNumber("col-4");
    public static TablerColumnNumber Five = new TablerColumnNumber("col-5");
    public static TablerColumnNumber Six = new TablerColumnNumber("col-6");
    public static TablerColumnNumber Seven = new TablerColumnNumber("col-7");
    public static TablerColumnNumber Eight = new TablerColumnNumber("col-8");
    public static TablerColumnNumber Nine = new TablerColumnNumber("col-9");
    public static TablerColumnNumber Ten = new TablerColumnNumber("col-10");
    public static TablerColumnNumber Eleven = new TablerColumnNumber("col-11");
    public static TablerColumnNumber Twelve = new TablerColumnNumber("col-12");
}

//public enum TablerColumnNumber {
//    Auto,
//    None,
//    Zero = 0,
//    One = 1,
//    Two,
//    Three,
//    Four,
//    Five,
//    Six,
//    Seven,
//    Eight,
//    Nine,
//    Ten,
//    Eleven,
//    Twelve
//}

//public static class ColumnNumberExtension {
//    public static string ToString(this TablerColumnNumber columnNumber) {
//        switch (columnNumber) {
//            case TablerColumnNumber.None:
//                return "col";
//            case TablerColumnNumber.Auto:
//                return "col-auto";
//            default:
//                return $"col-{(int)columnNumber}";
//        }
//    }
//}