namespace HtmlForgeX;

// https://tabler.io/docs/components/badges
// <span class="badge bg-blue">Blue</span>
// <span class="badge bg-cyan-lt">Cyan</span>

public class BadgeSpan : HtmlElement {
    public string Text { get; set; }
    public BadgeColor Color { get; set; }
    public BadgeColor? TextColor { get; set; }
    public bool IsLight { get; set; }
    public BadgeStyle Style { get; set; }

    public BadgeSpan(string text, BadgeColor color, BadgeStyle style = BadgeStyle.Normal, bool isLight = false, BadgeColor? textColor = null) {

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
        if (Style == BadgeStyle.Outline) {
            // Outline badges are not getting bg- color
            classString += " badge-outline";
        } else if (Style == BadgeStyle.Pill) {
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