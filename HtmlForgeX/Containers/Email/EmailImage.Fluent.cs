namespace HtmlForgeX;

public partial class EmailImage {
    #region Fluent API

    public EmailImage WithSource(string source, bool? autoEmbed = null) {
        Source = source;
        _originalSource = source;

        if (autoEmbed == true) {
            ForceEmbedding = true;
            SkipAutoEmbedding = false;
        } else if (autoEmbed == false) {
            SkipAutoEmbedding = true;
            ForceEmbedding = false;
        }

        ApplyDocumentConfiguration();
        return this;
    }

    public EmailImage WithSource(string source) => WithSource(source, null);

    public EmailImage WithWidth(string width) {
        Width = width;
        return this;
    }

    public EmailImage WithHeight(string height) {
        Height = height;
        return this;
    }

    public EmailImage WithAlternativeText(string altText) {
        AlternativeText = altText;
        return this;
    }

    public EmailImage WithAlignment(Alignment alignment) {
        alignment.ValidateEmailAlignment();
        Alignment = alignment.ToCssValue();
        return this;
    }

    public EmailImage WithMargin(string margin) {
        margin.ValidateMargin();
        Margin = margin;
        return this;
    }

    public EmailImage WithBorder(string border) {
        Border = border;
        return this;
    }

    public EmailImage WithBorderRadius(string borderRadius) {
        BorderRadius = borderRadius;
        return this;
    }

    public EmailImage WithLink(string url, bool openInNewWindow = false) {
        LinkUrl = url;
        OpenInNewWindow = openInNewWindow;
        return this;
    }

    public EmailImage WithCssClass(string cssClass) {
        CssClass = cssClass;
        return this;
    }

    public EmailImage WithoutAutoEmbedding() {
        SkipAutoEmbedding = true;
        ForceEmbedding = false;

        if (EmbedAsBase64 && !string.IsNullOrEmpty(_originalSource)) {
            EmbedAsBase64 = false;
            Base64Data = string.Empty;
            MimeType = string.Empty;
            Source = _originalSource;
        }

        return this;
    }

    public EmailImage WithAutoEmbedding() {
        ForceEmbedding = true;
        SkipAutoEmbedding = false;
        if (!EmbedAsBase64 && !string.IsNullOrEmpty(Source)) {
            ApplyDocumentConfiguration();
        }
        return this;
    }

    public EmailImage WithOptimization(int maxWidth = 0, int maxHeight = 0, int quality = 85) {
        OptimizeImage = true;
        MaxWidth = maxWidth;
        MaxHeight = maxHeight;
        Quality = Math.Max(0, Math.Min(100, quality));
        return this;
    }

    public EmailImage WithoutOptimization() {
        OptimizeImage = false;
        return this;
    }

    public EmailImage WithDarkModeSource(string darkSource, string darkAltText = "") {
        DarkModeSource = darkSource;
        DarkModeAlternativeText = string.IsNullOrEmpty(darkAltText) ? AlternativeText : darkAltText;
        EnableDarkModeSwapping = true;
        return this;
    }

    public EmailImage WithImagePair(string lightSource, string darkSource, string altText = "") {
        Source = lightSource;
        DarkModeSource = darkSource;
        AlternativeText = altText;
        DarkModeAlternativeText = altText;
        EnableDarkModeSwapping = true;
        return this;
    }

    public EmailImage WithSeparateAltTexts(string lightAltText, string darkAltText) {
        AlternativeText = lightAltText;
        DarkModeAlternativeText = darkAltText;
        return this;
    }

    public EmailImage WithoutDarkModeSwapping() {
        EnableDarkModeSwapping = false;
        DarkModeSource = string.Empty;
        return this;
    }

    public EmailImage WithDarkModeSwapping() {
        EnableDarkModeSwapping = true;
        return this;
    }

    public EmailImage WithMargin(EmailSpacing spacing) {
        Margin = spacing.ToCssValue();
        return this;
    }

    public EmailImage WithMargin(EmailSpacing vertical, EmailSpacing horizontal) {
        Margin = $"{vertical.ToCssValue()} {horizontal.ToCssValue()}";
        return this;
    }

    public EmailImage WithMargin(EmailSpacing top, EmailSpacing right, EmailSpacing bottom, EmailSpacing left) {
        Margin = $"{top.ToCssValue()} {right.ToCssValue()} {bottom.ToCssValue()} {left.ToCssValue()}";
        return this;
    }

    #endregion
}