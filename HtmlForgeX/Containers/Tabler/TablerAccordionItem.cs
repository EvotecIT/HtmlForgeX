using System;

namespace HtmlForgeX;

public class TablerAccordionItem : Element {
    private string TitleElement { get; set; }
    private Element ContentElement { get; set; }
    private string ParentId { get; set; }
    private string Id { get; } = GlobalStorage.GenerateRandomId("accordionItem");

    public TablerAccordionItem(string parentId) {
        ParentId = parentId;
    }

    public TablerAccordionItem Title(string title) {
        TitleElement = title;
        return this;
    }

    public TablerAccordionItem Content(Element content) {
        ContentElement = content;
        return this;
    }

    public TablerAccordionItem Content(Action<ElementContainer> content) {
        var contentElement = new ElementContainer();
        content(contentElement);
        ContentElement = contentElement;
        return this;
    }

    public override string ToString() {
        var itemDiv = new HtmlTag("div").Class("accordion-item");

        itemDiv.Value(new HtmlTag("h2").Class("accordion-header").Id("heading-" + Id).Value(
            new HtmlTag("button").Class("accordion-button")
                .Type("button")
                .Attribute("data-bs-toggle", "collapse")
                .Attribute("data-bs-target", "#collapse-" + Id)
                .Value(TitleElement)
        ));

        var collapseDiv = new HtmlTag("div").Class("accordion-collapse").Class("collapse").Attribute("data-bs-parent", "#" + ParentId).Id("collapse-" + Id);
        collapseDiv.Value(
            new HtmlTag("div").Class("accordion-body").Class("pt-0").Value(ContentElement));


        itemDiv.Value(collapseDiv.ToString());


        return itemDiv.ToString();
    }
}