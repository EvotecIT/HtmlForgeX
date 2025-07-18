namespace HtmlForgeX;

/// <summary>
/// Compact version of <see cref="TablerCard"/> typically used for dashboard widgets.
/// </summary>
public class TablerCardMini : TablerCard {
    private string? PrivateCardStyle { get; set; }
    private TablerIconType AvatarIcon { get; set; } = TablerIconType.Badge;
    private TablerColor AvatarBackgroundColor { get; set; } = TablerColor.Blue;
    private TablerColor AvatarTextColor { get; set; } = TablerColor.White;
    private RGBColor? CustomAvatarBackgroundColor { get; set; }
    private RGBColor? CustomAvatarTextColor { get; set; }
    private string TitleText { get; set; } = "";
    private string SubtitleText { get; set; } = "";

    /// <summary>
    /// Initializes or configures Avatar.
    /// </summary>
    public TablerCardMini Avatar(TablerIconType TablerIconType) {
        AvatarIcon = TablerIconType;
        return this;
    }

    /// <summary>
    /// Initializes or configures BackgroundColor.
    /// </summary>
    public new TablerCardMini BackgroundColor(TablerColor color) {
        AvatarBackgroundColor = color;
        return this;
    }

    /// <summary>
    /// Initializes or configures TextColor.
    /// </summary>
    public TablerCardMini TextColor(TablerColor color) {
        AvatarTextColor = color;
        return this;
    }

    /// <summary>
    /// Initializes or configures Title.
    /// </summary>
    public TablerCardMini Title(string title) {
        TitleText = title;
        return this;
    }

    /// <summary>
    /// Initializes or configures Subtitle.
    /// </summary>
    public TablerCardMini Subtitle(string subtitle) {
        SubtitleText = subtitle;
        return this;
    }

    /// <summary>
    /// Set custom avatar background color using RGBColor for precise color control
    /// </summary>
    public new TablerCardMini BackgroundColor(RGBColor backgroundColor, RGBColor? textColor = null) {
        CustomAvatarBackgroundColor = backgroundColor;
        CustomAvatarTextColor = textColor;
        return this;
    }

    /// <summary>
    /// Set custom avatar background color using hex string for precise color control
    /// </summary>
    public new TablerCardMini BackgroundColor(string hexBackgroundColor, string? hexTextColor = null) {
        CustomAvatarBackgroundColor = new RGBColor(hexBackgroundColor);
        if (!string.IsNullOrEmpty(hexTextColor)) {
            CustomAvatarTextColor = new RGBColor(hexTextColor!);
        }
        return this;
    }

    /// <summary>
    /// Initializes or configures ToString.
    /// </summary>
    public override string ToString() {
        //Console.WriteLine("Generating HtmlCard...");

        // Create the outer div for the card
        var cardDiv = new HtmlTag("div");
        cardDiv.Class("card").Class(PrivateCardStyle).Class(null);

        // Create the inner div for the card body
        var cardBodyDiv = new HtmlTag("div");
        cardBodyDiv.Class("card-body").Value(CardContent);
        cardBodyDiv.Attributes["style"] = CardInnerStyle!;

        var cardInside = cardBodyDiv.Row(cardRow => {
            cardRow.Column(TablerColumnNumber.Auto, avatarColumn => {
                var avatar = avatarColumn.Avatar().Icon(AvatarIcon);

                // Use custom RGBColor if set, otherwise use TablerColor
                if (CustomAvatarBackgroundColor != null) {
                    avatar.BackgroundColor(CustomAvatarBackgroundColor, CustomAvatarTextColor);
                } else {
                    avatar.BackgroundColor(AvatarBackgroundColor).TextColor(AvatarTextColor);
                }
            });
            cardRow.Column(textColumn => {
                textColumn.Text(TitleText).Weight(TablerFontWeight.Medium);
                textColumn.Text(SubtitleText).Style(TablerTextStyle.Muted);
            });
        });

        cardBodyDiv.Value(cardInside);

        // Add the card body to the card
        cardDiv.Value(cardBodyDiv);

        var result = cardDiv.ToString();

        // Console.WriteLine("Generated TablerCardMini: " + result);
        return result;
    }
}