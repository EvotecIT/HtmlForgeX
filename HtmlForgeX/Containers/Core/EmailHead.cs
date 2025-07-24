using System;
using System.Linq;
using System.Text;

using HtmlForgeX.Extensions;
using HtmlForgeX.Logging;

namespace HtmlForgeX;

/// <summary>
/// Represents the head section of an email document with email-specific meta
/// tags and styling. This includes embedded CSS and viewport configuration used
/// by email clients.
/// </summary>
public class EmailHead : Element {
    private static readonly InternalLogger _logger = new();
    private readonly Email _email;

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailHead"/> class.
    /// </summary>
    /// <param name="email">The parent email document.</param>
    public EmailHead(Email email) {
        _email = email;
    }

    /// <summary>
    /// Gets or sets the title of the email document.
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// Gets or sets the charset (default: utf-8).
    /// </summary>
    public string Charset { get; set; } = "utf-8";

    /// <summary>
    /// Gets or sets the viewport meta content.
    /// </summary>
    public string Viewport { get; set; } = "width=device-width, initial-scale=1.0";

    /// <summary>
    /// Gets or sets the format detection meta content.
    /// </summary>
    public string FormatDetection { get; set; } = "telephone=no";

    /// <summary>
    /// Gets or sets whether to disable Apple message reformatting.
    /// </summary>
    public bool DisableAppleMessageReformatting { get; set; } = true;

    /// <summary>
    /// Gets or sets the color scheme meta content.
    /// </summary>
    public string ColorScheme { get; set; } = "light dark";

    /// <summary>
    /// Gets or sets the supported color schemes.
    /// </summary>
    public string SupportedColorSchemes { get; set; } = "light dark only";

    /// <summary>
    /// Collection of additional meta tags.
    /// </summary>
    public List<HtmlTag> MetaTags { get; set; } = new List<HtmlTag>();

    /// <summary>
    /// Collection of inline CSS styles.
    /// </summary>
    public List<string> InlineStyles { get; set; } = new List<string>();

    /// <summary>
    /// Adds a title to the email document.
    /// </summary>
    /// <param name="title">The title to add.</param>
    /// <returns>The EmailHead object, allowing for method chaining.</returns>
    public EmailHead AddTitle(string title) {
        Title = Helpers.HtmlEncode(title);
        return this;
    }

    /// <summary>
    /// Adds a meta tag to the email document.
    /// </summary>
    /// <param name="name">The name of the meta tag.</param>
    /// <param name="content">The content of the meta tag.</param>
    /// <returns>The EmailHead object, allowing for method chaining.</returns>
    public EmailHead AddMeta(string name, string content) {
        MetaTags.Add(new HtmlTag("meta", "", attributes: new Dictionary<string, object> { { "name", name }, { "content", content } }, TagMode.SelfClosing));
        return this;
    }

    /// <summary>
    /// Adds a meta tag with http-equiv attribute.
    /// </summary>
    /// <param name="httpEquiv">The http-equiv value.</param>
    /// <param name="content">The content value.</param>
    /// <returns>The EmailHead object, allowing for method chaining.</returns>
    public EmailHead AddHttpEquivMeta(string httpEquiv, string content) {
        MetaTags.Add(new HtmlTag("meta", "", attributes: new Dictionary<string, object> { { "http-equiv", httpEquiv }, { "content", content } }, TagMode.SelfClosing));
        return this;
    }

    /// <summary>
    /// Adds inline CSS to the email head.
    /// </summary>
    /// <param name="css">The CSS content to add.</param>
    /// <returns>The EmailHead object, allowing for method chaining.</returns>
    public EmailHead AddCssInline(string css) {
        InlineStyles.Add(css);
        return this;
    }

    /// <summary>
    /// Adds the core email CSS styles.
    /// </summary>
    /// <returns>The EmailHead object, allowing for method chaining.</returns>
    public EmailHead AddEmailCoreStyles() {
        var coreStyles = @"
        @font-face {
            font-family: 'Inter';
            font-style: normal;
            font-weight: 400;
            src: url('https://fonts.gstatic.com/s/inter/v18/UcCO3FwrK3iLTeHuS_nVMrMxCp50SjIw2boKoduKmMEVuLyfAZ9hjQ.ttf') format('truetype');
        }

        body {
            margin: 0;
            padding: 0;
            background-color: #f9fafb;
            font-size: 15px;
            line-height: 160%;
            mso-line-height-rule: exactly;
            color: #4b5563;
            width: 100%;
            -webkit-font-smoothing: antialiased;
            -moz-osx-font-smoothing: grayscale;
            -webkit-font-feature-settings: ""cv02"", ""cv03"", ""cv04"", ""cv11"";
            font-feature-settings: ""cv02"", ""cv03"", ""cv04"", ""cv11"";
            font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif;
        }

        img {
            display: inline-block;
            border: 0 none;
            line-height: 100%;
            outline: none;
            text-decoration: none;
            vertical-align: bottom;
            font-size: 0;
        }

        a:hover {
            text-decoration: underline !important;
        }

        .btn:hover {
            text-decoration: none !important;
        }

        @media only screen and (max-width: 560px) {
            body {
                font-size: 14px !important;
            }

            .content {
                padding: 24px !important;
            }

            h1 {
                font-size: 24px !important;
            }

            .h1 {
                font-size: 24px !important;
            }

            h2 {
                font-size: 20px !important;
            }

            .h2 {
                font-size: 20px !important;
            }

            h3 {
                font-size: 18px !important;
            }

            .h3 {
                font-size: 18px !important;
            }

            .col {
                display: table !important;
                width: 100% !important;
            }

            .row {
                display: table !important;
                width: 100% !important;
            }

            .text-mobile-center {
                text-align: center !important;
            }

            .d-mobile-none {
                display: none !important;
            }
        }";

        AddCssInline(coreStyles);
        return this;
    }

