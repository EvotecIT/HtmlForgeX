using System.Collections.Generic;

namespace HtmlForgeX;

/// <summary>
/// FontAwesome icon component for displaying icons anywhere in HtmlForgeX
/// </summary>
public class FontAwesomeIcon : Element {
    private FontAwesomeStyle _style = FontAwesomeStyle.Solid;
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
    /// Creates a new FontAwesome icon component
    /// </summary>
    public FontAwesomeIcon() {
        RegisterLibraries();
    }

    /// <summary>
    /// Creates a FontAwesome icon with a solid icon
    /// </summary>
    public FontAwesomeIcon(FontAwesomeSolid icon) : this() {
        WithIcon(icon);
    }

    /// <summary>
    /// Creates a FontAwesome icon with a regular icon
    /// </summary>
    public FontAwesomeIcon(FontAwesomeRegular icon) : this() {
        WithIcon(icon);
    }

    /// <summary>
    /// Creates a FontAwesome icon with a brand icon
    /// </summary>
    public FontAwesomeIcon(FontAwesomeBrands icon) : this() {
        WithIcon(icon);
    }

    protected internal override void RegisterLibraries() {
        // Register FontAwesome 6 Free
        if (Document != null) {
            Document.AddLibrary(Libraries.FontAwesome6);
        }
    }

    /// <summary>
    /// Sets a solid icon
    /// </summary>
    public FontAwesomeIcon WithIcon(FontAwesomeSolid icon) {
        _style = FontAwesomeStyle.Solid;
        _iconCode = icon.GetCode();
        _iconName = ConvertEnumNameToFontAwesome(icon.ToString());
        return this;
    }

    /// <summary>
    /// Sets a regular icon
    /// </summary>
    public FontAwesomeIcon WithIcon(FontAwesomeRegular icon) {
        _style = FontAwesomeStyle.Regular;
        _iconCode = icon.GetCode();
        _iconName = ConvertEnumNameToFontAwesome(icon.ToString());
        return this;
    }

    /// <summary>
    /// Sets a brand icon
    /// </summary>
    public FontAwesomeIcon WithIcon(FontAwesomeBrands icon) {
        _style = FontAwesomeStyle.Brands;
        _iconCode = icon.GetCode();
        _iconName = ConvertEnumNameToFontAwesome(icon.ToString());
        return this;
    }

    /// <summary>
    /// Sets the icon by Unicode code (for backward compatibility or custom icons)
    /// </summary>
    public FontAwesomeIcon WithCode(string code, FontAwesomeStyle style = FontAwesomeStyle.Solid) {
        _iconCode = code;
        _style = style;
        return this;
    }

