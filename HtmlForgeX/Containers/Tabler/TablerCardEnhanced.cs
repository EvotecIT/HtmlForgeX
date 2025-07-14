using System.Linq;

using HtmlForgeX.Extensions;

namespace HtmlForgeX;

/// <summary>
/// Enhanced TablerCard with all features from Tabler cards.html, card-actions.html, and cards-masonry.html
/// Extends the existing TablerCard to follow HtmlForgeX patterns
/// </summary>
public class TablerCardEnhanced : TablerCard {
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

    #region Header Methods
    /// <summary>
    /// Initializes or configures WithHeader.
    /// </summary>
    public TablerCardEnhanced WithHeader(string title, string subtitle = "") {
        HeaderTitle = title;
        HeaderSubtitle = subtitle;
        return this;
    }

    /// <summary>
    /// Initializes or configures WithHeaderAvatar.
    /// </summary>
    public TablerCardEnhanced WithHeaderAvatar(string imageUrl, string alt = "") {
        HeaderAvatar = new TablerAvatar().Image(imageUrl);
        return this;
    }

    /// <summary>
    /// Initializes or configures WithHeaderAvatar.
    /// </summary>
    public TablerCardEnhanced WithHeaderAvatar(TablerIconType icon, TablerColor backgroundColor = TablerColor.Primary, TablerColor textColor = TablerColor.White) {
        HeaderAvatar = new TablerAvatar().Icon(icon).BackgroundColor(backgroundColor).TextColor(textColor);
        return this;
    }

    /// <summary>
    /// Initializes or configures WithHeaderAction.
    /// </summary>
    public TablerCardEnhanced WithHeaderAction(string text, string href = "#", TablerIconType? icon = null, TablerButtonVariant variant = TablerButtonVariant.Primary) {
        var button = new TablerButton(text, href, variant);
        if (icon.HasValue) {
            button.WithIcon(icon.Value);
        }
        HeaderActions.Add(button);
        return this;
    }

    /// <summary>
    /// Initializes or configures WithHeaderIconAction.
    /// </summary>
    public TablerCardEnhanced WithHeaderIconAction(TablerIconType icon, string href = "#") {
        HeaderActions.Add(new TablerIconButton(icon, href));
        return this;
    }

    /// <summary>
    /// Initializes or configures WithHeaderDropdown.
    /// </summary>
    public TablerCardEnhanced WithHeaderDropdown(List<TablerDropdownItem> items) {
        HeaderActions.Add(new TablerDropdown(items));
        return this;
    }

    /// <summary>
    /// Initializes or configures WithHeaderLightBackground.
    /// </summary>
    public TablerCardEnhanced WithHeaderLightBackground() {
        HeaderLightBackground = true;
        return this;
    }

    /// <summary>
    /// Initializes or configures WithHeaderTabs.
    /// </summary>
    public TablerCardEnhanced WithHeaderTabs(List<TablerNavItem> navItems) {
        HasHeaderTabs = true;
        HeaderNavItems = navItems;
        return this;
    }

    /// <summary>
    /// Initializes or configures WithHeaderPills.
    /// </summary>
    public TablerCardEnhanced WithHeaderPills(List<TablerNavItem> navItems) {
        HasHeaderPills = true;
        HeaderNavItems = navItems;
        return this;
    }
    #endregion

    #region Image Methods  
    /// <summary>
    /// Initializes or configures WithImage.
    /// </summary>
    public TablerCardEnhanced WithImage(string url, string position = "top", string alt = "") {
        ImageUrl = url;
        ImagePosition = position;
        ImageAlt = alt;
        return this;
    }

    /// <summary>
    /// Initializes or configures WithImageSettings.
    /// </summary>
    public TablerCardEnhanced WithImageSettings(bool responsive = true, string aspectRatio = "21x9") {
        ImageResponsive = responsive;
        ImageAspectRatio = aspectRatio;
        return this;
    }
    #endregion

