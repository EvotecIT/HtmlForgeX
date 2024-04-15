
namespace HtmlForgeX;

public class BadgeStatus : HtmlElement {
    public string Status { get; set; }
    public BadgeColor Color { get; set; }

    public BadgeStatus(string status, BadgeColor color) {
        Status = status;
        Color = color;
    }

    public override string ToString() {
        var colorString = Color.ToString().ToLower();
        return $"<span class=\"status status-{colorString}\">{Status}</span>";
    }
}
