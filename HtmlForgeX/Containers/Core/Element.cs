using System;
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
            if (_document == value) {
                return;
            }

            bool firstAssign = _document == null && value != null;
            _document = value;
            // Propagate the document reference to all child elements
            PropagateDocumentToChildren();

            if (firstAssign) {
                OnAddedToDocument();
            }
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
        // Only call OnAddedToDocument if the element actually has a Document reference
        if (element.Document != null) {
            element.OnAddedToDocument();
        }

        return this;
    }

    /// <summary>
    /// Called when this element is added to a document.
    /// Override this method to apply document-specific configuration.
    /// </summary>
    protected internal virtual void OnAddedToDocument() {
        // Register libraries when added to document
        RegisterLibraries();

        // Base implementation does nothing else
        // Derived classes can override to apply additional configuration
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
    /// Creates a table from a collection of objects.
    /// </summary>
    /// <param name="objects">Data source.</param>
    /// <param name="tableType">Table library type.</param>
    /// <returns>The created table element.</returns>
    public Table Table(IEnumerable<object> objects, TableType tableType) {
        var table = objects is null
            ? HtmlForgeX.Table.Create(Array.Empty<object>(), tableType)
            : HtmlForgeX.Table.Create(objects, tableType);
        this.Add(table);
        return table;
    }

    /// <summary>
    /// Creates a table from a single object instance.
    /// </summary>
    /// <param name="objects">Object containing data.</param>
    /// <param name="tableType">Table library type.</param>
    /// <returns>The created table element.</returns>
    public Table Table(object objects, TableType tableType) {
        if (objects is null) {
            throw new ArgumentNullException(nameof(objects));
        }

        var table = HtmlForgeX.Table.Create(objects, tableType);
        this.Add(table);
        return table;
    }

    /// <summary>
    /// Adds a line break element.
    /// </summary>
    /// <returns>The created line break.</returns>
    public LineBreak LineBreak() {
        var lineBreak = new LineBreak();
        this.Add(lineBreak);
        return lineBreak;
    }

    /// <summary>
    /// Adds and configures a fancy tree widget.
    /// </summary>
    /// <param name="config">Configuration action.</param>
    /// <returns>The created tree element.</returns>
    public FancyTree FancyTree(Action<FancyTree> config) {
        var fancyTree = new FancyTree();
        config(fancyTree);
        this.Add(fancyTree);
        return fancyTree;
    }

    /// <summary>
    /// Adds a QR code element with specified text.
    /// </summary>
    /// <param name="text">Text to encode.</param>
    /// <returns>The created QR code element.</returns>
    public EasyQRCodeElement QRCode(string text) {
        var qrCode = new EasyQRCodeElement(text);
        this.Add(qrCode);
        return qrCode;
    }

    /// <summary>
    /// Adds a Quill editor component.
    /// </summary>
    /// <param name="config">Optional configuration.</param>
    /// <returns>The created editor element.</returns>
    public QuillEditor QuillEditor(Action<QuillEditor>? config = null) {
        var editor = new QuillEditor();
        config?.Invoke(editor);
        this.Add(editor);
        return editor;
    }

    /// <summary>
    /// Adds a scrolling text component.
    /// </summary>
    /// <param name="config">Configuration action.</param>
    /// <returns>The created component.</returns>
    public ScrollingText ScrollingText(Action<ScrollingText> config) {
        var scrollingText = new ScrollingText();
        config(scrollingText);
        this.Add(scrollingText);
        return scrollingText;
    }

}
