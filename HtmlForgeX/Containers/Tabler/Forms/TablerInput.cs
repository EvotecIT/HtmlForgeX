using System;

using HtmlForgeX.Extensions;

namespace HtmlForgeX;

public class TablerInput : Element {
    private readonly string _name;
    private InputType _type = InputType.Text;
    private string? _label;
    private string? _placeholder;
    private bool _required;
    private TablerIconType? _icon;
    private ValidationState? _state;
    private string? _message;

    /// <summary>
    /// Initializes or configures TablerInput.
    /// </summary>
    public TablerInput(string name) {
        _name = name;
    }

    /// <summary>
    /// Sets the HTML <c>type</c> attribute for the input element.
    /// </summary>
    /// <param name="type">The input type to use.</param>
    /// <returns>The current <see cref="TablerInput"/> instance.</returns>
    public TablerInput Type(InputType type) { _type = type; return this; }
    /// <summary>
    /// Sets the label text displayed above the input.
    /// </summary>
    /// <param name="text">The label text.</param>
    /// <returns>The current <see cref="TablerInput"/> instance.</returns>
    public TablerInput Label(string text) { _label = text; return this; }
    /// <summary>
    /// Sets the placeholder text for the input element.
    /// </summary>
    /// <param name="text">The placeholder text.</param>
    /// <returns>The current <see cref="TablerInput"/> instance.</returns>
    public TablerInput Placeholder(string text) { _placeholder = text; return this; }
    /// <summary>
    /// Marks the input as required.
    /// </summary>
    /// <param name="required">Whether the input is required.</param>
    /// <returns>The current <see cref="TablerInput"/> instance.</returns>
    public TablerInput Required(bool required = true) { _required = required; return this; }
    /// <summary>
    /// Adds an icon to the input element.
    /// </summary>
    /// <param name="icon">Icon to display inside the input.</param>
    /// <returns>The current <see cref="TablerInput"/> instance.</returns>
    public TablerInput Icon(TablerIconType icon) { _icon = icon; return this; }
    /// <summary>
    /// Sets validation state and message for the input element.
    /// </summary>
    /// <param name="state">Validation state.</param>
    /// <param name="message">Message shown below the input.</param>
    /// <returns>The current <see cref="TablerInput"/> instance.</returns>
    public TablerInput Validation(ValidationState state, string message) { _state = state; _message = message; return this; }

    /// <summary>
    /// Generates the HTML markup for the input element and its wrapper.
    /// </summary>
    public override string ToString() {
        var wrapper = new HtmlTag("div").Class("mb-3");
        if (!string.IsNullOrEmpty(_label)) {
            wrapper.Value(new HtmlTag("label").Class("form-label").Attribute("for", _name).Value(_label));
        }
        var input = new HtmlTag("input")
            .Class("form-control")
            .Attribute("type", _type.ToInputString())
            .Id(_name)
            .Attribute("name", _name);
        if (!string.IsNullOrEmpty(_placeholder)) input.Attribute("placeholder", _placeholder);
        if (_required) input.Attribute("required", "required");
        if (_state != null) input.Class(_state.Value.ToInputClass());

        if (_icon != null) {
            var iconWrap = new HtmlTag("div").Class("input-icon mb-3");
            iconWrap.Value(input);
            iconWrap.Value(new HtmlTag("span").Class("input-icon-addon").Value(new TablerIconElement(_icon.Value)));
            wrapper.Value(iconWrap);
        } else {
            wrapper.Value(input);
        }
        if (_state != null && !string.IsNullOrEmpty(_message)) {
            wrapper.Value(new HtmlTag("div").Class(_state.Value.ToFeedbackClass()).Value(_message));
        }
        return wrapper.ToString();
    }
}