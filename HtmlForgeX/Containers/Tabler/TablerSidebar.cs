using System.Text;

namespace HtmlForgeX.Containers.Tabler
{
    /// <summary>
    /// Tabler sidebar component for vertical navigation
    /// </summary>
    public class TablerSidebar : Element
    {
        private string? _brand;
        private string? _brandUrl = ".";
        private string? _logoUrl;
        private readonly List<TablerSidebarItem> _items = new();
        private TablerSidebarStyle _style = TablerSidebarStyle.Default;
        private bool _sticky = false;
        private bool _collapsible = true;
        private bool _showToggle = true;
        private string? _footer;
        private TablerUserProfile? _userProfile;

        /// <summary>
        /// Initializes a new instance of the TablerSidebar class
        /// </summary>
        public TablerSidebar() : base()
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
        /// Set brand text and URL
        /// </summary>
        public TablerSidebar Brand(string text, string url = ".")
        {
            _brand = text;
            _brandUrl = url;
            return this;
        }

        /// <summary>
        /// Set logo image URL
        /// </summary>
        public TablerSidebar Logo(string logoUrl, string? brandUrl = null)
        {
            _logoUrl = logoUrl;
            if (brandUrl != null)
                _brandUrl = brandUrl;
            return this;
        }

        /// <summary>
        /// Set sidebar style
        /// </summary>
        public TablerSidebar Style(TablerSidebarStyle style)
        {
            _style = style;
            return this;
        }

        /// <summary>
        /// Make sidebar sticky
        /// </summary>
        public TablerSidebar Sticky(bool sticky = true)
        {
            _sticky = sticky;
            return this;
        }

        /// <summary>
        /// Set collapsible behavior
        /// </summary>
        public TablerSidebar Collapsible(bool collapsible = true)
        {
            _collapsible = collapsible;
            return this;
        }

        /// <summary>
        /// Show/hide mobile toggle button
        /// </summary>
        public TablerSidebar ShowToggle(bool show = true)
        {
            _showToggle = show;
            return this;
        }

        /// <summary>
        /// Add navigation item
        /// </summary>
        public TablerSidebar Item(string text, string? href = null)
        {
            _items.Add(new TablerSidebarLink(text, href));
            return this;
        }

        /// <summary>
        /// Add navigation item with icon
        /// </summary>
        public TablerSidebar Item(string text, TablerIconType icon, string? href = null)
        {
            _items.Add(new TablerSidebarLink(text, href) { Icon = icon });
            return this;
        }

        /// <summary>
        /// Add navigation item with badge
        /// </summary>
        public TablerSidebar Item(string text, string badge, string? href = null)
        {
            _items.Add(new TablerSidebarLink(text, href) { Badge = badge });
            return this;
        }

        /// <summary>
        /// Add navigation section header
        /// </summary>
        public TablerSidebar Section(string title)
        {
            _items.Add(new TablerSidebarSection(title));
            return this;
        }

        /// <summary>
        /// Add divider
        /// </summary>
        public TablerSidebar Divider()
        {
            _items.Add(new TablerSidebarDivider());
            return this;
        }

        /// <summary>
        /// Add dropdown menu
        /// </summary>
        public TablerSidebar Dropdown(string text, Action<TablerSidebarDropdown> configure)
        {
            var dropdown = new TablerSidebarDropdown(text);
            configure(dropdown);
            _items.Add(dropdown);
            return this;
        }

        /// <summary>
        /// Add dropdown menu with icon
        /// </summary>
        public TablerSidebar Dropdown(string text, TablerIconType icon, Action<TablerSidebarDropdown> configure)
        {
            var dropdown = new TablerSidebarDropdown(text) { Icon = icon };
            configure(dropdown);
            _items.Add(dropdown);
            return this;
        }

        /// <summary>
        /// Set footer content
        /// </summary>
        public TablerSidebar Footer(string html)
        {
            _footer = html;
            return this;
        }

