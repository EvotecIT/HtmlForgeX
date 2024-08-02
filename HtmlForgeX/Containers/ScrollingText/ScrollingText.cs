namespace HtmlForgeX;

public class ScrollingText : Element {
    public string Id { get; set; }
    public List<ScrollingTextItem> Items { get; set; } = new List<ScrollingTextItem>();

    public ScrollingText() {
        // Add library to the global storage, for HTML processing
        GlobalStorage.Libraries.Add(Libraries.ScrollingText);
        Id = GlobalStorage.GenerateRandomId("scrollingText");
    }

    public ScrollingText AddItem(string title, string content) {
        var item = new ScrollingTextItem(title, content);
        Items.Add(item);
        return this;
    }

    public ScrollingText AddItem(ScrollingTextItem item) {
        Items.Add(item);
        return this;
    }

    public override string ToString() {
        var sectionMain = new HtmlTag("div").Attribute("class", "main-section");
        var sectionScrollingDiv = new HtmlTag("div").Attribute("class", "sectionScrolling");
        var divTagEmpty = new HtmlTag("div");

        foreach (var item in Items) {
            divTagEmpty.Value(RenderItem(item));
        }

        sectionScrollingDiv.Value(divTagEmpty);
        sectionScrollingDiv.Value(RenderNav());

        sectionMain.Value(sectionScrollingDiv);
        return sectionMain.ToString();
    }

    private HtmlTag RenderItem(ScrollingTextItem item) {
        var sectionTag = new HtmlTag("section").Attribute("id", item.Id);
        sectionTag.Value(new HtmlTag("h2").Value(item.TitleProperty));
        sectionTag.Value(new HtmlTag("div").Value(new HtmlTag("p").Value(item.ContentProperty)));

        foreach (var child in item.Children) {
            sectionTag.Value(RenderItem(child));
        }

        return sectionTag;
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
        liTag.Value(new HtmlTag("a").Attribute("href", $"#{item.Id}").Value(item.TitleProperty));

        if (item.Children.Count > 0) {
            var ulTag = new HtmlTag("ul");
            foreach (var child in item.Children) {
                ulTag.Value(RenderNavItem(child));
            }
            liTag.Value(ulTag);
        }

        return liTag;
    }
}
