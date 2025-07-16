using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Represents an ApexCharts component that can be embedded in the HTML output
/// for displaying dynamic client-side charts.
/// </summary>
public class ApexCharts : Element {
    /// <summary>
    /// Gets or sets the DOM element identifier for the chart container.
    /// </summary>
    public string Id { get; set; }
    /// <summary>
    /// Gets or sets the type of chart to render.
    /// </summary>
    public ApexChartType Type { get; set; }
    /// <summary>
    /// Gets the numeric data series used by most chart types.
    /// </summary>
    public List<double> Series { get; set; } = new List<double>();
    /// <summary>
    /// Gets the labels associated with <see cref="Series"/> values.
    /// </summary>
    public List<string> Labels { get; set; } = new List<string>();
    /// <summary>
    /// Gets the heatmap specific series collection.
    /// </summary>
    public List<ApexHeatmapSeries> HeatmapSeries { get; set; } = new();
    /// <summary>
    /// Gets the title configuration.
    /// </summary>
    public ApexChartsTitle Title { get; set; } = new ApexChartsTitle();
    /// <summary>
    /// Gets the subtitle configuration.
    /// </summary>
    public ApexChartSubtitle Subtitle { get; set; } = new ApexChartSubtitle();
    /// <summary>
    /// Gets additional options passed directly to ApexCharts.
    /// </summary>
    public Dictionary<string, object> Options { get; set; } = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="ApexCharts"/> class.
    /// </summary>
    public ApexCharts() {
        // Libraries will be registered via RegisterLibraries method
        Id = GlobalStorage.GenerateRandomId("apexChart");
    }

    /// <summary>
    /// Registers the required libraries for ApexCharts.
    /// </summary>
    /// <inheritdoc />
    protected internal override void RegisterLibraries() {
        Document?.AddLibrary(Libraries.ApexCharts);
    }

    /// <summary>
    /// Adds a pie chart data point.
    /// </summary>
    /// <param name="name">Label for the data point.</param>
    /// <param name="value">Numeric value.</param>
    /// <returns>The current <see cref="ApexCharts"/> instance.</returns>
    public ApexCharts AddPie(string name, double value) {
        Type = ApexChartType.Pie;
        Labels.Add(name);
        Series.Add(value);
        return this;
    }

    /// <summary>
    /// Adds a donut chart data point.
    /// </summary>
    /// <param name="name">Label for the data point.</param>
    /// <param name="value">Numeric value.</param>
    /// <returns>The current <see cref="ApexCharts"/> instance.</returns>
    public ApexCharts AddDonut(string name, double value) {
        Type = ApexChartType.Donut;
        Labels.Add(name);
        Series.Add(value);
        return this;
    }

    /// <summary>
    /// Adds a bar chart data point.
    /// </summary>
    /// <param name="name">Label for the data point.</param>
    /// <param name="value">Numeric value.</param>
    /// <returns>The current <see cref="ApexCharts"/> instance.</returns>
    public ApexCharts AddBar(string name, double value) {
        Type = ApexChartType.Bar;
        Labels.Add(name);
        Series.Add(value);
        return this;
    }

    /// <summary>
    /// Adds an area chart data point.
    /// </summary>
    /// <param name="name">Label for the data point.</param>
    /// <param name="value">Numeric value.</param>
    /// <returns>The current <see cref="ApexCharts"/> instance.</returns>
    public ApexCharts AddArea(string name, double value) {
        Type = ApexChartType.Area;
        Labels.Add(name);
        Series.Add(value);
        return this;
    }

    /// <summary>
    /// Adds a treemap chart data point.
    /// </summary>
    /// <param name="name">Label for the data point.</param>
    /// <param name="value">Numeric value.</param>
    /// <returns>The current <see cref="ApexCharts"/> instance.</returns>
    public ApexCharts AddTreemap(string name, double value) {
        Type = ApexChartType.Treemap;
        Labels.Add(name);
        Series.Add(value);
        return this;
    }

    /// <summary>
    /// Adds a radar chart data point.
    /// </summary>
    /// <param name="name">Label for the data point.</param>
    /// <param name="value">Numeric value.</param>
    /// <returns>The current <see cref="ApexCharts"/> instance.</returns>
    public ApexCharts AddRadar(string name, double value) {
        Type = ApexChartType.Radar;
        Labels.Add(name);
        Series.Add(value);
        return this;
    }

    /// <summary>
    /// Adds a heatmap series consisting of multiple points.
    /// </summary>
    /// <param name="name">Series name.</param>
    /// <param name="points">Collection of points (X,Y).</param>
    /// <returns>The current <see cref="ApexCharts"/> instance.</returns>
    public ApexCharts AddHeatmap(string name, IEnumerable<(string X, double Y)> points) {
        Type = ApexChartType.Heatmap;
        var series = new ApexHeatmapSeries { Name = name };
        foreach (var point in points) {
            series.Data.Add(new ApexHeatmapData { X = point.X, Y = point.Y });
        }
        HeatmapSeries.Add(series);
        return this;
    }

