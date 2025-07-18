using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Helper for building simple Chart.js charts.
/// </summary>
public class ChartJs : Element {
    /// <summary>
    /// Gets or sets the canvas identifier.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the chart type.
    /// </summary>
    public ChartJsType Type { get; set; } = ChartJsType.Bar;

    /// <summary>
    /// Gets the labels for the dataset.
    /// </summary>
    public List<string> Labels { get; } = new();

    /// <summary>
    /// Gets the numeric values for the dataset (for line, bar, pie and radar charts).
    /// </summary>
    public List<double> Data { get; } = new();

    /// <summary>
    /// Gets the scatter points for scatter charts.
    /// </summary>
    public List<(double x, double y)> Points { get; } = new();

    /// <summary>
    /// Gets the bubble points for bubble charts.
    /// </summary>
    public List<(double x, double y, double r)> Bubbles { get; } = new();

    /// <summary>
    /// Gets the datasets for advanced configuration.
    /// </summary>
    public List<ChartJsDataset> Datasets { get; } = new();

    /// <summary>
    /// Gets or sets the chart options.
    /// </summary>
    public ChartJsOptions Options { get; set; } = new();

    /// <summary>
    /// Gets or sets the canvas width.
    /// </summary>
    public string? Width { get; set; }

    /// <summary>
    /// Gets or sets the canvas height.
    /// </summary>
    public string? Height { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ChartJs"/> class.
    /// </summary>
    public ChartJs() {
        Id = GlobalStorage.GenerateRandomId("chartjs");
        // Set default options
        Options.Responsive = true;
        Options.MaintainAspectRatio = true;
    }

    /// <summary>
    /// Registers the Chart.js library with the current document.
    /// </summary>
    protected internal override void RegisterLibraries() {
        Document?.AddLibrary(Libraries.ChartJs);
    }

    /// <summary>
    /// Adds a data point to the chart.
    /// </summary>
    /// <param name="label">Label for the data point.</param>
    /// <param name="value">Numeric value.</param>
    /// <returns>The current <see cref="ChartJs"/> instance.</returns>
    public ChartJs AddData(string label, double value) {
        Labels.Add(label);
        Data.Add(value);
        return this;
    }

    /// <summary>
    /// Adds a label to the chart.
    /// </summary>
    /// <param name="label">Label to add.</param>
    /// <returns>The current <see cref="ChartJs"/> instance.</returns>
    public ChartJs AddLabel(string label) {
        Labels.Add(label);
        return this;
    }

    /// <summary>
    /// Adds multiple labels to the chart.
    /// </summary>
    /// <param name="labels">Labels to add.</param>
    /// <returns>The current <see cref="ChartJs"/> instance.</returns>
    public ChartJs AddLabels(params string[] labels) {
        Labels.AddRange(labels);
        return this;
    }

    /// <summary>
    /// Adds a point for scatter charts.
    /// </summary>
    public ChartJs AddPoint(double x, double y) {
        Points.Add((x, y));
        return this;
    }

    /// <summary>
    /// Adds a bubble point for bubble charts.
    /// </summary>
    public ChartJs AddBubble(double x, double y, double radius) {
        Bubbles.Add((x, y, radius));
        return this;
    }

    /// <summary>
    /// Sets the chart type.
    /// </summary>
    /// <param name="type">Chart type.</param>
    /// <returns>The current <see cref="ChartJs"/> instance.</returns>
    public ChartJs SetType(ChartJsType type) {
        Type = type;
        return this;
    }

    /// <summary>
    /// Shortcut for calling <see cref="SetType(ChartJsType)"/> with
    /// <see cref="ChartJsType.Line"/>.
    /// </summary>
    /// <returns>The current <see cref="ChartJs"/> instance.</returns>
    public ChartJs Line() => SetType(ChartJsType.Line);

    /// <summary>
    /// Shortcut for calling <see cref="SetType(ChartJsType)"/> with
    /// <see cref="ChartJsType.Bar"/>.
    /// </summary>
    /// <returns>The current <see cref="ChartJs"/> instance.</returns>
    public ChartJs Bar() => SetType(ChartJsType.Bar);

    /// <summary>
    /// Shortcut for calling <see cref="SetType(ChartJsType)"/> with
    /// <see cref="ChartJsType.Pie"/>.
    /// </summary>
    /// <returns>The current <see cref="ChartJs"/> instance.</returns>
    public ChartJs Pie() => SetType(ChartJsType.Pie);

    /// <summary>
    /// Shortcut for calling <see cref="SetType(ChartJsType)"/> with
    /// <see cref="ChartJsType.Radar"/>.
    /// </summary>
    /// <returns>The current <see cref="ChartJs"/> instance.</returns>
    public ChartJs Radar() => SetType(ChartJsType.Radar);

    /// <summary>
    /// Shortcut for calling <see cref="SetType(ChartJsType)"/> with
    /// <see cref="ChartJsType.Scatter"/>.
    /// </summary>
    /// <returns>The current <see cref="ChartJs"/> instance.</returns>
    public ChartJs Scatter() => SetType(ChartJsType.Scatter);

    /// <summary>
    /// Shortcut for calling <see cref="SetType(ChartJsType)"/> with
    /// <see cref="ChartJsType.Bubble"/>.
    /// </summary>
    /// <returns>The current <see cref="ChartJs"/> instance.</returns>
    public ChartJs Bubble() => SetType(ChartJsType.Bubble);

    /// <summary>
    /// Shortcut for calling <see cref="SetType(ChartJsType)"/> with
    /// <see cref="ChartJsType.Doughnut"/>.
    /// </summary>
    /// <returns>The current <see cref="ChartJs"/> instance.</returns>
    public ChartJs Doughnut() => SetType(ChartJsType.Doughnut);

    /// <summary>
    /// Shortcut for calling <see cref="SetType(ChartJsType)"/> with
    /// <see cref="ChartJsType.PolarArea"/>.
    /// </summary>
    /// <returns>The current <see cref="ChartJs"/> instance.</returns>
    public ChartJs PolarArea() => SetType(ChartJsType.PolarArea);

    #region Options Methods

    /// <summary>
    /// Sets the chart title.
    /// </summary>
    public ChartJs Title(string text, bool display = true) {
        Options.Plugins ??= new ChartJsPlugins();
        Options.Plugins.Title ??= new ChartJsTitle();
        Options.Plugins.Title.Display = display;
        Options.Plugins.Title.Text = text;
        return this;
    }

    /// <summary>
    /// Sets the chart title with advanced styling options.
    /// </summary>
    public ChartJs TitleStyled(string text, int fontSize = 16, ChartJsFontWeight fontWeight = ChartJsFontWeight.Normal, string color = "#000") {
        Options.Plugins ??= new ChartJsPlugins();
        Options.Plugins.Title ??= new ChartJsTitle();
        Options.Plugins.Title.Display = true;
        Options.Plugins.Title.Text = text;
        Options.Plugins.Title.Font = new ChartJsFont {
            Size = fontSize,
            Weight = fontWeight
        };
        Options.Plugins.Title.Color = color;
        return this;
    }

    /// <summary>
    /// Sets the chart title with RGBColor support.
    /// </summary>
    public ChartJs TitleStyled(string text, int fontSize, ChartJsFontWeight fontWeight, RGBColor color) {
        return TitleStyled(text, fontSize, fontWeight, color.ToString());
    }

    /// <summary>
    /// Sets whether to show the legend.
    /// </summary>
    public ChartJs Legend(bool display = true, ChartJsPosition position = ChartJsPosition.Top) {
        Options.Plugins ??= new ChartJsPlugins();
        Options.Plugins.Legend ??= new ChartJsLegend();
        Options.Plugins.Legend.Display = display;
        Options.Plugins.Legend.Position = position;
        return this;
    }
    
    /// <summary>
    /// Configures the legend with advanced options.
    /// </summary>
    public ChartJs Legend(Action<ChartJsLegend> configure) {
        Options.Plugins ??= new ChartJsPlugins();
        Options.Plugins.Legend ??= new ChartJsLegend();
        configure(Options.Plugins.Legend);
        return this;
    }

    /// <summary>
    /// Configures legend labels with common settings.
    /// </summary>
    public ChartJs LegendLabels(int fontSize = 12, ChartJsFontWeight fontWeight = ChartJsFontWeight.Normal, 
                               string color = "#666", int padding = 10, bool usePointStyle = false) {
        Options.Plugins ??= new ChartJsPlugins();
        Options.Plugins.Legend ??= new ChartJsLegend();
        Options.Plugins.Legend.Labels = new ChartJsLegendLabels {
            Font = new ChartJsFont { Size = fontSize, Weight = fontWeight },
            Color = color,
            Padding = padding,
            UsePointStyle = usePointStyle
        };
        return this;
    }

    /// <summary>
    /// Configures legend labels with RGBColor support.
    /// </summary>
    public ChartJs LegendLabels(int fontSize, ChartJsFontWeight fontWeight, RGBColor color, 
                               int padding = 10, bool usePointStyle = false) {
        return LegendLabels(fontSize, fontWeight, color.ToString(), padding, usePointStyle);
    }

    /// <summary>
    /// Sets the responsive behavior.
    /// </summary>
    public ChartJs Responsive(bool responsive = true, bool maintainAspectRatio = true) {
        Options.Responsive = responsive;
        Options.MaintainAspectRatio = maintainAspectRatio;
        return this;
    }

    /// <summary>
    /// Sets the canvas dimensions.
    /// </summary>
    public ChartJs Size(string? width = null, string? height = null) {
        Width = width;
        Height = height;
        return this;
    }

    /// <summary>
    /// Disables animations.
    /// </summary>
    public ChartJs NoAnimation() {
        Options.Animation = false;
        return this;
    }

    /// <summary>
    /// Sets the Y-axis to begin at zero.
    /// </summary>
    public ChartJs BeginAtZero(bool enabled = true) {
        Options.Scales ??= new ChartJsScales();
        Options.Scales.Y ??= new ChartJsAxis();
        Options.Scales.Y.BeginAtZero = enabled;
        return this;
    }

    /// <summary>
    /// Sets the Y-axis to NOT begin at zero (allows floating scale).
    /// </summary>
    public ChartJs YAxisFloat() {
        Options.Scales ??= new ChartJsScales();
        Options.Scales.Y ??= new ChartJsAxis();
        Options.Scales.Y.BeginAtZero = false;
        return this;
    }
    
    /// <summary>
    /// Configures the chart as stacked (for bar and line charts).
    /// </summary>
    public ChartJs Stacked(bool enabled = true) {
        Options.Scales ??= new ChartJsScales();
        Options.Scales.X ??= new ChartJsAxis();
        Options.Scales.Y ??= new ChartJsAxis();
        Options.Scales.X.Stacked = enabled;
        Options.Scales.Y.Stacked = enabled;
        return this;
    }
    
    /// <summary>
    /// Configures the Y-axis with fluent API.
    /// </summary>
    public ChartJs YAxis(Action<ChartJsAxis> configure) {
        Options.Scales ??= new ChartJsScales();
        Options.Scales.Y ??= new ChartJsAxis();
        configure(Options.Scales.Y);
        return this;
    }
    
    /// <summary>
    /// Configures the X-axis with fluent API.
    /// </summary>
    public ChartJs XAxis(Action<ChartJsAxis> configure) {
        Options.Scales ??= new ChartJsScales();
        Options.Scales.X ??= new ChartJsAxis();
        configure(Options.Scales.X);
        return this;
    }

    /// <summary>
    /// Sets the Y-axis title.
    /// </summary>
    public ChartJs YAxisTitle(string text, bool display = true) {
        Options.Scales ??= new ChartJsScales();
        Options.Scales.Y ??= new ChartJsAxis();
        Options.Scales.Y.Title = new ChartJsAxisTitle { Display = display, Text = text };
        return this;
    }

    /// <summary>
    /// Sets the X-axis title.
    /// </summary>
    public ChartJs XAxisTitle(string text, bool display = true) {
        Options.Scales ??= new ChartJsScales();
        Options.Scales.X ??= new ChartJsAxis();
        Options.Scales.X.Title = new ChartJsAxisTitle { Display = display, Text = text };
        return this;
    }

    /// <summary>
    /// Sets the Y-axis range.
    /// </summary>
    public ChartJs YAxisRange(double? min = null, double? max = null) {
        Options.Scales ??= new ChartJsScales();
        Options.Scales.Y ??= new ChartJsAxis();
        if (min.HasValue) Options.Scales.Y.Min = min.Value;
        if (max.HasValue) Options.Scales.Y.Max = max.Value;
        return this;
    }

    /// <summary>
    /// Sets the X-axis range.
    /// </summary>
    public ChartJs XAxisRange(double? min = null, double? max = null) {
        Options.Scales ??= new ChartJsScales();
        Options.Scales.X ??= new ChartJsAxis();
        if (min.HasValue) Options.Scales.X.Min = min.Value;
        if (max.HasValue) Options.Scales.X.Max = max.Value;
        return this;
    }

    /// <summary>
    /// Configures Y-axis grid with common settings.
    /// </summary>
    public ChartJs YAxisGrid(string color = "rgba(0, 0, 0, 0.1)", int lineWidth = 1) {
        Options.Scales ??= new ChartJsScales();
        Options.Scales.Y ??= new ChartJsAxis();
        Options.Scales.Y.Grid = new ChartJsGrid {
            Color = color,
            LineWidth = lineWidth
        };
        return this;
    }

    /// <summary>
    /// Configures Y-axis grid with RGBColor support.
    /// </summary>
    public ChartJs YAxisGrid(RGBColor color, int lineWidth = 1) {
        return YAxisGrid(color.ToString(), lineWidth);
    }

    /// <summary>
    /// Configures X-axis grid with common settings.
    /// </summary>
    public ChartJs XAxisGrid(string color = "rgba(0, 0, 0, 0.1)", int lineWidth = 1) {
        Options.Scales ??= new ChartJsScales();
        Options.Scales.X ??= new ChartJsAxis();
        Options.Scales.X.Grid = new ChartJsGrid {
            Color = color,
            LineWidth = lineWidth
        };
        return this;
    }

    /// <summary>
    /// Configures X-axis grid with RGBColor support.
    /// </summary>
    public ChartJs XAxisGrid(RGBColor color, int lineWidth = 1) {
        return XAxisGrid(color.ToString(), lineWidth);
    }

    /// <summary>
    /// Configures Y-axis ticks with common settings.
    /// </summary>
    public ChartJs YAxisTicks(string color = "#666", int fontSize = 12) {
        Options.Scales ??= new ChartJsScales();
        Options.Scales.Y ??= new ChartJsAxis();
        Options.Scales.Y.Ticks = new ChartJsTicks {
            Color = color,
            Font = new ChartJsFont { Size = fontSize }
        };
        return this;
    }

    /// <summary>
    /// Configures Y-axis ticks with RGBColor support.
    /// </summary>
    public ChartJs YAxisTicks(RGBColor color, int fontSize = 12) {
        return YAxisTicks(color.ToString(), fontSize);
    }

    /// <summary>
    /// Configures X-axis ticks with common settings.
    /// </summary>
    public ChartJs XAxisTicks(string color = "#666", int fontSize = 12) {
        Options.Scales ??= new ChartJsScales();
        Options.Scales.X ??= new ChartJsAxis();
        Options.Scales.X.Ticks = new ChartJsTicks {
            Color = color,
            Font = new ChartJsFont { Size = fontSize }
        };
        return this;
    }

    /// <summary>
    /// Configures X-axis ticks with RGBColor support.
    /// </summary>
    public ChartJs XAxisTicks(RGBColor color, int fontSize = 12) {
        return XAxisTicks(color.ToString(), fontSize);
    }
    
    /// <summary>
    /// Configures the R-axis (for polar charts) with fluent API.
    /// </summary>
    public ChartJs RAxis(Action<ChartJsAxis> configure) {
        Options.Scales ??= new ChartJsScales();
        Options.Scales.R ??= new ChartJsAxis();
        configure(Options.Scales.R);
        return this;
    }

    /// <summary>
    /// Sets the R-axis range for polar charts.
    /// </summary>
    public ChartJs RAxisRange(double? min = null, double? max = null) {
        Options.Scales ??= new ChartJsScales();
        Options.Scales.R ??= new ChartJsAxis();
        if (min.HasValue) Options.Scales.R.Min = min.Value;
        if (max.HasValue) Options.Scales.R.Max = max.Value;
        return this;
    }
    
    /// <summary>
    /// Configures scales with fluent API.
    /// </summary>
    public ChartJs Scales(Action<ChartJsScales> configure) {
        Options.Scales ??= new ChartJsScales();
        configure(Options.Scales);
        return this;
    }
    
    /// <summary>
    /// Configures plugins with fluent API.
    /// </summary>
    public ChartJs Plugins(Action<ChartJsPlugins> configure) {
        Options.Plugins ??= new ChartJsPlugins();
        configure(Options.Plugins);
        return this;
    }
    
    /// <summary>
    /// Configures tooltip with fluent API.
    /// </summary>
    public ChartJs Tooltip(Action<ChartJsTooltip> configure) {
        Options.Plugins ??= new ChartJsPlugins();
        Options.Plugins.Tooltip ??= new ChartJsTooltip();
        configure(Options.Plugins.Tooltip);
        return this;
    }

    /// <summary>
    /// Configures tooltip with common settings.
    /// </summary>
    public ChartJs Tooltip(ChartJsInteractionMode mode = ChartJsInteractionMode.Index, bool intersect = false, 
                          string backgroundColor = "rgba(0, 0, 0, 0.8)", string titleColor = "#fff", 
                          string bodyColor = "#fff", string borderColor = "#ddd", int borderWidth = 1) {
        Options.Plugins ??= new ChartJsPlugins();
        Options.Plugins.Tooltip ??= new ChartJsTooltip();
        Options.Plugins.Tooltip.Mode = mode;
        Options.Plugins.Tooltip.Intersect = intersect;
        Options.Plugins.Tooltip.BackgroundColor = backgroundColor;
        Options.Plugins.Tooltip.TitleColor = titleColor;
        Options.Plugins.Tooltip.BodyColor = bodyColor;
        Options.Plugins.Tooltip.BorderColor = borderColor;
        Options.Plugins.Tooltip.BorderWidth = borderWidth;
        return this;
    }

    /// <summary>
    /// Configures tooltip with RGBColor support.
    /// </summary>
    public ChartJs Tooltip(ChartJsInteractionMode mode, bool intersect, RGBColor backgroundColor, 
                          RGBColor titleColor, RGBColor bodyColor, RGBColor borderColor, int borderWidth = 1) {
        return Tooltip(mode, intersect, backgroundColor.ToString(), titleColor.ToString(), 
                      bodyColor.ToString(), borderColor.ToString(), borderWidth);
    }
    
    /// <summary>
    /// Configures interaction with fluent API.
    /// </summary>
    public ChartJs Interaction(Action<ChartJsInteraction> configure) {
        Options.Interaction ??= new ChartJsInteraction();
        configure(Options.Interaction);
        return this;
    }

    /// <summary>
    /// Configures interaction with common settings.
    /// </summary>
    public ChartJs Interaction(ChartJsInteractionMode mode, bool intersect = false) {
        Options.Interaction ??= new ChartJsInteraction();
        Options.Interaction.Mode = mode;
        Options.Interaction.Intersect = intersect;
        return this;
    }
    
    /// <summary>
    /// Sets custom colors for the chart (for pie, doughnut, polarArea).
    /// </summary>
    public ChartJs Colors(params string[] colors) {
        if (Datasets.Count == 0 && Data.Count > 0) {
            // Create default dataset if using simple API
            var dataset = new ChartJsDataset { Label = "Dataset" };
            Datasets.Add(dataset);
        }
        
        if (Datasets.Count > 0) {
            var dataset = Datasets[0];
            dataset.BackgroundColor = colors;
        }
        
        return this;
    }
    
    /// <summary>
    /// Sets custom colors for the chart using RGBColor instances.
    /// </summary>
    public ChartJs Colors(params RGBColor[] colors) {
        return Colors(colors.Select(c => c.ToString()).ToArray());
    }
    
    /// <summary>
    /// Sets custom colors for the chart using a mix of RGBColor and string.
    /// </summary>
    public ChartJs Colors(params object[] colors) {
        var colorStrings = colors.Select(c => c switch {
            RGBColor rgb => rgb.ToString(),
            string str => str,
            _ => c.ToString() ?? string.Empty
        }).ToArray();
        
        return Colors(colorStrings);
    }
    
    /// <summary>
    /// Adds a dataset with custom colors.
    /// </summary>
    public ChartJs AddDataset(string label, string color, params double[] values) {
        var dataset = new ChartJsDataset {
            Label = label,
            Data = values.ToList(),
            BackgroundColor = color,
            BorderColor = color,
            BorderWidth = 1
        };
        Datasets.Add(dataset);
        return this;
    }
    
    /// <summary>
    /// Adds a dataset with custom RGBColor.
    /// </summary>
    public ChartJs AddDataset(string label, RGBColor color, params double[] values) {
        return AddDataset(label, color.ToString(), values);
    }
    
    /// <summary>
    /// Adds a dataset with custom object color (RGBColor or string).
    /// </summary>
    public ChartJs AddDataset(string label, object color, params double[] values) {
        var colorStr = color switch {
            RGBColor rgb => rgb.ToString(),
            string str => str,
            _ => color.ToString() ?? string.Empty
        };
        return AddDataset(label, colorStr, values);
    }

    /// <summary>
    /// Adds a dataset to the chart.
    /// </summary>
    public ChartJs AddDataset(Action<ChartJsDataset> configure) {
        var dataset = new ChartJsDataset();
        configure(dataset);
        Datasets.Add(dataset);
        return this;
    }

    /// <summary>
    /// Adds a simple dataset with values.
    /// </summary>
    public ChartJs AddDataset(string label, params double[] values) {
        var dataset = new ChartJsDataset {
            Label = label,
            Data = values.ToList()
        };
        
        // Auto-assign colors for common chart types
        if (Type == ChartJsType.Line || Type == ChartJsType.Bar) {
            var colorIndex = Datasets.Count % DefaultColors.Length;
            dataset.BackgroundColor = Type == ChartJsType.Line 
                ? $"rgba({DefaultColors[colorIndex]}, 0.2)" 
                : $"rgb({DefaultColors[colorIndex]})";
            dataset.BorderColor = $"rgb({DefaultColors[colorIndex]})";
            dataset.BorderWidth = Type == ChartJsType.Line ? 2 : 1;
        }
        
        Datasets.Add(dataset);
        return this;
    }
    
    /// <summary>
    /// Default colors for datasets (RGB values).
    /// </summary>
    private static readonly string[] DefaultColors = {
        "54, 162, 235",   // Blue
        "255, 99, 132",   // Red
        "255, 206, 86",   // Yellow
        "75, 192, 192",   // Teal
        "153, 102, 255",  // Purple
        "255, 159, 64",   // Orange
        "231, 233, 237"   // Gray
    };

    /// <summary>
    /// Configures chart options with full access.
    /// </summary>
    public ChartJs Configure(Action<ChartJsOptions> configure) {
        configure(Options);
        return this;
    }

    #endregion

    /// <summary>
    /// Generates the HTML required to render the chart.
    /// </summary>
    /// <returns>The HTML markup.</returns>
    public override string ToString() {
        var canvas = new HtmlTag("canvas").Id(Id);
        
        if (!string.IsNullOrEmpty(Width)) {
            canvas.Attributes["width"] = Width!;
        }
        
        if (!string.IsNullOrEmpty(Height)) {
            canvas.Attributes["height"] = Height!;
        }

        // If using the simple API, create a default dataset
        if (Datasets.Count == 0 && (Data.Count > 0 || Points.Count > 0 || Bubbles.Count > 0)) {
            var dataset = new ChartJsDataset { Label = "Dataset" };
            
            switch (Type) {
                case ChartJsType.Scatter:
                    dataset.PointData = Points.Select(p => (object)new { x = p.x, y = p.y }).ToList();
                    break;
                case ChartJsType.Bubble:
                    dataset.PointData = Bubbles.Select(p => (object)new { x = p.x, y = p.y, r = p.r }).ToList();
                    break;
                default:
                    dataset.Data = Data;
                    break;
            }
            
            Datasets.Add(dataset);
        }

        // Prepare the data object
        object dataObj;
        if (Type == ChartJsType.Scatter || Type == ChartJsType.Bubble) {
            dataObj = new {
                datasets = Datasets
            };
        } else {
            dataObj = new {
                labels = Labels,
                datasets = Datasets
            };
        }

        var config = new {
            type = Type,
            data = dataObj,
            options = Options
        };

        var options = new JsonSerializerOptions { 
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        
        // Add custom converters for enums
        options.Converters.Add(new ChartJsPositionConverter());
        options.Converters.Add(new ChartJsAlignConverter());
        options.Converters.Add(new ChartJsInteractionModeConverter());
        options.Converters.Add(new ChartJsFontStyleConverter());
        options.Converters.Add(new ChartJsFontWeightConverter());
        options.Converters.Add(new ChartJsPositionNullableConverter());
        options.Converters.Add(new ChartJsAlignNullableConverter());
        options.Converters.Add(new ChartJsInteractionModeNullableConverter());
        
        var json = JsonSerializer.Serialize(config, options);

        var script = new HtmlTag("script").Value($@"
(function() {{
    var ctx = document.getElementById('{Id}');
    if (ctx) {{
        ctx = ctx.getContext('2d');
        new Chart(ctx, {json});
    }}
}})();");

        return canvas + script.ToString();
    }
}