    #region Footer Methods
    /// <summary>
    /// Initializes or configures WithFooter.
    /// </summary>
    public TablerCardEnhanced WithFooter(string text = "", bool transparent = false) {
        FooterText = text;
        FooterTransparent = transparent;
        return this;
    }

    /// <summary>
    /// Initializes or configures WithFooterButton.
    /// </summary>
    public TablerCardEnhanced WithFooterButton(string text, string href = "#", TablerButtonVariant variant = TablerButtonVariant.Primary) {
        FooterActions.Add(new TablerButton(text, href, variant));
        return this;
    }

    /// <summary>
    /// Initializes or configures WithFooterAvatars.
    /// </summary>
    public TablerCardEnhanced WithFooterAvatars(params string[] imageUrls) {
        foreach (var url in imageUrls) {
            FooterAvatars.Add(new TablerAvatar().Image(url).Size(AvatarSize.XS));
        }
        return this;
    }

    /// <summary>
    /// Initializes or configures WithFooterSwitch.
    /// </summary>
    public TablerCardEnhanced WithFooterSwitch(bool isChecked = false) {
        FooterHasSwitch = true;
        FooterSwitchChecked = isChecked;
        return this;
    }
    #endregion

    /// <summary>
    /// Initializes or configures ToString.
    /// </summary>
    public override string ToString() {
        // Get base card HTML
        var baseCardHtml = base.ToString();

        // Parse the base card to inject our enhancements
        var cardTag = IsLink ? new HtmlTag("a") : new HtmlTag("div");

        // Build CSS classes from base
        var classes = new List<string> { "card" };

        // Note: CardOuterStyle is private in base class, using base logic

        // Add enhanced states
        if (IsActive) classes.Add("card-active");
        if (IsInactive) classes.Add("card-inactive");
        if (IsStacked) classes.Add("card-stacked");
        if (IsBorderless) classes.Add("card-borderless");

        if (CardRotation == "left") classes.Add("card-rotate-left");
        else if (CardRotation == "right") classes.Add("card-rotate-right");

        if (IsLink) {
            classes.Add("card-link");
            if (LinkEffect == "rotate") classes.Add("card-link-rotate");
            else if (LinkEffect == "pop") classes.Add("card-link-pop");
            cardTag.Attribute("href", LinkUrl ?? "#");
        }

        if (BackgroundColor.HasValue) {
            if (IsBackgroundLight) {
                classes.Add($"bg-{BackgroundColor.Value.ToTablerString()}-lt");
            } else {
                classes.Add(BackgroundColor.Value.ToTablerBackground());
                classes.Add($"text-{BackgroundColor.Value.ToTablerString()}-fg");
            }
        }

        cardTag.Class(string.Join(" ", classes));

        // Add status indicator
        if (!string.IsNullOrEmpty(StatusPosition) && StatusColor.HasValue) {
            var statusDiv = new HtmlTag("div");
            var positionClass = StatusPosition switch {
                "top" => "card-status-top",
                "bottom" => "card-status-bottom",
                "start" => "card-status-start",
                "end" => "card-status-end",
                _ => "card-status-top"
            };
            statusDiv.Class($"{positionClass} {StatusColor.Value.ToTablerBackground()}");
            cardTag.Value(statusDiv);
        }

        // Add ribbon
        if (!string.IsNullOrEmpty(RibbonText) || RibbonIcon.HasValue) {
            var ribbonDiv = new HtmlTag("div");
            var ribbonClasses = new List<string> { "ribbon" };

            if (!string.IsNullOrEmpty(RibbonPosition) && RibbonPosition != "top") {
                ribbonClasses.Add($"ribbon-{RibbonPosition}");
            } else {
                ribbonClasses.Add("ribbon-top");
            }

            if (RibbonColor.HasValue) {
                ribbonClasses.Add(RibbonColor.Value.ToTablerBackground());
            } else {
                ribbonClasses.Add("bg-red");
            }

            ribbonDiv.Class(string.Join(" ", ribbonClasses));

            if (RibbonIcon.HasValue) {
                ribbonDiv.Value(new TablerIconElement(RibbonIcon.Value));
            } else if (!string.IsNullOrEmpty(RibbonText)) {
                ribbonDiv.Value(RibbonText);
            }

            cardTag.Value(ribbonDiv);
        }

        // Add stamp
        if (StampIcon.HasValue) {
            var stampDiv = new HtmlTag("div").Class("card-stamp");
            var stampIconDiv = new HtmlTag("div");

            var stampClasses = new List<string> { "card-stamp-icon" };
            if (StampIconBackgroundColor.HasValue) {
                stampClasses.Add(StampIconBackgroundColor.Value.ToTablerBackground());
            } else {
                stampClasses.Add("bg-yellow");
            }

            if (StampIconColor.HasValue) {
                stampClasses.Add(StampIconColor.Value.ToTablerText());
            }

            stampIconDiv.Class(string.Join(" ", stampClasses));
            stampIconDiv.Value(new TablerIconElement(StampIcon.Value));
            stampDiv.Value(stampIconDiv);
            cardTag.Value(stampDiv);
        }

        // Handle side images with row layout
        if (!string.IsNullOrEmpty(ImageUrl) && (ImagePosition == "left" || ImagePosition == "right")) {
            var rowDiv = new HtmlTag("div").Class("row row-0");

            var imageCol = new HtmlTag("div").Class("col-3");
            if (ImagePosition == "right") {
                imageCol.Class("order-md-last");
            }

            var img = new HtmlTag("img")
                .Attribute("src", ImageUrl)
                .Class("w-100 h-100 object-cover")
                .Class(ImagePosition == "left" ? "card-img-start" : "card-img-end");

            if (!string.IsNullOrEmpty(ImageAlt)) {
                img.Attribute("alt", ImageAlt);
            }

            imageCol.Value(img);
            rowDiv.Value(imageCol);

            var contentCol = new HtmlTag("div").Class("col");

            // Add enhanced header
            if (!string.IsNullOrEmpty(HeaderTitle) || HeaderAvatar != null || HeaderActions.Any() || HasHeaderTabs || HasHeaderPills) {
                contentCol.Value(BuildCardHeader());
            }

            // Add body
            var bodyDiv = new HtmlTag("div").Class("card-body");
            if (!string.IsNullOrEmpty(CardContent)) {
                bodyDiv.Value(CardContent);
            }
            if (!string.IsNullOrEmpty(CardInnerStyle)) {
                bodyDiv.Attribute("style", CardInnerStyle);
            }
            foreach (var child in Children.WhereNotNull()) {
                bodyDiv.Value(child);
            }
            contentCol.Value(bodyDiv);

            // Add enhanced footer
            if (!string.IsNullOrEmpty(FooterText) || FooterActions.Any() || FooterAvatars.Any() || FooterHasSwitch) {
                contentCol.Value(BuildCardFooter());
            }

            rowDiv.Value(contentCol);
            cardTag.Value(rowDiv);
        } else {
            // Normal layout

            // Add top image
            if (!string.IsNullOrEmpty(ImageUrl) && ImagePosition == "top") {
                cardTag.Value(BuildCardImage());
            }

            // Add enhanced header
            if (!string.IsNullOrEmpty(HeaderTitle) || HeaderAvatar != null || HeaderActions.Any() || HasHeaderTabs || HasHeaderPills) {
                cardTag.Value(BuildCardHeader());
            }

            // Add body
            var bodyDiv = new HtmlTag("div").Class("card-body");
            if (!string.IsNullOrEmpty(CardContent)) {
                bodyDiv.Value(CardContent);
            }
            if (!string.IsNullOrEmpty(CardInnerStyle)) {
                bodyDiv.Attribute("style", CardInnerStyle);
            }
            foreach (var child in Children.WhereNotNull()) {
                bodyDiv.Value(child);
            }
            cardTag.Value(bodyDiv);

            // Add enhanced footer
            if (!string.IsNullOrEmpty(FooterText) || FooterActions.Any() || FooterAvatars.Any() || FooterHasSwitch) {
                cardTag.Value(BuildCardFooter());
            }

            // Add bottom image
            if (!string.IsNullOrEmpty(ImageUrl) && ImagePosition == "bottom") {
                cardTag.Value(BuildCardImage());
            }
        }

        // Add progress bar
        if (ProgressValue.HasValue) {
            var progressDiv = new HtmlTag("div").Class("progress progress-sm card-progress");
            var progressBar = new HtmlTag("div");

            var progressClasses = new List<string> { "progress-bar" };
            if (ProgressColor.HasValue) {
                progressClasses.Add(ProgressColor.Value.ToTablerBackground());
            }

            progressBar.Class(string.Join(" ", progressClasses));
            progressBar.Attribute("style", $"width: {ProgressValue.Value:F1}%");
            progressBar.Attribute("role", "progressbar");
            progressBar.Attribute("aria-valuenow", ProgressValue.Value.ToString("F1"));
            progressBar.Attribute("aria-valuemin", "0");
            progressBar.Attribute("aria-valuemax", "100");
            progressBar.Attribute("aria-label", $"{ProgressValue.Value:F1}% Complete");

            var hiddenSpan = new HtmlTag("span").Class("visually-hidden").Value($"{ProgressValue.Value:F1}% Complete");
            progressBar.Value(hiddenSpan);

            progressDiv.Value(progressBar);
            cardTag.Value(progressDiv);
        }

        return cardTag.ToString();
    }

