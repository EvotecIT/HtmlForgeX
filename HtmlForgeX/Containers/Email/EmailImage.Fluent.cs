namespace HtmlForgeX;

public partial class EmailImage {
    #region Fluent API

    /// <summary>
    /// Sets the image source and optionally controls auto embedding.
    /// </summary>
    /// <param name="source">Image source path.</param>
    /// <param name="autoEmbed">Force or disable embedding.</param>
    /// <returns>The current <see cref="EmailImage"/> instance.</returns>
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

    /// <summary>
    /// Sets the image source using default embedding behavior.
    /// </summary>
    /// <param name="source">Image source path.</param>
    /// <returns>The current <see cref="EmailImage"/> instance.</returns>
    public EmailImage WithSource(string source) => WithSource(source, null);

    /// <summary>
    /// Sets the image width.
    /// </summary>
    /// <param name="width">Width value.</param>
    /// <returns>The current <see cref="EmailImage"/> instance.</returns>
    public EmailImage WithWidth(string width) {
        Width = width;
        return this;
    }

    /// <summary>
    /// Sets the image height.
    /// </summary>
    /// <param name="height">Height value.</param>
    /// <returns>The current <see cref="EmailImage"/> instance.</returns>
    public EmailImage WithHeight(string height) {
        Height = height;
        return this;
    }

    /// <summary>
    /// Sets the alternative text for the image.
    /// </summary>
    /// <param name="altText">Alternative text.</param>
    /// <returns>The current <see cref="EmailImage"/> instance.</returns>
    public EmailImage WithAlternativeText(string altText) {
        AlternativeText = altText;
        return this;
    }

    /// <summary>
    /// Sets the alignment of the image.
    /// </summary>
    /// <param name="alignment">Alignment value.</param>
    /// <returns>The current <see cref="EmailImage"/> instance.</returns>
    public EmailImage WithAlignment(Alignment alignment) {
        alignment.ValidateEmailAlignment();
        Alignment = alignment.ToCssValue();
        return this;
    }

    /// <summary>
    /// Sets margin using a CSS string.
    /// </summary>
    /// <param name="margin">CSS margin value.</param>
    /// <returns>The current <see cref="EmailImage"/> instance.</returns>
    public EmailImage WithMargin(string margin) {
        margin.ValidateMargin();
        Margin = margin;
        return this;
    }

    /// <summary>
    /// Sets the CSS border of the image.
    /// </summary>
    /// <param name="border">Border value.</param>
    /// <returns>The current <see cref="EmailImage"/> instance.</returns>
    public EmailImage WithBorder(string border) {
        Border = border;
        return this;
    }

    /// <summary>
    /// Sets the CSS border radius of the image.
    /// </summary>
    /// <param name="borderRadius">Radius value.</param>
    /// <returns>The current <see cref="EmailImage"/> instance.</returns>
    public EmailImage WithBorderRadius(string borderRadius) {
        BorderRadius = borderRadius;
        return this;
    }

    /// <summary>
    /// Adds a hyperlink around the image.
    /// </summary>
    /// <param name="url">Target URL.</param>
    /// <param name="openInNewWindow">Open in a new window if true.</param>
    /// <returns>The current <see cref="EmailImage"/> instance.</returns>
    public EmailImage WithLink(string url, bool openInNewWindow = false) {
        LinkUrl = url;
        OpenInNewWindow = openInNewWindow;
        return this;
    }

    /// <summary>
    /// Sets the CSS class of the image container.
    /// </summary>
    /// <param name="cssClass">Class name.</param>
    /// <returns>The current <see cref="EmailImage"/> instance.</returns>
    public EmailImage WithCssClass(string cssClass) {
        CssClass = cssClass;
        return this;
    }

    /// <summary>
    /// Disables automatic image embedding.
    /// </summary>
    /// <returns>The current <see cref="EmailImage"/> instance.</returns>
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

    /// <summary>
    /// Forces automatic image embedding.
    /// </summary>
    /// <returns>The current <see cref="EmailImage"/> instance.</returns>
    public EmailImage WithAutoEmbedding() {
        ForceEmbedding = true;
        SkipAutoEmbedding = false;
        if (!EmbedAsBase64 && !string.IsNullOrEmpty(Source)) {
            ApplyDocumentConfiguration();
        }
        return this;
    }

