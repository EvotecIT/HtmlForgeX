using System.Collections.Generic;

namespace HtmlForgeX;

/// <summary>
/// Displays an avatar image or icon with optional styling.
/// </summary>
public class TablerAvatar : Element {
    private string ValueEntry { get; set; } = "";
    private string ImageUrl { get; set; } = "";
    private TablerColor? ClassBackgroundColor { get; set; }
    private TablerColor? ClassTextColor { get; set; }
    private AvatarSize? PrivateAvatarSize { get; set; }
    private TablerMarginStyle? PrivateAvatarMargin { get; set; }

    /// <summary>
    /// Initializes or configures BackgroundColor.
    /// </summary>
    public TablerAvatar BackgroundColor(TablerColor color) {
        ClassBackgroundColor = color;
        return this;
    }

    /// <summary>
    /// Initializes or configures TextColor.
    /// </summary>
    public TablerAvatar TextColor(TablerColor color) {
        ClassTextColor = color;
        return this;
    }

    /// <summary>
    /// Initializes or configures Icon.
    /// </summary>
    public TablerAvatar Icon(TablerIconType TablerIconType) {
        ValueEntry = new TablerIconElement(TablerIconType).ToString();
        return this;
    }

    /// <summary>
    /// Initializes or configures Image.
    /// </summary>
    public TablerAvatar Image(string url) {
        ImageUrl = url;
        return this;
    }

    /// <summary>
    /// Initializes or configures Size.
    /// </summary>
    public TablerAvatar Size(AvatarSize size) {
        PrivateAvatarSize = size;
        return this;
    }

    /// <summary>
    /// Initializes or configures Margin.
    /// </summary>
    public TablerAvatar Margin(TablerMarginStyle margin) {
        PrivateAvatarMargin = margin;
        return this;
    }

    /// <summary>
    /// Initializes or configures ToString.
    /// </summary>
    public override string ToString() {
        HtmlTag avatarTag = new HtmlTag("span");
        var classes = new List<string> { "avatar" };

        void AddClass(string? className) {
            if (!string.IsNullOrEmpty(className) && !classes.Contains(className)) {
                classes.Add(className);
            }
        }

        AddClass(PrivateAvatarSize?.EnumToString());
        AddClass(PrivateAvatarMargin?.EnumToString());
        AddClass(ClassBackgroundColor?.ToTablerBackground());
        AddClass(ClassTextColor?.ToTablerText());

        foreach (var className in classes) {
            avatarTag.Class(className);
        }

        if (!string.IsNullOrEmpty(ImageUrl)) {
            avatarTag.Style("background-image", $"url({ImageUrl})");
        } else if (!string.IsNullOrEmpty(ValueEntry)) {
            avatarTag.Value(ValueEntry);
        }

        return avatarTag.ToString();
    }
}