using System.Linq;

using HtmlForgeX.Extensions;

namespace HtmlForgeX;

/// <summary>
/// Accordion container composed of expandable TablerAccordionItem elements.
/// </summary>
public class TablerAccordion : Element {
    /// <summary>
    /// Gets the accordion items that will be rendered.
    /// </summary>
    public List<TablerAccordionItem> Items { get; set; } = new List<TablerAccordionItem>();
    private string Id { get; } = GlobalStorage.GenerateRandomId("accordion");
    private TablerAccordionType PrivateAccordionType { get; set; } = TablerAccordionType.Default;
    private TablerColor? PrivateColor { get; set; }
    private bool PrivateAlwaysOpen { get; set; } = false;


    /// <summary>
    /// Adds a fully configured accordion item to the container.
    /// </summary>
    /// <param name="item">The item to add.</param>
    /// <returns>The current <see cref="TablerAccordion"/> instance.</returns>
    public TablerAccordion AddItem(TablerAccordionItem item) {
        Items.Add(item);
        return this;
    }

    /// <summary>
    /// Creates a new accordion item with the specified title.
    /// </summary>
    /// <param name="title">The accordion item title.</param>
    /// <returns>The created <see cref="TablerAccordionItem"/> for further configuration.</returns>
    public TablerAccordionItem AddItem(string title) {
        var accordionItem = new TablerAccordionItem(Id).Title(title);
        Items.Add(accordionItem);
        return accordionItem;
    }

    /// <summary>
    /// Adds a new item and allows further configuration via an action.
    /// </summary>
    /// <param name="title">The accordion item title.</param>
    /// <param name="item">Callback used to configure the new item.</param>
    /// <returns>The configured <see cref="TablerAccordionItem"/>.</returns>
    public TablerAccordionItem AddItem(string title, Action<TablerAccordionItem> item) {
        var accordionItem = new TablerAccordionItem(Id).Title(title);
        item(accordionItem);
        Items.Add(accordionItem);
        return accordionItem;
    }

    /// <summary>
    /// Adds a new item using the specified title and content element.
    /// </summary>
    /// <param name="title">The accordion item title.</param>
    /// <param name="content">Content to display when the item is expanded.</param>
    /// <returns>The created <see cref="TablerAccordionItem"/>.</returns>
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

    /// <summary>
    /// Initializes or configures ToString.
    /// </summary>
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