using System;
using System.Text;

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

    public HtmlSpan AppendContent(string content) {
        var newSpan = new HtmlSpan(this) {
            Content = content
        };
        this.Parent.HtmlSpans.Add(newSpan);  // Add to children of this span
        return newSpan;  // Return new span for modification
    }

    public HtmlSpan AddContent(string content) {
        var newSpan = new HtmlSpan { Content = content };
        this.Add(newSpan);  // Add to children of this HtmlElement
        return newSpan;  // Return new span for modification
    }

    public HtmlSpan Add(string content) {
        var newSpan = new HtmlSpan { Content = content };
        this.Add(newSpan);  // Add to children of this HtmlElement
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

        var childrenHtml = string.Join("", Children.Select(child => child.ToString()));

        var childrenParentHtml = string.Join("", this.Parent.HtmlSpans.Select(child => {
            var childStyle = child.GenerateStyle();
            childStyle = !string.IsNullOrEmpty(childStyle) ? $" style=\"{childStyle}\"" : "";
            return $"<span{childStyle}>{child.Content}</span>";
        }));

        return $"<span{styleString}>{Content}{childrenHtml}</span>{childrenParentHtml}";
    }
}
