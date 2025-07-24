using System;
using System.Collections.Generic;
using System.Linq;

namespace HtmlForgeX.Examples.Charts;

internal class ChartsApexComprehensiveDemo {
    public static void Demo(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("ApexCharts Comprehensive Demo");

        using var document = new Document {
            Head = { Title = "ApexCharts Comprehensive Demo", Author = "HtmlForgeX" },
            LibraryMode = LibraryMode.Online,
            ThemeMode = ThemeMode.Light
        };

        document.Body.Page(page => {
            // Line Charts
            page.Row(row => {
                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.ApexChart(chart => {
                            chart.Title.Text("Basic Line Chart - Monthly Sales");
                            var months = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun" };
                            var sales = new[] { 30, 40, 35, 50, 49, 60 };

                            for (int i = 0; i < months.Length; i++) {
                                chart.AddLine(months[i], sales[i]);
                            }

                            chart.Stroke(s => s.SetCurve(ApexCurve.Smooth).SetWidth(3))
                                 .DataLabels(d => d.Enable(false))
                                 .Grid(g => g.PaddingOptions(p => p.All(2)));
                        });
                    });
                });

                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.ApexChart(chart => {
                            chart.Title.Text("Multi-Series Line Chart - Product Comparison");

                            chart.AddSeries("Product A", 44, 55, 57, 56, 61, 58)
                                 .AddSeries("Product B", 76, 85, 101, 98, 87, 105)
                                 .AddSeries("Product C", 35, 41, 36, 26, 45, 48);

                            chart.Stroke(s => s.SetCurve(ApexCurve.Smooth).SetWidth(2))
                                 .Colors(RGBColor.Blue, RGBColor.Green, RGBColor.Orange)
                                 .Legend(l => l.ShowLegend(true).Position(ApexPosition.Top));
                        });
                    });
                });
            });

            // Column and Bar Charts
            page.Row(row => {
                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.ApexChart(chart => {
                            chart.Title.Text("Column Chart with Data Labels - Quarterly Revenue");

                            var quarters = new[] { "Q1", "Q2", "Q3", "Q4" };
                            var revenue = new[] { 380, 430, 450, 470 };

                            for (int i = 0; i < quarters.Length; i++) {
                                chart.AddColumn(quarters[i], revenue[i]);
                            }

                            chart.DataLabels(d => d.Enable(true))
                                 .PlotOptions(p => p.BarOptions(b => b.BorderRadiusValue(4)))
                                 .Colors(RGBColor.Gray);
                        });
                    });
                });

                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.ApexChart(chart => {
                            chart.Title.Text("Horizontal Bar Chart - Top Products");

                            var products = new[] { "Product E", "Product D", "Product C", "Product B", "Product A" };
                            var values = new[] { 400, 430, 448, 470, 540 };

                            for (int i = 0; i < products.Length; i++) {
                                chart.AddBar(products[i], values[i]);
                            }

                            chart.PlotOptions(p => p.BarOptions(b => b.HorizontalValue(true)))
                                 .DataLabels(d => d.Enable(true).Offset(-6, 0))
                                 .Colors(RGBColor.Red);
                        });
                    });
                });
            });

            // Area Charts
            page.Row(row => {
                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.ApexChart(chart => {
                            chart.Title.Text("Gradient Area Chart - Website Traffic");

                            var random = new Random(42);
                            var days = new List<string>();
                            for (int i = 1; i <= 20; i++) {
                                days.Add($"Day {i}");
                                chart.AddArea($"Day {i}", random.Next(100, 500));
                            }

                            chart.Stroke(s => s.SetCurve(ApexCurve.Smooth).SetWidth(2))
                                 .Fill(f => f.SetType(ApexFillType.Gradient)
                                             .SetGradient(g => g.SetShade(ApexGradientShade.Dark)
                                                               .SetType(ApexGradientType.Vertical)
                                                               .SetOpacityRange(0.5, 0.1)))
                                 .DataLabels(d => d.Enable(false));
                        });
                    });
                });

                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.ApexChart(chart => {
                            chart.Title.Text("Stacked Area Chart - Server Load Distribution");
                            chart.Type = ApexChartType.Area;

                            chart.AddSeries("Server 1", 20, 29, 37, 36, 44, 45)
                                 .AddSeries("Server 2", 8, 12, 18, 16, 20, 24)
                                 .AddSeries("Server 3", 15, 17, 20, 25, 30, 28);

                            chart.Chart(c => c.SetStacked(true))
                                 .Fill(f => f.SetType(ApexFillType.Solid).SetOpacity(0.7));
                        });
                    });
                });
            });

            // Scatter and Bubble Charts
            page.Row(row => {
                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.ApexChart(chart => {
                            chart.Title.Text("Scatter Plot - Height vs Weight");

                            var random = new Random(123);
                            for (int i = 0; i < 30; i++) {
                                double height = 150 + random.Next(0, 50);
                                double weight = 50 + (height - 150) * 0.8 + random.Next(-10, 10);
                                chart.AddScatter(height, weight);
                            }

                            chart.XAxis(x => x.AxisType(ApexAxisType.Numeric).AxisTitle(t => t.SetText("Height (cm)")).Range(150, 200))
                                 .YAxis(y => y.AxisType(ApexAxisType.Numeric).AxisTitle(t => t.SetText("Weight (kg)")).Range(40, 100))
                                 .DataLabels(d => d.Enable(false));
                        });
                    });
                });

                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.ApexChart(chart => {
                            chart.Title.Text("Bubble Chart - Sales Analysis");

                            var random = new Random(456);
                            for (int i = 0; i < 20; i++) {
                                double x = random.Next(20, 80);
                                double y = random.Next(10, 70);
                                double z = random.Next(20, 60);
                                chart.AddBubble(x, y, z);
                            }

                            chart.XAxis(x => x.AxisType(ApexAxisType.Numeric).AxisTitle(t => t.SetText("Customer Satisfaction")))
                                 .YAxis(y => y.AxisType(ApexAxisType.Numeric).AxisTitle(t => t.SetText("Market Share")))
                                 .DataLabels(d => d.Enable(false))
                                 .Fill(f => f.SetOpacity(0.8));
                        });
                    });
                });
            });

            // Pie and Donut Charts
            page.Row(row => {
                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.ApexChart(chart => {
                            chart.Title.Text("Pie Chart with Custom Colors - Market Share");

                            chart.AddPie("Company A", 44)
                                 .AddPie("Company B", 33)
                                 .AddPie("Company C", 13)
                                 .AddPie("Others", 10);

                            chart.Colors(RGBColor.Pink, RGBColor.Blue, RGBColor.Yellow, RGBColor.Teal)
                                 .DataLabels(d => d.Enable(true))
                                 .Legend(l => l.ShowLegend(true).Position(ApexPosition.Bottom));
                        });
                    });
                });

                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.ApexChart(chart => {
                            chart.Title.Text("Donut Chart - Budget Distribution");

                            chart.AddDonut("Marketing", 35)
                                 .AddDonut("Development", 40)
                                 .AddDonut("Sales", 20)
                                 .AddDonut("Support", 5);

                            chart.PlotOptions(p => p.PieOptions(pie => pie.DonutSize("65%")))
                                 .DataLabels(d => d.Enable(false))
                                 .Legend(l => l.ShowLegend(true).Position(ApexPosition.Right));
                        });
                    });
                });
            });

            // Radial and Radar Charts
            page.Row(row => {
                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.ApexChart(chart => {
                            chart.Title.Text("Radial Bar Chart - Progress Tracker");

                            chart.AddRadialBar("Completed", 75)
                                 .AddRadialBar("In Progress", 50)
                                 .AddRadialBar("Planned", 25);

                            chart.PlotOptions(p => p.RadialBarOptions(r => r
                                .HollowSize("70%")
                                .TrackBackground("#f2f2f2")))
                                 .Colors(RGBColor.Green, RGBColor.Orange, RGBColor.Red);
                        });
                    });
                });

                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.ApexChart(chart => {
                            chart.Title.Text("Radar Chart - Developer Skills");

                            chart.AddRadar("JavaScript", 85)
                                 .AddRadar("TypeScript", 75)
                                 .AddRadar("React", 90)
                                 .AddRadar("Node.js", 80)
                                 .AddRadar("CSS", 70)
                                 .AddRadar("Testing", 65);

                            chart.PlotOptions(p => p.RadarOptions(r => r.PolygonsStrokeColors("#e8e8e8")))
                                 .Stroke(s => s.ShowStroke(true).SetWidth(2))
                                 .Fill(f => f.SetOpacity(0.5))
                                 .Tooltip(t => t.Enable(true));
                        });
                    });
                });
            });

            // Advanced Charts
            page.Row(row => {
                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.ApexChart(chart => {
                            chart.Title.Text("Candlestick Chart - Stock Price Movement");

                            var dates = new[] { "2024-01-01", "2024-01-02", "2024-01-03", "2024-01-04", "2024-01-05" };
                            var prices = new[] {
                                new[] { 100.0, 110.0, 95.0, 105.0 },  // open, high, low, close
                                new[] { 105.0, 112.0, 102.0, 108.0 },
                                new[] { 108.0, 108.0, 98.0, 100.0 },
                                new[] { 100.0, 115.0, 100.0, 113.0 },
                                new[] { 113.0, 118.0, 110.0, 115.0 }
                            };

                            for (int i = 0; i < dates.Length; i++) {
                                chart.AddCandlestick(dates[i], prices[i][0], prices[i][1], prices[i][2], prices[i][3]);
                            }

                            chart.XAxis(x => x.AxisType(ApexAxisType.Datetime))
                                 .YAxis(y => y.AxisTitle(t => t.SetText("Price ($)")))
                                 .Tooltip(t => t.Enable(true));
                        });
                    });
                });

                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.ApexChart(chart => {
                            chart.Title.Text("BoxPlot Chart - Performance Distribution");

                            chart.AddBoxPlot("Team A", 54, 66, 69, 75, 88)
                                 .AddBoxPlot("Team B", 43, 65, 69, 76, 81)
                                 .AddBoxPlot("Team C", 31, 39, 45, 51, 59)
                                 .AddBoxPlot("Team D", 39, 46, 55, 65, 71)
                                 .AddBoxPlot("Team E", 29, 31, 35, 39, 44);

                            chart.PlotOptions(p => p.BoxPlotOptions(b => b.ColorsUpper("#8BC34A").ColorsLower("#F44336")))
                                 .Stroke(s => s.SetColors(new[] { "#6c757d" }));
                        });
                    });
                });
            });

            // Heatmap and Treemap
            page.Row(row => {
                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.ApexChart(chart => {
                            chart.Title.Text("Heatmap - Weekly Activity Monitor");

                            var days = new[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
                            var random = new Random(789);

                            // Create more varied data for better visualization
                            var patterns = new[] {
                                new[] { 10, 15, 20, 25, 30, 20, 15 }, // Early morning
                                new[] { 20, 25, 30, 35, 40, 25, 20 }, // Morning
                                new[] { 50, 60, 70, 75, 80, 40, 30 }, // Mid-morning
                                new[] { 80, 90, 95, 100, 95, 50, 40 }, // Noon
                                new[] { 70, 80, 85, 90, 85, 60, 50 }, // Afternoon
                                new[] { 60, 70, 75, 80, 75, 70, 60 }, // Evening
                                new[] { 30, 40, 45, 50, 45, 80, 90 }, // Night
                                new[] { 10, 15, 20, 25, 20, 60, 70 }  // Late night
                            };

                            for (int hour = 0; hour < 24; hour++) {
                                var points = new List<(string X, double Y)>();
                                var patternIndex = hour / 3 % patterns.Length;
                                for (int d = 0; d < days.Length; d++) {
                                    var baseValue = patterns[patternIndex][d];
                                    var variation = random.Next(-10, 10);
                                    points.Add((days[d], Math.Max(0, Math.Min(100, baseValue + variation))));
                                }
                                chart.AddHeatmap($"{hour:00}:00", points);
                            }

                            chart.PlotOptions(o => o.HeatmapOptions(h => h.RadiusValue(0)))
                                 .DataLabels(d => d.Enable(false))
                                 .XAxis(x => x.SetCategories(days))
                                 .Colors(RGBColor.Blue);
                        });
                    });
                });

                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.ApexChart(chart => {
                            chart.Title.Text("Treemap Chart - File System Usage");

                            chart.AddTreemap("Documents", 45)
                                 .AddTreemap("Pictures", 30)
                                 .AddTreemap("Videos", 15)
                                 .AddTreemap("Music", 8)
                                 .AddTreemap("Others", 2);

                            chart.Legend(l => l.ShowLegend(true).Position(ApexPosition.Top))
                                 .DataLabels(d => d.Enable(true))
                                 .Colors("#33b2df", "#546E7A", "#d4526e", "#13d8aa", "#A5978B");
                        });
                    });
                });
            });

            // Mixed and Special Charts
            page.Row(row => {
                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.ApexChart(chart => {
                            chart.Title.Text("Funnel Chart - Sales Process");

                            var stages = new[] { "Website Visits", "Downloads", "Trials", "Purchases", "Renewals" };
                            var values = new[] { 1000, 700, 400, 200, 150 };

                            for (int i = 0; i < stages.Length; i++) {
                                chart.AddFunnel(stages[i], values[i]);
                            }

                            chart.PlotOptions(p => p.BarOptions(b => b
                                .HorizontalValue(true)
                                .IsFunnel(true)))
                                 .DataLabels(d => d.Enable(true))
                                 .Tooltip(t => t.Enable(true))
                                 .Colors(RGBColor.Teal);
                        });
                    });
                });

                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.ApexChart(chart => {
                            chart.Title.Text("Polar Area Chart - Department Budget");

                            chart.AddPolarArea("Research", 42)
                                 .AddPolarArea("Marketing", 35)
                                 .AddPolarArea("Operations", 28)
                                 .AddPolarArea("Finance", 20)
                                 .AddPolarArea("HR", 15);

                            chart.Stroke(s => s.SetColors(new[] { "#fff" }).SetWidth(2))
                                 .Fill(f => f.SetOpacity(0.8));
                        });
                    });
                });
            });
        });

        document.Save("ApexChartsComprehensive.html", openInBrowser);
    }
}