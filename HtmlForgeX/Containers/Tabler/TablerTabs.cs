using System.Linq;

using HtmlForgeX.Extensions;

namespace HtmlForgeX;

/// <summary>
/// Provides a tabbed card component containing multiple panels.
/// </summary>
public class TablerTabs : Element {
    /// <summary>
    /// Gets the collection of tab panels contained within this component.
    /// </summary>
    public List<TablerTabsPanel> Panels { get; set; } = new List<TablerTabsPanel>();
    private string Id { get; } = GlobalStorage.GenerateRandomId("tabs");
    private TabNavigation? PrivateTabNavigation { get; set; }

    /// <summary>
    /// Initializes or configures Navigation.
    /// </summary>
    public TablerTabs Navigation(TabNavigation navigation) {
        PrivateTabNavigation = navigation;
        return this;
    }

    /// <summary>
    /// Initializes or configures AddTab.
    /// </summary>
    public TablerTabsPanel AddTab(string title, Element content) {
        var tabsPanel = new TablerTabsPanel().Title(title);
        tabsPanel.Add(content);
        Panels.Add(tabsPanel);
        return tabsPanel;
    }

    /// <summary>
    /// Initializes or configures AddTab.
    /// </summary>
    public TablerTabsPanel AddTab(string title, Action<TablerTabsPanel> panelAction) {
        var tabsPanel = new TablerTabsPanel().Title(title);
        panelAction(tabsPanel);
        Panels.Add(tabsPanel);
        return tabsPanel;
    }

    /// <summary>
    /// Initializes or configures ToString.
    /// </summary>
    public override string ToString() {
        var cardDiv = new HtmlTag("div").Class("card");
        var cardHeaderDiv = new HtmlTag("div").Class("card-header");

        var tabsDiv = new HtmlTag("div").Class("tab-content");
        var tabsHeader = new HtmlTag("ul")
            .Class("nav nav-tabs card-header-tabs")
            .Class(PrivateTabNavigation?.EnumToString())
            .Attribute("data-bs-toggle", "tabs");

        var cardBodyDiv = new HtmlTag("div").Class("card-body");

        foreach (var panel in Panels.WhereNotNull()) {
            tabsDiv.Value(panel);
            var anchor = new Anchor()
                .Class("nav-link")
                .Class(panel.IsActive ? "active" : "")
                .Class(panel.IsDisabled ? "disabled" : "")
                .Attribute("data-bs-toggle", "tab")
                .Attribute("href", "#" + panel.Id);

            // Add title text
            anchor.Value(panel.PrivateTitle + " ");

            // Add icon as raw HTML to prevent double encoding
            anchor.Value(TablerIconLibrary.GetIcon(TablerIconType.Adjustments).Size(20));

            var tabHeaderItem = new HtmlTag("li")
                .Class("nav-item")
                .Class(panel.PrivateTabState?.EnumToString())
                .Value(anchor);
            tabsHeader.Value(tabHeaderItem);
        }

        cardHeaderDiv.Value(tabsHeader);
        cardBodyDiv.Value(tabsDiv);

        cardDiv.Value(cardHeaderDiv);
        cardDiv.Value(cardBodyDiv);
        return cardDiv.ToString();
    }
}

/// <summary>
/// TablerTabs enumeration.
/// </summary>
public enum TabState {
    /// <summary>Align tabs to the start of the container.</summary>
    MoveStart,
    /// <summary>Align tabs to the end of the container.</summary>
    MoveEnd
}

/// <summary>
/// TablerTabs enumeration.
/// </summary>
public enum TabNavigation {
    /// <summary>Distribute tabs to fill available width.</summary>
    Fill,
    /// <summary>Reverse the tab order.</summary>
    Reverse
}

/// <summary>
/// Extension methods for the <see cref="TabState"/> enumeration.
/// </summary>
public static class TabStateExtensions {
    /// <summary>
    /// Initializes or configures EnumToString.
    /// </summary>
    public static string EnumToString(this TabState state) {
        return state switch {
            TabState.MoveStart => "ms-auto",
            TabState.MoveEnd => "me-auto",
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, null)
        };
    }
}

/// <summary>
/// Extension methods for the <see cref="TabNavigation"/> enumeration.
/// </summary>
public static class NavigationExtensions {
    /// <summary>
    /// Initializes or configures EnumToString.
    /// </summary>
    public static string EnumToString(this TabNavigation navigation) {
        return navigation switch {
            TabNavigation.Fill => "nav-fill",
            TabNavigation.Reverse => "flex-row-reverse",
            _ => throw new ArgumentOutOfRangeException(nameof(navigation), navigation, null)
        };
    }
}