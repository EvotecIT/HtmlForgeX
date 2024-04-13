namespace HtmlForgeX;

public enum FontWeight {
    Normal = 1,
    Bold,
    Bolder,
    Lighter,
    W100 = 100,
    W200 = 200,
    W300 = 300,
    W400 = 400,
    W500 = 500,
    W600 = 600,
    W700 = 700,
    W800 = 800,
    W900 = 900
}

public static class FontWeightExtensions {
    public static string ToCssString(this FontWeight value) {
        return value switch {
            FontWeight.Normal => "normal",
            FontWeight.Bold => "bold",
            FontWeight.Bolder => "bolder",
            FontWeight.Lighter => "lighter",
            FontWeight.W100 => "100",
            FontWeight.W200 => "200",
            FontWeight.W300 => "300",
            FontWeight.W400 => "400",
            FontWeight.W500 => "500",
            FontWeight.W600 => "600",
            FontWeight.W700 => "700",
            FontWeight.W800 => "800",
            FontWeight.W900 => "900",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
        };
    }
}
