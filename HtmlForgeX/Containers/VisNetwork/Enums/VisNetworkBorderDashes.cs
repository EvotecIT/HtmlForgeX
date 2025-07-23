using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Border dash pattern options.
/// </summary>
[JsonConverter(typeof(VisNetworkEnumConverter<VisNetworkBorderDashes>))]
public enum VisNetworkBorderDashes {
    /// <summary>
    /// Use solid borders.
    /// </summary>
    False,

    /// <summary>
    /// Use dashed borders.
    /// </summary>
    True,

    /// <summary>
    /// Custom dash pattern specified by an array.
    /// </summary>
    Array
}