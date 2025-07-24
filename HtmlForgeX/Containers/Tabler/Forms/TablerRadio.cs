namespace HtmlForgeX;

/// <summary>
/// Radio button input element styled with Tabler classes.
/// </summary>
public class TablerRadio : Element {
    private readonly string _name;
    private readonly string _value;
    private string? _label;
    private string? _description;
    private bool _checked;
    private bool _disabled;
    private bool _inline;

    /// <summary>
    /// Initializes the radio button with the specified name and value.
    /// </summary>
    public TablerRadio(string name, string value) {
        _name = name;
        _value = value;
    }

    /// <summary>
    /// Sets the label text displayed next to the radio button.
    /// </summary>
    /// <param name="text">The label text.</param>
    /// <returns>The current <see cref="TablerRadio"/> instance.</returns>
    public TablerRadio Label(string text) { _label = text; return this; }

    /// <summary>
    /// Sets the description text displayed below the label.
    /// </summary>
    /// <param name="text">The description text.</param>
    /// <returns>The current <see cref="TablerRadio"/> instance.</returns>
    public TablerRadio Description(string text) { _description = text; return this; }

    /// <summary>
    /// Sets whether the radio button is checked by default.
    /// </summary>
    /// <param name="checked">Whether the radio button is checked.</param>
    /// <returns>The current <see cref="TablerRadio"/> instance.</returns>
    public TablerRadio Checked(bool @checked = true) { _checked = @checked; return this; }

    /// <summary>
    /// Sets whether the radio button is disabled.
    /// </summary>
    /// <param name="disabled">Whether the radio button is disabled.</param>
    /// <returns>The current <see cref="TablerRadio"/> instance.</returns>
    public TablerRadio Disabled(bool disabled = true) { _disabled = disabled; return this; }

    /// <summary>
    /// Sets whether the radio button should be displayed inline.
    /// </summary>
    /// <param name="inline">Whether the radio button is inline.</param>
    /// <returns>The current <see cref="TablerRadio"/> instance.</returns>
    public TablerRadio Inline(bool inline = true) { _inline = inline; return this; }

    /// <summary>
    /// Generates the HTML markup for the radio button element.
    /// </summary>
    public override string ToString() {
        var wrapper = new HtmlTag("label").Class("form-check");
        if (_inline) wrapper.Class("form-check-inline");

        var input = new HtmlTag("input")
            .Class("form-check-input")
            .Attribute("type", "radio")
            .Id($"{_name}_{_value}")
            .Attribute("name", _name)
            .Attribute("value", _value);

        if (_checked) input.Attribute("checked", "checked");
        if (_disabled) input.Attribute("disabled", "disabled");

        wrapper.Value(input);

        if (!string.IsNullOrEmpty(_label)) {
            wrapper.Value(new HtmlTag("span").Class("form-check-label").Value(_label));
        }

        if (!string.IsNullOrEmpty(_description)) {
            wrapper.Value(new HtmlTag("span").Class("form-check-description").Value(_description));
        }

        return wrapper.ToString();
    }
}