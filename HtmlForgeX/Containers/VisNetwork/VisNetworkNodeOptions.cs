using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Represents comprehensive configuration options for a node in VisNetwork.
/// </summary>
public class VisNetworkNodeOptions {
    [JsonPropertyName("id")]
    public object? Id { get; set; }

    [JsonPropertyName("label")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Label { get; set; }

    [JsonPropertyName("title")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; set; }

    [JsonPropertyName("group")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Group { get; set; }

    [JsonPropertyName("x")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? X { get; set; }

    [JsonPropertyName("y")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Y { get; set; }

    [JsonPropertyName("level")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Level { get; set; }

    [JsonPropertyName("hidden")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Hidden { get; set; }

    [JsonPropertyName("physics")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Physics { get; set; }

    [JsonPropertyName("fixed")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Fixed { get; set; }

    [JsonPropertyName("shape")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkNodeShape? Shape { get; set; }

    [JsonPropertyName("size")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Size { get; set; }

    [JsonPropertyName("mass")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Mass { get; set; }

    [JsonPropertyName("value")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Value { get; set; }

    [JsonPropertyName("scaling")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkScalingOptions? Scaling { get; set; }

    [JsonPropertyName("color")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Color { get; set; }

    [JsonPropertyName("opacity")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Opacity { get; set; }

    [JsonPropertyName("font")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkFontOptions? Font { get; set; }

    [JsonPropertyName("image")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Image { get; set; }

    [JsonPropertyName("icon")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkIconOptions? Icon { get; set; }

    [JsonPropertyName("shapeProperties")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkShapeProperties? ShapeProperties { get; set; }

    [JsonPropertyName("borderWidth")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? BorderWidth { get; set; }

    [JsonPropertyName("borderWidthSelected")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? BorderWidthSelected { get; set; }

    [JsonPropertyName("chosen")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Chosen { get; set; }

    [JsonPropertyName("labelHighlightBold")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? LabelHighlightBold { get; set; }

    [JsonPropertyName("shadow")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Shadow { get; set; }

    [JsonPropertyName("margin")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Margin { get; set; }

    [JsonPropertyName("widthConstraint")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? WidthConstraint { get; set; }

    [JsonPropertyName("heightConstraint")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? HeightConstraint { get; set; }

    // Fluent API Methods

    public VisNetworkNodeOptions WithId(object id) {
        Id = id;
        return this;
    }

    public VisNetworkNodeOptions WithLabel(string label) {
        Label = label;
        return this;
    }

    public VisNetworkNodeOptions WithTitle(string title) {
        Title = title;
        return this;
    }

    public VisNetworkNodeOptions WithGroup(string group) {
        Group = group;
        return this;
    }

    public VisNetworkNodeOptions WithPosition(double x, double y) {
        X = x;
        Y = y;
        return this;
    }

    public VisNetworkNodeOptions WithLevel(int level) {
        Level = level;
        return this;
    }

    public VisNetworkNodeOptions WithHidden(bool hidden = true) {
        Hidden = hidden;
        return this;
    }

    public VisNetworkNodeOptions WithPhysics(bool physics = true) {
        Physics = physics;
        return this;
    }

    public VisNetworkNodeOptions WithFixed(bool fixedX, bool fixedY) {
        Fixed = new { x = fixedX, y = fixedY };
        return this;
    }

    public VisNetworkNodeOptions WithShape(VisNetworkNodeShape shape) {
        Shape = shape;
        return this;
    }

    public VisNetworkNodeOptions WithSize(double size) {
        Size = size;
        return this;
    }

    public VisNetworkNodeOptions WithMass(double mass) {
        Mass = mass;
        return this;
    }

    public VisNetworkNodeOptions WithValue(double value) {
        Value = value;
        return this;
    }

    public VisNetworkNodeOptions WithScaling(Action<VisNetworkScalingOptions> configure) {
        Scaling ??= new VisNetworkScalingOptions();
        configure(Scaling);
        return this;
    }

    public VisNetworkNodeOptions WithColor(RGBColor color) {
        Color = color.ToHex();
        return this;
    }

    public VisNetworkNodeOptions WithColor(VisNetworkColorOptions colorOptions) {
        Color = colorOptions;
        return this;
    }

    public VisNetworkNodeOptions WithOpacity(double opacity) {
        Opacity = opacity;
        return this;
    }

    public VisNetworkNodeOptions WithFont(Action<VisNetworkFontOptions> configure) {
        Font ??= new VisNetworkFontOptions();
        configure(Font);
        return this;
    }

    public VisNetworkNodeOptions WithImage(string imageUrl) {
        Image = imageUrl;
        if (Shape == null || Shape == VisNetworkNodeShape.Ellipse) {
            Shape = VisNetworkNodeShape.Image;
        }
        return this;
    }

    public VisNetworkNodeOptions WithImageObject(VisNetworkImageOptions imageOptions) {
        Image = imageOptions;
        if (Shape == null || Shape == VisNetworkNodeShape.Ellipse) {
            Shape = VisNetworkNodeShape.Image;
        }
        return this;
    }

    public VisNetworkNodeOptions WithIcon(Action<VisNetworkIconOptions> configure) {
        Icon ??= new VisNetworkIconOptions();
        configure(Icon);
        Shape = VisNetworkNodeShape.Icon;
        return this;
    }

    public VisNetworkNodeOptions WithShapeProperties(Action<VisNetworkShapeProperties> configure) {
        ShapeProperties ??= new VisNetworkShapeProperties();
        configure(ShapeProperties);
        return this;
    }

    public VisNetworkNodeOptions WithBorderWidth(double width, double? selectedWidth = null) {
        BorderWidth = width;
        if (selectedWidth.HasValue) {
            BorderWidthSelected = selectedWidth.Value;
        }
        return this;
    }

    public VisNetworkNodeOptions WithChosen(bool enabled) {
        Chosen = enabled;
        return this;
    }

    public VisNetworkNodeOptions WithChosen(VisNetworkChosenOptions chosenOptions) {
        Chosen = chosenOptions;
        return this;
    }

    public VisNetworkNodeOptions WithLabelHighlightBold(bool highlightBold = true) {
        LabelHighlightBold = highlightBold;
        return this;
    }

    public VisNetworkNodeOptions WithShadow(bool enabled = true) {
        Shadow = enabled;
        return this;
    }

    public VisNetworkNodeOptions WithShadow(VisNetworkShadowOptions shadowOptions) {
        Shadow = shadowOptions;
        return this;
    }

    public VisNetworkNodeOptions WithMargin(double margin) {
        Margin = margin;
        return this;
    }

    public VisNetworkNodeOptions WithMargin(double top, double right, double bottom, double left) {
        Margin = new { top, right, bottom, left };
        return this;
    }

    public VisNetworkNodeOptions WithWidthConstraint(double? minimum = null, double? maximum = null) {
        if (minimum.HasValue || maximum.HasValue) {
            var constraint = new Dictionary<string, double>();
            if (minimum.HasValue) constraint["minimum"] = minimum.Value;
            if (maximum.HasValue) constraint["maximum"] = maximum.Value;
            WidthConstraint = constraint;
        }
        return this;
    }

    public VisNetworkNodeOptions WithHeightConstraint(double? minimum = null, double? maximum = null) {
        if (minimum.HasValue || maximum.HasValue) {
            var constraint = new Dictionary<string, double>();
            if (minimum.HasValue) constraint["minimum"] = minimum.Value;
            if (maximum.HasValue) constraint["maximum"] = maximum.Value;
            HeightConstraint = constraint;
        }
        return this;
    }
}

/// <summary>
/// Color configuration options for nodes.
/// </summary>
public class VisNetworkColorOptions {
    [JsonPropertyName("background")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Background { get; set; }

    [JsonPropertyName("border")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Border { get; set; }

    [JsonPropertyName("highlight")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Highlight { get; set; }

    [JsonPropertyName("hover")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Hover { get; set; }

    public VisNetworkColorOptions WithBackground(RGBColor color) {
        Background = color.ToHex();
        return this;
    }

    public VisNetworkColorOptions WithBorder(RGBColor color) {
        Border = color.ToHex();
        return this;
    }

    public VisNetworkColorOptions WithHighlight(RGBColor background, RGBColor border) {
        Highlight = new { background = background.ToHex(), border = border.ToHex() };
        return this;
    }

    public VisNetworkColorOptions WithHover(RGBColor background, RGBColor border) {
        Hover = new { background = background.ToHex(), border = border.ToHex() };
        return this;
    }
}

/// <summary>
/// Font configuration options.
/// </summary>
public class VisNetworkFontOptions {
    [JsonPropertyName("color")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Color { get; set; }

    [JsonPropertyName("size")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Size { get; set; }

    [JsonPropertyName("face")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Face { get; set; }

    [JsonPropertyName("background")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Background { get; set; }

    [JsonPropertyName("strokeWidth")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? StrokeWidth { get; set; }

    [JsonPropertyName("strokeColor")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? StrokeColor { get; set; }

    [JsonPropertyName("align")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkAlign? Align { get; set; }

    [JsonPropertyName("multi")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkMulti? Multi { get; set; }

    [JsonPropertyName("vadjust")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Vadjust { get; set; }

    [JsonPropertyName("bold")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Bold { get; set; }

    [JsonPropertyName("ital")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Ital { get; set; }

    [JsonPropertyName("boldital")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? BoldItal { get; set; }

    [JsonPropertyName("mono")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Mono { get; set; }

    public VisNetworkFontOptions WithColor(RGBColor color) {
        Color = color.ToHex();
        return this;
    }

    public VisNetworkFontOptions WithSize(int size) {
        Size = size;
        return this;
    }

    public VisNetworkFontOptions WithFace(string face) {
        Face = face;
        return this;
    }

    public VisNetworkFontOptions WithBackground(RGBColor background) {
        Background = background.ToHex();
        return this;
    }

    public VisNetworkFontOptions WithStroke(double width, RGBColor color) {
        StrokeWidth = width;
        StrokeColor = color.ToHex();
        return this;
    }

    public VisNetworkFontOptions WithAlign(VisNetworkAlign align) {
        Align = align;
        return this;
    }

    public VisNetworkFontOptions WithMulti(VisNetworkMulti multi) {
        Multi = multi;
        return this;
    }

    public VisNetworkFontOptions WithVadjust(double vadjust) {
        Vadjust = vadjust;
        return this;
    }
}

/// <summary>
/// Icon configuration for icon-shaped nodes.
/// </summary>
public class VisNetworkIconOptions {
    [JsonPropertyName("face")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Face { get; set; }

    [JsonPropertyName("code")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Code { get; set; }

    [JsonPropertyName("size")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Size { get; set; }

    [JsonPropertyName("color")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Color { get; set; }

    [JsonPropertyName("weight")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Weight { get; set; }

    public VisNetworkIconOptions WithFace(string face) {
        Face = face;
        return this;
    }

    public VisNetworkIconOptions WithCode(string code) {
        Code = code;
        return this;
    }

    public VisNetworkIconOptions WithSize(int size) {
        Size = size;
        return this;
    }

    public VisNetworkIconOptions WithColor(RGBColor color) {
        Color = color.ToHex();
        return this;
    }

    public VisNetworkIconOptions WithWeight(string weight) {
        Weight = weight;
        return this;
    }
}

/// <summary>
/// Shape-specific properties for custom node shapes.
/// </summary>
public class VisNetworkShapeProperties {
    [JsonPropertyName("borderDashes")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? BorderDashes { get; set; }

    [JsonPropertyName("borderRadius")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? BorderRadius { get; set; }

    [JsonPropertyName("interpolation")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Interpolation { get; set; }

    [JsonPropertyName("useImageSize")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? UseImageSize { get; set; }

    [JsonPropertyName("useBorderWithImage")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? UseBorderWithImage { get; set; }

    public VisNetworkShapeProperties WithBorderDashes(bool enabled = true) {
        BorderDashes = enabled;
        return this;
    }

    public VisNetworkShapeProperties WithBorderDashes(params int[] pattern) {
        BorderDashes = pattern;
        return this;
    }

    public VisNetworkShapeProperties WithBorderRadius(double radius) {
        BorderRadius = radius;
        return this;
    }

    public VisNetworkShapeProperties WithInterpolation(bool enabled = true) {
        Interpolation = enabled;
        return this;
    }

    public VisNetworkShapeProperties WithUseImageSize(bool use = true) {
        UseImageSize = use;
        return this;
    }

    public VisNetworkShapeProperties WithUseBorderWithImage(bool use = true) {
        UseBorderWithImage = use;
        return this;
    }
}

/// <summary>
/// Scaling options for nodes.
/// </summary>
public class VisNetworkScalingOptions {
    [JsonPropertyName("min")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Min { get; set; }

    [JsonPropertyName("max")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Max { get; set; }

    [JsonPropertyName("label")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Label { get; set; }

    public VisNetworkScalingOptions WithMin(double min) {
        Min = min;
        return this;
    }

    public VisNetworkScalingOptions WithMax(double max) {
        Max = max;
        return this;
    }

    public VisNetworkScalingOptions WithLabel(bool enabled = true) {
        Label = enabled;
        return this;
    }

    public VisNetworkScalingOptions WithLabel(double min, double max, double? maxVisible = null, bool? drawThreshold = null) {
        var labelOptions = new Dictionary<string, object> {
            ["enabled"] = true,
            ["min"] = min,
            ["max"] = max
        };
        if (maxVisible.HasValue) labelOptions["maxVisible"] = maxVisible.Value;
        if (drawThreshold.HasValue) labelOptions["drawThreshold"] = drawThreshold.Value;
        Label = labelOptions;
        return this;
    }
}

/// <summary>
/// Shadow configuration options.
/// </summary>
public class VisNetworkShadowOptions {
    [JsonPropertyName("enabled")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Enabled { get; set; }

    [JsonPropertyName("color")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Color { get; set; }

    [JsonPropertyName("size")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Size { get; set; }

    [JsonPropertyName("x")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? X { get; set; }

    [JsonPropertyName("y")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Y { get; set; }

    public VisNetworkShadowOptions WithEnabled(bool enabled = true) {
        Enabled = enabled;
        return this;
    }

    public VisNetworkShadowOptions WithColor(RGBColor color) {
        Color = color.ToHex();
        return this;
    }

    public VisNetworkShadowOptions WithSize(double size) {
        Size = size;
        return this;
    }

    public VisNetworkShadowOptions WithOffset(double x, double y) {
        X = x;
        Y = y;
        return this;
    }
}

/// <summary>
/// Chosen (selection/hover) configuration options.
/// </summary>
public class VisNetworkChosenOptions {
    [JsonPropertyName("node")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Node { get; set; }

    [JsonPropertyName("label")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Label { get; set; }

    public VisNetworkChosenOptions WithNode(bool enabled = true) {
        Node = enabled;
        return this;
    }

    public VisNetworkChosenOptions WithNode(Action<VisNetworkChosenNodeOptions> configure) {
        var options = new VisNetworkChosenNodeOptions();
        configure(options);
        Node = options;
        return this;
    }

    public VisNetworkChosenOptions WithLabel(bool enabled = true) {
        Label = enabled;
        return this;
    }
}

/// <summary>
/// Chosen node-specific options.
/// </summary>
public class VisNetworkChosenNodeOptions {
    [JsonPropertyName("color")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Color { get; set; }

    [JsonPropertyName("borderColor")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? BorderColor { get; set; }

    [JsonPropertyName("borderWidth")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? BorderWidth { get; set; }

    [JsonPropertyName("size")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Size { get; set; }

    public VisNetworkChosenNodeOptions WithColor(RGBColor color) {
        Color = color.ToHex();
        return this;
    }

    public VisNetworkChosenNodeOptions WithBorderColor(RGBColor color) {
        BorderColor = color.ToHex();
        return this;
    }

    public VisNetworkChosenNodeOptions WithBorderWidth(double width) {
        BorderWidth = width;
        return this;
    }

    public VisNetworkChosenNodeOptions WithSize(double size) {
        Size = size;
        return this;
    }
}

/// <summary>
/// Image configuration options for image nodes.
/// </summary>
public class VisNetworkImageOptions {
    [JsonPropertyName("unselected")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Unselected { get; set; }

    [JsonPropertyName("selected")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Selected { get; set; }

    public VisNetworkImageOptions WithUnselected(string url) {
        Unselected = url;
        return this;
    }

    public VisNetworkImageOptions WithSelected(string url) {
        Selected = url;
        return this;
    }
}