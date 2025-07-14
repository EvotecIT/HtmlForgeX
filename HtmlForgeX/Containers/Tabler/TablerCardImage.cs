using System;
using System.Collections.Generic;

namespace HtmlForgeX;

/// <summary>
/// Card image component with proper positioning (no raw HTML)
/// </summary>
public class TablerCardImage : Element {
    private string ImageUrl { get; set; } = "";
    private string? AltText { get; set; }
    private TablerCardImagePosition Position { get; set; } = TablerCardImagePosition.Top;
    private TablerCardImageSize Size { get; set; } = TablerCardImageSize.Default;
    private bool IsResponsive { get; set; } = true;
    private string? BackgroundStyle { get; set; }
    private TablerCardImageEffect Effect { get; set; } = TablerCardImageEffect.None;

    // Image embedding properties (reusing EmailImage pattern)
    private bool EmbedAsBase64 { get; set; } = false;
    private string Base64Data { get; set; } = "";
    private string MimeType { get; set; } = "";
    private bool ForceEmbedding { get; set; } = false;
    private bool SkipEmbedding { get; set; } = false;
    private int EmbeddingTimeout { get; set; } = 30;

    /// <summary>
    /// Initializes or configures Url.
    /// </summary>
    public TablerCardImage Url(string url) {
        ImageUrl = url;
        return this;
    }

    /// <summary>
    /// Initializes or configures Alt.
    /// </summary>
    public TablerCardImage Alt(string altText) {
        AltText = altText;
        return this;
    }

    /// <summary>
    /// Initializes or configures WithPosition.
    /// </summary>
    public TablerCardImage WithPosition(TablerCardImagePosition position) {
        Position = position;
        return this;
    }

    /// <summary>
    /// Initializes or configures WithSize.
    /// </summary>
    public TablerCardImage WithSize(TablerCardImageSize size) {
        Size = size;
        return this;
    }

    /// <summary>
    /// Initializes or configures Responsive.
    /// </summary>
    public TablerCardImage Responsive(bool responsive = true) {
        IsResponsive = responsive;
        return this;
    }

    /// <summary>
    /// Initializes or configures WithEffect.
    /// </summary>
    public TablerCardImage WithEffect(TablerCardImageEffect effect) {
        Effect = effect;
        return this;
    }

    /// <summary>
    /// Initializes or configures AsBackground.
    /// </summary>
    public TablerCardImage AsBackground() {
        Position = TablerCardImagePosition.Background;
        return this;
    }

    /// <summary>
    /// Force embedding regardless of LibraryMode
    /// </summary>
    public TablerCardImage WithEmbedding() {
        ForceEmbedding = true;
        return this;
    }

    /// <summary>
    /// Skip embedding even if LibraryMode is Offline
    /// </summary>
    public TablerCardImage WithoutEmbedding() {
        SkipEmbedding = true;
        return this;
    }

    /// <summary>
    /// Embed image from file path
    /// </summary>
    public TablerCardImage EmbedFromFile(string filePath) {
        var result = ImageEmbeddingHelper.EmbedFromFile(filePath, 0, true);
        if (result.Success) {
            Base64Data = result.Base64Data;
            MimeType = result.MimeType;
            EmbedAsBase64 = true;
        }
        return this;
    }

    /// <summary>
    /// Embed image from URL
    /// </summary>
    public TablerCardImage EmbedFromUrl(string url, int timeoutSeconds = 30) {
        var result = ImageEmbeddingHelper.EmbedFromUrl(url, timeoutSeconds, 0, true);
        if (result.Success) {
            Base64Data = result.Base64Data;
            MimeType = result.MimeType;
            EmbedAsBase64 = true;
        }
        return this;
    }

    /// <summary>
    /// Smart embedding - auto-detects file vs URL
    /// </summary>
    public TablerCardImage EmbedSmart(string source, int timeoutSeconds = 30) {
        var result = ImageEmbeddingHelper.EmbedSmart(source, timeoutSeconds, 0, true);
        if (result.Success) {
            Base64Data = result.Base64Data;
            MimeType = result.MimeType;
            EmbedAsBase64 = true;
        }
        return this;
    }

    /// <summary>
    /// Initializes or configures ToString.
    /// </summary>
    public override string ToString() {
        // Auto-embed based on LibraryMode unless explicitly overridden
        if (!SkipEmbedding && !EmbedAsBase64 &&
            (ForceEmbedding || GlobalStorage.LibraryMode == LibraryMode.Offline)) {
            EmbedSmart(ImageUrl, EmbeddingTimeout);
        }

        switch (Position) {
            case TablerCardImagePosition.Background:
                return CreateBackgroundImage();
            case TablerCardImagePosition.Left:
            case TablerCardImagePosition.Right:
                return CreateSideImage();
            default:
                return CreateStandardImage();
        }
    }

    private string CreateStandardImage() {
        var imgTag = new HtmlTag("img");

        // Use embedded data if available, otherwise use URL
        var src = EmbedAsBase64 && !string.IsNullOrEmpty(Base64Data) && !string.IsNullOrEmpty(MimeType)
            ? "data:" + MimeType + ";base64," + Base64Data
            : ImageUrl;

        imgTag.Attribute("src", src);
        imgTag.Attribute("alt", AltText ?? "");

        var classes = new List<string>();

        // Add position classes
        var positionClass = Position.ToTablerCardImageClass();
        if (!string.IsNullOrEmpty(positionClass)) {
            classes.Add(positionClass);
        }

        // Add responsive classes
        if (IsResponsive) {
            classes.Add("img-fluid");
        }

        // Add effect classes
        var effectClass = Effect.ToTablerImageEffectClass();
        if (!string.IsNullOrEmpty(effectClass)) {
            classes.Add(effectClass);
        }

        if (classes.Count > 0) {
            imgTag.Class(string.Join(" ", classes));
        }

        return imgTag.ToString();
    }

