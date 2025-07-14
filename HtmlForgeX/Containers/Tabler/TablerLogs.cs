namespace HtmlForgeX;

public class TablerLogs : Element {
    private HeaderLevelTag? PrivateLevelTitle { get; set; }
    private string? PrivateTitle { get; set; }
    private string PrivateCode { get; set; }
    private TablerLogsTheme ThemeEntry { get; set; } = TablerLogsTheme.Dark;
    private string? CustomBackgroundClass { get; set; }
    private string? CustomTextClass { get; set; }
    public TablerLogs(string code) {
        PrivateCode = code;
    }
    public TablerLogs(string[] code) {
        PrivateCode = string.Join(Environment.NewLine, code);
    }

    public TablerLogs(List<string> code) {
        PrivateCode = string.Join(Environment.NewLine, code);
    }

    public TablerLogs Title(HeaderLevelTag level, string title) {
        PrivateLevelTitle = level;
        PrivateTitle = title;
        return this;
    }

    public TablerLogs Theme(TablerLogsTheme theme) {
        ThemeEntry = theme;
        return this;
    }

    public TablerLogs CustomTheme(string backgroundClass, string textClass) {
        ThemeEntry = TablerLogsTheme.Custom;
        CustomBackgroundClass = backgroundClass;
        CustomTextClass = textClass;
        return this;
    }

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
            ? $"{CustomBackgroundClass} {CustomTextClass}".Trim()
            : ThemeEntry.ToClassString();

        HtmlTag preTag = new HtmlTag("pre")
            .Class(classes)
            .Value(PrivateCode);
        logsTag.Value(preTag);

        if (header != null) {
            return header + logsTag.ToString();
        } else {
            return logsTag.ToString();
        }
    }
}
