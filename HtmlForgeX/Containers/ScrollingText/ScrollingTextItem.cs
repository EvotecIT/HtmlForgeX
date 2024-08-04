namespace HtmlForgeX;

public class ScrollingTextItem : Element {
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("title")]
    public string TitleProperty { get; set; }

    [JsonPropertyName("content")]
    public string ContentProperty { get; set; }

    [JsonPropertyName("children")]
    public List<ScrollingTextItem> Items { get; set; } = new List<ScrollingTextItem>();

    private Element ContentElement { get; set; }

    public ScrollingTextItem() {
        Id = $"scrolling-{Guid.NewGuid().ToString("N")}";
    }

    public ScrollingTextItem(string title, string content = "") {
        Id = $"scrolling-{Guid.NewGuid().ToString("N")}";
        TitleProperty = title;
        if (content != "") {
            ContentProperty = content;
        }
    }

    public ScrollingTextItem(string title, ElementContainer content) {
        Id = $"scrolling-{Guid.NewGuid().ToString("N")}";
        TitleProperty = title;
        ContentElement = content;
    }

    public ScrollingTextItem Title(string title) {
        TitleProperty = title;
        return this;
    }

    public ScrollingTextItem AddItem(Action<ElementContainer> content) {
        var contentElement = new ElementContainer();
        content(contentElement);
        ContentElement = contentElement;
        return this;
    }

    public ScrollingTextItem AddItem(ScrollingTextItem child) {
        Children.Add(child);
        return this;
    }

    public ScrollingTextItem AddItem(string title, string content) {
        var child = new ScrollingTextItem(title, content);
        Children.Add(child);
        return this;
    }

    public override string ToString() {
        var sectionTag = new HtmlTag("section").Attribute("id", Id);
        sectionTag.Value(new HtmlTag("h2").Value(TitleProperty));
        if (ContentProperty != null) {
            sectionTag.Value(new HtmlTag("div").Value(ContentProperty));
        } else if (ContentElement != null) {
            sectionTag.Value(new HtmlTag("div").Value(ContentElement.ToString()));
        }

        foreach (var child in Children) {
            sectionTag.Value(child.ToString());
        }

        return sectionTag.ToString();
    }


}
