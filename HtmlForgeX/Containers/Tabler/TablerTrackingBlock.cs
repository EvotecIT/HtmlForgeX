namespace HtmlForgeX;

public class TablerTrackingBlock : Element {
    private string TooltipTitle { get; set; }
    private TablerColor PrivateTrackingColor { get; set; }

    /// <summary>
    /// Initializes or configures TablerTrackingBlock.
    /// </summary>
    public TablerTrackingBlock(string tooltipTitle, TablerColor trackingColor) {
        TooltipTitle = tooltipTitle;
        PrivateTrackingColor = trackingColor;
    }

    /// <summary>
    /// Initializes or configures ToString.
    /// </summary>
    public override string ToString() {
        var trackingBlockTag = new HtmlTag("div")
            .Class("tracking-block")
            .Class(PrivateTrackingColor.ToTablerBackground())
            .Attribute("data-bs-toggle", "tooltip")
            .Attribute("data-bs-placement", "top")
            .Attribute("title", TooltipTitle);

        return trackingBlockTag.ToString();
    }
}