namespace HtmlForgeX;

/// <summary>
/// Renders a button element with a colored badge next to the text.
/// </summary>
public class TablerBadgeButton : Element {
    /// <summary>
    /// Gets or sets the main button label.
    /// </summary>
    public new string Text { get; set; }

    /// <summary>
    /// Gets or sets the badge text displayed next to the label.
    /// </summary>
    public string BadgeText { get; set; }

    /// <summary>
    /// Gets or sets the badge background color.
    /// </summary>
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