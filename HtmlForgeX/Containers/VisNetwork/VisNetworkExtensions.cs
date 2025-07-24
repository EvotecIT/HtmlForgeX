namespace HtmlForgeX;

/// <summary>
/// Extension methods for VisNetwork legacy compatibility.
/// </summary>
public static class VisNetworkExtensions {
    /// <summary>
    /// Converts legacy VisNetworkNode to new VisNetworkNodeOptions.
    /// </summary>
    public static VisNetworkNodeOptions ToNodeOptions(this VisNetworkNode node) {
        var options = new VisNetworkNodeOptions()
            .WithId(node.Id!)
            .WithLabel(node.Label!)
            .WithTitle(node.Title!);

        if (node.Shape.HasValue) options.WithShape(node.Shape.Value);
        if (node.Group != null) options.WithGroup(node.Group);
        if (node.Color != null) options.WithColor(node.Color);
        if (node.Size.HasValue) options.WithSize(node.Size.Value);
        if (node.Hidden.HasValue) options.WithHidden(node.Hidden.Value);
        if (node.Physics.HasValue) options.WithPhysics(node.Physics.Value);
        if (node.X.HasValue && node.Y.HasValue) options.WithPosition(node.X.Value, node.Y.Value);
        if (node.Image != null) options.WithImage(node.Image);

        // Preserve the SkipAutoEmbedding flag
        options.SkipAutoEmbedding = node.SkipAutoEmbedding;

        return options;
    }

    /// <summary>
    /// Converts legacy VisNetworkEdge to new VisNetworkEdgeOptions.
    /// </summary>
    public static VisNetworkEdgeOptions ToEdgeOptions(this VisNetworkEdge edge) {
        var options = new VisNetworkEdgeOptions()
            .WithConnection(edge.From!, edge.To!)
            .WithLabel(edge.Label!)
            .WithTitle(edge.Title!);

        if (edge.Arrows.HasValue && edge.Arrows.Value != VisNetworkArrows.None) {
            var arrowOptions = new VisNetworkArrowOptions();
            if (edge.Arrows.Value.HasFlag(VisNetworkArrows.To)) arrowOptions.WithTo(true);
            if (edge.Arrows.Value.HasFlag(VisNetworkArrows.From)) arrowOptions.WithFrom(true);
            if (edge.Arrows.Value.HasFlag(VisNetworkArrows.Middle)) arrowOptions.WithMiddle(true);
            options.WithArrows(arrowOptions);
        }

        if (edge.Color != null) options.WithColor(edge.Color);
        if (edge.Width.HasValue) options.WithWidth(edge.Width.Value);
        if (edge.Dashes.HasValue) options.WithDashes(edge.Dashes.Value);
        if (edge.Hidden.HasValue) options.WithHidden(edge.Hidden.Value);
        if (edge.Physics.HasValue) options.WithPhysics(edge.Physics.Value);
        if (edge.Length.HasValue) options.WithLength(edge.Length.Value);

        return options;
    }
}