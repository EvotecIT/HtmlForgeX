using System.Collections.Generic;

namespace HtmlForgeX;

public class TablerAvatar : Element {
    private string ValueEntry { get; set; } = "";
    private TablerBadgeColor? ClassBackgroundColor { get; set; }
    private TablerBadgeColor? ClassTextColor { get; set; }

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


    public override string ToString() {
        HtmlTag avatarTag = new HtmlTag("span").Class($"avatar");
        if (ClassBackgroundColor != null) {
            avatarTag.Class($"bg-{ClassBackgroundColor.Value.EnumToString()}");
        }
        if (ClassTextColor != null) {
            avatarTag.Class($"text-{ClassTextColor.Value.EnumToString()}");
        }
        if (!string.IsNullOrEmpty(ValueEntry)) {
            avatarTag.Append(ValueEntry);
        }
        return avatarTag.ToString();
    }
}
