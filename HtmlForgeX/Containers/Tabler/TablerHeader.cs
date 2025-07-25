using System.Text;

namespace HtmlForgeX.Containers.Tabler
{
    /// <summary>
    /// Tabler header/navbar component for professional navigation
    /// </summary>
    public class TablerHeader : Element
    {
        private string? _brandText;
        private string? _brandUrl = ".";
        private string? _logoUrl;
        private bool _darkModeToggle = true;
        private bool _notificationBell = true;
        private bool _appMenu = false;
        private TablerUserProfile? _userProfile;
        private readonly List<TablerHeaderItem> _items = new();
        private readonly List<TablerNotification> _notifications = new();
        private readonly List<TablerAppMenuItem> _appMenuItems = new();
        private TablerHeaderStyle _style = TablerHeaderStyle.Default;
        private bool _sticky = false;
        private bool _autoHide = false;

        /// <summary>
        /// Initializes a new instance of the TablerHeader class
        /// </summary>
        public TablerHeader() : base()
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
        public TablerHeader Brand(string text, string url = ".")
        {
            _brandText = text;
            _brandUrl = url;
            return this;
        }

        /// <summary>
        /// Set logo image URL
        /// </summary>
        public TablerHeader Logo(string logoUrl, string? brandUrl = null)
        {
            _logoUrl = logoUrl;
            if (brandUrl != null)
                _brandUrl = brandUrl;
            return this;
        }

        /// <summary>
        /// Set header style
        /// </summary>
        public TablerHeader Style(TablerHeaderStyle style)
        {
            _style = style;
            return this;
        }

        /// <summary>
        /// Make header sticky
        /// </summary>
        public TablerHeader Sticky(bool sticky = true)
        {
            _sticky = sticky;
            return this;
        }

        /// <summary>
        /// Enable auto-hide on scroll
        /// </summary>
        public TablerHeader AutoHide(bool autoHide = true)
        {
            _autoHide = autoHide;
            return this;
        }

        /// <summary>
        /// Enable/disable dark mode toggle
        /// </summary>
        public TablerHeader DarkModeToggle(bool enable = true)
        {
            _darkModeToggle = enable;
            return this;
        }

        /// <summary>
        /// Enable/disable notification bell
        /// </summary>
        public TablerHeader NotificationBell(bool enable = true)
        {
            _notificationBell = enable;
            return this;
        }

        /// <summary>
        /// Enable app menu dropdown
        /// </summary>
        public TablerHeader AppMenu(bool enable = true)
        {
            _appMenu = enable;
            return this;
        }

        /// <summary>
        /// Add notification
        /// </summary>
        public TablerHeader Notification(string title, string? description = null, TablerNotificationType type = TablerNotificationType.Default)
        {
            _notifications.Add(new TablerNotification
            {
                Title = title,
                Description = description,
                Type = type
            });
            return this;
        }

        /// <summary>
        /// Add notification with configuration
        /// </summary>
        public TablerHeader Notification(Action<TablerNotification> configure)
        {
            var notification = new TablerNotification();
            configure(notification);
            _notifications.Add(notification);
            return this;
        }

        /// <summary>
        /// Add app menu item
        /// </summary>
        public TablerHeader AppMenuItem(string name, string iconUrl, string? href = null)
        {
            _appMenuItems.Add(new TablerAppMenuItem
            {
                Name = name,
                IconUrl = iconUrl,
                Href = href
            });
            return this;
        }

        /// <summary>
        /// Set user profile
        /// </summary>
        public TablerHeader UserProfile(string name, string? title = null, string? avatarUrl = null)
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
        public TablerHeader UserProfile(Action<TablerUserProfile> configure)
        {
            _userProfile = new TablerUserProfile();
            configure(_userProfile);
            return this;
        }

        /// <summary>
        /// Add header action button
        /// </summary>
        public TablerHeader Action(string text, string href, TablerButtonVariant variant = TablerButtonVariant.Primary)
        {
            _items.Add(new TablerHeaderButton(text, href, variant));
            return this;
        }

        /// <summary>
        /// Add header action button with icon
        /// </summary>
        public TablerHeader Action(string text, string href, TablerIconType icon, TablerButtonVariant variant = TablerButtonVariant.Primary)
        {
            _items.Add(new TablerHeaderButton(text, href, variant) { Icon = icon });
            return this;
        }

