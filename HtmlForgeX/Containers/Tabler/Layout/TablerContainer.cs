namespace HtmlForgeX.Containers.Tabler
{
    /// <summary>
    /// Tabler container component for content width control
    /// </summary>
    public class TablerContainer : Element
    {
        private TablerContainerSize _size = TablerContainerSize.Default;
        private bool _fluid = false;

        /// <summary>
        /// Initializes a new instance of the TablerContainer class
        /// </summary>
        public TablerContainer() : base()
        {
        }

        /// <summary>
        /// Set container size
        /// </summary>
        public TablerContainer Size(TablerContainerSize size)
        {
            _size = size;
            return this;
        }

        /// <summary>
        /// Make container fluid (full width)
        /// </summary>
        public TablerContainer Fluid(bool fluid = true)
        {
            _fluid = fluid;
            return this;
        }

        /// <summary>
        /// Add a row
        /// </summary>
        public new TablerContainer Row(Action<TablerRow> configure)
        {
            var row = new TablerRow();
            configure(row);
            Add(row);
            return this;
        }

        /// <summary>
        /// Add content directly
        /// </summary>
        public new TablerContainer Add(Element element)
        {
            base.Add(element);
            return this;
        }

        /// <summary>
        /// Renders the container to HTML string
        /// </summary>
        /// <returns>HTML representation of the container</returns>
        public override string ToString()
        {
            var container = new HtmlTag("div");
            
            if (_fluid)
            {
                container.Class("container-fluid");
            }
            else
            {
                var sizeClass = _size switch
                {
                    TablerContainerSize.Small => "container-sm",
                    TablerContainerSize.Medium => "container-md",
                    TablerContainerSize.Large => "container-lg",
                    TablerContainerSize.ExtraLarge => "container-xl",
                    TablerContainerSize.ExtraExtraLarge => "container-xxl",
                    _ => "container"
                };
                container.Class(sizeClass);
            }

            foreach (var child in Children)
            {
                container.Value(child.ToString());
            }

            return container.ToString();
        }
    }

    /// <summary>
    /// Represents container size options
    /// </summary>
    public enum TablerContainerSize
    {
        /// <summary>
        /// Default container size
        /// </summary>
        Default,
        /// <summary>
        /// Small container (576px)
        /// </summary>
        Small,
        /// <summary>
        /// Medium container (768px)
        /// </summary>
        Medium,
        /// <summary>
        /// Large container (992px)
        /// </summary>
        Large,
        /// <summary>
        /// Extra large container (1200px)
        /// </summary>
        ExtraLarge,
        /// <summary>
        /// Extra extra large container (1400px)
        /// </summary>
        ExtraExtraLarge
    }
}