namespace HtmlForgeX;

public class ScrollingTextItem {
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("title")]
    public string TitleProperty { get; set; }

    [JsonPropertyName("content")]
    public string ContentProperty { get; set; }

    [JsonPropertyName("children")]
    public List<ScrollingTextItem> Children { get; set; } = new List<ScrollingTextItem>();

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

    public ScrollingTextItem Content(string content) {
        ContentProperty = content;
        return this;
    }

    public ScrollingTextItem Content(Action<ElementContainer> content) {
        var contentElement = new ElementContainer();
        content(contentElement);
        ContentElement = contentElement;
        return this;
    }

    //public ScrollingTextItem AddChild(ScrollingTextItem child) {
    //    Children.Add(child);
    //    return this;
    //}

    //public ScrollingTextItem AddChild(string title, string content) {
    //    var child = new ScrollingTextItem(title, content);
    //    Children.Add(child);
    //    return this;
    //}

    public override string ToString() {
        if (ContentProperty != null) {
            return new HtmlTag("div").Value(ContentProperty).ToString();
        } else {
            return ContentElement.ToString();
        }
    }
}