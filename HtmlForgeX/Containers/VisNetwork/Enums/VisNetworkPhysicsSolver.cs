using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Physics solver algorithms for network simulation.
/// </summary>
[JsonConverter(typeof(VisNetworkEnumConverter<VisNetworkPhysicsSolver>))]
public enum VisNetworkPhysicsSolver {
    /// <summary>
    /// Uses the Barnes-Hut algorithm.
    /// </summary>
    BarnesHut,

    /// <summary>
    /// Uses the ForceAtlas2 based algorithm.
    /// </summary>
    ForceAtlas2based,

    /// <summary>
    /// Uses a repulsion algorithm.
    /// </summary>
    Repulsion,

    /// <summary>
    /// Uses hierarchical repulsion.
    /// </summary>
    HierarchicalRepulsion
}