using HtmlForgeX;

public class HtmlDiv : HtmlElement {
    public string? Content { get; set; }
    public List<string> Classes { get; set; } = new List<string>();
    public List<HtmlDiv> Children { get; set; } = new List<HtmlDiv>();

    public HtmlDiv AddClass(string className) {
        Classes.Add(className);
        return this;
    }

    public HtmlDiv AddChild(HtmlDiv child) {
        Children.Add(child);
        return this;
    }

    public HtmlDiv AddContent(string content) {
        Content = content;
        return this;
    }

    public override string ToString() {
        var classString = string.Join(" ", Classes);
        var childrenHtml = string.Join("", Children.Select(child => child.ToString()));
        return $"<div class=\"{classString}\">{Content}{childrenHtml}</div>";
    }
}
