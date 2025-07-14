using System.Linq;

using HtmlForgeX.Extensions;

namespace HtmlForgeX;

public class TablerForm : Element {
    /// <summary>
    /// Initializes or configures Input.
    /// </summary>
    public TablerInput Input(string name, Action<TablerInput>? config = null) {
        var input = new TablerInput(name);
        config?.Invoke(input);
        this.Add(input);
        return input;
    }

    /// <summary>
    /// Initializes or configures Select.
    /// </summary>
    public TablerSelect Select(string name, Action<TablerSelect>? config = null) {
        var select = new TablerSelect(name);
        config?.Invoke(select);
        this.Add(select);
        return select;
    }

    /// <summary>
    /// Initializes or configures InputMask.
    /// </summary>
    public TablerInputMask InputMask(string name, Action<TablerInputMask>? config = null) {
        var mask = new TablerInputMask(name);
        config?.Invoke(mask);
        this.Add(mask);
        return mask;
    }

    /// <summary>
    /// Initializes or configures ToString.
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