        /// <summary>
        /// Set user profile section
        /// </summary>
        public TablerSidebar UserProfile(string name, string? title = null, string? avatarUrl = null)
        {
            _userProfile = new TablerUserProfile
            {
                Name = name,
                Title = title,
                AvatarUrl = avatarUrl
            };
            return this;
        }

        /// <summary>
        /// Configure user profile with fluent API
        /// </summary>
        public TablerSidebar UserProfile(Action<TablerUserProfile> configure)
        {
            _userProfile = new TablerUserProfile();
            configure(_userProfile);
            return this;
        }

        /// <summary>
        /// Renders the sidebar to HTML string
        /// </summary>
        /// <returns>HTML representation of the sidebar</returns>
        public override string ToString()
        {
            var sidebar = new HtmlTag("aside");
            sidebar.Class("navbar");
            sidebar.Class("navbar-vertical");
            sidebar.Class("navbar-expand-lg");
            
            if (_style == TablerSidebarStyle.Dark)
                sidebar.Class("navbar-dark");
            else if (_style == TablerSidebarStyle.Light)
                sidebar.Class("navbar-light");
            else if (_style == TablerSidebarStyle.Transparent)
                sidebar.Class("navbar-transparent");
            
            if (_sticky)
                sidebar.Class("navbar-sticky");

            var container = new HtmlTag("div").Class("container-fluid");

            // Mobile toggle and brand
            if (_showToggle)
            {
                var toggle = new HtmlTag("button");
                toggle.Class("navbar-toggler");
                toggle.Attribute("type", "button");
                toggle.Attribute("data-bs-toggle", "collapse");
                toggle.Attribute("data-bs-target", "#sidebar-menu");
                toggle.Value(new TablerTogglerIcon().ToString());
                container.Value(toggle.ToString());
            }

            // Brand/Logo
            container.Value(RenderBrand());

            // Collapsible wrapper
            var navContent = new HtmlTag("div");
            if (_collapsible)
            {
                navContent.Class("collapse").Class("navbar-collapse");
                navContent.Attribute("id", "sidebar-menu");
            }

            // Main navigation
            var nav = new HtmlTag("div").Class("navbar-nav").Class("pt-lg-3");

            // User profile at top (if configured)
            if (_userProfile != null)
            {
                nav.Value(RenderUserProfileSection());
                if (_items.Any())
                {
                    nav.Value(new TablerDivider().Type(TablerDividerType.Navbar).MarginY(3).ToString());
                }
            }

            // Navigation items
            foreach (var item in _items)
            {
                nav.Value(item.Render());
            }

            navContent.Value(nav.ToString());

            // Footer
            if (!string.IsNullOrEmpty(_footer))
            {
                var footerDiv = new HtmlTag("div").Class("navbar-footer");
                footerDiv.Value(_footer);
                navContent.Value(footerDiv.ToString());
            }

            if (_collapsible)
            {
                container.Value(navContent.ToString());
            }
            else
            {
                container.Value(nav.ToString());
                if (!string.IsNullOrEmpty(_footer))
                {
                    var footerDiv = new HtmlTag("div").Class("navbar-footer");
                    footerDiv.Value(_footer);
                    container.Value(footerDiv.ToString());
                }
            }

            sidebar.Value(container.ToString());
            return sidebar.ToString();
        }

        /// <summary>
        /// Renders the brand/logo section
        /// </summary>
        /// <returns>HTML string for the brand section</returns>
        private string RenderBrand()
        {
            var brand = new HtmlTag("h1").Class("navbar-brand").Class("navbar-brand-autodark");
            var link = new HtmlTag("a").Attribute("href", _brandUrl!).Attribute("aria-label", _brand ?? "Home");
            
            if (!string.IsNullOrEmpty(_logoUrl))
            {
                var img = new HtmlTag("img");
                img.Attribute("src", _logoUrl!);
                img.Attribute("alt", _brand ?? "Logo");
                img.Class("navbar-brand-image");
                link.Value(img.ToString());
            }
            else if (!string.IsNullOrEmpty(_brand))
            {
                link.Value(_brand);
            }
            
            brand.Value(link.ToString());
            return brand.ToString();
        }

