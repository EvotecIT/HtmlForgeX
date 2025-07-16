using System;
using System.Linq;
using HtmlForgeX.Logging;
using HtmlForgeX.Extensions;

namespace HtmlForgeX;

/// <summary>
/// Represents an HTML document.
/// </summary>
public partial class Document : Element, System.IDisposable {
    internal static readonly InternalLogger _logger = new();
    private static int _activeDocuments;

    /// <summary>
    /// Configuration and state for this document instance.
    /// </summary>
    public DocumentConfiguration Configuration { get; } = new();

    /// <summary>
    /// Gets the <see cref="Head"/> element of this document.
    /// </summary>
    public Head Head { get; }

    /// <summary>
    /// Gets the <see cref="Body"/> element of this document.
    /// </summary>
    public Body Body { get; }

    /// <summary>
    /// Gets or sets how external libraries are loaded.
    /// </summary>
    public LibraryMode LibraryMode {
        get => Configuration.LibraryMode;
        set => Configuration.LibraryMode = value;
    }

    /// <summary>
    /// Gets or sets the initial theme mode.
    /// </summary>
    public ThemeMode ThemeMode {
        get => Configuration.ThemeMode;
        set => Configuration.ThemeMode = value;
    }

    /// <summary>
    /// Gets or sets the output path used when saving the document.
    /// </summary>
    public string Path {
        get => Configuration.Path;
        set => Configuration.Path = value;
    }

    /// <summary>
    /// Gets or sets the default style output path.
    /// </summary>
    public string StylePath {
        get => Configuration.StylePath;
        set => Configuration.StylePath = value;
    }

    /// <summary>
    /// Gets or sets the default script output path.
    /// </summary>
    public string ScriptPath {
        get => Configuration.ScriptPath;
        set => Configuration.ScriptPath = value;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Document"/> class.
    /// </summary>
    /// <param name="librariesMode">Initial library mode.</param>
    public Document(LibraryMode? librariesMode = null) {
        System.Threading.Interlocked.Increment(ref _activeDocuments);
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
    /// Returns the complete HTML representation of this document.
    /// </summary>
    /// <returns>Complete HTML document as a string.</returns>
    public override string ToString() {
        // Pre-register libraries from all elements before rendering the head
        RegisterAllLibraries();

        // CRITICAL FIX: Force one final registration pass to catch any missed elements
        FinalRegistrationPass();

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
            // CRITICAL FIX: Ensure child has Document reference before registering libraries
            if (child.Document == null) {
                child.Document = this;
                child.OnAddedToDocument(); // This will call RegisterLibraries()
            } else {
                child.RegisterLibraries();
            }
            RegisterLibrariesFromElement(child);
        }
    }

    /// <summary>
    /// Final registration pass to ensure all elements with Document references register their libraries
    /// </summary>
    private void FinalRegistrationPass() {
        FinalRegistrationPassForElement(Body);
    }

    /// <summary>
    /// Recursively forces library registration for all elements in the tree
    /// </summary>
    /// <param name="element">The element to process.</param>
    private void FinalRegistrationPassForElement(Element element) {
        // Force registration on this element if it has a Document reference
        if (element.Document != null) {
            element.RegisterLibraries();
        }

        // Recursively process all children
        foreach (var child in element.Children.WhereNotNull()) {
            FinalRegistrationPassForElement(child);
        }
    }
}
