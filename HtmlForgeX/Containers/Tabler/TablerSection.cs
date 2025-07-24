using System;

namespace HtmlForgeX;

/// <summary>
/// Represents a section container for organizing content within a Tabler page.
/// </summary>
public class TablerSection : Element {
    private string? _title;
    private HeaderLevelTag _headerLevel = HeaderLevelTag.H3;
    private TablerColor? _backgroundColor;
    private TablerSpacing? _padding;
    private TablerSpacing? _margin;
    private bool _border;
    private TablerColor? _borderColor;

    /// <summary>
    /// Initializes a new instance of the TablerSection class.
    /// </summary>
    public TablerSection() {
    }

    /// <summary>
    /// Registers the required libraries for TablerSection.
    /// </summary>
    protected internal override void RegisterLibraries() {
        Document?.AddLibrary(Libraries.Bootstrap);
        Document?.AddLibrary(Libraries.Tabler);
    }

    /// <summary>
    /// Sets the title for the section.
    /// </summary>
    public TablerSection WithTitle(string title, HeaderLevelTag level = HeaderLevelTag.H3) {
        _title = title;
        _headerLevel = level;
        return this;
    }

    /// <summary>
    /// Sets the background color for the section.
    /// </summary>
    public TablerSection WithBackgroundColor(TablerColor color) {
        _backgroundColor = color;
        return this;
    }

    /// <summary>
    /// Sets the padding for the section.
    /// </summary>
    public TablerSection WithPadding(TablerSpacing spacing) {
        _padding = spacing;
        return this;
    }

    /// <summary>
    /// Sets the margin for the section.
    /// </summary>
    public TablerSection WithMargin(TablerSpacing spacing) {
        _margin = spacing;
        return this;
    }

    /// <summary>
    /// Adds a border to the section.
    /// </summary>
    public TablerSection WithBorder(bool border = true, TablerColor? color = null) {
        _border = border;
        _borderColor = color;
        return this;
    }

    /// <summary>
    /// Adds content to the section.
    /// </summary>
    public TablerSection AddContent(Action<TablerSection> config) {
        config(this);
        return this;
    }

    /// <summary>
    /// Converts the section to its HTML representation.
    /// </summary>
    public override string ToString() {
        var container = new HtmlTag("div").Class("section");

        // Add styling classes
        if (_backgroundColor.HasValue) {
            container.Class($"bg-{_backgroundColor.Value.ToString().ToKebabCase()}");
        }

        if (_padding.HasValue) {
            container.Class($"p-{(int)_padding.Value}");
        }

        if (_margin.HasValue) {
            container.Class($"m-{(int)_margin.Value}");
        }

        if (_border) {
            container.Class("border");
            if (_borderColor.HasValue) {
                container.Class($"border-{_borderColor.Value.ToString().ToKebabCase()}");
            }
        }

        // Add title if specified
        if (!string.IsNullOrEmpty(_title)) {
            var header = new HtmlTag(_headerLevel.ToString().ToLower())
                .Class("section-title")
                .Value(_title);
            container.Value(header);
        }

        // Add all child content
        foreach (var child in Children) {
            container.Value(child);
        }

        return container.ToString();
    }
}