    private string CreateBackgroundImage() {
        var backgroundDiv = new HtmlTag("div");
        var classes = new List<string> { "card-img-background" };

        var effectClass = Effect.ToTablerImageEffectClass();
        if (!string.IsNullOrEmpty(effectClass)) {
            classes.Add(effectClass);
        }

        backgroundDiv.Class(string.Join(" ", classes));
        // Use embedded data if available, otherwise use URL
        var src = EmbedAsBase64 && !string.IsNullOrEmpty(Base64Data) && !string.IsNullOrEmpty(MimeType)
            ? "data:" + MimeType + ";base64," + Base64Data
            : ImageUrl;

        backgroundDiv.Style("background-image", "url(" + src + ")");
        backgroundDiv.Style("background-size", "cover");
        backgroundDiv.Style("background-position", "center");

        return backgroundDiv.ToString();
    }

    private string CreateSideImage() {
        // Side images need to be integrated into the card body layout
        // This creates a row layout with image and content side by side
        var rowDiv = new HtmlTag("div").Class("row row-0");

        var imageCol = new HtmlTag("div").Class("col-3");
        if (Position == TablerCardImagePosition.Right) {
            imageCol.Class("order-md-last");
        }

        var imgTag = new HtmlTag("img");

        // Use embedded data if available, otherwise use URL
        var src = EmbedAsBase64 && !string.IsNullOrEmpty(Base64Data) && !string.IsNullOrEmpty(MimeType)
            ? "data:" + MimeType + ";base64," + Base64Data
            : ImageUrl;

        imgTag.Attribute("src", src);
        imgTag.Attribute("alt", AltText ?? "");
        imgTag.Class("w-100 object-cover");

        var positionClass = Position.ToTablerCardImageClass();
        if (!string.IsNullOrEmpty(positionClass)) {
            imgTag.Class(positionClass);
        }

        imageCol.Value(imgTag);
        rowDiv.Value(imageCol);

        return rowDiv.ToString();
    }

    /// <summary>
    /// Creates a side layout wrapper that includes both image and content
    /// This is used by TablerCard when side images are present
    /// </summary>
    public string CreateSideLayout(string bodyContent) {
        var rowDiv = new HtmlTag("div").Class("row row-0 h-100");

        var imageCol = new HtmlTag("div").Class("col-3 d-flex align-items-stretch");
        if (Position == TablerCardImagePosition.Right) {
            imageCol.Class("order-md-last");
        }

        var imgTag = new HtmlTag("img");

        // Use embedded data if available, otherwise use URL
        var src = EmbedAsBase64 && !string.IsNullOrEmpty(Base64Data) && !string.IsNullOrEmpty(MimeType)
            ? "data:" + MimeType + ";base64," + Base64Data
            : ImageUrl;

        imgTag.Attribute("src", src);
        imgTag.Attribute("alt", AltText ?? "");
        imgTag.Class("w-100 object-cover");

        var positionClass = Position.ToTablerCardImageClass();
        if (!string.IsNullOrEmpty(positionClass)) {
            imgTag.Class(positionClass);
        }

        imageCol.Value(imgTag);
        rowDiv.Value(imageCol);

        // Update image styling for better height matching
        imgTag.Class("w-100 h-100 object-cover flex-fill");
        imgTag.Style("min-height", "200px");

        // Content column
        var contentCol = new HtmlTag("div").Class("col d-flex flex-column");
        contentCol.Value(bodyContent);
        rowDiv.Value(contentCol);

        return rowDiv.ToString();
    }
}

/// <summary>
/// Image sizes for responsive images
/// </summary>
public enum TablerCardImageSize {
    Default,     // 21x9 aspect ratio
    Square,      // 1x1 aspect ratio
    Portrait,    // 4x3 aspect ratio
    Landscape,   // 16x9 aspect ratio
    Wide         // 21x9 aspect ratio
}

/// <summary>
/// Image effects for visual enhancement
/// </summary>
public enum TablerCardImageEffect {
    None,
    Overlay,
    Gradient,
    Blur,
    Grayscale
}

/// <summary>
/// Extension methods for image styling
/// </summary>
public static class TablerCardImageExtensions {
    /// <summary>
    /// Initializes or configures ToTablerImageSizeClass.
    /// </summary>
    public static string ToTablerImageSizeClass(this TablerCardImageSize size) {
        switch (size) {
            case TablerCardImageSize.Default:
                return "img-responsive-21x9";
            case TablerCardImageSize.Square:
                return "img-responsive-1x1";
            case TablerCardImageSize.Portrait:
                return "img-responsive-4x3";
            case TablerCardImageSize.Landscape:
                return "img-responsive-16x9";
            case TablerCardImageSize.Wide:
                return "img-responsive-21x9";
            default:
                return "img-responsive-21x9";
        }
    }

    /// <summary>
    /// Initializes or configures ToTablerImageEffectClass.
    /// </summary>
    public static string ToTablerImageEffectClass(this TablerCardImageEffect effect) {
        switch (effect) {
            case TablerCardImageEffect.Overlay:
                return "img-overlay";
            case TablerCardImageEffect.Gradient:
                return "img-gradient";
            case TablerCardImageEffect.Blur:
                return "img-blur";
            case TablerCardImageEffect.Grayscale:
                return "img-grayscale";
            default:
                return "";
        }
    }
}