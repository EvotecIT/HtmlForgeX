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
    private string Content { get; set; }
    /// <summary>
    /// Items/Children of the ScrollingTextItem.
    /// </summary>
    internal List<ScrollingTextItem> Items { get; set; } = new List<ScrollingTextItem>();
    /// <summary>
    /// Constructor for the ScrollingTextItem.
    /// </summary>
    /// <param name="title"></param>
    /// <param name="content"></param>
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
    /// <param name="title"></param>
    /// <param name="config"></param>
    /// <returns></returns>
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
        foreach (var child in Children) {
            sectionTag.Value(child);
        }

        // Render all nested items (aka ScrollingTextItems)
        foreach (var child in Items) {
            sectionTag.Value(child);
        }

        return sectionTag.ToString();
    }
}
