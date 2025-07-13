using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HtmlForgeX;

public class ApexCharts : Element {
    public string Id { get; set; }
    public ApexChartType Type { get; set; }
    public List<double> Series { get; set; } = new List<double>();
    public List<string> Labels { get; set; } = new List<string>();
    public List<ApexHeatmapSeries> HeatmapSeries { get; set; } = new();
    public ApexChartsTitle Title { get; set; } = new ApexChartsTitle();
    public ApexChartSubtitle Subtitle { get; set; } = new ApexChartSubtitle();
    public Dictionary<string, object> Options { get; set; } = new();

    public ApexCharts() {
        // Libraries will be registered via RegisterLibraries method
        Id = GlobalStorage.GenerateRandomId("apexChart");
    }

    /// <summary>
    /// Registers the required libraries for ApexCharts.
    /// </summary>
    protected internal override void RegisterLibraries() {
        Document?.Configuration.Libraries.TryAdd(Libraries.ApexCharts, 0);
    }

    public ApexCharts AddPie(string name, double value) {
        Type = ApexChartType.Pie;
        Labels.Add(name);
        Series.Add(value);
        return this;
    }

    public ApexCharts AddDonut(string name, double value) {
        Type = ApexChartType.Donut;
        Labels.Add(name);
        Series.Add(value);
        return this;
    }

    public ApexCharts AddBar(string name, double value) {
        Type = ApexChartType.Bar;
        Labels.Add(name);
        Series.Add(value);
        return this;
    }

    public ApexCharts AddArea(string name, double value) {
        Type = ApexChartType.Area;
        Labels.Add(name);
        Series.Add(value);
        return this;
    }

    public ApexCharts AddTreemap(string name, double value) {
        Type = ApexChartType.Treemap;
        Labels.Add(name);
        Series.Add(value);
        return this;
    }

    public ApexCharts AddRadar(string name, double value) {
        Type = ApexChartType.Radar;
        Labels.Add(name);
        Series.Add(value);
        return this;
    }

    public ApexCharts AddHeatmap(string name, IEnumerable<(string X, double Y)> points) {
        Type = ApexChartType.Heatmap;
        var series = new ApexHeatmapSeries { Name = name };
        foreach (var point in points) {
            series.Data.Add(new ApexHeatmapData { X = point.X, Y = point.Y });
        }
        HeatmapSeries.Add(series);
        return this;
    }

    public ApexCharts AddMixed(string name, double value) {
        Type = ApexChartType.Mixed;
        Labels.Add(name);
        Series.Add(value);
        return this;
    }

    public ApexCharts SetOption(string key, object value) {
        Options[key] = value;
        return this;
    }

    public ApexCharts PlotOptions(Action<ApexPlotOptions> configure) {
        var options = new ApexPlotOptions();
        configure(options);
        return SetOption("plotOptions", options);
    }

    public ApexCharts Grid(Action<ApexGridOptions> configure) {
        var options = new ApexGridOptions();
        configure(options);
        return SetOption("grid", options);
    }

    public ApexCharts Legend(Action<ApexLegendOptions> configure) {
        var options = new ApexLegendOptions();
        configure(options);
        return SetOption("legend", options);
    }

    public ApexCharts Responsive(object value) => SetOption("responsive", value);

    public ApexCharts Tooltip(Action<ApexTooltipOptions> configure) {
        var options = new ApexTooltipOptions();
        configure(options);
        return SetOption("tooltip", options);
    }

    public ApexCharts Theme(Action<ApexThemeOptions> configure) {
        var options = new ApexThemeOptions();
        configure(options);
        return SetOption("theme", options);
    }

    public ApexCharts Data(string name, double value) {
        Labels.Add(name);
        Series.Add(value);
        return this;
    }

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