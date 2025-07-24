using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace HtmlForgeX;

/// <summary>
/// Script and style registration for <see cref="Head"/>.
/// </summary>
public partial class Head {
    /// <summary>Collection of inline &lt;style&gt; definitions or CSS strings.</summary>
    public List<object> Styles { get; } = new();

    /// <summary>Collection of inline scripts.</summary>
    public List<string> Scripts { get; } = new();

    /// <summary>External CSS links to include in the head.</summary>
    public List<string> CssLinks { get; } = new();

    /// <summary>External JavaScript links to include in the head.</summary>
    public List<string> JsLinks { get; } = new();

    /// <summary>External font links to include in the head.</summary>
    public List<string> FontLinks { get; } = new();

    private readonly object _syncRoot = new();

    private readonly HashSet<string> _cssLinkSet = new();
    private readonly HashSet<string> _jsLinkSet = new();
    private readonly HashSet<string> _fontLinkSet = new();
    private readonly HashSet<string> _cssInlineSet = new();
    private readonly HashSet<string> _jsInlineSet = new();

    /// <summary>Adds a strongly typed style element.</summary>
    public Head AddStyle(Style style) {
        Styles.Add(style);
        return this;
    }

    /// <summary>Adds a raw CSS style string.</summary>
    public Head AddStyle(string style) {
        Styles.Add(style);
        return this;
    }

    /// <summary>Adds a set of minimal default styles used by many generated documents.</summary>
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

    /// <summary>Registers an external CSS link if not already added.</summary>
    public void AddCssLink(string link) {
        lock (_syncRoot) {
            if (_cssLinkSet.Add(link)) {
                CssLinks.Add($"<link rel=\"stylesheet\" href=\"{link}\">");
            }
        }
    }

    /// <summary>Registers an external JavaScript link if not already added.</summary>
    public void AddJsLink(string link) {
        lock (_syncRoot) {
            if (_jsLinkSet.Add(link)) {
                JsLinks.Add($"<script src=\"{link}\"></script>");
            }
        }
    }

    /// <summary>Registers an external font link if not already added.</summary>
    public void AddFontLink(string link) {
        lock (_syncRoot) {
            if (_fontLinkSet.Add(link)) {
                FontLinks.Add($"<link href=\"{link}\" rel=\"stylesheet\">");
            }
        }
    }

    /// <summary>Sets the font-family for the specified selector.</summary>
    public void SetFontFamily(string selector, params string[] fonts) {
        if (fonts == null || fonts.Length == 0) {
            return;
        }

        var formatted = FormatFonts(fonts);
        AddCssInline($"{selector} {{ font-family: {formatted}; }}");
    }

    /// <summary>Sets the font-family for the document body.</summary>
    public void SetBodyFontFamily(params string[] fonts) => SetFontFamily("body", fonts);

    private static string FormatFonts(IEnumerable<string> fonts) =>
        string.Join(", ", fonts.Where(font => !string.IsNullOrWhiteSpace(font)).Select(QuoteFontIfNeeded));

    private static string QuoteFontIfNeeded(string font) {
        if (string.IsNullOrWhiteSpace(font)) {
            return font;
        }

        var trimmed = font.Trim().Trim('\'', '"');
        return trimmed.Contains(' ') ? $"'{trimmed}'" : trimmed;
    }

    /// <summary>Adds inline CSS content to the document head.</summary>
    public void AddCssInline(string css) {
        css = Regex.Replace(css.Trim(), @"\s+", " ");
        lock (_syncRoot) {
            if (_cssInlineSet.Add(css)) {
                Styles.Add($"<style>{css}</style>");
            }
        }
    }

    /// <summary>Adds inline JavaScript to the document head.</summary>
    public void AddJsInline(string js) {
        js = js.Trim();
        lock (_syncRoot) {
            if (_jsInlineSet.Add(js)) {
                Scripts.Add($"<script>{js}</script>");
            }
        }
    }

    private void AddRawScript(string script) {
        script = script.Trim();
        lock (_syncRoot) {
            if (_jsInlineSet.Add(script)) {
                Scripts.Add(script);
            }
        }
    }

    /// <summary>Adds analytics tracking code based on the specified provider.</summary>
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

    /// <summary>Adds a <see cref="Style"/> object to the list of styles.</summary>
    public void AddCssStyle(Style style) => Styles.Add(style);
}