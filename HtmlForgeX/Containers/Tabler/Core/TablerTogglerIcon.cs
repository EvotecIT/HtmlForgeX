namespace HtmlForgeX.Containers.Tabler
{
    /// <summary>
    /// Tabler toggler icon component for navbar hamburger menus
    /// </summary>
    public class TablerTogglerIcon : Element
    {
        /// <summary>
        /// Initializes a new instance of the TablerTogglerIcon class
        /// </summary>
        public TablerTogglerIcon() : base()
        {
        }

        /// <summary>
        /// Renders the toggler icon to HTML string
        /// </summary>
        /// <returns>HTML representation of the toggler icon</returns>
        public override string ToString()
        {
            var span = new HtmlTag("span");
            span.Class("navbar-toggler-icon");
            return span.ToString();
        }
    }
}