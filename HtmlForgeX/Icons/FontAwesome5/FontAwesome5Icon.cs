using System.Collections.Generic;

namespace HtmlForgeX;

/// <summary>
/// FontAwesome 5 icon component for displaying icons anywhere in HtmlForgeX
/// </summary>
public class FontAwesome5Icon : Element {
    private FontAwesome5Style _style = FontAwesome5Style.Solid;
    private string? _iconCode;
    private string? _iconName;
    private string? _size;
    private string? _color;
    private bool _fixedWidth;
    private bool _spin;
    private bool _pulse;
    private string? _rotate;
    private string? _flip;
    private bool _border;
    private string? _pull;
    private readonly List<string> _additionalClasses = new();

    /// <summary>
    /// Creates a new FontAwesome 5 icon component
    /// </summary>
    public FontAwesome5Icon() {
        RegisterLibraries();
    }

    /// <summary>
    /// Creates a FontAwesome 5 icon with a solid icon
    /// </summary>
    public FontAwesome5Icon(FontAwesome5Solid icon) : this() {
        WithIcon(icon);
    }

    /// <summary>
    /// Creates a FontAwesome 5 icon with a regular icon
    /// </summary>
    public FontAwesome5Icon(FontAwesome5Regular icon) : this() {
        WithIcon(icon);
    }

    /// <summary>
    /// Creates a FontAwesome 5 icon with a brand icon
    /// </summary>
    public FontAwesome5Icon(FontAwesome5Brands icon) : this() {
        WithIcon(icon);
    }

    /// <summary>
    /// Registers the required FontAwesome 5 libraries with the current document.
    /// </summary>
    protected internal override void RegisterLibraries() {
        // Register FontAwesome 5 Free
        if (Document != null) {
            Document.AddLibrary(Libraries.FontAwesome5);
        }
    }

    /// <summary>
    /// Sets a solid icon
    /// </summary>
    public FontAwesome5Icon WithIcon(FontAwesome5Solid icon) {
        _style = FontAwesome5Style.Solid;
        _iconCode = icon.GetCode();
        _iconName = icon.GetIconName();
        return this;
    }

    /// <summary>
    /// Sets a regular icon
    /// </summary>
    public FontAwesome5Icon WithIcon(FontAwesome5Regular icon) {
        _style = FontAwesome5Style.Regular;
        _iconCode = icon.GetCode();
        _iconName = icon.GetIconName();
        return this;
    }

    /// <summary>
    /// Sets a brand icon
    /// </summary>
    public FontAwesome5Icon WithIcon(FontAwesome5Brands icon) {
        _style = FontAwesome5Style.Brands;
        _iconCode = icon.GetCode();
        _iconName = icon.GetIconName();
        return this;
    }

    /// <summary>
    /// Sets the icon by Unicode code (for backward compatibility or custom icons)
    /// </summary>
    public FontAwesome5Icon WithCode(string code, FontAwesome5Style style = FontAwesome5Style.Solid) {
        _iconCode = code;
        _style = style;
        return this;
    }

    /// <summary>
    /// Sets the icon size using FontAwesome size classes
    /// </summary>
    public FontAwesome5Icon WithSize(FontAwesomeSize size) {
        _size = size switch {
            FontAwesomeSize.ExtraSmall => "fa-xs",
            FontAwesomeSize.Small => "fa-sm",
            FontAwesomeSize.Large => "fa-lg",
            FontAwesomeSize.X2 => "fa-2x",
            FontAwesomeSize.X3 => "fa-3x",
            FontAwesomeSize.X4 => "fa-4x",
            FontAwesomeSize.X5 => "fa-5x",
            FontAwesomeSize.X6 => "fa-6x",
            FontAwesomeSize.X7 => "fa-7x",
            FontAwesomeSize.X8 => "fa-8x",
            FontAwesomeSize.X9 => "fa-9x",
            FontAwesomeSize.X10 => "fa-10x",
            _ => null
        };
        return this;
    }

    /// <summary>
    /// Sets the icon color
    /// </summary>
    public FontAwesome5Icon WithColor(string color) {
        _color = color;
        return this;
    }

    /// <summary>
    /// Sets the icon color using RGB values
    /// </summary>
    public FontAwesome5Icon WithColor(RGBColor color) {
        _color = color.ToHex();
        return this;
    }