    private HtmlTag BuildCardHeader() {
        var headerDiv = new HtmlTag("div");
        var headerClasses = new List<string> { "card-header" };

        if (HeaderLightBackground) {
            headerClasses.Add("card-header-light");
        }

        headerDiv.Class(string.Join(" ", headerClasses));

        // Header with tabs/pills navigation
        if (HasHeaderTabs || HasHeaderPills) {
            var ul = new HtmlTag("ul");
            ul.Class($"nav nav-{(HasHeaderPills ? "pills" : "tabs")} card-header-{(HasHeaderPills ? "pills" : "tabs")}");

            foreach (var item in HeaderNavItems) {
                var li = new HtmlTag("li").Class("nav-item");
                var a = new HtmlTag("a").Class("nav-link").Attribute("href", item.Href ?? "#").Value(item.Text);
                if (item.IsActive) a.Class("active");
                if (item.IsDisabled) {
                    a.Class("disabled").Attribute("tabindex", "-1").Attribute("aria-disabled", "true");
                }
                if (item.Icon != null) {
                    a.Value(item.Icon.ToString() + " " + item.Text);
                }
                li.Value(a);
                ul.Value(li);
            }

            headerDiv.Value(ul);
        } else {
            // Regular header with title/avatar/actions
            if (HeaderAvatar != null || !string.IsNullOrEmpty(HeaderTitle)) {
                var titleSection = new HtmlTag("div");

                if (HeaderAvatar != null) {
                    var rowDiv = new HtmlTag("div").Class("row align-items-center");
                    var avatarCol = new HtmlTag("div").Class("col-auto");
                    avatarCol.Value(HeaderAvatar);
                    rowDiv.Value(avatarCol);

                    var textCol = new HtmlTag("div").Class("col");
                    if (!string.IsNullOrEmpty(HeaderTitle)) {
                        textCol.Value(new HtmlTag("div").Class("card-title").Value(HeaderTitle));
                    }
                    if (!string.IsNullOrEmpty(HeaderSubtitle)) {
                        textCol.Value(new HtmlTag("div").Class("card-subtitle").Value(HeaderSubtitle));
                    }
                    rowDiv.Value(textCol);

                    titleSection.Value(rowDiv);
                } else {
                    if (!string.IsNullOrEmpty(HeaderTitle)) {
                        var titleTag = new HtmlTag("h3").Class("card-title");
                        titleTag.Value(HeaderTitle);

                        if (!string.IsNullOrEmpty(HeaderSubtitle)) {
                            var subtitleSpan = new HtmlTag("span").Class("card-subtitle").Value(HeaderSubtitle);
                            titleTag.Value(" ").Value(subtitleSpan);
                        }

                        titleSection.Value(titleTag);
                    }
                }

                headerDiv.Value(titleSection);
            }

            // Add actions
            if (HeaderActions.Any()) {
                var actionsDiv = new HtmlTag("div").Class("card-actions");

                // Check if all actions are icon buttons
                if (HeaderActions.All(a => a is TablerIconButton)) {
                    actionsDiv.Class("btn-actions");
                }

                foreach (var action in HeaderActions) {
                    actionsDiv.Value(action);
                }

                headerDiv.Value(actionsDiv);
            }
        }

        return headerDiv;
    }

