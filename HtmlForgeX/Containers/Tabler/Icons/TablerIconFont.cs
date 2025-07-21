using System.Collections.Generic;

namespace HtmlForgeX;

/// <summary>
/// Tabler icon component using webfont (class: ti ti-{icon-name})
/// Provides an alternative to SVG-based icons for better performance with many icons
/// </summary>
public class TablerIconFont : Element {
    private readonly string _iconName;
    private string? _size;
    private string? _color;
    private readonly List<string> _additionalClasses = new();
    private readonly Dictionary<string, string> _styles = new();

    /// <summary>
    /// Creates a new Tabler font icon component
    /// </summary>
    public TablerIconFont(string iconName) {
        _iconName = iconName;
        RegisterLibraries();
    }

    /// <summary>
    /// Creates a new Tabler font icon component from enum
    /// </summary>
    public TablerIconFont(TablerIconType icon) {
        _iconName = GetIconName(icon);
        RegisterLibraries();
    }

    /// <summary>
    /// Registers the required Tabler Icons font library with the current document.
    /// </summary>
    protected internal override void RegisterLibraries() {
        if (Document != null) {
            Document.AddLibrary(Libraries.TablerIconsFont);
        }
    }

    /// <summary>
    /// Sets the icon size
    /// </summary>
    public TablerIconFont WithSize(string size) {
        _size = size;
        return this;
    }

    /// <summary>
    /// Sets the icon color
    /// </summary>
    public TablerIconFont WithColor(RGBColor color) {
        _color = color.ToHex();
        return this;
    }

    /// <summary>
    /// Sets the icon color using hex string
    /// </summary>
    public TablerIconFont WithColor(string color) {
        _color = color;
        return this;
    }

    /// <summary>
    /// Adds custom CSS class to the icon
    /// </summary>
    public TablerIconFont WithClass(string className) {
        if (!string.IsNullOrWhiteSpace(className)) {
            _additionalClasses.Add(className);
        }
        return this;
    }

    /// <summary>
    /// Adds custom CSS style
    /// </summary>
    public TablerIconFont WithStyle(string property, string value) {
        _styles[property] = value;
        return this;
    }

    /// <summary>
    /// Gets the icon name from the enum
    /// </summary>
    private static string GetIconName(TablerIconType icon) {
        // Convert enum name to kebab-case
        var name = icon.ToString();
        var result = "";
        for (int i = 0; i < name.Length; i++) {
            if (i > 0 && char.IsUpper(name[i])) {
                result += "-";
            }
            result += char.ToLower(name[i]);
        }
        return result;
    }

    /// <summary>
    /// Generates the HTML markup for the Tabler font icon
    /// </summary>
    public override string ToString() {
        var tag = new HtmlTag("i");
        var classes = new List<string> { "ti", $"ti-{_iconName}" };
        
        // Add custom classes
        classes.AddRange(_additionalClasses);
        
        // Set all classes
        tag.Class(string.Join(" ", classes));
        
        // Add inline styles
        if (!string.IsNullOrEmpty(_size)) {
            _styles["font-size"] = _size;
        }
        
        if (!string.IsNullOrEmpty(_color)) {
            _styles["color"] = _color;
        }
        
        foreach (var style in _styles) {
            tag.Style(style.Key, style.Value);
        }
        
        return tag.ToString();
    }
}