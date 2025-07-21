using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

using HtmlForgeX.Logging;

namespace HtmlForgeX;

/// <summary>
/// Represents the head section of an HTML document.
/// This class allows you to add and manage meta tags, the title, and other elements in the head section.
/// </summary>
public class Head : Element {
    private static readonly InternalLogger _logger = new();
    private readonly Document _document;

    /// <summary>
    /// Initializes a new instance of the <see cref="Head"/> class.
    /// </summary>
    /// <param name="document">The parent document.</param>
    public Head(Document document) {
        _document = document;
    }

    /// <summary>
    /// Gets or sets the title of the HTML document.
    /// This is displayed in the title bar of the web browser.
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// Gets or sets the charset.
    /// </summary>
    /// <value>
    /// The charset.
    /// </value>
    public string? Charset { get; set; } = "utf-8";

    /// <summary>
    /// Gets or sets the HTTP equiv.
    /// </summary>
    /// <value>
    /// The HTTP equiv.
    /// </value>
    public string? HttpEquiv { get; set; }

    /// <summary>
    /// Gets or sets the content.
    /// </summary>
    /// <value>
    /// The content.
    /// </value>
    public string? Content { get; set; }

    /// <summary>
    /// Gets or sets the viewport.
    /// </summary>
    /// <value>
    /// The viewport.
    /// </value>
    public string? Viewport { get; set; }

    /// <summary>
    /// Gets or sets the author.
    /// </summary>
    /// <value>
    /// The author.
    /// </value>
    public string? Author { get; set; }

    /// <summary>
    /// Gets or sets the revised.
    /// </summary>
    /// <value>
    /// The revised.
    /// </value>
    public DateTime? Revised { get; set; }

    /// <summary>
    /// Gets or sets the page description meta tag.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the keywords meta tag.
    /// </summary>
    public string? Keywords { get; set; }

    /// <summary>
    /// Gets or sets the meta tags.
    /// </summary>
    /// <value>
    /// The meta tags.
    /// </value>
    public List<HtmlTag> MetaTags { get; set; } = new List<HtmlTag>();

    /// <summary>
    /// Collection of inline &lt;style&gt; definitions or CSS strings.
    /// </summary>
    public List<object> Styles { get; set; } = new List<object>();

    /// <summary>
    /// Collection of inline scripts.
    /// </summary>
    public List<string> Scripts { get; set; } = new List<string>();

    /// <summary>
    /// External CSS links to include in the head.
    /// </summary>
    public List<string> CssLinks { get; set; } = new List<string>();

    /// <summary>
    /// External JavaScript links to include in the head.
    /// </summary>
    public List<string> JsLinks { get; set; } = new List<string>();
    /// <summary>
    /// External font links to include in the head.
    /// </summary>
    public List<string> FontLinks { get; set; } = new List<string>();
    private readonly HashSet<string> _cssLinkSet = new();
    private readonly HashSet<string> _jsLinkSet = new();
    private readonly HashSet<string> _fontLinkSet = new();
    private readonly HashSet<string> _cssInlineSet = new();
    private readonly HashSet<string> _jsInlineSet = new();
    /// <summary>
    /// Represents the auto refresh time in seconds.
    /// </summary>
    public int? AutoRefresh { get; set; }

    /// <summary>
    /// Adds a title to the HTML document.
    /// This will be displayed in the title bar of the web browser.
    /// </summary>
    /// <param name="title">The title to add.</param>
    /// <returns>The HtmlHead object, allowing for method chaining.</returns>
    public Head AddTitle(string title) {
        Title = Helpers.HtmlEncode(title);
        return this;
    }

    /// <summary>
    /// Adds a meta tag to the HTML document.
    /// If the name matches a known meta tag (charset, http-equiv, content, viewport, author), the corresponding property is set.
    /// </summary>
    /// <param name="name">The name of the meta tag.</param>
    /// <param name="content">The content of the meta tag.</param>
    /// <returns>The HtmlHead object, allowing for method chaining.</returns>
    public Head AddMeta(string name, string content) {
        switch (name.ToLower()) {
            case "charset":
                Charset = content;
                break;
            case "http-equiv":
                HttpEquiv = content;
                break;
            case "content":
                Content = content;
                break;
            case "viewport":
                Viewport = content;
                break;
            case "author":
                Author = content;
                break;
            case "description":
                Description = content;
                break;
            case "keywords":
                Keywords = content;
                break;
            default:
                MetaTags.Add(new HtmlTag("meta", "", attributes: new Dictionary<string, object> { { "name", name }, { "content", content } }, TagMode.SelfClosing));
                break;
        }
        return this;
    }

