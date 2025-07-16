using System.IO;
using System.Text;

namespace HtmlForgeX;

public partial class Document
{
    /// <summary>
    /// Adds a predefined library.
    /// </summary>
    /// <param name="library">Library identifier.</param>
    public void AddLibrary(Libraries library)
    {
        Configuration.Libraries.TryAdd(library, 0);
    }

    /// <summary>
    /// Adds a predefined library with a custom load order weight.
    /// </summary>
    /// <param name="library">Library identifier.</param>
    /// <param name="weight">Ordering weight. Lower values load first.</param>
    public void AddLibrary(Libraries library, byte weight)
    {
        Configuration.Libraries.TryAdd(library, weight);
    }

    /// <summary>
    /// Adds a custom library definition.
    /// </summary>
    /// <param name="library">Library to add.</param>
    public void AddLibrary(Library library)
    {
        if (Configuration.LibraryMode == LibraryMode.Online)
        {
            foreach (var link in library.Header.CssLink)
            {
                this.Head.AddCssLink(link);
            }

            foreach (var link in library.Header.JsLink)
            {
                this.Head.AddJsLink(link);
            }
        }
        else if (Configuration.LibraryMode == LibraryMode.Offline)
        {
            foreach (var css in library.Header.Css)
            {
                var resolved = System.IO.Path.IsPathRooted(css) ? css : System.IO.Path.Combine(Configuration.Path, css);
                if (!File.Exists(resolved))
                {
                    _logger.WriteError($"CSS file '{resolved}' not found.");
                    continue;
                }
                try
                {
                    var cssContent = File.ReadAllText(resolved, Encoding.UTF8);
                    this.Head.AddCssInline(cssContent);
                }
                catch (Exception ex)
                {
                    _logger.WriteError($"Failed to read CSS file '{resolved}'. {ex.Message}");
                }
            }

            foreach (var js in library.Header.Js)
            {
                var resolved = System.IO.Path.IsPathRooted(js) ? js : System.IO.Path.Combine(Configuration.Path, js);
                if (!File.Exists(resolved))
                {
                    _logger.WriteError($"JS file '{resolved}' not found.");
                    continue;
                }
                try
                {
                    var jsContent = File.ReadAllText(resolved, Encoding.UTF8);
                    this.Head.AddJsInline(jsContent);
                }
                catch (Exception ex)
                {
                    _logger.WriteError($"Failed to read JS file '{resolved}'. {ex.Message}");
                }
            }
        }
    }
}

