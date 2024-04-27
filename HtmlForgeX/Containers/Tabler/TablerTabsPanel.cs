namespace HtmlForgeX;


public class TablerTabsPanel : Element {
    internal string Id { get; } = GlobalStorage.GenerateRandomId("tabsPanel");
    internal string PrivateTitle { get; set; }
    private Element ContentElement { get; set; }
    internal bool IsActive { get; set; }
    internal bool IsDisabled { get; set; }
    internal TabState? PrivateTabState { get; set; }


    public TablerTabsPanel Title(string title) {
        PrivateTitle = title;
        return this;
    }

    public TablerTabsPanel Content(Element content) {
        ContentElement = content;
        return this;
    }

    public TablerTabsPanel Content(Action<ElementContainer> content) {
        var contentElement = new ElementContainer();
        content(contentElement);
        ContentElement = contentElement;
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
            .Id(Id)
            .Value(ContentElement);

        return panelDiv.ToString();
    }
}
