namespace HtmlForgeX;

public partial class EmailImage : Element
{
    #region Properties

    /// <summary>Gets or sets the image source URL.</summary>
    public string Source { get; set; } = string.Empty;

    /// <summary>Gets or sets the image width.</summary>
    public string Width { get; set; } = string.Empty;

    /// <summary>Gets or sets the image height.</summary>
    public string Height { get; set; } = string.Empty;

    /// <summary>Gets or sets the alternative text for accessibility.</summary>
    public string AlternativeText { get; set; } = string.Empty;

    /// <summary>Gets or sets the image alignment.</summary>
    public string Alignment { get; set; } = "left";

    /// <summary>Gets or sets the margin around the image.</summary>
    public string Margin { get; set; } = "0 0 16px 0";

    /// <summary>Gets or sets the padding around the image.</summary>
    public string Padding { get; set; } = "0";

    /// <summary>Gets or sets the border for the image.</summary>
    public string Border { get; set; } = "none";

    /// <summary>Gets or sets the border radius for the image.</summary>
    public string BorderRadius { get; set; } = "0";

    /// <summary>Gets or sets whether the image should be a link.</summary>
    public string LinkUrl { get; set; } = string.Empty;

    /// <summary>Gets or sets whether the image should open in a new window.</summary>
    public bool OpenInNewWindow { get; set; }

    /// <summary>Gets or sets the CSS class for the image container.</summary>
    public string CssClass { get; set; } = "logo";

    /// <summary>Gets or sets whether the image should be embedded as base64.</summary>
    public bool EmbedAsBase64 { get; set; }

    /// <summary>Gets or sets the base64 encoded image data.</summary>
    public string Base64Data { get; set; } = string.Empty;

    /// <summary>Gets or sets the image MIME type for embedded images.</summary>
    public string MimeType { get; set; } = string.Empty;

    /// <summary>Gets or sets the maximum width for image optimization (in pixels).</summary>
    public int MaxWidth { get; set; }

    /// <summary>Gets or sets the maximum height for image optimization (in pixels).</summary>
    public int MaxHeight { get; set; }

    /// <summary>Gets or sets the quality for JPEG compression (0-100).</summary>
    public int Quality { get; set; } = 85;

    /// <summary>Gets or sets whether to enable automatic image optimization.</summary>
    public bool OptimizeImage { get; set; }

    /// <summary>Gets or sets whether to skip automatic embedding for this specific image.</summary>
    public bool SkipAutoEmbedding { get; set; }

    /// <summary>Stores the original source path before any embedding occurs.</summary>
    private string _originalSource = string.Empty;

    /// <summary>Gets or sets whether to force embedding for this specific image.</summary>
    public bool ForceEmbedding { get; set; }

    /// <summary>Gets or sets the dark mode image source URL.</summary>
    public string DarkModeSource { get; set; } = string.Empty;

    /// <summary>Gets or sets the dark mode alternative text.</summary>
    public string DarkModeAlternativeText { get; set; } = string.Empty;

    /// <summary>Gets or sets whether dark mode image should be embedded as base64.</summary>
    public bool DarkModeEmbedAsBase64 { get; set; }

    /// <summary>Gets or sets the dark mode base64 encoded image data.</summary>
    public string DarkModeBase64Data { get; set; } = string.Empty;

    /// <summary>Gets or sets the dark mode image MIME type.</summary>
    public string DarkModeMimeType { get; set; } = string.Empty;

    /// <summary>Gets or sets whether to enable automatic dark mode image swapping.</summary>
    public bool EnableDarkModeSwapping { get; set; } = true;

    #endregion
}
