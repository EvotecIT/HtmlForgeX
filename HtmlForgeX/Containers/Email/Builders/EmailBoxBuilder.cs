namespace HtmlForgeX;

/// <summary>
    /// Fluent builder for configuring <see cref="EmailBox"/> instances.
    /// Use the builder when you want to configure a box separately from where it
    /// is created, e.g. inside lambdas passed to <c>Element.EmailBox</c>, or when
    /// you need to reuse a configuration in multiple places. For immediate
    /// inline configuration you can call the <see cref="EmailBox"/> methods
    /// directly.
/// </summary>
public class EmailBoxBuilder
{
    private readonly EmailBox _box = new EmailBox();

    /// <summary>
    /// Sets the padding of the email box.
    /// </summary>
    public EmailBoxBuilder WithPadding(string padding)
    {
        _box.WithPadding(padding);
        return this;
    }

    /// <summary>
    /// Sets the background color of the email box.
    /// </summary>
    public EmailBoxBuilder WithBackground(string color)
    {
        _box.WithBackground(color);
        return this;
    }

    /// <summary>
    /// Sets the background color of the email box.
    /// </summary>
    public EmailBoxBuilder WithBackground(RGBColor color)
    {
        _box.WithBackground(color);
        return this;
    }

    /// <summary>
    /// Sets the border radius of the email box.
    /// </summary>
    public EmailBoxBuilder WithBorderRadius(string radius)
    {
        _box.WithBorderRadius(radius);
        return this;
    }

    /// <summary>
    /// Sets the border color of the email box.
    /// </summary>
    public EmailBoxBuilder WithBorderColor(string color)
    {
        _box.WithBorderColor(color);
        return this;
    }

    /// <summary>
    /// Gets the configured <see cref="EmailBox"/> instance.
    /// </summary>
    public EmailBox Build() => _box;
}
