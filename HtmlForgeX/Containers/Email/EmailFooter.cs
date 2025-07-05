namespace HtmlForgeX;

/// <summary>
/// Represents an email footer section with social links, contact information, and unsubscribe options.
/// </summary>
public class EmailFooter : Element {
    /// <summary>
    /// Gets or sets the list of social media links.
    /// </summary>
    public List<EmailSocialLink> SocialLinks { get; set; } = new();

    /// <summary>
    /// Gets or sets the contact email address.
    /// </summary>
    public string ContactEmail { get; set; } = "";

    /// <summary>
    /// Gets or sets the contact message text.
    /// </summary>
    public string ContactMessage { get; set; } = "If you have any questions, feel free to message us at";

    /// <summary>
    /// Gets or sets the unsubscribe link URL.
    /// </summary>
    public string UnsubscribeLink { get; set; } = "";

    /// <summary>
    /// Gets or sets the unsubscribe message text.
    /// </summary>
    public string UnsubscribeMessage { get; set; } = "You are receiving this email because you have bought or downloaded one of our products.";

    /// <summary>
    /// Gets or sets the copyright text.
    /// </summary>
    public string CopyrightText { get; set; } = "";

    /// <summary>
    /// Gets or sets the padding for the footer section.
    /// </summary>
    public string Padding { get; set; } = "48px";

    /// <summary>
    /// Gets or sets whether to include social links.
    /// </summary>
    public bool IncludeSocialLinks { get; set; } = true;

    /// <summary>
    /// Gets or sets whether to include contact information.
    /// </summary>
    public bool IncludeContactInfo { get; set; } = true;

    /// <summary>
    /// Gets or sets whether to include unsubscribe link.
    /// </summary>
    public bool IncludeUnsubscribe { get; set; } = true;

    /// <summary>
    /// Gets or sets whether to include copyright text.
    /// </summary>
    public bool IncludeCopyright { get; set; } = true;

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailFooter"/> class.
    /// </summary>
    public EmailFooter() { }

    /// <summary>
    /// Adds a social media link to the footer.
    /// </summary>
    /// <param name="platform">The social media platform name.</param>
    /// <param name="url">The URL to link to.</param>
    /// <param name="iconSrc">The icon image source.</param>
    /// <returns>The EmailFooter object, allowing for method chaining.</returns>
    public EmailFooter AddSocialLink(string platform, string url, string iconSrc) {
        SocialLinks.Add(new EmailSocialLink {
            Platform = platform,
            Url = url,
            IconSrc = iconSrc
        });
        return this;
    }

    /// <summary>
    /// Sets the contact email information.
    /// </summary>
    /// <param name="email">The contact email address.</param>
    /// <param name="message">The contact message text (optional).</param>
    /// <returns>The EmailFooter object, allowing for method chaining.</returns>
    public EmailFooter SetContactEmail(string email, string message = "") {
        ContactEmail = email;
        if (!string.IsNullOrEmpty(message)) {
            ContactMessage = message;
        }
        return this;
    }

    /// <summary>
    /// Sets the unsubscribe link information.
    /// </summary>
    /// <param name="url">The unsubscribe URL.</param>
    /// <param name="message">The unsubscribe message text (optional).</param>
    /// <returns>The EmailFooter object, allowing for method chaining.</returns>
    public EmailFooter SetUnsubscribeLink(string url, string message = "") {
        UnsubscribeLink = url;
        if (!string.IsNullOrEmpty(message)) {
            UnsubscribeMessage = message;
        }
        return this;
    }

    /// <summary>
    /// Sets the copyright text.
    /// </summary>
    /// <param name="text">The copyright text.</param>
    /// <returns>The EmailFooter object, allowing for method chaining.</returns>
    public EmailFooter SetCopyright(string text) {
        CopyrightText = text;
        return this;
    }

    /// <summary>
    /// Sets the copyright text with current year.
    /// </summary>
    /// <param name="companyName">The company name.</param>
    /// <returns>The EmailFooter object, allowing for method chaining.</returns>
    public EmailFooter SetCopyright(string companyName, int? year = null) {
        var currentYear = year ?? DateTime.Now.Year;
        CopyrightText = $"Copyright © {currentYear} {companyName}. All rights reserved.";
        return this;
    }

