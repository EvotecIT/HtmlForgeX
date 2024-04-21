using System.Collections.Generic;

namespace HtmlForgeX;

public class TablerAvatar : Element {
    private string ValueEntry { get; set; } = "";
    private BadgeColor? ClassBackgroundColor { get; set; }
    private BadgeColor? ClassTextColor { get; set; }

    public TablerAvatar BackgroundColor(BadgeColor color) {
        ClassBackgroundColor = color;
        return this;
    }

    public TablerAvatar TextColor(BadgeColor color) {
        ClassTextColor = color;
        return this;
    }

    public TablerAvatar Icon(TablerIcon icon) {
        ValueEntry = new TablerIconElement(icon).ToString();
        return this;
    }


    public override string ToString() {
        HtmlTag avatarTag = new HtmlTag("span").Class($"avatar");
        if (ClassBackgroundColor != null) {
            avatarTag.Class($"bg-{ClassBackgroundColor.Value.ToLowerString()}");
        }
        if (ClassTextColor != null) {
            avatarTag.Class($"text-{ClassTextColor.Value.ToLowerString()}");
        }
        if (!string.IsNullOrEmpty(ValueEntry)) {
            avatarTag.Append(ValueEntry);
        }
        return avatarTag.ToString();
    }
}
