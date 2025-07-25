namespace HtmlForgeX.Containers.Tabler
{
    /// <summary>
    /// Tabler status dot component for visual status indicators
    /// </summary>
    public class TablerStatusDot : Element
    {
        private TablerStatusColor _color = TablerStatusColor.Default;
        private bool _animated = false;
        private TablerStatusDotSize _size = TablerStatusDotSize.Default;

        /// <summary>
        /// Initializes a new instance of the TablerStatusDot class
        /// </summary>
        public TablerStatusDot() : base()
        {
        }

        /// <summary>
        /// Set status color
        /// </summary>
        public TablerStatusDot Color(TablerStatusColor color)
        {
            _color = color;
            return this;
        }

        /// <summary>
        /// Make status dot animated
        /// </summary>
        public TablerStatusDot Animated(bool animated = true)
        {
            _animated = animated;
            return this;
        }

        /// <summary>
        /// Set dot size
        /// </summary>
        public TablerStatusDot Size(TablerStatusDotSize size)
        {
            _size = size;
            return this;
        }

        /// <summary>
        /// Renders the status dot to HTML string
        /// </summary>
        /// <returns>HTML representation of the status dot</returns>
        public override string ToString()
        {
            var span = new HtmlTag("span");
            span.Class("status-dot");
            
            if (_animated)
                span.Class("status-dot-animated");

            // Color
            var colorClass = _color switch
            {
                TablerStatusColor.Success => "bg-success",
                TablerStatusColor.Warning => "bg-warning",
                TablerStatusColor.Danger => "bg-danger",
                TablerStatusColor.Info => "bg-info",
                TablerStatusColor.Primary => "bg-primary",
                TablerStatusColor.Secondary => "bg-secondary",
                TablerStatusColor.Light => "bg-light",
                TablerStatusColor.Dark => "bg-dark",
                TablerStatusColor.Red => "bg-red",
                TablerStatusColor.Green => "bg-green",
                TablerStatusColor.Yellow => "bg-yellow",
                TablerStatusColor.Blue => "bg-blue",
                _ => ""
            };
            
            if (!string.IsNullOrEmpty(colorClass))
                span.Class(colorClass);

            // Size
            if (_size == TablerStatusDotSize.Small)
                span.Class("status-dot-sm");
            else if (_size == TablerStatusDotSize.Large)
                span.Class("status-dot-lg");

            span.Class("d-block");
            
            return span.ToString();
        }
    }

    /// <summary>
    /// Represents color options for TablerStatusDot
    /// </summary>
    public enum TablerStatusColor
    {
        /// <summary>
        /// Default color
        /// </summary>
        Default,
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
        /// Primary theme color
        /// </summary>
        Primary,
        /// <summary>
        /// Secondary theme color
        /// </summary>
        Secondary,
        /// <summary>
        /// Light color
        /// </summary>
        Light,
        /// <summary>
        /// Dark color
        /// </summary>
        Dark,
        /// <summary>
        /// Red color
        /// </summary>
        Red,
        /// <summary>
        /// Green color
        /// </summary>
        Green,
        /// <summary>
        /// Yellow color
        /// </summary>
        Yellow,
        /// <summary>
        /// Blue color
        /// </summary>
        Blue
    }

    /// <summary>
    /// Represents size options for TablerStatusDot
    /// </summary>
    public enum TablerStatusDotSize
    {
        /// <summary>
        /// Default size
        /// </summary>
        Default,
        /// <summary>
        /// Small size
        /// </summary>
        Small,
        /// <summary>
        /// Large size
        /// </summary>
        Large
    }
}