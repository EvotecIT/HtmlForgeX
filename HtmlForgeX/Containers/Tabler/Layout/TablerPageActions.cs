namespace HtmlForgeX.Containers.Tabler
{
    /// <summary>
    /// Tabler page actions container for buttons and controls
    /// </summary>
    public class TablerPageActions : Element
    {
        private bool _autoMargin = true;
        private bool _printHidden = true;

        /// <summary>
        /// Initializes a new instance of the TablerPageActions class
        /// </summary>
        public TablerPageActions() : base()
        {
        }

        /// <summary>
        /// Disable automatic left margin
        /// </summary>
        public TablerPageActions NoAutoMargin()
        {
            _autoMargin = false;
            return this;
        }

        /// <summary>
        /// Show actions when printing
        /// </summary>
        public TablerPageActions ShowOnPrint(bool show = true)
        {
            _printHidden = !show;
            return this;
        }

        /// <summary>
        /// Add a button
        /// </summary>
        public TablerPageActions Button(string text, TablerButtonVariant variant = TablerButtonVariant.Primary)
        {
            var button = new TablerButton(text).Variant(variant);
            Add(button);
            return this;
        }

        /// <summary>
        /// Add a button with configuration
        /// </summary>
        public TablerPageActions Button(string text, Action<TablerButton> configure)
        {
            var button = new TablerButton(text);
            configure(button);
            Add(button);
            return this;
        }

        /// <summary>
        /// Add a dropdown
        /// </summary>
        public TablerPageActions Dropdown(string text, Action<TablerDropdown> configure)
        {
            var dropdown = new TablerDropdown(text);
            configure(dropdown);
            Add(dropdown);
            return this;
        }

        /// <summary>
        /// Add custom element
        /// </summary>
        public TablerPageActions Custom(Element element)
        {
            Add(element);
            return this;
        }

        /// <summary>
        /// Renders the page actions to HTML string
        /// </summary>
        /// <returns>HTML representation of the page actions</returns>
        public override string ToString()
        {
            var container = new HtmlTag("div");
            container.Class("col-auto");
            
            if (_autoMargin)
                container.Class("ms-auto");
                
            if (_printHidden)
                container.Class("d-print-none");

            var btnList = new HtmlTag("div");
            btnList.Class("btn-list");

            foreach (var child in Children)
            {
                btnList.Value(child.ToString());
            }

            container.Value(btnList.ToString());
            return container.ToString();
        }
    }
}