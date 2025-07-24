namespace HtmlForgeX;

/// <summary>
/// Represents a Tabler modal dialog component.
/// </summary>
public class TablerModal : Element {
    private string Id { get; } = GlobalStorage.GenerateRandomId("modal");
    private string? PrivateTitle { get; set; }
    private ElementContainer? PrivateContent { get; set; }
    private ElementContainer? PrivateFooter { get; set; }
    private bool PrivateScrollable { get; set; }
    private TablerModalSize PrivateSize { get; set; } = TablerModalSize.Default;

    /// <summary>
    /// Sets modal title.
    /// </summary>
    public TablerModal Title(string title) {
        PrivateTitle = title;
        return this;
    }

    /// <summary>
    /// Sets modal size.
    /// </summary>
    public TablerModal Size(TablerModalSize size) {
        PrivateSize = size;
        return this;
    }

    /// <summary>
    /// Enables scrollable dialog.
    /// </summary>
    public TablerModal Scrollable(bool scrollable = true) {
        PrivateScrollable = scrollable;
        return this;
    }

    /// <summary>
    /// Configures modal body content.
    /// </summary>
    public TablerModal Content(Action<ElementContainer> content) {
        var container = new ElementContainer();
        content(container);
        PrivateContent = container;
        return this;
    }

    /// <summary>
    /// Returns container for modal body content.
    /// </summary>
    public ElementContainer Content() {
        PrivateContent = new ElementContainer();
        return PrivateContent;
    }

    /// <summary>
    /// Configures modal footer content with raw <see cref="ElementContainer"/>.
    /// </summary>
    public TablerModal Footer(Action<ElementContainer> footer) {
        var container = new ElementContainer();
        footer(container);
        PrivateFooter = container;
        return this;
    }

    /// <summary>
    /// Configures modal footer using a fluent builder.
    /// </summary>
    /// <param name="footer">Configuration action.</param>
    /// <returns>The current modal.</returns>
    public TablerModal Footer(Action<TablerModalFooterBuilder> footer) {
        var container = new ElementContainer();
        var builder = new TablerModalFooterBuilder(container, Document);
        footer(builder);
        PrivateFooter = container;
        return this;
    }

    /// <summary>
    /// Returns container for modal footer content.
    /// </summary>
    public ElementContainer Footer() {
        PrivateFooter = new ElementContainer();
        return PrivateFooter;
    }

    /// <inheritdoc />
    protected internal override void RegisterLibraries() {
        Document?.AddLibrary(Libraries.Bootstrap);
        Document?.AddLibrary(Libraries.Tabler);
        base.RegisterLibraries();
    }

    /// <inheritdoc />
    public override string ToString() {
        var modal = new HtmlTag("div")
            .Class("modal modal-blur fade position-relative rounded d-block show bg-surface-backdrop py-6 w-auto h-auto")
            .Id(Id)
            .Attribute("tabindex", "-1")
            .Attribute("role", "dialog")
            .Attribute("aria-hidden", "true");

        var dialog = new HtmlTag("div")
            .Class("modal-dialog")
            .Class(PrivateSize.EnumToString())
            .Class("modal-dialog-centered");
        if (PrivateScrollable) {
            dialog.Class("modal-dialog-scrollable");
        }

        var content = new HtmlTag("div").Class("modal-content");

        var header = new HtmlTag("div").Class("modal-header");
        if (!string.IsNullOrEmpty(PrivateTitle)) {
            header.Value(new HtmlTag("h5").Class("modal-title").Value(PrivateTitle));
        }
        header.Value(new HtmlTag("button").Class("btn-close").Attribute("data-bs-dismiss", "modal").Attribute("aria-label", "Close"));
        content.Value(header);

        if (PrivateContent != null) {
            content.Value(new HtmlTag("div").Class("modal-body").Value(PrivateContent));
        }

        if (PrivateFooter != null) {
            content.Value(new HtmlTag("div").Class("modal-footer").Value(PrivateFooter));
        }

        dialog.Value(content);
        modal.Value(dialog);

        return modal.ToString();
    }
}