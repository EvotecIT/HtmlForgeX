namespace HtmlForgeX;

public class TablerText : Element {
    /// <summary>
    /// Initializes or configures TablerText.
    /// </summary>
    public TablerText() { }
    /// <summary>
    /// Initializes or configures TablerText.
    /// </summary>
    public TablerText(string text) {
        ValueEntry = text;
    }
    private string ValueEntry { get; set; } = "";
    private TablerTextStyle? ClassTextStyle { get; set; }
    private TablerFontWeight? ClassWeight { get; set; }

    /// <summary>
    /// Initializes or configures Value.
    /// </summary>
    public TablerText Value(string value) {
        ValueEntry = value;
        return this;
    }

    /// <summary>
    /// Initializes or configures Style.
    /// </summary>
    public TablerText Style(TablerTextStyle style) {
        ClassTextStyle = style;
        return this;
    }

    /// <summary>
    /// Initializes or configures Weight.
    /// </summary>
    public TablerText Weight(TablerFontWeight weight) {
        ClassWeight = weight;
        return this;
    }

    /// <summary>
    /// Initializes or configures Text.
    /// </summary>
    public TablerText Text(string text) {
        ValueEntry += text;
        return this;
    }

    /// <summary>
    /// Initializes or configures ToString.
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