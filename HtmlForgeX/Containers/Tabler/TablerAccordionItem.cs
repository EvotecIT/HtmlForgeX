namespace HtmlForgeX;

public class TablerAccordionItem : Element {
    public Element TitleElement { get; set; }
    public Element ContentElement { get; set; }
    private string ParentId { get; set; }
    private string Id { get; } = GlobalStorage.GenerateRandomId("accordionItem");

    public TablerAccordionItem(string parentId) {
        ParentId = parentId;
    }

    public TablerAccordionItem Title(string title) {
        TitleElement = new HtmlTag("h2").Class("accordion-header").Id("heading-" + Id).Value(
            new HtmlTag("button").Class("accordion-button").Type("button").Attribute("data-bs-toggle", "collapse").Attribute("data-bs-target", "#collapse-" + Id).Value(title)
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
            var collapseDiv = new HtmlTag("div").Class("accordion-collapse").Class("collapse").Attribute("data-bs-parent", "#" + ParentId).Id("collapse-" + Id);
            collapseDiv.Value(ContentElement);
            itemDiv.Value(collapseDiv.ToString());
        }

        return itemDiv.ToString();
    }


}