    /// <summary>
    /// Converts the EmailFooter to its HTML representation.
    /// </summary>
    /// <returns>HTML string representing the email footer.</returns>
    public override string ToString() {
        var html = StringBuilderCache.Acquire();

        html.AppendLine("<!-- FOOTER -->");
        html.AppendLine("\t\t\t\t\t\t\t\t<table cellspacing=\"0\" cellpadding=\"0\" style=\"font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif; border-collapse: collapse; width: 100%;\">");
        html.AppendLine("\t\t\t\t\t\t\t\t\t<tr>");
        html.AppendLine($"\t\t\t\t\t\t\t\t\t\t<td class=\"py-xl\" style=\"font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif; padding-top: {Padding}; padding-bottom: {Padding};\">");
        
        var themeClass = Email?.Configuration.ThemeMode == EmailThemeMode.Dark ? " color: rgba(255, 255, 255, 0.4) !important;" : "";
        html.AppendLine($"\t\t\t\t\t\t\t\t\t\t\t<table class=\"text-center text-muted\" cellspacing=\"0\" cellpadding=\"0\" style=\"font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif; border-collapse: collapse; width: 100%; color: #667382; text-align: center;{themeClass}\">");

        // Social links section
        if (IncludeSocialLinks && SocialLinks.Count > 0) {
            html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t<tr>");
            html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\t<td align=\"center\" class=\"pb-md\" style=\"font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif; padding-bottom: 16px;\">");
            html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t<table class=\"w-auto\" cellspacing=\"0\" cellpadding=\"0\" style=\"font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif; border-collapse: collapse; width: auto;\">");
            html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<tr>");

            foreach (var socialLink in SocialLinks) {
                html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<td class=\"px-sm\" style=\"font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif; padding-right: 8px; padding-left: 8px;\">");
                html.AppendLine($"\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<a href=\"{Helpers.HtmlEncode(socialLink.Url)}\" style=\"color: #066FD1; text-decoration: none;\">");
                html.AppendLine($"\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<img src=\"{Helpers.HtmlEncode(socialLink.IconSrc)}\" class=\"va-middle\" width=\"24\" height=\"24\" alt=\"{Helpers.HtmlEncode(socialLink.Platform)}\" style=\"display: inline-block; line-height: 100%; outline: none; text-decoration: none; vertical-align: middle; font-size: 0; border-style: none; border-width: 0;\" />");
                html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t</a>");
                html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t</td>");
            }

            html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t</tr>");
            html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t</table>");
            html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\t</td>");
            html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t</tr>");
        }

        // Contact information section
        if (IncludeContactInfo && !string.IsNullOrEmpty(ContactEmail)) {
            html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t<tr>");
            html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\t<td class=\"pt-md\" style=\"font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif; padding-top: 16px;\">");
            html.AppendLine($"\t\t\t\t\t\t\t\t\t\t\t\t\t\t{Helpers.HtmlEncode(ContactMessage)} <a href=\"mailto:{Helpers.HtmlEncode(ContactEmail)}\" style=\"color: #066FD1; text-decoration: none;\">{Helpers.HtmlEncode(ContactEmail)}</a>.");
            html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\t</td>");
            html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t</tr>");
        }

        // Unsubscribe section
        if (IncludeUnsubscribe && !string.IsNullOrEmpty(UnsubscribeLink)) {
            html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t<tr>");
            html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\t<td class=\"pt-md\" style=\"font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif; padding-top: 16px;\">");
            html.AppendLine($"\t\t\t\t\t\t\t\t\t\t\t\t\t\t{Helpers.HtmlEncode(UnsubscribeMessage)} <a href=\"{Helpers.HtmlEncode(UnsubscribeLink)}\" style=\"color: #066FD1; text-decoration: none;\">Unsubscribe</a>");
            html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\t</td>");
            html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t</tr>");
        }

        // Copyright section
        if (IncludeCopyright && !string.IsNullOrEmpty(CopyrightText)) {
            html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t<tr>");
            html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\t<td class=\"pt-md\" style=\"font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif; padding-top: 16px;\">");
            html.AppendLine($"\t\t\t\t\t\t\t\t\t\t\t\t\t\t{Helpers.HtmlEncode(CopyrightText)}");
            html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\t</td>");
            html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t</tr>");
        }

        html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t</table>");
        html.AppendLine("\t\t\t\t\t\t\t\t\t\t</td>");
        html.AppendLine("\t\t\t\t\t\t\t\t\t</tr>");
        html.AppendLine("\t\t\t\t\t\t\t\t</table>");
        html.AppendLine("<!-- /FOOTER -->");

        return StringBuilderCache.GetStringAndRelease(html);
    }
}

/// <summary>
/// Represents a social media link in the email footer.
/// </summary>
public class EmailSocialLink {
    /// <summary>
    /// Gets or sets the platform name (e.g., "Twitter", "GitHub").
    /// </summary>
    public string Platform { get; set; } = "";

    /// <summary>
    /// Gets or sets the URL to link to.
    /// </summary>
    public string Url { get; set; } = "";

    /// <summary>
    /// Gets or sets the icon image source.
    /// </summary>
    public string IconSrc { get; set; } = "";
}