namespace HtmlForgeX;

public class TablerAccordion : Element {
    public List<TablerAccordionItem> Items { get; set; } = new List<TablerAccordionItem>();
    private string Id { get; set; } = Guid.NewGuid().ToString();

    public TablerAccordion AddItem(TablerAccordionItem item) {
        Items.Add(item);
        return this;
    }

    public TablerAccordionItem AddItem(string title, Element content) {
        var item = new TablerAccordionItem(Id).Title(title).Content(content);
        Items.Add(item);
        return item;
    }

    public override string ToString() {
        var accordionDiv = new HtmlTag("div").Class("accordion").Id(Id);

        foreach (var item in Items) {
            accordionDiv.Value(item);
        }

        return accordionDiv.ToString();
    }
}

public class TablerAccordionItem : Element {
    public Element TitleElement { get; set; }
    public Element ContentElement { get; set; }

    private string ParentId { get; set; }
    private string Id { get; set; } = Guid.NewGuid().ToString();

    public TablerAccordionItem(string parentId) {
        ParentId = parentId;
    }

    public TablerAccordionItem Title(string title) {
        TitleElement = new HtmlTag("h2").Class("accordion-header").Id("heading-" + Id).Value(
            new HtmlTag("button").Class("accordion-button").Type("button").SetAttribute("data-bs-toggle", "collapse").SetAttribute("data-bs-target", "#collapse-" + Id).Value(title)
        );
        return this;
    }

    public TablerAccordionItem Content(Element content) {
        ContentElement = new HtmlTag("div").Class("accordion-body").Class("pt-0").Value(content.ToString());
        return this;
    }


    public override string ToString() {
        var itemDiv = new HtmlTag("div").Class("accordion-item");

        if (TitleElement != null) {
            itemDiv.Value(TitleElement);
        }

        if (ContentElement != null) {
            var collapseDiv = new HtmlTag("div").Class("accordion-collapse").Class("collapse").SetAttribute("data-bs-parent", "#" + ParentId).Id("collapse-" + Id);
            collapseDiv.Value(ContentElement);
            itemDiv.Value(collapseDiv.ToString());
        }

        return itemDiv.ToString();
    }


}
