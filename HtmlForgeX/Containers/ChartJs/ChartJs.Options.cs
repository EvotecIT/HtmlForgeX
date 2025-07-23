using System;

namespace HtmlForgeX;

public partial class ChartJs {
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
    /// Configures chart options with full access.
    /// </summary>
    public ChartJs Configure(Action<ChartJsOptions> configure) {
        configure(Options);
        return this;
    }
#endregion
}