        /// <summary>
        /// Renders the user profile section in the sidebar
        /// </summary>
        /// <returns>HTML string for the user profile section</returns>
        private string RenderUserProfileSection()
        {
            if (_userProfile == null) return "";

            var dropdown = new HtmlTag("div").Class("nav-item").Class("dropdown");
            var toggle = new HtmlTag("a");
            toggle.Attribute("href", "#");
            toggle.Class("nav-link").Class("d-flex").Class("lh-1").Class("text-reset").Class("p-0");
            toggle.Attribute("data-bs-toggle", "dropdown");
            toggle.Attribute("aria-label", "Open user menu");
            
            // Avatar
            var avatar = new HtmlTag("span").Class("avatar").Class("avatar-sm");
            if (!string.IsNullOrEmpty(_userProfile.AvatarUrl))
            {
                avatar.Style("background-image", $"url({_userProfile.AvatarUrl})");
            }
            else
            {
                var initials = GetInitials(_userProfile.Name);
                avatar.Value(initials);
            }
            toggle.Value(avatar.ToString());
            
            // Name and title
            var info = new HtmlTag("div").Class("ps-2");
            var nameDiv = new HtmlTag("div").Value(_userProfile.Name);
            info.Value(nameDiv.ToString());
            if (!string.IsNullOrEmpty(_userProfile.Title))
            {
                var titleDiv = new HtmlTag("div").Class("mt-1").Class("small").Class("text-secondary").Value(_userProfile.Title);
                info.Value(titleDiv.ToString());
            }
            toggle.Value(info.ToString());
            
            dropdown.Value(toggle.ToString());
            
            // Dropdown menu
            var menu = new HtmlTag("div").Class("dropdown-menu").Class("dropdown-menu-end").Class("dropdown-menu-arrow");
            
            foreach (var item in _userProfile.MenuItems)
            {
                if (item.IsDivider)
                {
                    menu.Value(new TablerDivider().Type(TablerDividerType.Dropdown).ToString());
                }
                else
                {
                    var link = new HtmlTag("a");
                    link.Attribute("href", item.Href);
                    link.Class("dropdown-item");
                    if (item.Icon.HasValue)
                    {
                        link.Value(TablerIconLibrary.GetIcon(item.Icon.Value).ToString());
                    }
                    link.Value(item.Text);
                    menu.Value(link.ToString());
                }
            }
            
            dropdown.Value(menu.ToString());
            return dropdown.ToString();
        }

        /// <summary>
        /// Extracts initials from a full name
        /// </summary>
        /// <param name="name">Full name to extract initials from</param>
        /// <returns>Uppercase initials (first and last name first letters)</returns>
        private string GetInitials(string name)
        {
            var parts = name.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length >= 2)
                return $"{parts[0][0]}{parts[parts.Length - 1][0]}".ToUpper();
            return name.Length > 0 ? name[0].ToString().ToUpper() : "?";
        }

