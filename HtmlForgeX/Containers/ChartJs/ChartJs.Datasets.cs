using System;
using System.Collections.Generic;
using System.Linq;

namespace HtmlForgeX;

public partial class ChartJs {
    /// <summary>
    /// Adds a numeric data point with an associated label.
    /// </summary>
    /// <param name="label">Label for the value.</param>
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
    /// Sets custom colors for the chart (for pie, doughnut and polarArea types).
    /// </summary>
    /// <param name="colors">Array of color strings.</param>
    /// <returns>The current <see cref="ChartJs"/> instance.</returns>
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
    /// Sets custom colors for the chart using <see cref="RGBColor"/> instances.
    /// </summary>
    /// <param name="colors">Colors to apply.</param>
    /// <returns>The current <see cref="ChartJs"/> instance.</returns>
    public ChartJs Colors(params RGBColor[] colors) {
        return Colors(colors.Select(c => c.ToString()).ToArray());
    }

    /// <summary>
    /// Sets custom colors for the chart using a mix of <see cref="RGBColor"/> and strings.
    /// </summary>
    /// <param name="colors">Color values.</param>
    /// <returns>The current <see cref="ChartJs"/> instance.</returns>
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
    /// <param name="label">Dataset label.</param>
    /// <param name="color">Color for the dataset.</param>
    /// <param name="values">Data values.</param>
    /// <returns>The current <see cref="ChartJs"/> instance.</returns>
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
    /// Adds a dataset with a custom <see cref="RGBColor"/>.
    /// </summary>
    /// <param name="label">Dataset label.</param>
    /// <param name="color">RGB color value.</param>
    /// <param name="values">Data values.</param>
    /// <returns>The current <see cref="ChartJs"/> instance.</returns>
    public ChartJs AddDataset(string label, RGBColor color, params double[] values) {
        return AddDataset(label, color.ToString(), values);
    }

    /// <summary>
    /// Adds a dataset with a color specified as <see cref="RGBColor"/> or string.
    /// </summary>
    /// <param name="label">Dataset label.</param>
    /// <param name="color">Color value.</param>
    /// <param name="values">Data values.</param>
    /// <returns>The current <see cref="ChartJs"/> instance.</returns>
    public ChartJs AddDataset(string label, object color, params double[] values) {
        var colorStr = color switch {
            RGBColor rgb => rgb.ToString(),
            string str => str,
            _ => color.ToString() ?? string.Empty
        };
        return AddDataset(label, colorStr, values);
    }

    /// <summary>
    /// Adds a dataset configured via delegate.
    /// </summary>
    /// <param name="configure">Action configuring the dataset.</param>
    /// <returns>The current <see cref="ChartJs"/> instance.</returns>
    public ChartJs AddDataset(Action<ChartJsDataset> configure) {
        var dataset = new ChartJsDataset();
        configure(dataset);
        Datasets.Add(dataset);
        return this;
    }

    /// <summary>
    /// Adds a simple dataset with values.
    /// </summary>
    /// <param name="label">Dataset label.</param>
    /// <param name="values">Data values.</param>
    /// <returns>The current <see cref="ChartJs"/> instance.</returns>
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
}