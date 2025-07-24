using System.Collections.Generic;

namespace HtmlForgeX;

/// <summary>
/// Represents an edge in a Vis Network diagram.
/// </summary>
public class VisNetworkEdge {
    /// <summary>
    /// Gets or sets the unique identifier of the edge.
    /// </summary>
    public object? Id { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the source node.
    /// </summary>
    public object? From { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the destination node.
    /// </summary>
    public object? To { get; set; }

    /// <summary>
    /// Gets or sets the text label shown on the edge.
    /// </summary>
    public string? Label { get; set; }

    /// <summary>
    /// Gets or sets the tooltip title for the edge.
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// Gets or sets the arrows configuration for the edge.
    /// </summary>
    public VisNetworkArrows? Arrows { get; set; }

    /// <summary>
    /// Gets or sets the color of the edge line.
    /// </summary>
    public string? Color { get; set; }

    /// <summary>
    /// Gets or sets the width of the edge line in pixels.
    /// </summary>
    public double? Width { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the edge should be drawn with dashes.
    /// </summary>
    public bool? Dashes { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the edge is hidden.
    /// </summary>
    public bool? Hidden { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether physics calculations are enabled for the edge.
    /// </summary>
    public bool? Physics { get; set; }

    /// <summary>
    /// Gets or sets the ideal length of the edge in pixels.
    /// </summary>
    public double? Length { get; set; }

    /// <summary>
    /// Gets a dictionary of custom key/value pairs that will be serialized with the edge.
    /// </summary>
    public Dictionary<string, object> Custom { get; } = new();

    /// <summary>
    /// Sets a custom property on the edge that will be included in the output dictionary.
    /// </summary>
    /// <param name="key">Property name.</param>
    /// <param name="value">Property value.</param>
    /// <returns>The current <see cref="VisNetworkEdge"/> instance.</returns>
    public VisNetworkEdge SetCustom(string key, object value) {
        Custom[key] = value;
        return this;
    }

    /// <summary>
    /// Sets the identifier of the edge.
    /// </summary>
    /// <param name="id">Identifier value.</param>
    /// <returns>The current <see cref="VisNetworkEdge"/> instance.</returns>
    public VisNetworkEdge IdValue(object id) {
        Id = id;
        return this;
    }

    /// <summary>
    /// Sets the identifier of the source node.
    /// </summary>
    /// <param name="from">Source node id.</param>
    /// <returns>The current <see cref="VisNetworkEdge"/> instance.</returns>
    public VisNetworkEdge FromNode(object from) {
        From = from;
        return this;
    }

    /// <summary>
    /// Sets the identifier of the destination node.
    /// </summary>
    /// <param name="to">Destination node id.</param>
    /// <returns>The current <see cref="VisNetworkEdge"/> instance.</returns>
    public VisNetworkEdge ToNode(object to) {
        To = to;
        return this;
    }

    /// <summary>
    /// Sets the edge label displayed in the diagram.
    /// </summary>
    /// <param name="label">Label text.</param>
    /// <returns>The current <see cref="VisNetworkEdge"/> instance.</returns>
    public VisNetworkEdge EdgeLabel(string label) {
        Label = label;
        return this;
    }

    /// <summary>
    /// Sets the edge tooltip title.
    /// </summary>
    /// <param name="title">Title text.</param>
    /// <returns>The current <see cref="VisNetworkEdge"/> instance.</returns>
    public VisNetworkEdge EdgeTitle(string title) {
        Title = title;
        return this;
    }

    /// <summary>
    /// Specifies the edge color using a hex or CSS color string.
    /// </summary>
    /// <param name="color">Color value.</param>
    /// <returns>The current <see cref="VisNetworkEdge"/> instance.</returns>
    public VisNetworkEdge EdgeColor(string color) {
        Color = color;
        return this;
    }

    /// <summary>
    /// Specifies the edge color using an <see cref="RGBColor"/> instance.
    /// </summary>
    /// <param name="color">Color value.</param>
    /// <returns>The current <see cref="VisNetworkEdge"/> instance.</returns>
    public VisNetworkEdge EdgeColor(RGBColor color) {
        Color = color.ToHex();
        return this;
    }

    /// <summary>
    /// Configures the arrows displayed on this edge.
    /// </summary>
    /// <param name="arrows">Arrow options.</param>
    /// <returns>The current <see cref="VisNetworkEdge"/> instance.</returns>
    public VisNetworkEdge EdgeArrows(VisNetworkArrows arrows) {
        Arrows = arrows;
        return this;
    }

    /// <summary>
    /// Sets the width of the edge line in pixels.
    /// </summary>
    /// <param name="width">Edge width.</param>
    /// <returns>The current <see cref="VisNetworkEdge"/> instance.</returns>
    public VisNetworkEdge EdgeWidth(double width) {
        Width = width;
        return this;
    }

    /// <summary>
    /// Enables or disables dashed line style for the edge.
    /// </summary>
    /// <param name="dashes">Value indicating whether dashes should be used.</param>
    /// <returns>The current <see cref="VisNetworkEdge"/> instance.</returns>
    public VisNetworkEdge EdgeDashes(bool dashes = true) {
        Dashes = dashes;
        return this;
    }

    /// <summary>
    /// Hides or shows the edge.
    /// </summary>
    /// <param name="hidden">True to hide the edge.</param>
    /// <returns>The current <see cref="VisNetworkEdge"/> instance.</returns>
    public VisNetworkEdge EdgeHidden(bool hidden = true) {
        Hidden = hidden;
        return this;
    }

    /// <summary>
    /// Enables or disables physics calculations for the edge.
    /// </summary>
    /// <param name="physics">True to enable physics.</param>
    /// <returns>The current <see cref="VisNetworkEdge"/> instance.</returns>
    public VisNetworkEdge EdgePhysics(bool physics = true) {
        Physics = physics;
        return this;
    }

    /// <summary>
    /// Specifies the ideal length of the edge in pixels.
    /// </summary>
    /// <param name="length">Length value.</param>
    /// <returns>The current <see cref="VisNetworkEdge"/> instance.</returns>
    public VisNetworkEdge EdgeLength(double length) {
        Length = length;
        return this;
    }

    internal Dictionary<string, object> ToDictionary() {
        var dict = new Dictionary<string, object>(Custom);
        if (Id != null) dict["id"] = Id;
        if (From != null) dict["from"] = From;
        if (To != null) dict["to"] = To;
        if (Label != null) dict["label"] = Label;
        if (Title != null) dict["title"] = Title;
        if (Arrows != null && Arrows != VisNetworkArrows.None) dict["arrows"] = Arrows.Value.EnumToString();
        if (Color != null) dict["color"] = Color;
        if (Width != null) dict["width"] = Width;
        if (Dashes != null) dict["dashes"] = Dashes;
        if (Hidden != null) dict["hidden"] = Hidden;
        if (Physics != null) dict["physics"] = Physics;
        if (Length != null) dict["length"] = Length;
        return dict;
    }
}