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
    
    public TablerCardImage Url(string url) {
        ImageUrl = url;
        return this;
    }
    
    public TablerCardImage Alt(string altText) {
        AltText = altText;
        return this;
    }
    
    public TablerCardImage WithPosition(TablerCardImagePosition position) {
        Position = position;
        return this;
    }
    
    public TablerCardImage WithSize(TablerCardImageSize size) {
        Size = size;
        return this;
    }
    
    public TablerCardImage Responsive(bool responsive = true) {
        IsResponsive = responsive;
        return this;
    }
    
    public TablerCardImage WithEffect(TablerCardImageEffect effect) {
        Effect = effect;
        return this;
    }
    
    public TablerCardImage AsBackground() {
        Position = TablerCardImagePosition.Background;
        return this;
    }
    
    public override string ToString() {
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
        var imageDiv = new HtmlTag("div");
        var classes = new List<string>();
        
        if (IsResponsive) {
            classes.Add("img-responsive");
            classes.Add(Size.ToTablerImageSizeClass());
        }
        
        // Add position classes
        var positionClass = Position.ToTablerCardImageClass();
        if (!string.IsNullOrEmpty(positionClass)) {
            classes.Add(positionClass);
        }
        
        // Add effect classes
        var effectClass = Effect.ToTablerImageEffectClass();
        if (!string.IsNullOrEmpty(effectClass)) {
            classes.Add(effectClass);
        }
        
        imageDiv.Class(string.Join(" ", classes));
        imageDiv.Style("background-image", $"url({ImageUrl})");
        
        return imageDiv.ToString();
    }
    
    private string CreateBackgroundImage() {
        var backgroundDiv = new HtmlTag("div");
        var classes = new List<string> { "card-img-background" };
        
        var effectClass = Effect.ToTablerImageEffectClass();
        if (!string.IsNullOrEmpty(effectClass)) {
            classes.Add(effectClass);
        }
        
        backgroundDiv.Class(string.Join(" ", classes));
        backgroundDiv.Style("background-image", $"url({ImageUrl})");
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
        imgTag.Attribute("src", ImageUrl);
        imgTag.Attribute("alt", AltText ?? "");
        imgTag.Class("w-100 h-100 object-cover");
        
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
        var rowDiv = new HtmlTag("div").Class("row row-0");
        
        var imageCol = new HtmlTag("div").Class("col-3");
        if (Position == TablerCardImagePosition.Right) {
            imageCol.Class("order-md-last");
        }
        
        var imgTag = new HtmlTag("img");
        imgTag.Attribute("src", ImageUrl);
        imgTag.Attribute("alt", AltText ?? "");
        imgTag.Class("w-100 h-100 object-cover");
        
        var positionClass = Position.ToTablerCardImageClass();
        if (!string.IsNullOrEmpty(positionClass)) {
            imgTag.Class(positionClass);
        }
        
        imageCol.Value(imgTag);
        rowDiv.Value(imageCol);
        
        // Content column
        var contentCol = new HtmlTag("div").Class("col");
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
    public static string ToTablerImageSizeClass(this TablerCardImageSize size) {
        return size switch {
            TablerCardImageSize.Default => "img-responsive-21x9",
            TablerCardImageSize.Square => "img-responsive-1x1",
            TablerCardImageSize.Portrait => "img-responsive-4x3",
            TablerCardImageSize.Landscape => "img-responsive-16x9",
            TablerCardImageSize.Wide => "img-responsive-21x9",
            _ => "img-responsive-21x9"
        };
    }
    
    public static string ToTablerImageEffectClass(this TablerCardImageEffect effect) {
        return effect switch {
            TablerCardImageEffect.Overlay => "img-overlay",
            TablerCardImageEffect.Gradient => "img-gradient",
            TablerCardImageEffect.Blur => "img-blur",
            TablerCardImageEffect.Grayscale => "img-grayscale",
            _ => ""
        };
    }
}