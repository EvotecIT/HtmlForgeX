namespace HtmlForgeX;

public class TablerInputMask : Element {
    private readonly string _name;
    private string? _label;
    private string _pattern = string.Empty;

    public TablerInputMask(string name) {
        _name = name;
    }

    public TablerInputMask Label(string text) { _label = text; return this; }
    public TablerInputMask Pattern(string pattern) { _pattern = pattern; return this; }

    protected internal override void RegisterLibraries() {
        Document?.Configuration.Libraries.TryAdd(Libraries.IMask, 0);
    }

    public override string ToString() {
        var wrapper = new HtmlTag("div").Class("mb-3");
        if (!string.IsNullOrEmpty(_label)) {
            wrapper.Value(new HtmlTag("label").Class("form-label").Attribute("for", _name).Value(_label));
        }
        var input = new HtmlTag("input")
            .Class("form-control")
            .Id(_name)
            .Attribute("name", _name)
            .Attribute("type", "text")
            .Attribute("autocomplete", "off");
        if (!string.IsNullOrEmpty(_pattern)) {
            input.Attribute("data-mask", _pattern).Attribute("data-mask-visible", "true");
        }
        wrapper.Value(input);
        return wrapper.ToString();
    }
}
