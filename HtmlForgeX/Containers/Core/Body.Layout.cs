namespace HtmlForgeX;

public partial class Body {
    /// <summary>
    /// Adds a layout container with navigation and multiple pages to the body.
    /// </summary>
    /// <param name="config">Configuration action for the layout container.</param>
    /// <returns>The TablerLayoutContainer element.</returns>
    public TablerLayoutContainer Layout(Action<TablerLayoutContainer> config) {
        var layout = new TablerLayoutContainer();
        this.Add(layout);
        config(layout);
        return layout;
    }

    /// <summary>
    /// Adds a navigation bar to the body.
    /// </summary>
    /// <param name="config">Configuration action for the navbar.</param>
    /// <returns>The TablerNavbar element.</returns>
    public TablerNavbar Navbar(Action<TablerNavbar> config) {
        var navbar = new TablerNavbar();
        this.Add(navbar);
        config(navbar);
        return navbar;
    }
}