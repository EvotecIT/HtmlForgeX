namespace HtmlForgeX;

/// <summary>
/// Generates an anchor element styled as a badge.
/// </summary>
public class TablerBadgeLink : Element {
    private new string Text { get; set; }
    private string Href {
        get => _href;
        set {
            if (!Uri.TryCreate(value, UriKind.RelativeOrAbsolute, out _)) {
                throw new ArgumentException($"Invalid href value: {value}", nameof(value));
            }
            _href = value;
        }
    }
    private string _href = string.Empty;
    private TablerColor? Color { get; set; }

    private TablerBadgeStyle Style { get; set; }

    /// <summary>
    /// Initializes or configures TablerBadgeLink.
    /// </summary>
    public TablerBadgeLink(string text, string href, TablerColor color, TablerBadgeStyle style = TablerBadgeStyle.Normal) {
        Text = text;
        Href = href;
        Color = color;
        Style = style;
    }

    /// <summary>
    /// Initializes or configures ToString.
    /// </summary>
    public override string ToString() {
        var badgeTag = new HtmlTag("a")
            .Attribute("href", Href)
            .Class("badge")
            .Value(Text);

        if (Style == TablerBadgeStyle.Outline) {
            badgeTag.Class("badge-outline");
        } else if (Style == TablerBadgeStyle.Pill) {
            badgeTag.Class("badge-pill").Class(Color?.ToTablerBackground());
        } else {
            badgeTag.Class(Color?.ToTablerBackground());
        }

        return badgeTag.ToString();
    }
}