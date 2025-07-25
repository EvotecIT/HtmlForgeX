namespace HtmlForgeX;

public partial class EmailImage {
    #region Fluent API

    /// <summary>
    /// Sets the image source with optional auto-embedding control
    /// </summary>
    /// <param name="source">The image source URL or path</param>
    /// <param name="autoEmbed">Whether to automatically embed the image (null uses default settings)</param>
    /// <returns>The EmailImage instance for method chaining</returns>
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
    /// Sets the image source
    /// </summary>
    /// <param name="source">The image source URL or path</param>
    /// <returns>The EmailImage instance for method chaining</returns>
    public EmailImage WithSource(string source) => WithSource(source, null);

    /// <summary>
    /// Sets the image width
    /// </summary>
    /// <param name="width">The width value (e.g., "300px", "100%")</param>
    /// <returns>The EmailImage instance for method chaining</returns>
    public EmailImage WithWidth(string width) {
        Width = width;
        return this;
    }

    /// <summary>
    /// Sets the image height
    /// </summary>
    /// <param name="height">The height value (e.g., "200px", "auto")</param>
    /// <returns>The EmailImage instance for method chaining</returns>
    public EmailImage WithHeight(string height) {
        Height = height;
        return this;
    }

    /// <summary>
    /// Sets the alternative text for accessibility
    /// </summary>
    /// <param name="altText">The alternative text</param>
    /// <returns>The EmailImage instance for method chaining</returns>
    public EmailImage WithAlternativeText(string altText) {
        AlternativeText = altText;
        return this;
    }

    /// <summary>
    /// Sets the image alignment
    /// </summary>
    /// <param name="alignment">The alignment option</param>
    /// <returns>The EmailImage instance for method chaining</returns>
    public EmailImage WithAlignment(Alignment alignment) {
        alignment.ValidateEmailAlignment();
        Alignment = alignment.ToCssValue();
        return this;
    }

    /// <summary>
    /// Sets the image margin
    /// </summary>
    /// <param name="margin">The margin value (e.g., "10px", "10px 20px")</param>
    /// <returns>The EmailImage instance for method chaining</returns>
    public EmailImage WithMargin(string margin) {
        margin.ValidateMargin();
        Margin = margin;
        return this;
    }

    /// <summary>
    /// Sets the image border
    /// </summary>
    /// <param name="border">The border CSS value</param>
    /// <returns>The EmailImage instance for method chaining</returns>
    public EmailImage WithBorder(string border) {
        Border = border;
        return this;
    }

    /// <summary>
    /// Sets the image border radius
    /// </summary>
    /// <param name="borderRadius">The border radius value</param>
    /// <returns>The EmailImage instance for method chaining</returns>
    public EmailImage WithBorderRadius(string borderRadius) {
        BorderRadius = borderRadius;
        return this;
    }

    /// <summary>
    /// Wraps the image in a hyperlink
    /// </summary>
    /// <param name="url">The URL to link to</param>
    /// <param name="openInNewWindow">Whether to open the link in a new window</param>
    /// <returns>The EmailImage instance for method chaining</returns>
    public EmailImage WithLink(string url, bool openInNewWindow = false) {
        LinkUrl = url;
        OpenInNewWindow = openInNewWindow;
        return this;
    }

    /// <summary>
    /// Sets a custom CSS class for the image
    /// </summary>
    /// <param name="cssClass">The CSS class name</param>
    /// <returns>The EmailImage instance for method chaining</returns>
    public EmailImage WithCssClass(string cssClass) {
        CssClass = cssClass;
        return this;
    }

    /// <summary>
    /// Disables automatic image embedding
    /// </summary>
    /// <returns>The EmailImage instance for method chaining</returns>
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
    /// Enables automatic image embedding
    /// </summary>
    /// <returns>The EmailImage instance for method chaining</returns>
    public EmailImage WithAutoEmbedding() {
        ForceEmbedding = true;
        SkipAutoEmbedding = false;
        if (!EmbedAsBase64 && !string.IsNullOrEmpty(Source)) {
            ApplyDocumentConfiguration();
        }
        return this;
    }