        /// <summary>
        /// Create sidebar with fluent configuration
        /// </summary>
        public static TablerSidebar Create(Action<TablerSidebar> configure)
        {
            var sidebar = new TablerSidebar();
            configure(sidebar);
            return sidebar;
        }
    }

    /// <summary>
    /// Base class for sidebar items
    /// </summary>
    public abstract class TablerSidebarItem
    {
        /// <summary>
        /// Renders the sidebar item to HTML string
        /// </summary>
        /// <returns>HTML representation of the sidebar item</returns>
        public abstract string Render();
    }

    /// <summary>
    /// Sidebar link item
    /// </summary>
    public class TablerSidebarLink : TablerSidebarItem
    {
        /// <summary>
        /// Gets the link text
        /// </summary>
        public string Text { get; }
        
        /// <summary>
        /// Gets the link href URL
        /// </summary>
        public string? Href { get; }
        
        /// <summary>
        /// Gets or sets the optional link icon
        /// </summary>
        public TablerIconType? Icon { get; set; }
        
        /// <summary>
        /// Gets or sets the optional badge text
        /// </summary>
        public string? Badge { get; set; }
        
        /// <summary>
        /// Gets or sets whether the link is active
        /// </summary>
        public bool Active { get; set; }
        
        /// <summary>
        /// Gets or sets whether the link is disabled
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// Initializes a new instance of the TablerSidebarLink class
        /// </summary>
        /// <param name="text">Link text</param>
        /// <param name="href">Link href URL (optional)</param>
        public TablerSidebarLink(string text, string? href = null)
        {
            Text = text;
            Href = href;
        }

        /// <summary>
        /// Renders the sidebar link to HTML string
        /// </summary>
        /// <returns>HTML representation of the sidebar link</returns>
        public override string Render()
        {
            var link = new HtmlTag("a");
            link.Class("nav-link");
            if (Active) link.Class("active");
            if (Disabled) link.Class("disabled");
            
            link.Attribute("href", Href ?? "#");
            if (Disabled) 
            {
                link.Attribute("tabindex", "-1");
                link.Attribute("aria-disabled", "true");
            }

            if (Icon.HasValue)
            {
                var iconSpan = new HtmlTag("span").Class("nav-link-icon").Class("d-md-none").Class("d-lg-inline-block");
                iconSpan.Value(TablerIconLibrary.GetIcon(Icon.Value).ToString());
                link.Value(iconSpan.ToString());
            }

            var titleSpan = new HtmlTag("span").Class("nav-link-title");
            titleSpan.Value(Text);
            link.Value(titleSpan.ToString());

            if (!string.IsNullOrEmpty(Badge))
            {
                var badge = new TablerBadge(Badge!)
                    .Color(TablerBadgeColor.Green)
                    .Style(TablerBadgeStyle.Light)
                    .Size(TablerBadgeSize.Small);
                badge.ContainerClasses = "text-uppercase ms-auto";
                link.Value(badge.ToString());
            }

            return link.ToString();
        }
    }

    /// <summary>
    /// Sidebar section header
    /// </summary>
    public class TablerSidebarSection : TablerSidebarItem
    {
        /// <summary>
        /// Gets the section title
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Initializes a new instance of the TablerSidebarSection class
        /// </summary>
        /// <param name="title">Section title</param>
        public TablerSidebarSection(string title)
        {
            Title = title;
        }

        /// <summary>
        /// Renders the sidebar section to HTML string
        /// </summary>
        /// <returns>HTML representation of the sidebar section</returns>
        public override string Render()
        {
            var subtitle = new HtmlTag("div").Class("nav-subtitle").Value(Title);
            return subtitle.ToString();
        }
    }

    /// <summary>
    /// Sidebar divider
    /// </summary>
    public class TablerSidebarDivider : TablerSidebarItem
    {
        /// <summary>
        /// Renders the sidebar divider to HTML string
        /// </summary>
        /// <returns>HTML representation of the sidebar divider</returns>
        public override string Render()
        {
            return new TablerDivider().Type(TablerDividerType.Navbar).MarginY(2).ToString();
        }
    }

    /// <summary>
    /// Sidebar dropdown menu
    /// </summary>
    public class TablerSidebarDropdown : TablerSidebarItem
    {
        /// <summary>
        /// Gets the dropdown text
        /// </summary>
        public string Text { get; }
        
        /// <summary>
        /// Gets or sets the optional dropdown icon
        /// </summary>
        public TablerIconType? Icon { get; set; }
        
        /// <summary>
        /// Gets or sets whether the dropdown is active
        /// </summary>
        public bool Active { get; set; }
        
        /// <summary>
        /// Gets or sets whether the dropdown is expanded
        /// </summary>
        public bool Expanded { get; set; }
        
        private readonly List<TablerSidebarLink> _items = new();

        /// <summary>
        /// Initializes a new instance of the TablerSidebarDropdown class
        /// </summary>
        /// <param name="text">Dropdown text</param>
        public TablerSidebarDropdown(string text)
        {
            Text = text;
        }

        /// <summary>
        /// Adds an item to the dropdown menu
        /// </summary>
        /// <param name="text">Item text</param>
        /// <param name="href">Item href URL (optional)</param>
        /// <returns>This TablerSidebarDropdown instance for method chaining</returns>
        public TablerSidebarDropdown Item(string text, string? href = null)
        {
            _items.Add(new TablerSidebarLink(text, href));
            return this;
        }

        /// <summary>
        /// Adds an item with a badge to the dropdown menu
        /// </summary>
        /// <param name="text">Item text</param>
        /// <param name="href">Item href URL (optional)</param>
        /// <param name="badge">Badge text</param>
        /// <returns>This TablerSidebarDropdown instance for method chaining</returns>
        public TablerSidebarDropdown Item(string text, string? href, string badge)
        {
            _items.Add(new TablerSidebarLink(text, href) { Badge = badge });
            return this;
        }

        /// <summary>
        /// Renders the sidebar dropdown to HTML string
        /// </summary>
        /// <returns>HTML representation of the sidebar dropdown</returns>
        public override string Render()
        {
            var dropdownId = $"dropdown-{Guid.NewGuid():N}";
            var dropdown = new HtmlTag("div");
            dropdown.Class("nav-item").Class("dropdown");
            if (Active) dropdown.Class("active");

            // Toggle link
            var toggle = new HtmlTag("a");
            toggle.Class("nav-link").Class("dropdown-toggle");
            toggle.Attribute("href", $"#navbar-{dropdownId}");
            toggle.Attribute("data-bs-toggle", "dropdown");
            toggle.Attribute("data-bs-auto-close", "false");
            toggle.Attribute("role", "button");
            toggle.Attribute("aria-expanded", Expanded ? "true" : "false");

            if (Icon.HasValue)
            {
                var iconSpan = new HtmlTag("span").Class("nav-link-icon").Class("d-md-none").Class("d-lg-inline-block");
                iconSpan.Value(TablerIconLibrary.GetIcon(Icon.Value).ToString());
                toggle.Value(iconSpan.ToString());
            }

            var titleSpan = new HtmlTag("span").Class("nav-link-title");
            titleSpan.Value(Text);
            toggle.Value(titleSpan.ToString());
            
            dropdown.Value(toggle.ToString());

            // Dropdown menu
            var menu = new HtmlTag("div");
            menu.Class("dropdown-menu");
            if (Expanded) menu.Class("show");
            
            var menuColumns = new HtmlTag("div").Class("dropdown-menu-columns");
            var menuColumn = new HtmlTag("div").Class("dropdown-menu-column");

            foreach (var item in _items)
            {
                menuColumn.Value(item.Render());
            }

            menuColumns.Value(menuColumn.ToString());
            menu.Value(menuColumns.ToString());
            dropdown.Value(menu.ToString());

            return dropdown.ToString();
        }
    }

    /// <summary>
    /// Defines sidebar style options
    /// </summary>
    public enum TablerSidebarStyle
    {
        /// <summary>
        /// Default sidebar style
        /// </summary>
        Default,
        
        /// <summary>
        /// Dark sidebar style
        /// </summary>
        Dark,
        
        /// <summary>
        /// Light sidebar style
        /// </summary>
        Light,
        
        /// <summary>
        /// Transparent sidebar style
        /// </summary>
        Transparent
    }
}