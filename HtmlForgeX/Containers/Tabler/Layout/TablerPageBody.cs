namespace HtmlForgeX.Containers.Tabler
{
    /// <summary>
    /// Tabler page body component for main content area
    /// </summary>
    public class TablerPageBody : Element
    {
        private TablerContainer? _container;
        private bool _autoContainer = true;

        /// <summary>
        /// Initializes a new instance of the TablerPageBody class
        /// </summary>
        public TablerPageBody() : base()
        {
        }

        /// <summary>
        /// Disable automatic container wrapper
        /// </summary>
        public TablerPageBody NoContainer()
        {
            _autoContainer = false;
            return this;
        }

        /// <summary>
        /// Add content with container
        /// </summary>
        public TablerPageBody Container(Action<TablerContainer> configure)
        {
            EnsureContainer();
            configure(_container!);
            return this;
        }

        /// <summary>
        /// Add a row
        /// </summary>
        public new TablerPageBody Row(Action<TablerRow> configure)
        {
            EnsureContainer();
            var row = new TablerRow();
            configure(row);
            _container!.Add(row);
            return this;
        }

        /// <summary>
        /// Add stats row
        /// </summary>
        public TablerPageBody StatsRow(Action<TablerStatsRow> configure)
        {
            EnsureContainer();
            var statsRow = new TablerStatsRow();
            configure(statsRow);
            _container!.Add(statsRow);
            return this;
        }

        /// <summary>
        /// Add a card
        /// </summary>
        public new TablerPageBody Card(Action<TablerCard> configure)
        {
            EnsureContainer();
            var card = new TablerCard();
            configure(card);
            _container!.Add(card);
            return this;
        }

        /// <summary>
        /// Add custom element
        /// </summary>
        public new TablerPageBody Add(Element element)
        {
            if (_autoContainer)
            {
                EnsureContainer();
                _container!.Add(element);
            }
            else
            {
                base.Add(element);
            }
            return this;
        }

        /// <summary>
        /// Ensures the container is initialized if auto-container is enabled
        /// </summary>
        private void EnsureContainer()
        {
            if (_container == null && _autoContainer)
            {
                _container = new TablerContainer().Size(TablerContainerSize.ExtraLarge);
                base.Add(_container);
            }
        }

        /// <summary>
        /// Renders the page body to HTML string
        /// </summary>
        /// <returns>HTML representation of the page body</returns>
        public override string ToString()
        {
            var body = new HtmlTag("div");
            body.Class("page-body");

            foreach (var child in Children)
            {
                body.Value(child.ToString());
            }

            return body.ToString();
        }
    }
}