        /// <summary>
        /// Add custom header item
        /// </summary>
        public TablerHeader Item(Action<HtmlTag> configure)
        {
            var container = new HtmlTag("div");
            container.Class("nav-item");
            configure(container);
            _items.Add(new TablerHeaderCustom(container));
            return this;
        }

        /// <summary>
        /// Renders the header to HTML string
        /// </summary>
        /// <returns>HTML representation of the header</returns>
        public override string ToString()
        {
            var header = new HtmlTag("header");
            header.Class("navbar");
            header.Class("navbar-expand-md");
            header.Class("d-print-none");
            
            if (_style == TablerHeaderStyle.Dark)
                header.Class("navbar-dark");
            else if (_style == TablerHeaderStyle.Light)
                header.Class("navbar-light");
            else if (_style == TablerHeaderStyle.Transparent)
                header.Class("navbar-transparent");
            
            if (_sticky)
                header.Class("navbar-sticky");
            if (_autoHide)
                header.Class("navbar-overlap");

            // Main container
            var container = new HtmlTag("div").Class("container-xl");

            // Mobile toggle button
            var toggler = new HtmlTag("button");
            toggler.Class("navbar-toggler");
            toggler.Attribute("type", "button");
            toggler.Attribute("data-bs-toggle", "collapse");
            toggler.Attribute("data-bs-target", "#navbar-menu");
            toggler.Attribute("aria-controls", "navbar-menu");
            toggler.Attribute("aria-expanded", "false");
            toggler.Attribute("aria-label", "Toggle navigation");
            toggler.Value(new TablerTogglerIcon().ToString());
            container.Value(toggler.ToString());

            // Brand/Logo
            container.Value(RenderBrand());

            // Right side items
            var navItems = new HtmlTag("div").Class("navbar-nav").Class("flex-row").Class("order-md-last");

            // Custom action items (like GitHub/Sponsor buttons)
            foreach (var item in _items.OfType<TablerHeaderButton>())
            {
                var itemDiv = new HtmlTag("div").Class("nav-item").Class("d-none").Class("d-md-flex").Class("me-3");
                var btnList = new HtmlTag("div").Class("btn-list");
                btnList.Value(item.Render());
                itemDiv.Value(btnList.ToString());
                navItems.Value(itemDiv.ToString());
            }

            // Dark mode toggle
            if (_darkModeToggle)
            {
                navItems.Value(RenderDarkModeToggle());
            }

            // Notification bell
            if (_notificationBell && _notifications.Any())
            {
                navItems.Value(RenderNotificationBell());
            }

            // App menu
            if (_appMenu && _appMenuItems.Any())
            {
                navItems.Value(RenderAppMenu());
            }

            // User profile dropdown
            if (_userProfile != null)
            {
                navItems.Value(RenderUserProfile());
            }

            // Custom items
            foreach (var item in _items.OfType<TablerHeaderCustom>())
            {
                navItems.Value(item.Render());
            }

            container.Value(navItems.ToString());
            header.Value(container.ToString());
            
            return header.ToString();
        }

        /// <summary>
        /// Renders the brand/logo section
        /// </summary>
        /// <returns>HTML string for the brand section</returns>
        private string RenderBrand()
        {
            var brand = new HtmlTag("div");
            brand.Class("navbar-brand");
            brand.Class("navbar-brand-autodark");
            brand.Class("d-none-navbar-horizontal");
            brand.Class("pe-0");
            brand.Class("pe-md-3");
            
            var link = new HtmlTag("a").Attribute("href", _brandUrl!);
            
            if (!string.IsNullOrEmpty(_logoUrl))
            {
                var img = new HtmlTag("img");
                img.Attribute("src", _logoUrl!);
                img.Attribute("alt", _brandText ?? "Logo");
                img.Class("navbar-brand-image");
                link.Value(img.ToString());
            }
            else if (!string.IsNullOrEmpty(_brandText))
            {
                link.Value(_brandText);
            }
            
            brand.Value(link.ToString());
            return brand.ToString();
        }

