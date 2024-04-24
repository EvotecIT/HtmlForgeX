namespace HtmlForgeX;

public class Span : Element {
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

    public List<Span> HtmlSpans { get; } = new List<Span>();
    private Span Parent { get; set; }
    public Span(Span? parent = null) {
        this.Parent = parent ?? this;  // If no parent is provided, assume this is the root.
    }

    public Span AppendContent(string content) {
        var newSpan = new Span(this) {
            Content = content
        };
        this.Parent.HtmlSpans.Add(newSpan);  // Add to children of this span
        return newSpan;  // Return new span for modification
    }

    public Span AddContent(string content) {
        var newSpan = new Span { Content = content };
        this.Add(newSpan);  // Add to children of this HtmlElement
        return newSpan;  // Return new span for modification
    }

    public Span Add(string content) {
        var newSpan = new Span { Content = content };
        this.Add(newSpan);  // Add to children of this HtmlElement
        return newSpan;  // Return new span for modification
    }

    public Span WithColor(RGBColor color) {
        this.Color = color;
        return this;
    }

    public Span WithBackgroundColor(RGBColor backgroundColor) {
        BackGroundColor = backgroundColor;
        return this;
    }


    public Span WithFontSize(string fontSize) {
        FontSize = fontSize;
        return this;
    }

    public Span WithLineHeight(string lineHeight) {
        LineHeight = lineHeight;
        return this;
    }

    public Span WithFontWeight(FontWeight fontWeight) {
        FontWeight = fontWeight;
        return this;
    }

    public Span WithFontStyle(FontStyle fontStyle) {
        FontStyle = fontStyle;
        return this;
    }

    public Span WithFontVariant(FontVariant fontVariant) {
        FontVariant = fontVariant;
        return this;
    }

    public Span WithFontFamily(string fontFamily) {
        FontFamily = fontFamily;
        return this;
    }

    public Span WithAlignment(FontAlignment alignment) {
        Alignment = alignment;
        return this;
    }

    public Span WithTextDecoration(TextDecoration textDecoration) {
        TextDecoration = textDecoration;
        return this;
    }

    public Span WithTextTransform(TextTransform textTransform) {
        TextTransform = textTransform;
        return this;
    }

    public Span WithDirection(Direction direction) {
        Direction = direction;
        return this;
    }

    public Span WithDisplay(Display display) {
        Display = display;
        return this;
    }

    public Span WithOpacity(double? opacity) {
        Opacity = opacity;
        return this;
    }

    public string GenerateStyle() {
        var style = new List<string>();

        if (Color != null) style.Add($"color: {Color.ToHex()}");
        if (BackGroundColor != null) style.Add($"background-color: {BackGroundColor.ToHex()}");
        if (FontSize != null) style.Add($"font-size: {FontSize}");
        if (LineHeight != null) style.Add($"line-height: {LineHeight}");
        if (FontWeight != null) style.Add($"font-weight: {FontWeight?.EnumToString()}");
        if (FontStyle != null) style.Add($"font-style: {FontStyle}");
        if (FontVariant != null) style.Add($"font-variant: {FontVariant?.EnumToString()}");
        if (FontFamily != null) style.Add($"font-family: {FontFamily}");
        if (Alignment != null) style.Add($"text-align: {Alignment}");
        if (TextDecoration != null) style.Add($"text-decoration: {TextDecoration?.EnumToString()}");
        if (TextTransform != null) style.Add($"text-transform: {TextTransform}");
        if (Direction != null) style.Add($"direction: {Direction}");
        if (Display != null) style.Add($"display: {Display?.EnumToString()}");
        if (Opacity != null) style.Add($"opacity: {Opacity}");

        var styleString = string.Join("; ", style);
        return styleString;
    }

    public override string ToString() {
        var styleString = GenerateStyle();
        styleString = !string.IsNullOrEmpty(styleString) ? $" style=\"{styleString}\"" : "";

        var childrenHtml = string.Join("", Children.Select(child => child.ToString()));

        var childrenParentHtml = string.Join("", this.Parent.HtmlSpans.Select(child => {
            var childStyle = child.GenerateStyle();
            childStyle = !string.IsNullOrEmpty(childStyle) ? $" style=\"{childStyle}\"" : "";
            return $"<span{childStyle}>{child.Content}</span>";
        }));

        return $"<span{styleString}>{Content}{childrenHtml}</span>{childrenParentHtml}";
    }
}
