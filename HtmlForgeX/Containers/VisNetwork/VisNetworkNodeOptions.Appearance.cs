using System.Text.Json.Serialization;

namespace HtmlForgeX;

public partial class VisNetworkNodeOptions {
    /// <summary>
    /// Gets or sets the visual shape of the node.
    /// </summary>
    [JsonPropertyName("shape")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkNodeShape? Shape { get; set; }

    /// <summary>
    /// Gets or sets the size of the node.
    /// </summary>
    [JsonPropertyName("size")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Size { get; set; }

    /// <summary>
    /// Gets or sets the mass used by the physics engine.
    /// </summary>
    [JsonPropertyName("mass")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Mass { get; set; }

    /// <summary>
    /// Gets or sets the value used for scaling.
    /// </summary>
    [JsonPropertyName("value")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Value { get; set; }

    /// <summary>
    /// Gets or sets scaling options for the node.
    /// </summary>
    [JsonPropertyName("scaling")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkScalingOptions? Scaling { get; set; }

    /// <summary>
    /// Gets or sets the color configuration of the node.
    /// </summary>
    [JsonPropertyName("color")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Color { get; set; }

    /// <summary>
    /// Gets or sets the opacity of the node.
    /// </summary>
    [JsonPropertyName("opacity")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Opacity { get; set; }

    /// <summary>
    /// Gets or sets font options for the label.
    /// </summary>
    [JsonPropertyName("font")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkFontOptions? Font { get; set; }

    /// <summary>
    /// Gets or sets the image or image options for image nodes.
    /// </summary>
    [JsonPropertyName("image")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Image { get; set; }

    /// <summary>
    /// Gets or sets the fallback image URL when the main image fails to load.
    /// Used when shape is 'image' or 'circularImage'.
    /// </summary>
    [JsonPropertyName("brokenImage")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? BrokenImage { get; set; }

    /// <summary>
    /// Gets or sets the padding around the image.
    /// Can be a number for uniform padding or an object with top, right, bottom, left properties.
    /// Used when shape is 'image' or 'circularImage'.
    /// </summary>
    [JsonPropertyName("imagePadding")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? ImagePadding { get; set; }

    /// <summary>
    /// Gets or sets icon options when using icon shaped nodes.
    /// </summary>
    [JsonPropertyName("icon")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkIconOptions? Icon { get; set; }

    /// <summary>
    /// Gets or sets additional shape properties.
    /// </summary>
    [JsonPropertyName("shapeProperties")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkShapeProperties? ShapeProperties { get; set; }

    /// <summary>
    /// Gets or sets the border width of the node.
    /// </summary>
    [JsonPropertyName("borderWidth")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? BorderWidth { get; set; }

    /// <summary>
    /// Gets or sets the border width when the node is selected.
    /// </summary>
    [JsonPropertyName("borderWidthSelected")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? BorderWidthSelected { get; set; }

    /// <summary>
    /// Gets or sets chosen options for node selection.
    /// </summary>
    [JsonPropertyName("chosen")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Chosen { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether label text is bold when highlighted.
    /// </summary>
    [JsonPropertyName("labelHighlightBold")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? LabelHighlightBold { get; set; }

    /// <summary>
    /// Gets or sets shadow options for the node.
    /// </summary>
    [JsonPropertyName("shadow")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Shadow { get; set; }

    /// <summary>
    /// Gets or sets margin around the node content.
    /// </summary>
    [JsonPropertyName("margin")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Margin { get; set; }

    /// <summary>
    /// Gets or sets width constraints for the node.
    /// </summary>
    [JsonPropertyName("widthConstraint")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? WidthConstraint { get; set; }

    /// <summary>
    /// Gets or sets height constraints for the node.
    /// </summary>
    [JsonPropertyName("heightConstraint")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? HeightConstraint { get; set; }

    /// <summary>
    /// Gets or sets the name of the custom canvas renderer function.
    /// </summary>
    [JsonPropertyName("ctxRenderer")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? CtxRenderer { get; set; }
}