namespace HtmlForgeX;

/// <summary>
/// Represents an email header section with logo and view online link.
/// </summary>
public class EmailHeader : Element {
    /// <summary>
    /// Gets or sets the logo image source.
    /// </summary>
    public string LogoSrc { get; set; } = "./assets/sample-logo.png";

    /// <summary>
    /// Gets or sets the dark mode logo image source.
    /// </summary>
    public string LogoDarkSrc { get; set; } = "./assets/sample-logo-white.png";

    /// <summary>
    /// Gets or sets the logo width.
    /// </summary>
    public int LogoWidth { get; set; } = 114;

    /// <summary>
    /// Gets or sets the logo height.
    /// </summary>
    public int LogoHeight { get; set; } = 32;

    /// <summary>
    /// Gets or sets the logo alt text.
    /// </summary>
    public string LogoAlt { get; set; } = "";

    /// <summary>
    /// Gets or sets the logo link URL.
    /// </summary>
    public string LogoLink { get; set; } = "";

    /// <summary>
    /// Gets or sets the "View online" link URL.
    /// </summary>
    public string ViewOnlineLink { get; set; } = "";

    /// <summary>
    /// Gets or sets the "View online" link text.
    /// </summary>
    public string ViewOnlineText { get; set; } = "View online";

    /// <summary>
    /// Gets or sets whether to include the "View online" link.
    /// </summary>
    public bool IncludeViewOnline { get; set; } = true;

    /// <summary>
    /// Gets or sets the padding for the header section.
    /// </summary>
    public string Padding { get; set; } = "24px";

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailHeader"/> class.
    /// </summary>
    public EmailHeader() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailHeader"/> class with custom settings.
    /// </summary>
    /// <param name="logoSrc">The logo image source.</param>
    /// <param name="logoLink">The logo link URL.</param>
    public EmailHeader(string logoSrc, string logoLink = "") {
        LogoSrc = logoSrc;
        LogoLink = logoLink;
    }

    /// <summary>
    /// Sets the logo image source.
    /// </summary>
    /// <param name="src">The image source URL.</param>
    /// <param name="darkSrc">The dark mode image source URL (optional).</param>
    /// <returns>The EmailHeader object, allowing for method chaining.</returns>
    public EmailHeader SetLogo(string src, string darkSrc = "") {
        LogoSrc = src;
        if (!string.IsNullOrEmpty(darkSrc)) {
            LogoDarkSrc = darkSrc;
        }
        return this;
    }

    /// <summary>
    /// Sets the logo dimensions.
    /// </summary>
    /// <param name="width">The logo width in pixels.</param>
    /// <param name="height">The logo height in pixels.</param>
    /// <returns>The EmailHeader object, allowing for method chaining.</returns>
    public EmailHeader SetLogoDimensions(int width, int height) {
        LogoWidth = width;
        LogoHeight = height;
        return this;
    }

    /// <summary>
    /// Sets the logo link URL.
    /// </summary>
    /// <param name="url">The URL to link to when logo is clicked.</param>
    /// <returns>The EmailHeader object, allowing for method chaining.</returns>
    public EmailHeader SetLogoLink(string url) {
        LogoLink = url;
        return this;
    }

    /// <summary>
    /// Sets the "View online" link.
    /// </summary>
    /// <param name="url">The URL for the online version.</param>
    /// <param name="text">The link text (optional).</param>
    /// <returns>The EmailHeader object, allowing for method chaining.</returns>
    public EmailHeader SetViewOnlineLink(string url, string text = "View online") {
        ViewOnlineLink = url;
        ViewOnlineText = text;
        IncludeViewOnline = true;
        return this;
    }

    /// <summary>
    /// Hides the "View online" link.
    /// </summary>
    /// <returns>The EmailHeader object, allowing for method chaining.</returns>
    public EmailHeader HideViewOnline() {
        IncludeViewOnline = false;
        return this;
    }

    /// <summary>
    /// Converts the EmailHeader to its HTML representation.
    /// </summary>
    /// <returns>HTML string representing the email header.</returns>
    public override string ToString() {
        var html = StringBuilderCache.Acquire();

        html.AppendLine("<!-- HEADER -->");
        html.AppendLine("\t\t\t\t\t\t\t\t<table cellpadding=\"0\" cellspacing=\"0\" style=\"font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif; border-collapse: collapse; width: 100%;\">");
        html.AppendLine("\t\t\t\t\t\t\t\t\t<tr>");
        html.AppendLine($"\t\t\t\t\t\t\t\t\t\t<td class=\"py-lg\" style=\"font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif; padding-top: {Padding}; padding-bottom: {Padding};\">");
        html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t<table cellspacing=\"0\" cellpadding=\"0\" style=\"font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif; border-collapse: collapse; width: 100%;\">");
        html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t<tr>");
        html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\t<td style=\"font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif;\">");

        // Logo section
        if (!string.IsNullOrEmpty(LogoSrc)) {
            if (!string.IsNullOrEmpty(LogoLink)) {
                html.AppendLine($"\t\t\t\t\t\t\t\t\t\t\t\t\t\t<a href=\"{Helpers.HtmlEncode(LogoLink)}\" style=\"color: #066FD1; text-decoration: none;\">");
            }

            // Light mode logo
            html.AppendLine($"\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<img src=\"{Helpers.HtmlEncode(LogoSrc)}\" class=\"img-light\" width=\"{LogoWidth}\" height=\"{LogoHeight}\" alt=\"{Helpers.HtmlEncode(LogoAlt)}\" style=\"display: inline-block; line-height: 100%; outline: none; text-decoration: none; vertical-align: bottom; font-size: 0; border-style: none; border-width: 0;\" />");

            // Dark mode logo (conditionally rendered)
            if (!string.IsNullOrEmpty(LogoDarkSrc) && Email?.Configuration.DarkModeSupport == true) {
                html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<!--[if !mso]> <!-->");
                html.AppendLine($"\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<img src=\"{Helpers.HtmlEncode(LogoDarkSrc)}\" class=\"img-dark\" width=\"{LogoWidth}\" height=\"{LogoHeight}\" alt=\"{Helpers.HtmlEncode(LogoAlt)}\" style=\"display: none; line-height: 100%; outline: none; text-decoration: none; vertical-align: bottom; font-size: 0; border-style: none; border-width: 0;\" />");
                html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<!-- <![endif]-->");
            }

            if (!string.IsNullOrEmpty(LogoLink)) {
                html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t</a>");
            }
        }

        html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\t</td>");

        // View online link section
        if (IncludeViewOnline && !string.IsNullOrEmpty(ViewOnlineLink)) {
            html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\t<td class=\"text-right\" style=\"font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif;\" align=\"right\">");
            html.AppendLine($"\t\t\t\t\t\t\t\t\t\t\t\t\t\t<a href=\"{Helpers.HtmlEncode(ViewOnlineLink)}\" class=\"text-muted-light\" style=\"color: #8491a1; text-decoration: none;\">");
            html.AppendLine($"\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t{Helpers.HtmlEncode(ViewOnlineText)}");
            html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t</a>");
            html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\t</td>");
        }

        html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t</tr>");
        html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t</table>");
        html.AppendLine("\t\t\t\t\t\t\t\t\t\t</td>");
        html.AppendLine("\t\t\t\t\t\t\t\t\t</tr>");
        html.AppendLine("\t\t\t\t\t\t\t\t</table>");
        html.AppendLine("<!-- /HEADER -->");

        return StringBuilderCache.GetStringAndRelease(html);
    }
}