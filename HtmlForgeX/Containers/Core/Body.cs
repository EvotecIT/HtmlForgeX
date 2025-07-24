namespace HtmlForgeX;

/// <summary>
/// Represents the <c>&lt;body&gt;</c> element of an HTML document.
/// </summary>
public partial class Body : Element {

    /// <summary>
    /// Adds a child element to the body.
    /// </summary>
    /// <param name="element">Element to add.</param>
    /// <returns>The current <see cref="Body"/> instance.</returns>
    public new Body Add(Element? element) {
        base.Add(element);
        return this;
    }

    /// <summary>
    /// Executes a build action in the context of the body.
    /// </summary>
    /// <param name="buildAction">Action that configures the body.</param>
    /// <returns>The current <see cref="Body"/> instance.</returns>
    public Body Add(Action<Body> buildAction) {
        buildAction(this);
        return this;
    }
}