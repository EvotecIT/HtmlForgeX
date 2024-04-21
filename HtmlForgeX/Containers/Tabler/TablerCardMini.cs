using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlForgeX;
public class TablerCardMini : TablerCard {
    private string? CardStyle { get; set; }

    private TablerIcon AvatarIcon { get; set; } = TablerIcon.User;
    private TablerBadgeColor AvatarBackgroundColor { get; set; } = TablerBadgeColor.Blue;
    private TablerBadgeColor AvatarTextColor { get; set; } = TablerBadgeColor.White;
    private string TitleText { get; set; } = "";
    private string SubtitleText { get; set; } = "";


    public TablerCardMini Avatar(TablerIcon icon) {
        AvatarIcon = icon;
        return this;
    }

    public TablerCardMini BackgroundColor(TablerBadgeColor color) {
        AvatarBackgroundColor = color;
        return this;
    }

    public TablerCardMini TextColor(TablerBadgeColor color) {
        AvatarTextColor = color;
        return this;
    }

    public TablerCardMini Title(string title) {
        TitleText = title;
        return this;
    }

    public TablerCardMini Subtitle(string subtitle) {
        SubtitleText = subtitle;
        return this;
    }

    public override string ToString() {
        //Console.WriteLine("Generating HtmlCard...");

        // Create the outer div for the card
        var cardDiv = new HtmlTag("div");
        cardDiv.Class("card").Class(CardStyle).Class(null);

        // Create the inner div for the card body
        var cardBodyDiv = new HtmlTag("div");
        cardBodyDiv.Class("card-body").Append(Content);
        cardBodyDiv.Attributes["style"] = Style;

        var cardInside = cardBodyDiv.Row(cardRow => {
            cardRow.Column(TablerColumnNumber.Auto, avatarColumn => {
                avatarColumn.Avatar().Icon(AvatarIcon).BackgroundColor(AvatarBackgroundColor)
                    .TextColor(AvatarTextColor);

            });
            cardRow.Column(textColumn => {
                textColumn.Text(TitleText).Weight(TablerFontWeight.Medium);
                textColumn.Text(SubtitleText).Style(TablerTextStyle.Muted);
            });
        });

        cardBodyDiv.Append(cardInside);

        // Add the card body to the card
        cardDiv.Append(cardBodyDiv);

        var result = cardDiv.ToString();

        // Console.WriteLine("Generated TablerCardMini: " + result);
        return result;
    }
}