    /// <summary>
    /// Enables optimization of embedded images.
    /// </summary>
    /// <param name="maxWidth">Maximum width.</param>
    /// <param name="maxHeight">Maximum height.</param>
    /// <param name="quality">Quality percentage.</param>
    /// <returns>The current <see cref="EmailImage"/> instance.</returns>
    public EmailImage WithOptimization(int maxWidth = 0, int maxHeight = 0, int quality = 85) {
        OptimizeImage = true;
        MaxWidth = maxWidth;
        MaxHeight = maxHeight;
        Quality = Math.Max(0, Math.Min(100, quality));
        return this;
    }

    /// <summary>
    /// Disables image optimization.
    /// </summary>
    /// <returns>The current <see cref="EmailImage"/> instance.</returns>
    public EmailImage WithoutOptimization() {
        OptimizeImage = false;
        return this;
    }

    /// <summary>
    /// Specifies an alternative image for dark mode.
    /// </summary>
    /// <param name="darkSource">Dark mode image source.</param>
    /// <param name="darkAltText">Alternative text for dark mode.</param>
    /// <returns>The current <see cref="EmailImage"/> instance.</returns>
    public EmailImage WithDarkModeSource(string darkSource, string darkAltText = "") {
        DarkModeSource = darkSource;
        DarkModeAlternativeText = string.IsNullOrEmpty(darkAltText) ? AlternativeText : darkAltText;
        EnableDarkModeSwapping = true;
        return this;
    }

    /// <summary>
    /// Sets both light and dark mode images.
    /// </summary>
    /// <param name="lightSource">Light mode image.</param>
    /// <param name="darkSource">Dark mode image.</param>
    /// <param name="altText">Alternative text.</param>
    /// <returns>The current <see cref="EmailImage"/> instance.</returns>
    public EmailImage WithImagePair(string lightSource, string darkSource, string altText = "") {
        Source = lightSource;
        DarkModeSource = darkSource;
        AlternativeText = altText;
        DarkModeAlternativeText = altText;
        EnableDarkModeSwapping = true;
        return this;
    }

    /// <summary>
    /// Sets separate alternative texts for light and dark mode images.
    /// </summary>
    /// <param name="lightAltText">Alt text for light mode.</param>
    /// <param name="darkAltText">Alt text for dark mode.</param>
    /// <returns>The current <see cref="EmailImage"/> instance.</returns>
    public EmailImage WithSeparateAltTexts(string lightAltText, string darkAltText) {
        AlternativeText = lightAltText;
        DarkModeAlternativeText = darkAltText;
        return this;
    }

    /// <summary>
    /// Disables dark mode image swapping.
    /// </summary>
    /// <returns>The current <see cref="EmailImage"/> instance.</returns>
    public EmailImage WithoutDarkModeSwapping() {
        EnableDarkModeSwapping = false;
        DarkModeSource = string.Empty;
        return this;
    }

    /// <summary>
    /// Enables dark mode image swapping.
    /// </summary>
    /// <returns>The current <see cref="EmailImage"/> instance.</returns>
    public EmailImage WithDarkModeSwapping() {
        EnableDarkModeSwapping = true;
        return this;
    }

    /// <summary>
    /// Sets margin using predefined spacing values.
    /// </summary>
    /// <param name="spacing">Spacing value.</param>
    /// <returns>The current <see cref="EmailImage"/> instance.</returns>
    public EmailImage WithMargin(EmailSpacing spacing) {
        Margin = spacing.ToCssValue();
        return this;
    }

    /// <summary>
    /// Sets vertical and horizontal margins.
    /// </summary>
    /// <param name="vertical">Vertical spacing.</param>
    /// <param name="horizontal">Horizontal spacing.</param>
    /// <returns>The current <see cref="EmailImage"/> instance.</returns>
    public EmailImage WithMargin(EmailSpacing vertical, EmailSpacing horizontal) {
        Margin = $"{vertical.ToCssValue()} {horizontal.ToCssValue()}";
        return this;
    }

    /// <summary>
    /// Sets individual margins for each side.
    /// </summary>
    /// <param name="top">Top spacing.</param>
    /// <param name="right">Right spacing.</param>
    /// <param name="bottom">Bottom spacing.</param>
    /// <param name="left">Left spacing.</param>
    /// <returns>The current <see cref="EmailImage"/> instance.</returns>
    public EmailImage WithMargin(EmailSpacing top, EmailSpacing right, EmailSpacing bottom, EmailSpacing left) {
        Margin = $"{top.ToCssValue()} {right.ToCssValue()} {bottom.ToCssValue()} {left.ToCssValue()}";
        return this;
    }

    #endregion
}