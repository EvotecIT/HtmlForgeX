using System.Linq;

using HtmlForgeX.Extensions;

namespace HtmlForgeX;

/// <summary>
/// Visual representation of item progress using colored blocks.
/// </summary>
public class TablerTracking : Element {
    private List<TablerTrackingBlock> Blocks { get; set; } = new List<TablerTrackingBlock>();

    /// <summary>
    /// Initializes or configures Block.
    /// </summary>
    public TablerTracking Block(TablerTrackingBlock block) {
        Blocks.Add(block);
        return this;
    }

    /// <summary>
    /// Initializes or configures Block.
    /// </summary>
    public TablerTracking Block(string tooltipTitle, TablerColor trackingColor) {
        Blocks.Add(new TablerTrackingBlock(tooltipTitle, trackingColor));
        return this;
    }

    /// <summary>
    /// Initializes or configures ToString.
    /// </summary>
    public override string ToString() {
        var trackingContainerTag = new HtmlTag("div").Class("tracking");

        foreach (var block in Blocks.WhereNotNull()) {
            trackingContainerTag.Value(block);
        }

        return trackingContainerTag.ToString();
    }
}