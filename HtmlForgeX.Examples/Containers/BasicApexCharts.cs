using System;

namespace HtmlForgeX.Examples.Containers;

internal class BasicApexCharts {
    public static void Demo(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("ApexCharts Demo");

        var document = new Document {
            Head = { Title = "ApexCharts Demo", Author = "HtmlForgeX" },
            LibraryMode = LibraryMode.Online,
            ThemeMode = ThemeMode.Light
        };

        document.Body.Page(page => {
            page.Row(row => {
                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.ApexChart(chart => {
                            chart.Title.Text("Area Chart");
                            chart.AddArea("A", 10)
                                 .AddArea("B", 5);
                            chart.Grid(g => g.PaddingOptions(p => p.All(4)));
                        });
                    });
                });
                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.ApexChart(chart => {
                            chart.Title.Text("Heatmap Chart");
                            chart.AddHeatmap("H1", 5)
                                 .AddHeatmap("H2", 7);
                            chart.PlotOptions(o => o.HeatmapOptions(h => h.RadiusValue(2)));
                        });
                    });
                });
            });
            page.Row(row => {
                row.Column(TablerColumnNumber.Twelve, col => {
                    col.Card(card => {
                        card.ApexChart(chart => {
                            chart.Title.Text("Radar Chart");
                            chart.AddRadar("R1", 3)
                                 .AddRadar("R2", 4);
                            chart.Legend(l => l.ShowLegend(true))
                                 .Theme(t => t.ModeValue(ApexThemeMode.Dark));
                        });
                    });
                });
            });
        });

        document.Save("ApexChartsDemo.html", openInBrowser);
    }
}