    /// <summary>
    /// Adds or replaces the charset meta tag.
    /// </summary>
    /// <param name="charset">Character set to use.</param>
    /// <returns>The current <see cref="Head"/> instance.</returns>
    public Head AddCharsetMeta(string charset) {
        Charset = charset;
        return this;
    }

    /// <summary>
    /// Adds an HTTP-equiv meta tag.
    /// </summary>
    /// <param name="httpEquiv">HTTP-equivalent header name.</param>
    /// <param name="content">Content value.</param>
    /// <returns>The current <see cref="Head"/> instance.</returns>
    public Head AddHttpEquivMeta(string httpEquiv, string content) {
        HttpEquiv = httpEquiv;
        Content = content;
        return this;
    }

    /// <summary>
    /// Adds a viewport meta tag.
    /// </summary>
    /// <param name="content">Viewport value.</param>
    /// <returns>The current <see cref="Head"/> instance.</returns>
    public Head AddViewportMeta(string content) {
        Viewport = content;
        return this;
    }

    /// <summary>
    /// Adds an author meta tag.
    /// </summary>
    /// <param name="author">Author name.</param>
    /// <returns>The current <see cref="Head"/> instance.</returns>
    public Head AddAuthorMeta(string author) {
        Author = author;
        return this;
    }

    /// <summary>
    /// Adds a revised date meta tag.
    /// </summary>
    /// <param name="date">Revision date.</param>
    /// <returns>The current <see cref="Head"/> instance.</returns>
    public Head AddRevisedMeta(DateTime date) {
        Revised = date;
        return this;
    }

    /// <summary>
    /// Adds a strongly typed style element.
    /// </summary>
    /// <param name="style">Style to add.</param>
    /// <returns>The current <see cref="Head"/> instance.</returns>
    public Head AddStyle(Style style) {
        Styles.Add(style);
        return this;
    }

    /// <summary>
    /// Adds a raw CSS style string.
    /// </summary>
    /// <param name="style">Style markup.</param>
    /// <returns>The current <see cref="Head"/> instance.</returns>
    public Head AddStyle(string style) {
        Styles.Add(style);
        return this;
    }

