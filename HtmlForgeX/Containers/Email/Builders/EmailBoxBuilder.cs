namespace HtmlForgeX;

/// <summary>
/// Fluent builder for configuring <see cref="EmailBox"/> instances.
/// The builder mirrors the fluent setters on <see cref="EmailBox"/>, but allows
/// configuration to happen separately from the object itself. This can be
/// useful when constructing boxes via lambdas using <c>Element.EmailBox</c> or
/// when you want to pass configuration around without exposing the underlying
/// element instance.
/// </summary>
public class EmailBoxBuilder
{
    private readonly EmailBox _box = new EmailBox();

    /// <summary>
    /// Sets the padding of the email box.
    /// </summary>
    public EmailBoxBuilder WithPadding(string padding)
    {
        _box.SetPadding(padding);
        return this;
    }

    /// <summary>
    /// Sets the background color of the email box.
    /// </summary>
    public EmailBoxBuilder WithBackground(string color)
    {
        _box.SetBackgroundColor(color);
        return this;
    }

    /// <summary>
    /// Sets the background color of the email box.
    /// </summary>
    public EmailBoxBuilder WithBackground(RGBColor color)
    {
        _box.SetBackgroundColor(color);
        return this;
    }

    /// <summary>
    /// Sets the border radius of the email box.
    /// </summary>
    public EmailBoxBuilder WithBorderRadius(string radius)
    {
        _box.SetBorderRadius(radius);
        return this;
    }

    /// <summary>
    /// Sets the border color of the email box.
    /// </summary>
    public EmailBoxBuilder WithBorderColor(string color)
    {
        _box.SetBorderColor(color);
        return this;
    }

    /// <summary>
    /// Gets the configured <see cref="EmailBox"/> instance.
    /// </summary>
    public EmailBox Build() => _box;
}
