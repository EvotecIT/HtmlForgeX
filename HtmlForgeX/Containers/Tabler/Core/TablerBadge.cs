namespace HtmlForgeX.Containers.Tabler
{
    /// <summary>
    /// Tabler badge component for labels and status indicators
    /// </summary>
    public class TablerBadge : Element
    {
        private string _text = "";
        private TablerBadgeColor _color = TablerBadgeColor.Default;
        private TablerBadgeStyle _style = TablerBadgeStyle.Default;
        private TablerBadgeSize _size = TablerBadgeSize.Default;
        private bool _pill = false;
        private bool _outline = false;
        private TablerIconType? _icon;
        private string? _href;
        private bool _removable = false;
        
        /// <summary>
        /// Additional CSS classes for the badge container
        /// </summary>
        public string? ContainerClasses { get; set; }

        /// <summary>
        /// Initializes a new instance of the TablerBadge class
        /// </summary>
        public TablerBadge() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the TablerBadge class with text
        /// </summary>
        /// <param name="text">The text to display in the badge</param>
        public TablerBadge(string text) : base()
        {
            _text = text;
        }

        /// <summary>
        /// Set badge text
        /// </summary>
        public new TablerBadge Text(string text)
        {
            _text = text;
            return this;
        }

        /// <summary>
        /// Set badge color
        /// </summary>
        public TablerBadge Color(TablerBadgeColor color)
        {
            _color = color;
            return this;
        }

        /// <summary>
        /// Set badge style
        /// </summary>
        public TablerBadge Style(TablerBadgeStyle style)
        {
            _style = style;
            return this;
        }

        /// <summary>
        /// Set badge size
        /// </summary>
        public TablerBadge Size(TablerBadgeSize size)
        {
            _size = size;
            return this;
        }

        /// <summary>
        /// Make badge pill shaped
        /// </summary>
        public TablerBadge Pill(bool pill = true)
        {
            _pill = pill;
            return this;
        }

        /// <summary>
        /// Make badge outline only
        /// </summary>
        public TablerBadge Outline(bool outline = true)
        {
            _outline = outline;
            return this;
        }

        /// <summary>
        /// Add icon to badge
        /// </summary>
        public TablerBadge Icon(TablerIconType icon)
        {
            _icon = icon;
            return this;
        }

        /// <summary>
        /// Make badge a link
        /// </summary>
        public TablerBadge Href(string href)
        {
            _href = href;
            return this;
        }

        /// <summary>
        /// Add remove button to badge
        /// </summary>
        public TablerBadge Removable(bool removable = true)
        {
            _removable = removable;
            return this;
        }

        /// <summary>
        /// Renders the badge to HTML string
        /// </summary>
        /// <returns>HTML representation of the badge</returns>
        public override string ToString()
        {
            var tag = string.IsNullOrEmpty(_href) ? new HtmlTag("span") : new HtmlTag("a");
            
            if (!string.IsNullOrEmpty(_href))
                tag.Attribute("href", _href!);

            // Base class
            tag.Class("badge");

            // Size
            if (_size == TablerBadgeSize.Small)
                tag.Class("badge-sm");

            // Style and color
            if (_style == TablerBadgeStyle.Light)
            {
                var colorClass = _color switch
                {
                    TablerBadgeColor.Primary => "bg-primary-lt",
                    TablerBadgeColor.Secondary => "bg-secondary-lt",
                    TablerBadgeColor.Success => "bg-success-lt",
                    TablerBadgeColor.Warning => "bg-warning-lt",
                    TablerBadgeColor.Danger => "bg-danger-lt",
                    TablerBadgeColor.Info => "bg-info-lt",
                    TablerBadgeColor.Light => "bg-light-lt",
                    TablerBadgeColor.Dark => "bg-dark-lt",
                    TablerBadgeColor.Blue => "bg-blue-lt",
                    TablerBadgeColor.Azure => "bg-azure-lt",
                    TablerBadgeColor.Indigo => "bg-indigo-lt",
                    TablerBadgeColor.Purple => "bg-purple-lt",
                    TablerBadgeColor.Pink => "bg-pink-lt",
                    TablerBadgeColor.Red => "bg-red-lt",
                    TablerBadgeColor.Orange => "bg-orange-lt",
                    TablerBadgeColor.Yellow => "bg-yellow-lt",
                    TablerBadgeColor.Lime => "bg-lime-lt",
                    TablerBadgeColor.Green => "bg-green-lt",
                    TablerBadgeColor.Teal => "bg-teal-lt",
                    TablerBadgeColor.Cyan => "bg-cyan-lt",
                    _ => ""
                };
                if (!string.IsNullOrEmpty(colorClass))
                    tag.Class(colorClass);
            }
            else if (_outline)
            {
                tag.Class("badge-outline");
                var colorClass = _color switch
                {
                    TablerBadgeColor.Primary => "text-primary",
                    TablerBadgeColor.Secondary => "text-secondary",
                    TablerBadgeColor.Success => "text-success",
                    TablerBadgeColor.Warning => "text-warning",
                    TablerBadgeColor.Danger => "text-danger",
                    TablerBadgeColor.Info => "text-info",
                    TablerBadgeColor.Light => "text-light",
                    TablerBadgeColor.Dark => "text-dark",
                    TablerBadgeColor.Blue => "text-blue",
                    TablerBadgeColor.Azure => "text-azure",
                    TablerBadgeColor.Indigo => "text-indigo",
                    TablerBadgeColor.Purple => "text-purple",
                    TablerBadgeColor.Pink => "text-pink",
                    TablerBadgeColor.Red => "text-red",
                    TablerBadgeColor.Orange => "text-orange",
                    TablerBadgeColor.Yellow => "text-yellow",
                    TablerBadgeColor.Lime => "text-lime",
                    TablerBadgeColor.Green => "text-green",
                    TablerBadgeColor.Teal => "text-teal",
                    TablerBadgeColor.Cyan => "text-cyan",
                    _ => ""
                };
                if (!string.IsNullOrEmpty(colorClass))
                    tag.Class(colorClass);
            }
            else
            {
                var colorClass = _color switch
                {
                    TablerBadgeColor.Primary => "bg-primary",
                    TablerBadgeColor.Secondary => "bg-secondary",
                    TablerBadgeColor.Success => "bg-success",
                    TablerBadgeColor.Warning => "bg-warning",
                    TablerBadgeColor.Danger => "bg-danger",
                    TablerBadgeColor.Info => "bg-info",
                    TablerBadgeColor.Light => "bg-light",
                    TablerBadgeColor.Dark => "bg-dark",
                    TablerBadgeColor.Blue => "bg-blue",
                    TablerBadgeColor.Azure => "bg-azure",
                    TablerBadgeColor.Indigo => "bg-indigo",
                    TablerBadgeColor.Purple => "bg-purple",
                    TablerBadgeColor.Pink => "bg-pink",
                    TablerBadgeColor.Red => "bg-red",
                    TablerBadgeColor.Orange => "bg-orange",
                    TablerBadgeColor.Yellow => "bg-yellow",
                    TablerBadgeColor.Lime => "bg-lime",
                    TablerBadgeColor.Green => "bg-green",
                    TablerBadgeColor.Teal => "bg-teal",
                    TablerBadgeColor.Cyan => "bg-cyan",
                    _ => ""
                };
                if (!string.IsNullOrEmpty(colorClass))
                    tag.Class(colorClass);
            }

            // Pill
            if (_pill)
                tag.Class("badge-pill");

            // Container classes
            if (!string.IsNullOrEmpty(ContainerClasses))
                tag.Class(ContainerClasses);

            // Icon
            if (_icon.HasValue)
            {
                tag.Value(TablerIconLibrary.GetIcon(_icon.Value).ToString());
                if (!string.IsNullOrEmpty(_text))
                    tag.Value(" ");
            }

            // Text
            tag.Value(_text);

            // Remove button
            if (_removable)
            {
                var removeBtn = new HtmlTag("a");
                removeBtn.Attribute("href", "#");
                removeBtn.Class("badge-close");
                removeBtn.Attribute("aria-label", "Remove");
                tag.Value(removeBtn.ToString());
            }

            return tag.ToString();
        }

        /// <summary>
        /// Create badge with fluent configuration
        /// </summary>
        public static TablerBadge Create(string text, Action<TablerBadge> configure)
        {
            var badge = new TablerBadge(text);
            configure(badge);
            return badge;
        }
    }

    /// <summary>
    /// Represents color options for TablerBadge
    /// </summary>
    public enum TablerBadgeColor
    {
        /// <summary>
        /// Default color
        /// </summary>
        Default,
        /// <summary>
        /// Primary theme color
        /// </summary>
        Primary,
        /// <summary>
        /// Secondary theme color
        /// </summary>
        Secondary,
        /// <summary>
        /// Success/green color
        /// </summary>
        Success,
        /// <summary>
        /// Warning/yellow color
        /// </summary>
        Warning,
        /// <summary>
        /// Danger/red color
        /// </summary>
        Danger,
        /// <summary>
        /// Info/blue color
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
        /// Blue color
        /// </summary>
        Blue,
        /// <summary>
        /// Azure color
        /// </summary>
        Azure,
        /// <summary>
        /// Indigo color
        /// </summary>
        Indigo,
        /// <summary>
        /// Purple color
        /// </summary>
        Purple,
        /// <summary>
        /// Pink color
        /// </summary>
        Pink,
        /// <summary>
        /// Red color
        /// </summary>
        Red,
        /// <summary>
        /// Orange color
        /// </summary>
        Orange,
        /// <summary>
        /// Yellow color
        /// </summary>
        Yellow,
        /// <summary>
        /// Lime color
        /// </summary>
        Lime,
        /// <summary>
        /// Green color
        /// </summary>
        Green,
        /// <summary>
        /// Teal color
        /// </summary>
        Teal,
        /// <summary>
        /// Cyan color
        /// </summary>
        Cyan
    }

    /// <summary>
    /// Represents style options for TablerBadge
    /// </summary>
    public enum TablerBadgeStyle
    {
        /// <summary>
        /// Default filled style
        /// </summary>
        Default,
        /// <summary>
        /// Light/outline style
        /// </summary>
        Light
    }

    /// <summary>
    /// Represents size options for TablerBadge
    /// </summary>
    public enum TablerBadgeSize
    {
        /// <summary>
        /// Default size
        /// </summary>
        Default,
        /// <summary>
        /// Small size
        /// </summary>
        Small
    }
}