        /// <summary>
        /// Renders the dark mode toggle buttons
        /// </summary>
        /// <returns>HTML string for the dark mode toggle</returns>
        private string RenderDarkModeToggle()
        {
            var wrapper = new HtmlTag("div").Class("d-none").Class("d-md-flex");
            var navItem = new HtmlTag("div").Class("nav-item");
            
            // Dark mode button
            var darkLink = new HtmlTag("a");
            darkLink.Attribute("href", "?theme=dark");
            darkLink.Class("nav-link").Class("px-0").Class("hide-theme-dark");
            darkLink.Attribute("title", "Enable dark mode");
            darkLink.Attribute("data-bs-toggle", "tooltip");
            darkLink.Attribute("data-bs-placement", "bottom");
            darkLink.Value(TablerIconLibrary.GetIcon(TablerIconType.Moon).ToString());
            navItem.Value(darkLink.ToString());
            
            // Light mode button
            var lightLink = new HtmlTag("a");
            lightLink.Attribute("href", "?theme=light");
            lightLink.Class("nav-link").Class("px-0").Class("hide-theme-light");
            lightLink.Attribute("title", "Enable light mode");
            lightLink.Attribute("data-bs-toggle", "tooltip");
            lightLink.Attribute("data-bs-placement", "bottom");
            lightLink.Value(TablerIconLibrary.GetIcon(TablerIconType.Sun).ToString());
            navItem.Value(lightLink.ToString());
            
            wrapper.Value(navItem.ToString());
            return wrapper.ToString();
        }

        /// <summary>
        /// Renders the notification bell dropdown
        /// </summary>
        /// <returns>HTML string for the notification bell</returns>
        private string RenderNotificationBell()
        {
            var dropdown = new HtmlTag("div").Class("nav-item").Class("dropdown").Class("d-none").Class("d-md-flex");
            
            var toggle = new HtmlTag("a");
            toggle.Attribute("href", "#");
            toggle.Class("nav-link").Class("px-0");
            toggle.Attribute("data-bs-toggle", "dropdown");
            toggle.Attribute("tabindex", "-1");
            toggle.Attribute("aria-label", "Show notifications");
            toggle.Attribute("data-bs-auto-close", "outside");
            
            toggle.Value(TablerIconLibrary.GetIcon(TablerIconType.Bell).ToString());
            
            if (_notifications.Any(n => n.Type == TablerNotificationType.Error || n.Type == TablerNotificationType.Warning))
            {
                var badge = new TablerBadge("").Color(TablerBadgeColor.Red).Size(TablerBadgeSize.Small);
                toggle.Value(badge.ToString());
            }
            
            dropdown.Value(toggle.ToString());
            
            // Dropdown menu
            var menu = new HtmlTag("div").Class("dropdown-menu").Class("dropdown-menu-arrow").Class("dropdown-menu-end").Class("dropdown-menu-card");
            var card = new HtmlTag("div").Class("card");
            
            var cardHeader = new HtmlTag("div").Class("card-header").Class("d-flex");
            var cardTitle = new HtmlTag("h3").Class("card-title").Value("Notifications");
            cardHeader.Value(cardTitle.ToString());
            var btnClose = new TablerCloseButton().Dismiss("dropdown").MarginStart("auto");
            cardHeader.Value(btnClose.ToString());
            card.Value(cardHeader.ToString());
            
            var listGroup = new HtmlTag("div").Class("list-group").Class("list-group-flush").Class("list-group-hoverable");
            foreach (var notification in _notifications.Take(5))
            {
                listGroup.Value(notification.Render());
            }
            card.Value(listGroup.ToString());
            
            var cardBody = new HtmlTag("div").Class("card-body");
            var row = new HtmlTag("div").Class("row");
            var col1 = new HtmlTag("div").Class("col");
            col1.Value(new TablerButton("Archive all", "#", TablerButtonVariant.Secondary).FullWidth(true).ToString());
            row.Value(col1.ToString());
            var col2 = new HtmlTag("div").Class("col");
            col2.Value(new TablerButton("Mark all as read", "#", TablerButtonVariant.Secondary).FullWidth(true).ToString());
            row.Value(col2.ToString());
            cardBody.Value(row.ToString());
            card.Value(cardBody.ToString());
            
            menu.Value(card.ToString());
            dropdown.Value(menu.ToString());
            
            return dropdown.ToString();
        }

