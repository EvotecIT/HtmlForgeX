using System;

namespace HtmlForgeX;

public enum TablerFontWeight {
    Medium,
    // Add more options here as needed
}

public enum TableTextStyle {
    Muted,
    // Add more options here as needed
}

public class TablerText : Element {
    public TablerText() { }
    public TablerText(string text) {
        ValueEntry = text;
    }
    private string ValueEntry { get; set; } = "";
    private TableTextStyle? ClassTextStyle { get; set; }
    private TablerFontWeight? ClassWeight { get; set; }

    public TablerText Value(string value) {
        ValueEntry = value;
        return this;
    }

    public TablerText Style(TableTextStyle style) {
        ClassTextStyle = style;
        return this;
    }

    public TablerText Weight(TablerFontWeight weight) {
        ClassWeight = weight;
        return this;
    }

    public TablerText Text(string text) {
        ValueEntry += text;
        return this;
    }

    public override string ToString() {
        HtmlTag textTag = new HtmlTag("div");
        if (ClassWeight.HasValue) {
            textTag.Class($"font-weight-{ClassWeight.Value.ToString().ToLower()}");
        }
        if (ClassTextStyle.HasValue) {
            textTag.Class($"text-{ClassTextStyle.Value.ToString().ToLower()}");
        }
        if (!string.IsNullOrEmpty(ValueEntry)) {
            textTag.Append(ValueEntry);
        }
        return textTag.ToString();
    }
}