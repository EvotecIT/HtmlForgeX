namespace HtmlForgeX;

/// <summary>
/// Represents a button within a <see cref="TablerModal"/> footer.
/// </summary>
public class TablerModalButton : Element {
    private bool dismiss;
    private bool submit;

    /// <summary>
    /// Initializes a new instance of the <see cref="TablerModalButton"/> class.
    /// </summary>
    /// <param name="text">Button text.</param>
    /// <param name="color">Button color.</param>
    public TablerModalButton(string text, TablerColor color) {
        Text = text;
        Color = color;
    }

    /// <summary>Button label text.</summary>
    public new string Text { get; set; }

    /// <summary>Visual color of the button.</summary>
    public TablerColor Color { get; set; }

    /// <summary>
    /// Marks this button as dismissing the modal.
    /// </summary>
    public TablerModalButton Dismiss() {
        dismiss = true;
        return this;
    }

    /// <summary>
    /// Marks this button as submitting the modal form.
    /// </summary>
    public TablerModalButton Submit() {
        submit = true;
        return this;
    }

    /// <inheritdoc />
    public override string ToString() {
        var btn = new HtmlTag("a")
            .Class("btn")
            .Class($"btn-{Color.ToTablerString()}")
            .Attribute("href", "#");

        if (dismiss) {
            btn.Attribute("data-bs-dismiss", "modal");
        }

        if (submit) {
            btn.Attribute("type", "submit");
            // Typically submit buttons also dismiss the modal
            if (!dismiss) {
                btn.Attribute("data-bs-dismiss", "modal");
            }
            btn.Class("ms-auto");
        }

        btn.Value(Text);
        return btn.ToString();
    }
}
