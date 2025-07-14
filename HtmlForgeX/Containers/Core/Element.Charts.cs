namespace HtmlForgeX;

public abstract partial class Element {
    public ApexCharts ApexChart(Action<ApexCharts> config) {
        var apexChart = new ApexCharts();
        config(apexChart);
        this.Add(apexChart);
        return apexChart;
    }

    public ChartJs ChartJs(Action<ChartJs> config) {
        var chartJs = new ChartJs();
        config(chartJs);
        this.Add(chartJs);
        return chartJs;
    }

    public VisNetwork DiagramNetwork(Action<VisNetwork> config) {
        var visNetwork = new VisNetwork();
        config(visNetwork);
        this.Add(visNetwork);
        return visNetwork;
    }
}
