using System.Text.Json;

namespace HtmlForgeX;

/// <summary>
/// Provides predefined method templates for common operations.
/// </summary>
public static class VisNetworkMethodTemplates {
    /// <summary>
    /// JavaScript to fit all nodes with animation.
    /// </summary>
    public static string FitAllAnimated => @"
        network.fit({
            animation: {
                duration: 1000,
                easingFunction: 'easeInOutQuad'
            }
        });";

    /// <summary>
    /// JavaScript to center the view on a specific node.
    /// </summary>
    public static string CenterOnNode(object nodeId) => $@"
        network.focus({JsonSerializer.Serialize(nodeId)}, {{
            scale: 1.5,
            animation: {{
                duration: 1000,
                easingFunction: 'easeInOutQuad'
            }}
        }});";

    /// <summary>
    /// JavaScript to select nodes and edges programmatically.
    /// </summary>
    public static string SelectNodesAndEdges(object[] nodeIds, object[] edgeIds) => $@"
        network.selectNodes({JsonSerializer.Serialize(nodeIds)});
        network.selectEdges({JsonSerializer.Serialize(edgeIds)});";

    /// <summary>
    /// JavaScript to get current viewport information.
    /// </summary>
    public static string GetViewportInfo => @"
        var viewPosition = network.getViewPosition();
        var scale = network.getScale();
        console.log('View Position:', viewPosition);
        console.log('Scale:', scale);";

    /// <summary>
    /// JavaScript to export network positions.
    /// </summary>
    public static string ExportPositions => @"
        var positions = network.getPositions();
        console.log('Network Positions:', JSON.stringify(positions, null, 2));
        return positions;";

    /// <summary>
    /// JavaScript to get bounding box of nodes.
    /// </summary>
    public static string GetBoundingBox(params object[] nodeIds) => $@"
        var boundingBox = network.getBoundingBox({JsonSerializer.Serialize(nodeIds)});
        console.log('Bounding Box:', boundingBox);
        return boundingBox;";
}
