using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using HtmlForgeX.Logging;

namespace HtmlForgeX;

/// <summary>
/// Represents an HTML document.
/// </summary>
public class Document : Element {
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
    /// Saves the document to disk.
    /// </summary>
    /// <param name="path">File path.</param>
    /// <param name="openInBrowser">Whether to open the file after saving.</param>
    /// <param name="scriptPath">Optional scripts path.</param>
    /// <param name="stylePath">Optional styles path.</param>
    public void Save(string path, bool openInBrowser = false, string scriptPath = "", string stylePath = "") {
        Configuration.Path = path;
        if (!string.IsNullOrEmpty(scriptPath)) {
            Configuration.ScriptPath = scriptPath;
        }

        if (!string.IsNullOrEmpty(stylePath)) {
            Configuration.StylePath = stylePath;
        }

        var countErrors = Configuration.Errors.Count;
        if (countErrors > 0) {
            Console.WriteLine($"There were {countErrors} found during generation of HTML.");
        }

        var directory = System.IO.Path.GetDirectoryName(path);
        if (!string.IsNullOrEmpty(directory)) {
            try {
                System.IO.Directory.CreateDirectory(directory);
            } catch (Exception ex) {
                _logger.WriteError($"Failed to create directory '{directory}'. {ex.Message}");
            }
        }
        try {
            File.WriteAllText(path, ToString(), Encoding.UTF8);
        } catch (Exception ex) {
            _logger.WriteError($"Failed to write file '{path}'. {ex.Message}");
        }
        if (!Helpers.Open(path, openInBrowser)) {
            _logger.WriteError($"Failed to open file '{path}' using the default application.");
        }
    }

    /// <summary>
    /// Saves the document to disk asynchronously.
    /// </summary>
    /// <param name="path">File path.</param>
    /// <param name="openInBrowser">Whether to open the file after saving.</param>
    /// <param name="scriptPath">Optional scripts path.</param>
    /// <param name="stylePath">Optional styles path.</param>
    public async Task SaveAsync(string path, bool openInBrowser = false, string scriptPath = "", string stylePath = "") {
        Configuration.Path = path;
        if (!string.IsNullOrEmpty(scriptPath)) {
            Configuration.ScriptPath = scriptPath;
        }

        if (!string.IsNullOrEmpty(stylePath)) {
            Configuration.StylePath = stylePath;
        }

        var countErrors = Configuration.Errors.Count;
        if (countErrors > 0) {
            Console.WriteLine($"There were {countErrors} found during generation of HTML.");
        }

        var directory = System.IO.Path.GetDirectoryName(path);
        if (!string.IsNullOrEmpty(directory)) {
            try {
                System.IO.Directory.CreateDirectory(directory);
            } catch (Exception ex) {
                _logger.WriteError($"Failed to create directory '{directory}'. {ex.Message}");
            }
        }
        try {
#if NET5_0_OR_GREATER
            await File.WriteAllTextAsync(path, ToString(), Encoding.UTF8).ConfigureAwait(false);
#else
            using var writer = new StreamWriter(path, false, Encoding.UTF8);
            // Prevent returning to the captured context (e.g. UI thread)
            await writer.WriteAsync(ToString()).ConfigureAwait(false);
#endif
        } catch (Exception ex) {
            _logger.WriteError($"Failed to write file '{path}'. {ex.Message}");
        }
        if (!Helpers.Open(path, openInBrowser)) {
            _logger.WriteError($"Failed to open file '{path}' using the default application.");
        }
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
        foreach (var child in element.Children) {
            child.RegisterLibraries();
            RegisterLibrariesFromElement(child);
        }
    }

    /// <summary>
    /// Adds a predefined library.
    /// </summary>
    /// <param name="library">Library identifier.</param>
    public void AddLibrary(Libraries library) {
        Configuration.Libraries.TryAdd(library, 0);
    }

    /// <summary>
    /// Adds a custom library definition.
    /// </summary>
    /// <param name="library">Library to add.</param>
    public void AddLibrary(Library library) {
        if (Configuration.LibraryMode == LibraryMode.Online) {
            foreach (var link in library.Header.CssLink) {
                this.Head.AddCssLink(link);
            }

            foreach (var link in library.Header.JsLink) {
                this.Head.AddJsLink(link);
            }
        } else if (Configuration.LibraryMode == LibraryMode.Offline) {
            foreach (var css in library.Header.Css) {
                var resolved = System.IO.Path.IsPathRooted(css) ? css : System.IO.Path.Combine(Configuration.Path, css);
                if (!File.Exists(resolved)) {
                    _logger.WriteError($"CSS file '{resolved}' not found.");
                    continue;
                }
                try {
                    var cssContent = File.ReadAllText(resolved);
                    this.Head.AddCssInline(cssContent);
                } catch (Exception ex) {
                    _logger.WriteError($"Failed to read CSS file '{resolved}'. {ex.Message}");
                }
            }

            foreach (var js in library.Header.Js) {
                var resolved = System.IO.Path.IsPathRooted(js) ? js : System.IO.Path.Combine(Configuration.Path, js);
                if (!File.Exists(resolved)) {
                    _logger.WriteError($"JS file '{resolved}' not found.");
                    continue;
                }
                try {
                    var jsContent = File.ReadAllText(resolved);
                    this.Head.AddJsInline(jsContent);
                } catch (Exception ex) {
                    _logger.WriteError($"Failed to read JS file '{resolved}'. {ex.Message}");
                }
            }
        }
    }
}
