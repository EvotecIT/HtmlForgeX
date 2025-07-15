namespace HtmlForgeX;

public partial class Body : Element {
    /// <summary>
    /// Adds a Tabler page.
    /// </summary>
    /// <returns>The created <see cref="TablerPage"/>.</returns>
    public TablerPage Page() {
        var page = new TablerPage();
        this.Add(page);
        return page;
    }

    /// <summary>
    /// Adds a Tabler page and invokes configuration.
    /// </summary>
    /// <param name="config">Configuration delegate.</param>
    /// <returns>The created <see cref="TablerPage"/>.</returns>
    public TablerPage Page(Action<TablerPage> config) {
        var page = new TablerPage();
        this.Add(page);
        config(page);
        return page;
    }
}
