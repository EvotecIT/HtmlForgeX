namespace HtmlForgeX;

public class TablerTrackingBlock : Element {
    private string TooltipTitle { get; set; }
    private TablerBackground PrivateTrackingColor { get; set; }

    public TablerTrackingBlock(string tooltipTitle, TablerBackground trackingColor) {
        TooltipTitle = tooltipTitle;
        PrivateTrackingColor = trackingColor;
    }

    public override string ToString() {
        var trackingBlockTag = new HtmlTag("div")
            .Class("tracking-block")
            .Class(PrivateTrackingColor.EnumToString())
            .Attribute("data-bs-toggle", "tooltip")
            .Attribute("data-bs-placement", "top")
            .Attribute("title", TooltipTitle);

        return trackingBlockTag.ToString();
    }
}