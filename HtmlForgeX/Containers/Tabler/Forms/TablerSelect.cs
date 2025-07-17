using System.Collections.Generic;
using System.Linq;

namespace HtmlForgeX;

/// <summary>
/// Dropdown/select element styled for the Tabler framework.
/// </summary>
public class TablerSelect : Element {
    private readonly string _name;
    private string? _label;
    private bool _multiple;
    private bool _searchable;
    private bool _required;
    private readonly List<(string Value, string Text)> _options = new();

    /// <summary>
    /// Initializes or configures TablerSelect.
    /// </summary>
    public TablerSelect(string name) {
        _name = name;
    }

    /// <summary>
    /// Sets the label text displayed above the select element.
    /// </summary>
    /// <param name="text">The label text.</param>
    /// <returns>The current <see cref="TablerSelect"/> instance.</returns>
    public TablerSelect Label(string text) { _label = text; return this; }
    /// <summary>
    /// Allows multiple items to be selected.
    /// </summary>
    /// <param name="multiple">Whether multiple selection is enabled.</param>
    /// <returns>The current <see cref="TablerSelect"/> instance.</returns>
    public TablerSelect Multiple(bool multiple = true) { _multiple = multiple; return this; }
    /// <summary>
    /// Enables client-side search functionality for the select element.
    /// </summary>
    /// <param name="enable">Whether search should be enabled.</param>
    /// <returns>The current <see cref="TablerSelect"/> instance.</returns>
    public TablerSelect Searchable(bool enable = true) { _searchable = enable; return this; }
    /// <summary>
    /// Marks the select as required.
    /// </summary>
    /// <param name="required">Whether the select is required.</param>
    /// <returns>The current <see cref="TablerSelect"/> instance.</returns>
    public TablerSelect Required(bool required = true) { _required = required; return this; }
    /// <summary>
    /// Adds a selectable option.
    /// </summary>
    /// <param name="text">Display text for the option.</param>
    /// <param name="value">Value submitted when the option is selected.</param>
    /// <returns>The current <see cref="TablerSelect"/> instance.</returns>
    public TablerSelect Option(string text, string value) { _options.Add((value, text)); return this; }
    /// <summary>
    /// Adds multiple options based on the provided collection of values.
    /// </summary>
    /// <param name="values">Values to use for both option text and value.</param>
    /// <returns>The current <see cref="TablerSelect"/> instance.</returns>
    public TablerSelect Options(IEnumerable<string> values) {
        foreach (var v in values) { _options.Add((v, v)); }
        return this;
    }

    /// <summary>
    /// Registers any required JavaScript libraries for enhanced select controls.
    /// </summary>
    protected internal override void RegisterLibraries() {
        if (_searchable) {
            Document?.AddLibrary(Libraries.TomSelect);
        }
    }

    /// <summary>
    /// Generates the HTML markup for the select element and associated script.
    /// </summary>
    public override string ToString() {
        var wrapper = new HtmlTag("div").Class("mb-3");
        if (!string.IsNullOrEmpty(_label)) {
            wrapper.Value(new HtmlTag("label").Class("form-label").Attribute("for", _name).Value(_label));
        }
        var select = new HtmlTag("select")
            .Class("form-select")
            .Id(_name)
            .Attribute("name", _name);
        if (_multiple) select.Attribute("multiple", "multiple");
        if (_required) select.Attribute("required", "required");
        foreach (var opt in _options) {
            select.Value(new HtmlTag("option").Attribute("value", opt.Value).Value(opt.Text));
        }
        wrapper.Value(select);
        if (_searchable) {
            var script = new HtmlTag("script").Value($"document.addEventListener('DOMContentLoaded',function(){{new TomSelect('#{_name}');}});");
            wrapper.Value(script);
        }
        return wrapper.ToString();
    }
}