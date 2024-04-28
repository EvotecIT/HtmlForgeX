using HtmlForgeX;

public class TablerBadgeStatus : Element {
    public string Status { get; set; }
    public TablerColor Color { get; set; }

    public TablerBadgeStatus(string status, TablerColor color) {
        Status = status;
        Color = color;
    }

    public override string ToString() {
        var badgeStatusTag = new HtmlTag("span")
            .Class("status")
            .Class(Color.ToTablerStatus())
            .Value(Status);
        return badgeStatusTag.ToString();
    }
}