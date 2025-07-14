namespace HtmlForgeX;

/// <summary>
/// Tabler Badge Status
/// </summary>
public class TablerBadgeStatus(string status, TablerColor color = TablerColor.Azure) : Element {
    private string PrivateStatus { get; set; } = status;
    private TablerColor PrivateColor { get; set; } = color;

/// <summary>
/// Method ToString.
/// </summary>
    public override string ToString() {
        var badgeStatusTag = new HtmlTag("span")
            .Class("status")
            .Class(PrivateColor.ToTablerStatus())
            .Value(PrivateStatus);
        return badgeStatusTag.ToString();
    }
}