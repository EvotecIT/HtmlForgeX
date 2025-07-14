namespace HtmlForgeX;

public class TablerText : Element {
    public TablerText() { }
    public TablerText(string text) {
        ValueEntry = text;
    }
    private string ValueEntry { get; set; } = "";
    private TablerTextStyle? ClassTextStyle { get; set; }
    private TablerFontWeight? ClassWeight { get; set; }

/// <summary>
/// Method Value.
/// </summary>
    public TablerText Value(string value) {
        ValueEntry = value;
        return this;
    }

/// <summary>
/// Method Style.
/// </summary>
    public TablerText Style(TablerTextStyle style) {
        ClassTextStyle = style;
        return this;
    }

/// <summary>
/// Method Weight.
/// </summary>
    public TablerText Weight(TablerFontWeight weight) {
        ClassWeight = weight;
        return this;
    }

/// <summary>
/// Method Text.
/// </summary>
    public TablerText Text(string text) {
        ValueEntry += text;
        return this;
    }

/// <summary>
/// Method ToString.
/// </summary>
    public override string ToString() {
        HtmlTag textTag = new HtmlTag("div");
        if (ClassWeight.HasValue) {
            textTag.Class($"font-weight-{ClassWeight.Value.ToString().ToLower()}");
        }
        if (ClassTextStyle.HasValue) {
            textTag.Class($"text-{ClassTextStyle.Value.ToString().ToLower()}");
        }
        if (!string.IsNullOrEmpty(ValueEntry)) {
            textTag.Value(ValueEntry);
        }
        return textTag.ToString();
    }
}