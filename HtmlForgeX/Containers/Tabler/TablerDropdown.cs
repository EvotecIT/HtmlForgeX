using System.Text;

namespace HtmlForgeX.Containers.Tabler
{
    /// <summary>
    /// Tabler dropdown component for menus and navigation
    /// </summary>
    public class TablerDropdown : Element
    {
        private string _toggleText;
        private TablerButtonVariant _buttonVariant = TablerButtonVariant.Primary;
        private TablerButtonSize _buttonSize = TablerButtonSize.Default;
        private TablerIconType? _icon;
        private bool _split = false;
        private bool _dropup = false;
        private bool _dropend = false;
        private bool _dropstart = false;
        private TablerDropdownAlignment _alignment = TablerDropdownAlignment.Start;
        private readonly List<IDropdownItem> _items = new();

        /// <summary>
        /// Initializes a new instance of the TablerDropdown class
        /// </summary>
        /// <param name="toggleText">The text displayed on the dropdown toggle button</param>
        public TablerDropdown(string toggleText) : base()
        {
            _toggleText = toggleText;
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
        /// Set button variant for dropdown toggle
        /// </summary>
        public TablerDropdown ButtonVariant(TablerButtonVariant variant)
        {
            _buttonVariant = variant;
            return this;
        }

        /// <summary>
        /// Set button size for dropdown toggle
        /// </summary>
        public TablerDropdown ButtonSize(TablerButtonSize size)
        {
            _buttonSize = size;
            return this;
        }

        /// <summary>
        /// Add icon to dropdown toggle
        /// </summary>
        public TablerDropdown Icon(TablerIconType icon)
        {
            _icon = icon;
            return this;
        }

        /// <summary>
        /// Make split button dropdown
        /// </summary>
        public TablerDropdown Split(bool split = true)
        {
            _split = split;
            return this;
        }

        /// <summary>
        /// Make dropup (opens upward)
        /// </summary>
        public TablerDropdown Dropup(bool dropup = true)
        {
            _dropup = dropup;
            return this;
        }

        /// <summary>
        /// Make dropend (opens to the right)
        /// </summary>
        public TablerDropdown Dropend(bool dropend = true)
        {
            _dropend = dropend;
            return this;
        }

        /// <summary>
        /// Make dropstart (opens to the left)
        /// </summary>
        public TablerDropdown Dropstart(bool dropstart = true)
        {
            _dropstart = dropstart;
            return this;
        }

        /// <summary>
        /// Set dropdown menu alignment
        /// </summary>
        public TablerDropdown Alignment(TablerDropdownAlignment alignment)
        {
            _alignment = alignment;
            return this;
        }

        /// <summary>
        /// Add dropdown item
        /// </summary>
        public TablerDropdown Item(string text, string? href = null)
        {
            _items.Add(new DropdownItem(text, href));
            return this;
        }

        /// <summary>
        /// Add dropdown item with icon
        /// </summary>
        public TablerDropdown Item(string text, TablerIconType icon, string? href = null)
        {
            _items.Add(new DropdownItem(text, href) { Icon = icon });
            return this;
        }

        /// <summary>
        /// Add dropdown item with configuration
        /// </summary>
        public TablerDropdown Item(Action<DropdownItem> configure)
        {
            var item = new DropdownItem();
            configure(item);
            _items.Add(item);
            return this;
        }

        /// <summary>
        /// Add divider
        /// </summary>
        public TablerDropdown Divider()
        {
            _items.Add(new DropdownDivider());
            return this;
        }

        /// <summary>
        /// Add header
        /// </summary>
        public TablerDropdown Header(string text)
        {
            _items.Add(new DropdownHeader(text));
            return this;
        }

        /// <summary>
        /// Add custom content
        /// </summary>
        public TablerDropdown Custom(Action<HtmlTag> configure)
        {
            var container = new HtmlTag("div");
            configure(container);
            _items.Add(new DropdownCustom(container));
            return this;
        }

        /// <summary>
        /// Renders the dropdown to HTML string
        /// </summary>
        /// <returns>HTML representation of the dropdown</returns>
        public override string ToString()
        {
            var container = new HtmlTag("div");
            
            // Set dropdown direction class
            if (_dropup)
                container.Class("dropup");
            else if (_dropend)
                container.Class("dropend");
            else if (_dropstart)
                container.Class("dropstart");
            else
                container.Class("dropdown");

            // Render toggle button(s)
            if (_split)
            {
                // Main button
                var mainButton = new TablerButton(_toggleText)
                    .Variant(_buttonVariant)
                    .Size(_buttonSize);
                if (_icon.HasValue)
                    mainButton.Icon(_icon.Value);
                
                container.Value(mainButton.ToString());

                // Split toggle button
                var toggleButton = new TablerButton("")
                    .Variant(_buttonVariant)
                    .Size(_buttonSize);
                // Note: dropdown-toggle classes and attributes should be handled by TablerButton when used in dropdown context
                
                container.Value(toggleButton.ToString());
            }
            else
            {
                // Single toggle button
                var toggleButton = new TablerButton(_toggleText)
                    .Variant(_buttonVariant)
                    .Size(_buttonSize);
                // Note: dropdown-toggle classes and attributes should be handled by TablerButton when used in dropdown context
                
                if (_icon.HasValue)
                    toggleButton.Icon(_icon.Value);
                
                container.Value(toggleButton.ToString());
            }

            // Render dropdown menu
            var menu = new HtmlTag("div");
            menu.Class("dropdown-menu");
            
            if (_alignment == TablerDropdownAlignment.End)
                menu.Class("dropdown-menu-end");
            else if (_alignment == TablerDropdownAlignment.Center)
                menu.Class("dropdown-menu-center");

            foreach (var item in _items)
            {
                menu.Value(item.Render());
            }
            
            container.Value(menu.ToString());
            
            return container.ToString();
        }

        /// <summary>
        /// Create dropdown with fluent configuration
        /// </summary>
        public static TablerDropdown Create(string toggleText, Action<TablerDropdown> configure)
        {
            var dropdown = new TablerDropdown(toggleText);
            configure(dropdown);
            return dropdown;
        }
    }

