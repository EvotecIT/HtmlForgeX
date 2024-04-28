namespace HtmlForgeX;

public class TablerProgressBarItem : Element {
    private TablerColor Background { get; }
    private int Progress { get; }
    private string PrivateLabel { get; set; }
    private int? AriaValueNow { get; }
    private int? AriaValueMin { get; }
    private int? AriaValueMax { get; }

    public TablerProgressBarItem(TablerColor background, int progress) {
        Background = background;
        Progress = progress;
    }

    public TablerProgressBarItem(TablerColor background, int progress, string label, int? valueNow = null, int? valueMin = null, int? valueMax = null) {
        Background = background;
        Progress = progress;
        PrivateLabel = label;
        AriaValueNow = valueNow;
        AriaValueMin = valueMin;
        AriaValueMax = valueMax;
    }

    public TablerProgressBarItem Label(string label) {
        PrivateLabel = label;
        return this;
    }

    public override string ToString() {
        HtmlTag progressTag = new HtmlTag("div")
            .Class($"progress-bar")
            .Class(Background.ToTablerBackground())
            .Attribute("role", "progressbar")
            .Attribute("style", $"width: {Progress}%")
            .Attribute("aria-label", PrivateLabel);

        if (AriaValueNow.HasValue) {
            progressTag.Attribute("aria-valuenow", AriaValueNow.Value.ToString());
        }

        if (AriaValueMin.HasValue) {
            progressTag.Attribute("aria-valuemin", AriaValueMin.Value.ToString());
        }

        if (AriaValueMax.HasValue) {
            progressTag.Attribute("aria-valuemax", AriaValueMax.Value.ToString());
        }


        progressTag.Value(new HtmlTag("span").Class("visually-hidden").Value(PrivateLabel));


        return progressTag.ToString();
    }
}


public class TablerProgressBar : Element {
    private HashSet<TablerProgressBarType> Types { get; } = new HashSet<TablerProgressBarType>();
    private List<TablerProgressBarItem> Items { get; } = new List<TablerProgressBarItem>();

    public TablerProgressBar(params TablerProgressBarType[] types) {
        foreach (var type in types) {
            Types.Add(type);
        }
    }

    public TablerProgressBar Item(TablerColor background, int progress, string label) {
        Items.Add(new TablerProgressBarItem(background, progress, label));
        return this;
    }

    private TablerProgressBar Item(TablerProgressBarItem item) {
        Items.Add(item);
        return this;
    }

    public override string ToString() {
        string typeClass = string.Join(" ", Types.Select(t => t.ToClassString()));

        HtmlTag progressBarTag = new HtmlTag("div")
            .Class("progress")
            .Class(typeClass);
        // TODO: We need to add handling for mb-3 and similar for margins and padding

        foreach (var item in Items) {
            progressBarTag.Value(item.ToString());
        }

        return progressBarTag.ToString();
    }
}