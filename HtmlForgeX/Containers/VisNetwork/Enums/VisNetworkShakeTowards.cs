using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Shake towards options for hierarchical layout.
/// </summary>
[JsonConverter(typeof(VisNetworkEnumConverter<VisNetworkShakeTowards>))]  
public enum VisNetworkShakeTowards {
    /// <summary>
    /// Shake towards roots.
    /// </summary>
    Roots,
    
    /// <summary>
    /// Shake towards leaves.
    /// </summary>
    Leaves
}