    /// <summary>
    /// Sets the icon size using FontAwesome size classes
    /// </summary>
    public FontAwesomeIcon WithSize(FontAwesomeSize size) {
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
    public FontAwesomeIcon WithColor(RGBColor color) {
        _color = color.ToHex();
        return this;
    }

    /// <summary>
    /// Sets the icon color using hex string
    /// </summary>
    public FontAwesomeIcon WithColor(string color) {
        _color = color;
        return this;
    }

    /// <summary>
    /// Makes the icon fixed width
    /// </summary>
    public FontAwesomeIcon WithFixedWidth(bool fixedWidth = true) {
        _fixedWidth = fixedWidth;
        return this;
    }

    /// <summary>
    /// Makes the icon spin
    /// </summary>
    public FontAwesomeIcon WithSpin(bool spin = true) {
        _spin = spin;
        return this;
    }

    /// <summary>
    /// Makes the icon pulse (8-step rotation)
    /// </summary>
    public FontAwesomeIcon WithPulse(bool pulse = true) {
        _pulse = pulse;
        return this;
    }

    /// <summary>
    /// Rotates the icon
    /// </summary>
    public FontAwesomeIcon WithRotate(int degrees) {
        _rotate = degrees switch {
            90 => "fa-rotate-90",
            180 => "fa-rotate-180",
            270 => "fa-rotate-270",
            _ => null
        };
        return this;
    }

    /// <summary>
    /// Flips the icon
    /// </summary>
    public FontAwesomeIcon WithFlip(FontAwesomeFlip flip) {
        _flip = flip switch {
            FontAwesomeFlip.Horizontal => "fa-flip-horizontal",
            FontAwesomeFlip.Vertical => "fa-flip-vertical",
            FontAwesomeFlip.Both => "fa-flip-both",
            _ => null
        };
        return this;
    }

    /// <summary>
    /// Adds a border around the icon
    /// </summary>
    public FontAwesomeIcon WithBorder(bool border = true) {
        _border = border;
        return this;
    }

    /// <summary>
    /// Pulls the icon to left or right
    /// </summary>
    public FontAwesomeIcon WithPull(FontAwesomePull pull) {
        _pull = pull switch {
            FontAwesomePull.Left => "fa-pull-left",
            FontAwesomePull.Right => "fa-pull-right",
            _ => null
        };
        return this;
    }

    /// <summary>
    /// Adds custom CSS class to the icon
    /// </summary>
    public FontAwesomeIcon WithClass(string className) {
        if (!string.IsNullOrWhiteSpace(className)) {
            _additionalClasses.Add(className);
        }
        return this;
    }

    public override string ToString() {
        var tag = new HtmlTag("i");
        var classes = new List<string>();
        
        // Add style prefix
        classes.Add(_style.GetClassPrefix());
        
        // Add icon class
        if (!string.IsNullOrEmpty(_iconName)) {
            // Convert enum name to FontAwesome class name (e.g., User -> fa-user)
            classes.Add($"fa-{_iconName}");
        } else if (!string.IsNullOrEmpty(_iconCode)) {
            // Fallback to code mapping for backward compatibility
            var iconName = GetIconNameFromCode(_iconCode);
            if (!string.IsNullOrEmpty(iconName)) {
                classes.Add($"fa-{iconName}");
            }
        }
        
        // Add size class
        if (!string.IsNullOrEmpty(_size)) {
            classes.Add(_size);
        }
        
        // Add modifier classes
        if (_fixedWidth) classes.Add("fa-fw");
        if (_spin) classes.Add("fa-spin");
        if (_pulse) classes.Add("fa-pulse");
        if (!string.IsNullOrEmpty(_rotate)) classes.Add(_rotate);
        if (!string.IsNullOrEmpty(_flip)) classes.Add(_flip);
        if (_border) classes.Add("fa-border");
        if (!string.IsNullOrEmpty(_pull)) classes.Add(_pull);
        
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
        
        // For compatibility with older FontAwesome or custom implementations,
        // we can also add the Unicode as a data attribute
        if (!string.IsNullOrEmpty(_iconCode)) {
            tag.Attribute("data-icon", _iconCode);
        }
        
        return tag.ToString();
    }

    private string GetIconNameFromCode(string code) {
        // Map common Unicode values to icon names
        // This is a subset - a full implementation would have complete mappings
        return code switch {
            "\uf007" => "user",
            "\uf0c0" => "users",
            "\uf233" => "server",
            "\uf1c0" => "database",
            "\uf023" => "lock",
            "\uf09c" => "unlock",
            "\uf0c2" => "cloud",
            "\uf015" => "home",
            "\uf013" => "cog",
            "\uf085" => "cogs",
            "\uf0e0" => "envelope",
            "\uf095" => "phone",
            "\uf002" => "search",
            "\uf00c" => "check",
            "\uf00d" => "times",
            "\uf067" => "plus",
            "\uf068" => "minus",
            "\uf058" => "check-circle",
            "\uf057" => "times-circle",
            "\uf059" => "info-circle",
            "\uf06a" => "exclamation-circle",
            "\uf071" => "exclamation-triangle",
            "\uf128" => "question",
            "\uf129" => "question-circle",
            "\uf017" => "clock",
            "\uf073" => "calendar",
            "\uf133" => "calendar-alt",
            "\uf15b" => "file",
            "\uf15c" => "file-alt",
            "\uf07b" => "folder",
            "\uf07c" => "folder-open",
            "\uf1f8" => "trash",
            "\uf2ed" => "trash-alt",
            "\uf044" => "edit",
            "\uf040" => "pencil",
            "\uf303" => "pencil-alt",
            "\uf0c5" => "copy",
            "\uf0c7" => "save",
            "\uf019" => "download",
            "\uf093" => "upload",
            "\uf021" => "sync",
            "\uf074" => "random",
            "\uf06e" => "eye",
            "\uf070" => "eye-slash",
            "\uf041" => "map-marker",
            "\uf3c5" => "map-marker-alt",
            "\uf124" => "location-arrow",
            "\uf0ac" => "globe",
            "\uf0f3" => "bell",
            "\uf02e" => "bookmark",
            "\uf004" => "heart",
            "\uf005" => "star",
            "\uf089" => "star-half",
            "\uf118" => "smile",
            "\uf119" => "meh",
            "\uf11a" => "frown",
            "\uf080" => "chart-bar",
            "\uf201" => "chart-line",
            "\uf200" => "chart-pie",
            "\uf1fe" => "chart-area",
            "\uf0eb" => "lightbulb",
            "\uf108" => "desktop",
            "\uf109" => "laptop",
            "\uf10a" => "tablet",
            "\uf10b" => "mobile",
            "\uf3cd" => "mobile-alt",
            "\uf1e0" => "share",
            "\uf14d" => "share-alt",
            "\uf045" => "share-square",
            "\uf064" => "share-nodes",
            "\uf0a0" => "hdd",
            "\uf025" => "volume-off",
            "\uf026" => "volume-down",
            "\uf027" => "volume-up",
            "\uf028" => "volume-mute",
            "\uf04b" => "play",
            "\uf04c" => "pause",
            "\uf04d" => "stop",
            "\uf04e" => "forward",
            "\uf049" => "backward",
            "\uf050" => "fast-forward",
            "\uf04a" => "fast-backward",
            "\uf0b0" => "filter",
            "\uf0ca" => "list-ul",
            "\uf0cb" => "list-ol",
            "\uf0ce" => "table",
            "\uf0db" => "columns",
            "\uf0dc" => "sort",
            "\uf15d" => "sort-down",
            "\uf15e" => "sort-up",
            "\uf1de" => "sliders",
            "\uf024" => "flag",
            "\uf11e" => "flag-checkered",
            "\uf0c3" => "flask",
            "\uf1b9" => "car",
            "\uf1ba" => "taxi",
            "\uf238" => "train",
            "\uf072" => "plane",
            "\uf21a" => "ship",
            "\uf197" => "space-shuttle",
            "\uf0d1" => "truck",
            "\uf21c" => "motorcycle",
            "\uf245" => "bus",
            "\uf1bd" => "bicycle",
            "\uf018" => "road",
            _ => string.Empty // Return empty for unknown codes
        };
    }
    
    private string ConvertEnumNameToFontAwesome(string enumName) {
        // Convert C# enum naming to FontAwesome naming
        // e.g., UserTie -> user-tie, FileAlt -> file-alt
        var result = System.Text.RegularExpressions.Regex.Replace(
            enumName, 
            "(?<!^)(?=[A-Z])", 
            "-"
        ).ToLowerInvariant();
        
        // Handle special cases
        return result switch {
            "linked-in-in" => "linkedin-in",
            "linked-in" => "linkedin",
            "git-hub" => "github",
            "git-lab" => "gitlab",
            "bit-bucket" => "bitbucket",
            "stack-overflow" => "stack-overflow",
            "you-tube" => "youtube",
            "pay-pal" => "paypal",
            "git-alt" => "git-alt",
            "js" => "js",
            "cc-visa" => "cc-visa",
            "cc-mastercard" => "cc-mastercard",
            "cc-amex" => "cc-amex",
            _ => result
        };
    }
}

/// <summary>
/// FontAwesome icon sizes
/// </summary>
public enum FontAwesomeSize {
    /// <summary>
    /// Default size
    /// </summary>
    Normal,
    
