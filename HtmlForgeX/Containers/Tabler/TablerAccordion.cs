namespace HtmlForgeX;

public class TablerAccordion : Element {
    public List<TablerAccordionItem> Items { get; set; } = new List<TablerAccordionItem>();
    private string Id { get; } = GlobalStorage.GenerateRandomId("accordion");


    public TablerAccordion AddItem(TablerAccordionItem item) {
        Items.Add(item);
        return this;
    }

    public TablerAccordionItem AddItem(string title) {
        var accordionItem = new TablerAccordionItem(Id).Title(title);
        Items.Add(accordionItem);
        return accordionItem;
    }

    public TablerAccordionItem AddItem(string title, Action<TablerAccordionItem> item) {
        var accordionItem = new TablerAccordionItem(Id).Title(title);
        item(accordionItem);
        Items.Add(accordionItem);
        return accordionItem;
    }

    public TablerAccordionItem AddItem(string title, Element content) {
        var accordionItem = new TablerAccordionItem(Id).Title(title).Content(content);
        Items.Add(accordionItem);
        return accordionItem;
    }

    public override string ToString() {
        var accordionDiv = new HtmlTag("div").Class("accordion").Id(Id);

        foreach (var item in Items) {
            accordionDiv.Value(item);
        }

        return accordionDiv.ToString();
    }
}