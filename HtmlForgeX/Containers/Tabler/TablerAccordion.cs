using System.Linq;
using HtmlForgeX.Extensions;

namespace HtmlForgeX;

public class TablerAccordion : Element {
    public List<TablerAccordionItem> Items { get; set; } = new List<TablerAccordionItem>();
    private string Id { get; } = GlobalStorage.GenerateRandomId("accordion");
    private TablerAccordionType PrivateAccordionType { get; set; } = TablerAccordionType.Default;
    private TablerColor? PrivateColor { get; set; }
    private bool PrivateAlwaysOpen { get; set; } = false;


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

    /// <summary>
    /// Sets the accordion type (Default, Flush, Tabs, Inverted, Plus)
    /// </summary>
    public TablerAccordion Type(TablerAccordionType accordionType) {
        PrivateAccordionType = accordionType;
        return this;
    }

    /// <summary>
    /// Sets the accordion color theme
    /// </summary>
    public TablerAccordion Color(TablerColor color) {
        PrivateColor = color;
        return this;
    }

    /// <summary>
    /// Allows multiple accordion items to be open simultaneously
    /// </summary>
    public TablerAccordion AlwaysOpen(bool alwaysOpen = true) {
        PrivateAlwaysOpen = alwaysOpen;
        return this;
    }

    public override string ToString() {
        var accordionDiv = new HtmlTag("div").Class("accordion").Id(Id);
        
        // Apply accordion type classes
        var typeClass = PrivateAccordionType.EnumToString();
        if (!string.IsNullOrEmpty(typeClass)) {
            accordionDiv.Class(typeClass);
        }
        
        // Apply color theme if specified
        if (PrivateColor.HasValue) {
            accordionDiv.Class($"accordion-{PrivateColor.Value.ToTablerString()}");
        }

        foreach (var item in Items.WhereNotNull()) {
            // Pass accordion configuration to items
            item.SetAccordionConfig(PrivateAccordionType, PrivateAlwaysOpen);
            accordionDiv.Value(item);
        }

        return accordionDiv.ToString();
    }
}