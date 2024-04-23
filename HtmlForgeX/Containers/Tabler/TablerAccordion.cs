namespace HtmlForgeX;

public class TablerAccordion : Element {
    public List<TablerAccordionItem> Items { get; set; } = new List<TablerAccordionItem>();
    private string Id { get; } = GlobalStorage.GenerateRandomId("accordion");

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