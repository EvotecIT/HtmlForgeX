using System;
using System.Collections.Generic;

namespace HtmlForgeX.Examples.Charts;

internal class ChartsApexBasicDemo {
    public static void Create(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("ApexCharts Demo");

        using var document = new Document {
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
                            var random = new Random(0);
                            for (var i = 1; i <= 20; i++) {
                                chart.AddArea($"A{i}", random.Next(1, 20));
                            }
                            chart.Grid(g => g.PaddingOptions(p => p.All(4)));
                        });
                    });
                });
                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.ApexChart(chart => {
                            chart.Title.Text("Heatmap Chart");
                            var random = new Random(1);
                            for (var s = 1; s <= 5; s++) {
                                var points = new List<(string X, double Y)>();
                                for (var x = 1; x <= 10; x++) {
                                    points.Add(($"W{x}", random.Next(0, 10)));
                                }
                                chart.AddHeatmap($"S{s}", points);
                            }
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
                            var random = new Random(2);
                            for (var i = 1; i <= 6; i++) {
                                chart.AddRadar($"R{i}", random.Next(1, 10));
                            }
                            chart.Legend(l => l.ShowLegend(true))
                                 .Theme(t => t.ModeValue(ApexThemeMode.Dark));
                        });
                    });
                });
            });
        });

        document.Save("ChartsApexBasicDemo.html", openInBrowser);
    }
}