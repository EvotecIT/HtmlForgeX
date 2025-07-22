namespace HtmlForgeX;

/// <summary>
/// Arrow type configuration.
/// </summary>
public class VisNetworkArrowTypeOptions {
    /// <summary>Gets or sets the enabled.</summary>
    [JsonPropertyName("enabled")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Enabled { get; set; }

    /// <summary>Gets or sets the image height.</summary>
    [JsonPropertyName("imageHeight")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? ImageHeight { get; set; }

    /// <summary>Gets or sets the image width.</summary>
    [JsonPropertyName("imageWidth")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? ImageWidth { get; set; }

    /// <summary>Gets or sets the scale factor.</summary>
    [JsonPropertyName("scaleFactor")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? ScaleFactor { get; set; }

    /// <summary>Gets or sets the src.</summary>
    [JsonPropertyName("src")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Src { get; set; }

    /// <summary>Gets or sets the type.</summary>
    [JsonPropertyName("type")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkArrowType? Type { get; set; }

    /// <summary>Configures the enabled.</summary>
    public VisNetworkArrowTypeOptions WithEnabled(bool enabled = true) {
        Enabled = enabled;
        return this;
    }

    /// <summary>Configures the type.</summary>
    public VisNetworkArrowTypeOptions WithType(VisNetworkArrowType type) {
        Type = type;
        return this;
    }

    /// <summary>Configures the scale factor.</summary>
    public VisNetworkArrowTypeOptions WithScaleFactor(double scaleFactor) {
        ScaleFactor = scaleFactor;
        return this;
    }

    /// <summary>Configures the image.</summary>
    public VisNetworkArrowTypeOptions WithImage(string src, double? width = null, double? height = null) {
        Type = VisNetworkArrowType.Image;
        Src = src;
        if (width.HasValue) ImageWidth = width.Value;
        if (height.HasValue) ImageHeight = height.Value;
        return this;
    }
}