using System.Text;
using System.Linq;
using HtmlForgeX.Extensions;

namespace HtmlForgeX;

public partial class Body : Element {
    private readonly Document _document;

    /// <summary>
    /// Initializes a new instance of the <see cref="Body"/> class.
    /// </summary>
    /// <param name="document">The parent document.</param>
    public Body(Document document) {
        _document = document;
    }

    /// <inheritdoc/>
    public override string ToString() {
        var bodyBuilder = StringBuilderCache.Acquire();
        if (_document.Configuration.ThemeMode == ThemeMode.Dark) {
            bodyBuilder.AppendLine("<body data-bs-theme=\"dark\">");
        } else if (_document.Configuration.ThemeMode == ThemeMode.Light) {
            bodyBuilder.AppendLine("<body data-bs-theme=\"light\">");
        } else if (_document.Configuration.ThemeMode == ThemeMode.System) {
            // This is the default value, but we need to write some javascript to set the theme
            bodyBuilder.AppendLine("<body data-bs-theme=\"light\">");
        } else {
            bodyBuilder.AppendLine("<body>");
        }

        // Add body scripts (from library Body sections) at the top of body
        var bodyScripts = _document.Head.GenerateBodyScripts();
        if (!string.IsNullOrEmpty(bodyScripts.Trim())) {
            bodyBuilder.AppendLine();
            bodyBuilder.AppendLine("\t<!-- Body Scripts -->");
            bodyBuilder.Append(bodyScripts.TrimEnd('\r', '\n'));
        }

        // Add the HTML of the child elements
        foreach (var child in Children.WhereNotNull()) {
            bodyBuilder.AppendLine(child.ToString().TrimEnd('\r', '\n'));
        }

        // Add footer scripts (from library Footer sections) before closing body tag
        var footerScripts = _document.Head.GenerateFooterScripts();
        if (!string.IsNullOrEmpty(footerScripts.Trim())) {
            bodyBuilder.AppendLine();
            bodyBuilder.AppendLine("\t<!-- Footer Scripts -->");
            bodyBuilder.Append(footerScripts.TrimEnd('\r', '\n'));
        }

        bodyBuilder.AppendLine("</body>");

        return StringBuilderCache.GetStringAndRelease(bodyBuilder);
    }
}
