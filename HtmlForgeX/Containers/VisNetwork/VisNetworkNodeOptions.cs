using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Represents comprehensive configuration options for a node in VisNetwork.
/// </summary>
public partial class VisNetworkNodeOptions {
    /// <summary>
    /// Gets or sets the unique identifier for the node.
    /// </summary>
    [JsonPropertyName("id")]
    public object? Id { get; set; }

    /// <summary>
    /// Gets or sets the label displayed on the node.
    /// </summary>
    [JsonPropertyName("label")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Label { get; set; }

    /// <summary>
    /// Gets or sets the tooltip text for the node.
    /// </summary>
    [JsonPropertyName("title")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; set; }

    /// <summary>
    /// Gets or sets the group this node belongs to.
    /// </summary>
    [JsonPropertyName("group")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Group { get; set; }

    /// <summary>
    /// Gets or sets the initial X position of the node.
    /// </summary>
    [JsonPropertyName("x")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? X { get; set; }

    /// <summary>
    /// Gets or sets the initial Y position of the node.
    /// </summary>
    [JsonPropertyName("y")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Y { get; set; }

    /// <summary>
    /// Gets or sets the hierarchical level of the node.
    /// </summary>
    [JsonPropertyName("level")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Level { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the node is initially hidden.
    /// </summary>
    [JsonPropertyName("hidden")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Hidden { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the node is affected by physics.
    /// </summary>
    [JsonPropertyName("physics")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Physics { get; set; }

    /// <summary>
    /// Gets or sets fixed positioning flags for the node.
    /// </summary>
    [JsonPropertyName("fixed")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Fixed { get; set; }



    // Fluent API Methods

    /// <summary>
    /// Sets the unique identifier for the node.
    /// </summary>
    /// <param name="id">The identifier (can be string, number, or any object)</param>
    /// <returns>The node options for method chaining</returns>
    public VisNetworkNodeOptions WithId(object id) {
        Id = id;
        return this;
    }

    /// <summary>
    /// Sets the plain text label for the node.
    /// </summary>
    /// <param name="label">The label text (use \n for line breaks)</param>
    /// <returns>The node options for method chaining</returns>
    public VisNetworkNodeOptions WithLabel(string label) {
        Label = label;
        return this;
    }
    
    /// <summary>
    /// Sets an HTML-formatted label with multi-line support. Automatically enables HTML multi-line mode.
    /// </summary>
    /// <param name="htmlLabel">The HTML-formatted label content</param>
    /// <returns>The node options for method chaining</returns>
    public VisNetworkNodeOptions WithHtmlLabel(string htmlLabel) {
        Label = htmlLabel;
        // Ensure font options exist and set multi to HTML
        Font ??= new VisNetworkFontOptions();
        Font.Multi = VisNetworkMulti.Html;
        return this;
    }
    
    /// <summary>
    /// Builds an HTML-formatted label using a fluent builder. Automatically enables HTML multi-line mode.
    /// </summary>
    /// <param name="configure">Action to configure the label builder</param>
    /// <returns>The node options for method chaining</returns>
    public VisNetworkNodeOptions WithHtmlLabel(Action<VisNetworkLabelBuilder> configure) {
        var builder = new VisNetworkLabelBuilder();
        configure(builder);
        return WithHtmlLabel(builder.Build());
    }
    
    /// <summary>
    /// Sets a Markdown-formatted label with multi-line support. Automatically enables Markdown multi-line mode.
    /// </summary>
    /// <param name="markdownLabel">The Markdown-formatted label content</param>
    /// <returns>The node options for method chaining</returns>
    public VisNetworkNodeOptions WithMarkdownLabel(string markdownLabel) {
        Label = markdownLabel;
        // Ensure font options exist and set multi to Markdown
        Font ??= new VisNetworkFontOptions();
        Font.Multi = VisNetworkMulti.Markdown;
        return this;
    }

    /// <summary>
    /// Sets the tooltip text that appears when hovering over the node.
    /// </summary>
    /// <param name="title">The tooltip text</param>
    /// <returns>The node options for method chaining</returns>
    public VisNetworkNodeOptions WithTitle(string title) {
        Title = title;
        return this;
    }

    /// <summary>
    /// Assigns the node to a group for shared styling.
    /// </summary>
    /// <param name="group">The group name</param>
    /// <returns>The node options for method chaining</returns>
    public VisNetworkNodeOptions WithGroup(string group) {
        Group = group;
        return this;
    }

    /// <summary>
    /// Sets the initial position of the node.
    /// </summary>
    /// <param name="x">The X coordinate</param>
    /// <param name="y">The Y coordinate</param>
    /// <returns>The node options for method chaining</returns>
    public VisNetworkNodeOptions WithPosition(double x, double y) {
        X = x;
        Y = y;
        return this;
    }

    /// <summary>
    /// Sets the hierarchical level of the node.
    /// </summary>
    /// <param name="level">The level value.</param>
    /// <returns>The node options for method chaining.</returns>
    public VisNetworkNodeOptions WithLevel(int level) {
        Level = level;
        return this;
    }

    /// <summary>
    /// Sets whether the node is hidden.
    /// </summary>
    /// <param name="hidden">True to hide the node.</param>
    /// <returns>The node options for method chaining.</returns>
    public VisNetworkNodeOptions WithHidden(bool hidden = true) {
        Hidden = hidden;
        return this;
    }

    /// <summary>
    /// Enables or disables physics for the node.
    /// </summary>
    /// <param name="physics">True to enable physics.</param>
    /// <returns>The node options for method chaining.</returns>
    public VisNetworkNodeOptions WithPhysics(bool physics = true) {
        Physics = physics;
        return this;
    }

    /// <summary>
    /// Fixes the node position on the X and Y axis.
    /// </summary>
    /// <param name="fixedX">Fix horizontal position.</param>
    /// <param name="fixedY">Fix vertical position.</param>
    /// <returns>The node options for method chaining.</returns>
    public VisNetworkNodeOptions WithFixed(bool fixedX, bool fixedY) {
        Fixed = new { x = fixedX, y = fixedY };
        return this;
    }

    /// <summary>
    /// Sets the node shape.
    /// </summary>
    /// <param name="shape">Shape to use.</param>
    /// <returns>The node options for method chaining.</returns>
    public VisNetworkNodeOptions WithShape(VisNetworkNodeShape shape) {
        Shape = shape;
        return this;
    }

    /// <summary>
    /// Sets the node size.
    /// </summary>
    /// <param name="size">Size value.</param>
    /// <returns>The node options for method chaining.</returns>
    public VisNetworkNodeOptions WithSize(double size) {
        Size = size;
        return this;
    }

    /// <summary>
    /// Sets the physics mass of the node.
    /// </summary>
    /// <param name="mass">Mass value.</param>
    /// <returns>The node options for method chaining.</returns>
    public VisNetworkNodeOptions WithMass(double mass) {
        Mass = mass;
        return this;
    }

    /// <summary>
    /// Sets the scaling value of the node.
    /// </summary>
    /// <param name="value">Value used for scaling.</param>
    /// <returns>The node options for method chaining.</returns>
    public VisNetworkNodeOptions WithValue(double value) {
        Value = value;
        return this;
    }

    /// <summary>
    /// Configures node scaling options.
    /// </summary>
    /// <param name="configure">Delegate to configure scaling.</param>
    /// <returns>The node options for method chaining.</returns>
    public VisNetworkNodeOptions WithScaling(Action<VisNetworkScalingOptions> configure) {
        Scaling ??= new VisNetworkScalingOptions();
        configure(Scaling);
        return this;
    }

    /// <summary>
    /// Sets the node color.
    /// </summary>
    /// <param name="color">Color value.</param>
    /// <returns>The node options for method chaining.</returns>
    public VisNetworkNodeOptions WithColor(RGBColor color) {
        Color = color.ToHex();
        return this;
    }

    /// <summary>
    /// Sets the node color using a string.
    /// </summary>
    /// <param name="color">Color value.</param>
    /// <returns>The node options for method chaining.</returns>
    public VisNetworkNodeOptions WithColor(string color) {
        Color = color;
        return this;
    }

    /// <summary>
    /// Sets complex color options for the node.
    /// </summary>
    /// <param name="colorOptions">Color options.</param>
    /// <returns>The node options for method chaining.</returns>
    public VisNetworkNodeOptions WithColor(VisNetworkColorOptions colorOptions) {
        Color = colorOptions;
        return this;
    }

    /// <summary>
    /// Sets the node opacity.
    /// </summary>
    /// <param name="opacity">Opacity value.</param>
    /// <returns>The node options for method chaining.</returns>
    public VisNetworkNodeOptions WithOpacity(double opacity) {
        Opacity = opacity;
        return this;
    }

    /// <summary>
    /// Configures font options for the node label.
    /// </summary>
    /// <param name="configure">Delegate to configure font options.</param>
    /// <returns>The node options for method chaining.</returns>
    public VisNetworkNodeOptions WithFont(Action<VisNetworkFontOptions> configure) {
        Font ??= new VisNetworkFontOptions();
        configure(Font);
        return this;
    }

    /// <summary>
    /// Sets the image URL for an image node.
    /// </summary>
    /// <param name="imageUrl">URL of the image.</param>
    /// <returns>The node options for method chaining.</returns>
    public VisNetworkNodeOptions WithImage(string imageUrl) {
        Image = imageUrl;
        if (Shape == null || Shape == VisNetworkNodeShape.Ellipse) {
            Shape = VisNetworkNodeShape.Image;
        }
        return this;
    }

    /// <summary>
    /// Sets image options for an image node.
    /// </summary>
    /// <param name="imageOptions">Options describing the image.</param>
    /// <returns>The node options for method chaining.</returns>
    public VisNetworkNodeOptions WithImageObject(VisNetworkImageOptions imageOptions) {
        Image = imageOptions;
        if (Shape == null || Shape == VisNetworkNodeShape.Ellipse) {
            Shape = VisNetworkNodeShape.Image;
        }
        return this;
    }

    /// <summary>
    /// Sets the fallback image URL when the main image fails to load.
    /// Used when shape is 'image' or 'circularImage'.
    /// </summary>
    /// <param name="url">The URL of the broken image placeholder</param>
    /// <returns>The node options for method chaining</returns>
    public VisNetworkNodeOptions WithBrokenImage(string url) {
        BrokenImage = url;
        return this;
    }

    /// <summary>
    /// Sets uniform padding around the image in pixels.
    /// Used when shape is 'image' or 'circularImage'.
    /// </summary>
    /// <param name="padding">The padding value in pixels</param>
    /// <returns>The node options for method chaining</returns>
    public VisNetworkNodeOptions WithImagePadding(int padding) {
        ImagePadding = padding;
        return this;
    }

    /// <summary>
    /// Sets individual padding values for each side of the image.
    /// Used when shape is 'image' or 'circularImage'.
    /// </summary>
    /// <param name="top">Top padding in pixels</param>
    /// <param name="right">Right padding in pixels</param>
    /// <param name="bottom">Bottom padding in pixels</param>
    /// <param name="left">Left padding in pixels</param>
    /// <returns>The node options for method chaining</returns>
    public VisNetworkNodeOptions WithImagePadding(int top, int right, int bottom, int left) {
        ImagePadding = new { top, right, bottom, left };
        return this;
    }

    /// <summary>
    /// Configures an icon for the node.
    /// </summary>
    /// <param name="configure">Delegate to configure icon options.</param>
    /// <returns>The node options for method chaining.</returns>
    public VisNetworkNodeOptions WithIcon(Action<VisNetworkIconOptions> configure) {
        Icon ??= new VisNetworkIconOptions();
        configure(Icon);
        Shape = VisNetworkNodeShape.Icon;
        return this;
    }

    /// <summary>
    /// Configures additional shape properties.
    /// </summary>
    /// <param name="configure">Delegate to configure the shape properties.</param>
    /// <returns>The node options for method chaining.</returns>
    public VisNetworkNodeOptions WithShapeProperties(Action<VisNetworkShapeProperties> configure) {
        ShapeProperties ??= new VisNetworkShapeProperties();
        configure(ShapeProperties);
        return this;
    }

    /// <summary>
    /// Sets the border width of the node.
    /// </summary>
    /// <param name="width">Border width.</param>
    /// <param name="selectedWidth">Optional width when selected.</param>
    /// <returns>The node options for method chaining.</returns>
    public VisNetworkNodeOptions WithBorderWidth(double width, double? selectedWidth = null) {
        BorderWidth = width;
        if (selectedWidth.HasValue) {
            BorderWidthSelected = selectedWidth.Value;
        }
        return this;
    }

    /// <summary>
    /// Enables or disables the chosen state for the node.
    /// </summary>
    /// <param name="enabled">True to enable chosen state.</param>
    /// <returns>The node options for method chaining.</returns>
    public VisNetworkNodeOptions WithChosen(bool enabled) {
        Chosen = enabled;
        return this;
    }

    /// <summary>
    /// Sets detailed chosen options for the node.
    /// </summary>
    /// <param name="chosenOptions">Chosen configuration.</param>
    /// <returns>The node options for method chaining.</returns>
    public VisNetworkNodeOptions WithChosen(VisNetworkChosenOptions chosenOptions) {
        Chosen = chosenOptions;
        return this;
    }

    /// <summary>
    /// Enables or disables bold highlight of the node label.
    /// </summary>
    /// <param name="highlightBold">True to highlight in bold.</param>
    /// <returns>The node options for method chaining.</returns>
    public VisNetworkNodeOptions WithLabelHighlightBold(bool highlightBold = true) {
        LabelHighlightBold = highlightBold;
        return this;
    }

    /// <summary>
    /// Enables or disables shadow for the node.
    /// </summary>
    /// <param name="enabled">True to enable shadow.</param>
    /// <returns>The node options for method chaining.</returns>
    public VisNetworkNodeOptions WithShadow(bool enabled = true) {
        Shadow = enabled;
        return this;
    }

    /// <summary>
    /// Applies custom shadow options to the node.
    /// </summary>
    /// <param name="shadowOptions">Shadow configuration.</param>
    /// <returns>The node options for method chaining.</returns>
    public VisNetworkNodeOptions WithShadow(VisNetworkShadowOptions shadowOptions) {
        Shadow = shadowOptions;
        return this;
    }

    /// <summary>
    /// Sets a uniform margin around the node.
    /// </summary>
    /// <param name="margin">Margin value.</param>
    /// <returns>The node options for method chaining.</returns>
    public VisNetworkNodeOptions WithMargin(double margin) {
        Margin = margin;
        return this;
    }

    /// <summary>
    /// Sets individual margins around the node.
    /// </summary>
    /// <param name="top">Top margin.</param>
    /// <param name="right">Right margin.</param>
    /// <param name="bottom">Bottom margin.</param>
    /// <param name="left">Left margin.</param>
    /// <returns>The node options for method chaining.</returns>
    public VisNetworkNodeOptions WithMargin(double top, double right, double bottom, double left) {
        Margin = new { top, right, bottom, left };
        return this;
    }

    /// <summary>
    /// Sets width constraints for the node.
    /// </summary>
    /// <param name="minimum">Minimum width.</param>
    /// <param name="maximum">Maximum width.</param>
    /// <returns>The node options for method chaining.</returns>
    public VisNetworkNodeOptions WithWidthConstraint(double? minimum = null, double? maximum = null) {
        if (minimum.HasValue || maximum.HasValue) {
            var constraint = new Dictionary<string, double>();
            if (minimum.HasValue) constraint["minimum"] = minimum.Value;
            if (maximum.HasValue) constraint["maximum"] = maximum.Value;
            WidthConstraint = constraint;
        }
        return this;
    }

    /// <summary>
    /// Sets height constraints for the node.
    /// </summary>
    /// <param name="minimum">Minimum height.</param>
    /// <param name="maximum">Maximum height.</param>
    /// <returns>The node options for method chaining.</returns>
    public VisNetworkNodeOptions WithHeightConstraint(double? minimum = null, double? maximum = null) {
        if (minimum.HasValue || maximum.HasValue) {
            var constraint = new Dictionary<string, double>();
            if (minimum.HasValue) constraint["minimum"] = minimum.Value;
            if (maximum.HasValue) constraint["maximum"] = maximum.Value;
            HeightConstraint = constraint;
        }
        return this;
    }

    /// <summary>
    /// Sets a custom shape for the node using the provided custom shape definition.
    /// </summary>
    /// <param name="customShape">The custom shape to use for rendering the node</param>
    /// <returns>The node options for method chaining</returns>
    public VisNetworkNodeOptions WithCustomShape(VisNetworkCustomShape customShape) {
        if (customShape != null && !string.IsNullOrEmpty(customShape.RenderFunction)) {
            Shape = VisNetworkNodeShape.Custom;
            CtxRenderer = customShape.RenderFunction;
        }
        return this;
    }
    
    /// <summary>
    /// Internal flag to track whether auto-embedding should be skipped for this node.
    /// This is not serialized to JSON.
    /// </summary>
    [JsonIgnore]
    internal bool SkipAutoEmbedding { get; set; }
}

/// <summary>
/// Color configuration options for nodes.
/// </summary>
public class VisNetworkColorOptions {
    /// <summary>Background color.</summary>
    [JsonPropertyName("background")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Background { get; set; }

    /// <summary>Border color.</summary>
    [JsonPropertyName("border")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Border { get; set; }

    /// <summary>Highlight colors.</summary>
    [JsonPropertyName("highlight")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Highlight { get; set; }

    /// <summary>Hover colors.</summary>
    [JsonPropertyName("hover")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Hover { get; set; }

    /// <summary>Sets the background color.</summary>
    /// <param name="color">Background color.</param>
    /// <returns>The color options for method chaining.</returns>
    public VisNetworkColorOptions WithBackground(RGBColor color) {
        Background = color.ToHex();
        return this;
    }

    /// <summary>Sets the border color.</summary>
    /// <param name="color">Border color.</param>
    /// <returns>The color options for method chaining.</returns>
    public VisNetworkColorOptions WithBorder(RGBColor color) {
        Border = color.ToHex();
        return this;
    }

    /// <summary>Sets the highlight colors.</summary>
    /// <param name="background">Background highlight color.</param>
    /// <param name="border">Border highlight color.</param>
    /// <returns>The color options for method chaining.</returns>
    public VisNetworkColorOptions WithHighlight(RGBColor background, RGBColor border) {
        Highlight = new { background = background.ToHex(), border = border.ToHex() };
        return this;
    }

    /// <summary>Sets the hover colors.</summary>
    /// <param name="background">Background hover color.</param>
    /// <param name="border">Border hover color.</param>
    /// <returns>The color options for method chaining.</returns>
    public VisNetworkColorOptions WithHover(RGBColor background, RGBColor border) {
        Hover = new { background = background.ToHex(), border = border.ToHex() };
        return this;
    }
}

/// <summary>
/// Font configuration options.
/// </summary>
public class VisNetworkFontOptions {
    /// <summary>Font color.</summary>
    [JsonPropertyName("color")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Color { get; set; }

    /// <summary>Font size in pixels.</summary>
    [JsonPropertyName("size")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Size { get; set; }

    /// <summary>Font family.</summary>
    [JsonPropertyName("face")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Face { get; set; }

    /// <summary>Background color.</summary>
    [JsonPropertyName("background")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Background { get; set; }

    /// <summary>Stroke width for the text.</summary>
    [JsonPropertyName("strokeWidth")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? StrokeWidth { get; set; }

    /// <summary>Stroke color for the text.</summary>
    [JsonPropertyName("strokeColor")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? StrokeColor { get; set; }

    /// <summary>Text alignment.</summary>
    [JsonPropertyName("align")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkAlign? Align { get; set; }

    /// <summary>Multi-line mode.</summary>
    [JsonPropertyName("multi")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkMulti? Multi { get; set; }

    /// <summary>Vertical adjustment.</summary>
    [JsonPropertyName("vadjust")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Vadjust { get; set; }

    /// <summary>Bold font configuration.</summary>
    [JsonPropertyName("bold")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Bold { get; set; }

    /// <summary>Italic font configuration.</summary>
    [JsonPropertyName("ital")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Ital { get; set; }

    /// <summary>Bold italic font configuration.</summary>
    [JsonPropertyName("boldital")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? BoldItal { get; set; }

    /// <summary>Monospace font configuration.</summary>
    [JsonPropertyName("mono")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Mono { get; set; }

    /// <summary>Sets the font color.</summary>
    /// <param name="color">Color to set.</param>
    /// <returns>The font options for method chaining.</returns>
    public VisNetworkFontOptions WithColor(RGBColor color) {
        Color = color.ToHex();
        return this;
    }

    /// <summary>Sets the font size.</summary>
    /// <param name="size">Size in pixels.</param>
    /// <returns>The font options for method chaining.</returns>
    public VisNetworkFontOptions WithSize(int size) {
        Size = size;
        return this;
    }

    /// <summary>Sets the font family.</summary>
    /// <param name="face">Font family name.</param>
    /// <returns>The font options for method chaining.</returns>
    public VisNetworkFontOptions WithFace(string face) {
        Face = face;
        return this;
    }

    /// <summary>Sets the background color.</summary>
    /// <param name="background">Background color.</param>
    /// <returns>The font options for method chaining.</returns>
    public VisNetworkFontOptions WithBackground(RGBColor background) {
        Background = background.ToHex();
        return this;
    }

    /// <summary>Sets stroke width and color.</summary>
    /// <param name="width">Stroke width.</param>
    /// <param name="color">Stroke color.</param>
    /// <returns>The font options for method chaining.</returns>
    public VisNetworkFontOptions WithStroke(double width, RGBColor color) {
        StrokeWidth = width;
        StrokeColor = color.ToHex();
        return this;
    }

    /// <summary>Sets text alignment.</summary>
    /// <param name="align">Alignment value.</param>
    /// <returns>The font options for method chaining.</returns>
    public VisNetworkFontOptions WithAlign(VisNetworkAlign align) {
        Align = align;
        return this;
    }

    /// <summary>Sets multi-line mode.</summary>
    /// <param name="multi">Multi-line option.</param>
    /// <returns>The font options for method chaining.</returns>
    public VisNetworkFontOptions WithMulti(VisNetworkMulti multi) {
        Multi = multi;
        return this;
    }

    /// <summary>Adjusts vertical positioning.</summary>
    /// <param name="vadjust">Vertical offset.</param>
    /// <returns>The font options for method chaining.</returns>
    public VisNetworkFontOptions WithVadjust(double vadjust) {
        Vadjust = vadjust;
        return this;
    }
}

/// <summary>
/// Icon configuration for icon-shaped nodes.
/// </summary>
public class VisNetworkIconOptions {
    /// <summary>Icon font face.</summary>
    [JsonPropertyName("face")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Face { get; set; }

    /// <summary>Icon code.</summary>
    [JsonPropertyName("code")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Code { get; set; }

    /// <summary>Icon size.</summary>
    [JsonPropertyName("size")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Size { get; set; }

    /// <summary>Icon color.</summary>
    [JsonPropertyName("color")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Color { get; set; }

    /// <summary>Font weight.</summary>
    [JsonPropertyName("weight")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Weight { get; set; }

    /// <summary>Sets the icon face.</summary>
    /// <param name="face">Font face.</param>
    /// <returns>The icon options for method chaining.</returns>
    public VisNetworkIconOptions WithFace(string face) {
        Face = face;
        return this;
    }

    /// <summary>Sets the icon code.</summary>
    /// <param name="code">Icon code.</param>
    /// <returns>The icon options for method chaining.</returns>
    public VisNetworkIconOptions WithCode(string code) {
        Code = code;
        return this;
    }

    /// <summary>Sets the icon size.</summary>
    /// <param name="size">Size value.</param>
    /// <returns>The icon options for method chaining.</returns>
    public VisNetworkIconOptions WithSize(int size) {
        Size = size;
        return this;
    }

    /// <summary>Sets the icon color.</summary>
    /// <param name="color">Color value.</param>
    /// <returns>The icon options for method chaining.</returns>
    public VisNetworkIconOptions WithColor(RGBColor color) {
        Color = color.ToHex();
        return this;
    }

    /// <summary>Sets the font weight.</summary>
    /// <param name="weight">Weight value.</param>
    /// <returns>The icon options for method chaining.</returns>
    public VisNetworkIconOptions WithWeight(string weight) {
        Weight = weight;
        return this;
    }

    /// <summary>
    /// <summary>
    /// Sets the icon using a FontAwesome Solid icon. Automatically sets face for Font Awesome 6.
    /// </summary>
    /// <param name="icon">The FontAwesome solid icon to use</param>
    /// <returns>The icon options for method chaining</returns>
    public VisNetworkIconOptions WithFontAwesome(FontAwesomeSolid icon) {
        Face = "\"Font Awesome 6 Free\"";
        Code = icon.GetCode();
        Weight = "900"; // Solid weight
        return this;
    }

    /// <summary>
    /// Sets the icon using a FontAwesome Regular icon. Automatically sets face for Font Awesome 6.
    /// </summary>
    /// <param name="icon">The FontAwesome regular icon to use</param>
    /// <returns>The icon options for method chaining</returns>
    public VisNetworkIconOptions WithFontAwesome(FontAwesomeRegular icon) {
        Face = "\"Font Awesome 6 Free\"";
        Code = icon.GetCode();
        Weight = "400"; // Regular weight
        return this;
    }

    /// <summary>
    /// Sets the icon using a FontAwesome Brand icon. Automatically sets face for Font Awesome 6 Brands.
    /// </summary>
    /// <param name="icon">The FontAwesome brand icon to use</param>
    /// <returns>The icon options for method chaining</returns>
    public VisNetworkIconOptions WithFontAwesome(FontAwesomeBrands icon) {
        Face = "\"Font Awesome 6 Brands\"";
        Code = icon.GetCode();
        Weight = "400"; // Brands use regular weight
        return this;
    }

    // Font Awesome 5 methods for vis.js compatibility

    /// <summary>
    /// Sets the icon using a FontAwesome 5 Solid icon. Uses proper face format for vis.js compatibility.
    /// </summary>
    /// <param name="icon">The FontAwesome 5 solid icon to use</param>
    /// <returns>The icon options for method chaining</returns>
    public VisNetworkIconOptions WithFontAwesome5(FontAwesome5Solid icon) {
        Face = "\"Font Awesome 5 Free\"";
        Code = icon.GetCode();
        Weight = "bold"; // Font Awesome 5 uses "bold" for solid
        return this;
    }

    /// <summary>
    /// Sets the icon using a FontAwesome 5 Regular icon. Uses proper face format for vis.js compatibility.
    /// </summary>
    /// <param name="icon">The FontAwesome 5 regular icon to use</param>
    /// <returns>The icon options for method chaining</returns>
    public VisNetworkIconOptions WithFontAwesome5(FontAwesome5Regular icon) {
        Face = "\"Font Awesome 5 Free\"";
        Code = icon.GetCode();
        Weight = "bold"; // Font Awesome 5 uses "bold" even for regular
        return this;
    }

    /// <summary>
    /// Sets the icon using a FontAwesome 5 Brand icon. Uses proper face format for vis.js compatibility.
    /// </summary>
    /// <param name="icon">The FontAwesome 5 brand icon to use</param>
    /// <returns>The icon options for method chaining</returns>
    public VisNetworkIconOptions WithFontAwesome5(FontAwesome5Brands icon) {
        Face = "\"Font Awesome 5 Brands\"";
        Code = icon.GetCode();
        Weight = "bold"; // Font Awesome 5 uses "bold" for brands
        return this;
    }
}

/// <summary>
/// Shape-specific properties for custom node shapes.
/// </summary>
public class VisNetworkShapeProperties {
    /// <summary>Dash pattern for the border.</summary>
    [JsonPropertyName("borderDashes")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? BorderDashes { get; set; }

    /// <summary>Border corner radius.</summary>
    [JsonPropertyName("borderRadius")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? BorderRadius { get; set; }

    /// <summary>Enable interpolation for custom shapes.</summary>
    [JsonPropertyName("interpolation")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Interpolation { get; set; }

    /// <summary>Use image's natural size.</summary>
    [JsonPropertyName("useImageSize")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? UseImageSize { get; set; }

    /// <summary>Show border when using images.</summary>
    [JsonPropertyName("useBorderWithImage")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? UseBorderWithImage { get; set; }

    /// <summary>
    /// Enables or disables dashed borders for the node.
    /// </summary>
    /// <param name="enabled">True to enable dashed borders, false for solid borders</param>
    /// <returns>The shape properties for method chaining</returns>
    public VisNetworkShapeProperties WithBorderDashes(bool enabled = true) {
        BorderDashes = enabled;
        return this;
    }

    /// <summary>
    /// Sets a custom dash pattern for the node border.
    /// </summary>
    /// <param name="pattern">An array of integers representing dash and gap lengths</param>
    /// <returns>The shape properties for method chaining</returns>
    public VisNetworkShapeProperties WithBorderDashes(params int[] pattern) {
        BorderDashes = pattern;
        return this;
    }

    /// <summary>
    /// Sets a predefined dash pattern for the node border.
    /// </summary>
    /// <param name="pattern">The dash pattern to use</param>
    /// <returns>The shape properties for method chaining</returns>
    public VisNetworkShapeProperties WithBorderDashes(VisNetworkDashPattern pattern) {
        BorderDashes = pattern == VisNetworkDashPattern.Solid ? false : (object)pattern.ToArray();
        return this;
    }

    /// <summary>Sets the border radius.</summary>
    /// <param name="radius">Radius value.</param>
    /// <returns>The shape properties for method chaining.</returns>
    public VisNetworkShapeProperties WithBorderRadius(double radius) {
        BorderRadius = radius;
        return this;
    }

    /// <summary>Enables or disables interpolation.</summary>
    /// <param name="enabled">Whether interpolation is enabled.</param>
    /// <returns>The shape properties for method chaining.</returns>
    public VisNetworkShapeProperties WithInterpolation(bool enabled = true) {
        Interpolation = enabled;
        return this;
    }

    /// <summary>Uses the image's natural size.</summary>
    /// <param name="use">True to use image size.</param>
    /// <returns>The shape properties for method chaining.</returns>
    public VisNetworkShapeProperties WithUseImageSize(bool use = true) {
        UseImageSize = use;
        return this;
    }

    /// <summary>Enables or disables the border when using images.</summary>
    /// <param name="use">True to show border.</param>
    /// <returns>The shape properties for method chaining.</returns>
    public VisNetworkShapeProperties WithUseBorderWithImage(bool use = true) {
        UseBorderWithImage = use;
        return this;
    }
}

/// <summary>
/// Scaling options for nodes.
/// </summary>
public class VisNetworkScalingOptions {
    /// <summary>Minimum value for scaling.</summary>
    [JsonPropertyName("min")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Min { get; set; }

    /// <summary>Maximum value for scaling.</summary>
    [JsonPropertyName("max")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Max { get; set; }

    /// <summary>Label scaling options.</summary>
    [JsonPropertyName("label")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Label { get; set; }

    /// <summary>Sets the minimum scaling value.</summary>
    /// <param name="min">Minimum value.</param>
    /// <returns>The scaling options for method chaining.</returns>
    public VisNetworkScalingOptions WithMin(double min) {
        Min = min;
        return this;
    }

    /// <summary>Sets the maximum scaling value.</summary>
    /// <param name="max">Maximum value.</param>
    /// <returns>The scaling options for method chaining.</returns>
    public VisNetworkScalingOptions WithMax(double max) {
        Max = max;
        return this;
    }

    /// <summary>Enables or disables label scaling.</summary>
    /// <param name="enabled">True to enable scaling.</param>
    /// <returns>The scaling options for method chaining.</returns>
    public VisNetworkScalingOptions WithLabel(bool enabled = true) {
        Label = enabled;
        return this;
    }

    /// <summary>Configures advanced label scaling options.</summary>
    /// <param name="min">Minimum value.</param>
    /// <param name="max">Maximum value.</param>
    /// <param name="maxVisible">Maximum visible value.</param>
    /// <param name="drawThreshold">Draw threshold value.</param>
    /// <returns>The scaling options for method chaining.</returns>
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
    /// <summary>Determines whether shadow is enabled.</summary>
    [JsonPropertyName("enabled")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Enabled { get; set; }

    /// <summary>Shadow color.</summary>
    [JsonPropertyName("color")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Color { get; set; }

    /// <summary>Blur size of the shadow.</summary>
    [JsonPropertyName("size")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Size { get; set; }

    /// <summary>X offset of the shadow.</summary>
    [JsonPropertyName("x")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? X { get; set; }

    /// <summary>Y offset of the shadow.</summary>
    [JsonPropertyName("y")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Y { get; set; }

    /// <summary>Enables or disables the shadow.</summary>
    /// <param name="enabled">True to enable shadow.</param>
    /// <returns>The shadow options for method chaining.</returns>
    public VisNetworkShadowOptions WithEnabled(bool enabled = true) {
        Enabled = enabled;
        return this;
    }

    /// <summary>Sets the shadow color.</summary>
    /// <param name="color">Shadow color.</param>
    /// <returns>The shadow options for method chaining.</returns>
    public VisNetworkShadowOptions WithColor(RGBColor color) {
        Color = color.ToHex();
        return this;
    }

    /// <summary>Sets the shadow blur size.</summary>
    /// <param name="size">Blur size.</param>
    /// <returns>The shadow options for method chaining.</returns>
    public VisNetworkShadowOptions WithSize(double size) {
        Size = size;
        return this;
    }

    /// <summary>Sets the shadow offset.</summary>
    /// <param name="x">Horizontal offset.</param>
    /// <param name="y">Vertical offset.</param>
    /// <returns>The shadow options for method chaining.</returns>
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
    /// <summary>Node selection options.</summary>
    [JsonPropertyName("node")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Node { get; set; }

    /// <summary>Label selection options.</summary>
    [JsonPropertyName("label")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Label { get; set; }

    /// <summary>Enables or disables node selection.</summary>
    /// <param name="enabled">True to enable selection.</param>
    /// <returns>The chosen options for method chaining.</returns>
    public VisNetworkChosenOptions WithNode(bool enabled = true) {
        Node = enabled;
        return this;
    }

    /// <summary>Configures node selection options.</summary>
    /// <param name="configure">Delegate to configure the options.</param>
    /// <returns>The chosen options for method chaining.</returns>
    public VisNetworkChosenOptions WithNode(Action<VisNetworkChosenNodeOptions> configure) {
        var options = new VisNetworkChosenNodeOptions();
        configure(options);
        Node = options;
        return this;
    }

    /// <summary>Enables or disables label selection.</summary>
    /// <param name="enabled">True to enable label selection.</param>
    /// <returns>The chosen options for method chaining.</returns>
    public VisNetworkChosenOptions WithLabel(bool enabled = true) {
        Label = enabled;
        return this;
    }
}

/// <summary>
/// Chosen node-specific options.
/// </summary>
public class VisNetworkChosenNodeOptions {
    /// <summary>Color of the node when chosen.</summary>
    [JsonPropertyName("color")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Color { get; set; }

    /// <summary>Border color when chosen.</summary>
    [JsonPropertyName("borderColor")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? BorderColor { get; set; }

    /// <summary>Border width when chosen.</summary>
    [JsonPropertyName("borderWidth")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? BorderWidth { get; set; }

    /// <summary>Node size when chosen.</summary>
    [JsonPropertyName("size")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Size { get; set; }

    /// <summary>Sets the chosen color.</summary>
    /// <param name="color">Color value.</param>
    /// <returns>The chosen node options for method chaining.</returns>
    public VisNetworkChosenNodeOptions WithColor(RGBColor color) {
        Color = color.ToHex();
        return this;
    }

    /// <summary>Sets the border color when chosen.</summary>
    /// <param name="color">Border color.</param>
    /// <returns>The chosen node options for method chaining.</returns>
    public VisNetworkChosenNodeOptions WithBorderColor(RGBColor color) {
        BorderColor = color.ToHex();
        return this;
    }

    /// <summary>Sets the border width when chosen.</summary>
    /// <param name="width">Border width.</param>
    /// <returns>The chosen node options for method chaining.</returns>
    public VisNetworkChosenNodeOptions WithBorderWidth(double width) {
        BorderWidth = width;
        return this;
    }

    /// <summary>Sets the node size when chosen.</summary>
    /// <param name="size">Size value.</param>
    /// <returns>The chosen node options for method chaining.</returns>
    public VisNetworkChosenNodeOptions WithSize(double size) {
        Size = size;
        return this;
    }
}

/// <summary>
/// Image configuration options for image nodes.
/// </summary>
public class VisNetworkImageOptions {
    /// <summary>Image URL when the node is not selected.</summary>
    [JsonPropertyName("unselected")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Unselected { get; set; }

    /// <summary>Image URL when the node is selected.</summary>
    [JsonPropertyName("selected")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Selected { get; set; }

    /// <summary>Fallback image URL when the main image fails.</summary>
    [JsonPropertyName("brokenImage")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? BrokenImage { get; set; }

    /// <summary>Padding around the image.</summary>
    [JsonPropertyName("imagePadding")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? ImagePadding { get; set; }

    /// <summary>Sets the image displayed when not selected.</summary>
    /// <param name="url">Image URL.</param>
    /// <returns>The image options for method chaining.</returns>
    public VisNetworkImageOptions WithUnselected(string url) {
        Unselected = url;
        return this;
    }

    /// <summary>Sets the image displayed when selected.</summary>
    /// <param name="url">Image URL.</param>
    /// <returns>The image options for method chaining.</returns>
    public VisNetworkImageOptions WithSelected(string url) {
        Selected = url;
        return this;
    }

    /// <summary>
    /// Sets the URL of the image to use when the main image cannot be loaded.
    /// </summary>
    /// <param name="url">The URL of the broken image placeholder</param>
    /// <returns>The image options for method chaining</returns>
    public VisNetworkImageOptions WithBrokenImage(string url) {
        BrokenImage = url;
        return this;
    }

    /// <summary>
    /// Sets uniform padding around the image in pixels.
    /// </summary>
    /// <param name="padding">The padding value in pixels</param>
    /// <returns>The image options for method chaining</returns>
    public VisNetworkImageOptions WithImagePadding(int padding) {
        ImagePadding = padding;
        return this;
    }

    /// <summary>
    /// Sets individual padding values for each side of the image.
    /// </summary>
    /// <param name="top">Top padding in pixels</param>
    /// <param name="right">Right padding in pixels</param>
    /// <param name="bottom">Bottom padding in pixels</param>
    /// <param name="left">Left padding in pixels</param>
    /// <returns>The image options for method chaining</returns>
    public VisNetworkImageOptions WithImagePadding(int top, int right, int bottom, int left) {
        ImagePadding = new { top, right, bottom, left };
        return this;
    }
}