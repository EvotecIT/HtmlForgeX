namespace HtmlForgeX;

public class HtmlSpan : HtmlElement {
    public string? Content { get; set; }
    public RGBColor? Color { get; set; }
    public RGBColor? BackGroundColor { get; set; }
    public string? FontSize { get; set; }
    public string? LineHeight { get; set; }
    public FontWeight? FontWeight { get; set; }
    public FontStyle? FontStyle { get; set; }
    public FontVariant? FontVariant { get; set; }
    public string? FontFamily { get; set; }
    public FontAlignment? Alignment { get; set; }
    public TextDecoration? TextDecoration { get; set; }
    public TextTransform? TextTransform { get; set; }
    public Direction? Direction { get; set; }
    public Display? Display { get; set; }
    public double? Opacity { get; set; }

    public List<HtmlSpan> HtmlSpans { get; } = new List<HtmlSpan>();
    private HtmlSpan Parent { get; set; }

    public HtmlSpan(HtmlSpan? parent = null) {
        this.Parent = parent ?? this;  // If no parent is provided, assume this is the root.
    }

    public HtmlSpan AddContent(string content) {
        var newSpan = new HtmlSpan(this) {
            Content = content
        };
        this.Parent.HtmlSpans.Add(newSpan);  // Add to children of this span
        return newSpan;  // Return new span for modification
    }

    public HtmlSpan WithColor(RGBColor color) {
        this.Color = color;
        return this;
    }

    public HtmlSpan WithBackgroundColor(RGBColor backgroundColor) {
        BackGroundColor = backgroundColor;
        return this;
    }


    public HtmlSpan WithFontSize(string fontSize) {
        FontSize = fontSize;
        return this;
    }

    public HtmlSpan WithLineHeight(string lineHeight) {
        LineHeight = lineHeight;
        return this;
    }

    public HtmlSpan WithFontWeight(FontWeight fontWeight) {
        FontWeight = fontWeight;
        return this;
    }

    public HtmlSpan WithFontStyle(FontStyle fontStyle) {
        FontStyle = fontStyle;
        return this;
    }

    public HtmlSpan WithFontVariant(FontVariant fontVariant) {
        FontVariant = fontVariant;
        return this;
    }

    public HtmlSpan WithFontFamily(string fontFamily) {
        FontFamily = fontFamily;
        return this;
    }

    public HtmlSpan WithAlignment(FontAlignment alignment) {
        Alignment = alignment;
        return this;
    }

    public HtmlSpan WithTextDecoration(TextDecoration textDecoration) {
        TextDecoration = textDecoration;
        return this;
    }

    public HtmlSpan WithTextTransform(TextTransform textTransform) {
        TextTransform = textTransform;
        return this;
    }

    public HtmlSpan WithDirection(Direction direction) {
        Direction = direction;
        return this;
    }

    public HtmlSpan WithDisplay(Display display) {
        Display = display;
        return this;
    }

    public HtmlSpan WithOpacity(double? opacity) {
        Opacity = opacity;
        return this;
    }

    public string GenerateStyle() {
        //var style = new Dictionary<string, string>
        //{
        //    { "color", Color?.ToHex() },
        //    { "background-color", BackGroundColor?.ToHex() },
        //    { "font-size", FontSize },
        //    { "line-height", LineHeight },
        //    { "font-weight", FontWeight?.ToCssString() },
        //    { "font-style", FontStyle?.ToString() },
        //    { "font-variant", FontVariant?.ToCssString() },
        //    { "font-family", FontFamily },
        //    { "text-align", Alignment?.ToString() },
        //    { "text-decoration", TextDecoration?.ToCssString() },
        //    { "text-transform", TextTransform?.ToString() },
        //    { "direction", Direction?.ToString() },
        //    { "display", Display?.ToCssString() },
        //    { "opacity", Opacity?.ToString() }
        //};

        //var styleString = string.Join("; ", style.Where(kvp => !string.IsNullOrEmpty(kvp.Value)).Select(kvp => $"{kvp.Key}: {kvp.Value}"));
        //return styleString;
        var style = new List<string>();

        if (Color != null) style.Add($"color: {Color.ToHex()}");
        if (BackGroundColor != null) style.Add($"background-color: {BackGroundColor.ToHex()}");
        if (FontSize != null) style.Add($"font-size: {FontSize}");
        if (LineHeight != null) style.Add($"line-height: {LineHeight}");
        if (FontWeight != null) style.Add($"font-weight: {FontWeight?.ToCssString()}");
        if (FontStyle != null) style.Add($"font-style: {FontStyle}");
        if (FontVariant != null) style.Add($"font-variant: {FontVariant?.ToCssString()}");
        if (FontFamily != null) style.Add($"font-family: {FontFamily}");
        if (Alignment != null) style.Add($"text-align: {Alignment}");
        if (TextDecoration != null) style.Add($"text-decoration: {TextDecoration?.ToCssString()}");
        if (TextTransform != null) style.Add($"text-transform: {TextTransform}");
        if (Direction != null) style.Add($"direction: {Direction}");
        if (Display != null) style.Add($"display: {Display?.ToCssString()}");
        if (Opacity != null) style.Add($"opacity: {Opacity}");

        var styleString = string.Join("; ", style);
        return styleString;
    }

    public override string ToString() {
        var styleString = GenerateStyle();
        styleString = !string.IsNullOrEmpty(styleString) ? $" style=\"{styleString}\"" : "";

        if (this == this.Parent) {
            return $"<span{styleString}>{Content}</span>";
        } else {
            var childrenHtml = string.Join("", this.Parent.HtmlSpans.Select(child => $"<span style=\"{child.GenerateStyle()}\">{child.Content}</span>"));
            return $"{childrenHtml}";
        }
    }
}
