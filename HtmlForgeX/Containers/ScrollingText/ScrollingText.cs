namespace HtmlForgeX;

public class ScrollingText : Element {
    public string Id { get; set; }
    public List<ScrollingTextItem> Items { get; set; } = new List<ScrollingTextItem>();

    public ScrollingText() {
        // Add library to the global storage, for HTML processing
        GlobalStorage.Libraries.TryAdd(Libraries.ScrollingText, 0);
        Id = GlobalStorage.GenerateRandomId("scrollingText");
    }

    public ScrollingTextItem AddItem(string title, Action<ScrollingTextItem> contentAction) {
        var item = new ScrollingTextItem(title);
        contentAction(item);
        Items.Add(item);
        return item;
    }

    public override string ToString() {
        var sectionMain = new HtmlTag("div").Attribute("class", "main-section");
        var sectionScrollingDiv = new HtmlTag("div").Attribute("class", "sectionScrolling");
        var divTagEmpty = new HtmlTag("div");

        foreach (var item in Items) {
            divTagEmpty.Value(item.ToString());
        }

        sectionScrollingDiv.Value(divTagEmpty);
        sectionScrollingDiv.Value(RenderNav());

        sectionMain.Value(sectionScrollingDiv);
        return sectionMain.ToString();
    }

    private HtmlTag RenderNav() {
        var navTag = new HtmlTag("nav").Attribute("class", "section-nav");
        var olTag = new HtmlTag("ol");

        foreach (var item in Items) {
            olTag.Value(RenderNavItem(item));
        }

        navTag.Value(olTag);
        return navTag;
    }

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
