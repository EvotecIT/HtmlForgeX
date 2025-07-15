using System.Linq;
using HtmlForgeX.Extensions;

namespace HtmlForgeX;

/// <summary>
/// Class for creating a scrolling text item.
/// </summary>
public class ScrollingTextItem : Element {
    /// <summary>
    /// ID of the ScrollingTextItem. By default, it is a random GUID.
    /// </summary>
    public string Id { get; set; }
    /// <summary>
    /// Title of the ScrollingTextItem. It's mandatory.
    /// </summary>
    internal string Title { get; set; }
    /// <summary>
    /// Storage for the content of the ScrollingTextItem.
    /// </summary>
    private string Content { get; set; } = string.Empty;
    /// <summary>
    /// Items/Children of the ScrollingTextItem.
    /// </summary>
    internal List<ScrollingTextItem> Items { get; set; } = new List<ScrollingTextItem>();
    /// <summary>
    /// Constructor for the ScrollingTextItem.
    /// </summary>
    /// <param name="title">Title of the new item.</param>
    /// <param name="content">Optional HTML content.</param>
    internal ScrollingTextItem(string title, string content = "") {
        Id = $"scrolling-{Guid.NewGuid().ToString("N")}";
        Title = title;
        if (content != "") {
            Content = content;
        }
    }

    /// <summary>
    /// Allows you to add a child element to the ScrollingTextItem.
    /// </summary>
    /// <param name="title">Title of the child item.</param>
    /// <param name="config">Callback used to configure the item.</param>
    /// <returns>The newly created item.</returns>
    public ScrollingTextItem AddItem(string title, Action<ScrollingTextItem> config) {
        var child = new ScrollingTextItem(title);
        config(child);
        Items.Add(child);
        return child;
    }

    /// <summary>
    /// Converts the ScrollingTextItem to an HTML string.
    /// </summary>
    /// <returns></returns>
    public override string ToString() {
        var sectionTag = new HtmlTag("section").Attribute("id", Id);
        sectionTag.Value(new HtmlTag("h2").Value(Title));

        if (!string.IsNullOrEmpty(Content)) {
            sectionTag.Value(new HtmlTag("div").Value(Content));
        }

        // Render all child elements recursively
        foreach (var child in Children.WhereNotNull()) {
            sectionTag.Value(child);
        }

        // Render all nested items (aka ScrollingTextItems)
        foreach (var child in Items.WhereNotNull()) {
            sectionTag.Value(child);
        }

        return sectionTag.ToString();
    }
}
