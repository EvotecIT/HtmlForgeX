using HtmlForgeX.Containers.Tabler;

namespace HtmlForgeX
{
    /// <summary>
    /// Extension methods for adding Tabler UI components to Body elements
    /// </summary>
    public static partial class BodyExtensions
    {
        /// <summary>
        /// Adds a Tabler button to the body with fluent configuration
        /// </summary>
        public static TablerButton Button(this Body body, string text, Action<TablerButton> configure)
        {
            var button = new TablerButton(text);
            configure(button);
            body.Add(button);
            return button;
        }

        /// <summary>
        /// Adds a Tabler button to the body
        /// </summary>
        public static TablerButton Button(this Body body, string text, TablerButtonVariant variant = TablerButtonVariant.Primary)
        {
            var button = new TablerButton(text, variant);
            body.Add(button);
            return button;
        }

        /// <summary>
        /// Adds a Tabler link button to the body
        /// </summary>
        public static TablerButton LinkButton(this Body body, string text, string href, TablerButtonVariant variant = TablerButtonVariant.Primary)
        {
            var button = new TablerButton(text, href, variant);
            body.Add(button);
            return button;
        }

        /// <summary>
        /// Adds a Tabler dropdown to the body with fluent configuration
        /// </summary>
        public static TablerDropdown Dropdown(this Body body, string text, Action<TablerDropdown> configure)
        {
            var dropdown = new TablerDropdown(text);
            configure(dropdown);
            body.Add(dropdown);
            return dropdown;
        }

        /// <summary>
        /// Adds a Tabler dropdown to the body
        /// </summary>
        public static TablerDropdown Dropdown(this Body body, string text)
        {
            var dropdown = new TablerDropdown(text);
            body.Add(dropdown);
            return dropdown;
        }

        /// <summary>
        /// Adds a Tabler breadcrumb to the body with fluent configuration
        /// </summary>
        public static TablerBreadcrumb Breadcrumb(this Body body, Action<TablerBreadcrumb> configure)
        {
            var breadcrumb = new TablerBreadcrumb();
            configure(breadcrumb);
            body.Add(breadcrumb);
            return breadcrumb;
        }

        /// <summary>
        /// Adds a Tabler breadcrumb to the body
        /// </summary>
        public static TablerBreadcrumb Breadcrumb(this Body body)
        {
            var breadcrumb = new TablerBreadcrumb();
            body.Add(breadcrumb);
            return breadcrumb;
        }

        /// <summary>
        /// Adds a Tabler header to the body with fluent configuration
        /// </summary>
        public static TablerHeader Header(this Body body, Action<TablerHeader> configure)
        {
            var header = new TablerHeader();
            configure(header);
            body.Add(header);
            return header;
        }

        /// <summary>
        /// Adds a Tabler header to the body
        /// </summary>
        public static TablerHeader Header(this Body body)
        {
            var header = new TablerHeader();
            body.Add(header);
            return header;
        }

        /// <summary>
        /// Adds a Tabler sidebar to the body with fluent configuration
        /// </summary>
        public static TablerSidebar Sidebar(this Body body, Action<TablerSidebar> configure)
        {
            var sidebar = new TablerSidebar();
            configure(sidebar);
            body.Add(sidebar);
            return sidebar;
        }

        /// <summary>
        /// Adds a Tabler sidebar to the body
        /// </summary>
        public static TablerSidebar Sidebar(this Body body)
        {
            var sidebar = new TablerSidebar();
            body.Add(sidebar);
            return sidebar;
        }

        /// <summary>
        /// Adds a Tabler footer to the body with fluent configuration
        /// </summary>
        public static TablerFooter Footer(this Body body, Action<TablerFooter> configure)
        {
            var footer = new TablerFooter();
            configure(footer);
            body.Add(footer);
            return footer;
        }

        /// <summary>
        /// Adds a Tabler footer to the body
        /// </summary>
        public static TablerFooter Footer(this Body body)
        {
            var footer = new TablerFooter();
            body.Add(footer);
            return footer;
        }
    }
}