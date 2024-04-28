namespace HtmlForgeX;

public class TablerTracking : Element {
    private List<TablerTrackingBlock> Blocks { get; set; } = new List<TablerTrackingBlock>();

    public TablerTracking Block(TablerTrackingBlock block) {
        Blocks.Add(block);
        return this;
    }

    public TablerTracking Block(string tooltipTitle, TablerColor trackingColor) {
        Blocks.Add(new TablerTrackingBlock(tooltipTitle, trackingColor));
        return this;
    }

    public override string ToString() {
        var trackingContainerTag = new HtmlTag("div").Class("tracking");

        foreach (var block in Blocks) {
            trackingContainerTag.Value(block.ToString());
        }

        return trackingContainerTag.ToString();
    }
}