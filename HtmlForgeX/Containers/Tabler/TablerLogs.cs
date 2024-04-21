namespace HtmlForgeX;

public class TablerLogs : Element {
    private HeaderLevelTag? PrivateLevelTitle { get; set; }
    private string? PrivateTitle { get; set; }
    private string PrivateCode { get; set; }
    public TablerLogs(string code) {
        PrivateCode = code;
    }

    public TablerLogs Title(HeaderLevelTag level, string title) {
        PrivateLevelTitle = level;
        PrivateTitle = title;
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
        HtmlTag preTag = new HtmlTag("pre").SetValue(PrivateCode);
        logsTag.SetValue(preTag.ToString());

        if (header != null) {
            return header + logsTag.ToString();
        } else {
            return logsTag.ToString();
        }
    }
}
