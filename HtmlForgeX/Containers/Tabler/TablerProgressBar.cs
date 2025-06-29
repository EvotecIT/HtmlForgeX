namespace HtmlForgeX;

/// <summary>
/// Represents a single item within a progress bar.
/// </summary>
public class TablerProgressBarItem : Element {
    private TablerColor Background { get; }
    private int Progress { get; }
    private string PrivateLabel { get; set; }
    private int? AriaValueNow { get; }
    private int? AriaValueMin { get; }
    private int? AriaValueMax { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="TablerProgressBarItem"/> class.
    /// </summary>
    /// <param name="background">Background color for the progress bar segment.</param>
    /// <param name="progress">Progress percentage.</param>
    public TablerProgressBarItem(TablerColor background, int progress) {
        Background = background;
        Progress = progress;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TablerProgressBarItem"/> class with additional ARIA attributes.
    /// </summary>
    /// <param name="background">Background color for the progress bar segment.</param>
    /// <param name="progress">Progress percentage.</param>
    /// <param name="label">Accessible label for the item.</param>
    /// <param name="valueNow">Optional current value.</param>
    /// <param name="valueMin">Optional minimum value.</param>
    /// <param name="valueMax">Optional maximum value.</param>
    public TablerProgressBarItem(TablerColor background, int progress, string label, int? valueNow = null, int? valueMin = null, int? valueMax = null) {
        Background = background;
        Progress = progress;
        PrivateLabel = label;
        AriaValueNow = valueNow;
        AriaValueMin = valueMin;
        AriaValueMax = valueMax;
    }

    /// <summary>
    /// Sets the accessible label for the progress segment.
    /// </summary>
    /// <param name="label">Label text.</param>
    /// <returns>The current <see cref="TablerProgressBarItem"/> instance.</returns>
    public TablerProgressBarItem Label(string label) {
        PrivateLabel = label;
        return this;
    }

    /// <summary>
    /// Returns the HTML representation of the progress bar item.
    /// </summary>
    /// <returns>A string containing the HTML markup.</returns>
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


/// <summary>
/// Represents a progress bar that can contain multiple items.
/// </summary>
public class TablerProgressBar : Element {
    private HashSet<TablerProgressBarType> Types { get; } = new HashSet<TablerProgressBarType>();
    private List<TablerProgressBarItem> Items { get; } = new List<TablerProgressBarItem>();

    /// <summary>
    /// Initializes a new instance of the <see cref="TablerProgressBar"/> class with optional progress bar types.
    /// </summary>
    /// <param name="types">Additional CSS types.</param>
    public TablerProgressBar(params TablerProgressBarType[] types) {
        foreach (var type in types) {
            Types.Add(type);
        }
    }

    /// <summary>
    /// Adds a progress item to the bar.
    /// </summary>
    /// <param name="background">Background color of the item.</param>
    /// <param name="progress">Progress percentage.</param>
    /// <param name="label">Label text.</param>
    /// <returns>The current <see cref="TablerProgressBar"/> instance.</returns>
    public TablerProgressBar Item(TablerColor background, int progress, string label) {
        Items.Add(new TablerProgressBarItem(background, progress, label));
        return this;
    }

    /// <summary>
    /// Adds a preconstructed progress item to the bar.
    /// </summary>
    /// <param name="item">The item to add.</param>
    /// <returns>The current <see cref="TablerProgressBar"/> instance.</returns>
    private TablerProgressBar Item(TablerProgressBarItem item) {
        Items.Add(item);
        return this;
    }

    /// <summary>
    /// Returns the HTML representation of the progress bar.
    /// </summary>
    /// <returns>A string containing the HTML markup.</returns>
    public override string ToString() {
        string typeClass = string.Join(" ", Types.Select(t => t.ToClassString()));

        HtmlTag progressBarTag = new HtmlTag("div")
            .Class("progress");

        if (!string.IsNullOrEmpty(typeClass)) {
            progressBarTag.Class(typeClass);
        }
        // TODO: We need to add handling for mb-3 and similar for margins and padding

        foreach (var item in Items) {
            progressBarTag.Value(item.ToString());
        }

        return progressBarTag.ToString();
    }
}