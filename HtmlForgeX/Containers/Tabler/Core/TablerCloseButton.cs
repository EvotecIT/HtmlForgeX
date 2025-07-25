namespace HtmlForgeX.Containers.Tabler
{
    /// <summary>
    /// Tabler close button component for dismissing content
    /// </summary>
    public class TablerCloseButton : Element
    {
        private string? _dismissTarget;
        private string? _ariaLabel;
        private TablerCloseButtonSize _size = TablerCloseButtonSize.Default;
        private string? _marginStart;

        /// <summary>
        /// Initializes a new instance of the TablerCloseButton class
        /// </summary>
        public TablerCloseButton() : base()
        {
        }

        /// <summary>
        /// Set what to dismiss (e.g., "dropdown", "modal", "alert")
        /// </summary>
        public TablerCloseButton Dismiss(string target)
        {
            _dismissTarget = target;
            return this;
        }

        /// <summary>
        /// Set aria label for accessibility
        /// </summary>
        public TablerCloseButton AriaLabel(string label)
        {
            _ariaLabel = label;
            return this;
        }

        /// <summary>
        /// Set button size
        /// </summary>
        public TablerCloseButton Size(TablerCloseButtonSize size)
        {
            _size = size;
            return this;
        }

        /// <summary>
        /// Set margin start
        /// </summary>
        public TablerCloseButton MarginStart(string margin)
        {
            _marginStart = margin;
            return this;
        }

        /// <summary>
        /// Renders the close button to HTML string
        /// </summary>
        /// <returns>HTML representation of the close button</returns>
        public override string ToString()
        {
            var button = new HtmlTag("div");
            button.Class("btn-close");

            if (_size == TablerCloseButtonSize.Small)
                button.Class("btn-close-sm");
            else if (_size == TablerCloseButtonSize.Large)
                button.Class("btn-close-lg");

            if (!string.IsNullOrEmpty(_dismissTarget))
                button.Attribute($"data-bs-dismiss", _dismissTarget!);

            if (!string.IsNullOrEmpty(_ariaLabel))
                button.Attribute("aria-label", _ariaLabel!);

            if (_marginStart == "auto")
                button.Class("ms-auto");
            else if (!string.IsNullOrEmpty(_marginStart))
                button.Class($"ms-{_marginStart}");

            return button.ToString();
        }
    }

    /// <summary>
    /// Represents size options for TablerCloseButton
    /// </summary>
    public enum TablerCloseButtonSize
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