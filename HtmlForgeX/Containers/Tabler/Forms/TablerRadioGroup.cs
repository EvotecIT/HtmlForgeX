using System.Collections.Generic;
using System.Linq;

using HtmlForgeX.Extensions;

namespace HtmlForgeX;

/// <summary>
/// Container for grouping multiple radio button elements.
/// </summary>
public class TablerRadioGroup : Element {
    private readonly string _name;
    private string? _label;
    private readonly List<RadioOption> _options = new();
    private bool _inline;

    /// <summary>
    /// Initializes the radio group with the specified name.
    /// </summary>
    public TablerRadioGroup(string name) {
        _name = name;
    }

    /// <summary>
    /// Sets the label for the radio group.
    /// </summary>
    /// <param name="text">The label text.</param>
    /// <returns>The current <see cref="TablerRadioGroup"/> instance.</returns>
    public TablerRadioGroup Label(string text) { _label = text; return this; }

    /// <summary>
    /// Adds radio options from string values.
    /// </summary>
    /// <param name="options">Array of option values.</param>
    /// <returns>The current <see cref="TablerRadioGroup"/> instance.</returns>
    public TablerRadioGroup Options(params string[] options) {
        foreach (var option in options) {
            _options.Add(new RadioOption { Value = option, Label = option });
        }
        return this;
    }

    /// <summary>
    /// Adds a radio option with specific configuration.
    /// </summary>
    /// <param name="value">The radio value.</param>
    /// <param name="label">The display label.</param>
    /// <param name="checked">Whether the option is checked.</param>
    /// <param name="disabled">Whether the option is disabled.</param>
    /// <returns>The current <see cref="TablerRadioGroup"/> instance.</returns>
    public TablerRadioGroup Option(string value, string label, bool @checked = false, bool disabled = false) {
        _options.Add(new RadioOption { Value = value, Label = label, Checked = @checked, Disabled = disabled });
        return this;
    }

    /// <summary>
    /// Sets whether radio buttons should be displayed inline.
    /// </summary>
    /// <param name="inline">Whether radio buttons are inline.</param>
    /// <returns>The current <see cref="TablerRadioGroup"/> instance.</returns>
    public TablerRadioGroup Inline(bool inline = true) { _inline = inline; return this; }

    /// <summary>
    /// Generates the HTML markup for the radio group.
    /// </summary>
    public override string ToString() {
        var wrapper = new HtmlTag("div").Class("mb-3");
        
        if (!string.IsNullOrEmpty(_label)) {
            wrapper.Value(new HtmlTag("div").Class("form-label").Value(_label));
        }
        
        var container = new HtmlTag("div");
        
        foreach (var option in _options) {
            var radio = new TablerRadio(_name, option.Value)
                .Label(option.Label)
                .Checked(option.Checked)
                .Disabled(option.Disabled)
                .Inline(_inline);
            
            container.Value(radio);
        }
        
        wrapper.Value(container);
        return wrapper.ToString();
    }

    private class RadioOption {
        public string Value { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public bool Checked { get; set; }
        public bool Disabled { get; set; }
    }
}