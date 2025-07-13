using System.Linq;
using HtmlForgeX.Extensions;

namespace HtmlForgeX;

public class TablerTabsPanel : ElementContainer {
    internal string Id { get; } = GlobalStorage.GenerateRandomId("tabsPanel");
    internal string PrivateTitle { get; set; }
    internal bool IsActive { get; set; }
    internal bool IsDisabled { get; set; }
    internal TabState? PrivateTabState { get; set; }

    public TablerTabsPanel Title(string title) {
        PrivateTitle = title;
        return this;
    }

    /// <summary>
    /// Set the panel to be active, while allowing to use the non-default value
    /// </summary>
    /// <param name="isActive"></param>
    /// <returns></returns>
    public TablerTabsPanel Active(bool isActive = true) {
        IsActive = isActive;
        return this;
    }

    /// <summary>
    /// Set the panel to be disabled
    /// </summary>
    /// <returns></returns>
    public TablerTabsPanel Disabled() {
        IsDisabled = true;
        return this;
    }

    /// <summary>
    /// Move the tabs to a specific state
    /// </summary>
    /// <param name="state"></param>
    /// <returns></returns>
    public TablerTabsPanel MoveTabs(TabState state) {
        PrivateTabState = state;
        return this;
    }

    public override string ToString() {
        var panelDiv = new HtmlTag("div")
            .Class("tab-pane")
            .Class(IsActive ? "active show" : "")
            .Id(Id);

        // Convert child elements to string and add them to the panelDiv
        foreach (var child in Children.WhereNotNull()) {
            panelDiv.Value(child);
        }

        return panelDiv.ToString();
    }
}