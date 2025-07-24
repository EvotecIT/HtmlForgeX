using System.Collections.Generic;
using System.Linq;

using HtmlForgeX.Extensions;

namespace HtmlForgeX;

/// <summary>
/// Container for grouping multiple checkbox elements.
/// </summary>
public class TablerCheckboxGroup : Element {
    private readonly string _name;
    private string? _label;
    private readonly List<CheckboxOption> _options = new();
    private bool _inline;

    /// <summary>
    /// Initializes the checkbox group with the specified name.
    /// </summary>
    public TablerCheckboxGroup(string name) {
        _name = name;
    }

    /// <summary>
    /// Sets the label for the checkbox group.
    /// </summary>
    /// <param name="text">The label text.</param>
    /// <returns>The current <see cref="TablerCheckboxGroup"/> instance.</returns>
    public TablerCheckboxGroup Label(string text) { _label = text; return this; }

    /// <summary>
    /// Adds checkbox options from string values.
    /// </summary>
    /// <param name="options">Array of option values.</param>
    /// <returns>The current <see cref="TablerCheckboxGroup"/> instance.</returns>
    public TablerCheckboxGroup Options(params string[] options) {
        foreach (var option in options) {
            _options.Add(new CheckboxOption { Value = option, Label = option });
        }
        return this;
    }

    /// <summary>
    /// Adds a checkbox option with specific configuration.
    /// </summary>
    /// <param name="value">The checkbox value.</param>
    /// <param name="label">The display label.</param>
    /// <param name="checked">Whether the option is checked.</param>
    /// <param name="disabled">Whether the option is disabled.</param>
    /// <returns>The current <see cref="TablerCheckboxGroup"/> instance.</returns>
    public TablerCheckboxGroup Option(string value, string label, bool @checked = false, bool disabled = false) {
        _options.Add(new CheckboxOption { Value = value, Label = label, Checked = @checked, Disabled = disabled });
        return this;
    }

    /// <summary>
    /// Sets whether checkboxes should be displayed inline.
    /// </summary>
    /// <param name="inline">Whether checkboxes are inline.</param>
    /// <returns>The current <see cref="TablerCheckboxGroup"/> instance.</returns>
    public TablerCheckboxGroup Inline(bool inline = true) { _inline = inline; return this; }

    /// <summary>
    /// Generates the HTML markup for the checkbox group.
    /// </summary>
    public override string ToString() {
        var wrapper = new HtmlTag("div").Class("mb-3");

        if (!string.IsNullOrEmpty(_label)) {
            wrapper.Value(new HtmlTag("div").Class("form-label").Value(_label));
        }

        var container = new HtmlTag("div");

        foreach (var option in _options) {
            var checkbox = new TablerCheckbox($"{_name}[]")
                .Label(option.Label)
                .Checked(option.Checked)
                .Disabled(option.Disabled)
                .Inline(_inline);

            container.Value(checkbox);
        }

        wrapper.Value(container);
        return wrapper.ToString();
    }

    private class CheckboxOption {
        public string Value { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public bool Checked { get; set; }
        public bool Disabled { get; set; }
    }
}