namespace HtmlForgeX;

public class TablerDivider : Element {
    private string Text { get; }
    private HrTextAlignment Alignment { get; }
    private TablerColor Color { get; }

    public TablerDivider(string text, HrTextAlignment alignment = HrTextAlignment.Center, TablerColor color = TablerColor.Default) {
        Text = text;
        Alignment = alignment;
        Color = color;
    }

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
