namespace HtmlForgeX.Containers.Tabler
{
    /// <summary>
    /// Tabler divider component for visual separation
    /// </summary>
    public class TablerDivider : Element
    {
        private TablerDividerType _type = TablerDividerType.Default;
        private TablerDividerStyle _style = TablerDividerStyle.Default;
        private int? _marginY;
        private string? _text;
        private TablerDividerTextPosition _textPosition = TablerDividerTextPosition.Center;

        /// <summary>
        /// Initializes a new instance of the TablerDivider class
        /// </summary>
        public TablerDivider() : base()
        {
        }

        /// <summary>
        /// Set divider type
        /// </summary>
        public TablerDivider Type(TablerDividerType type)
        {
            _type = type;
            return this;
        }

        /// <summary>
        /// Set divider style
        /// </summary>
        public TablerDivider Style(TablerDividerStyle style)
        {
            _style = style;
            return this;
        }

        /// <summary>
        /// Set vertical margin
        /// </summary>
        public TablerDivider MarginY(int margin)
        {
            _marginY = margin;
            return this;
        }

        /// <summary>
        /// Add text to divider
        /// </summary>
        public TablerDivider Text(string text, TablerDividerTextPosition position = TablerDividerTextPosition.Center)
        {
            _text = text;
            _textPosition = position;
            return this;
        }

        /// <summary>
        /// Renders the divider to HTML string
        /// </summary>
        /// <returns>HTML representation of the divider</returns>
        public override string ToString()
        {
            var tag = new HtmlTag("hr");
            
            // Base classes based on type
            if (_type == TablerDividerType.Dropdown)
                tag.Class("dropdown-divider");
            else if (_type == TablerDividerType.Navbar)
                tag.Class("navbar-divider");
            else
                tag.Class("hr");

            // Style
            if (_style == TablerDividerStyle.Dashed)
                tag.Class("hr-dashed");
            else if (_style == TablerDividerStyle.Dotted)
                tag.Class("hr-dotted");

            // Margin
            if (_marginY.HasValue)
                tag.Class($"my-{_marginY}");

            // Text divider
            if (!string.IsNullOrEmpty(_text))
            {
                var container = new HtmlTag("div");
                container.Class("hr-text");
                
                if (_textPosition == TablerDividerTextPosition.Left)
                    container.Class("hr-text-left");
                else if (_textPosition == TablerDividerTextPosition.Right)
                    container.Class("hr-text-right");
                
                container.Value(_text);
                return container.ToString();
            }

            return tag.ToString();
        }
    }

    /// <summary>
    /// Represents type options for TablerDivider
    /// </summary>
    public enum TablerDividerType
    {
        /// <summary>
        /// Default horizontal rule divider
        /// </summary>
        Default,
        /// <summary>
        /// Dropdown menu divider
        /// </summary>
        Dropdown,
        /// <summary>
        /// Navbar divider
        /// </summary>
        Navbar
    }

    /// <summary>
    /// Represents style options for TablerDivider
    /// </summary>
    public enum TablerDividerStyle
    {
        /// <summary>
        /// Default solid line
        /// </summary>
        Default,
        /// <summary>
        /// Dashed line
        /// </summary>
        Dashed,
        /// <summary>
        /// Dotted line
        /// </summary>
        Dotted
    }

    /// <summary>
    /// Represents text position options for TablerDivider
    /// </summary>
    public enum TablerDividerTextPosition
    {
        /// <summary>
        /// Center aligned text
        /// </summary>
        Center,
        /// <summary>
        /// Left aligned text
        /// </summary>
        Left,
        /// <summary>
        /// Right aligned text
        /// </summary>
        Right
    }
}