    /// <summary>
    /// Converts the HtmlHead object to a string that represents the head section of an HTML document.
    /// This includes the title, meta tags, and other elements in the head section.
    /// </summary>
    /// <returns>A string that represents the head section of an HTML document.</returns>
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
            head.AppendLine($"{link}");
        }

        foreach (var link in CssLinks) {
            head.AppendLine($"{link}");
        }

        foreach (var link in JsLinks) {
            head.AppendLine($"{link}");
        }

        if (Styles.Count > 0) {
            foreach (var style in Styles) {
                string styleStr = style?.ToString() ?? "";
                if (styleStr?.Trim().StartsWith("<style") == true && styleStr.Trim().EndsWith("</style>")) {
                    head.AppendLine(styleStr?.TrimEnd('\r', '\n') ?? "");
                } else {
                    head.AppendLine("<style type=\"text/css\">");
                    head.AppendLine(styleStr?.TrimEnd('\r', '\n') ?? "");
                    head.AppendLine("</style>");
                }
            }
        }

        if (Scripts.Count > 0) {
            foreach (var script in Scripts) {
                string scriptStr = script;
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

    /// <summary>
    /// Adds a set of minimal default styles used by many generated documents.
    /// </summary>
    /// <returns>The current <see cref="Head"/> instance.</returns>
    public Head AddDefaultStyles() {
        Styles.Add(
            """
            body {
                font-family: "Roboto Condensed", sans-serif;
                font-size: 8pt;
                margin: 0px;
            }

            input {
                font-size: 8pt;
            }

            .main-section {
                margin-top: 0px;
            }
            """);
        return this;
    }

    /// <summary>
    /// Registers an external CSS link if it has not already been added.
    /// </summary>
    /// <param name="link">URL to the stylesheet.</param>
    public void AddCssLink(string link) {
        if (_cssLinkSet.Add(link)) {
            CssLinks.Add($"<link rel=\"stylesheet\" href=\"{link}\">");
        }
    }

    /// <summary>
    /// Registers an external JavaScript link if it has not already been added.
    /// </summary>
    /// <param name="link">URL to the script.</param>
    public void AddJsLink(string link) {
        if (_jsLinkSet.Add(link)) {
            JsLinks.Add($"<script src=\"{link}\"></script>");
        }
    }

    /// <summary>
    /// Registers an external font link if it has not already been added.
    /// </summary>
    /// <param name="link">URL to the font stylesheet.</param>
    public void AddFontLink(string link) {
        if (_fontLinkSet.Add(link)) {
            FontLinks.Add($"<link href=\"{link}\" rel=\"stylesheet\">");
        }
    }

    /// <summary>
    /// Sets the font-family for the specified CSS selector.
    /// </summary>
    /// <param name="selector">CSS selector to apply the font to.</param>
    /// <param name="fonts">Font families in preferred order.</param>
    public void SetFontFamily(string selector, params string[] fonts) {
        if (fonts == null || fonts.Length == 0) {
            return;
        }
        var formatted = FormatFonts(fonts);
        AddCssInline($"{selector} {{ font-family: {formatted}; }}");
    }

    /// <summary>
    /// Sets the font-family for the document body.
    /// </summary>
    /// <param name="fonts">Font families in preferred order.</param>
    public void SetBodyFontFamily(params string[] fonts) {
        SetFontFamily("body", fonts);
    }

    private static string FormatFonts(IEnumerable<string> fonts) {
        return string.Join(", ",
            fonts.Where(font => !string.IsNullOrWhiteSpace(font))
                 .Select(QuoteFontIfNeeded));
    }

    private static string QuoteFontIfNeeded(string font) {
        if (string.IsNullOrWhiteSpace(font)) {
            return font;
        }

        var trimmed = font.Trim().Trim('\'', '"');

        if (trimmed.Contains(' ')) {
            return $"'{trimmed}'";
        }

        return trimmed;
    }

    /// <summary>
    /// Adds inline CSS content to the document head.
    /// </summary>
    /// <param name="css">CSS rules to embed.</param>
    public void AddCssInline(string css) {
        css = Regex.Replace(css.Trim(), @"\s+", " ");
        if (_cssInlineSet.Add(css)) {
            Styles.Add($"<style>{css}</style>");
        }
    }

    /// <summary>
    /// Adds inline JavaScript to the document head.
    /// </summary>
    /// <param name="js">JavaScript code to embed.</param>
    public void AddJsInline(string js) {
        // Don't minify JavaScript - it can break the code
        js = js.Trim();
        if (_jsInlineSet.Add(js)) {
            Scripts.Add($"<script>{js}</script>");
        }
    }

    private void AddRawScript(string script) {
        script = script.Trim();
        if (_jsInlineSet.Add(script)) {
            Scripts.Add(script);
        }
    }

    /// <summary>
    /// Adds analytics tracking code based on the specified provider.
    /// </summary>
    /// <param name="provider">Analytics provider.</param>
    /// <param name="identifier">Tracking or token identifier.</param>
    /// <returns><see langword="true"/> when the provider is handled, <see langword="false"/> otherwise.</returns>
    public bool AddAnalytics(AnalyticsProvider provider, string identifier) {
        var encodedIdentifier = Uri.EscapeDataString(identifier);
        switch (provider) {
            case AnalyticsProvider.GoogleAnalytics:
                AddRawScript($"<script async src=\"https://www.googletagmanager.com/gtag/js?id={encodedIdentifier}\"></script>");
                AddRawScript($@"<script>
window.dataLayer = window.dataLayer || [];
function gtag(){{dataLayer.push(arguments);}}
gtag('js', new Date());
gtag('config', '{encodedIdentifier}');
</script>");
                return true;
            case AnalyticsProvider.CloudflareInsights:
                AddRawScript($"<script defer src=\"https://static.cloudflareinsights.com/beacon.min.js\" data-cf-beacon='{{\"token\": \"{encodedIdentifier}\"}}'></script>");
                return true;
            default:
                return false;
        }
    }

    /// <summary>
    /// Adds a <see cref="Style"/> object to the list of styles.
    /// </summary>
    /// <param name="style">Style instance to include.</param>
    public void AddCssStyle(Style style) {
        Styles.Add(style);
    }

    private string MetaTagString(string name, string? content) {
        if (string.IsNullOrEmpty(content)) {
            return string.Empty;
        }
        var encoded = Helpers.HtmlEncode(content!);
        return $"<meta name=\"{name}\" content=\"{encoded}\">\n";
    }

    private void ProcessLibrary(Library library) {
        // Only process Header section in the head
        var headerLinks = library.Header;

        if (_document.Configuration.LibraryMode == LibraryMode.Online) {
            foreach (var link in headerLinks.CssLink) {
                AddCssLink(link);
            }

            foreach (var link in headerLinks.JsLink) {
                AddJsLink(link);
            }
            
            // If no JsLink but has embedded Js resources, embed them inline
            if (headerLinks.JsLink.Count == 0 && headerLinks.Js.Count > 0) {
                foreach (var js in headerLinks.Js) {
                    var jsContent = ReadEmbeddedResource("HtmlForgeX.Resources.Scripts." + js);
                    AddJsInline(jsContent);
                }
            }
            
            // If no CssLink but has embedded Css resources, embed them inline
            if (headerLinks.CssLink.Count == 0 && headerLinks.Css.Count > 0) {
                foreach (var css in headerLinks.Css) {
                    var cssContent = ReadEmbeddedResource("HtmlForgeX.Resources.Styles." + css);
                    AddCssInline(cssContent);
                }
            }
        } else if (_document.Configuration.LibraryMode == LibraryMode.Offline) {
            foreach (var css in headerLinks.Css) {
                var cssContent = ReadEmbeddedResource("HtmlForgeX.Resources.Styles." + css);
                AddCssInline(cssContent);
            }

            foreach (var js in headerLinks.Js) {
                var jsContent = ReadEmbeddedResource("HtmlForgeX.Resources.Scripts." + js);
                AddJsInline(jsContent);
            }

        } else if (_document.Configuration.LibraryMode == LibraryMode.OfflineWithFiles) {
            foreach (var css in headerLinks.Css) {
                var fileName = Path.GetFileName(css);
                var linkPath = string.IsNullOrEmpty(_document.Configuration.StylePath)
                    ? fileName
                    : Path.Combine(_document.Configuration.StylePath, fileName);
                AddCssLink(linkPath.Replace('\\', '/'));
            }

            foreach (var js in headerLinks.Js) {
                var jsContent = ReadEmbeddedResource("HtmlForgeX.Resources.Scripts." + js);
                var fileName = Path.GetFileName(js);
                var linkPath = string.IsNullOrEmpty(_document.Configuration.ScriptPath)
                    ? fileName
                    : Path.Combine(_document.Configuration.ScriptPath, fileName);
                AddJsLink(linkPath.Replace('\\', '/'));

                var baseDir = Path.GetDirectoryName(_document.Configuration.Path) ?? string.Empty;
                var jsFileName = Path.Combine(baseDir, linkPath);
                var jsDirectory = Path.GetDirectoryName(jsFileName);
                if (!string.IsNullOrEmpty(jsDirectory)) {
                    try {
                        Directory.CreateDirectory(jsDirectory);
                    } catch (Exception ex) {
                        _logger.WriteError($"Failed to create directory '{jsDirectory}'. {ex.Message}");
                    }
                }
                FileWriteLock.Semaphore.Wait();
                try {
                    File.WriteAllText(jsFileName, jsContent, Encoding.UTF8);
                } catch (Exception ex) {
                    _logger.WriteError($"Failed to write file '{jsFileName}'. {ex.Message}");
                } finally {
                    FileWriteLock.Semaphore.Release();
                }
            }
        }

        // add css styles regardless of the mode
        foreach (var style in headerLinks.CssStyle) {
            AddCssStyle(style);
        }
        // add js inline script regardless of the mode
        foreach (var style in headerLinks.JsScript) {
            AddJsInline(style);
        }
    }

    /// <summary>
    /// Processes a library section (Header, Footer, or Body) and adds to StringBuilder
    /// </summary>
    /// <param name="libraryLinks">The library links to process</param>
    /// <param name="output">StringBuilder to append to</param>
    private void ProcessLibrarySection(LibraryLinks libraryLinks, StringBuilder output) {
        ProcessLibrarySectionLinks(libraryLinks, output);
    }

    /// <summary>
    /// Unified processing for library links - handles CSS, JS, and inline content consistently
    /// </summary>
    /// <param name="libraryLinks">The library links to process</param>
    /// <param name="output">StringBuilder to append to</param>
    private void ProcessLibrarySectionLinks(LibraryLinks libraryLinks, StringBuilder output) {
        if (_document.Configuration.LibraryMode == LibraryMode.Online) {
            // Process CSS links
            foreach (var link in libraryLinks.CssLink) {
                output.AppendLine($"<link rel=\"stylesheet\" href=\"{link}\">");
            }

            // Process JS links
            foreach (var link in libraryLinks.JsLink) {
                output.AppendLine($"<script src=\"{link}\"></script>");
            }
        } else if (_document.Configuration.LibraryMode == LibraryMode.Offline) {
            // Process embedded CSS
            foreach (var css in libraryLinks.Css) {
                var cssContent = ReadEmbeddedResource("HtmlForgeX.Resources.Styles." + css);
                output.AppendLine($"<style>{cssContent}</style>");
            }

            // Process embedded JS
            foreach (var js in libraryLinks.Js) {
                var jsContent = ReadEmbeddedResource("HtmlForgeX.Resources.Scripts." + js);
                output.AppendLine($"<script>{jsContent}</script>");
            }
        } else if (_document.Configuration.LibraryMode == LibraryMode.OfflineWithFiles) {
            // Process CSS file links
            foreach (var css in libraryLinks.Css) {
                var fileName = Path.GetFileName(css);
                var linkPath = string.IsNullOrEmpty(_document.Configuration.StylePath)
                    ? fileName
                    : Path.Combine(_document.Configuration.StylePath, fileName);
                output.AppendLine($"<link rel=\"stylesheet\" href=\"{linkPath.Replace('\\', '/')}\">");
            }

            // Process JS file links
            foreach (var js in libraryLinks.Js) {
                var fileName = Path.GetFileName(js);
                var linkPath = string.IsNullOrEmpty(_document.Configuration.ScriptPath)
                    ? fileName
                    : Path.Combine(_document.Configuration.ScriptPath, fileName);
                output.AppendLine($"<script src=\"{linkPath.Replace('\\', '/')}\"></script>");
            }
        }

        // Process inline CSS styles (consistent with Header processing)
        foreach (var style in libraryLinks.CssStyle) {
            output.AppendLine($"<style type=\"text/css\">");
            output.AppendLine(style.ToString().TrimEnd('\r', '\n'));
            output.AppendLine($"</style>");
        }

        // Process inline JS scripts (consistent with Header processing)
        foreach (var script in libraryLinks.JsScript) {
            output.AppendLine($"<script type=\"text/javascript\">");
            output.AppendLine(script);
            output.AppendLine($"</script>");
        }
    }

    /// <summary>
    /// Generates footer scripts from library Footer sections with optional deferred execution
    /// </summary>
    /// <returns>HTML string with footer scripts</returns>
    public string GenerateFooterScripts() {
        var footer = StringBuilderCache.Acquire();

        foreach (var libraryEnum in _document.Configuration.Libraries
            .OrderBy(l => l.Value)
            .ThenBy(l => (int)l.Key)
            .Select(l => l.Key)) {
            var library = LibrariesConverter.MapLibraryEnumToLibraryObject(libraryEnum);
            ProcessLibrarySectionLinks(library.Footer, footer);
        }

        // Only add deferred script system if enabled
        if (_document.Configuration.EnableDeferredScripts) {
            footer.AppendLine($@"	<script>
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

    /// <summary>
    /// Generates body scripts from library Body sections with optional deferred execution setup
    /// </summary>
    /// <returns>HTML string with body scripts</returns>
    public string GenerateBodyScripts() {
        var body = StringBuilderCache.Acquire();

        // Only initialize deferred script system if enabled
        if (_document.Configuration.EnableDeferredScripts) {
            body.AppendLine($@"	<script>
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
        //foreach (var displayResource in assembly.GetManifestResourceNames()) {
        //    Console.WriteLine(displayResource);
        //}
        using var stream = assembly.GetManifestResourceStream(resourceName);
        if (stream == null) {
            throw new ArgumentException($"Resource not found: {resourceName}");
        }
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
}