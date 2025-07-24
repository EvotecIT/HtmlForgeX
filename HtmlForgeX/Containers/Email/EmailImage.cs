namespace HtmlForgeX;

/// <summary>
/// Represents an image element for email layouts with email-safe styling and attributes.
/// Provides image display with customizable dimensions and optional embedding.
/// </summary>
public partial class EmailImage : Element {
    public EmailImage() {
        // Configuration will be applied when the image is added to a document
    }

    public EmailImage(string source) : this() {
        Source = source;
        _originalSource = source;
    }

    public EmailImage(string source, string width, string height = "") : this() {
        Source = source;
        _originalSource = source;
        Width = width;
        Height = height;
    }

    public EmailImage(string source, string width, string height, bool autoEmbed) : this() {
        Source = source;
        _originalSource = source;
        Width = width;
        Height = height;

        if (autoEmbed) {
            ForceEmbedding = true;
        } else {
            SkipAutoEmbedding = true;
        }
    }

    internal void ApplyDocumentConfiguration() {
        if (Email?.Configuration == null) {
            return;
        }

        var emailConfig = Email.Configuration.Email;
        var imageConfig = Email.Configuration.Images;

        if (imageConfig.AutoOptimize && !OptimizeImage) {
            WithOptimization(imageConfig.MaxWidth, imageConfig.MaxHeight, imageConfig.Quality);
        }

        if (emailConfig.AutoEmbedImages && !SkipAutoEmbedding && !EmbedAsBase64 && !string.IsNullOrEmpty(Source)) {
            if (emailConfig.SmartImageDetection) {
                EmbedSmart(Source, emailConfig.EmbeddingTimeout);
            } else {
                EmbedFromFile(Source);
            }
        } else if (ForceEmbedding && !EmbedAsBase64 && !string.IsNullOrEmpty(Source)) {
            if (emailConfig.SmartImageDetection) {
                EmbedSmart(Source, emailConfig.EmbeddingTimeout);
            } else {
                EmbedFromFile(Source);
            }
        }

        if (!string.IsNullOrEmpty(DarkModeSource) && EnableDarkModeSwapping) {
            if (emailConfig.AutoEmbedImages && !SkipAutoEmbedding && !DarkModeEmbedAsBase64) {
                EmbedDarkModeImage(DarkModeSource, emailConfig.EmbeddingTimeout, emailConfig.SmartImageDetection);
            } else if (ForceEmbedding && !DarkModeEmbedAsBase64) {
                EmbedDarkModeImage(DarkModeSource, emailConfig.EmbeddingTimeout, emailConfig.SmartImageDetection);
            }
        }
    }

    protected internal override void OnAddedToDocument() {
        base.OnAddedToDocument();
        ApplyDocumentConfiguration();
    }

