using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HtmlForgeX;

/// <summary>
/// Rendering helpers for <see cref="Head"/>.
/// </summary>
public partial class Head {
    /// <inheritdoc />
    public override string ToString() {
        foreach (var libraryEnum in _document.Configuration.Libraries
            .OrderBy(l => l.Value)
            .ThenBy(l => (int)l.Key)
            .Select(l => l.Key)) {
            var library = LibrariesConverter.MapLibraryEnumToLibraryObject(libraryEnum);
            ProcessLibrary(library);
        }

        var head = StringBuilderCache.Acquire();
        head.AppendLine("<head>");

        if (!string.IsNullOrEmpty(Title)) {
            head.AppendLine($"<title>{Title}</title>");
        }

        if (!string.IsNullOrEmpty(Charset)) {
            head.AppendLine($"<meta http-equiv=\"Content-Type\" content=\"text/html; charset={Helpers.HtmlEncode(Charset!)}\">");
        }

        if (!string.IsNullOrEmpty(HttpEquiv) && !string.IsNullOrEmpty(Content)) {
            head.AppendLine($"<meta http-equiv=\"{Helpers.HtmlEncode(HttpEquiv!)}\" content=\"{Helpers.HtmlEncode(Content!)}\">");
        }

        if (AutoRefresh.HasValue) {
            head.AppendLine($"<meta http-equiv=\"refresh\" content=\"{AutoRefresh.Value}\">");
        }

        head.Append(MetaTagString("viewport", Viewport));
        head.Append(MetaTagString("author", Author));
        head.Append(MetaTagString("description", Description));
        head.Append(MetaTagString("keywords", Keywords));
        head.Append(MetaTagString("revised", Revised?.ToString()));

        foreach (var metaTag in MetaTags) {
            head.AppendLine($"{metaTag.ToString().TrimEnd('\r', '\n')}");
        }

        foreach (var link in FontLinks) {
            head.AppendLine(link);
        }

        foreach (var link in CssLinks) {
            head.AppendLine(link);
        }

        foreach (var link in JsLinks) {
            head.AppendLine(link);
        }

        if (Styles.Count > 0) {
            foreach (var style in Styles) {
                var styleStr = style?.ToString() ?? string.Empty;
                if (styleStr.Trim().StartsWith("<style") && styleStr.Trim().EndsWith("</style>")) {
                    head.AppendLine(styleStr.TrimEnd('\r', '\n'));
                } else {
                    head.AppendLine("<style type=\"text/css\">");
                    head.AppendLine(styleStr.TrimEnd('\r', '\n'));
                    head.AppendLine("</style>");
                }
            }
        }

        if (Scripts.Count > 0) {
            foreach (var script in Scripts) {
                var scriptStr = script;
                if (scriptStr.Trim().StartsWith("<script") && scriptStr.Trim().EndsWith("</script>")) {
                    head.AppendLine(scriptStr);
                } else {
                    head.AppendLine("<script type=\"text/javascript\">");
                    head.AppendLine(scriptStr);
                    head.AppendLine("</script>");
                }
            }
        }

        head.AppendLine("</head>");
        return StringBuilderCache.GetStringAndRelease(head);
    }

    private string MetaTagString(string name, string? content) {
        if (string.IsNullOrEmpty(content)) {
            return string.Empty;
        }

        var encoded = Helpers.HtmlEncode(content!);
        return $"<meta name=\"{name}\" content=\"{encoded}\">\n";
    }

    private void ProcessLibrary(Library library) {
        LibraryRegistrar.RegisterLibrary(_document, this, library, false);
    }

    private void ProcessLibrarySection(LibraryLinks libraryLinks, StringBuilder output) {
        ProcessLibrarySectionLinks(libraryLinks, output);
    }