        /// <summary>
        /// Renders the app menu dropdown
        /// </summary>
        /// <returns>HTML string for the app menu</returns>
        private string RenderAppMenu()
        {
            var dropdown = new HtmlTag("div").Class("nav-item").Class("dropdown").Class("d-none").Class("d-md-flex").Class("me-3");
            
            var toggle = new HtmlTag("a");
            toggle.Attribute("href", "#");
            toggle.Class("nav-link").Class("px-0");
            toggle.Attribute("data-bs-toggle", "dropdown");
            toggle.Attribute("tabindex", "-1");
            toggle.Attribute("aria-label", "Show app menu");
            toggle.Attribute("data-bs-auto-close", "outside");
            toggle.Value(TablerIconLibrary.GetIcon(TablerIconType.Apps).ToString());
            dropdown.Value(toggle.ToString());
            
            // Dropdown menu
            var menu = new HtmlTag("div").Class("dropdown-menu").Class("dropdown-menu-arrow").Class("dropdown-menu-end").Class("dropdown-menu-card");
            var card = new HtmlTag("div").Class("card");
            
            var cardHeader = new HtmlTag("div").Class("card-header");
            var cardTitle = new HtmlTag("div").Class("card-title").Value("My Apps");
            cardHeader.Value(cardTitle.ToString());
            var actions = new HtmlTag("div").Class("card-actions").Class("btn-actions");
            var settingsLink = new HtmlTag("a").Attribute("href", "#").Class("btn-action");
            settingsLink.Value(TablerIconLibrary.GetIcon(TablerIconType.Settings).ToString());
            actions.Value(settingsLink.ToString());
            cardHeader.Value(actions.ToString());
            card.Value(cardHeader.ToString());
            
            var cardBody = new HtmlTag("div").Class("card-body").Class("scroll-y").Class("p-2");
            cardBody.Style("max-height", "50vh");
            var appsRow = new HtmlTag("div").Class("row").Class("g-0");
            
            foreach (var app in _appMenuItems)
            {
                appsRow.Value(app.Render());
            }
            
            cardBody.Value(appsRow.ToString());
            card.Value(cardBody.ToString());
            menu.Value(card.ToString());
            dropdown.Value(menu.ToString());
            
            return dropdown.ToString();
        }

        /// <summary>
        /// Renders the user profile dropdown
        /// </summary>
        /// <returns>HTML string for the user profile dropdown</returns>
        private string RenderUserProfile()
        {
            if (_userProfile == null) return "";
            
            var dropdown = new HtmlTag("div").Class("nav-item").Class("dropdown");
            
            var toggle = new HtmlTag("a");
            toggle.Attribute("href", "#");
            toggle.Class("nav-link").Class("d-flex").Class("lh-1").Class("p-0").Class("px-2");
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
            var info = new HtmlTag("div").Class("d-none").Class("d-xl-block").Class("ps-2");
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
        /// Create header with fluent configuration
        /// </summary>
        public static TablerHeader Create(Action<TablerHeader> configure)
        {
            var header = new TablerHeader();
            configure(header);
            return header;
        }
    }

    /// <summary>
    /// Base class for header items
    /// </summary>
    public abstract class TablerHeaderItem
    {
        /// <summary>
        /// Renders the header item to HTML string
        /// </summary>
        /// <returns>HTML representation of the header item</returns>
        public abstract string Render();
    }

    /// <summary>
    /// Header button item
    /// </summary>
    public class TablerHeaderButton : TablerHeaderItem
    {
        /// <summary>
        /// Gets the button text
        /// </summary>
        public string Text { get; }
        
        /// <summary>
        /// Gets the button href URL
        /// </summary>
        public string Href { get; }
        
        /// <summary>
        /// Gets the button variant
        /// </summary>
        public TablerButtonVariant Variant { get; }
        
        /// <summary>
        /// Gets or sets the optional button icon
        /// </summary>
        public TablerIconType? Icon { get; set; }

        /// <summary>
        /// Initializes a new instance of the TablerHeaderButton class
        /// </summary>
        /// <param name="text">Button text</param>
        /// <param name="href">Button href URL</param>
        /// <param name="variant">Button variant style</param>
        public TablerHeaderButton(string text, string href, TablerButtonVariant variant)
        {
            Text = text;
            Href = href;
            Variant = variant;
        }

        /// <summary>
        /// Renders the header button to HTML string
        /// </summary>
        /// <returns>HTML representation of the header button</returns>
        public override string Render()
        {
            var button = new TablerButton(Text, Href, Variant);
            if (Icon.HasValue)
                button.Icon(Icon.Value);
            return button.ToString();
        }
    }

    /// <summary>
    /// Custom header item
    /// </summary>
    public class TablerHeaderCustom : TablerHeaderItem
    {
        private readonly HtmlTag _content;

        /// <summary>
        /// Initializes a new instance of the TablerHeaderCustom class
        /// </summary>
        /// <param name="content">Custom HTML content</param>
        public TablerHeaderCustom(HtmlTag content)
        {
            _content = content;
        }

