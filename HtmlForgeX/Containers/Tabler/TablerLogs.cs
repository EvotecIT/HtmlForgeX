namespace HtmlForgeX;

public class TablerLogs : Element {
    private HeaderLevelTag? PrivateLevelTitle { get; set; }
    private string? PrivateTitle { get; set; }
    private string PrivateCode { get; set; }
    private TablerLogsTheme ThemeEntry { get; set; } = TablerLogsTheme.Dark;
    private string? CustomBackgroundClass { get; set; }
    private string? CustomTextClass { get; set; }
    private RGBColor? CustomBackgroundColor { get; set; }
    private RGBColor? CustomTextColor { get; set; }
    public TablerLogs(string code) {
        PrivateCode = code;
    }
    public TablerLogs(string[] code) {
        PrivateCode = string.Join(Environment.NewLine, code);
    }

    public TablerLogs(List<string> code) {
        PrivateCode = string.Join(Environment.NewLine, code);
    }

/// <summary>
/// Method Title.
/// </summary>
    public TablerLogs Title(HeaderLevelTag level, string title) {
        PrivateLevelTitle = level;
        PrivateTitle = title;
        return this;
    }

/// <summary>
/// Method Theme.
/// </summary>
    public TablerLogs Theme(TablerLogsTheme theme) {
        ThemeEntry = theme;
        return this;
    }

/// <summary>
/// Method CustomTheme.
/// </summary>
    public TablerLogs CustomTheme(string backgroundClass, string textClass) {
        ThemeEntry = TablerLogsTheme.Custom;
        CustomBackgroundClass = backgroundClass;
        CustomTextClass = textClass;
        return this;
    }

/// <summary>
/// Method CustomColors.
/// </summary>
    public TablerLogs CustomColors(RGBColor backgroundColor, RGBColor textColor) {
        ThemeEntry = TablerLogsTheme.Custom;
        CustomBackgroundColor = backgroundColor;
        CustomTextColor = textColor;
        return this;
    }

/// <summary>
/// Method CustomColors.
/// </summary>
    public TablerLogs CustomColors(string backgroundColorHex, string textColorHex) {
        return CustomColors(new RGBColor(backgroundColorHex), new RGBColor(textColorHex));
    }

/// <summary>
/// Method ToString.
/// </summary>
    public override string ToString() {
        HeaderLevel? header;
        if (PrivateLevelTitle != null && PrivateTitle != null) {
            header = new HeaderLevel(PrivateLevelTitle.Value, PrivateTitle);
        } else if (PrivateTitle != null) {
            header = new HeaderLevel(HeaderLevelTag.H4, PrivateTitle);
        } else {
            header = null;
        }

        HtmlTag logsTag = new HtmlTag("div");
        string classes = ThemeEntry == TablerLogsTheme.Custom
            ? (CustomBackgroundClass is not null && CustomTextClass is not null
                ? $"{CustomBackgroundClass} {CustomTextClass}".Trim()
                : string.Empty)
            : ThemeEntry.ToClassString();

        HtmlTag preTag = new HtmlTag("pre")
            .Class(classes)
            .Value(PrivateCode);

        if (CustomBackgroundColor is not null && CustomTextColor is not null) {
            preTag.Style("background-color", CustomBackgroundColor.ToHex());
            preTag.Style("color", CustomTextColor.ToHex());
        }
        logsTag.Value(preTag);

        if (header != null) {
            return header + logsTag.ToString();
        } else {
            return logsTag.ToString();
        }
    }
}