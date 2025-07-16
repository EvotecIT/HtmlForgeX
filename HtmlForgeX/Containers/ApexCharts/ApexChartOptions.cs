using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Represents chart-specific options for ApexCharts.
/// </summary>
public class ApexChartOptions {
    /// <summary>
    /// Gets or sets the chart type.
    /// </summary>
    [JsonPropertyName("type")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ApexChartType? Type { get; set; }

    /// <summary>
    /// Gets or sets the height of the chart.
    /// </summary>
    [JsonPropertyName("height")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Height { get; set; }

    /// <summary>
    /// Gets or sets the width of the chart.
    /// </summary>
    [JsonPropertyName("width")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Width { get; set; }

    /// <summary>
    /// Gets or sets whether the chart is stacked.
    /// </summary>
    [JsonPropertyName("stacked")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Stacked { get; set; }

    /// <summary>
    /// Gets or sets the stacking type.
    /// </summary>
    [JsonPropertyName("stackType")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? StackType { get; set; }

    /// <summary>
    /// Gets or sets the toolbar options.
    /// </summary>
    [JsonPropertyName("toolbar")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ApexToolbar? Toolbar { get; set; }

    /// <summary>
    /// Gets or sets the zoom options.
    /// </summary>
    [JsonPropertyName("zoom")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ApexZoom? Zoom { get; set; }

    /// <summary>
    /// Gets or sets the animations options.
    /// </summary>
    [JsonPropertyName("animations")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ApexAnimations? Animations { get; set; }

    /// <summary>
    /// Gets or sets the background color.
    /// </summary>
    [JsonPropertyName("background")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Background { get; set; }

    /// <summary>
    /// Sets the chart as stacked.
    /// </summary>
    public ApexChartOptions SetStacked(bool stacked) {
        Stacked = stacked;
        return this;
    }

    /// <summary>
    /// Sets the chart height.
    /// </summary>
    public ApexChartOptions SetHeight(object height) {
        Height = height;
        return this;
    }

    /// <summary>
    /// Sets the chart width.
    /// </summary>
    public ApexChartOptions SetWidth(object width) {
        Width = width;
        return this;
    }

    /// <summary>
    /// Sets the background color.
    /// </summary>
    public ApexChartOptions SetBackground(string color) {
        Background = color;
        return this;
    }

    /// <summary>
    /// Configures the toolbar.
    /// </summary>
    public ApexChartOptions ConfigureToolbar(System.Action<ApexToolbar> configure) {
        Toolbar ??= new ApexToolbar();
        configure(Toolbar);
        return this;
    }

    /// <summary>
    /// Configures zoom options.
    /// </summary>
    public ApexChartOptions ConfigureZoom(System.Action<ApexZoom> configure) {
        Zoom ??= new ApexZoom();
        configure(Zoom);
        return this;
    }

    /// <summary>
    /// Configures animations.
    /// </summary>
    public ApexChartOptions ConfigureAnimations(System.Action<ApexAnimations> configure) {
        Animations ??= new ApexAnimations();
        configure(Animations);
        return this;
    }
}

/// <summary>
/// Represents toolbar options.
/// </summary>
public class ApexToolbar {
    /// <summary>
    /// Gets or sets whether to show the toolbar.
    /// </summary>
    [JsonPropertyName("show")]
    public bool? Show { get; set; }

    /// <summary>
    /// Gets or sets the tools configuration.
    /// </summary>
    [JsonPropertyName("tools")]
    public ApexToolbarTools? Tools { get; set; }

    /// <summary>
    /// Shows or hides the toolbar.
    /// </summary>
    public ApexToolbar SetShow(bool show) {
        Show = show;
        return this;
    }
}

/// <summary>
/// Represents toolbar tools configuration.
/// </summary>
public class ApexToolbarTools {
    /// <summary>
    /// Gets or sets whether to show download button.
    /// </summary>
    [JsonPropertyName("download")]
    public bool? Download { get; set; }

    /// <summary>
    /// Gets or sets whether to show selection button.
    /// </summary>
    [JsonPropertyName("selection")]
    public bool? Selection { get; set; }

    /// <summary>
    /// Gets or sets whether to show zoom button.
    /// </summary>
    [JsonPropertyName("zoom")]
    public bool? Zoom { get; set; }

    /// <summary>
    /// Gets or sets whether to show zoom in button.
    /// </summary>
    [JsonPropertyName("zoomin")]
    public bool? ZoomIn { get; set; }

    /// <summary>
    /// Gets or sets whether to show zoom out button.
    /// </summary>
    [JsonPropertyName("zoomout")]
    public bool? ZoomOut { get; set; }

    /// <summary>
    /// Gets or sets whether to show pan button.
    /// </summary>
    [JsonPropertyName("pan")]
    public bool? Pan { get; set; }

    /// <summary>
    /// Gets or sets whether to show reset button.
    /// </summary>
    [JsonPropertyName("reset")]
    public bool? Reset { get; set; }
}

/// <summary>
/// Represents zoom options.
/// </summary>
public class ApexZoom {
    /// <summary>
    /// Gets or sets whether zoom is enabled.
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// Gets or sets the zoom type.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// Gets or sets whether auto scale Y axis.
    /// </summary>
    [JsonPropertyName("autoScaleYaxis")]
    public bool? AutoScaleYaxis { get; set; }

    /// <summary>
    /// Enables or disables zoom.
    /// </summary>
    public ApexZoom SetEnabled(bool enabled) {
        Enabled = enabled;
        return this;
    }

    /// <summary>
    /// Sets the zoom type.
    /// </summary>
    public ApexZoom SetType(string type) {
        Type = type;
        return this;
    }
}

/// <summary>
/// Represents animation options.
/// </summary>
public class ApexAnimations {
    /// <summary>
    /// Gets or sets whether animations are enabled.
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// Gets or sets the animation speed.
    /// </summary>
    [JsonPropertyName("speed")]
    public int? Speed { get; set; }

    /// <summary>
    /// Gets or sets the animation easing.
    /// </summary>
    [JsonPropertyName("easing")]
    public string? Easing { get; set; }

    /// <summary>
    /// Gets or sets whether to animate gradually.
    /// </summary>
    [JsonPropertyName("animateGradually")]
    public ApexAnimateGradually? AnimateGradually { get; set; }

    /// <summary>
    /// Gets or sets dynamic animation options.
    /// </summary>
    [JsonPropertyName("dynamicAnimation")]
    public ApexDynamicAnimation? DynamicAnimation { get; set; }

    /// <summary>
    /// Enables or disables animations.
    /// </summary>
    public ApexAnimations SetEnabled(bool enabled) {
        Enabled = enabled;
        return this;
    }

    /// <summary>
    /// Sets the animation speed.
    /// </summary>
    public ApexAnimations SetSpeed(int speed) {
        Speed = speed;
        return this;
    }
}

/// <summary>
/// Represents gradual animation options.
/// </summary>
public class ApexAnimateGradually {
    /// <summary>
    /// Gets or sets whether enabled.
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// Gets or sets the delay.
    /// </summary>
    [JsonPropertyName("delay")]
    public int? Delay { get; set; }
}

/// <summary>
/// Represents dynamic animation options.
/// </summary>
public class ApexDynamicAnimation {
    /// <summary>
    /// Gets or sets whether enabled.
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// Gets or sets the speed.
    /// </summary>
    [JsonPropertyName("speed")]
    public int? Speed { get; set; }
}