namespace HtmlForgeX.Containers.Tabler
{
    /// <summary>
    /// Tabler button component with full customization options
    /// </summary>
    public class TablerButton : Element
    {
        private string _text;
        private string? _href;
        private TablerButtonVariant _variant = TablerButtonVariant.Primary;
        private TablerButtonSize _size = TablerButtonSize.Default;
        private TablerIconType? _icon;
        private TablerIconPosition _iconPosition = TablerIconPosition.Left;
        private bool _iconOnly = false;
        private bool _disabled = false;
        private bool _loading = false;
        private bool _block = false;
        private bool _ghost = false;
        private string? _onClick;
        private string? _tooltip;
        private string? _type;

        /// <summary>
        /// Gets the current button variant
        /// </summary>
        public TablerButtonVariant CurrentVariant => _variant;

        /// <summary>
        /// Initializes a new instance of the TablerButton class with text
        /// </summary>
        /// <param name="text">The button text</param>
        public TablerButton(string text) : base()
        {
            _text = text;
        }

        /// <summary>
        /// Initializes a new instance of the TablerButton class as a link button
        /// </summary>
        /// <param name="text">The button text</param>
        /// <param name="href">The URL to navigate to</param>
        public TablerButton(string text, string href) : base()
        {
            _text = text;
            _href = href;
        }

        /// <summary>
        /// Initializes a new instance of the TablerButton class with text and variant
        /// </summary>
        /// <param name="text">The button text</param>
        /// <param name="variant">The button variant</param>
        public TablerButton(string text, TablerButtonVariant variant) : this(text)
        {
            Variant(variant);
        }

        /// <summary>
        /// Initializes a new instance of the TablerButton class as a link button with variant
        /// </summary>
        /// <param name="text">The button text</param>
        /// <param name="href">The URL to navigate to</param>
        /// <param name="variant">The button variant</param>
        public TablerButton(string text, string href, TablerButtonVariant variant) : this(text, href)
        {
            Variant(variant);
        }

        /// <summary>
        /// Registers the required libraries for this component
        /// </summary>
        protected internal override void RegisterLibraries()
        {
            if (Document != null)
            {
                Document.AddLibrary(Libraries.Tabler);
                if (_icon.HasValue)
                {
                    Document.AddLibrary(Libraries.TablerIcon);
                }
            }
        }

        /// <summary>
        /// Set button variant (color scheme)
        /// </summary>
        public TablerButton Variant(TablerButtonVariant variant)
        {
            _variant = variant;
            return this;
        }

        /// <summary>
        /// Set button size
        /// </summary>
        public TablerButton Size(TablerButtonSize size)
        {
            _size = size;
            return this;
        }

        /// <summary>
        /// Add icon to button
        /// </summary>
        public TablerButton Icon(TablerIconType icon, TablerIconPosition position = TablerIconPosition.Left)
        {
            _icon = icon;
            _iconPosition = position;
            return this;
        }

        /// <summary>
        /// Make button icon-only
        /// </summary>
        public TablerButton IconOnly(bool iconOnly = true)
        {
            _iconOnly = iconOnly;
            return this;
        }

        /// <summary>
        /// Set loading state
        /// </summary>
        public TablerButton Loading(bool loading = true)
        {
            _loading = loading;
            return this;
        }

        /// <summary>
        /// Set disabled state
        /// </summary>
        public TablerButton Disabled(bool disabled = true)
        {
            _disabled = disabled;
            return this;
        }

        /// <summary>
        /// Make button full width
        /// </summary>
        public TablerButton Block(bool block = true)
        {
            _block = block;
            return this;
        }

        /// <summary>
        /// Make button full width (alias for Block)
        /// </summary>
        public TablerButton FullWidth(bool fullWidth = true)
        {
            _block = fullWidth;
            return this;
        }

        /// <summary>
        /// Make button ghost (outline only)
        /// </summary>
        public TablerButton Ghost(bool ghost = true)
        {
            _ghost = ghost;
            return this;
        }

        /// <summary>
        /// Set onClick JavaScript
        /// </summary>
        public TablerButton OnClick(string javascript)
        {
            _onClick = javascript;
            return this;
        }

        /// <summary>
        /// Set tooltip
        /// </summary>
        public TablerButton Tooltip(string text)
        {
            _tooltip = text;
            return this;
        }

        /// <summary>
        /// Set button type attribute
        /// </summary>
        public TablerButton Type(string type)
        {
            _type = type;
            return this;
        }

        /// <summary>
        /// Make button submit type
        /// </summary>
        public TablerButton Submit()
        {
            return Type("submit");
        }

        /// <summary>
        /// Make button reset type
        /// </summary>
        public TablerButton Reset()
        {
            return Type("reset");
        }

