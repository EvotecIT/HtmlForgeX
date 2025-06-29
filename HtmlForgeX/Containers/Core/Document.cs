using System;
using System.IO;
using System.Text;
using HtmlForgeX.Logging;

namespace HtmlForgeX;

/// <summary>
/// Represents an HTML document.
/// </summary>
public class Document : Element {
    private static readonly InternalLogger _logger = new();
    public Head Head = new Head();
    public Body Body = new Body();

    public LibraryMode LibraryMode {
        get => GlobalStorage.LibraryMode;
        set => GlobalStorage.LibraryMode = value;
    }

    public ThemeMode ThemeMode {
        get => GlobalStorage.ThemeMode;
        set => GlobalStorage.ThemeMode = value;
    }

    public string Path {
        get => GlobalStorage.Path;
        set => GlobalStorage.Path = value;
    }

    public string StylePath {
        get => GlobalStorage.StylePath;
        set => GlobalStorage.StylePath = value;
    }

    public string ScriptPath {
        get => GlobalStorage.ScriptPath;
        set => GlobalStorage.ScriptPath = value;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Document"/> class.
    /// </summary>
    /// <param name="librariesMode">Initial library mode.</param>
    public Document(LibraryMode? librariesMode = null) {
        if (librariesMode != null) {
            GlobalStorage.LibraryMode = librariesMode.Value;
        }
    }

    /// <summary>
    /// Saves the document to disk.
    /// </summary>
    /// <param name="path">File path.</param>
    /// <param name="openInBrowser">Whether to open the file after saving.</param>
    /// <param name="scriptPath">Optional scripts path.</param>
    /// <param name="stylePath">Optional styles path.</param>
    public void Save(string path, bool openInBrowser = false, string scriptPath = "", string stylePath = "") {
        GlobalStorage.Path = path;
        if (!string.IsNullOrEmpty(scriptPath)) {
            GlobalStorage.ScriptPath = scriptPath;
        }

        if (!string.IsNullOrEmpty(stylePath)) {
            GlobalStorage.StylePath = stylePath;
        }

        var countErrors = GlobalStorage.Errors.Count;
        if (countErrors > 0) {
            Console.WriteLine($"There were {countErrors} found during generation of HTML.");
        }

        var directory = System.IO.Path.GetDirectoryName(path);
        if (!string.IsNullOrEmpty(directory)) {
            System.IO.Directory.CreateDirectory(directory);
        }
        try {
            File.WriteAllText(path, ToString());
        } catch (Exception ex) {
            _logger.WriteError($"Failed to write file '{path}'. {ex.Message}");
        }
        Helpers.Open(path, openInBrowser);
    }

    /// <inheritdoc/>
    public override string ToString() {
        StringBuilder html = new StringBuilder();

        html.AppendLine("<!DOCTYPE html>");
        html.AppendLine("<html>");
        html.AppendLine(this.Head.ToString());
        html.AppendLine(this.Body.ToString());
        html.AppendLine("</html>");

        return html.ToString();
    }

    /// <summary>
    /// Adds a predefined library.
    /// </summary>
    /// <param name="library">Library identifier.</param>
    public void AddLibrary(Libraries library) {
        GlobalStorage.Libraries.TryAdd(library, 0);
    }

    /// <summary>
    /// Adds a custom library definition.
    /// </summary>
    /// <param name="library">Library to add.</param>
    public void AddLibrary(Library library) {
        if (GlobalStorage.LibraryMode == LibraryMode.Online) {
            foreach (var link in library.Header.CssLink) {
                this.Head.AddCssLink(link);
            }

            foreach (var link in library.Header.JsLink) {
                this.Head.AddJsLink(link);
            }
        } else if (GlobalStorage.LibraryMode == LibraryMode.Offline) {
            foreach (var css in library.Header.Css) {
                var cssContent = System.IO.File.ReadAllText(css);
                this.Head.AddCssInline(cssContent);
            }

            foreach (var js in library.Header.Js) {
                var jsContent = System.IO.File.ReadAllText(js);
                this.Head.AddJsInline(jsContent);
            }
        }
    }
}
