namespace HtmlForgeX;

public class HtmlTablerCard : HtmlElementContainer {
    public string? Content { get; set; }
    public string? Style { get; set; }

    public HtmlTablerCard AddContent(string content) {
        Content = content;
        return this;
    }

    public HtmlTablerCard WithStyle(string style) {
        Style = style;
        return this;
    }

    public override string ToString() {
        Console.WriteLine("Generating HtmlCard...");
        var childrenHtml = string.Join("", Children.Select(child => child.ToString()));
        var result = $"<div class=\"card\"><div class=\"card-body\" style=\"{Style}\">{Content}{childrenHtml}</div></div>";
        Console.WriteLine("Generated HtmlCard: " + result);
        return result;
    }

    public HtmlTablerCard AddContent(Action<HtmlTablerCard> config) {
        config(this);
        return this;
    }
}