        /// <summary>
        /// Renders the button to HTML string
        /// </summary>
        /// <returns>HTML representation of the button</returns>
        public override string ToString()
        {
            var tag = string.IsNullOrEmpty(_href) ? "button" : "a";
            var button = new HtmlTag(tag);
            
            // Base class
            button.Class("btn");
            
            // Variant class
            var variantClass = _variant switch
            {
                TablerButtonVariant.Primary => "btn-primary",
                TablerButtonVariant.Secondary => "btn-secondary",
                TablerButtonVariant.Success => "btn-success",
                TablerButtonVariant.Warning => "btn-warning",
                TablerButtonVariant.Danger => "btn-danger",
                TablerButtonVariant.Info => "btn-info",
                TablerButtonVariant.Light => "btn-light",
                TablerButtonVariant.Dark => "btn-dark",
                TablerButtonVariant.Link => "btn-link",
                _ => null
            };
            
            if (!string.IsNullOrEmpty(variantClass))
            {
                if (_ghost)
                    button.Class(variantClass!.Replace("btn-", "btn-ghost-"));
                else
                    button.Class(variantClass!);
            }
            
            // Size class
            if (_size == TablerButtonSize.Small)
                button.Class("btn-sm");
            else if (_size == TablerButtonSize.Large)
                button.Class("btn-lg");
            
            // Other classes
            if (_iconOnly && _icon.HasValue)
                button.Class("btn-icon");
            if (_loading)
                button.Class("btn-loading");
            if (_block)
                button.Class("w-100");
            
            // Attributes
            if (tag == "button")
            {
                button.Attribute("type", _type ?? "button");
                if (_disabled)
                    button.Attribute("disabled", "disabled");
            }
            else
            {
                button.Attribute("href", _href ?? "#");
                button.Attribute("role", "button");
                if (_disabled)
                {
                    button.Class("disabled");
                    button.Attribute("aria-disabled", "true");
                }
            }
            
            if (!string.IsNullOrEmpty(_onClick))
                button.Attribute("onclick", _onClick!);
            
            if (!string.IsNullOrEmpty(_tooltip))
            {
                button.Attribute("data-bs-toggle", "tooltip");
                button.Attribute("data-bs-placement", "top");
                button.Attribute("title", _tooltip!);
            }
            
            // Content
            if (_icon.HasValue && !_loading)
            {
                if (_iconOnly)
                {
                    button.Value(TablerIconLibrary.GetIcon(_icon.Value).ToString());
                }
                else if (_iconPosition == TablerIconPosition.Left)
                {
                    button.Value(TablerIconLibrary.GetIcon(_icon.Value).ToString());
                    button.Value(_text);
                }
                else
                {
                    button.Value(_text);
                    button.Value(TablerIconLibrary.GetIcon(_icon.Value).ToString());
                }
            }
            else if (!_iconOnly)
            {
                button.Value(_text);
            }
            
            return button.ToString();
        }

        // Note: TablerButton handles its own CSS classes and attributes internally
        // Custom classes and attributes are managed through the component's properties
        // and applied in the ToString() method

        /// <summary>
        /// Create button with fluent configuration
        /// </summary>
        public static TablerButton Create(string text, Action<TablerButton> configure)
        {
            var button = new TablerButton(text);
            configure(button);
            return button;
        }
    }

    /// <summary>
    /// Represents button color variants in Tabler
    /// </summary>
    public enum TablerButtonVariant
    {
        /// <summary>
        /// Primary theme color (usually blue)
        /// </summary>
        Primary,
        /// <summary>
        /// Secondary theme color (usually gray)
        /// </summary>
        Secondary,
        /// <summary>
        /// Success color (green)
        /// </summary>
        Success,
        /// <summary>
        /// Warning color (yellow/orange)
        /// </summary>
        Warning,
        /// <summary>
        /// Danger color (red)
        /// </summary>
        Danger,
        /// <summary>
        /// Info color (light blue)
        /// </summary>
        Info,
        /// <summary>
        /// Light color
        /// </summary>
        Light,
        /// <summary>
        /// Dark color
        /// </summary>
        Dark,
        /// <summary>
        /// Link style button (no background)
        /// </summary>
        Link
    }

    /// <summary>
    /// Represents button size options
    /// </summary>
    public enum TablerButtonSize
    {
        /// <summary>
        /// Default button size
        /// </summary>
        Default,
        /// <summary>
        /// Small button size
        /// </summary>
        Small,
        /// <summary>
        /// Large button size
        /// </summary>
        Large
    }

    /// <summary>
    /// Represents icon position within a button
    /// </summary>
    public enum TablerIconPosition
    {
        /// <summary>
        /// Icon on the left side of text
        /// </summary>
        Left,
        /// <summary>
        /// Icon on the right side of text
        /// </summary>
        Right
    }
}