    /// <summary>
    /// Adds a data point for a mixed chart.
    /// </summary>
    /// <param name="name">Label for the data point.</param>
    /// <param name="value">Numeric value.</param>
    /// <returns>The current <see cref="ApexCharts"/> instance.</returns>
    public ApexCharts AddMixed(string name, double value) {
        Type = ApexChartType.Mixed;
        Labels.Add(name);
        Series.Add(value);
        return this;
    }

    /// <summary>
    /// Sets a raw option value passed directly to the ApexCharts configuration.
    /// </summary>
    /// <param name="key">Option key.</param>
    /// <param name="value">Option value.</param>
    /// <returns>The current <see cref="ApexCharts"/> instance.</returns>
    public ApexCharts SetOption(string key, object value) {
        Options[key] = value;
        return this;
    }

    /// <summary>
    /// Configures plot options using a fluent builder.
    /// </summary>
    /// <param name="configure">Delegate used to configure options.</param>
    /// <returns>The current <see cref="ApexCharts"/> instance.</returns>
    public ApexCharts PlotOptions(Action<ApexPlotOptions> configure) {
        var options = new ApexPlotOptions();
        configure(options);
        return SetOption("plotOptions", options);
    }

    /// <summary>
    /// Configures grid options using a fluent builder.
    /// </summary>
    /// <param name="configure">Delegate used to configure grid options.</param>
    /// <returns>The current <see cref="ApexCharts"/> instance.</returns>
    public ApexCharts Grid(Action<ApexGridOptions> configure) {
        var options = new ApexGridOptions();
        configure(options);
        return SetOption("grid", options);
    }

    /// <summary>
    /// Configures legend options using a fluent builder.
    /// </summary>
    /// <param name="configure">Delegate used to configure legend options.</param>
    /// <returns>The current <see cref="ApexCharts"/> instance.</returns>
    public ApexCharts Legend(Action<ApexLegendOptions> configure) {
        var options = new ApexLegendOptions();
        configure(options);
        return SetOption("legend", options);
    }

    /// <summary>
    /// Sets the responsive option value.
    /// </summary>
    /// <param name="value">Responsive configuration object.</param>
    /// <returns>The current <see cref="ApexCharts"/> instance.</returns>
    public ApexCharts Responsive(object value) => SetOption("responsive", value);

    /// <summary>
    /// Configures tooltip options using a fluent builder.
    /// </summary>
    /// <param name="configure">Delegate used to configure tooltip options.</param>
    /// <returns>The current <see cref="ApexCharts"/> instance.</returns>
    public ApexCharts Tooltip(Action<ApexTooltipOptions> configure) {
        var options = new ApexTooltipOptions();
        configure(options);
        return SetOption("tooltip", options);
    }

    /// <summary>
    /// Configures theme options.
    /// </summary>
    /// <param name="configure">Delegate used to configure theme options.</param>
    /// <returns>The current <see cref="ApexCharts"/> instance.</returns>
    public ApexCharts Theme(Action<ApexThemeOptions> configure) {
        var options = new ApexThemeOptions();
        configure(options);
        return SetOption("theme", options);
    }

    /// <summary>
    /// Adds a data point to the chart using the currently selected type.
    /// </summary>
    /// <param name="name">Label for the data point.</param>
    /// <param name="value">Numeric value.</param>
    /// <returns>The current <see cref="ApexCharts"/> instance.</returns>
    public ApexCharts Data(string name, double value) {
        Labels.Add(name);
        Series.Add(value);
        return this;
    }

    /// <summary>
    /// Generates the HTML and JavaScript required to render the chart.
    /// </summary>
    /// <returns>HTML markup representing the chart.</returns>
    public override string ToString() {
        // Generate ID if not already set
        if (string.IsNullOrEmpty(Id)) {
            Id = GlobalStorage.GenerateRandomId("apexChart");
        }

        var divTag = new HtmlTag("div").Attribute("id", Id);

        var options = new Dictionary<string, object> {
            ["chart"] = new Dictionary<string, object> {
                ["type"] = Type
            }
        };

        if (Title.IsSet) {
            options["title"] = Title;
        }

        if (Subtitle.IsSet) {
            options["subtitle"] = Subtitle;
        }

        if (Type == ApexChartType.Heatmap && HeatmapSeries.Count > 0) {
            options["series"] = HeatmapSeries;
        } else if (Series.Count > 0) {
            if (Type is ApexChartType.Pie or ApexChartType.Donut) {
                options["series"] = Series;
            } else {
                options["series"] = new List<object> { new { data = Series } };
            }
        }

        if (Labels.Count > 0) {
            options["labels"] = Labels;
        }

        foreach (var kv in Options) {
            options[kv.Key] = kv.Value;
        }

        //options = options.RemoveEmptyCollections();

        var optionsJson = JsonSerializer.Serialize(options, new JsonSerializerOptions { WriteIndented = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });

        var scriptTag = new HtmlTag("script").Value($@"
        var options = {optionsJson};
        var chart = new ApexCharts(document.querySelector('#{Id}'), options);
        chart.render();
    ");

        return divTag + scriptTag.ToString();
    }
}