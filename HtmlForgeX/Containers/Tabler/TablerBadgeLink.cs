namespace HtmlForgeX;

// var badgeLink = new BadgeLink("Blue", "#", BadgeColor.Blue);
// string htmlLink = badgeLink.ToString();  // "<a href=\"#\" class=\"badge bg-blue\">Blue</a>"

public class TablerBadgeLink : Element {
    public string Text { get; set; }
    public string Href { get; set; }
    public TablerBadgeColor Color { get; set; }
    public bool IsLight { get; set; }
    public TablerBadgeStyle Style { get; set; }

    public TablerBadgeLink(string text, string href, TablerBadgeColor color, TablerBadgeStyle style = TablerBadgeStyle.Normal, bool isLight = false) {
        Text = text;
        Href = href;
        Color = color;
        IsLight = isLight;
        Style = style;
    }

    public override string ToString() {
        string colorString = Color.ToString().ToLower();
        if (IsLight) {
            colorString += "-lt";
        }
        string classString = "badge";
        if (Style == TablerBadgeStyle.Outline) {
            classString += " badge-outline";
        } else if (Style == TablerBadgeStyle.Pill) {
            classString += " badge-pill bg-" + colorString;
        } else {
            classString += " bg-" + colorString;
        }
        return $"<a href=\"{Href}\" class=\"{classString}\">{Text}</a>";
    }
}