    private HtmlTag BuildCardImage() {
        if (ImageResponsive) {
            var div = new HtmlTag("div");
            var classes = new List<string> {
                "img-responsive",
                $"img-responsive-{ImageAspectRatio}",
                ImagePosition == "top" ? "card-img-top" : "card-img-bottom"
            };

            div.Class(string.Join(" ", classes));
            div.Attribute("style", $"background-image: url({ImageUrl})");

            return div;
        } else {
            var img = new HtmlTag("img");
            img.Attribute("src", ImageUrl);
            img.Class(ImagePosition == "top" ? "card-img-top" : "card-img-bottom");

            if (!string.IsNullOrEmpty(ImageAlt)) {
                img.Attribute("alt", ImageAlt);
            }

            return img;
        }
    }

    private HtmlTag BuildCardFooter() {
        var footerDiv = new HtmlTag("div");
        var footerClasses = new List<string> { "card-footer" };

        if (FooterTransparent) {
            footerClasses.Add("card-footer-transparent");
        }

        footerDiv.Class(string.Join(" ", footerClasses));

        if (!string.IsNullOrEmpty(FooterText)) {
            footerDiv.Value(FooterText);
        }

        // Handle complex footer layouts
        if (FooterActions.Any() || FooterAvatars.Any() || FooterHasSwitch) {
            var rowDiv = new HtmlTag("div").Class("row align-items-center");

            // Left side content
            if (FooterActions.Any(a => a is TablerButton b && b.Variant == TablerButtonVariant.Link)) {
                var leftCol = new HtmlTag("div").Class("col-auto");
                foreach (var action in FooterActions.Where(a => a is TablerButton b && b.Variant == TablerButtonVariant.Link)) {
                    leftCol.Value(action);
                }
                rowDiv.Value(leftCol);
            }

            // Right side content
            var rightCol = new HtmlTag("div").Class("col-auto ms-auto");

            // Add avatars
            if (FooterAvatars.Any()) {
                var avatarList = new HtmlTag("div").Class("avatar-list avatar-list-stacked");
                foreach (var avatar in FooterAvatars) {
                    avatarList.Value(avatar);
                }
                rightCol.Value(avatarList);
            }

            // Add switch
            if (FooterHasSwitch) {
                var switchLabel = new HtmlTag("label").Class("form-check form-switch form-switch-lg m-0");
                var switchInput = new HtmlTag("input")
                    .Class("form-check-input position-static")
                    .Attribute("type", "checkbox");

                if (FooterSwitchChecked) {
                    switchInput.Attribute("checked", "");
                }

                switchLabel.Value(switchInput);
                rightCol.Value(switchLabel);
            }

            // Add primary buttons
            foreach (var action in FooterActions.Where(a => !(a is TablerButton b && b.Variant == TablerButtonVariant.Link))) {
                rightCol.Value(action);
            }

            rowDiv.Value(rightCol);
            footerDiv.Value(rowDiv);
        }

        return footerDiv;
    }
}