    /// <summary>
    /// Enables image optimization with specified parameters
    /// </summary>
    /// <param name="maxWidth">Maximum width (0 for no limit)</param>
    /// <param name="maxHeight">Maximum height (0 for no limit)</param>
    /// <param name="quality">Image quality (0-100)</param>
    /// <returns>The EmailImage instance for method chaining</returns>
    public EmailImage WithOptimization(int maxWidth = 0, int maxHeight = 0, int quality = 85) {
        OptimizeImage = true;
        MaxWidth = maxWidth;
        MaxHeight = maxHeight;
        Quality = Math.Max(0, Math.Min(100, quality));
        return this;
    }

    /// <summary>
    /// Disables image optimization
    /// </summary>
    /// <returns>The EmailImage instance for method chaining</returns>
    public EmailImage WithoutOptimization() {
        OptimizeImage = false;
        return this;
    }

    /// <summary>
    /// Sets an alternative image source for dark mode
    /// </summary>
    /// <param name="darkSource">The dark mode image source</param>
    /// <param name="darkAltText">Alternative text for dark mode image</param>
    /// <returns>The EmailImage instance for method chaining</returns>
    public EmailImage WithDarkModeSource(string darkSource, string darkAltText = "") {
        DarkModeSource = darkSource;
        DarkModeAlternativeText = string.IsNullOrEmpty(darkAltText) ? AlternativeText : darkAltText;
        EnableDarkModeSwapping = true;
        return this;
    }

    /// <summary>
    /// Sets both light and dark mode image sources
    /// </summary>
    /// <param name="lightSource">The light mode image source</param>
    /// <param name="darkSource">The dark mode image source</param>
    /// <param name="altText">Alternative text for both images</param>
    /// <returns>The EmailImage instance for method chaining</returns>
    public EmailImage WithImagePair(string lightSource, string darkSource, string altText = "") {
        Source = lightSource;
        DarkModeSource = darkSource;
        AlternativeText = altText;
        DarkModeAlternativeText = altText;
        EnableDarkModeSwapping = true;
        return this;
    }

    /// <summary>
    /// Sets different alternative texts for light and dark mode images
    /// </summary>
    /// <param name="lightAltText">Alternative text for light mode image</param>
    /// <param name="darkAltText">Alternative text for dark mode image</param>
    /// <returns>The EmailImage instance for method chaining</returns>
    public EmailImage WithSeparateAltTexts(string lightAltText, string darkAltText) {
        AlternativeText = lightAltText;
        DarkModeAlternativeText = darkAltText;
        return this;
    }

    /// <summary>
    /// Disables dark mode image swapping
    /// </summary>
    /// <returns>The EmailImage instance for method chaining</returns>
    public EmailImage WithoutDarkModeSwapping() {
        EnableDarkModeSwapping = false;
        DarkModeSource = string.Empty;
        return this;
    }

    /// <summary>
    /// Enables dark mode image swapping
    /// </summary>
    /// <returns>The EmailImage instance for method chaining</returns>
    public EmailImage WithDarkModeSwapping() {
        EnableDarkModeSwapping = true;
        return this;
    }

    /// <summary>
    /// Sets uniform margin using EmailSpacing
    /// </summary>
    /// <param name="spacing">The spacing value</param>
    /// <returns>The EmailImage instance for method chaining</returns>
    public EmailImage WithMargin(EmailSpacing spacing) {
        Margin = spacing.ToCssValue();
        return this;
    }

    /// <summary>
    /// Sets vertical and horizontal margins using EmailSpacing
    /// </summary>
    /// <param name="vertical">The vertical spacing</param>
    /// <param name="horizontal">The horizontal spacing</param>
    /// <returns>The EmailImage instance for method chaining</returns>
    public EmailImage WithMargin(EmailSpacing vertical, EmailSpacing horizontal) {
        Margin = $"{vertical.ToCssValue()} {horizontal.ToCssValue()}";
        return this;
    }

    /// <summary>
    /// Sets individual margins for all four sides using EmailSpacing
    /// </summary>
    /// <param name="top">The top margin</param>
    /// <param name="right">The right margin</param>
    /// <param name="bottom">The bottom margin</param>
    /// <param name="left">The left margin</param>
    /// <returns>The EmailImage instance for method chaining</returns>
    public EmailImage WithMargin(EmailSpacing top, EmailSpacing right, EmailSpacing bottom, EmailSpacing left) {
        Margin = $"{top.ToCssValue()} {right.ToCssValue()} {bottom.ToCssValue()} {left.ToCssValue()}";
        return this;
    }

    #endregion
}