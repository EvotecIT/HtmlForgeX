using System.Linq;
using HtmlForgeX.Extensions;

namespace HtmlForgeX;

public class TablerTabs : Element {
    public List<TablerTabsPanel> Panels { get; set; } = new List<TablerTabsPanel>();
    private string Id { get; } = GlobalStorage.GenerateRandomId("tabs");
    private TabNavigation? PrivateTabNavigation { get; set; }

    public TablerTabs Navigation(TabNavigation navigation) {
        PrivateTabNavigation = navigation;
        return this;
    }

    public TablerTabsPanel AddTab(string title, Element content) {
        var tabsPanel = new TablerTabsPanel().Title(title);
        tabsPanel.Add(content);
        Panels.Add(tabsPanel);
        return tabsPanel;
    }

    public TablerTabsPanel AddTab(string title, Action<TablerTabsPanel> panelAction) {
        var tabsPanel = new TablerTabsPanel().Title(title);
        panelAction(tabsPanel);
        Panels.Add(tabsPanel);
        return tabsPanel;
    }

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

public enum TabState {
    MoveStart,
    MoveEnd
}

public enum TabNavigation {
    Fill,
    Reverse
}

public static class TabStateExtensions {
    public static string EnumToString(this TabState state) {
        return state switch {
            TabState.MoveStart => "ms-auto",
            TabState.MoveEnd => "me-auto",
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, null)
        };
    }
}

public static class NavigationExtensions {
    public static string EnumToString(this TabNavigation navigation) {
        return navigation switch {
            TabNavigation.Fill => "nav-fill",
            TabNavigation.Reverse => "flex-row-reverse",
            _ => throw new ArgumentOutOfRangeException(nameof(navigation), navigation, null)
        };
    }
}