        /// <summary>
        /// Renders the custom header item to HTML string
        /// </summary>
        /// <returns>HTML representation of the custom header item</returns>
        public override string Render()
        {
            return _content.ToString();
        }
    }

    /// <summary>
    /// User profile configuration
    /// </summary>
    public class TablerUserProfile
    {
        /// <summary>
        /// Gets or sets the user name
        /// </summary>
        public string Name { get; set; } = "";
        
        /// <summary>
        /// Gets or sets the user title (optional)
        /// </summary>
        public string? Title { get; set; }
        
        /// <summary>
        /// Gets or sets the avatar image URL (optional)
        /// </summary>
        public string? AvatarUrl { get; set; }
        
        /// <summary>
        /// Gets the list of menu items for the user dropdown
        /// </summary>
        public List<TablerUserMenuItem> MenuItems { get; } = new();

        /// <summary>
        /// Initializes a new instance of the TablerUserProfile class with default menu items
        /// </summary>
        public TablerUserProfile()
        {
            // Default menu items
            MenuItem("Status", "#");
            MenuItem("Profile", "./profile.html");
            MenuItem("Feedback", "#");
            Divider();
            MenuItem("Settings", "./settings.html");
            MenuItem("Logout", "./sign-in.html");
        }

        /// <summary>
        /// Adds a menu item to the user dropdown
        /// </summary>
        /// <param name="text">Menu item text</param>
        /// <param name="href">Menu item href URL</param>
        /// <param name="icon">Optional menu item icon</param>
        /// <returns>This TablerUserProfile instance for method chaining</returns>
        public TablerUserProfile MenuItem(string text, string href, TablerIconType? icon = null)
        {
            MenuItems.Add(new TablerUserMenuItem { Text = text, Href = href, Icon = icon });
            return this;
        }

        /// <summary>
        /// Adds a divider to the user dropdown menu
        /// </summary>
        /// <returns>This TablerUserProfile instance for method chaining</returns>
        public TablerUserProfile Divider()
        {
            MenuItems.Add(new TablerUserMenuItem { IsDivider = true });
            return this;
        }

        /// <summary>
        /// Clears all menu items from the user dropdown
        /// </summary>
        /// <returns>This TablerUserProfile instance for method chaining</returns>
        public TablerUserProfile ClearMenuItems()
        {
            MenuItems.Clear();
            return this;
        }
    }

    /// <summary>
    /// User menu item
    /// </summary>
    public class TablerUserMenuItem
    {
        /// <summary>
        /// Gets or sets the menu item text
        /// </summary>
        public string Text { get; set; } = "";
        
        /// <summary>
        /// Gets or sets the menu item href URL
        /// </summary>
        public string Href { get; set; } = "#";
        
        /// <summary>
        /// Gets or sets the optional menu item icon
        /// </summary>
        public TablerIconType? Icon { get; set; }
        
        /// <summary>
        /// Gets or sets whether this is a divider item
        /// </summary>
        public bool IsDivider { get; set; }
    }

    /// <summary>
    /// Notification item
    /// </summary>
    public class TablerNotification
    {
        /// <summary>
        /// Gets or sets the notification title
        /// </summary>
        public string Title { get; set; } = "";
        
        /// <summary>
        /// Gets or sets the notification description (optional)
        /// </summary>
        public string? Description { get; set; }
        
        /// <summary>
        /// Gets or sets the notification type
        /// </summary>
        public TablerNotificationType Type { get; set; } = TablerNotificationType.Default;
        
        /// <summary>
        /// Gets or sets the notification link URL (optional)
        /// </summary>
        public string? Href { get; set; }
        
        /// <summary>
        /// Gets or sets whether the notification has been read
        /// </summary>
        public bool IsRead { get; set; }

