using System.Collections.Generic;

namespace HtmlForgeX;

public class TablerIconElement : Element {
    public TablerIcon Icon { get; set; }
    public Dictionary<string, string> IconStyle { get; set; } = new Dictionary<string, string>();

    public TablerIconElement(TablerIcon icon) {
        GlobalStorage.Libraries.TryAdd(Libraries.TablerIcon, 0);
        Icon = icon;
    }

    public TablerIconElement Color(RGBColor color) {
        IconStyle.Add("color", color.ToHex());
        return this;
    }

    public TablerIconElement FontSize(int size) {
        IconStyle.Add("font-size", $"{size}px");
        return this;
    }

    public TablerIconElement StrokeWidth(double width) {
        IconStyle.Add("stroke-width", $"{width}px");
        return this;
    }

    public override string ToString() {
        var icon = new HtmlTag("i");
        icon.Class("ti " + Icon.Icon);
        foreach (var property in IconStyle) {
            icon.Style(property.Key, property.Value);
        }
        return icon.ToString();
    }
}