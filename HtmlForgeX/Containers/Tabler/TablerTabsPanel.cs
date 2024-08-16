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

    public TablerTabsPanel Active() {
        IsActive = true;
        return this;
    }

    public TablerTabsPanel Disabled() {
        IsDisabled = true;
        return this;
    }

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
        foreach (var child in Children) {
            panelDiv.Value(child.ToString());
        }

        return panelDiv.ToString();
    }
}