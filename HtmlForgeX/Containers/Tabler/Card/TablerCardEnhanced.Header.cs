using System.Linq;

using HtmlForgeX.Extensions;
using HtmlForgeX.Containers.Tabler;

namespace HtmlForgeX;

public partial class TablerCardEnhanced {
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
            button.Icon(icon.Value);
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
    /// Adds a dropdown menu to the header using a configuration action.
    /// </summary>
    /// <param name="configure">Action to configure the dropdown.</param>
    /// <returns>The current card instance.</returns>
    // Note: Updated to use new TablerDropdown API
    public TablerCardEnhanced WithHeaderDropdown(Action<TablerDropdown> configure) {
        var dropdown = new TablerDropdown("Actions");
        configure?.Invoke(dropdown);
        HeaderActions.Add(dropdown);
        return this;
    }

    // Note: Duplicate method removed - use the method above

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

    private HtmlTag BuildCardHeader() {
        // Ensure all actions have the current Document and Email references
        foreach (var action in HeaderActions.WhereNotNull()) {
            action.Document = Document;
            action.Email = Email;
        }

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
}