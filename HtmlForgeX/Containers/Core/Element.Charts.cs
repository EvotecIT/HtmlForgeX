namespace HtmlForgeX;

public abstract partial class Element {
    /// <summary>
    /// Adds an <see cref="ApexCharts"/> element and applies the provided configuration.
    /// </summary>
    /// <param name="config">Action used to configure the chart.</param>
    /// <returns>The created chart element.</returns>
    public ApexCharts ApexChart(Action<ApexCharts> config) {
        var apexChart = new ApexCharts();
        config(apexChart);
        this.Add(apexChart);
        return apexChart;
    }

    /// <summary>
    /// Adds a <see cref="ChartJs"/> element and applies the provided configuration.
    /// </summary>
    /// <param name="config">Action used to configure the chart.</param>
    /// <returns>The created chart element.</returns>
    public ChartJs ChartJs(Action<ChartJs> config) {
        var chartJs = new ChartJs();
        config(chartJs);
        this.Add(chartJs);
        return chartJs;
    }

    /// <summary>
    /// Adds a <see cref="VisNetwork"/> element and applies the provided configuration.
    /// </summary>
    /// <param name="config">Action used to configure the network diagram.</param>
    /// <returns>The created network element.</returns>
    public VisNetwork DiagramNetwork(Action<VisNetwork> config) {
        var visNetwork = new VisNetwork();
        config(visNetwork);
        this.Add(visNetwork);
        return visNetwork;
    }
}
