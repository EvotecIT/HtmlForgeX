using System.Collections.Generic;

namespace HtmlForgeX;

public class TablerAvatar : Element {
    private string ValueEntry { get; set; } = "";
    private string ImageUrl { get; set; } = "";
    private TablerBadgeColor? ClassBackgroundColor { get; set; }
    private TablerBadgeColor? ClassTextColor { get; set; }
    private AvatarSize? PrivateAvatarSize { get; set; }
    private TablerMarginStyle? PrivateAvatarMargin { get; set; }

    public TablerAvatar BackgroundColor(TablerBadgeColor color) {
        ClassBackgroundColor = color;
        return this;
    }

    public TablerAvatar TextColor(TablerBadgeColor color) {
        ClassTextColor = color;
        return this;
    }

    public TablerAvatar Icon(TablerIcon icon) {
        ValueEntry = new TablerIconElement(icon).ToString();
        return this;
    }

    public TablerAvatar Image(string url) {
        ImageUrl = url;
        return this;
    }

    public TablerAvatar Size(AvatarSize size) {
        PrivateAvatarSize = size;
        return this;
    }

    public TablerAvatar Margin(TablerMarginStyle margin) {
        PrivateAvatarMargin = margin;
        return this;
    }

    public override string ToString() {
        HtmlTag avatarTag = new HtmlTag("span").Class("avatar");

        avatarTag.Class(PrivateAvatarSize?.EnumToString());
        avatarTag.Class(PrivateAvatarMargin?.EnumToString());

        if (ClassBackgroundColor != null) {
            avatarTag.Class($"bg-{ClassBackgroundColor.Value.EnumToString()}");
        }
        if (ClassTextColor != null) {
            avatarTag.Class($"text-{ClassTextColor.Value.EnumToString()}");
        }
        if (!string.IsNullOrEmpty(ImageUrl)) {
            avatarTag.Style("background-image", $"url({ImageUrl})");
        } else if (!string.IsNullOrEmpty(ValueEntry)) {
            avatarTag.Value(ValueEntry);
        }
        return avatarTag.ToString();
    }
}