    /// <summary>
    /// Extra small (0.75em)
    /// </summary>
    ExtraSmall,
    
    /// <summary>
    /// Small (0.875em)
    /// </summary>
    Small,
    
    /// <summary>
    /// Large (1.33em)
    /// </summary>
    Large,
    
    /// <summary>
    /// 2x size
    /// </summary>
    X2,
    
    /// <summary>
    /// 3x size
    /// </summary>
    X3,
    
    /// <summary>
    /// 4x size
    /// </summary>
    X4,
    
    /// <summary>
    /// 5x size
    /// </summary>
    X5,
    
    /// <summary>
    /// 6x size
    /// </summary>
    X6,
    
    /// <summary>
    /// 7x size
    /// </summary>
    X7,
    
    /// <summary>
    /// 8x size
    /// </summary>
    X8,
    
    /// <summary>
    /// 9x size
    /// </summary>
    X9,
    
    /// <summary>
    /// 10x size
    /// </summary>
    X10
}

/// <summary>
/// FontAwesome flip options
/// </summary>
public enum FontAwesomeFlip {
    /// <summary>
    /// No flip
    /// </summary>
    None,
    
    /// <summary>
    /// Flip horizontally
    /// </summary>
    Horizontal,
    
    /// <summary>
    /// Flip vertically
    /// </summary>
    Vertical,
    
    /// <summary>
    /// Flip both horizontally and vertically
    /// </summary>
    Both
}

/// <summary>
/// FontAwesome pull options for text wrapping
/// </summary>
public enum FontAwesomePull {
    /// <summary>
    /// No pull
    /// </summary>
    None,
    
    /// <summary>
    /// Pull to left with text wrapping
    /// </summary>
    Left,
    
    /// <summary>
    /// Pull to right with text wrapping
    /// </summary>
    Right
}