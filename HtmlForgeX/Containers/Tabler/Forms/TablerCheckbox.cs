namespace HtmlForgeX;

/// <summary>
/// Checkbox input element styled with Tabler classes.
/// </summary>
public class TablerCheckbox : Element {
    private readonly string _name;
    private string? _label;
    private string? _description;
    private bool _checked;
    private bool _disabled;
    private bool _required;
    private bool _inline;

    /// <summary>
    /// Initializes the checkbox with the specified name.
    /// </summary>
    public TablerCheckbox(string name) {
        _name = name;
    }

    /// <summary>
    /// Sets the label text displayed next to the checkbox.
    /// </summary>
    /// <param name="text">The label text.</param>
    /// <returns>The current <see cref="TablerCheckbox"/> instance.</returns>
    public TablerCheckbox Label(string text) { _label = text; return this; }

    /// <summary>
    /// Sets the description text displayed below the label.
    /// </summary>
    /// <param name="text">The description text.</param>
    /// <returns>The current <see cref="TablerCheckbox"/> instance.</returns>
    public TablerCheckbox Description(string text) { _description = text; return this; }

    /// <summary>
    /// Sets whether the checkbox is checked by default.
    /// </summary>
    /// <param name="checked">Whether the checkbox is checked.</param>
    /// <returns>The current <see cref="TablerCheckbox"/> instance.</returns>
    public TablerCheckbox Checked(bool @checked = true) { _checked = @checked; return this; }

    /// <summary>
    /// Sets whether the checkbox is disabled.
    /// </summary>
    /// <param name="disabled">Whether the checkbox is disabled.</param>
    /// <returns>The current <see cref="TablerCheckbox"/> instance.</returns>
    public TablerCheckbox Disabled(bool disabled = true) { _disabled = disabled; return this; }

    /// <summary>
    /// Marks the checkbox as required.
    /// </summary>
    /// <param name="required">Whether the checkbox is required.</param>
    /// <returns>The current <see cref="TablerCheckbox"/> instance.</returns>
    public TablerCheckbox Required(bool required = true) { _required = required; return this; }

    /// <summary>
    /// Sets whether the checkbox should be displayed inline.
    /// </summary>
    /// <param name="inline">Whether the checkbox is inline.</param>
    /// <returns>The current <see cref="TablerCheckbox"/> instance.</returns>
    public TablerCheckbox Inline(bool inline = true) { _inline = inline; return this; }

    /// <summary>
    /// Generates the HTML markup for the checkbox element.
    /// </summary>
    public override string ToString() {
        var wrapper = new HtmlTag("label").Class("form-check");
        if (_inline) wrapper.Class("form-check-inline");

        var input = new HtmlTag("input")
            .Class("form-check-input")
            .Attribute("type", "checkbox")
            .Id(_name)
            .Attribute("name", _name);
        
        if (_checked) input.Attribute("checked", "checked");
        if (_disabled) input.Attribute("disabled", "disabled");
        if (_required) input.Attribute("required", "required");
        
        wrapper.Value(input);
        
        if (!string.IsNullOrEmpty(_label)) {
            var span = new HtmlTag("span").Class("form-check-label");
            if (_required) span.Class("required");
            span.Value(_label);
            wrapper.Value(span);
        }
        
        if (!string.IsNullOrEmpty(_description)) {
            wrapper.Value(new HtmlTag("span").Class("form-check-description").Value(_description));
        }
        
        return wrapper.ToString();
    }
}