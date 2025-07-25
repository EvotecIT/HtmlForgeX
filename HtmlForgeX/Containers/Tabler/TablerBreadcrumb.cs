using System.Text;

namespace HtmlForgeX.Containers.Tabler
{
    /// <summary>
    /// Tabler breadcrumb navigation component
    /// </summary>
    public class TablerBreadcrumb : Element
    {
        private readonly List<BreadcrumbItem> _items = new();
        private string? _ariaLabel = "breadcrumbs";
        private TablerBreadcrumbStyle _style = TablerBreadcrumbStyle.Default;
        private TablerBreadcrumbSeparator _separator = TablerBreadcrumbSeparator.Default;

        /// <summary>
        /// Initializes a new instance of the TablerBreadcrumb class
        /// </summary>
        public TablerBreadcrumb() : base()
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
        /// Add breadcrumb item
        /// </summary>
        public TablerBreadcrumb Item(string text, string? href = null)
        {
            _items.Add(new BreadcrumbItem { Text = text, Href = href });
            return this;
        }

        /// <summary>
        /// Add breadcrumb item with icon
        /// </summary>
        public TablerBreadcrumb Item(string text, TablerIconType icon, string? href = null)
        {
            _items.Add(new BreadcrumbItem { Text = text, Href = href, Icon = icon });
            return this;
        }

        /// <summary>
        /// Add active (current) breadcrumb item
        /// </summary>
        public TablerBreadcrumb Active(string text)
        {
            _items.Add(new BreadcrumbItem { Text = text, IsActive = true });
            return this;
        }

        /// <summary>
        /// Add active (current) breadcrumb item with icon
        /// </summary>
        public TablerBreadcrumb Active(string text, TablerIconType icon)
        {
            _items.Add(new BreadcrumbItem { Text = text, Icon = icon, IsActive = true });
            return this;
        }

        /// <summary>
        /// Set breadcrumb style
        /// </summary>
        public TablerBreadcrumb Style(TablerBreadcrumbStyle style)
        {
            _style = style;
            return this;
        }

        /// <summary>
        /// Set custom separator
        /// </summary>
        public TablerBreadcrumb Separator(TablerBreadcrumbSeparator separator)
        {
            _separator = separator;
            return this;
        }

        /// <summary>
        /// Set aria label for accessibility
        /// </summary>
        public TablerBreadcrumb AriaLabel(string label)
        {
            _ariaLabel = label;
            return this;
        }

        /// <summary>
        /// Renders the breadcrumb to HTML string
        /// </summary>
        /// <returns>HTML representation of the breadcrumb</returns>
        public override string ToString()
        {
            var breadcrumb = new HtmlTag("ol");
            breadcrumb.Class("breadcrumb");
            
            if (!string.IsNullOrEmpty(_ariaLabel))
                breadcrumb.Attribute("aria-label", _ariaLabel!);
            
            // Apply style
            if (_style == TablerBreadcrumbStyle.Dots)
                breadcrumb.Class("breadcrumb-dots");
            else if (_style == TablerBreadcrumbStyle.Arrows)
                breadcrumb.Class("breadcrumb-arrows");
            else if (_style == TablerBreadcrumbStyle.Bullets)
                breadcrumb.Class("breadcrumb-bullets");
            
            // Apply custom separator
            if (_separator != TablerBreadcrumbSeparator.Default)
            {
                var separatorChar = _separator switch
                {
                    TablerBreadcrumbSeparator.Slash => "/",
                    TablerBreadcrumbSeparator.Arrow => ">",
                    TablerBreadcrumbSeparator.Dot => "•",
                    TablerBreadcrumbSeparator.Pipe => "|",
                    _ => "/"
                };
                breadcrumb.Style("--tblr-breadcrumb-divider", $"'{separatorChar}'");
            }
            
            // Add items
            for (int i = 0; i < _items.Count; i++)
            {
                var item = _items[i];
                var isLast = i == _items.Count - 1;
                
                var li = new HtmlTag("li");
                li.Class("breadcrumb-item");
                
                if (item.IsActive || isLast)
                {
                    li.Class("active");
                    li.Attribute("aria-current", "page");
                }
                
                // Content
                if (!item.IsActive && !isLast && !string.IsNullOrEmpty(item.Href))
                {
                    var link = new HtmlTag("a");
                    link.Attribute("href", item.Href!);
                    
                    if (item.Icon.HasValue)
                    {
                        link.Value(TablerIconLibrary.GetIcon(item.Icon.Value).ToString());
                    }
                    
                    link.Value(item.Text);
                    li.Value(link.ToString());
                }
                else
                {
                    if (item.Icon.HasValue)
                    {
                        li.Value(TablerIconLibrary.GetIcon(item.Icon.Value).ToString());
                    }
                    
                    li.Value(item.Text);
                }
                
                breadcrumb.Value(li.ToString());
            }
            
            return breadcrumb.ToString();
        }

        /// <summary>
        /// Create breadcrumb with fluent configuration
        /// </summary>
        public static TablerBreadcrumb Create(Action<TablerBreadcrumb> configure)
        {
            var breadcrumb = new TablerBreadcrumb();
            configure(breadcrumb);
            return breadcrumb;
        }

        /// <summary>
        /// Internal class representing a breadcrumb item
        /// </summary>
        private class BreadcrumbItem
        {
            /// <summary>
            /// Gets or sets the item text
            /// </summary>
            public string Text { get; set; } = "";
            /// <summary>
            /// Gets or sets the item URL
            /// </summary>
            public string? Href { get; set; }
            /// <summary>
            /// Gets or sets the item icon
            /// </summary>
            public TablerIconType? Icon { get; set; }
            /// <summary>
            /// Gets or sets whether this is the active/current item
            /// </summary>
            public bool IsActive { get; set; }
        }
    }

    /// <summary>
    /// Represents breadcrumb style options
    /// </summary>
    public enum TablerBreadcrumbStyle
    {
        /// <summary>
        /// Default breadcrumb style
        /// </summary>
        Default,
        /// <summary>
        /// Dots style
        /// </summary>
        Dots,
        /// <summary>
        /// Arrows style
        /// </summary>
        Arrows,
        /// <summary>
        /// Bullets style
        /// </summary>
        Bullets
    }

    /// <summary>
    /// Represents breadcrumb separator options
    /// </summary>
    public enum TablerBreadcrumbSeparator
    {
        /// <summary>
        /// Default separator (slash)
        /// </summary>
        Default,
        /// <summary>
        /// Forward slash separator
        /// </summary>
        Slash,
        /// <summary>
        /// Arrow separator
        /// </summary>
        Arrow,
        /// <summary>
        /// Dot separator
        /// </summary>
        Dot,
        /// <summary>
        /// Pipe separator
        /// </summary>
        Pipe
    }
}