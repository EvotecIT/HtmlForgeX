using System.Collections.Generic;
using System.Text;
using System.Linq;
using HtmlForgeX.Extensions;

namespace HtmlForgeX;


/// <summary>
/// Represents an SVG icon with full styling and positioning flexibility
/// </summary>
public class TablerIcon : Element {
    public string SvgContent { get; set; }
    public Dictionary<string, string> SvgAttributes { get; set; } = new Dictionary<string, string>();
    public Dictionary<string, string> SvgStyles { get; set; } = new Dictionary<string, string>();
    public Dictionary<string, string> ContainerStyles { get; set; } = new Dictionary<string, string>();
    public string ContainerClasses { get; set; } = "";

    public TablerIcon(string svgContent) {
        SvgContent = svgContent;
        // Set default viewBox and size
        SvgAttributes["viewBox"] = "0 0 24 24";
        SvgAttributes["width"] = "24";
        SvgAttributes["height"] = "24";
        SvgAttributes["fill"] = "none";
        SvgAttributes["stroke"] = "currentColor";
        SvgAttributes["stroke-width"] = "2";
        SvgAttributes["stroke-linecap"] = "round";
        SvgAttributes["stroke-linejoin"] = "round";
    }

    /// <summary>
    /// Set the icon size (width and height)
    /// </summary>
    public TablerIcon Size(int size) {
        SvgAttributes["width"] = size.ToString();
        SvgAttributes["height"] = size.ToString();
        return this;
    }

    /// <summary>
    /// Set the icon size with different width and height
    /// </summary>
    public TablerIcon Size(int width, int height) {
        SvgAttributes["width"] = width.ToString();
        SvgAttributes["height"] = height.ToString();
        return this;
    }

    /// <summary>
    /// Set the stroke color
    /// </summary>
    public TablerIcon StrokeColor(RGBColor color) {
        SvgAttributes["stroke"] = color.ToHex();
        return this;
    }

    /// <summary>
    /// Set the fill color
    /// </summary>
    public TablerIcon FillColor(RGBColor color) {
        SvgAttributes["fill"] = color.ToHex();
        return this;
    }

    /// <summary>
    /// Set the stroke width
    /// </summary>
    public TablerIcon StrokeWidth(double width) {
        SvgAttributes["stroke-width"] = width.ToString();
        return this;
    }

    /// <summary>
    /// Set custom SVG attribute
    /// </summary>
    public TablerIcon SetAttribute(string name, string value) {
        SvgAttributes[name] = value;
        return this;
    }

    /// <summary>
    /// Add CSS styles to the SVG element
    /// </summary>
    public TablerIcon AddStyle(string property, string value) {
        SvgStyles[property] = value;
        return this;
    }

    /// <summary>
    /// Add CSS styles to the container div
    /// </summary>
    public TablerIcon AddContainerStyle(string property, string value) {
        ContainerStyles[property] = value;
        return this;
    }

    /// <summary>
    /// Set container CSS classes
    /// </summary>
    public TablerIcon SetContainerClasses(string classes) {
        ContainerClasses = classes;
        return this;
    }

    /// <summary>
    /// Position the icon absolutely
    /// </summary>
    public TablerIcon Position(string position, string top = null, string right = null, string bottom = null, string left = null) {
        ContainerStyles["position"] = position;
        if (top != null) ContainerStyles["top"] = top;
        if (right != null) ContainerStyles["right"] = right;
        if (bottom != null) ContainerStyles["bottom"] = bottom;
        if (left != null) ContainerStyles["left"] = left;
        return this;
    }

    /// <summary>
    /// Add margin to the container
    /// </summary>
    public TablerIcon Margin(string margin) {
        ContainerStyles["margin"] = margin;
        return this;
    }

    /// <summary>
    /// Add padding to the container
    /// </summary>
    public TablerIcon Padding(string padding) {
        ContainerStyles["padding"] = padding;
        return this;
    }

    /// <summary>
    /// Set display property
    /// </summary>
    public TablerIcon Display(string display) {
        ContainerStyles["display"] = display;
        return this;
    }

    /// <summary>
    /// Set vertical alignment
    /// </summary>
    public TablerIcon VerticalAlign(string alignment) {
        ContainerStyles["vertical-align"] = alignment;
        return this;
    }

    /// <summary>
    /// Add transform to the SVG
    /// </summary>
    public TablerIcon Transform(string transform) {
        SvgStyles["transform"] = transform;
        return this;
    }

    /// <summary>
    /// Rotate the icon
    /// </summary>
    public TablerIcon Rotate(int degrees) {
        SvgStyles["transform"] = $"rotate({degrees}deg)";
        return this;
    }

    /// <summary>
    /// Scale the icon
    /// </summary>
    public TablerIcon Scale(double scale) {
        SvgStyles["transform"] = $"scale({scale})";
        return this;
    }

    /// <summary>
    /// Add hover effects
    /// </summary>
    public TablerIcon AddHoverEffect(string property, string value) {
        // This would need CSS to be added to the document head
        // For now, we'll add it as a data attribute for custom CSS handling
        SetAttribute($"data-hover-{property}", value);
        return this;
    }

    public override string ToString() {
        var container = new HtmlTag("span");

        // Add container classes and styles
        if (!string.IsNullOrEmpty(ContainerClasses)) {
            container.Class(ContainerClasses);
        }

        foreach (var style in ContainerStyles.WhereNotNull()) {
            container.Style(style.Key, style.Value);
        }

        // Create the SVG element
        var svg = new HtmlTag("svg");

        // Add all SVG attributes
        foreach (var attr in SvgAttributes.WhereNotNull()) {
            svg.Attribute(attr.Key, attr.Value);
        }

        // Add SVG styles
        if (SvgStyles.Count > 0) {
            var styleBuilder = new StringBuilder();
            foreach (var style in SvgStyles.WhereNotNull()) {
                styleBuilder.Append($"{style.Key}:{style.Value};");
            }
            svg.Attribute("style", styleBuilder.ToString());
        }

        // Add the SVG content as raw HTML (not encoded)
        svg.Value(new RawHtml(SvgContent));

        container.Value(svg);

        return container.ToString();
    }
}