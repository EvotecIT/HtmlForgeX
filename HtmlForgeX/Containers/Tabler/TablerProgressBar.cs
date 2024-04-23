namespace HtmlForgeX;

public class TablerProgressBarItem : Element {
    private TablerBackground Background { get; }
    private int Progress { get; }
    private string Label { get; }
    private int? AriaValueNow { get; }
    private int? AriaValueMin { get; }
    private int? AriaValueMax { get; }

    public TablerProgressBarItem(TablerBackground background, int progress, string label, int? valueNow = null, int? valueMin = null, int? valueMax = null) {
        Background = background;
        Progress = progress;
        Label = label;
        AriaValueNow = valueNow;
        AriaValueMin = valueMin;
        AriaValueMax = valueMax;
    }

    public override string ToString() {
        HtmlTag progressTag = new HtmlTag("div")
            .Class($"progress-bar {Background}")
            .Attribute("role", "progressbar")
            .Attribute("style", $"width: {Progress}%")
            .Attribute("aria-label", Label);

        if (AriaValueNow.HasValue) {
            progressTag.Attribute("aria-valuenow", AriaValueNow.Value.ToString());
        }

        if (AriaValueMin.HasValue) {
            progressTag.Attribute("aria-valuemin", AriaValueMin.Value.ToString());
        }

        if (AriaValueMax.HasValue) {
            progressTag.Attribute("aria-valuemax", AriaValueMax.Value.ToString());
        }

        return progressTag.ToString();
    }
}


public class TablerProgressBar : Element {
    private HashSet<TablerProgressBarType> Types { get; } = new HashSet<TablerProgressBarType>();
    private List<TablerProgressBarItem> Items { get; } = new List<TablerProgressBarItem>();

    public TablerProgressBar(params TablerProgressBarType[] types) {
        Types.Add(TablerProgressBarType.Regular);
        foreach (var type in types) {
            Types.Add(type);
        }
    }

    public TablerProgressBar AddItem(TablerBackground background, int progress, string label) {
        Items.Add(new TablerProgressBarItem(background, progress, label));
        return this;
    }

    private TablerProgressBar AddItem(TablerProgressBarItem item) {
        Items.Add(item);
        return this;
    }

    public override string ToString() {
        string typeClass = string.Join(" ", Types.Select(t => t.ToString()));

        HtmlTag progressBarTag = new HtmlTag("div").Class(typeClass);

        foreach (var item in Items) {
            progressBarTag.Value(item.ToString());
        }

        return progressBarTag.ToString();
    }
}

public class TablerBackground {
    private string Background { get; }

    private TablerBackground(string background) {
        Background = background;
    }

    public override string ToString() {
        return Background;
    }

    public static TablerBackground Primary => new TablerBackground("bg-primary");
    public static TablerBackground Info => new TablerBackground("bg-info");
    public static TablerBackground Success => new TablerBackground("bg-success");
    public static TablerBackground FaceBook => new TablerBackground("bg-facebook");
    // Add more backgrounds here
}

public class TablerProgressBarType {
    private string Type { get; }

    private TablerProgressBarType(string type) {
        Type = type;
    }

    public override string ToString() {
        return Type;
    }

    internal static TablerProgressBarType Regular => new TablerProgressBarType("progress");
    public static TablerProgressBarType Separated => new TablerProgressBarType("progress-separated");
    public static TablerProgressBarType Small => new TablerProgressBarType("progress-sm");
    // Add more types here
}
