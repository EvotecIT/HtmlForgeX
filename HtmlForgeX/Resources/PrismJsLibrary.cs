namespace HtmlForgeX.Resources;

/// <summary>
/// PrismJS syntax highlighting library configuration
/// </summary>
public class PrismJsLibrary : Library {
    /// <summary>
    /// Initializes a new instance of the <see cref="PrismJsLibrary"/> class.
    /// </summary>
    public PrismJsLibrary() {
        Header = new LibraryLinks {
            CssLink = [
                "https://cdn.jsdelivr.net/npm/prismjs@1.29.0/themes/prism.min.css",
                "https://cdn.jsdelivr.net/npm/prismjs@1.29.0/plugins/line-numbers/prism-line-numbers.min.css",
                "https://cdn.jsdelivr.net/npm/prismjs@1.29.0/plugins/toolbar/prism-toolbar.min.css"
            ],
            Css = [
                "prism.min.css",
                "prism-line-numbers.min.css",
                "prism-toolbar.min.css"
            ]
        };

        Footer = new LibraryLinks {
            JsLink = [
                "https://cdn.jsdelivr.net/npm/prismjs@1.29.0/components/prism-core.min.js",
                "https://cdn.jsdelivr.net/npm/prismjs@1.29.0/plugins/autoloader/prism-autoloader.min.js",
                "https://cdn.jsdelivr.net/npm/prismjs@1.29.0/plugins/line-numbers/prism-line-numbers.min.js",
                "https://cdn.jsdelivr.net/npm/prismjs@1.29.0/plugins/toolbar/prism-toolbar.min.js",
                "https://cdn.jsdelivr.net/npm/prismjs@1.29.0/plugins/copy-to-clipboard/prism-copy-to-clipboard.min.js"
            ],
            Js = [
                "prism-core.min.js",
                "prism-autoloader.min.js",
                "prism-line-numbers.min.js",
                "prism-toolbar.min.js",
                "prism-copy-to-clipboard.min.js"
            ]
        };

        Comment = "PrismJS - Lightweight, extensible syntax highlighter";
        Website = "https://prismjs.com/";
        SourceCodes = "https://github.com/PrismJS/prism";
        LicenseLink = "https://github.com/PrismJS/prism/blob/master/LICENSE";
        License = "MIT License";
        Default = false;
        Email = false;
    }
}