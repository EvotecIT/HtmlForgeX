namespace HtmlForgeX;

// var badgeButton = new BadgeButton("Notifications", "4", BadgeColor.Red);
// string htmlButton = badgeButton.ToString();  // "<button type=\"button\" class=\"btn\">Notifications <span class=\"badge bg-red ms-2\">4</span></button>"


public class BadgeButton : HtmlElement {
    public string Text { get; set; }
    public string BadgeText { get; set; }
    public BadgeColor BadgeColor { get; set; }

    public BadgeButton(string text, string badgeText, BadgeColor badgeColor) {
        Text = text;
        BadgeText = badgeText;
        BadgeColor = badgeColor;
    }

    public override string ToString() {
        string colorString = BadgeColor.ToString().ToLower();
        return $"<button type=\"button\" class=\"btn\">{Text} <span class=\"badge bg-{colorString} ms-2\">{BadgeText}</span></button>";
    }
}
