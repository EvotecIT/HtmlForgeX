namespace HtmlForgeX.Containers.Tabler
{
    /// <summary>
    /// Tabler page header component for page titles and actions
    /// </summary>
    public class TablerPageHeader : Element
    {
        private bool _printHidden = true;
        private TablerContainer? _container;

        /// <summary>
        /// Initializes a new instance of the TablerPageHeader class
        /// </summary>
        public TablerPageHeader() : base()
        {
        }

        /// <summary>
        /// Show header when printing
        /// </summary>
        public TablerPageHeader ShowOnPrint(bool show = true)
        {
            _printHidden = !show;
            return this;
        }

        /// <summary>
        /// Add page title
        /// </summary>
        public TablerPageHeader Title(Action<TablerPageTitle> configure)
        {
            EnsureContainer();
            var title = new TablerPageTitle();
            configure(title);
            _container!.Add(title);
            return this;
        }

        /// <summary>
        /// Add page title with simple text
        /// </summary>
        public TablerPageHeader Title(string title, string? pretitle = null)
        {
            EnsureContainer();
            var titleComponent = new TablerPageTitle()
                .Title(title);
            
            if (!string.IsNullOrEmpty(pretitle))
                titleComponent.PreTitle(pretitle!);
                
            _container!.Add(titleComponent);
            return this;
        }

        /// <summary>
        /// Add breadcrumb
        /// </summary>
        public TablerPageHeader Breadcrumb(Action<TablerBreadcrumb> configure)
        {
            EnsureContainer();
            var breadcrumb = new TablerBreadcrumb();
            configure(breadcrumb);
            _container!.Add(breadcrumb);
            return this;
        }

        /// <summary>
        /// Add action buttons
        /// </summary>
        public TablerPageHeader Actions(Action<TablerPageActions> configure)
        {
            EnsureContainer();
            var actions = new TablerPageActions();
            configure(actions);
            _container!.Add(actions);
            return this;
        }

        /// <summary>
        /// Ensures the container is initialized
        /// </summary>
        private void EnsureContainer()
        {
            if (_container == null)
            {
                _container = new TablerContainer().Size(TablerContainerSize.ExtraLarge);
                Add(_container);
            }
        }

        /// <summary>
        /// Renders the page header to HTML string
        /// </summary>
        /// <returns>HTML representation of the page header</returns>
        public override string ToString()
        {
            var header = new HtmlTag("div");
            header.Class("page-header");
            
            if (_printHidden)
                header.Class("d-print-none");

            foreach (var child in Children)
            {
                header.Value(child.ToString());
            }

            return header.ToString();
        }
    }
}