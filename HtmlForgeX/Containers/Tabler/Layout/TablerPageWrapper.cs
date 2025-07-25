namespace HtmlForgeX.Containers.Tabler
{
    /// <summary>
    /// Tabler page wrapper component that contains the main content area
    /// </summary>
    public class TablerPageWrapper : Element
    {
        /// <summary>
        /// Initializes a new instance of the TablerPageWrapper class
        /// </summary>
        public TablerPageWrapper() : base()
        {
        }

        /// <summary>
        /// Add page header
        /// </summary>
        public TablerPageWrapper PageHeader(Action<TablerPageHeader> configure)
        {
            var header = new TablerPageHeader();
            configure(header);
            Add(header);
            return this;
        }

        /// <summary>
        /// Add page body
        /// </summary>
        public TablerPageWrapper PageBody(Action<TablerPageBody> configure)
        {
            var body = new TablerPageBody();
            configure(body);
            Add(body);
            return this;
        }

        /// <summary>
        /// Add header (navbar)
        /// </summary>
        public TablerPageWrapper Header(Action<TablerHeader> configure)
        {
            var header = new TablerHeader();
            configure(header);
            Add(header);
            return this;
        }

        /// <summary>
        /// Add footer
        /// </summary>
        public TablerPageWrapper Footer(Action<TablerFooter> configure)
        {
            var footer = new TablerFooter();
            configure(footer);
            Add(footer);
            return this;
        }

        /// <summary>
        /// Renders the page wrapper to HTML string
        /// </summary>
        /// <returns>HTML representation of the page wrapper</returns>
        public override string ToString()
        {
            var wrapper = new HtmlTag("div");
            wrapper.Class("page-wrapper");

            foreach (var child in Children)
            {
                wrapper.Value(child.ToString());
            }

            return wrapper.ToString();
        }
    }
}