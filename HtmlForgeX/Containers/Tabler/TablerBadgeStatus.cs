
namespace HtmlForgeX;

public class TablerBadgeStatus : Element {
    public string Status { get; set; }
    public BadgeColor Color { get; set; }

    public TablerBadgeStatus(string status, BadgeColor color) {
        Status = status;
        Color = color;
    }

    public override string ToString() {
        var colorString = Color.ToString().ToLower();
        return $"<span class=\"status status-{colorString}\">{Status}</span>";
    }
}