    /// <summary>
    /// Converts the EmailHead object to a string that represents the head section of an email document.
    /// </summary>
    /// <returns>A string that represents the head section of an email document.</returns>
    public override string ToString() {
        // Process any registered email libraries
        foreach (var libraryEnum in _email.Configuration.Email.Libraries
            .OrderBy(l => l.Value)
            .ThenBy(l => (int)l.Key)
            .Select(l => l.Key)
            .WhereNotNull()) {
            var library = EmailLibrariesConverter.MapLibraryEnumToLibraryObject(libraryEnum);
            ProcessEmailLibrary(library);
        }

        var head = StringBuilderCache.Acquire();
        head.AppendLine("<head>");

        // Content-Type meta tag (required for emails)
        head.AppendLine($"<meta http-equiv=\"Content-Type\" content=\"text/html; charset={Helpers.HtmlEncode(Charset)}\" />");

        // Title
        if (!string.IsNullOrEmpty(Title)) {
            head.AppendLine($"<title>{Title}</title>");
        }

        // Viewport meta tag
        head.AppendLine($"<meta name=\"viewport\" content=\"{Helpers.HtmlEncode(Viewport)}\" />");

        // Format detection meta tag
        head.AppendLine($"<meta content=\"{Helpers.HtmlEncode(FormatDetection)}\" name=\"format-detection\" />");

        // Apple message reformatting meta tag
        if (DisableAppleMessageReformatting) {
            head.AppendLine("<meta name=\"x-apple-disable-message-reformatting\" />");
        }

        // Color scheme meta tags for dark mode support
        if (_email.Configuration.DarkModeSupport) {
            head.AppendLine($"<meta name=\"color-scheme\" content=\"{Helpers.HtmlEncode(ColorScheme)}\" />");
            head.AppendLine($"<meta name=\"supported-color-schemes\" content=\"{Helpers.HtmlEncode(SupportedColorSchemes)}\" />");
        }

        // Additional meta tags
        foreach (var metaTag in MetaTags.WhereNotNull()) {
            head.AppendLine($"{metaTag.ToString()}");
        }

        // Dark mode CSS reset
        if (_email.Configuration.DarkModeSupport) {
            head.AppendLine("<style data-premailer=\"ignore\">");
            head.AppendLine(":root {");
            head.AppendLine($"color-scheme: {ColorScheme};");
            head.AppendLine($"supported-color-schemes: {ColorScheme};");
            head.AppendLine("}");
            head.AppendLine();
            head.AppendLine("@media screen and (max-width: 600px) {");
            head.AppendLine("u+.body {");
            head.AppendLine("width: 100vw !important;");
            head.AppendLine("}");
            head.AppendLine("}");
            head.AppendLine();
            head.AppendLine("a[x-apple-data-detectors] {");
            head.AppendLine("color: inherit !important;");
            head.AppendLine("text-decoration: none !important;");
            head.AppendLine("font-size: inherit !important;");
            head.AppendLine("font-family: inherit !important;");
            head.AppendLine("font-weight: inherit !important;");
            head.AppendLine("line-height: inherit !important;");
            head.AppendLine("}");
            head.AppendLine("</style>");
        }

        // MSO conditional comments for Outlook
        head.AppendLine("<!--[if mso]>");
        head.AppendLine("  <style type=\"text/css\">");
        head.AppendLine("body, table, td {");
        head.AppendLine("font-family: Arial, Helvetica, sans-serif !important;");
        head.AppendLine("}");
        head.AppendLine();
        head.AppendLine("img {");
        head.AppendLine("-ms-interpolation-mode: bicubic;");
        head.AppendLine("}");
        head.AppendLine();
        head.AppendLine(".box {");
        head.AppendLine("border-color: #eee !important;");
        head.AppendLine("}");
        head.AppendLine("  </style>");
        head.AppendLine("<![endif]-->");

        // Non-MSO font imports
        head.AppendLine("<!--[if !mso]><!-->");
        head.AppendLine("<link href=\"https://rsms.me/inter/inter.css\" rel=\"stylesheet\" type=\"text/css\" data-premailer=\"ignore\" />");
        head.AppendLine("<style type=\"text/css\" data-premailer=\"ignore\">");
        head.AppendLine("@import url(https://rsms.me/inter/inter.css);");
        head.AppendLine("</style>");
        head.AppendLine("<!--<![endif]-->");

        // Inline styles
        if (InlineStyles.Count > 0) {
            head.AppendLine("<style>");
            foreach (var style in InlineStyles.WhereNotNull()) {
                head.AppendLine(style);
            }
            head.AppendLine("</style>");
        }

        head.AppendLine("</head>");
        return StringBuilderCache.GetStringAndRelease(head);
    }

    private void ProcessEmailLibrary(EmailLibrary library) {
        // Add inline CSS from the library
        foreach (var css in library.InlineCss.WhereNotNull()) {
            AddCssInline(css);
        }
    }
}