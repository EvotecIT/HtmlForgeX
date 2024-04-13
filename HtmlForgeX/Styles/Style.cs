namespace HtmlForgeX;

public class Style {
    public string Selector { get; }
    public Dictionary<string, string> Properties { get; } = new Dictionary<string, string>();

    public Style(string selector) {
        Selector = selector;
    }

    public Style Add(string property, string value) {
        Properties[property] = value;
        return this;
    }

    public override string ToString() {
        var properties = string.Join("; ", Properties.Select(kvp => $"{kvp.Key}: {kvp.Value}"));
        return $"{Selector} {{ {properties} }}";
    }
}
