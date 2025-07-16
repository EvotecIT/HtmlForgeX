namespace HtmlForgeX;

/// <summary>
/// Extension methods for SmartWizard integration.
/// </summary>
public static class SmartWizardExtensions {
    /// <summary>
    /// Adds a SmartWizard component to the element.
    /// </summary>
    /// <param name="element">The element to add the SmartWizard to.</param>
    /// <param name="configure">Configuration action for the SmartWizard.</param>
    /// <returns>The SmartWizard instance for further configuration.</returns>
    public static SmartWizard SmartWizard(this Element element, Action<SmartWizard>? configure = null) {
        var smartWizard = new SmartWizard();
        configure?.Invoke(smartWizard);
        element.Add(smartWizard);
        return smartWizard;
    }

    /// <summary>
    /// Adds a SmartWizard component to the element container.
    /// </summary>
    /// <param name="container">The container to add the SmartWizard to.</param>
    /// <param name="configure">Configuration action for the SmartWizard.</param>
    /// <returns>The SmartWizard instance for further configuration.</returns>
    public static SmartWizard SmartWizard(this ElementContainer container, Action<SmartWizard>? configure = null) {
        var smartWizard = new SmartWizard();
        configure?.Invoke(smartWizard);
        container.Add(smartWizard);
        return smartWizard;
    }

    /// <summary>
    /// Adds a SmartWizard component to a Tabler card.
    /// </summary>
    /// <param name="card">The card to add the SmartWizard to.</param>
    /// <param name="configure">Configuration action for the SmartWizard.</param>
    /// <returns>The SmartWizard instance for further configuration.</returns>
    public static SmartWizard SmartWizard(this TablerCard card, Action<SmartWizard>? configure = null) {
        var smartWizard = new SmartWizard();
        configure?.Invoke(smartWizard);
        card.Add(smartWizard);
        return smartWizard;
    }

    /// <summary>
    /// Adds a SmartWizard component to a Tabler card body.
    /// </summary>
    /// <param name="cardBody">The card body to add the SmartWizard to.</param>
    /// <param name="configure">Configuration action for the SmartWizard.</param>
    /// <returns>The SmartWizard instance for further configuration.</returns>
    public static SmartWizard SmartWizard(this TablerCardBody cardBody, Action<SmartWizard>? configure = null) {
        var smartWizard = new SmartWizard();
        configure?.Invoke(smartWizard);
        cardBody.Add(smartWizard);
        return smartWizard;
    }

    /// <summary>
    /// Adds a SmartWizard component to a Tabler column.
    /// </summary>
    /// <param name="column">The column to add the SmartWizard to.</param>
    /// <param name="configure">Configuration action for the SmartWizard.</param>
    /// <returns>The SmartWizard instance for further configuration.</returns>
    public static SmartWizard SmartWizard(this TablerColumn column, Action<SmartWizard>? configure = null) {
        var smartWizard = new SmartWizard();
        configure?.Invoke(smartWizard);
        column.Add(smartWizard);
        return smartWizard;
    }

    /// <summary>
    /// Adds a SmartWizard component to a SmartTab panel (wizard in tab).
    /// </summary>
    /// <param name="panel">The panel to add the SmartWizard to.</param>
    /// <param name="configure">Configuration action for the SmartWizard.</param>
    /// <returns>The SmartWizard instance for further configuration.</returns>
    public static SmartWizard SmartWizard(this SmartTabPanel panel, Action<SmartWizard>? configure = null) {
        var smartWizard = new SmartWizard();
        configure?.Invoke(smartWizard);
        panel.Add(smartWizard);
        return smartWizard;
    }

    /// <summary>
    /// Adds a SmartWizard component to a SmartWizard step (nested wizards).
    /// </summary>
    /// <param name="step">The step to add the SmartWizard to.</param>
    /// <param name="configure">Configuration action for the SmartWizard.</param>
    /// <returns>The SmartWizard instance for further configuration.</returns>
    public static SmartWizard SmartWizard(this SmartWizardStep step, Action<SmartWizard>? configure = null) {
        var smartWizard = new SmartWizard();
        configure?.Invoke(smartWizard);
        step.Add(smartWizard);
        return smartWizard;
    }
}