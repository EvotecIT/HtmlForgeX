using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    /// Gets the multi-series data collection for charts like Line, Column, etc.
    /// </summary>
    public List<ApexSeriesData> MultipleSeries { get; set; } = new();
    /// <summary>
    /// Gets the candlestick specific series collection.
    /// </summary>
    public List<ApexCandlestickSeries> CandlestickSeries { get; set; } = new();
    /// <summary>
    /// Gets the bubble specific series collection.
    /// </summary>
    public List<ApexBubbleSeries> BubbleSeries { get; set; } = new();
    /// <summary>
    /// Gets the boxplot specific series collection.
    /// </summary>
    public List<ApexBoxPlotSeries> BoxPlotSeries { get; set; } = new();
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
    /// Adds a line chart data point.
    /// </summary>
    /// <param name="name">Label for the data point.</param>
    /// <param name="value">Numeric value.</param>
    /// <returns>The current <see cref="ApexCharts"/> instance.</returns>
    public ApexCharts AddLine(string name, double value) {
        Type = ApexChartType.Line;
        Labels.Add(name);
        Series.Add(value);
        return this;
    }

    /// <summary>
    /// Adds a column chart data point.
    /// </summary>
    /// <param name="name">Label for the data point.</param>
    /// <param name="value">Numeric value.</param>
    /// <returns>The current <see cref="ApexCharts"/> instance.</returns>
    public ApexCharts AddColumn(string name, double value) {
        Type = ApexChartType.Column;
        Labels.Add(name);
        Series.Add(value);
        return this;
    }

    /// <summary>
    /// Adds a scatter chart data point.
    /// </summary>
    /// <param name="x">X coordinate.</param>
    /// <param name="y">Y coordinate.</param>
    /// <returns>The current <see cref="ApexCharts"/> instance.</returns>
    public ApexCharts AddScatter(double x, double y) {
        Type = ApexChartType.Scatter;
        if (MultipleSeries.Count == 0) {
            MultipleSeries.Add(new ApexSeriesData { Name = "Series 1", Data = new() });
        }
        MultipleSeries[0].Data.Add(new[] { x, y });
        return this;
    }

    /// <summary>
    /// Adds a bubble chart data point.
    /// </summary>
    /// <param name="x">X coordinate.</param>
    /// <param name="y">Y coordinate.</param>
    /// <param name="z">Bubble size.</param>
    /// <returns>The current <see cref="ApexCharts"/> instance.</returns>
    public ApexCharts AddBubble(double x, double y, double z) {
        Type = ApexChartType.Bubble;
        if (BubbleSeries.Count == 0) {
            BubbleSeries.Add(new ApexBubbleSeries { Name = "Series 1", Data = new() });
        }
        BubbleSeries[0].Data.Add(new ApexBubbleData { X = x, Y = y, Z = z });
        return this;
    }

    /// <summary>
    /// Adds a candlestick data point.
    /// </summary>
    /// <param name="x">X value (typically date/time).</param>
    /// <param name="open">Opening price.</param>
    /// <param name="high">High price.</param>
    /// <param name="low">Low price.</param>
    /// <param name="close">Closing price.</param>
    /// <returns>The current <see cref="ApexCharts"/> instance.</returns>
    public ApexCharts AddCandlestick(string x, double open, double high, double low, double close) {
        Type = ApexChartType.Candlestick;
        if (CandlestickSeries.Count == 0) {
            CandlestickSeries.Add(new ApexCandlestickSeries { Name = "Series 1", Data = new() });
        }
        CandlestickSeries[0].Data.Add(new ApexCandlestickData { X = x, Y = new[] { open, high, low, close } });
        return this;
    }

    /// <summary>
    /// Adds a boxplot data point.
    /// </summary>
    /// <param name="x">X value (category).</param>
    /// <param name="min">Minimum value.</param>
    /// <param name="q1">First quartile.</param>
    /// <param name="median">Median value.</param>
    /// <param name="q3">Third quartile.</param>
    /// <param name="max">Maximum value.</param>
    /// <returns>The current <see cref="ApexCharts"/> instance.</returns>
    public ApexCharts AddBoxPlot(string x, double min, double q1, double median, double q3, double max) {
        Type = ApexChartType.BoxPlot;
        if (BoxPlotSeries.Count == 0) {
            BoxPlotSeries.Add(new ApexBoxPlotSeries { Name = "Series 1", Data = new() });
        }
        BoxPlotSeries[0].Data.Add(new ApexBoxPlotData { X = x, Y = new[] { min, q1, median, q3, max } });
        return this;
    }

    /// <summary>
    /// Adds a funnel chart data point.
    /// </summary>
    /// <param name="name">Label for the data point.</param>
    /// <param name="value">Numeric value.</param>
    /// <returns>The current <see cref="ApexCharts"/> instance.</returns>
    public ApexCharts AddFunnel(string name, double value) {
        Type = ApexChartType.Funnel;
        Labels.Add(name);
        Series.Add(value);
        return this;
    }

    /// <summary>
    /// Adds a polar area chart data point.
    /// </summary>
    /// <param name="name">Label for the data point.</param>
    /// <param name="value">Numeric value.</param>
    /// <returns>The current <see cref="ApexCharts"/> instance.</returns>
    public ApexCharts AddPolarArea(string name, double value) {
        Type = ApexChartType.PolarArea;
        Labels.Add(name);
        Series.Add(value);
        return this;
    }

    /// <summary>
    /// Adds a radial bar chart data point.
    /// </summary>
    /// <param name="name">Label for the data point.</param>
    /// <param name="value">Numeric value.</param>
    /// <returns>The current <see cref="ApexCharts"/> instance.</returns>
    public ApexCharts AddRadialBar(string name, double value) {
        Type = ApexChartType.RadialBar;
        Labels.Add(name);
        Series.Add(value);
        return this;
    }

    /// <summary>
    /// Adds a series with multiple data points for multi-series charts.
    /// </summary>
    /// <param name="seriesName">Name of the series.</param>
    /// <param name="data">Array of data values.</param>
    /// <returns>The current <see cref="ApexCharts"/> instance.</returns>
    public ApexCharts AddSeries(string seriesName, params double[] data) {
        // If type hasn't been set and we're adding series, default to Line
        if (Type == ApexChartType.Pie && MultipleSeries.Count == 0 && Series.Count == 0) {
            Type = ApexChartType.Line;
        }
        
        var series = new ApexSeriesData { Name = seriesName };
        foreach (var value in data) {
            series.Data.Add(value);
        }
        MultipleSeries.Add(series);
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
    /// Configures X-axis options.
    /// </summary>
    /// <param name="configure">Delegate used to configure X-axis options.</param>
    /// <returns>The current <see cref="ApexCharts"/> instance.</returns>
    public ApexCharts XAxis(Action<ApexAxisOptions> configure) {
        var options = new ApexAxisOptions();
        configure(options);
        return SetOption("xaxis", options);
    }

    /// <summary>
    /// Configures Y-axis options.
    /// </summary>
    /// <param name="configure">Delegate used to configure Y-axis options.</param>
    /// <returns>The current <see cref="ApexCharts"/> instance.</returns>
    public ApexCharts YAxis(Action<ApexAxisOptions> configure) {
        var options = new ApexAxisOptions();
        configure(options);
        return SetOption("yaxis", options);
    }

    /// <summary>
    /// Configures data labels options.
    /// </summary>
    /// <param name="configure">Delegate used to configure data labels options.</param>
    /// <returns>The current <see cref="ApexCharts"/> instance.</returns>
    public ApexCharts DataLabels(Action<ApexDataLabelsOptions> configure) {
        var options = new ApexDataLabelsOptions();
        configure(options);
        return SetOption("dataLabels", options);
    }

    /// <summary>
    /// Configures stroke options.
    /// </summary>
    /// <param name="configure">Delegate used to configure stroke options.</param>
    /// <returns>The current <see cref="ApexCharts"/> instance.</returns>
    public ApexCharts Stroke(Action<ApexStrokeOptions> configure) {
        var options = new ApexStrokeOptions();
        configure(options);
        return SetOption("stroke", options);
    }

    /// <summary>
    /// Configures fill options.
    /// </summary>
    /// <param name="configure">Delegate used to configure fill options.</param>
    /// <returns>The current <see cref="ApexCharts"/> instance.</returns>
    public ApexCharts Fill(Action<ApexFillOptions> configure) {
        var options = new ApexFillOptions();
        configure(options);
        return SetOption("fill", options);
    }

    /// <summary>
    /// Sets chart colors.
    /// </summary>
    /// <param name="colors">Array of color values.</param>
    /// <returns>The current <see cref="ApexCharts"/> instance.</returns>
    public ApexCharts Colors(params string[] colors) {
        return SetOption("colors", colors);
    }

    /// <summary>
    /// Sets chart colors using RGBColor.
    /// </summary>
    /// <param name="colors">Array of RGBColor values.</param>
    /// <returns>The current <see cref="ApexCharts"/> instance.</returns>
    public ApexCharts Colors(params RGBColor[] colors) {
        var colorStrings = colors.Select(c => c.ToHex()).ToArray();
        return SetOption("colors", colorStrings);
    }

    /// <summary>
    /// Sets chart animations.
    /// </summary>
    /// <param name="enabled">Whether animations are enabled.</param>
    /// <param name="speed">Animation speed in milliseconds.</param>
    /// <returns>The current <see cref="ApexCharts"/> instance.</returns>
    public ApexCharts Animations(bool enabled, int speed = 800) {
        return SetOption("chart", new Dictionary<string, object> {
            ["animations"] = new Dictionary<string, object> {
                ["enabled"] = enabled,
                ["speed"] = speed
            }
        });
    }

    /// <summary>
    /// Configures chart options using a fluent builder.
    /// </summary>
    /// <param name="configure">Delegate used to configure chart options.</param>
    /// <returns>The current <see cref="ApexCharts"/> instance.</returns>
    public ApexCharts Chart(Action<ApexChartOptions> configure) {
        var options = new ApexChartOptions();
        configure(options);
        return SetOption("chart", options);
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

        var chartType = Type;
        // Funnel and column charts are rendered as bar charts
        if (Type is ApexChartType.Funnel or ApexChartType.Column) {
            chartType = ApexChartType.Bar;
        }
        
        var chartOptions = new Dictionary<string, object> {
            ["type"] = chartType
        };
        
        var options = new Dictionary<string, object> {
            ["chart"] = chartOptions
        };

        if (Title.IsSet) {
            options["title"] = Title;
        }

        if (Subtitle.IsSet) {
            options["subtitle"] = Subtitle;
        }

        if (Type == ApexChartType.Heatmap && HeatmapSeries.Count > 0) {
            options["series"] = HeatmapSeries;
        } else if (Type == ApexChartType.Candlestick && CandlestickSeries.Count > 0) {
            options["series"] = CandlestickSeries;
        } else if (Type == ApexChartType.Bubble && BubbleSeries.Count > 0) {
            options["series"] = BubbleSeries;
        } else if (Type == ApexChartType.BoxPlot && BoxPlotSeries.Count > 0) {
            options["series"] = BoxPlotSeries;
        } else if (Type == ApexChartType.Scatter && MultipleSeries.Count > 0) {
            options["series"] = MultipleSeries;
        } else if ((Type == ApexChartType.Line || Type == ApexChartType.Column || Type == ApexChartType.Area || Type == ApexChartType.Bar) && MultipleSeries.Count > 0) {
            options["series"] = MultipleSeries;
        } else if (Series.Count > 0) {
            if (Type is ApexChartType.Pie or ApexChartType.Donut or ApexChartType.RadialBar or ApexChartType.PolarArea) {
                options["series"] = Series;
            } else if (Type == ApexChartType.Funnel) {
                // Funnel chart needs series with name and data
                options["series"] = new List<object> { new { name = "Funnel", data = Series } };
            } else if (Type == ApexChartType.Treemap) {
                // Treemap needs series with name and data
                var treemapData = new List<object>();
                for (int i = 0; i < Labels.Count && i < Series.Count; i++) {
                    treemapData.Add(new { x = Labels[i], y = Series[i] });
                }
                options["series"] = new List<object> { new { data = treemapData } };
            } else if (Type == ApexChartType.Radar) {
                // Radar chart needs series with name and data
                options["series"] = new List<object> { new { name = "Series", data = Series } };
            } else {
                options["series"] = new List<object> { new { data = Series } };
            }
        }

        if (Labels.Count > 0) {
            // Don't add labels for certain chart types that use x/y data format or need xaxis categories
            if (Type != ApexChartType.Treemap && Type != ApexChartType.Heatmap && 
                Type != ApexChartType.Scatter && Type != ApexChartType.Bubble &&
                Type != ApexChartType.Column && Type != ApexChartType.Bar &&
                Type != ApexChartType.Line && Type != ApexChartType.Area) {
                options["labels"] = Labels;
            }
        }

        // Set xaxis categories for charts that need them
        if (Labels.Count > 0 && (Type == ApexChartType.Column || Type == ApexChartType.Bar || 
            Type == ApexChartType.Line || Type == ApexChartType.Area)) {
            
            // Check if xaxis is already configured in Options
            if (!Options.ContainsKey("xaxis")) {
                options["xaxis"] = new Dictionary<string, object> { ["categories"] = Labels };
            } else {
                // Merge with existing xaxis options
                var existingXaxis = Options["xaxis"];
                if (existingXaxis is Dictionary<string, object> xaxisDict) {
                    if (!xaxisDict.ContainsKey("categories")) {
                        xaxisDict["categories"] = Labels;
                    }
                } else if (existingXaxis is ApexAxisOptions apexAxisOptions) {
                    // If it's already an ApexAxisOptions object, check if categories are set
                    if (apexAxisOptions.Categories == null) {
                        apexAxisOptions.Categories = Labels.ToArray();
                    }
                }
            }
        }

        foreach (var kv in Options) {
            // Special handling for chart options to merge with existing type
            if (kv.Key == "chart") {
                if (kv.Value is Dictionary<string, object> userChartOptions) {
                    foreach (var chartOption in userChartOptions) {
                        chartOptions[chartOption.Key] = chartOption.Value;
                    }
                } else if (kv.Value is ApexChartOptions apexChartOptions) {
                    // Serialize and deserialize to convert to dictionary
                    var json = JsonSerializer.Serialize(apexChartOptions);
                    var dict = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
                    if (dict != null) {
                        foreach (var chartOption in dict) {
                            chartOptions[chartOption.Key] = chartOption.Value;
                        }
                    }
                }
            } else {
                options[kv.Key] = kv.Value;
            }
        }

        //options = options.RemoveEmptyCollections();

        var optionsJson = JsonSerializer.Serialize(options, new JsonSerializerOptions { WriteIndented = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });

        var scriptTag = new HtmlTag("script").Value($@"
        document.addEventListener('DOMContentLoaded', function() {{
            var options = {optionsJson};
            var chart = new ApexCharts(document.querySelector('#{Id}'), options);
            chart.render();
        }});
    ");

        return divTag + scriptTag.ToString();
    }
}