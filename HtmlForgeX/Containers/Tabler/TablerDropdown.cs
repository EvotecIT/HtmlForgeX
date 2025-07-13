using System.Collections.Generic;
using System.Linq;
using HtmlForgeX.Extensions;

namespace HtmlForgeX;

public class TablerDropdown : Element {
    private readonly string _label;
    private bool _dark;
    private bool _arrow;
    private readonly List<TablerDropdownItemBase> _items = new();

    public TablerDropdown(string label) {
        _label = label;
    }

    public TablerDropdown Dark() {
        _dark = true;
        return this;
    }

    public TablerDropdown WithArrow() {
        _arrow = true;
        return this;
    }

    public TablerDropdownItem Item(string text) {
        var item = new TablerDropdownItem(text);
        _items.Add(item);
        return item;
    }

    public TablerDropdown Separator() {
        _items.Add(new TablerDropdownSeparator());
        return this;
    }

    public TablerDropdownCheckboxItem CheckboxItem(string text, bool isChecked = false) {
        var item = new TablerDropdownCheckboxItem(text, isChecked);
        _items.Add(item);
        return item;
    }

    public TablerDropdownRadioItem RadioItem(string text, string groupName, bool isChecked = false) {
        var item = new TablerDropdownRadioItem(text, groupName, isChecked);
        _items.Add(item);
        return item;
    }

    public override string ToString() {
        var dropdownDiv = new HtmlTag("div").Class("dropdown");
        var toggle = new HtmlTag("a")
            .Class("btn dropdown-toggle")
            .Attribute("href", "#")
            .Attribute("data-bs-toggle", "dropdown")
            .Value(_label);

        var menu = new HtmlTag("div")
            .Class("dropdown-menu")
            .Class(_dark ? "dropdown-menu-dark" : null)
            .Class(_arrow ? "dropdown-menu-arrow" : null);

        foreach (var item in _items.WhereNotNull()) {
            menu.Value(item);
        }

        dropdownDiv.Value(toggle);
        dropdownDiv.Value(menu);
        return dropdownDiv.ToString();
    }
}

public abstract class TablerDropdownItemBase : Element {
}

public class TablerDropdownItem : TablerDropdownItemBase {
    private readonly string _text;
    private TablerIconType? _icon;
    private bool _danger;

    public TablerDropdownItem(string text) {
        _text = text;
    }

    public TablerDropdownItem Icon(TablerIconType icon) {
        _icon = icon;
        return this;
    }

    public TablerDropdownItem Danger() {
        _danger = true;
        return this;
    }

    public override string ToString() {
        var anchor = new HtmlTag("a")
            .Class("dropdown-item")
            .Attribute("href", "#")
            .Class(_danger ? "text-danger" : null);

        if (_icon.HasValue) {
            anchor.Value(new TablerIconElement(_icon.Value).FontSize(16));
            anchor.Value(" " + _text);
        } else {
            anchor.Value(_text);
        }

        return anchor.ToString();
    }
}

public class TablerDropdownSeparator : TablerDropdownItemBase {
    public override string ToString() => new HtmlTag("div").Class("dropdown-divider").ToString();
}

public class TablerDropdownCheckboxItem : TablerDropdownItemBase {
    private readonly string _text;
    private bool _checked;

    public TablerDropdownCheckboxItem(string text, bool isChecked) {
        _text = text;
        _checked = isChecked;
    }

    public TablerDropdownCheckboxItem Checked(bool state = true) {
        _checked = state;
        return this;
    }

    public override string ToString() {
        var label = new HtmlTag("label").Class("dropdown-item");
        var input = new HtmlTag("input")
            .Class("form-check-input me-1")
            .Attribute("type", "checkbox");
        if (_checked) {
            input.Attribute("checked", "checked");
        }
        label.Value(input).Value(_text);
        return label.ToString();
    }
}

public class TablerDropdownRadioItem : TablerDropdownItemBase {
    private readonly string _text;
    private readonly string _group;
    private bool _checked;

    public TablerDropdownRadioItem(string text, string groupName, bool isChecked) {
        _text = text;
        _group = groupName;
        _checked = isChecked;
    }

    public TablerDropdownRadioItem Checked(bool state = true) {
        _checked = state;
        return this;
    }

    public override string ToString() {
        var label = new HtmlTag("label").Class("dropdown-item");
        var input = new HtmlTag("input")
            .Class("form-check-input me-1")
            .Attribute("type", "radio")
            .Attribute("name", _group);
        if (_checked) {
            input.Attribute("checked", "checked");
        }
        label.Value(input).Value(_text);
        return label.ToString();
    }
}
