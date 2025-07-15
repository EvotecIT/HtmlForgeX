using System.Linq;

using HtmlForgeX.Extensions;

namespace HtmlForgeX;

/// <summary>
/// Enhanced TablerCard with all features from Tabler cards.html, card-actions.html, and cards-masonry.html
/// Extends the existing TablerCard to follow HtmlForgeX patterns
/// </summary>
public partial class TablerCardEnhanced : TablerCard {
    // Card header properties
    /// <summary>Primary title displayed in the card header.</summary>
    public string HeaderTitle { get; set; } = string.Empty;
    /// <summary>Secondary title displayed beneath the header title.</summary>
    public string HeaderSubtitle { get; set; } = string.Empty;
    /// <summary>Optional avatar shown in the header.</summary>
    public TablerAvatar HeaderAvatar { get; set; }
    /// <summary>Action elements such as buttons shown in the header.</summary>
    public List<Element> HeaderActions { get; set; } = new List<Element>();
    /// <summary>Whether the header uses a light background color.</summary>
    public bool HeaderLightBackground { get; set; }
    /// <summary>Indicates if navigation tabs are present in the header.</summary>
    public bool HasHeaderTabs { get; set; }
    /// <summary>Indicates if pill-style navigation is present in the header.</summary>
    public bool HasHeaderPills { get; set; }
    /// <summary>Navigation items rendered within the header.</summary>
    public List<TablerNavItem> HeaderNavItems { get; set; } = new List<TablerNavItem>();

    // Card image properties
    /// <summary>URL of the card image.</summary>
    public string ImageUrl { get; set; } = string.Empty;
    /// <summary>Position of the image relative to the card.</summary>
    public string ImagePosition { get; set; } = "top"; // top, bottom, left, right
    /// <summary>Alternate text for the image.</summary>
    public string ImageAlt { get; set; } = string.Empty;
    /// <summary>Whether the image should be responsive.</summary>
    public bool ImageResponsive { get; set; } = true;
    /// <summary>Aspect ratio used when cropping the image.</summary>
    public string ImageAspectRatio { get; set; } = "21x9";

    // Enhanced footer properties
    /// <summary>Action elements displayed in the footer.</summary>
    public List<Element> FooterActions { get; set; } = new List<Element>();
    /// <summary>Avatars displayed within the footer.</summary>
    public List<TablerAvatar> FooterAvatars { get; set; } = new List<TablerAvatar>();
    /// <summary>Text content displayed in the footer.</summary>
    public string FooterText { get; set; } = string.Empty;
    /// <summary>Whether the footer background is transparent.</summary>
    public bool FooterTransparent { get; set; }
    /// <summary>Whether the footer contains a toggle switch.</summary>
    public bool FooterHasSwitch { get; set; }
    /// <summary>Initial checked state of the footer switch.</summary>
    public bool FooterSwitchChecked { get; set; }

    /// <summary>
    /// Initializes or configures TablerCardEnhanced.
    /// </summary>
    public TablerCardEnhanced() : base() { }
}
