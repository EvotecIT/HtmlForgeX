namespace HtmlForgeX;

/// <summary>
/// Horizontal divider with optional text using Tabler styling.
/// </summary>
public class TablerDivider : Element {
    private string Text { get; }
    private HrTextAlignment Alignment { get; }
    private TablerColor Color { get; }

    /// <summary>
    /// Initializes or configures TablerDivider.
    /// </summary>
    public TablerDivider(string text, HrTextAlignment alignment = HrTextAlignment.Center, TablerColor color = TablerColor.Default) {
        Text = text;
        Alignment = alignment;
        Color = color;
    }

    /// <summary>
    /// Initializes or configures ToString.
    /// </summary>
    public override string ToString() {
        var alignmentClass = Alignment.ToClassString();
        var colorClass = Color.ToTablerText();

        var dividerTag = new HtmlTag("div")
            .Class("hr-text")
            .Class(alignmentClass)
            .Class(colorClass)
            .Value(Text);

        return dividerTag.ToString();
    }
}