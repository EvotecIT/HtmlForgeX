namespace HtmlForgeX;

public class HtmlText : HtmlSpan {
    public string Text { get; set; }
    public bool LineBreak { get; set; }
    public bool SkipParagraph { get; set; }

    public override string ToString() {
        base.Content = Text;
        var span = base.ToString(); // Calls the ToString() method of the base class (HtmlSpan)

        if (SkipParagraph) {
            return span;
        } else {
            return $"<div class=\"defaultText\">{span}</div>";
        }
    }

}
