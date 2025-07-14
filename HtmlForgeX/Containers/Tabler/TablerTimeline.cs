using HtmlForgeX.Extensions;

namespace HtmlForgeX;

/// <summary>
/// Container for displaying a sequence of events using Tabler styling.
/// </summary>
public class TablerTimeline : Element {
    private readonly List<TablerTimelineItem> _items = new();

    /// <summary>
    /// Initializes or configures Item.
    /// </summary>
    public TablerTimeline Item(Action<TablerTimelineItem> config) {
        var item = new TablerTimelineItem();
        config(item);
        _items.Add(item);
        return this;
    }

    /// <summary>
    /// Initializes or configures ToString.
    /// </summary>
    public override string ToString() {
        var ul = new HtmlTag("ul").Class("timeline");
        foreach (var item in _items.WhereNotNull()) {
            ul.Value(item);
        }
        return ul.ToString();
    }
}

/// <summary>
/// Represents a single item displayed within a <see cref="TablerTimeline"/>.
/// </summary>
public class TablerTimelineItem : Element {
    private string? _time;
    private TablerIconType? _icon;
    private TablerColor? _color;
    private string? _title;
    private string? _description;

    /// <summary>
    /// Initializes or configures Time.
    /// </summary>
    public TablerTimelineItem Time(DateTime dateTime) {
        _time = dateTime.ToString("g");
        return this;
    }

    /// <summary>
    /// Initializes or configures Time.
    /// </summary>
    public TablerTimelineItem Time(string time) {
        _time = time;
        return this;
    }

    /// <summary>
    /// Initializes or configures Icon.
    /// </summary>
    public TablerTimelineItem Icon(TablerIconType icon) {
        _icon = icon;
        return this;
    }

    /// <summary>
    /// Initializes or configures Color.
    /// </summary>
    public TablerTimelineItem Color(TablerColor color) {
        _color = color;
        return this;
    }

    /// <summary>
    /// Initializes or configures Title.
    /// </summary>
    public TablerTimelineItem Title(string title) {
        _title = title;
        return this;
    }

    /// <summary>
    /// Initializes or configures Description.
    /// </summary>
    public TablerTimelineItem Description(string description) {
        _description = description;
        return this;
    }

    /// <summary>
    /// Initializes or configures ToString.
    /// </summary>
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