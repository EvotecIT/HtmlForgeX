using System.Linq;

using HtmlForgeX.Extensions;

namespace HtmlForgeX;

/// <summary>
/// Enhanced TablerCard with all features from Tabler cards.html, card-actions.html, and cards-masonry.html
/// Extends the existing TablerCard to follow HtmlForgeX patterns
/// </summary>
public partial class TablerCardEnhanced : TablerCard {
    // Card header properties
    public string HeaderTitle { get; set; } = string.Empty;
    public string HeaderSubtitle { get; set; } = string.Empty;
    public TablerAvatar HeaderAvatar { get; set; }
    public List<Element> HeaderActions { get; set; } = new List<Element>();
    public bool HeaderLightBackground { get; set; }
    public bool HasHeaderTabs { get; set; }
    public bool HasHeaderPills { get; set; }
    public List<TablerNavItem> HeaderNavItems { get; set; } = new List<TablerNavItem>();

    // Card image properties
    public string ImageUrl { get; set; } = string.Empty;
    public string ImagePosition { get; set; } = "top"; // top, bottom, left, right
    public string ImageAlt { get; set; } = string.Empty;
    public bool ImageResponsive { get; set; } = true;
    public string ImageAspectRatio { get; set; } = "21x9";

    // Enhanced footer properties
    public List<Element> FooterActions { get; set; } = new List<Element>();
    public List<TablerAvatar> FooterAvatars { get; set; } = new List<TablerAvatar>();
    public string FooterText { get; set; } = string.Empty;
    public bool FooterTransparent { get; set; }
    public bool FooterHasSwitch { get; set; }
    public bool FooterSwitchChecked { get; set; }

    /// <summary>
    /// Initializes or configures TablerCardEnhanced.
    /// </summary>
    public TablerCardEnhanced() : base() { }
}
