namespace HtmlForgeX;

// https://tabler.io/docs/components/badges
// <span class="badge bg-blue">Blue</span>
// <span class="badge bg-cyan-lt">Cyan</span>

public class TablerBadgeSpan : Element {
    public string Text { get; set; }
    public TablerBadgeColor Color { get; set; }
    public TablerBadgeColor? TextColor { get; set; }
    public bool IsLight { get; set; }
    public TablerBadgeStyle Style { get; set; }

    public TablerBadgeSpan(string text, TablerBadgeColor color, TablerBadgeStyle style = TablerBadgeStyle.Normal, bool isLight = false, TablerBadgeColor? textColor = null) {
        Text = text;
        Color = color;
        IsLight = isLight;
        Style = style;
        TextColor = textColor;
    }

    public override string ToString() {
        string colorString = Color.ToString().ToLower();
        if (IsLight) {
            colorString += "-lt";
        }
        string classString = "badge";
        if (Style == TablerBadgeStyle.Outline) {
            // Outline badges are not getting bg- color
            classString += " badge-outline";
        } else if (Style == TablerBadgeStyle.Pill) {
            classString += " badge-pill bg-" + colorString;
        } else {
            classString += " bg-" + colorString;
        }
        if (TextColor.HasValue) {
            classString += " text-" + TextColor.Value.ToString().ToLower();
        }
        return $"<span class=\"{classString}\">{Text}</span>";
    }
}