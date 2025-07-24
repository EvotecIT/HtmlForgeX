namespace HtmlForgeX;

/// <summary>
/// Toggle switch element styled with Tabler classes.
/// </summary>
public class TablerSwitch : Element {
    private readonly string _name;
    private string? _label;
    private bool _checked;
    private bool _disabled;
    private SwitchSize _size = SwitchSize.Default;

    /// <summary>
    /// Initializes the switch with the specified name.
    /// </summary>
    public TablerSwitch(string name) {
        _name = name;
    }

    /// <summary>
    /// Sets the label text displayed next to the switch.
    /// </summary>
    /// <param name="text">The label text.</param>
    /// <returns>The current <see cref="TablerSwitch"/> instance.</returns>
    public TablerSwitch Label(string text) { _label = text; return this; }

    /// <summary>
    /// Sets whether the switch is checked by default.
    /// </summary>
    /// <param name="checked">Whether the switch is checked.</param>
    /// <returns>The current <see cref="TablerSwitch"/> instance.</returns>
    public TablerSwitch Checked(bool @checked = true) { _checked = @checked; return this; }

    /// <summary>
    /// Sets whether the switch is disabled.
    /// </summary>
    /// <param name="disabled">Whether the switch is disabled.</param>
    /// <returns>The current <see cref="TablerSwitch"/> instance.</returns>
    public TablerSwitch Disabled(bool disabled = true) { _disabled = disabled; return this; }

    /// <summary>
    /// Sets the size of the switch.
    /// </summary>
    /// <param name="size">The switch size.</param>
    /// <returns>The current <see cref="TablerSwitch"/> instance.</returns>
    public TablerSwitch Size(SwitchSize size) { _size = size; return this; }

    /// <summary>
    /// Generates the HTML markup for the switch element.
    /// </summary>
    public override string ToString() {
        var wrapper = new HtmlTag("label").Class("form-check form-switch");

        if (_size != SwitchSize.Default) {
            wrapper.Class($"form-switch-{(int)_size}");
        }

        var input = new HtmlTag("input")
            .Class("form-check-input")
            .Attribute("type", "checkbox")
            .Id(_name)
            .Attribute("name", _name);

        if (_checked) input.Attribute("checked", "checked");
        if (_disabled) input.Attribute("disabled", "disabled");

        wrapper.Value(input);

        if (!string.IsNullOrEmpty(_label)) {
            wrapper.Value(new HtmlTag("span").Class("form-check-label").Value(_label));
        }

        return wrapper.ToString();
    }
}

/// <summary>
/// Defines available switch sizes.
/// </summary>
public enum SwitchSize {
    /// <summary>Default switch size.</summary>
    Default = 0,
    /// <summary>Small switch size.</summary>
    Small = 1,
    /// <summary>Medium switch size.</summary>
    Medium = 2,
    /// <summary>Large switch size.</summary>
    Large = 3
}