    private void ProcessLibrarySectionLinks(LibraryLinks libraryLinks, StringBuilder output) {
        if (_document.Configuration.LibraryMode == LibraryMode.Online) {
            foreach (var link in libraryLinks.CssLink) {
                output.AppendLine($"<link rel=\"stylesheet\" href=\"{link}\">");
            }

            foreach (var link in libraryLinks.JsLink) {
                output.AppendLine($"<script src=\"{link}\"></script>");
            }
        } else if (_document.Configuration.LibraryMode == LibraryMode.Offline) {
            foreach (var css in libraryLinks.Css) {
                var cssContent = ReadEmbeddedResource("HtmlForgeX.Resources.Styles." + css);
                output.AppendLine($"<style>{cssContent}</style>");
            }

            foreach (var js in libraryLinks.Js) {
                var jsContent = ReadEmbeddedResource("HtmlForgeX.Resources.Scripts." + js);
                output.AppendLine($"<script>{jsContent}</script>");
            }
        } else if (_document.Configuration.LibraryMode == LibraryMode.OfflineWithFiles) {
            foreach (var css in libraryLinks.Css) {
                var fileName = Path.GetFileName(css);
                var linkPath = string.IsNullOrEmpty(_document.Configuration.StylePath)
                    ? fileName
                    : Path.Combine(_document.Configuration.StylePath, fileName);
                output.AppendLine($"<link rel=\"stylesheet\" href=\"{linkPath.Replace('\\', '/')}\">");
            }

            foreach (var js in libraryLinks.Js) {
                var fileName = Path.GetFileName(js);
                var linkPath = string.IsNullOrEmpty(_document.Configuration.ScriptPath)
                    ? fileName
                    : Path.Combine(_document.Configuration.ScriptPath, fileName);
                output.AppendLine($"<script src=\"{linkPath.Replace('\\', '/')}\"></script>");
            }
        }

        foreach (var style in libraryLinks.CssStyle) {
            output.AppendLine("<style type=\"text/css\">");
            output.AppendLine(style.ToString().TrimEnd('\r', '\n'));
            output.AppendLine("</style>");
        }

        foreach (var script in libraryLinks.JsScript) {
            output.AppendLine("<script type=\"text/javascript\">");
            output.AppendLine(script);
            output.AppendLine("</script>");
        }
    }

    /// <summary>Generates footer scripts from library Footer sections with optional deferred execution.</summary>
    public string GenerateFooterScripts() {
        var footer = StringBuilderCache.Acquire();

        foreach (var libraryEnum in _document.Configuration.Libraries
            .OrderBy(l => l.Value)
            .ThenBy(l => (int)l.Key)
            .Select(l => l.Key)) {
            var library = LibrariesConverter.MapLibraryEnumToLibraryObject(libraryEnum);
            ProcessLibrarySectionLinks(library.Footer, footer);
        }

        if (_document.Configuration.EnableDeferredScripts) {
            footer.AppendLine($@"       <script>
                window.htmlForgeXLibrariesLoaded = true;
                // Trigger any deferred component initializations
                if (window.htmlForgeXDeferredScripts) {{
                        window.htmlForgeXDeferredScripts.forEach(function(script) {{ script(); }});
                        window.htmlForgeXDeferredScripts = [];
                }}
        </script>");
        }

        return StringBuilderCache.GetStringAndRelease(footer);
    }

    /// <summary>Generates body scripts from library Body sections with optional deferred execution setup.</summary>
    public string GenerateBodyScripts() {
        var body = StringBuilderCache.Acquire();

        if (_document.Configuration.EnableDeferredScripts) {
            body.AppendLine($@" <script>
                window.htmlForgeXLibrariesLoaded = false;
                window.htmlForgeXDeferredScripts = [];

                // Helper function to defer script execution until libraries are loaded
                function deferUntilLibrariesLoaded(callback) {{
                        if (window.htmlForgeXLibrariesLoaded) {{
                                callback();
                        }} else {{
                                window.htmlForgeXDeferredScripts.push(callback);
                        }}
                }}
        </script>");
        }

        foreach (var libraryEnum in _document.Configuration.Libraries
            .OrderBy(l => l.Value)
            .ThenBy(l => (int)l.Key)
            .Select(l => l.Key)) {
            var library = LibrariesConverter.MapLibraryEnumToLibraryObject(libraryEnum);
            ProcessLibrarySectionLinks(library.Body, body);
        }

        return StringBuilderCache.GetStringAndRelease(body);
    }

    private string ReadEmbeddedResource(string resourceName) {
        var assembly = Assembly.GetExecutingAssembly();
        using var stream = assembly.GetManifestResourceStream(resourceName);
        if (stream == null) {
            throw new ArgumentException($"Resource not found: {resourceName}");
        }

        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
}