using System.Text;

namespace HtmlForgeX;

/// <summary>
/// Represents the <c>&lt;body&gt;</c> element of an HTML document.
/// </summary>
public class Body : Element {
    private readonly Document _document;

    /// <summary>
    /// Initializes a new instance of the <see cref="Body"/> class.
    /// </summary>
    /// <param name="document">The parent document.</param>
    public Body(Document document) {
        _document = document;
    }

    /// <summary>
    /// Adds a child element to the body.
    /// </summary>
    /// <param name="element">Element to add.</param>
    /// <returns>The current <see cref="Body"/> instance.</returns>
    public new Body Add(Element element) {
        base.Add(element);
        return this;
    }

    /// <summary>
    /// Executes a build action in the context of the body.
    /// </summary>
    /// <param name="buildAction">Action that configures the body.</param>
    /// <returns>The current <see cref="Body"/> instance.</returns>
    public Body Add(Action<Body> buildAction) {
        buildAction(this);
        return this;
    }

    /// <summary>
    /// Adds a Tabler page.
    /// </summary>
    /// <returns>The created <see cref="TablerPage"/>.</returns>
    public TablerPage Page() {
        var page = new TablerPage();
        this.Add(page);
        return page;
    }

    /// <summary>
    /// Adds a Tabler page and invokes configuration.
    /// </summary>
    /// <param name="config">Configuration delegate.</param>
    /// <returns>The created <see cref="TablerPage"/>.</returns>
    public TablerPage Page(Action<TablerPage> config) {
        var page = new TablerPage();
        config(page);
        this.Add(page);
        return page;
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
            bodyBuilder.Append(bodyScripts);
        }

        // Add the HTML of the child elements
        foreach (var child in Children) {
            bodyBuilder.AppendLine(child.ToString());
        }

        // Add footer scripts (from library Footer sections) before closing body tag
        var footerScripts = _document.Head.GenerateFooterScripts();
        if (!string.IsNullOrEmpty(footerScripts.Trim())) {
            bodyBuilder.AppendLine();
            bodyBuilder.AppendLine("\t<!-- Footer Scripts -->");
            bodyBuilder.Append(footerScripts);
        }

        bodyBuilder.AppendLine("</body>");

        return StringBuilderCache.GetStringAndRelease(bodyBuilder);
    }
}
