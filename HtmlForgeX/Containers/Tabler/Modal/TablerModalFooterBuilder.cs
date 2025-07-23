namespace HtmlForgeX;

/// <summary>
/// Builder for configuring modal footer content without exposing raw HTML.
/// </summary>
public class TablerModalFooterBuilder {
    private readonly ElementContainer container;
    private readonly Document? document;

    /// <summary>
    /// Initializes a new instance of the <see cref="TablerModalFooterBuilder"/> class.
    /// </summary>
    /// <param name="container">Container that will hold footer elements.</param>
    /// <param name="document">Optional document reference used when adding elements.</param>
    public TablerModalFooterBuilder(ElementContainer container, Document? document) {
        this.container = container;
        this.document = document;
    }

    /// <summary>
    /// Adds a button to the footer.
    /// </summary>
    /// <param name="text">Button text.</param>
    /// <param name="color">Button color.</param>
    /// <param name="config">Optional additional configuration.</param>
    /// <returns>A chain object for further configuration.</returns>
    public TablerModalFooterButtonChain Button(string text, TablerColor color, Action<TablerModalButton>? config = null) {
        var button = new TablerModalButton(text, color);
        config?.Invoke(button);
        if (document != null) {
            button.Document = document;
            button.OnAddedToDocument();
        }
        container.Add(button);
        return new TablerModalFooterButtonChain(this, button);
    }
}

/// <summary>
/// Chain object returned after adding a button to the footer.
/// Allows calling methods like <c>Dismiss</c> or <c>Submit</c> fluently.
/// </summary>
public class TablerModalFooterButtonChain {
    private readonly TablerModalFooterBuilder parent;
    private readonly TablerModalButton button;

    internal TablerModalFooterButtonChain(TablerModalFooterBuilder parent, TablerModalButton button) {
        this.parent = parent;
        this.button = button;
    }

    /// <summary>
    /// Marks the previously added button as a dismiss button.
    /// </summary>
    /// <returns>The parent builder.</returns>
    public TablerModalFooterBuilder Dismiss() {
        button.Dismiss();
        return parent;
    }

    /// <summary>
    /// Marks the previously added button as a submit button.
    /// </summary>
    /// <returns>The parent builder.</returns>
    public TablerModalFooterBuilder Submit() {
        button.Submit();
        return parent;
    }
}