    /// <summary>
    /// Makes the icon fixed width
    /// </summary>
    public FontAwesome5Icon WithFixedWidth(bool fixedWidth = true) {
        _fixedWidth = fixedWidth;
        return this;
    }

    /// <summary>
    /// Makes the icon spin continuously
    /// </summary>
    public FontAwesome5Icon WithSpin(bool spin = true) {
        _spin = spin;
        return this;
    }

    /// <summary>
    /// Makes the icon pulse (8-step rotation)
    /// </summary>
    public FontAwesome5Icon WithPulse(bool pulse = true) {
        _pulse = pulse;
        return this;
    }

    /// <summary>
    /// Rotates the icon
    /// </summary>
    public FontAwesome5Icon WithRotate(FontAwesome5Rotate rotate) {
        _rotate = rotate switch {
            FontAwesome5Rotate.Rotate90 => "fa-rotate-90",
            FontAwesome5Rotate.Rotate180 => "fa-rotate-180",
            FontAwesome5Rotate.Rotate270 => "fa-rotate-270",
            _ => null
        };
        return this;
    }

    /// <summary>
    /// Flips the icon
    /// </summary>
    public FontAwesome5Icon WithFlip(FontAwesome5Flip flip) {
        _flip = flip switch {
            FontAwesome5Flip.Horizontal => "fa-flip-horizontal",
            FontAwesome5Flip.Vertical => "fa-flip-vertical",
            _ => null
        };
        return this;
    }

    /// <summary>
    /// Adds a border around the icon
    /// </summary>
    public FontAwesome5Icon WithBorder(bool border = true) {
        _border = border;
        return this;
    }

    /// <summary>
    /// Pulls the icon to the left or right
    /// </summary>
    public FontAwesome5Icon WithPull(FontAwesome5Pull pull) {
        _pull = pull switch {
            FontAwesome5Pull.Left => "fa-pull-left",
            FontAwesome5Pull.Right => "fa-pull-right",
            _ => null
        };
        return this;
    }

    /// <summary>
    /// Adds custom CSS class to the icon
    /// </summary>
    public FontAwesome5Icon WithClass(string className) {
        if (!string.IsNullOrWhiteSpace(className)) {
            _additionalClasses.Add(className);
        }
        return this;
    }

    /// <summary>
    /// Generates the HTML markup for the configured FontAwesome 5 icon.
    /// </summary>
    /// <returns>String representation of the icon element.</returns>
    public override string ToString() {
        var tag = new HtmlTag("i");
        var classes = new List<string>();
        
        // Add style prefix
        classes.Add(_style.GetClassPrefix());
        
        // Add icon class
        if (!string.IsNullOrEmpty(_iconName)) {
            // Convert enum name to FontAwesome class name (e.g., User -> fa-user)
            classes.Add($"fa-{_iconName}");
        }
        // Note: When using WithCode(), we don't add the fa-iconname class
        // because we don't have the icon name, only the Unicode
        
        // Add size class
        if (!string.IsNullOrEmpty(_size)) {
            classes.Add(_size!);
        }
        
        // Add modifier classes
        if (_fixedWidth) classes.Add("fa-fw");
        if (_spin) classes.Add("fa-spin");
        if (_pulse) classes.Add("fa-pulse");
        if (!string.IsNullOrEmpty(_rotate)) classes.Add(_rotate!);
        if (!string.IsNullOrEmpty(_flip)) classes.Add(_flip!);
        if (_border) classes.Add("fa-border");
        if (!string.IsNullOrEmpty(_pull)) classes.Add(_pull!);
        
        // Add custom classes
        classes.AddRange(_additionalClasses);
        
        // Set all classes
        tag.Class(string.Join(" ", classes));
        
        // Add inline styles
        var styles = new List<string>();
        if (!string.IsNullOrEmpty(_color)) {
            styles.Add($"color: {_color}");
        }
        
        if (styles.Count > 0) {
            foreach (var style in styles) {
                var parts = style.Split(new[] { ':' }, 2);
                if (parts.Length == 2) {
                    tag.Style(parts[0].Trim(), parts[1].Trim());
                }
            }
        }
        
        // When using WithCode(), add the Unicode as content via CSS pseudo-element
        if (!string.IsNullOrEmpty(_iconCode) && string.IsNullOrEmpty(_iconName)) {
            // Add the Unicode character as text content for Font Awesome to render
            tag.Text(_iconCode);
        }
        
        return tag.ToString();
    }


}