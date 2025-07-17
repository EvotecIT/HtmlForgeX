using System.Linq;

using HtmlForgeX.Extensions;

namespace HtmlForgeX;

/// <summary>
/// Form container that provides fluent APIs for building Tabler forms.
/// </summary>
public class TablerForm : Element {
    /// <summary>
    /// Adds a standard input element to the form.
    /// </summary>
    /// <param name="name">Name and identifier of the input.</param>
    /// <param name="config">Optional configuration callback.</param>
    /// <returns>The created <see cref="TablerInput"/>.</returns>
    public TablerInput Input(string name, Action<TablerInput>? config = null) {
        var input = new TablerInput(name);
        config?.Invoke(input);
        this.Add(input);
        return input;
    }

    /// <summary>
    /// Adds a select element to the form.
    /// </summary>
    /// <param name="name">Name and identifier of the select.</param>
    /// <param name="config">Optional configuration callback.</param>
    /// <returns>The created <see cref="TablerSelect"/>.</returns>
    public TablerSelect Select(string name, Action<TablerSelect>? config = null) {
        var select = new TablerSelect(name);
        config?.Invoke(select);
        this.Add(select);
        return select;
    }

    /// <summary>
    /// Adds an input mask element to the form.
    /// </summary>
    /// <param name="name">Name and identifier of the mask.</param>
    /// <param name="config">Optional configuration callback.</param>
    /// <returns>The created <see cref="TablerInputMask"/>.</returns>
    public TablerInputMask InputMask(string name, Action<TablerInputMask>? config = null) {
        var mask = new TablerInputMask(name);
        config?.Invoke(mask);
        this.Add(mask);
        return mask;
    }

    /// <summary>
    /// Adds a rich text editor element to the form.
    /// </summary>
    /// <param name="name">Name and identifier of the editor.</param>
    /// <param name="config">Optional configuration callback.</param>
    /// <returns>The created <see cref="TablerWysiwygEditor"/>.</returns>
    public TablerWysiwygEditor Wysiwyg(string name, Action<TablerWysiwygEditor>? config = null) {
        var editor = new TablerWysiwygEditor(name);
        config?.Invoke(editor);
        this.Add(editor);
        return editor;
    }

    /// <summary>
    /// Adds a textarea element to the form.
    /// </summary>
    /// <param name="name">Name and identifier of the textarea.</param>
    /// <param name="config">Optional configuration callback.</param>
    /// <returns>The created <see cref="TablerTextarea"/>.</returns>
    public TablerTextarea Textarea(string name, Action<TablerTextarea>? config = null) {
        var textarea = new TablerTextarea(name);
        config?.Invoke(textarea);
        this.Add(textarea);
        return textarea;
    }

    /// <summary>
    /// Adds a checkbox element to the form.
    /// </summary>
    /// <param name="name">Name and identifier of the checkbox.</param>
    /// <param name="config">Optional configuration callback.</param>
    /// <returns>The created <see cref="TablerCheckbox"/>.</returns>
    public TablerCheckbox Checkbox(string name, Action<TablerCheckbox>? config = null) {
        var checkbox = new TablerCheckbox(name);
        config?.Invoke(checkbox);
        this.Add(checkbox);
        return checkbox;
    }

    /// <summary>
    /// Adds a checkbox group to the form.
    /// </summary>
    /// <param name="name">Name and identifier of the checkbox group.</param>
    /// <param name="config">Optional configuration callback.</param>
    /// <returns>The created <see cref="TablerCheckboxGroup"/>.</returns>
    public TablerCheckboxGroup CheckboxGroup(string name, Action<TablerCheckboxGroup>? config = null) {
        var group = new TablerCheckboxGroup(name);
        config?.Invoke(group);
        this.Add(group);
        return group;
    }

    /// <summary>
    /// Adds a radio button element to the form.
    /// </summary>
    /// <param name="name">Name of the radio button group.</param>
    /// <param name="value">Value of this radio button.</param>
    /// <param name="config">Optional configuration callback.</param>
    /// <returns>The created <see cref="TablerRadio"/>.</returns>
    public TablerRadio Radio(string name, string value, Action<TablerRadio>? config = null) {
        var radio = new TablerRadio(name, value);
        config?.Invoke(radio);
        this.Add(radio);
        return radio;
    }

    /// <summary>
    /// Adds a radio button group to the form.
    /// </summary>
    /// <param name="name">Name and identifier of the radio group.</param>
    /// <param name="config">Optional configuration callback.</param>
    /// <returns>The created <see cref="TablerRadioGroup"/>.</returns>
    public TablerRadioGroup RadioGroup(string name, Action<TablerRadioGroup>? config = null) {
        var group = new TablerRadioGroup(name);
        config?.Invoke(group);
        this.Add(group);
        return group;
    }

    /// <summary>
    /// Adds a toggle switch element to the form.
    /// </summary>
    /// <param name="name">Name and identifier of the switch.</param>
    /// <param name="config">Optional configuration callback.</param>
    /// <returns>The created <see cref="TablerSwitch"/>.</returns>
    public TablerSwitch Switch(string name, Action<TablerSwitch>? config = null) {
        var switchElement = new TablerSwitch(name);
        config?.Invoke(switchElement);
        this.Add(switchElement);
        return switchElement;
    }

    /// <summary>
    /// Generates the HTML markup for the form and its child elements.
    /// </summary>
    public override string ToString() {
        var form = new HtmlTag("form").Class("card");
        var body = new HtmlTag("div").Class("card-body");
        foreach (var child in Children.WhereNotNull()) {
            body.Value(child);
        }
        form.Value(body);
        return form.ToString();
    }
}