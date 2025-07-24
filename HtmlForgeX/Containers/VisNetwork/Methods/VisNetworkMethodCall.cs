using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Represents a method call to be executed on the VisNetwork instance after initialization.
/// </summary>
public class VisNetworkMethodCall {
    /// <summary>
    /// Gets or sets the method name to call.
    /// </summary>
    public string Method { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the parameters for the method call.
    /// </summary>
    public object[]? Parameters { get; set; }

    /// <summary>
    /// Gets or sets whether this method should be called after a delay.
    /// </summary>
    public int? Delay { get; set; }
}