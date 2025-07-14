using System.Collections.Generic;

namespace HtmlForgeX;

/// <summary>
/// Represents an edge in a Vis Network diagram.
/// </summary>
public class VisNetworkEdge {
    public object? Id { get; set; }
    public object? From { get; set; }
    public object? To { get; set; }
    public string? Label { get; set; }
    public string? Title { get; set; }
    public VisNetworkArrows? Arrows { get; set; }
    public string? Color { get; set; }
    public double? Width { get; set; }
    public bool? Dashes { get; set; }
    public bool? Hidden { get; set; }
    public bool? Physics { get; set; }
    public double? Length { get; set; }
    public Dictionary<string, object> Custom { get; } = new();

    public VisNetworkEdge SetCustom(string key, object value) {
        Custom[key] = value;
        return this;
    }

    public VisNetworkEdge IdValue(object id) {
        Id = id;
        return this;
    }

    public VisNetworkEdge FromNode(object from) {
        From = from;
        return this;
    }

    public VisNetworkEdge ToNode(object to) {
        To = to;
        return this;
    }

    public VisNetworkEdge EdgeLabel(string label) {
        Label = label;
        return this;
    }

    public VisNetworkEdge EdgeTitle(string title) {
        Title = title;
        return this;
    }

    public VisNetworkEdge EdgeColor(string color) {
        Color = color;
        return this;
    }

    public VisNetworkEdge EdgeColor(RGBColor color) {
        Color = color.ToHex();
        return this;
    }

    public VisNetworkEdge EdgeArrows(VisNetworkArrows arrows) {
        Arrows = arrows;
        return this;
    }

    public VisNetworkEdge EdgeWidth(double width) {
        Width = width;
        return this;
    }

    public VisNetworkEdge EdgeDashes(bool dashes = true) {
        Dashes = dashes;
        return this;
    }

    public VisNetworkEdge EdgeHidden(bool hidden = true) {
        Hidden = hidden;
        return this;
    }

    public VisNetworkEdge EdgePhysics(bool physics = true) {
        Physics = physics;
        return this;
    }

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
