namespace HtmlForgeX.Resources;

/// <summary>
/// PrismJS syntax highlighting library configuration
/// </summary>
public class PrismJsLibrary : Library
{
    public PrismJsLibrary()
    {
        Header = new LibraryLinks {
            CssLink = [
                "https://cdnjs.cloudflare.com/ajax/libs/prism/1.29.0/themes/prism.min.css",
                "https://cdnjs.cloudflare.com/ajax/libs/prism/1.29.0/plugins/line-numbers/prism-line-numbers.min.css",
                "https://cdnjs.cloudflare.com/ajax/libs/prism/1.29.0/plugins/toolbar/prism-toolbar.min.css"
            ]
        };

        Footer = new LibraryLinks {
            JsLink = [
                "https://cdnjs.cloudflare.com/ajax/libs/prism/1.29.0/components/prism-core.min.js",
                "https://cdnjs.cloudflare.com/ajax/libs/prism/1.29.0/plugins/autoloader/prism-autoloader.min.js",
                "https://cdnjs.cloudflare.com/ajax/libs/prism/1.29.0/plugins/line-numbers/prism-line-numbers.min.js",
                "https://cdnjs.cloudflare.com/ajax/libs/prism/1.29.0/plugins/copy-to-clipboard/prism-copy-to-clipboard.min.js",
                "https://cdnjs.cloudflare.com/ajax/libs/prism/1.29.0/plugins/toolbar/prism-toolbar.min.js"
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