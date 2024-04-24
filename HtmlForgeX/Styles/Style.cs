namespace HtmlForgeX;

public class Style {
    public string? Selector { get; set; }
    public Dictionary<string, string> Properties { get; set; } = new Dictionary<string, string>();

    public Style(string selector) {
        Selector = selector;
    }

    public Style(string selector, Dictionary<string, string> properties) {
        Selector = selector;
        Properties = properties;
    }

    public Style() {

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
