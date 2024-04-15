namespace HtmlForgeX;

// var badgeLink = new BadgeLink("Blue", "#", BadgeColor.Blue);
// string htmlLink = badgeLink.ToString();  // "<a href=\"#\" class=\"badge bg-blue\">Blue</a>"

public class BadgeLink : HtmlElement {
    public string Text { get; set; }
    public string Href { get; set; }
    public BadgeColor Color { get; set; }
    public bool IsLight { get; set; }
    public BadgeStyle Style { get; set; }

    public BadgeLink(string text, string href, BadgeColor color, BadgeStyle style = BadgeStyle.Normal, bool isLight = false) {
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
        if (Style == BadgeStyle.Outline) {
            classString += " badge-outline";
        } else if (Style == BadgeStyle.Pill) {
            classString += " badge-pill bg-" + colorString;
        } else {
            classString += " bg-" + colorString;
        }
        return $"<a href=\"{Href}\" class=\"{classString}\">{Text}</a>";
    }
}
