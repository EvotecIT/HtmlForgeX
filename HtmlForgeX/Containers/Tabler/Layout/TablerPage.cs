namespace HtmlForgeX.Containers.Tabler
{
    /// <summary>
    /// Tabler page container component that provides the main page structure
    /// </summary>
    public class TablerPage : Element
    {
        private TablerPageLayout _layout = TablerPageLayout.Default;
        private bool _condensed = false;

        /// <summary>
        /// Initializes a new instance of the TablerPage class
        /// </summary>
        public TablerPage() : base()
        {
        }

        /// <summary>
        /// Registers the required libraries for this component
        /// </summary>
        protected internal override void RegisterLibraries()
        {
            if (Document != null)
            {
                Document.AddLibrary(Libraries.Tabler);
            }
        }

        /// <summary>
        /// Set page layout type
        /// </summary>
        public TablerPage Layout(TablerPageLayout layout)
        {
            _layout = layout;
            return this;
        }

        /// <summary>
        /// Make page condensed (less padding)
        /// </summary>
        public TablerPage Condensed(bool condensed = true)
        {
            _condensed = condensed;
            return this;
        }

        /// <summary>
        /// Add page wrapper
        /// </summary>
        public TablerPage Wrapper(Action<TablerPageWrapper> configure)
        {
            var wrapper = new TablerPageWrapper();
            configure(wrapper);
            Add(wrapper);
            return this;
        }

        /// <summary>
        /// Add sidebar to page
        /// </summary>
        public TablerPage Sidebar(Action<TablerSidebar> configure)
        {
            var sidebar = new TablerSidebar();
            configure(sidebar);
            Add(sidebar);
            return this;
        }

        /// <summary>
        /// Add header to page
        /// </summary>
        public TablerPage Header(Action<TablerHeader> configure)
        {
            var header = new TablerHeader();
            configure(header);
            Add(header);
            return this;
        }

        /// <summary>
        /// Renders the page to HTML string
        /// </summary>
        /// <returns>HTML representation of the page</returns>
        public override string ToString()
        {
            var page = new HtmlTag("div");
            page.Class("page");

            if (_layout == TablerPageLayout.Boxed)
                page.Class("page-boxed");
            else if (_layout == TablerPageLayout.Fluid)
                page.Class("page-fluid");

            if (_condensed)
                page.Class("page-condensed");

            foreach (var child in Children)
            {
                page.Value(child.ToString());
            }

            return page.ToString();
        }
    }

    /// <summary>
    /// Represents page layout options
    /// </summary>
    public enum TablerPageLayout
    {
        /// <summary>
        /// Default page layout
        /// </summary>
        Default,
        /// <summary>
        /// Boxed layout with centered content
        /// </summary>
        Boxed,
        /// <summary>
        /// Fluid layout with full width
        /// </summary>
        Fluid
    }
}