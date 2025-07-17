using System.Text;
using System.Linq;
using HtmlForgeX.Logging;
using HtmlForgeX.Extensions;

namespace HtmlForgeX;

/// <summary>
/// Represents the body section of an email document with table-based layout for email client compatibility.
/// </summary>
public class EmailBody : Element {
    private static readonly InternalLogger _logger = new();
    private readonly Email _email;

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailBody"/> class.
    /// </summary>
    /// <param name="email">The parent email document.</param>
    public EmailBody(Email email) {
        _email = email;
    }

    /// <summary>
    /// Gets or sets the background color of the email body.
    /// </summary>
    public string BackgroundColor { get; set; } = "#f9fafb";

    /// <summary>
    /// Gets the appropriate background color based on theme mode.
    /// </summary>
    public string GetThemeBackgroundColor() {
        return _email.Configuration.Email.ThemeMode == EmailThemeMode.Dark ? "#1f2937" : BackgroundColor;
    }

    /// <summary>
    /// Gets or sets additional CSS classes for the body.
    /// </summary>
    public string CssClass { get; set; } = "bg-body";

    /// <summary>
    /// Gets or sets the maximum width of the email content.
    /// </summary>
    public int MaxWidth {
        get => _email.Configuration.Email.MaxWidth;
        set => _email.Configuration.Email.MaxWidth = value;
    }

    /// <summary>
    /// Gets or sets the preheader text.
    /// </summary>
    public string PreheaderText {
        get => _email.Configuration.Email.PreheaderText;
        set => _email.Configuration.Email.PreheaderText = value;
    }

    /// <summary>
    /// Gets or sets whether to include preheader text.
    /// </summary>
    public bool IncludePreheader {
        get => _email.Configuration.Email.IncludePreheader;
        set => _email.Configuration.Email.IncludePreheader = value;
    }

    /// <summary>
    /// Adds content to the email body using a builder pattern.
    /// </summary>
    /// <param name="action">Action to configure the content.</param>
    /// <returns>The EmailBody object, allowing for method chaining.</returns>
    public EmailBody Add(Action<BasicElement> action) {
        var contentElement = new BasicElement();
        contentElement.Email = _email;
        action(contentElement);
        Children.Add(contentElement);
        return this;
    }

    /// <summary>
    /// Adds an element to the email body.
    /// </summary>
    /// <param name="element">The element to add.</param>
    /// <returns>The EmailBody object, allowing for method chaining.</returns>
    public EmailBody Add(Element? element) {
        if (element is null) {
            return this;
        }

        element.Email = _email;
        Children.Add(element);
        return this;
    }

    /// <summary>
    /// Sets the background color of the email body.
    /// </summary>
    /// <param name="color">The background color.</param>
    /// <returns>The EmailBody object, allowing for method chaining.</returns>
    public EmailBody WithBackground(string color) {
        BackgroundColor = color;
        return this;
    }

    /// <summary>
    /// Sets the background color of the email body.
    /// </summary>
    /// <param name="color">The background color.</param>
    /// <returns>The EmailBody object, allowing for method chaining.</returns>
    public EmailBody WithBackground(RGBColor color) {
        BackgroundColor = color.ToString();
        return this;
    }

    /// <summary>
    /// Sets the CSS class of the email body.
    /// </summary>
    /// <param name="cssClass">The CSS class.</param>
    /// <returns>The EmailBody object, allowing for method chaining.</returns>
    public EmailBody SetCssClass(string cssClass) {
        CssClass = cssClass;
        return this;
    }

    /// <summary>
    /// Converts the EmailBody object to a string that represents the body section of an email document.
    /// </summary>
    /// <returns>A string that represents the body section of an email document.</returns>
    public override string ToString() {
        var body = StringBuilderCache.Acquire();

        // Build inline style for body
        var bodyStyle = $"font-size: 15px; line-height: 160%; mso-line-height-rule: exactly; color: #4b5563; width: 100%; -webkit-font-smoothing: antialiased; -moz-osx-font-smoothing: grayscale; -webkit-font-feature-settings: &quot;cv02&quot;, &quot;cv03&quot;, &quot;cv04&quot;, &quot;cv11&quot;; font-feature-settings: &quot;cv02&quot;, &quot;cv03&quot;, &quot;cv04&quot;, &quot;cv11&quot;; font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif; margin: 0; padding: 0;";

        // Apply dark mode styles if enabled
        var themeClass = _email.Configuration.Email.ThemeMode switch {
            EmailThemeMode.Dark => " theme-dark",
            EmailThemeMode.Auto => " auto-dark-mode",
            _ => ""
        };

        var actualBackgroundColor = GetThemeBackgroundColor();

        body.AppendLine($"<body class=\"{CssClass}{themeClass}\" style=\"{bodyStyle}\" bgcolor=\"{actualBackgroundColor}\">");
        body.AppendLine("<center>");
        body.AppendLine($"<table class=\"main {CssClass}{themeClass}\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" role=\"presentation\" style=\"font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif; border-collapse: collapse; width: 100%; -webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%;\" bgcolor=\"{actualBackgroundColor}\">");
        body.AppendLine("<tr>");
        body.AppendLine("<td align=\"center\" valign=\"top\" style=\"font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif;\">");

        // MSO conditional comments for IE/Outlook
        body.AppendLine("<!--[if (gte mso 9)|(IE)]>");
        body.AppendLine("<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\">");
        body.AppendLine("<tr>");
        body.AppendLine($"<td align=\"center\" valign=\"top\" width=\"{MaxWidth}\">");
        body.AppendLine("<![endif]-->");

        // Preheader text (hidden but appears in email previews)
        if (IncludePreheader && !string.IsNullOrEmpty(PreheaderText)) {
            body.AppendLine($"<span class=\"preheader\" style=\"font-size: 0; display: none; max-height: 0; mso-hide: all; line-height: 0; color: transparent; height: 0; max-width: 0; opacity: 0; overflow: hidden; visibility: hidden; width: 0; padding: 0;\">{Helpers.HtmlEncode(PreheaderText)}</span>");
        }

        // Main content wrapper table
        body.AppendLine($"<table class=\"wrap\" cellspacing=\"0\" cellpadding=\"0\" role=\"presentation\" style=\"font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif; border-collapse: collapse; width: 100%; max-width: {MaxWidth}px; text-align: left;\">");
        body.AppendLine("<tr>");
        body.AppendLine("<td class=\"p-sm\" style=\"font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif; padding: 8px;\">");

        // Render child elements
        foreach (var child in Children.WhereNotNull()) {
            var childContent = child.ToString();
            if (!string.IsNullOrEmpty(childContent)) {
                body.AppendLine(childContent);
            }
        }

        // Close main content wrapper
        body.AppendLine("</td>");
        body.AppendLine("</tr>");
        body.AppendLine("</table>");

        // Close MSO conditional comments
        body.AppendLine("<!--[if (gte mso 9)|(IE)]>");
        body.AppendLine("</td>");
        body.AppendLine("</tr>");
        body.AppendLine("</table>");
        body.AppendLine("<![endif]-->");

        body.AppendLine("</td>");
        body.AppendLine("</tr>");
        body.AppendLine("</table>");
        body.AppendLine("</center>");
        body.AppendLine("</body>");

        return StringBuilderCache.GetStringAndRelease(body);
    }
}