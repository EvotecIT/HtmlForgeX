using System.Collections.Generic;
using System.Linq;

namespace HtmlForgeX;

public class TablerSelect : Element {
    private readonly string _name;
    private string? _label;
    private bool _multiple;
    private bool _searchable;
    private readonly List<(string Value, string Text)> _options = new();

    public TablerSelect(string name) {
        _name = name;
    }

/// <summary>
/// Method Label.
/// </summary>
    public TablerSelect Label(string text) { _label = text; return this; }
/// <summary>
/// Method Multiple.
/// </summary>
    public TablerSelect Multiple(bool multiple = true) { _multiple = multiple; return this; }
/// <summary>
/// Method Searchable.
/// </summary>
    public TablerSelect Searchable(bool enable = true) { _searchable = enable; return this; }
/// <summary>
/// Method Option.
/// </summary>
    public TablerSelect Option(string text, string value) { _options.Add((value, text)); return this; }
/// <summary>
/// Method Options.
/// </summary>
    public TablerSelect Options(IEnumerable<string> values) {
        foreach (var v in values) { _options.Add((v, v)); }
        return this;
    }

    protected internal override void RegisterLibraries() {
        if (_searchable) {
            Document?.Configuration.Libraries.TryAdd(Libraries.TomSelect, 0);
        }
    }

/// <summary>
/// Method ToString.
/// </summary>
    public override string ToString() {
        var wrapper = new HtmlTag("div").Class("mb-3");
        if (!string.IsNullOrEmpty(_label)) {
            wrapper.Value(new HtmlTag("label").Class("form-label").Attribute("for", _name).Value(_label));
        }
        var select = new HtmlTag("select")
            .Class("form-select")
            .Id(_name)
            .Attribute("name", _name);
        if (_multiple) select.Attribute("multiple", "multiple");
        foreach (var opt in _options) {
            select.Value(new HtmlTag("option").Attribute("value", opt.Value).Value(opt.Text));
        }
        wrapper.Value(select);
        if (_searchable) {
            var script = new HtmlTag("script").Value($"document.addEventListener('DOMContentLoaded',function(){{new TomSelect('#{_name}');}});");
            wrapper.Value(script);
        }
        return wrapper.ToString();
    }
}