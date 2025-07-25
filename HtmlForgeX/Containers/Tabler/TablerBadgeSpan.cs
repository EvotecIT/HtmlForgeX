namespace HtmlForgeX;

/// <summary>
/// Represents a badge styled <c>span</c> element.
/// </summary>
public class TablerBadgeSpan : Element {
    /// <summary>
    /// Gets or sets the badge text.
    /// </summary>
    public new string Text { get; set; }

    /// <summary>
    /// Gets or sets the badge background color.
    /// </summary>
    public TablerColor? Color { get; set; }

    /// <summary>
    /// Gets or sets the badge text color.
    /// </summary>
    public TablerColor? TextColor { get; set; }

    /// <summary>
    /// Gets or sets the visual style applied to the badge.
    /// </summary>
    public TablerBadgeStyle Style { get; set; }

    /// <summary>
    /// Initializes or configures TablerBadgeSpan.
    /// </summary>
    public TablerBadgeSpan(string text, TablerColor? color, TablerBadgeStyle style = TablerBadgeStyle.Normal, TablerColor? textColor = null) {
        Text = text;
        Color = color;
        Style = style;
        TextColor = textColor;
    }

    /// <summary>
    /// Initializes or configures ToString.
    /// </summary>
    public override string ToString() {
        var badgeTag = new HtmlTag("span")
            .Class("badge")
            .Value(Text);

        if (Style == TablerBadgeStyle.Outline) {
            badgeTag.Class("badge-outline");
        } else if (Style == TablerBadgeStyle.Pill) {
            badgeTag.Class("badge-pill").Class(Color?.ToTablerBackground());
        } else {
            badgeTag.Class(Color?.ToTablerBackground());
        }
        badgeTag.Class(TextColor?.ToTablerText());
        return badgeTag.ToString();
    }
}