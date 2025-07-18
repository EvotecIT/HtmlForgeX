namespace HtmlForgeX;

/// <summary>
/// Represents a single item within a Tabler accordion component.
/// </summary>
public class TablerAccordionItem : Element {
    private string? TitleElement { get; set; }
    private Element? ContentElement { get; set; }
    private string ParentId { get; set; }
    private string Id { get; } = GlobalStorage.GenerateRandomId("accordionItem");
    private TablerIconType? PrivateIcon { get; set; }
    private bool PrivateExpanded { get; set; } = false;
    private bool PrivateDisabled { get; set; } = false;
    private TablerAccordionType AccordionType { get; set; } = TablerAccordionType.Default;
    private bool AlwaysOpen { get; set; } = false;

    /// <summary>
    /// Initializes or configures TablerAccordionItem.
    /// </summary>
    public TablerAccordionItem(string parentId) {
        ParentId = parentId;
    }

    /// <summary>
    /// Initializes or configures Title.
    /// </summary>
    public TablerAccordionItem Title(string title) {
        TitleElement = title;
        return this;
    }

    /// <summary>
    /// Initializes or configures Content.
    /// </summary>
    public TablerAccordionItem Content(Element content) {
        ContentElement = content;
        return this;
    }

    /// <summary>
    /// Initializes or configures Content.
    /// </summary>
    public TablerAccordionItem Content(Action<ElementContainer> content) {
        var contentElement = new ElementContainer();
        content(contentElement);
        ContentElement = contentElement;
        return this;
    }

    /// <summary>
    /// Returns a fluent container for building content using method chaining
    /// </summary>
    public ElementContainer Content() {
        var contentElement = new ElementContainer();
        ContentElement = contentElement;
        return contentElement;
    }

    /// <summary>
    /// Sets an icon to display before the accordion item title
    /// </summary>
    public TablerAccordionItem Icon(TablerIconType icon) {
        PrivateIcon = icon;
        return this;
    }

    /// <summary>
    /// Sets the accordion item to be expanded by default
    /// </summary>
    public TablerAccordionItem Expanded(bool expanded = true) {
        PrivateExpanded = expanded;
        return this;
    }

    /// <summary>
    /// Sets the accordion item to be disabled
    /// </summary>
    public TablerAccordionItem Disabled(bool disabled = true) {
        PrivateDisabled = disabled;
        return this;
    }

    /// <summary>
    /// Internal method to set accordion configuration from parent
    /// </summary>
    internal void SetAccordionConfig(TablerAccordionType accordionType, bool alwaysOpen) {
        AccordionType = accordionType;
        AlwaysOpen = alwaysOpen;
    }

    /// <summary>
    /// Initializes or configures ToString.
    /// </summary>
    public override string ToString() {
        var itemDiv = new HtmlTag("div").Class("accordion-item");

        // Build accordion button with proper classes
        var buttonClasses = "accordion-button";
        if (!PrivateExpanded) {
            buttonClasses += " collapsed";
        }
        if (AccordionType == TablerAccordionType.Plus) {
            buttonClasses += " accordion-button-toggle-plus";
        }

        var accordionButton = new HtmlTag("button")
            .Class(buttonClasses)
            .Type("button")
            .Attribute("data-bs-toggle", "collapse")
            .Attribute("data-bs-target", "#collapse-" + Id)
            .Attribute("aria-expanded", PrivateExpanded.ToString().ToLower())
            .Attribute("aria-controls", "collapse-" + Id);

        if (PrivateDisabled) {
            accordionButton.Attribute("disabled", "disabled");
        }

        // Add icon if specified
        if (PrivateIcon.HasValue) {
            var iconElement = new TablerIconElement(PrivateIcon.Value);
            var iconWrapper = new HtmlTag("span").Class("accordion-button-icon me-2").Value(iconElement);
            accordionButton.Value(iconWrapper);
        }

        accordionButton.Value(TitleElement);

        var headerDiv = new HtmlTag("h2").Class("accordion-header").Id("heading-" + Id).Value(accordionButton);
        itemDiv.Value(headerDiv);

        // Build collapse div with proper classes and attributes
        var collapseClasses = "accordion-collapse collapse";
        if (PrivateExpanded) {
            collapseClasses += " show";
        }

        var collapseDiv = new HtmlTag("div")
            .Class(collapseClasses)
            .Id("collapse-" + Id)
            .Attribute("aria-labelledby", "heading-" + Id);

        // Only add parent reference if not always open
        if (!AlwaysOpen) {
            collapseDiv.Attribute("data-bs-parent", "#" + ParentId);
        }

        var bodyDiv = new HtmlTag("div").Class("accordion-body").Style("padding", "1rem 1.25rem").Value(ContentElement);
        collapseDiv.Value(bodyDiv);

        itemDiv.Value(collapseDiv);

        return itemDiv.ToString();
    }
}