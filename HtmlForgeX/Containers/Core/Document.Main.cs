using System;
using System.Linq;
using HtmlForgeX.Logging;
using HtmlForgeX.Extensions;

namespace HtmlForgeX;

/// <summary>
/// Represents an HTML document.
/// </summary>
public partial class Document : Element {
    internal static readonly InternalLogger _logger = new();

    /// <summary>
    /// Configuration and state for this document instance.
    /// </summary>
    public DocumentConfiguration Configuration { get; } = new();

    public Head Head { get; }
    public Body Body { get; }

    public LibraryMode LibraryMode {
        get => Configuration.LibraryMode;
        set => Configuration.LibraryMode = value;
    }

    public ThemeMode ThemeMode {
        get => Configuration.ThemeMode;
        set => Configuration.ThemeMode = value;
    }

    public string Path {
        get => Configuration.Path;
        set => Configuration.Path = value;
    }

    public string StylePath {
        get => Configuration.StylePath;
        set => Configuration.StylePath = value;
    }

    public string ScriptPath {
        get => Configuration.ScriptPath;
        set => Configuration.ScriptPath = value;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Document"/> class.
    /// </summary>
    /// <param name="librariesMode">Initial library mode.</param>
    public Document(LibraryMode? librariesMode = null) {
        if (librariesMode != null) {
            Configuration.LibraryMode = librariesMode.Value;
        }

        // Initialize Head and Body with reference to this document's configuration
        Head = new Head(this);
        Body = new Body(this);

        // Set the document reference for Head and Body so they can propagate it to children
        Head.Document = this;
        Body.Document = this;
    }


    /// <summary>
    /// Converts the Document to its HTML string representation.
    /// </summary>
    /// <returns>Complete HTML document as string.</returns>
    public override string ToString() {
        // Pre-register libraries from all elements before rendering the head
        RegisterAllLibraries();

        var html = StringBuilderCache.Acquire();
        html.AppendLine("<!DOCTYPE html>");
        html.AppendLine("<html>");
        html.Append(Head.ToString());
        html.AppendLine();
        html.Append(Body.ToString());
        html.AppendLine();
        html.AppendLine("</html>");
        return StringBuilderCache.GetStringAndRelease(html);
    }

    /// <summary>
    /// Recursively registers libraries from all elements in the document.
    /// </summary>
    private void RegisterAllLibraries() {
        // Register libraries from Head
        Head.RegisterLibraries();
        RegisterLibrariesFromElement(Head);

        // Register libraries from Body and its children
        Body.RegisterLibraries();
        RegisterLibrariesFromElement(Body);
    }

    /// <summary>
    /// Recursively registers libraries from an element and all its children.
    /// </summary>
    /// <param name="element">The element to process.</param>
    private void RegisterLibrariesFromElement(Element element) {
        foreach (var child in element.Children.WhereNotNull()) {
            child.RegisterLibraries();
            RegisterLibrariesFromElement(child);
        }
    }
}
