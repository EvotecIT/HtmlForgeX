using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Represents comprehensive configuration options for an edge in VisNetwork.
/// </summary>
public class VisNetworkEdgeOptions {
    /// <summary>Gets or sets the id.</summary>
    [JsonPropertyName("id")]
    public object? Id { get; set; }

    /// <summary>Gets or sets the from.</summary>
    [JsonPropertyName("from")]
    public object? From { get; set; }

    /// <summary>Gets or sets the to.</summary>
    [JsonPropertyName("to")]
    public object? To { get; set; }

    /// <summary>Gets or sets the label.</summary>
    [JsonPropertyName("label")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Label { get; set; }

    /// <summary>Gets or sets the title.</summary>
    [JsonPropertyName("title")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; set; }

    /// <summary>Gets or sets the value.</summary>
    [JsonPropertyName("value")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Value { get; set; }

    /// <summary>Gets or sets the length.</summary>
    [JsonPropertyName("length")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Length { get; set; }

    /// <summary>Gets or sets the width.</summary>
    [JsonPropertyName("width")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Width { get; set; }

    /// <summary>Gets or sets the width constraint.</summary>
    [JsonPropertyName("widthConstraint")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? WidthConstraint { get; set; }

    /// <summary>Gets or sets the selection width.</summary>
    [JsonPropertyName("selectionWidth")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? SelectionWidth { get; set; }

    /// <summary>Gets or sets the arrows.</summary>
    [JsonPropertyName("arrows")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Arrows { get; set; }

    /// <summary>Gets or sets the arrow strikethrough.</summary>
    [JsonPropertyName("arrowStrikethrough")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ArrowStrikethrough { get; set; }

    /// <summary>Gets or sets the chosen.</summary>
    [JsonPropertyName("chosen")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Chosen { get; set; }

    /// <summary>Gets or sets the color.</summary>
    [JsonPropertyName("color")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Color { get; set; }

    /// <summary>Gets or sets the dashes.</summary>
    [JsonPropertyName("dashes")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Dashes { get; set; }

    /// <summary>Gets or sets the font.</summary>
    [JsonPropertyName("font")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkFontOptions? Font { get; set; }

    /// <summary>Gets or sets the hidden.</summary>
    [JsonPropertyName("hidden")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Hidden { get; set; }

    /// <summary>Gets or sets the hover width.</summary>
    [JsonPropertyName("hoverWidth")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? HoverWidth { get; set; }

    /// <summary>Gets or sets the label highlight bold.</summary>
    [JsonPropertyName("labelHighlightBold")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? LabelHighlightBold { get; set; }

    /// <summary>Gets or sets the physics.</summary>
    [JsonPropertyName("physics")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Physics { get; set; }

    /// <summary>Gets or sets the scaling.</summary>
    [JsonPropertyName("scaling")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkScalingOptions? Scaling { get; set; }

    /// <summary>Gets or sets the self reference size.</summary>
    [JsonPropertyName("selfReferenceSize")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? SelfReferenceSize { get; set; }

    /// <summary>Gets or sets the self reference.</summary>
    [JsonPropertyName("selfReference")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkSelfReferenceOptions? SelfReference { get; set; }

    /// <summary>Gets or sets the shadow.</summary>
    [JsonPropertyName("shadow")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Shadow { get; set; }

    /// <summary>Gets or sets the smooth.</summary>
    [JsonPropertyName("smooth")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Smooth { get; set; }

    /// <summary>Gets or sets the end point offset.</summary>
    [JsonPropertyName("endPointOffset")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkEndPointOffset? EndPointOffset { get; set; }

    // Fluent API Methods

    /// <summary>Configures the id.</summary>
    public VisNetworkEdgeOptions WithId(object id) {
        Id = id;
        return this;
    }

    /// <summary>Configures the connection.</summary>
    public VisNetworkEdgeOptions WithConnection(object from, object to) {
        From = from;
        To = to;
        return this;
    }

    /// <summary>Configures the label.</summary>
    public VisNetworkEdgeOptions WithLabel(string label) {
        Label = label;
        return this;
    }

    /// <summary>
    /// Sets an HTML-formatted label with multi-line support. Automatically enables HTML multi-line mode.
    /// </summary>
    /// <param name="htmlLabel">The HTML-formatted label content</param>
    /// <returns>The edge options for method chaining</returns>
    public VisNetworkEdgeOptions WithHtmlLabel(string htmlLabel) {
        Label = htmlLabel;
        // Ensure font options exist and set multi to HTML
        Font ??= new VisNetworkFontOptions();
        Font.Multi = VisNetworkMulti.Html;
        return this;
    }

    /// <summary>
    /// Sets a Markdown-formatted label with multi-line support. Automatically enables Markdown multi-line mode.
    /// </summary>
    /// <param name="markdownLabel">The Markdown-formatted label content</param>
    /// <returns>The edge options for method chaining</returns>
    public VisNetworkEdgeOptions WithMarkdownLabel(string markdownLabel) {
        Label = markdownLabel;
        // Ensure font options exist and set multi to Markdown
        Font ??= new VisNetworkFontOptions();
        Font.Multi = VisNetworkMulti.Markdown;
        return this;
    }

    /// <summary>Configures the title.</summary>
    public VisNetworkEdgeOptions WithTitle(string title) {
        Title = title;
        return this;
    }

    /// <summary>Configures the value.</summary>
    public VisNetworkEdgeOptions WithValue(double value) {
        Value = value;
        return this;
    }

    /// <summary>Configures the length.</summary>
    public VisNetworkEdgeOptions WithLength(double length) {
        Length = length;
        return this;
    }

    /// <summary>Configures the width.</summary>
    public VisNetworkEdgeOptions WithWidth(double width, double? selectionWidth = null, double? hoverWidth = null) {
        Width = width;
        if (selectionWidth.HasValue) SelectionWidth = selectionWidth.Value;
        if (hoverWidth.HasValue) HoverWidth = hoverWidth.Value;
        return this;
    }

    /// <summary>Configures the width constraint.</summary>
    public VisNetworkEdgeOptions WithWidthConstraint(double? maximum = null) {
        if (maximum.HasValue) {
            WidthConstraint = new { maximum = maximum.Value };
        }
        return this;
    }

    /// <summary>Configures the arrows.</summary>
    public VisNetworkEdgeOptions WithArrows(VisNetworkArrowOptions arrows) {
        Arrows = arrows;
        return this;
    }

    /// <summary>Configures the arrows.</summary>
    public VisNetworkEdgeOptions WithArrows(Action<VisNetworkArrowOptions> configure) {
        if (Arrows is not VisNetworkArrowOptions arrowOptions) {
            arrowOptions = new VisNetworkArrowOptions();
            Arrows = arrowOptions;
        }
        configure(arrowOptions);
        return this;
    }

    /// <summary>Configures the arrow strikethrough.</summary>
    public VisNetworkEdgeOptions WithArrowStrikethrough(bool strikethrough = true) {
        ArrowStrikethrough = strikethrough;
        return this;
    }

    /// <summary>Configures the chosen.</summary>
    public VisNetworkEdgeOptions WithChosen(bool enabled = true) {
        Chosen = enabled;
        return this;
    }

    /// <summary>Configures the chosen.</summary>
    public VisNetworkEdgeOptions WithChosen(VisNetworkChosenEdgeOptions chosenOptions) {
        Chosen = chosenOptions;
        return this;
    }

    /// <summary>Configures the color.</summary>
    public VisNetworkEdgeOptions WithColor(RGBColor color) {
        Color = color.ToHex();
        return this;
    }

    /// <summary>Configures the color.</summary>
    public VisNetworkEdgeOptions WithColor(string color) {
        Color = color;
        return this;
    }


    /// <summary>Configures the color using advanced color options.</summary>
    public VisNetworkEdgeOptions WithColor(VisNetworkAdvancedColorOptions colorOptions) {
        Color = colorOptions;
        return this;
    }

    /// <summary>Configures the color using advanced color options.</summary>
    public VisNetworkEdgeOptions WithColor(Action<VisNetworkAdvancedColorOptions> configure) {
        if (Color is not VisNetworkAdvancedColorOptions colorOptions) {
            colorOptions = new VisNetworkAdvancedColorOptions();
            Color = colorOptions;
        }
        configure(colorOptions);
        return this;
    }

    /// <summary>
    /// Sets a gradient color for the edge that transitions from one color to another.
    /// The gradient follows the edge direction from source to target.
    /// </summary>
    /// <param name="fromColor">The color at the start of the edge (source node)</param>
    /// <param name="toColor">The color at the end of the edge (target node)</param>
    /// <returns>The edge options for method chaining</returns>
    public VisNetworkEdgeOptions WithGradientColor(RGBColor fromColor, RGBColor toColor) {
        // VisNetwork expects gradient as an object with specific structure
        Color = new {
            from = fromColor.ToHex(),
            to = toColor.ToHex()
        };
        return this;
    }

    /// <summary>
    /// Sets a gradient color for the edge using color strings.
    /// </summary>
    /// <param name="fromColor">The color at the start of the edge (source node)</param>
    /// <param name="toColor">The color at the end of the edge (target node)</param>
    /// <returns>The edge options for method chaining</returns>
    public VisNetworkEdgeOptions WithGradientColor(string fromColor, string toColor) {
        Color = new {
            from = fromColor,
            to = toColor
        };
        return this;
    }

    /// <summary>
    /// Enables or disables dashed lines for the edge.
    /// </summary>
    /// <param name="enabled">True to enable dashed lines, false for solid lines</param>
    /// <returns>The edge options for method chaining</returns>
    public VisNetworkEdgeOptions WithDashes(bool enabled = true) {
        Dashes = enabled;
        return this;
    }

    /// <summary>
    /// Sets a custom dash pattern for the edge line.
    /// </summary>
    /// <param name="pattern">An array of integers representing dash and gap lengths</param>
    /// <returns>The edge options for method chaining</returns>
    public VisNetworkEdgeOptions WithDashes(params int[] pattern) {
        Dashes = pattern;
        return this;
    }

    /// <summary>
    /// Sets a predefined dash pattern for the edge line.
    /// </summary>
    /// <param name="pattern">The dash pattern to use</param>
    /// <returns>The edge options for method chaining</returns>
    public VisNetworkEdgeOptions WithDashes(VisNetworkDashPattern pattern) {
        Dashes = pattern == VisNetworkDashPattern.Solid ? false : (object)pattern.ToArray();
        return this;
    }

    /// <summary>Configures the font.</summary>
    public VisNetworkEdgeOptions WithFont(Action<VisNetworkFontOptions> configure) {
        Font ??= new VisNetworkFontOptions();
        configure(Font);
        return this;
    }

    /// <summary>Configures the hidden.</summary>
    public VisNetworkEdgeOptions WithHidden(bool hidden = true) {
        Hidden = hidden;
        return this;
    }

    /// <summary>Configures the label highlight bold.</summary>
    public VisNetworkEdgeOptions WithLabelHighlightBold(bool highlightBold = true) {
        LabelHighlightBold = highlightBold;
        return this;
    }

    /// <summary>Configures the physics.</summary>
    public VisNetworkEdgeOptions WithPhysics(bool physics = true) {
        Physics = physics;
        return this;
    }

    /// <summary>Configures the scaling.</summary>
    public VisNetworkEdgeOptions WithScaling(Action<VisNetworkScalingOptions> configure) {
        Scaling ??= new VisNetworkScalingOptions();
        configure(Scaling);
        return this;
    }

    /// <summary>Configures the self reference size.</summary>
    public VisNetworkEdgeOptions WithSelfReferenceSize(double size) {
        SelfReferenceSize = size;
        return this;
    }

    /// <summary>Configures the self reference.</summary>
    public VisNetworkEdgeOptions WithSelfReference(Action<VisNetworkSelfReferenceOptions> configure) {
        SelfReference ??= new VisNetworkSelfReferenceOptions();
        configure(SelfReference);
        return this;
    }

    /// <summary>Configures the shadow.</summary>
    public VisNetworkEdgeOptions WithShadow(bool enabled = true) {
        Shadow = enabled;
        return this;
    }

    /// <summary>Configures the shadow.</summary>
    public VisNetworkEdgeOptions WithShadow(VisNetworkShadowOptions shadowOptions) {
        Shadow = shadowOptions;
        return this;
    }

    /// <summary>Configures the smooth.</summary>
    public VisNetworkEdgeOptions WithSmooth(bool enabled = true) {
        Smooth = enabled;
        return this;
    }

    /// <summary>Configures the smooth.</summary>
    public VisNetworkEdgeOptions WithSmooth(VisNetworkSmoothOptions smoothOptions) {
        Smooth = smoothOptions;
        return this;
    }

    /// <summary>Configures the smooth.</summary>
    public VisNetworkEdgeOptions WithSmooth(Action<VisNetworkSmoothOptions> configure) {
        if (Smooth is not VisNetworkSmoothOptions smoothOptions) {
            smoothOptions = new VisNetworkSmoothOptions();
            Smooth = smoothOptions;
        }
        configure(smoothOptions);
        return this;
    }

    /// <summary>Configures the end point offset.</summary>
    public VisNetworkEdgeOptions WithEndPointOffset(Action<VisNetworkEndPointOffset> configure) {
        EndPointOffset ??= new VisNetworkEndPointOffset();
        configure(EndPointOffset);
        return this;
    }
}