    public override string ToString() {
        if (EmbedAsBase64 && string.IsNullOrWhiteSpace(MimeType)) {
            throw new InvalidOperationException("EmbedAsBase64 is enabled but MimeType is not specified.");
        }

        var html = StringBuilderCache.Acquire();

        var imgAttributes = new List<string> { $"src=\"{Helpers.HtmlEncode(Source)}\"" };
        if (!string.IsNullOrEmpty(Width)) {
            imgAttributes.Add($"width=\"{Width}\"");
        }
        if (!string.IsNullOrEmpty(Height)) {
            imgAttributes.Add($"height=\"{Height}\"");
        }
        if (!string.IsNullOrEmpty(AlternativeText)) {
            imgAttributes.Add($"alt=\"{Helpers.HtmlEncode(AlternativeText)}\"");
        }

        var imgStyle = new List<string>
        {
            "display: inline-block",
            "line-height: 100%",
            "outline: none",
            "text-decoration: none",
            "vertical-align: bottom",
            "font-size: 0",
            "border-style: none",
            "border-width: 0"
        };

        if (!string.IsNullOrEmpty(Border) && Border != "none") {
            imgStyle.Add($"border: {Border}");
        }
        if (!string.IsNullOrEmpty(BorderRadius) && BorderRadius != "0") {
            imgStyle.Add($"border-radius: {BorderRadius}");
        }

        var cssClass = CssClass;
        if (EnableDarkModeSwapping && !string.IsNullOrEmpty(DarkModeSource)) {
            cssClass += " light-img";
        }

        if (IsInEmailColumn()) {
            html.AppendLine($"<div class=\"{cssClass}\" style=\"margin: {Margin}; padding: {Padding}; text-align: {Alignment};\">");
            var imgStyleAttr = $" style=\"{string.Join("; ", imgStyle)}\"";
            var imgTag = $"<img {string.Join(" ", imgAttributes)}{imgStyleAttr} />";

            if (!string.IsNullOrEmpty(LinkUrl)) {
                var target = OpenInNewWindow ? " target=\"_blank\"" : string.Empty;
                html.AppendLine($"<a href=\"{Helpers.HtmlEncode(LinkUrl)}\"{target} style=\"color: #066FD1; text-decoration: none;\">{imgTag}</a>");
            } else {
                html.AppendLine(imgTag);
            }

            if (EnableDarkModeSwapping && !string.IsNullOrEmpty(DarkModeSource)) {
                var darkImgAttributes = new List<string> { $"src=\"{Helpers.HtmlEncode(DarkModeSource)}\"" };
                if (!string.IsNullOrEmpty(Width)) darkImgAttributes.Add($"width=\"{Width}\"");
                if (!string.IsNullOrEmpty(Height)) darkImgAttributes.Add($"height=\"{Height}\"");
                var darkAltText = !string.IsNullOrEmpty(DarkModeAlternativeText) ? DarkModeAlternativeText : AlternativeText;
                if (!string.IsNullOrEmpty(darkAltText)) darkImgAttributes.Add($"alt=\"{Helpers.HtmlEncode(darkAltText)}\"");
                var darkImgStyle = new List<string>(imgStyle) { "display: none" };
                darkImgAttributes.Add($"class=\"{CssClass} dark-img\"");
                var darkImgStyleAttr = $" style=\"{string.Join("; ", darkImgStyle)}\"";

                html.AppendLine($"<!--[if !mso]><!-->");
                html.AppendLine($"<div class=\"dark-img\" style=\"display: none; overflow: hidden; float: left; width: 0px; max-height: 0px; max-width: 0px; line-height: 0px; visibility: hidden;\" align=\"{Alignment}\">");

                if (!string.IsNullOrEmpty(LinkUrl)) {
                    var target = OpenInNewWindow ? " target=\"_blank\"" : string.Empty;
                    html.AppendLine($"<a href=\"{Helpers.HtmlEncode(LinkUrl)}\"{target} style=\"color: #066FD1; text-decoration: none;\">");
                    html.AppendLine($"<img {string.Join(" ", darkImgAttributes)}{darkImgStyleAttr} />");
                    html.AppendLine("</a>");
                } else {
                    html.AppendLine($"<img {string.Join(" ", darkImgAttributes)}{darkImgStyleAttr} />");
                }

                html.AppendLine("</div>");
                html.AppendLine("<!--<![endif]-->");
            }

            html.AppendLine("</div>");
        } else {
            html.AppendLine("<tr>");
            html.AppendLine($"<td style=\"margin: {Margin}; padding: {Padding}; text-align: {Alignment}; font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif;\">");

            var imgStyleAttr = $" style=\"{string.Join("; ", imgStyle)}\"";
            if (!string.IsNullOrEmpty(LinkUrl)) {
                var target = OpenInNewWindow ? " target=\"_blank\"" : string.Empty;
                html.AppendLine($"<a href=\"{Helpers.HtmlEncode(LinkUrl)}\"{target} style=\"color: #066FD1; text-decoration: none;\">");
                html.AppendLine($"<img {string.Join(" ", imgAttributes)}{imgStyleAttr} />");
                html.AppendLine("</a>");
            } else {
                html.AppendLine($"<img {string.Join(" ", imgAttributes)}{imgStyleAttr} />");
            }

            if (EnableDarkModeSwapping && !string.IsNullOrEmpty(DarkModeSource)) {
                var darkImgAttributes = new List<string> { $"src=\"{Helpers.HtmlEncode(DarkModeSource)}\"" };
                if (!string.IsNullOrEmpty(Width)) darkImgAttributes.Add($"width=\"{Width}\"");
                if (!string.IsNullOrEmpty(Height)) darkImgAttributes.Add($"height=\"{Height}\"");
                var darkAltText = !string.IsNullOrEmpty(DarkModeAlternativeText) ? DarkModeAlternativeText : AlternativeText;
                if (!string.IsNullOrEmpty(darkAltText)) darkImgAttributes.Add($"alt=\"{Helpers.HtmlEncode(darkAltText)}\"");
                var darkImgStyle = new List<string>(imgStyle) { "display: none" };
                darkImgAttributes.Add($"class=\"{CssClass} dark-img\"");
                var darkImgStyleAttr = $" style=\"{string.Join("; ", darkImgStyle)}\"";

                html.AppendLine($"<!--[if !mso]><!-->");
                html.AppendLine($"<div class=\"dark-img\" style=\"display: none; overflow: hidden; float: left; width: 0px; max-height: 0px; max-width: 0px; line-height: 0px; visibility: hidden;\" align=\"{Alignment}\">");

                if (!string.IsNullOrEmpty(LinkUrl)) {
                    var target = OpenInNewWindow ? " target=\"_blank\"" : string.Empty;
                    html.AppendLine($"<a href=\"{Helpers.HtmlEncode(LinkUrl)}\"{target} style=\"color: #066FD1; text-decoration: none;\">");
                    html.AppendLine($"<img {string.Join(" ", darkImgAttributes)}{darkImgStyleAttr} />");
                    html.AppendLine("</a>");
                } else {
                    html.AppendLine($"<img {string.Join(" ", darkImgAttributes)}{darkImgStyleAttr} />");
                }

                html.AppendLine("</div>");
                html.AppendLine("<!--<![endif]-->");
            }

            html.AppendLine("</td>");
            html.AppendLine("</tr>");
        }

        return StringBuilderCache.GetStringAndRelease(html);
    }

    private bool IsInEmailColumn() => ParentColumn != null;
}