    /// <summary>
    /// Interface for dropdown items
    /// </summary>
    public interface IDropdownItem
    {
        /// <summary>
        /// Renders the dropdown item to HTML
        /// </summary>
        /// <returns>HTML string representation of the item</returns>
        string Render();
    }

    /// <summary>
    /// Dropdown menu item
    /// </summary>
    public class DropdownItem : IDropdownItem
    {
        private string _text = "";
        private string? _href;
        private bool _active = false;
        private bool _disabled = false;
        
        /// <summary>
        /// Gets or sets the icon for the dropdown item
        /// </summary>
        public TablerIconType? Icon { get; set; }

        /// <summary>
        /// Initializes a new instance of the DropdownItem class
        /// </summary>
        public DropdownItem() { }

        /// <summary>
        /// Initializes a new instance of the DropdownItem class with text and optional href
        /// </summary>
        /// <param name="text">The item text</param>
        /// <param name="href">Optional link URL</param>
        public DropdownItem(string text, string? href = null)
        {
            _text = text;
            _href = href;
        }

        /// <summary>
        /// Set item text
        /// </summary>
        public DropdownItem Text(string text)
        {
            _text = text;
            return this;
        }

        /// <summary>
        /// Set item link
        /// </summary>
        public DropdownItem Href(string href)
        {
            _href = href;
            return this;
        }

        /// <summary>
        /// Mark as active
        /// </summary>
        public DropdownItem Active(bool active = true)
        {
            _active = active;
            return this;
        }

        /// <summary>
        /// Mark as disabled
        /// </summary>
        public DropdownItem Disabled(bool disabled = true)
        {
            _disabled = disabled;
            return this;
        }

        /// <summary>
        /// Add icon
        /// </summary>
        public DropdownItem WithIcon(TablerIconType icon)
        {
            Icon = icon;
            return this;
        }

        /// <summary>
        /// Renders the dropdown item to HTML
        /// </summary>
        /// <returns>HTML string representation of the item</returns>
        public string Render()
        {
            var tag = string.IsNullOrEmpty(_href) ? "button" : "a";
            var item = new HtmlTag(tag);
            item.Class("dropdown-item");
            
            if (_active) item.Class("active");
            if (_disabled) item.Class("disabled");

            if (tag == "a" && !string.IsNullOrEmpty(_href))
                item.Attribute("href", _href!);
            else if (tag == "button")
                item.Attribute("type", "button");

            if (Icon.HasValue)
            {
                item.Value(TablerIconLibrary.GetIcon(Icon.Value).ToString());
            }

            item.Value(_text);
            
            return item.ToString();
        }
    }

    /// <summary>
    /// Dropdown divider
    /// </summary>
    public class DropdownDivider : IDropdownItem
    {
        /// <summary>
        /// Renders the dropdown divider to HTML
        /// </summary>
        /// <returns>HTML string representation of the divider</returns>
        public string Render()
        {
            return "<hr class=\"dropdown-divider\">";
        }
    }

    /// <summary>
    /// Dropdown header
    /// </summary>
    public class DropdownHeader : IDropdownItem
    {
        private readonly string _text;

        /// <summary>
        /// Initializes a new instance of the DropdownHeader class
        /// </summary>
        /// <param name="text">The header text</param>
        public DropdownHeader(string text)
        {
            _text = text;
        }

        /// <summary>
        /// Renders the dropdown header to HTML
        /// </summary>
        /// <returns>HTML string representation of the header</returns>
        public string Render()
        {
            return $"<h6 class=\"dropdown-header\">{_text}</h6>";
        }
    }

    /// <summary>
    /// Custom dropdown content
    /// </summary>
    public class DropdownCustom : IDropdownItem
    {
        private readonly HtmlTag _content;

        /// <summary>
        /// Initializes a new instance of the DropdownCustom class
        /// </summary>
        /// <param name="content">The custom HTML content</param>
        public DropdownCustom(HtmlTag content)
        {
            _content = content;
        }

        /// <summary>
        /// Renders the custom content to HTML
        /// </summary>
        /// <returns>HTML string representation of the custom content</returns>
        public string Render()
        {
            return _content.ToString();
        }
    }

    /// <summary>
    /// Represents dropdown menu alignment options
    /// </summary>
    public enum TablerDropdownAlignment
    {
        /// <summary>
        /// Align to start (left in LTR)
        /// </summary>
        Start,
        /// <summary>
        /// Align to end (right in LTR)
        /// </summary>
        End,
        /// <summary>
        /// Center alignment
        /// </summary>
        Center
    }
}
