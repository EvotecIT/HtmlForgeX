using System;
using System.IO;
using System.Reflection;
using System.Text;

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

    public string? Description { get; set; }

    public string? Keywords { get; set; }

    /// <summary>
    /// Gets or sets the meta tags.
    /// </summary>
    /// <value>
    /// The meta tags.
    /// </value>
    public List<HtmlTag> MetaTags { get; set; } = new List<HtmlTag>();
    public List<object> Styles { get; set; } = new List<object>();
    public List<string> Scripts { get; set; } = new List<string>();
    public List<string> CssLinks { get; set; } = new List<string>();
    public List<string> JsLinks { get; set; } = new List<string>();
    private readonly HashSet<string> _cssLinkSet = new();
    private readonly HashSet<string> _jsLinkSet = new();
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

    public Head AddCharsetMeta(string charset) {
        Charset = charset;
        return this;
    }

    public Head AddHttpEquivMeta(string httpEquiv, string content) {
        HttpEquiv = httpEquiv;
        Content = content;
        return this;
    }

    public Head AddViewportMeta(string content) {
        Viewport = content;
        return this;
    }

    public Head AddAuthorMeta(string author) {
        Author = author;
        return this;
    }

    public Head AddRevisedMeta(DateTime date) {
        Revised = date;
        return this;
    }

    public Head AddStyle(Style style) {
        Styles.Add(style);
        return this;
    }

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
        foreach (var libraryEnum in _document.Configuration.Libraries.Keys) {
            var library = LibrariesConverter.MapLibraryEnumToLibraryObject(libraryEnum);
            ProcessLibrary(library);
        }

        var head = StringBuilderCache.Acquire();
        head.AppendLine("<head>");

        if (!string.IsNullOrEmpty(Title)) {
            head.AppendLine($"\t<title>{Title}</title>");
        }

        if (!string.IsNullOrEmpty(Charset)) {
            head.AppendLine($"\t<meta http-equiv=\"Content-Type\" content=\"text/html; charset={Helpers.HtmlEncode(Charset)}\">");
        }

        if (!string.IsNullOrEmpty(HttpEquiv) && !string.IsNullOrEmpty(Content)) {
            head.AppendLine($"\t<meta http-equiv=\"{Helpers.HtmlEncode(HttpEquiv)}\" content=\"{Helpers.HtmlEncode(Content)}\">");
        }

        if (AutoRefresh.HasValue) {
            head.AppendLine($"\t<meta http-equiv=\"refresh\" content=\"{AutoRefresh.Value}\">");
        }

        head.Append(MetaTagString("viewport", Viewport));
        head.Append(MetaTagString("author", Author));
        head.Append(MetaTagString("description", Description));
        head.Append(MetaTagString("keywords", Keywords));
        head.Append(MetaTagString("revised", Revised?.ToString()));

        foreach (var metaTag in MetaTags) {
            head.AppendLine($"\t{metaTag.ToString()}");
        }

        foreach (var link in CssLinks) {
            head.AppendLine($"\t{link}");
        }

        foreach (var link in JsLinks) {
            head.AppendLine($"\t{link}");
        }

        if (Styles.Count > 0) {
            foreach (var style in Styles) {
                string styleStr = style.ToString();
                if (styleStr.Trim().StartsWith("<style") && styleStr.Trim().EndsWith("</style>")) {
                    head.AppendLine(styleStr);
                } else {
                    head.AppendLine("<style type=\"text/css\">");
                    head.AppendLine(styleStr);
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

    public void AddCssLink(string link) {
        if (_cssLinkSet.Add(link)) {
            CssLinks.Add($"<link rel=\"stylesheet\" href=\"{link}\">");
        }
    }

    public void AddJsLink(string link) {
        if (_jsLinkSet.Add(link)) {
            JsLinks.Add($"<script src=\"{link}\"></script>");
        }
    }

    public void AddCssInline(string css) {
        if (_cssInlineSet.Add(css)) {
            Styles.Add($"<style>{css}</style>");
        }
    }

    public void AddJsInline(string js) {
        if (_jsInlineSet.Add(js)) {
            Scripts.Add($"<script>{js}</script>");
        }
    }

    private void AddRawScript(string script) {
        if (_jsInlineSet.Add(script)) {
            Scripts.Add(script);
        }
    }

    /// <summary>
    /// Adds analytics tracking code based on the specified provider.
    /// </summary>
    /// <param name="provider">Analytics provider.</param>
    /// <param name="identifier">Tracking or token identifier.</param>
    /// <returns>The <see cref="Head"/> instance for chaining.</returns>
    public Head AddAnalytics(AnalyticsProvider provider, string identifier) {
        switch (provider) {
            case AnalyticsProvider.GoogleAnalytics:
                AddRawScript($"<script async src=\"https://www.googletagmanager.com/gtag/js?id={identifier}\"></script>");
                AddRawScript($@"<script>
window.dataLayer = window.dataLayer || [];
function gtag(){{dataLayer.push(arguments);}}
gtag('js', new Date());
gtag('config', '{identifier}');
</script>");
                break;
            case AnalyticsProvider.CloudflareInsights:
                AddRawScript($"<script defer src=\"https://static.cloudflareinsights.com/beacon.min.js\" data-cf-beacon='{{\"token\": \"{identifier}\"}}'></script>");
                break;
            default:
                break;
        }
        return this;
    }

    public void AddCssStyle(Style style) {
        Styles.Add(style);
    }

    private string MetaTagString(string name, string? content) {
        if (string.IsNullOrEmpty(content)) {
            return string.Empty;
        }
        var encoded = Helpers.HtmlEncode(content);
        return $"\t<meta name=\"{name}\" content=\"{encoded}\">\n";
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
                AddCssLink(css);
            }
            foreach (var js in headerLinks.Js) {
                var jsContent = ReadEmbeddedResource("HtmlForgeX.Resources.Scripts." + js);
                // we need to save the js file to disk
                var jsFileName = Path.Combine(_document.Configuration.Path, Path.GetFileName(js));
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
                output.AppendLine($"\t<link rel=\"stylesheet\" href=\"{link}\">");
            }

            // Process JS links
            foreach (var link in libraryLinks.JsLink) {
                output.AppendLine($"\t<script src=\"{link}\"></script>");
            }
        } else if (_document.Configuration.LibraryMode == LibraryMode.Offline) {
            // Process embedded CSS
            foreach (var css in libraryLinks.Css) {
                var cssContent = ReadEmbeddedResource("HtmlForgeX.Resources.Styles." + css);
                output.AppendLine($"\t<style>{cssContent}</style>");
            }

            // Process embedded JS
            foreach (var js in libraryLinks.Js) {
                var jsContent = ReadEmbeddedResource("HtmlForgeX.Resources.Scripts." + js);
                output.AppendLine($"\t<script>{jsContent}</script>");
            }
        } else if (_document.Configuration.LibraryMode == LibraryMode.OfflineWithFiles) {
            // Process CSS file links
            foreach (var css in libraryLinks.Css) {
                output.AppendLine($"\t<link rel=\"stylesheet\" href=\"{Path.GetFileName(css)}\">");
            }

            // Process JS file links
            foreach (var js in libraryLinks.Js) {
                output.AppendLine($"\t<script src=\"{Path.GetFileName(js)}\"></script>");
            }
        }

        // Process inline CSS styles (consistent with Header processing)
        foreach (var style in libraryLinks.CssStyle) {
            output.AppendLine($"\t<style type=\"text/css\">");
            output.AppendLine(style.ToString());
            output.AppendLine($"\t</style>");
        }

        // Process inline JS scripts (consistent with Header processing)
        foreach (var script in libraryLinks.JsScript) {
            output.AppendLine($"\t<script type=\"text/javascript\">");
            output.AppendLine(script);
            output.AppendLine($"\t</script>");
        }
    }

    /// <summary>
    /// Generates footer scripts from library Footer sections with optional deferred execution
    /// </summary>
    /// <returns>HTML string with footer scripts</returns>
    public string GenerateFooterScripts() {
        var footer = StringBuilderCache.Acquire();

        foreach (var libraryEnum in _document.Configuration.Libraries.Keys) {
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

        foreach (var libraryEnum in _document.Configuration.Libraries.Keys) {
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