namespace HtmlForgeX;

/// <summary>
/// Extension methods for SmartTab integration.
/// </summary>
public static class SmartTabExtensions {
    /// <summary>
    /// Adds a SmartTab component to the element.
    /// </summary>
    /// <param name="element">The element to add the SmartTab to.</param>
    /// <param name="configure">Configuration action for the SmartTab.</param>
    /// <returns>The SmartTab instance for further configuration.</returns>
    public static SmartTab SmartTab(this Element element, Action<SmartTab>? configure = null) {
        var smartTab = new SmartTab();
        configure?.Invoke(smartTab);
        element.Add(smartTab);
        return smartTab;
    }

    /// <summary>
    /// Adds a SmartTab component to the element container.
    /// </summary>
    /// <param name="container">The container to add the SmartTab to.</param>
    /// <param name="configure">Configuration action for the SmartTab.</param>
    /// <returns>The SmartTab instance for further configuration.</returns>
    public static SmartTab SmartTab(this ElementContainer container, Action<SmartTab>? configure = null) {
        var smartTab = new SmartTab();
        configure?.Invoke(smartTab);
        container.Add(smartTab);
        return smartTab;
    }

    /// <summary>
    /// Adds a SmartTab component to a Tabler card.
    /// </summary>
    /// <param name="card">The card to add the SmartTab to.</param>
    /// <param name="configure">Configuration action for the SmartTab.</param>
    /// <returns>The SmartTab instance for further configuration.</returns>
    public static SmartTab SmartTab(this TablerCard card, Action<SmartTab>? configure = null) {
        var smartTab = new SmartTab();
        configure?.Invoke(smartTab);
        card.Add(smartTab);
        return smartTab;
    }

    /// <summary>
    /// Adds a SmartTab component to a Tabler card body.
    /// </summary>
    /// <param name="cardBody">The card body to add the SmartTab to.</param>
    /// <param name="configure">Configuration action for the SmartTab.</param>
    /// <returns>The SmartTab instance for further configuration.</returns>
    public static SmartTab SmartTab(this TablerCardBody cardBody, Action<SmartTab>? configure = null) {
        var smartTab = new SmartTab();
        configure?.Invoke(smartTab);
        cardBody.Add(smartTab);
        return smartTab;
    }

    /// <summary>
    /// Adds a SmartTab component to a Tabler column.
    /// </summary>
    /// <param name="column">The column to add the SmartTab to.</param>
    /// <param name="configure">Configuration action for the SmartTab.</param>
    /// <returns>The SmartTab instance for further configuration.</returns>
    public static SmartTab SmartTab(this TablerColumn column, Action<SmartTab>? configure = null) {
        var smartTab = new SmartTab();
        configure?.Invoke(smartTab);
        column.Add(smartTab);
        return smartTab;
    }

    /// <summary>
    /// Adds a SmartTab component to a SmartTab panel (nested tabs).
    /// </summary>
    /// <param name="panel">The panel to add the SmartTab to.</param>
    /// <param name="configure">Configuration action for the SmartTab.</param>
    /// <returns>The SmartTab instance for further configuration.</returns>
    public static SmartTab SmartTab(this SmartTabPanel panel, Action<SmartTab>? configure = null) {
        var smartTab = new SmartTab();
        configure?.Invoke(smartTab);
        panel.Add(smartTab);
        return smartTab;
    }

    /// <summary>
    /// Adds a SmartTab component to a SmartWizard step (tabs in wizard steps).
    /// </summary>
    /// <param name="step">The step to add the SmartTab to.</param>
    /// <param name="configure">Configuration action for the SmartTab.</param>
    /// <returns>The SmartTab instance for further configuration.</returns>
    public static SmartTab SmartTab(this SmartWizardStep step, Action<SmartTab>? configure = null) {
        var smartTab = new SmartTab();
        configure?.Invoke(smartTab);
        step.Add(smartTab);
        return smartTab;
    }
}