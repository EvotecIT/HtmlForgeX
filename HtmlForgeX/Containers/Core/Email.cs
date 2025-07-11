using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using HtmlForgeX.Logging;

namespace HtmlForgeX;

/// <summary>
/// Represents an email document with XHTML 1.0 Strict compliance for email clients.
/// </summary>
public class Email : Element {
    private static readonly InternalLogger _logger = new();

    /// <summary>
    /// Configuration and state for this email document instance.
    /// </summary>
    public EmailConfiguration Configuration { get; } = new();

    public EmailHead Head { get; }
    public EmailBody Body { get; }

    public EmailLibraryMode LibraryMode {
        get => Configuration.LibraryMode;
        set => Configuration.LibraryMode = value;
    }

    public EmailThemeMode ThemeMode {
        get => Configuration.ThemeMode;
        set => Configuration.ThemeMode = value;
    }

    public string Path {
        get => Configuration.Path;
        set => Configuration.Path = value;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Email"/> class.
    /// </summary>
    /// <param name="librariesMode">Initial library mode (must be inline CSS only).</param>
    public Email(EmailLibraryMode? librariesMode = null) {
        if (librariesMode != null) {
            Configuration.LibraryMode = librariesMode.Value;
        }

        // Initialize Head and Body with reference to this email's configuration
        Head = new EmailHead(this);
        Body = new EmailBody(this);

        // Set the email reference for Head and Body so they can propagate it to children
        Head.Email = this;
        Body.Email = this;
    }

    /// <summary>
    /// Saves the email to disk.
    /// </summary>
    /// <param name="path">File path.</param>
    /// <param name="openInBrowser">Whether to open the file after saving.</param>
    public void Save(string path, bool openInBrowser = false) {
        Configuration.Path = path;

        var countErrors = Configuration.Errors.Count;
        if (countErrors > 0) {
            Console.WriteLine($"There were {countErrors} found during generation of email HTML.");
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
    /// Saves the email to disk asynchronously.
    /// </summary>
    /// <param name="path">File path.</param>
    /// <param name="openInBrowser">Whether to open the file after saving.</param>
    public async Task SaveAsync(string path, bool openInBrowser = false) {
        Configuration.Path = path;

        var countErrors = Configuration.Errors.Count;
        if (countErrors > 0) {
            Console.WriteLine($"There were {countErrors} found during generation of email HTML.");
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
    /// Converts the Email to its XHTML string representation.
    /// </summary>
    /// <returns>Complete XHTML email document as string.</returns>
    public override string ToString() {
        // Pre-register libraries from all elements before rendering the head
        RegisterAllLibraries();

        var html = StringBuilderCache.Acquire();
        html.AppendLine("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Strict//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd\">");
        html.AppendLine("<html xmlns=\"http://www.w3.org/1999/xhtml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\" style=\"color-scheme: light dark; supported-color-schemes: light dark;\">");
        html.Append(Head.ToString());
        html.AppendLine();
        html.Append(Body.ToString());
        html.AppendLine();
        html.AppendLine("</html>");
        return StringBuilderCache.GetStringAndRelease(html);
    }

    /// <summary>
    /// Recursively registers libraries from all elements in the email.
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
    /// Adds a predefined email library.
    /// </summary>
    /// <param name="library">Library identifier.</param>
    public void AddLibrary(EmailLibraries library) {
        Configuration.Libraries.TryAdd(library, 0);
    }

    /// <summary>
    /// Adds a custom email library definition.
    /// Email libraries can only contain inline CSS - no external links or JavaScript.
    /// </summary>
    /// <param name="library">Library to add.</param>
    public void AddLibrary(EmailLibrary library) {
        // Email libraries only support inline CSS
        foreach (var css in library.InlineCss) {
            this.Head.AddCssInline(css);
        }
    }
}