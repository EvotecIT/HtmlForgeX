namespace HtmlForgeX.Containers.Tabler
{
    /// <summary>
    /// Tabler page title component with optional pretitle
    /// </summary>
    public class TablerPageTitle : Element
    {
        private string? _preTitle;
        private string _title = "";
        private TablerPageTitleSize _size = TablerPageTitleSize.Default;

        /// <summary>
        /// Initializes a new instance of the TablerPageTitle class
        /// </summary>
        public TablerPageTitle() : base()
        {
        }

        /// <summary>
        /// Set the pretitle (small text above main title)
        /// </summary>
        public TablerPageTitle PreTitle(string pretitle)
        {
            _preTitle = pretitle;
            return this;
        }

        /// <summary>
        /// Set the main title
        /// </summary>
        public TablerPageTitle Title(string title)
        {
            _title = title;
            return this;
        }

        /// <summary>
        /// Set title size
        /// </summary>
        public TablerPageTitle Size(TablerPageTitleSize size)
        {
            _size = size;
            return this;
        }

        /// <summary>
        /// Renders the page title to HTML string
        /// </summary>
        /// <returns>HTML representation of the page title</returns>
        public override string ToString()
        {
            var container = new HtmlTag("div");
            container.Class("col");

            // Add pretitle if provided
            if (!string.IsNullOrEmpty(_preTitle))
            {
                var pretitle = new HtmlTag("div");
                pretitle.Class("page-pretitle");
                pretitle.Value(_preTitle);
                container.Value(pretitle.ToString());
            }

            // Add main title
            var titleTag = _size switch
            {
                TablerPageTitleSize.Small => "h3",
                TablerPageTitleSize.Large => "h1",
                _ => "h2"
            };

            var title = new HtmlTag(titleTag);
            title.Class("page-title");
            title.Value(_title);
            container.Value(title.ToString());

            return container.ToString();
        }
    }

    /// <summary>
    /// Represents page title size options
    /// </summary>
    public enum TablerPageTitleSize
    {
        /// <summary>
        /// Small title size (h3)
        /// </summary>
        Small,
        /// <summary>
        /// Default title size (h2)
        /// </summary>
        Default,
        /// <summary>
        /// Large title size (h1)
        /// </summary>
        Large
    }
}