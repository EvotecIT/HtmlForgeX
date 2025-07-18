using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Represents comprehensive configuration options for an edge in VisNetwork.
/// </summary>
public class VisNetworkEdgeOptions {
    [JsonPropertyName("id")]
    public object? Id { get; set; }

    [JsonPropertyName("from")]
    public object? From { get; set; }

    [JsonPropertyName("to")]
    public object? To { get; set; }

    [JsonPropertyName("label")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Label { get; set; }

    [JsonPropertyName("title")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; set; }

    [JsonPropertyName("value")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Value { get; set; }

    [JsonPropertyName("length")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Length { get; set; }

    [JsonPropertyName("width")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Width { get; set; }

    [JsonPropertyName("widthConstraint")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? WidthConstraint { get; set; }

    [JsonPropertyName("selectionWidth")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? SelectionWidth { get; set; }

    [JsonPropertyName("arrows")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Arrows { get; set; }

    [JsonPropertyName("arrowStrikethrough")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ArrowStrikethrough { get; set; }

    [JsonPropertyName("chosen")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Chosen { get; set; }

    [JsonPropertyName("color")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Color { get; set; }

    [JsonPropertyName("dashes")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Dashes { get; set; }

    [JsonPropertyName("font")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkFontOptions? Font { get; set; }

    [JsonPropertyName("hidden")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Hidden { get; set; }

    [JsonPropertyName("hoverWidth")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? HoverWidth { get; set; }

    [JsonPropertyName("labelHighlightBold")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? LabelHighlightBold { get; set; }

    [JsonPropertyName("physics")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Physics { get; set; }

    [JsonPropertyName("scaling")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkScalingOptions? Scaling { get; set; }

    [JsonPropertyName("selfReferenceSize")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? SelfReferenceSize { get; set; }

    [JsonPropertyName("selfReference")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkSelfReferenceOptions? SelfReference { get; set; }

    [JsonPropertyName("shadow")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Shadow { get; set; }

    [JsonPropertyName("smooth")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Smooth { get; set; }

    [JsonPropertyName("endPointOffset")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkEndPointOffset? EndPointOffset { get; set; }

    // Fluent API Methods

    public VisNetworkEdgeOptions WithId(object id) {
        Id = id;
        return this;
    }

    public VisNetworkEdgeOptions WithConnection(object from, object to) {
        From = from;
        To = to;
        return this;
    }

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

    public VisNetworkEdgeOptions WithTitle(string title) {
        Title = title;
        return this;
    }

    public VisNetworkEdgeOptions WithValue(double value) {
        Value = value;
        return this;
    }

    public VisNetworkEdgeOptions WithLength(double length) {
        Length = length;
        return this;
    }

    public VisNetworkEdgeOptions WithWidth(double width, double? selectionWidth = null, double? hoverWidth = null) {
        Width = width;
        if (selectionWidth.HasValue) SelectionWidth = selectionWidth.Value;
        if (hoverWidth.HasValue) HoverWidth = hoverWidth.Value;
        return this;
    }

    public VisNetworkEdgeOptions WithWidthConstraint(double? maximum = null) {
        if (maximum.HasValue) {
            WidthConstraint = new { maximum = maximum.Value };
        }
        return this;
    }

    public VisNetworkEdgeOptions WithArrows(VisNetworkArrowOptions arrows) {
        Arrows = arrows;
        return this;
    }

    public VisNetworkEdgeOptions WithArrows(Action<VisNetworkArrowOptions> configure) {
        if (Arrows is not VisNetworkArrowOptions arrowOptions) {
            arrowOptions = new VisNetworkArrowOptions();
            Arrows = arrowOptions;
        }
        configure(arrowOptions);
        return this;
    }

    public VisNetworkEdgeOptions WithArrowStrikethrough(bool strikethrough = true) {
        ArrowStrikethrough = strikethrough;
        return this;
    }

    public VisNetworkEdgeOptions WithChosen(bool enabled = true) {
        Chosen = enabled;
        return this;
    }

    public VisNetworkEdgeOptions WithChosen(VisNetworkChosenEdgeOptions chosenOptions) {
        Chosen = chosenOptions;
        return this;
    }

    public VisNetworkEdgeOptions WithColor(RGBColor color) {
        Color = color.ToHex();
        return this;
    }

    public VisNetworkEdgeOptions WithColor(string color) {
        Color = color;
        return this;
    }

    public VisNetworkEdgeOptions WithColor(VisNetworkEdgeColorOptions colorOptions) {
        Color = colorOptions;
        return this;
    }
    
    public VisNetworkEdgeOptions WithColor(Action<VisNetworkEdgeColorOptions> configure) {
        if (Color is not VisNetworkEdgeColorOptions colorOptions) {
            colorOptions = new VisNetworkEdgeColorOptions();
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

    public VisNetworkEdgeOptions WithFont(Action<VisNetworkFontOptions> configure) {
        Font ??= new VisNetworkFontOptions();
        configure(Font);
        return this;
    }

    public VisNetworkEdgeOptions WithHidden(bool hidden = true) {
        Hidden = hidden;
        return this;
    }

    public VisNetworkEdgeOptions WithLabelHighlightBold(bool highlightBold = true) {
        LabelHighlightBold = highlightBold;
        return this;
    }

    public VisNetworkEdgeOptions WithPhysics(bool physics = true) {
        Physics = physics;
        return this;
    }

    public VisNetworkEdgeOptions WithScaling(Action<VisNetworkScalingOptions> configure) {
        Scaling ??= new VisNetworkScalingOptions();
        configure(Scaling);
        return this;
    }

    public VisNetworkEdgeOptions WithSelfReferenceSize(double size) {
        SelfReferenceSize = size;
        return this;
    }

    public VisNetworkEdgeOptions WithSelfReference(Action<VisNetworkSelfReferenceOptions> configure) {
        SelfReference ??= new VisNetworkSelfReferenceOptions();
        configure(SelfReference);
        return this;
    }

    public VisNetworkEdgeOptions WithShadow(bool enabled = true) {
        Shadow = enabled;
        return this;
    }

    public VisNetworkEdgeOptions WithShadow(VisNetworkShadowOptions shadowOptions) {
        Shadow = shadowOptions;
        return this;
    }

    public VisNetworkEdgeOptions WithSmooth(bool enabled = true) {
        Smooth = enabled;
        return this;
    }

    public VisNetworkEdgeOptions WithSmooth(VisNetworkSmoothOptions smoothOptions) {
        Smooth = smoothOptions;
        return this;
    }

    public VisNetworkEdgeOptions WithSmooth(Action<VisNetworkSmoothOptions> configure) {
        if (Smooth is not VisNetworkSmoothOptions smoothOptions) {
            smoothOptions = new VisNetworkSmoothOptions();
            Smooth = smoothOptions;
        }
        configure(smoothOptions);
        return this;
    }

    public VisNetworkEdgeOptions WithEndPointOffset(Action<VisNetworkEndPointOffset> configure) {
        EndPointOffset ??= new VisNetworkEndPointOffset();
        configure(EndPointOffset);
        return this;
    }
}

/// <summary>
/// Arrow configuration options for edges.
/// </summary>
public class VisNetworkArrowOptions {
    [JsonPropertyName("to")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? To { get; set; }

    [JsonPropertyName("from")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? From { get; set; }

    [JsonPropertyName("middle")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Middle { get; set; }

    public VisNetworkArrowOptions WithTo(bool enabled = true) {
        To = enabled;
        return this;
    }

    public VisNetworkArrowOptions WithTo(VisNetworkArrowTypeOptions options) {
        To = options;
        return this;
    }
    
    public VisNetworkArrowOptions WithTo(Action<VisNetworkArrowTypeOptions> configure) {
        var options = new VisNetworkArrowTypeOptions();
        configure(options);
        To = options;
        return this;
    }

    public VisNetworkArrowOptions WithFrom(bool enabled = true) {
        From = enabled;
        return this;
    }

    public VisNetworkArrowOptions WithFrom(VisNetworkArrowTypeOptions options) {
        From = options;
        return this;
    }
    
    public VisNetworkArrowOptions WithFrom(Action<VisNetworkArrowTypeOptions> configure) {
        var options = new VisNetworkArrowTypeOptions();
        configure(options);
        From = options;
        return this;
    }

    public VisNetworkArrowOptions WithMiddle(bool enabled = true) {
        Middle = enabled;
        return this;
    }

    public VisNetworkArrowOptions WithMiddle(VisNetworkArrowTypeOptions options) {
        Middle = options;
        return this;
    }
    
    public VisNetworkArrowOptions WithMiddle(Action<VisNetworkArrowTypeOptions> configure) {
        var options = new VisNetworkArrowTypeOptions();
        configure(options);
        Middle = options;
        return this;
    }
}

/// <summary>
/// Arrow type configuration.
/// </summary>
public class VisNetworkArrowTypeOptions {
    [JsonPropertyName("enabled")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Enabled { get; set; }

    [JsonPropertyName("imageHeight")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? ImageHeight { get; set; }

    [JsonPropertyName("imageWidth")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? ImageWidth { get; set; }

    [JsonPropertyName("scaleFactor")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? ScaleFactor { get; set; }

    [JsonPropertyName("src")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Src { get; set; }

    [JsonPropertyName("type")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkArrowType? Type { get; set; }

    public VisNetworkArrowTypeOptions WithEnabled(bool enabled = true) {
        Enabled = enabled;
        return this;
    }

    public VisNetworkArrowTypeOptions WithType(VisNetworkArrowType type) {
        Type = type;
        return this;
    }

    public VisNetworkArrowTypeOptions WithScaleFactor(double scaleFactor) {
        ScaleFactor = scaleFactor;
        return this;
    }

    public VisNetworkArrowTypeOptions WithImage(string src, double? width = null, double? height = null) {
        Type = VisNetworkArrowType.Image;
        Src = src;
        if (width.HasValue) ImageWidth = width.Value;
        if (height.HasValue) ImageHeight = height.Value;
        return this;
    }
}

/// <summary>
/// Edge color configuration options.
/// </summary>
public class VisNetworkEdgeColorOptions {
    [JsonPropertyName("color")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Color { get; set; }

    [JsonPropertyName("highlight")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Highlight { get; set; }

    [JsonPropertyName("hover")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Hover { get; set; }

    [JsonPropertyName("inherit")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Inherit { get; set; }

    [JsonPropertyName("opacity")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Opacity { get; set; }

    public VisNetworkEdgeColorOptions WithColor(RGBColor color) {
        Color = color.ToHex();
        return this;
    }
    
    public VisNetworkEdgeColorOptions WithColor(string color) {
        Color = color;
        return this;
    }

    public VisNetworkEdgeColorOptions WithHighlight(RGBColor color) {
        Highlight = color.ToHex();
        return this;
    }
    
    public VisNetworkEdgeColorOptions WithHighlight(string color) {
        Highlight = color;
        return this;
    }

    public VisNetworkEdgeColorOptions WithHover(RGBColor color) {
        Hover = color.ToHex();
        return this;
    }
    
    public VisNetworkEdgeColorOptions WithHover(string color) {
        Hover = color;
        return this;
    }

    public VisNetworkEdgeColorOptions WithInherit(VisNetworkColorInherit inherit) {
        Inherit = inherit;
        return this;
    }
    
    public VisNetworkEdgeColorOptions WithInherit(string from) {
        Inherit = from;
        return this;
    }

    public VisNetworkEdgeColorOptions WithInherit(bool enabled) {
        Inherit = enabled;
        return this;
    }

    public VisNetworkEdgeColorOptions WithOpacity(double opacity) {
        Opacity = opacity;
        return this;
    }
}

/// <summary>
/// Chosen edge configuration options.
/// </summary>
public class VisNetworkChosenEdgeOptions {
    [JsonPropertyName("edge")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Edge { get; set; }

    [JsonPropertyName("label")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Label { get; set; }

    public VisNetworkChosenEdgeOptions WithEdge(bool enabled = true) {
        Edge = enabled;
        return this;
    }

    public VisNetworkChosenEdgeOptions WithLabel(bool enabled = true) {
        Label = enabled;
        return this;
    }
}

/// <summary>
/// Self reference configuration for edges that connect a node to itself.
/// </summary>
public class VisNetworkSelfReferenceOptions {
    [JsonPropertyName("size")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Size { get; set; }

    [JsonPropertyName("angle")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Angle { get; set; }

    [JsonPropertyName("renderBehindTheNode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? RenderBehindTheNode { get; set; }

    public VisNetworkSelfReferenceOptions WithSize(double size) {
        Size = size;
        return this;
    }

    public VisNetworkSelfReferenceOptions WithAngle(double angle) {
        Angle = angle;
        return this;
    }

    public VisNetworkSelfReferenceOptions WithRenderBehindTheNode(bool renderBehind = true) {
        RenderBehindTheNode = renderBehind;
        return this;
    }
}

/// <summary>
/// Smooth curve configuration for edges.
/// </summary>
public class VisNetworkSmoothOptions {
    [JsonPropertyName("enabled")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Enabled { get; set; }

    [JsonPropertyName("type")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkSmoothType? Type { get; set; }

    [JsonPropertyName("forceDirection")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? ForceDirection { get; set; }

    [JsonPropertyName("roundness")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Roundness { get; set; }

    public VisNetworkSmoothOptions WithEnabled(bool enabled = true) {
        Enabled = enabled;
        return this;
    }

    public VisNetworkSmoothOptions WithType(VisNetworkSmoothType type) {
        Type = type;
        return this;
    }

    public VisNetworkSmoothOptions WithForceDirection(VisNetworkForceDirection direction) {
        ForceDirection = direction;
        return this;
    }
    
    public VisNetworkSmoothOptions WithForceDirection(string direction) {
        // For backward compatibility
        ForceDirection = direction;
        return this;
    }

    public VisNetworkSmoothOptions WithForceDirection(bool enabled) {
        ForceDirection = enabled;
        return this;
    }

    public VisNetworkSmoothOptions WithRoundness(double roundness) {
        Roundness = roundness;
        return this;
    }
}

/// <summary>
/// End point offset configuration for edges.
/// </summary>
public class VisNetworkEndPointOffset {
    [JsonPropertyName("from")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? From { get; set; }

    [JsonPropertyName("to")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? To { get; set; }

    public VisNetworkEndPointOffset WithFrom(double offset) {
        From = offset;
        return this;
    }

    public VisNetworkEndPointOffset WithTo(double offset) {
        To = offset;
        return this;
    }
}