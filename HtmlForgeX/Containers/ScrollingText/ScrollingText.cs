using System.Linq;

using HtmlForgeX.Extensions;

namespace HtmlForgeX;

/// <summary>
/// Displays a hierarchical scrolling text section with a navigation sidebar.
/// </summary>
/// <remarks>
/// Each <see cref="ScrollingText"/> instance collects <see cref="ScrollingTextItem"/>
/// objects which are rendered in order. The control automatically registers the
/// required JavaScript libraries when attached to a document.
/// </remarks>
public class ScrollingText : Element {
    /// <summary>
    /// Gets a unique identifier for the component.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Gets the list of items displayed by the control.
    /// </summary>
    public List<ScrollingTextItem> Items { get; set; } = new List<ScrollingTextItem>();

    /// <summary>
    /// Initializes a new instance of the <see cref="ScrollingText"/> class.
    /// </summary>
    public ScrollingText() {
        // Libraries will be registered via RegisterLibraries method
        Id = GlobalStorage.GenerateRandomId("scrollingText");
    }

    /// <summary>
    /// Registers the required libraries for ScrollingText.
    /// </summary>
    protected internal override void RegisterLibraries() {
        Document?.AddLibrary(Libraries.ScrollingText);
    }

    /// <summary>
    /// Adds a new item to the scrolling text sequence.
    /// </summary>
    /// <param name="title">Display title for the item.</param>
    /// <param name="contentAction">Callback used to populate the item contents.</param>
    /// <returns>The created <see cref="ScrollingTextItem"/> instance.</returns>
    public ScrollingTextItem AddItem(string title, Action<ScrollingTextItem> contentAction) {
        var item = new ScrollingTextItem(title);
        contentAction(item);
        Items.Add(item);
        return item;
    }

    /// <summary>
    /// Renders the control as HTML.
    /// </summary>
    /// <returns>A string containing the rendered HTML.</returns>
    public override string ToString() {
        var sectionMain = new HtmlTag("div").Attribute("class", "main-section");
        var sectionScrollingDiv = new HtmlTag("div").Attribute("class", "sectionScrolling");
        var divTagEmpty = new HtmlTag("div");

        foreach (var item in Items.WhereNotNull()) {
            divTagEmpty.Value(item);
        }

        sectionScrollingDiv.Value(divTagEmpty);
        sectionScrollingDiv.Value(RenderNav());

        sectionMain.Value(sectionScrollingDiv);
        return sectionMain.ToString();
    }

    /// <summary>
    /// Renders the navigation section for the scrolling text control.
    /// </summary>
    /// <returns>A navigation <see cref="HtmlTag"/> element.</returns>
    private HtmlTag RenderNav() {
        var navTag = new HtmlTag("nav").Attribute("class", "section-nav");
        var olTag = new HtmlTag("ol");

        foreach (var item in Items.WhereNotNull()) {
            olTag.Value(RenderNavItem(item));
        }

        navTag.Value(olTag);
        return navTag;
    }

    /// <summary>
    /// Builds a list item for the navigation menu.
    /// </summary>
    /// <param name="item">The item to create a nav link for.</param>
    /// <returns>A <see cref="HtmlTag"/> representing the navigation entry.</returns>
    private HtmlTag RenderNavItem(ScrollingTextItem item) {
        var liTag = new HtmlTag("li");
        liTag.Value(new HtmlTag("a").Attribute("href", $"#{item.Id}").Value(item.Title));

        if (item.Items.Count > 0) {
            var ulTag = new HtmlTag("ul");
            foreach (var child in item.Items) {
                ulTag.Value(RenderNavItem(child));
            }
            liTag.Value(ulTag);
        }

        return liTag;
    }
}