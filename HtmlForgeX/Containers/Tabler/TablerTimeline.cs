using HtmlForgeX.Extensions;

namespace HtmlForgeX;

public class TablerTimeline : Element {
    private readonly List<TablerTimelineItem> _items = new();

    public TablerTimeline Item(Action<TablerTimelineItem> config) {
        var item = new TablerTimelineItem();
        config(item);
        _items.Add(item);
        return this;
    }

    public override string ToString() {
        var ul = new HtmlTag("ul").Class("timeline");
        foreach (var item in _items.WhereNotNull()) {
            ul.Value(item);
        }
        return ul.ToString();
    }
}

public class TablerTimelineItem : Element {
    private string? _time;
    private TablerIconType? _icon;
    private TablerColor? _color;
    private string? _title;
    private string? _description;

    public TablerTimelineItem Time(DateTime dateTime) {
        _time = dateTime.ToString("g");
        return this;
    }

    public TablerTimelineItem Time(string time) {
        _time = time;
        return this;
    }

    public TablerTimelineItem Icon(TablerIconType icon) {
        _icon = icon;
        return this;
    }

    public TablerTimelineItem Color(TablerColor color) {
        _color = color;
        return this;
    }

    public TablerTimelineItem Title(string title) {
        _title = title;
        return this;
    }

    public TablerTimelineItem Description(string description) {
        _description = description;
        return this;
    }

    public override string ToString() {
        var li = new HtmlTag("li").Class("timeline-event");
        var iconDiv = new HtmlTag("div").Class("timeline-event-icon");
        if (_color != null) {
            iconDiv.Class(_color.Value.ToTablerBackground());
        }
        if (_icon != null) {
            iconDiv.Value(new TablerIconElement(_icon.Value).FontSize(20));
        }
        li.Value(iconDiv);

        var card = new HtmlTag("div").Class("card timeline-event-card");
        var body = new HtmlTag("div").Class("card-body");
        if (!string.IsNullOrEmpty(_time)) {
            body.Value(new HtmlTag("div").Class("text-muted mb-1").Value(_time));
        }
        if (!string.IsNullOrEmpty(_title)) {
            body.Value(new HtmlTag("h4").Class("card-title").Value(_title));
        }
        if (!string.IsNullOrEmpty(_description)) {
            body.Value(new HtmlTag("div").Class("text-muted").Value(_description));
        }
        card.Value(body);
        li.Value(card);
        return li.ToString();
    }
}
