
namespace HtmlForgeX;

public class TablerBadgeStatus : Element {
    public string Status { get; set; }
    public TablerBadgeColor Color { get; set; }

    public TablerBadgeStatus(string status, TablerBadgeColor color) {
        Status = status;
        Color = color;
    }

    public override string ToString() {
        var colorString = Color.ToString().ToLower();
        return $"<span class=\"status status-{colorString}\">{Status}</span>";
    }
}
