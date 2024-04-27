namespace HtmlForgeX;

public class TablerDivider : Element {
    private string Text { get; }
    private HrTextAlignment Alignment { get; }
    private TextColor Color { get; }

    public TablerDivider(string text, HrTextAlignment alignment = HrTextAlignment.Center, TextColor color = TextColor.Default) {
        Text = text;
        Alignment = alignment;
        Color = color;
    }

    public override string ToString() {
        var alignmentClass = Alignment.ToClassString();
        var colorClass = Color.ToClassString();

        var dividerTag = new HtmlTag("div")
            .Class("hr-text")
            .Class(alignmentClass)
            .Class(colorClass)
            .Value(Text);

        return dividerTag.ToString();
    }
}
