namespace HtmlForgeX;

public class TablerBadgeButton : Element {
    public new string Text { get; set; }
    public string BadgeText { get; set; }
    public TablerColor BadgeColor { get; set; }

    /// <summary>
    /// Initializes or configures TablerBadgeButton.
    /// </summary>
    public TablerBadgeButton(string text, string badgeText, TablerColor badgeColor) {
        Text = text;
        BadgeText = badgeText;
        BadgeColor = badgeColor;
    }

    /// <summary>
    /// Initializes or configures ToString.
    /// </summary>
    public override string ToString() {
        var badgeTag = new HtmlTag("span")
            .Class("badge")
            .Class("ms-2")
            .Class(BadgeColor.ToTablerBackground())
            .Value(BadgeText);

        var buttonTag = new HtmlTag("button")
            .Type("button")
            .Class("btn")
            .Value(Text, badgeTag);

        return buttonTag.ToString();
    }
}