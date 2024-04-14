namespace HtmlForgeX;

public class HtmlAnchor {
    public string Name { get; set; }
    public string Id { get; set; }
    public string Target { get; set; }
    public string Class { get; set; }
    public string HrefLink { get; set; }
    public string OnClick { get; set; }
    public Dictionary<string, string> Style { get; set; }
    public string Text { get; set; }

    public HtmlAnchor() {
        Style = new Dictionary<string, string>();
    }

    public override string ToString() {
        var attributes = new Dictionary<string, string>
        {
            { "id", Id },
            { "name", Name },
            { "class", Class },
            { "target", Target },
            { "href", HrefLink },
            { "onclick", OnClick },
            { "style", string.Join("; ", Style.Select(kvp => $"{kvp.Key}: {kvp.Value}")) }
        };

        var attributeString = string.Join(" ", attributes.Where(kvp => !string.IsNullOrEmpty(kvp.Value)).Select(kvp => $"{kvp.Key}=\"{kvp.Value}\""));
        return $"<a {attributeString}>{Text}</a>";
    }
}
