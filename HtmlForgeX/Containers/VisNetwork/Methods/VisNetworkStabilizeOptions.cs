using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Options for stabilization.
/// </summary>
public class VisNetworkStabilizeOptions {
    /// <summary>
    /// Gets or sets the number of iterations used during stabilization.
    /// </summary>
    [JsonPropertyName("iterations")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Iterations { get; set; }

    /// <summary>
    /// Sets the number of iterations to stabilize.
    /// </summary>
    public VisNetworkStabilizeOptions WithIterations(int iterations) {
        Iterations = iterations;
        return this;
    }
}