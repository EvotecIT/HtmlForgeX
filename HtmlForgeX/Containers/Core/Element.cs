using System.Linq;
using HtmlForgeX.Tags;
using HtmlForgeX.Extensions;

namespace HtmlForgeX;

/// <summary>
/// Base class for all HTML elements in HtmlForgeX.
/// </summary>
public abstract partial class Element {
    /// <summary>
    /// Collection of child elements contained within this element.
    /// </summary>
    public List<Element> Children { get; } = new List<Element>();

    private Document? _document;
    private Email? _email;

    /// <summary>
    /// Gets or sets the parent EmailColumn reference. Used internally for column-aware rendering.
    /// </summary>
    protected internal EmailColumn? ParentColumn { get; set; }

    /// <summary>
    /// Gets or sets the parent document reference. Used internally for library registration.
    /// </summary>
    public Document? Document {
        get => _document;
        set {
            _document = value;
            // Propagate the document reference to all child elements
            PropagateDocumentToChildren();
        }
    }

    /// <summary>
    /// Gets or sets the parent email reference. Used internally for email-specific functionality.
    /// </summary>
    public Email? Email {
        get => _email;
        set {
            _email = value;
            // Propagate the email reference to all child elements
            PropagateEmailToChildren();
        }
    }

    /// <summary>
    /// Adds a child element to this element.
    /// </summary>
    /// <param name="element">The element to add.</param>
    /// <returns>This element for method chaining.</returns>
    public virtual Element Add(Element? element) {
        if (element is null) {
            return this;
        }

        element.Email = this.Email;
        element.Document = this.Document;
        Children.Add(element);

        // Notify the element that it has been added to a document
        element.OnAddedToDocument();

        return this;
    }

    /// <summary>
    /// Called when this element is added to a document.
    /// Override this method to apply document-specific configuration.
    /// </summary>
    protected virtual void OnAddedToDocument() {
        // Base implementation does nothing
        // Derived classes can override to apply configuration
    }

    /// <summary>
    /// Recursively sets the document reference for all child elements.
    /// </summary>
    private void PropagateDocumentToChildren() {
        foreach (var child in Children.WhereNotNull()) {
            child.Document = Document;
        }
    }

    /// <summary>
    /// Recursively sets the email reference for all child elements.
    /// </summary>
    private void PropagateEmailToChildren() {
        foreach (var child in Children.WhereNotNull()) {
            child.Email = Email;
        }
    }

    /// <summary>
    /// Registers required libraries for this element. Override in derived classes to register specific libraries.
    /// </summary>
    protected internal virtual void RegisterLibraries() {
        // Base implementation does nothing - override in derived classes
    }

    /// <summary>
    /// Returns a string representation of the element.
    /// </summary>
    /// <returns>HTML output for this element.</returns>
    public abstract override string ToString();

    /// <summary>
    /// Adds the span.
    /// </summary>
    /// <param name="content">The content.</param>
    /// <returns></returns>
    public Span Span(string content = "") {
        var span = new Span { Content = content };
        this.Add(span);
        return span;
    }

    /// <summary>
    /// Adds a simple text span with optional color and size.
    /// </summary>
    /// <param name="content">The text content.</param>
    /// <param name="color">Optional text color.</param>
    /// <param name="fontSize">Optional font size.</param>
    /// <returns></returns>
    public Span Text(string content, RGBColor? color = null, string? fontSize = null) {
        var span = new Span { Content = content };
        if (color != null) span.WithColor(color);
        if (fontSize != null) span.WithFontSize(fontSize);
        this.Add(span);
        return span;
    }

    /// <summary>
    /// Adds the table.
    /// </summary>
    /// <param name="objects">The objects.</param>
    /// <param name="tableType">Type of the table.</param>
    /// <returns></returns>
    public Table Table(IEnumerable<object> objects, TableType tableType) {
        var table = HtmlForgeX.Table.Create(objects, tableType);
        this.Add(table);
        return table;
    }

    public Table Table(Object objects, TableType tableType) {
        var table = HtmlForgeX.Table.Create(objects, tableType);
        this.Add(table);
        return table;
    }

    public LineBreak LineBreak() {
        var lineBreak = new LineBreak();
        this.Add(lineBreak);
        return lineBreak;
    }

    public FancyTree FancyTree(Action<FancyTree> config) {
        var fancyTree = new FancyTree();
        config(fancyTree);
        this.Add(fancyTree);
        return fancyTree;
    }

    public EasyQRCodeElement QRCode(string text) {
        var qrCode = new EasyQRCodeElement(text);
        this.Add(qrCode);
        return qrCode;
    }

    public QuillEditor QuillEditor(Action<QuillEditor>? config = null) {
        var editor = new QuillEditor();
        config?.Invoke(editor);
        this.Add(editor);
        return editor;
    }

    public ScrollingText ScrollingText(Action<ScrollingText> config) {
        var scrollingText = new ScrollingText();
        config(scrollingText);
        this.Add(scrollingText);
        return scrollingText;
    }

}