        /// <summary>
        /// Renders the notification to HTML string
        /// </summary>
        /// <returns>HTML representation of the notification</returns>
        public string Render()
        {
            var item = new HtmlTag("div").Class("list-group-item");
            var row = new HtmlTag("div").Class("row").Class("align-items-center");
            
            // Status dot
            var dotCol = new HtmlTag("div").Class("col-auto");
            var statusClass = Type switch
            {
                TablerNotificationType.Error => "bg-red",
                TablerNotificationType.Warning => "bg-yellow",
                TablerNotificationType.Success => "bg-green",
                TablerNotificationType.Info => "bg-blue",
                _ => ""
            };
            
            if (!IsRead && !string.IsNullOrEmpty(statusClass))
            {
                var statusColor = Type switch
                {
                    TablerNotificationType.Error => TablerStatusColor.Red,
                    TablerNotificationType.Warning => TablerStatusColor.Yellow,
                    TablerNotificationType.Success => TablerStatusColor.Green,
                    TablerNotificationType.Info => TablerStatusColor.Blue,
                    _ => TablerStatusColor.Default
                };
                var statusDot = new TablerStatusDot().Color(statusColor).Animated(true);
                dotCol.Value(statusDot.ToString());
            }
            else
            {
                dotCol.Value(new TablerStatusDot().ToString());
            }
            
            row.Value(dotCol.ToString());
            
            // Content
            var contentCol = new HtmlTag("div").Class("col").Class("text-truncate");
            if (!string.IsNullOrEmpty(Href))
            {
                var link = new HtmlTag("a").Attribute("href", Href!).Class("text-body").Class("d-block").Value(Title);
                contentCol.Value(link.ToString());
            }
            else
            {
                var span = new HtmlTag("span").Class("text-body").Class("d-block").Value(Title);
                contentCol.Value(span.ToString());
            }
            
            if (!string.IsNullOrEmpty(Description))
            {
                var descDiv = new HtmlTag("div").Class("d-block").Class("text-secondary").Class("text-truncate").Class("mt-n1").Value(Description);
                contentCol.Value(descDiv.ToString());
            }
            
            row.Value(contentCol.ToString());
            
            // Action
            var actionCol = new HtmlTag("div").Class("col-auto");
            var actionLink = new HtmlTag("a").Attribute("href", "#").Class("list-group-item-actions");
            var starIcon = TablerIconLibrary.GetIcon(TablerIconType.Star);
            starIcon.ContainerClasses = "text-muted";
            actionLink.Value(starIcon.ToString());
            actionCol.Value(actionLink.ToString());
            row.Value(actionCol.ToString());
            
            item.Value(row.ToString());
            return item.ToString();
        }
    }

    /// <summary>
    /// App menu item
    /// </summary>
    public class TablerAppMenuItem
    {
        /// <summary>
        /// Gets or sets the app name
        /// </summary>
        public string Name { get; set; } = "";
        
        /// <summary>
        /// Gets or sets the app icon URL
        /// </summary>
        public string IconUrl { get; set; } = "";
        
        /// <summary>
        /// Gets or sets the app link URL (optional)
        /// </summary>
        public string? Href { get; set; }

        /// <summary>
        /// Renders the app menu item to HTML string
        /// </summary>
        /// <returns>HTML representation of the app menu item</returns>
        public string Render()
        {
            var col = new HtmlTag("div").Class("col-4");
            var link = new HtmlTag("a");
            link.Attribute("href", Href ?? "#");
            link.Class("d-flex").Class("flex-column").Class("flex-center");
            link.Class("text-center").Class("text-secondary").Class("py-2").Class("px-2").Class("link-hoverable");
            
            var img = new HtmlTag("img");
            img.Attribute("src", IconUrl);
            img.Class("w-6").Class("h-6").Class("mx-auto").Class("mb-2");
            img.Attribute("width", "24");
            img.Attribute("height", "24");
            img.Attribute("alt", "");
            link.Value(img.ToString());
            
            var nameSpan = new HtmlTag("span").Class("h5").Value(Name);
            link.Value(nameSpan.ToString());
            col.Value(link.ToString());
            
            return col.ToString();
        }
    }

    /// <summary>
    /// Defines header style options
    /// </summary>
    public enum TablerHeaderStyle
    {
        /// <summary>
        /// Default header style
        /// </summary>
        Default,
        
        /// <summary>
        /// Dark header style
        /// </summary>
        Dark,
        
        /// <summary>
        /// Light header style
        /// </summary>
        Light,
        
        /// <summary>
        /// Transparent header style
        /// </summary>
        Transparent
    }

    /// <summary>
    /// Defines notification type options
    /// </summary>
    public enum TablerNotificationType
    {
        /// <summary>
        /// Default notification type
        /// </summary>
        Default,
        
        /// <summary>
        /// Informational notification
        /// </summary>
        Info,
        
        /// <summary>
        /// Success notification
        /// </summary>
        Success,
        
        /// <summary>
        /// Warning notification
        /// </summary>
        Warning,
        
        /// <summary>
        /// Error notification
        /// </summary>
        Error
    }
}
