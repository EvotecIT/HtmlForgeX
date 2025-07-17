using System.Collections.Generic;

namespace HtmlForgeX.Examples.Containers;

internal class BasicChartJs {
    public static void Demo(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("ChartJs Demo - Enhanced");

        using var document = new Document {
            Head = { Title = "ChartJs Demo - Enhanced", Author = "HtmlForgeX" },
            LibraryMode = LibraryMode.Online,
            ThemeMode = ThemeMode.Light
        };

        document.Body.Page(page => {
            page.Layout = TablerLayout.Fluid;
            
            // Header
            page.Add(new HeaderLevel(HeaderLevelTag.H1, "📊 ChartJs Enhanced Demo"));
            page.Text("Comprehensive Chart.js integration with fluent API")
                .Style(TablerTextStyle.Muted).Weight(TablerFontWeight.Medium);

            // Basic Charts
            page.Divider("Basic Charts");
            page.Row(row => {
                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.Header(header => header.Title("Line Chart with Options"));
                        card.Body(body => {
                            body.ChartJs(chart => {
                                chart.Line()
                                     .Title("Monthly Sales")
                                     .AddData("Jan", 30)
                                     .AddData("Feb", 70)
                                     .AddData("Mar", 40)
                                     .AddData("Apr", 90)
                                     .AddData("May", 55)
                                     .AddData("Jun", 80)
                                     .BeginAtZero()
                                     .Legend(true, ChartJsPosition.Bottom);
                            });
                        });
                    });
                });
                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.Header(header => header.Title("Pie Chart with Custom Colors"));
                        card.Body(body => {
                            body.ChartJs(chart => {
                                chart.Pie()
                                     .Title("Browser Market Share")
                                     .AddData("Chrome", 60)
                                     .AddData("Firefox", 20)
                                     .AddData("Safari", 15)
                                     .AddData("Edge", 5)
                                     .Legend(true, ChartJsPosition.Right);
                            });
                        });
                    });
                });
            });

            // Advanced Charts
            page.Divider("Advanced Chart Types");
            page.Row(row => {
                row.Column(TablerColumnNumber.Four, col => {
                    col.Card(card => {
                        card.Header(header => header.Title("Doughnut Chart"));
                        card.Body(body => {
                            body.ChartJs(c => {
                                c.Doughnut()
                                 .Title("Product Categories")
                                 .AddData("Electronics", 45)
                                 .AddData("Clothing", 25)
                                 .AddData("Food", 20)
                                 .AddData("Books", 10)
                                 .Configure(opt => {
                                     opt.Plugins ??= new ChartJsPlugins();
                                     opt.Plugins.Legend ??= new ChartJsLegend();
                                     opt.Plugins.Legend.Position = ChartJsPosition.Right;
                                 });
                            });
                        });
                    });
                });
                row.Column(TablerColumnNumber.Four, col => {
                    col.Card(card => {
                        card.Header(header => header.Title("Polar Area Chart"));
                        card.Body(body => {
                            body.ChartJs(c => {
                                c.PolarArea()
                                 .Title("Activity Distribution")
                                 .AddData("Running", 12)
                                 .AddData("Swimming", 8)
                                 .AddData("Cycling", 15)
                                 .AddData("Walking", 10)
                                 .NoAnimation();
                            });
                        });
                    });
                });
                row.Column(TablerColumnNumber.Four, col => {
                    col.Card(card => {
                        card.Header(header => header.Title("Radar Chart"));
                        card.Body(body => {
                            body.ChartJs(c => {
                                c.Radar()
                                 .Title("Skills Assessment")
                                 .AddLabels("JavaScript", "Python", "C#", "SQL", "DevOps")
                                 .AddDataset("Developer A", 85, 75, 90, 80, 95)
                                 .Configure(opt => {
                                     opt.Scales ??= new ChartJsScales();
                                     opt.Scales.R ??= new ChartJsAxis();
                                     opt.Scales.R.SuggestedMin = 0;
                                     opt.Scales.R.SuggestedMax = 100;
                                 });
                            });
                        });
                    });
                });
            });

            // Scatter and Bubble Charts
            page.Divider("Data Visualization Charts");
            page.Row(row => {
                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.Header(header => header.Title("Scatter Plot"));
                        card.Body(body => {
                            body.ChartJs(c => {
                                c.Scatter()
                                 .Title("Correlation Analysis")
                                 .AddPoint(10, 20)
                                 .AddPoint(15, 25)
                                 .AddPoint(20, 30)
                                 .AddPoint(25, 18)
                                 .AddPoint(30, 35)
                                 .Configure(opt => {
                                     opt.Scales ??= new ChartJsScales();
                                     opt.Scales.X ??= new ChartJsAxis();
                                     opt.Scales.X.Title = new ChartJsAxisTitle { Display = true, Text = "X Values" };
                                     opt.Scales.Y ??= new ChartJsAxis();
                                     opt.Scales.Y.Title = new ChartJsAxisTitle { Display = true, Text = "Y Values" };
                                 });
                            });
                        });
                    });
                });
                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.Header(header => header.Title("Bubble Chart"));
                        card.Body(body => {
                            body.ChartJs(c => {
                                c.Bubble()
                                 .Title("Market Analysis")
                                 .AddBubble(10, 20, 15)
                                 .AddBubble(15, 25, 10)
                                 .AddBubble(20, 30, 25)
                                 .AddBubble(25, 18, 8)
                                 .AddBubble(30, 35, 18)
                                 .Configure(opt => {
                                     opt.Scales ??= new ChartJsScales();
                                     opt.Scales.X ??= new ChartJsAxis();
                                     opt.Scales.X.Title = new ChartJsAxisTitle { Display = true, Text = "Price ($)" };
                                     opt.Scales.Y ??= new ChartJsAxis();
                                     opt.Scales.Y.Title = new ChartJsAxisTitle { Display = true, Text = "Sales" };
                                     opt.Plugins ??= new ChartJsPlugins();
                                     opt.Plugins.Tooltip = new ChartJsTooltip {
                                         Mode = ChartJsInteractionMode.Point
                                     };
                                 });
                            });
                        });
                    });
                });
            });

            // Multi-dataset Examples
            page.Divider("Multi-Dataset Charts");
            page.Row(row => {
                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.Header(header => header.Title("Multi-Line Chart"));
                        card.Body(body => {
                            body.ChartJs(chart => {
                                chart.Line()
                                     .Title("Revenue Comparison")
                                     .AddLabels("Q1", "Q2", "Q3", "Q4")
                                     .AddDataset("2023", 65, 59, 80, 81)
                                     .AddDataset("2024", 85, 69, 90, 101)
                                     .BeginAtZero();
                            });
                        });
                    });
                });
                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.Header(header => header.Title("Stacked Bar Chart"));
                        card.Body(body => {
                            body.ChartJs(chart => {
                                chart.Bar()
                                     .Title("Department Budget")
                                     .AddLabels("Jan", "Feb", "Mar", "Apr")
                                     .AddDataset("Marketing", 20, 30, 25, 35)
                                     .AddDataset("Development", 40, 35, 45, 40)
                                     .AddDataset("Operations", 30, 25, 30, 25)
                                     .BeginAtZero()
                                     .Stacked();
                            });
                        });
                    });
                });
            });

            // Configuration Examples
            page.Divider("Advanced Configuration");
            page.Row(row => {
                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.Header(header => header.Title("Custom Styled Chart"));
                        card.Body(body => {
                            body.ChartJs(chart => {
                                chart.Line()
                                     .Title("Custom Styling Example")
                                     .AddLabels("Mon", "Tue", "Wed", "Thu", "Fri")
                                     .AddDataset(ds => {
                                         ds.Label = "Sales";
                                         ds.Data = new List<double> { 12, 19, 3, 17, 6 };
                                         ds.BackgroundColor = "rgba(255, 99, 132, 0.4)";
                                         ds.BorderColor = "#ff6384";
                                         ds.BorderWidth = 3;
                                         ds.PointBackgroundColor = "#fff";
                                         ds.PointBorderColor = "#ff6384";
                                         ds.PointBorderWidth = 2;
                                         ds.PointRadius = 6;
                                         ds.PointHoverRadius = 8;
                                         ds.PointHoverBackgroundColor = "#ff6384";
                                         ds.PointHoverBorderColor = "#fff";
                                         ds.PointHoverBorderWidth = 2;
                                         ds.Tension = 0.4;
                                     })
                                     .Configure(opt => {
                                         opt.Plugins ??= new ChartJsPlugins();
                                         opt.Plugins.Title ??= new ChartJsTitle();
                                         opt.Plugins.Title.Font = new ChartJsFont {
                                             Size = 20,
                                             Weight = "bold"
                                         };
                                         opt.Plugins.Title.Color = "#2c3e50";
                                         
                                         opt.Plugins.Legend ??= new ChartJsLegend();
                                         opt.Plugins.Legend.Labels = new ChartJsLegendLabels {
                                             Font = new ChartJsFont { Size = 14, Weight = "600" },
                                             Padding = 20,
                                             Color = "#34495e"
                                         };
                                         
                                         opt.Scales ??= new ChartJsScales();
                                         opt.Scales.X ??= new ChartJsAxis();
                                         opt.Scales.X.Grid = new ChartJsGrid {
                                             Color = "rgba(52, 73, 94, 0.1)",
                                             LineWidth = 1
                                         };
                                         opt.Scales.X.Ticks = new ChartJsTicks {
                                             Color = "#7f8c8d",
                                             Font = new ChartJsFont { Size = 12 }
                                         };
                                         
                                         opt.Scales.Y ??= new ChartJsAxis();
                                         opt.Scales.Y.Grid = new ChartJsGrid {
                                             Color = "rgba(52, 73, 94, 0.1)",
                                             LineWidth = 1
                                         };
                                         opt.Scales.Y.Ticks = new ChartJsTicks {
                                             Color = "#7f8c8d",
                                             Font = new ChartJsFont { Size = 12 }
                                         };
                                         opt.Scales.Y.BeginAtZero = true;
                                     });
                            });
                        });
                    });
                });
                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.Header(header => header.Title("Chart with Custom Tooltips"));
                        card.Body(body => {
                            body.ChartJs(chart => {
                                chart.Bar()
                                     .Title("Interactive Tooltips")
                                     .AddData("Product A", 45)
                                     .AddData("Product B", 37)
                                     .AddData("Product C", 60)
                                     .AddData("Product D", 70)
                                     .Configure(opt => {
                                         opt.Plugins ??= new ChartJsPlugins();
                                         opt.Plugins.Tooltip = new ChartJsTooltip {
                                             BackgroundColor = "rgba(0, 0, 0, 0.8)",
                                             TitleColor = "#fff",
                                             BodyColor = "#fff",
                                             BorderColor = "#ddd",
                                             BorderWidth = 1,
                                             Mode = ChartJsInteractionMode.Index,
                                             Intersect = false
                                         };
                                         opt.Interaction = new ChartJsInteraction {
                                             Mode = ChartJsInteractionMode.Nearest,
                                             Intersect = false
                                         };
                                     });
                            });
                        });
                    });
                });
            });
            
            // ENHANCED CHART SHOWCASE - 20 Additional Complex Charts
            
            // Financial & Business Charts
            page.Divider("Financial & Business Analytics");
            page.Row(row => {
                row.Column(TablerColumnNumber.Four, col => {
                    col.Card(card => {
                        card.Header(header => header.Title("Stock Price Candlestick Style"));
                        card.Body(body => {
                            body.ChartJs(chart => {
                                chart.Line()
                                     .Title("AAPL Stock Movement")
                                     .AddLabels("9:00", "10:00", "11:00", "12:00", "1:00", "2:00", "3:00", "4:00")
                                     .AddDataset(ds => {
                                         ds.Label = "High";
                                         ds.Data = new List<double> { 150, 152, 149, 153, 155, 154, 156, 158 };
                                         ds.BorderColor = "#27ae60";
                                         ds.BackgroundColor = "rgba(39, 174, 96, 0.1)";
                                         ds.BorderWidth = 2;
                                         ds.Fill = false;
                                     })
                                     .AddDataset(ds => {
                                         ds.Label = "Low";
                                         ds.Data = new List<double> { 148, 149, 146, 150, 152, 151, 153, 155 };
                                         ds.BorderColor = "#e74c3c";
                                         ds.BackgroundColor = "rgba(231, 76, 60, 0.1)";
                                         ds.BorderWidth = 2;
                                         ds.Fill = false;
                                     })
                                     .Configure(opt => {
                                         opt.Scales ??= new ChartJsScales();
                                         opt.Scales.Y ??= new ChartJsAxis();
                                         opt.Scales.Y.BeginAtZero = false;
                                         opt.Scales.Y.Min = 140;
                                         opt.Scales.Y.Max = 160;
                                         opt.Plugins ??= new ChartJsPlugins();
                                         opt.Plugins.Legend ??= new ChartJsLegend();
                                         opt.Plugins.Legend.Position = ChartJsPosition.Bottom;
                                     });
                            });
                        });
                    });
                });
                row.Column(TablerColumnNumber.Four, col => {
                    col.Card(card => {
                        card.Header(header => header.Title("Revenue Breakdown"));
                        card.Body(body => {
                            body.ChartJs(chart => {
                                chart.Doughnut()
                                     .Title("Q4 Revenue by Product")
                                     .AddLabels("SaaS", "Consulting", "Licenses", "Support")
                                     .AddDataset(ds => {
                                         ds.Label = "Revenue";
                                         ds.Data = new List<double> { 45, 25, 20, 10 };
                                         ds.BackgroundColor = new List<string> { "#3498db", "#e74c3c", "#f39c12", "#27ae60" };
                                         ds.BorderColor = new List<string> { "#3498db", "#e74c3c", "#f39c12", "#27ae60" };
                                         ds.BorderWidth = 2;
                                     })
                                     .Configure(opt => {
                                         opt.Plugins ??= new ChartJsPlugins();
                                         opt.Plugins.Legend ??= new ChartJsLegend();
                                         opt.Plugins.Legend.Position = ChartJsPosition.Right;
                                         opt.Plugins.Legend.Labels = new ChartJsLegendLabels {
                                             Font = new ChartJsFont { Size = 12 },
                                             UsePointStyle = true,
                                             Padding = 15
                                         };
                                     });
                            });
                        });
                    });
                });
                row.Column(TablerColumnNumber.Four, col => {
                    col.Card(card => {
                        card.Header(header => header.Title("KPI Dashboard"));
                        card.Body(body => {
                            body.ChartJs(chart => {
                                chart.Bar()
                                     .Title("Monthly KPIs")
                                     .AddLabels("Revenue", "Customers", "Conversion", "Retention")
                                     .AddDataset(ds => {
                                         ds.Label = "Target";
                                         ds.Data = new List<double> { 100, 100, 100, 100 };
                                         ds.BackgroundColor = "rgba(149, 165, 166, 0.3)";
                                         ds.BorderColor = "#95a5a6";
                                         ds.BorderWidth = 1;
                                     })
                                     .AddDataset(ds => {
                                         ds.Label = "Actual";
                                         ds.Data = new List<double> { 95, 112, 87, 103 };
                                         ds.BackgroundColor = new[] { "#e74c3c", "#27ae60", "#f39c12", "#27ae60" };
                                         ds.BorderColor = new[] { "#c0392b", "#229954", "#d68910", "#229954" };
                                         ds.BorderWidth = 2;
                                     })
                                     .BeginAtZero();
                            });
                        });
                    });
                });
            });
            
            // Data Science & Analytics Charts
            page.Divider("Data Science & Analytics");
            page.Row(row => {
                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.Header(header => header.Title("Distribution Analysis"));
                        card.Body(body => {
                            body.ChartJs(chart => {
                                chart.Line()
                                     .Title("Normal Distribution Curve")
                                     .AddLabels("-3σ", "-2σ", "-1σ", "μ", "1σ", "2σ", "3σ")
                                     .AddDataset(ds => {
                                         ds.Label = "Distribution";
                                         ds.Data = new List<double> { 0.4, 5.4, 24.2, 39.9, 24.2, 5.4, 0.4 };
                                         ds.BorderColor = "#9b59b6";
                                         ds.BackgroundColor = "rgba(155, 89, 182, 0.2)";
                                         ds.BorderWidth = 3;
                                         ds.PointRadius = 6;
                                         ds.PointBackgroundColor = "#8e44ad";
                                         ds.PointBorderColor = "#fff";
                                         ds.PointBorderWidth = 2;
                                         ds.Tension = 0.4;
                                         ds.Fill = true;
                                     })
                                     .Configure(opt => {
                                         opt.Scales ??= new ChartJsScales();
                                         opt.Scales.Y ??= new ChartJsAxis();
                                         opt.Scales.Y.Title = new ChartJsAxisTitle { Display = true, Text = "Probability %" };
                                         opt.Scales.X ??= new ChartJsAxis();
                                         opt.Scales.X.Title = new ChartJsAxisTitle { Display = true, Text = "Standard Deviations" };
                                     });
                            });
                        });
                    });
                });
                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.Header(header => header.Title("A/B Test Results"));
                        card.Body(body => {
                            body.ChartJs(chart => {
                                chart.Bar()
                                     .Title("Conversion Rate Comparison")
                                     .AddLabels("Week 1", "Week 2", "Week 3", "Week 4")
                                     .AddDataset(ds => {
                                         ds.Label = "Variant A";
                                         ds.Data = new List<double> { 12.3, 13.1, 12.8, 13.5 };
                                         ds.BackgroundColor = "#3498db";
                                         ds.BorderColor = "#2980b9";
                                         ds.BorderWidth = 2;
                                     })
                                     .AddDataset(ds => {
                                         ds.Label = "Variant B";
                                         ds.Data = new List<double> { 14.2, 15.1, 14.9, 15.8 };
                                         ds.BackgroundColor = "#e74c3c";
                                         ds.BorderColor = "#c0392b";
                                         ds.BorderWidth = 2;
                                     })
                                     .BeginAtZero()
                                     .Configure(opt => {
                                         opt.Scales ??= new ChartJsScales();
                                         opt.Scales.Y ??= new ChartJsAxis();
                                         opt.Scales.Y.Title = new ChartJsAxisTitle { Display = true, Text = "Conversion Rate %" };
                                         opt.Plugins ??= new ChartJsPlugins();
                                         opt.Plugins.Legend ??= new ChartJsLegend();
                                         opt.Plugins.Legend.Position = ChartJsPosition.Top;
                                     });
                            });
                        });
                    });
                });
            });
            
            // Performance & Monitoring Charts
            page.Divider("Performance & System Monitoring");
            page.Row(row => {
                row.Column(TablerColumnNumber.Four, col => {
                    col.Card(card => {
                        card.Header(header => header.Title("CPU Usage"));
                        card.Body(body => {
                            body.ChartJs(chart => {
                                chart.Line()
                                     .Title("Multi-Core CPU Monitoring")
                                     .AddLabels("00:00", "00:15", "00:30", "00:45", "01:00", "01:15", "01:30")
                                     .AddDataset(ds => {
                                         ds.Label = "Core 1";
                                         ds.Data = new List<double> { 45, 52, 48, 61, 55, 67, 59 };
                                         ds.BorderColor = "#e74c3c";
                                         ds.BackgroundColor = "rgba(231, 76, 60, 0.1)";
                                         ds.BorderWidth = 2;
                                         ds.PointRadius = 4;
                                         ds.Tension = 0.3;
                                         ds.Fill = false;
                                     })
                                     .AddDataset(ds => {
                                         ds.Label = "Core 2";
                                         ds.Data = new List<double> { 38, 45, 52, 58, 49, 63, 55 };
                                         ds.BorderColor = "#3498db";
                                         ds.BackgroundColor = "rgba(52, 152, 219, 0.1)";
                                         ds.BorderWidth = 2;
                                         ds.PointRadius = 4;
                                         ds.Tension = 0.3;
                                         ds.Fill = false;
                                     })
                                     .AddDataset(ds => {
                                         ds.Label = "Core 3";
                                         ds.Data = new List<double> { 42, 49, 45, 65, 51, 69, 62 };
                                         ds.BorderColor = "#2ecc71";
                                         ds.BackgroundColor = "rgba(46, 204, 113, 0.1)";
                                         ds.BorderWidth = 2;
                                         ds.PointRadius = 4;
                                         ds.Tension = 0.3;
                                         ds.Fill = false;
                                     })
                                     .AddDataset(ds => {
                                         ds.Label = "Core 4";
                                         ds.Data = new List<double> { 39, 46, 43, 59, 47, 64, 56 };
                                         ds.BorderColor = "#f39c12";
                                         ds.BackgroundColor = "rgba(243, 156, 18, 0.1)";
                                         ds.BorderWidth = 2;
                                         ds.PointRadius = 4;
                                         ds.Tension = 0.3;
                                         ds.Fill = false;
                                     })
                                     .Configure(opt => {
                                         opt.Scales ??= new ChartJsScales();
                                         opt.Scales.Y ??= new ChartJsAxis();
                                         opt.Scales.Y.Min = 0;
                                         opt.Scales.Y.Max = 100;
                                         opt.Scales.Y.Title = new ChartJsAxisTitle { Display = true, Text = "Usage %" };
                                         opt.Plugins ??= new ChartJsPlugins();
                                         opt.Plugins.Legend ??= new ChartJsLegend();
                                         opt.Plugins.Legend.Position = ChartJsPosition.Top;
                                     });
                            });
                        });
                    });
                });
                row.Column(TablerColumnNumber.Four, col => {
                    col.Card(card => {
                        card.Header(header => header.Title("Memory Usage"));
                        card.Body(body => {
                            body.ChartJs(chart => {
                                chart.PolarArea()
                                     .Title("Memory Distribution")
                                     .AddLabels("Used", "Cache", "Buffer", "Free")
                                     .AddDataset(ds => {
                                         ds.Label = "Memory %";
                                         ds.Data = new List<double> { 65, 20, 10, 5 };
                                         ds.BackgroundColor = new List<string> { "#e74c3c", "#f39c12", "#3498db", "#27ae60" };
                                         ds.BorderColor = new List<string> { "#c0392b", "#e67e22", "#2980b9", "#27ae60" };
                                         ds.BorderWidth = 1;
                                     })
                                     .Configure(opt => {
                                         opt.Scales ??= new ChartJsScales();
                                         opt.Scales.R ??= new ChartJsAxis();
                                         opt.Scales.R.Min = 0;
                                         opt.Scales.R.Max = 100;
                                         opt.Plugins ??= new ChartJsPlugins();
                                         opt.Plugins.Legend ??= new ChartJsLegend();
                                         opt.Plugins.Legend.Position = ChartJsPosition.Bottom;
                                     });
                            });
                        });
                    });
                });
                row.Column(TablerColumnNumber.Four, col => {
                    col.Card(card => {
                        card.Header(header => header.Title("Network Traffic"));
                        card.Body(body => {
                            body.ChartJs(chart => {
                                chart.Bar()
                                     .Title("Bandwidth Usage")
                                     .AddLabels("Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun")
                                     .AddDataset(ds => {
                                         ds.Label = "Upload (GB)";
                                         ds.Data = new List<double> { 12, 15, 18, 14, 20, 8, 6 };
                                         ds.BackgroundColor = "#3498db";
                                         ds.BorderColor = "#2980b9";
                                         ds.BorderWidth = 1;
                                     })
                                     .AddDataset(ds => {
                                         ds.Label = "Download (GB)";
                                         ds.Data = new List<double> { 25, 30, 35, 28, 40, 18, 15 };
                                         ds.BackgroundColor = "#e74c3c";
                                         ds.BorderColor = "#c0392b";
                                         ds.BorderWidth = 1;
                                     })
                                     .BeginAtZero()
                                     .Stacked();
                            });
                        });
                    });
                });
            });
            
            // Advanced Data Visualization
            page.Divider("Advanced Data Visualization");
            page.Row(row => {
                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.Header(header => header.Title("Correlation Matrix"));
                        card.Body(body => {
                            body.ChartJs(chart => {
                                chart.Scatter()
                                     .Title("Sales vs Marketing Spend")
                                     .AddPoint(1000, 50000)
                                     .AddPoint(1500, 75000)
                                     .AddPoint(2000, 95000)
                                     .AddPoint(2500, 110000)
                                     .AddPoint(3000, 130000)
                                     .AddPoint(3500, 155000)
                                     .AddPoint(4000, 180000)
                                     .Configure(opt => {
                                         opt.Scales ??= new ChartJsScales();
                                         opt.Scales.X ??= new ChartJsAxis();
                                         opt.Scales.X.Title = new ChartJsAxisTitle { Display = true, Text = "Marketing Spend ($)" };
                                         opt.Scales.Y ??= new ChartJsAxis();
                                         opt.Scales.Y.Title = new ChartJsAxisTitle { Display = true, Text = "Sales Revenue ($)" };
                                     });
                            });
                        });
                    });
                });
                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.Header(header => header.Title("Risk vs Return Analysis"));
                        card.Body(body => {
                            body.ChartJs(chart => {
                                chart.Bubble()
                                     .Title("Investment Portfolio Analysis")
                                     .AddBubble(5, 12, 20)    // Risk 5%, Return 12%, Size 20
                                     .AddBubble(8, 15, 35)    // Risk 8%, Return 15%, Size 35
                                     .AddBubble(12, 18, 25)   // Risk 12%, Return 18%, Size 25
                                     .AddBubble(15, 22, 40)   // Risk 15%, Return 22%, Size 40
                                     .AddBubble(20, 25, 30)   // Risk 20%, Return 25%, Size 30
                                     .Configure(opt => {
                                         opt.Scales ??= new ChartJsScales();
                                         opt.Scales.X ??= new ChartJsAxis();
                                         opt.Scales.X.Title = new ChartJsAxisTitle { Display = true, Text = "Risk %" };
                                         opt.Scales.Y ??= new ChartJsAxis();
                                         opt.Scales.Y.Title = new ChartJsAxisTitle { Display = true, Text = "Expected Return %" };
                                         opt.Plugins ??= new ChartJsPlugins();
                                         opt.Plugins.Tooltip = new ChartJsTooltip {
                                             Mode = ChartJsInteractionMode.Point
                                         };
                                     });
                            });
                        });
                    });
                });
            });
            
            // Marketing & Sales Charts
            page.Divider("Marketing & Sales Analytics");
            page.Row(row => {
                row.Column(TablerColumnNumber.Four, col => {
                    col.Card(card => {
                        card.Header(header => header.Title("Sales Funnel"));
                        card.Body(body => {
                            body.ChartJs(chart => {
                                chart.Bar()
                                     .Title("Conversion Funnel")
                                     .AddLabels("Visitors", "Leads", "Prospects", "Customers")
                                     .AddDataset(ds => {
                                         ds.Label = "Count";
                                         ds.Data = new List<double> { 10000, 2500, 500, 100 };
                                         ds.BackgroundColor = new[] { "#3498db", "#f39c12", "#e67e22", "#27ae60" };
                                         ds.BorderColor = new[] { "#2980b9", "#d68910", "#d35400", "#229954" };
                                         ds.BorderWidth = 2;
                                     })
                                     .Configure(opt => {
                                         opt.Plugins ??= new ChartJsPlugins();
                                         opt.Plugins.Legend ??= new ChartJsLegend();
                                         opt.Plugins.Legend.Display = false;
                                         opt.Scales ??= new ChartJsScales();
                                         opt.Scales.Y ??= new ChartJsAxis();
                                         opt.Scales.Y.Type = "logarithmic";
                                     });
                            });
                        });
                    });
                });
                row.Column(TablerColumnNumber.Four, col => {
                    col.Card(card => {
                        card.Header(header => header.Title("Campaign Performance"));
                        card.Body(body => {
                            body.ChartJs(chart => {
                                chart.Radar()
                                     .Title("Multi-Channel Performance")
                                     .AddLabels("Email", "Social", "PPC", "SEO", "Display", "Referral")
                                     .AddDataset(ds => {
                                         ds.Label = "Q3 2024";
                                         ds.Data = new List<double> { 80, 65, 90, 70, 55, 75 };
                                         ds.BorderColor = "#e74c3c";
                                         ds.BackgroundColor = "rgba(231, 76, 60, 0.2)";
                                         ds.BorderWidth = 2;
                                         ds.PointBackgroundColor = "#e74c3c";
                                         ds.PointBorderColor = "#fff";
                                         ds.PointBorderWidth = 2;
                                     })
                                     .AddDataset(ds => {
                                         ds.Label = "Q4 2024";
                                         ds.Data = new List<double> { 85, 70, 85, 80, 65, 85 };
                                         ds.BorderColor = "#3498db";
                                         ds.BackgroundColor = "rgba(52, 152, 219, 0.2)";
                                         ds.BorderWidth = 2;
                                         ds.PointBackgroundColor = "#3498db";
                                         ds.PointBorderColor = "#fff";
                                         ds.PointBorderWidth = 2;
                                     })
                                     .Configure(opt => {
                                         opt.Scales ??= new ChartJsScales();
                                         opt.Scales.R ??= new ChartJsAxis();
                                         opt.Scales.R.Min = 0;
                                         opt.Scales.R.Max = 100;
                                     });
                            });
                        });
                    });
                });
                row.Column(TablerColumnNumber.Four, col => {
                    col.Card(card => {
                        card.Header(header => header.Title("Customer Lifetime Value"));
                        card.Body(body => {
                            body.ChartJs(chart => {
                                chart.Line()
                                     .Title("CLV by Cohort")
                                     .AddLabels("Month 1", "Month 3", "Month 6", "Month 12", "Month 24")
                                     .AddDataset(ds => {
                                         ds.Label = "2023 Cohort";
                                         ds.Data = new List<double> { 50, 120, 200, 350, 500 };
                                         ds.BorderColor = "#9b59b6";
                                         ds.BackgroundColor = "rgba(155, 89, 182, 0.1)";
                                         ds.BorderWidth = 3;
                                         ds.PointRadius = 6;
                                         ds.Tension = 0.4;
                                     })
                                     .AddDataset(ds => {
                                         ds.Label = "2024 Cohort";
                                         ds.Data = new List<double> { 60, 140, 230, 400, 580 };
                                         ds.BorderColor = "#1abc9c";
                                         ds.BackgroundColor = "rgba(26, 188, 156, 0.1)";
                                         ds.BorderWidth = 3;
                                         ds.PointRadius = 6;
                                         ds.Tension = 0.4;
                                     })
                                     .BeginAtZero()
                                     .Configure(opt => {
                                         opt.Scales ??= new ChartJsScales();
                                         opt.Scales.Y ??= new ChartJsAxis();
                                         opt.Scales.Y.Title = new ChartJsAxisTitle { Display = true, Text = "CLV ($)" };
                                     });
                            });
                        });
                    });
                });
            });
            
            // Product & User Analytics
            page.Divider("Product & User Analytics");
            page.Row(row => {
                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.Header(header => header.Title("Feature Usage Heatmap"));
                        card.Body(body => {
                            body.ChartJs(chart => {
                                chart.Bar()
                                     .Title("Feature Adoption Rate")
                                     .AddLabels("Dashboard", "Reports", "Analytics", "Settings", "API", "Mobile")
                                     .AddDataset(ds => {
                                         ds.Label = "Daily Active Users";
                                         ds.Data = new List<double> { 85, 70, 60, 40, 25, 55 };
                                         ds.BackgroundColor = new[] { "#27ae60", "#f39c12", "#e67e22", "#e74c3c", "#c0392b", "#f39c12" };
                                         ds.BorderColor = new[] { "#229954", "#d68910", "#d35400", "#c0392b", "#a93226", "#d68910" };
                                         ds.BorderWidth = 2;
                                     })
                                     .Configure(opt => {
                                         opt.Plugins ??= new ChartJsPlugins();
                                         opt.Plugins.Legend ??= new ChartJsLegend();
                                         opt.Plugins.Legend.Display = false;
                                         opt.Scales ??= new ChartJsScales();
                                         opt.Scales.Y ??= new ChartJsAxis();
                                         opt.Scales.Y.Title = new ChartJsAxisTitle { Display = true, Text = "Usage %" };
                                     });
                            });
                        });
                    });
                });
                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.Header(header => header.Title("User Engagement Flow"));
                        card.Body(body => {
                            body.ChartJs(chart => {
                                chart.Line()
                                     .Title("User Journey Analytics")
                                     .AddLabels("Login", "Browse", "Search", "View", "Add to Cart", "Checkout", "Purchase")
                                     .AddDataset(ds => {
                                         ds.Label = "Drop-off Rate";
                                         ds.Data = new List<double> { 100, 85, 70, 60, 45, 30, 25 };
                                         ds.BorderColor = "#e74c3c";
                                         ds.BackgroundColor = "rgba(231, 76, 60, 0.2)";
                                         ds.BorderWidth = 3;
                                         ds.PointRadius = 7;
                                         ds.PointBackgroundColor = "#c0392b";
                                         ds.PointBorderColor = "#fff";
                                         ds.PointBorderWidth = 2;
                                         ds.Tension = 0.3;
                                         ds.Fill = true;
                                     })
                                     .Configure(opt => {
                                         opt.Scales ??= new ChartJsScales();
                                         opt.Scales.Y ??= new ChartJsAxis();
                                         opt.Scales.Y.Title = new ChartJsAxisTitle { Display = true, Text = "Retention %" };
                                     });
                            });
                        });
                    });
                });
            });
            
            // Geographic & Demographic Charts
            page.Divider("Geographic & Demographic Analytics");
            page.Row(row => {
                row.Column(TablerColumnNumber.Four, col => {
                    col.Card(card => {
                        card.Header(header => header.Title("Regional Sales"));
                        card.Body(body => {
                            body.ChartJs(chart => {
                                chart.Pie()
                                     .Title("Sales by Region")
                                     .AddLabels("North America", "Europe", "Asia Pacific", "Latin America")
                                     .AddDataset(ds => {
                                         ds.Label = "Sales %";
                                         ds.Data = new List<double> { 45, 30, 20, 5 };
                                         ds.BackgroundColor = new List<string> { "#3498db", "#e74c3c", "#f39c12", "#27ae60" };
                                         ds.BorderColor = new List<string> { "#2980b9", "#c0392b", "#e67e22", "#229954" };
                                         ds.BorderWidth = 2;
                                     })
                                     .Configure(opt => {
                                         opt.Plugins ??= new ChartJsPlugins();
                                         opt.Plugins.Legend ??= new ChartJsLegend();
                                         opt.Plugins.Legend.Position = ChartJsPosition.Bottom;
                                         opt.Plugins.Legend.Labels = new ChartJsLegendLabels {
                                             UsePointStyle = true,
                                             Font = new ChartJsFont { Size = 12 }
                                         };
                                     });
                            });
                        });
                    });
                });
                row.Column(TablerColumnNumber.Four, col => {
                    col.Card(card => {
                        card.Header(header => header.Title("Age Demographics"));
                        card.Body(body => {
                            body.ChartJs(chart => {
                                chart.Bar()
                                     .Title("User Age Distribution")
                                     .AddLabels("18-24", "25-34", "35-44", "45-54", "55-64", "65+")
                                     .AddDataset(ds => {
                                         ds.Label = "Male";
                                         ds.Data = new List<double> { 15, 25, 30, 20, 8, 2 };
                                         ds.BackgroundColor = "#3498db";
                                         ds.BorderColor = "#2980b9";
                                         ds.BorderWidth = 1;
                                     })
                                     .AddDataset(ds => {
                                         ds.Label = "Female";
                                         ds.Data = new List<double> { 12, 28, 32, 18, 7, 3 };
                                         ds.BackgroundColor = "#e74c3c";
                                         ds.BorderColor = "#c0392b";
                                         ds.BorderWidth = 1;
                                     })
                                     .BeginAtZero()
                                     .Configure(opt => {
                                         opt.Scales ??= new ChartJsScales();
                                         opt.Scales.Y ??= new ChartJsAxis();
                                         opt.Scales.Y.Title = new ChartJsAxisTitle { Display = true, Text = "Percentage %" };
                                     });
                            });
                        });
                    });
                });
                row.Column(TablerColumnNumber.Four, col => {
                    col.Card(card => {
                        card.Header(header => header.Title("Device Usage"));
                        card.Body(body => {
                            body.ChartJs(chart => {
                                chart.Doughnut()
                                     .Title("Traffic by Device")
                                     .AddLabels("Desktop", "Mobile", "Tablet")
                                     .AddDataset(ds => {
                                         ds.Label = "Usage %";
                                         ds.Data = new List<double> { 55, 35, 10 };
                                         ds.BackgroundColor = new List<string> { "#34495e", "#e67e22", "#9b59b6" };
                                         ds.BorderColor = new List<string> { "#2c3e50", "#d35400", "#8e44ad" };
                                         ds.BorderWidth = 2;
                                     })
                                     .Configure(opt => {
                                         opt.Plugins ??= new ChartJsPlugins();
                                         opt.Plugins.Legend ??= new ChartJsLegend();
                                         opt.Plugins.Legend.Position = ChartJsPosition.Right;
                                         opt.Plugins.Legend.Labels = new ChartJsLegendLabels {
                                             UsePointStyle = true,
                                             Font = new ChartJsFont { Size = 14, Weight = "bold" }
                                         };
                                     });
                            });
                        });
                    });
                });
            });
            
            // Real-time & Dynamic Charts
            page.Divider("Real-time & Dynamic Visualizations");
            page.Row(row => {
                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.Header(header => header.Title("Live Trading Data"));
                        card.Body(body => {
                            body.ChartJs(chart => {
                                chart.Line()
                                     .Title("Crypto Price Feed")
                                     .AddLabels("12:00", "12:15", "12:30", "12:45", "13:00", "13:15", "13:30")
                                     .AddDataset(ds => {
                                         ds.Label = "BTC/USD";
                                         ds.Data = new List<double> { 45000, 45200, 44800, 45100, 45500, 45300, 45800 };
                                         ds.BorderColor = "#f39c12";
                                         ds.BackgroundColor = "rgba(243, 156, 18, 0.1)";
                                         ds.BorderWidth = 2;
                                         ds.PointRadius = 0;
                                         ds.Tension = 0.1;
                                         ds.Fill = true;
                                     })
                                     .AddDataset(ds => {
                                         ds.Label = "ETH/USD";
                                         ds.Data = new List<double> { 3200, 3250, 3180, 3220, 3280, 3240, 3300 };
                                         ds.BorderColor = "#9b59b6";
                                         ds.BackgroundColor = "rgba(155, 89, 182, 0.1)";
                                         ds.BorderWidth = 2;
                                         ds.PointRadius = 0;
                                         ds.Tension = 0.1;
                                         ds.Fill = true;
                                     })
                                     .Configure(opt => {
                                         opt.Scales ??= new ChartJsScales();
                                         opt.Scales.Y ??= new ChartJsAxis();
                                         opt.Scales.Y.BeginAtZero = false;
                                         opt.Plugins ??= new ChartJsPlugins();
                                         opt.Plugins.Legend ??= new ChartJsLegend();
                                         opt.Plugins.Legend.Position = ChartJsPosition.Top;
                                     });
                            });
                        });
                    });
                });
                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.Header(header => header.Title("Server Response Times"));
                        card.Body(body => {
                            body.ChartJs(chart => {
                                chart.Bar()
                                     .Title("API Endpoint Performance")
                                     .AddLabels("/api/users", "/api/orders", "/api/products", "/api/analytics", "/api/reports")
                                     .AddDataset(ds => {
                                         ds.Label = "Avg Response (ms)";
                                         ds.Data = new List<double> { 120, 250, 180, 300, 450 };
                                         ds.BackgroundColor = new[] { "#27ae60", "#f39c12", "#27ae60", "#e67e22", "#e74c3c" };
                                         ds.BorderColor = new[] { "#229954", "#d68910", "#229954", "#d35400", "#c0392b" };
                                         ds.BorderWidth = 2;
                                     })
                                     .BeginAtZero()
                                     .Configure(opt => {
                                         opt.Plugins ??= new ChartJsPlugins();
                                         opt.Plugins.Legend ??= new ChartJsLegend();
                                         opt.Plugins.Legend.Display = false;
                                         opt.Scales ??= new ChartJsScales();
                                         opt.Scales.Y ??= new ChartJsAxis();
                                         opt.Scales.Y.Title = new ChartJsAxisTitle { Display = true, Text = "Response Time (ms)" };
                                     });
                            });
                        });
                    });
                });
            });
            
            // Specialized Industry Charts
            page.Divider("Specialized Industry Analytics");
            page.Row(row => {
                row.Column(TablerColumnNumber.Four, col => {
                    col.Card(card => {
                        card.Header(header => header.Title("Healthcare Metrics"));
                        card.Body(body => {
                            body.ChartJs(chart => {
                                chart.Radar()
                                     .Title("Patient Satisfaction Scores")
                                     .AddLabels("Care Quality", "Communication", "Facilities", "Wait Time", "Staff", "Overall")
                                     .AddDataset(ds => {
                                         ds.Label = "Hospital A";
                                         ds.Data = new List<double> { 85, 78, 92, 65, 88, 82 };
                                         ds.BorderColor = "#e74c3c";
                                         ds.BackgroundColor = "rgba(231, 76, 60, 0.2)";
                                         ds.BorderWidth = 2;
                                         ds.PointBackgroundColor = "#e74c3c";
                                     })
                                     .AddDataset(ds => {
                                         ds.Label = "Hospital B";
                                         ds.Data = new List<double> { 90, 85, 88, 75, 92, 86 };
                                         ds.BorderColor = "#27ae60";
                                         ds.BackgroundColor = "rgba(39, 174, 96, 0.2)";
                                         ds.BorderWidth = 2;
                                         ds.PointBackgroundColor = "#27ae60";
                                     })
                                     .Configure(opt => {
                                         opt.Scales ??= new ChartJsScales();
                                         opt.Scales.R ??= new ChartJsAxis();
                                         opt.Scales.R.Min = 0;
                                         opt.Scales.R.Max = 100;
                                     });
                            });
                        });
                    });
                });
                row.Column(TablerColumnNumber.Four, col => {
                    col.Card(card => {
                        card.Header(header => header.Title("E-commerce Conversion"));
                        card.Body(body => {
                            body.ChartJs(chart => {
                                chart.Line()
                                     .Title("Monthly Conversion Rates")
                                     .AddLabels("Jan", "Feb", "Mar", "Apr", "May", "Jun")
                                     .AddDataset(ds => {
                                         ds.Label = "Desktop";
                                         ds.Data = new List<double> { 3.2, 3.5, 3.8, 3.6, 4.1, 4.3 };
                                         ds.BorderColor = "#3498db";
                                         ds.BackgroundColor = "rgba(52, 152, 219, 0.1)";
                                         ds.BorderWidth = 3;
                                         ds.PointRadius = 6;
                                         ds.PointBackgroundColor = "#3498db";
                                         ds.PointBorderColor = "#fff";
                                         ds.PointBorderWidth = 2;
                                         ds.Tension = 0.4;
                                     })
                                     .AddDataset(ds => {
                                         ds.Label = "Mobile";
                                         ds.Data = new List<double> { 2.1, 2.3, 2.5, 2.4, 2.8, 3.0 };
                                         ds.BorderColor = "#e74c3c";
                                         ds.BackgroundColor = "rgba(231, 76, 60, 0.1)";
                                         ds.BorderWidth = 3;
                                         ds.PointRadius = 6;
                                         ds.PointBackgroundColor = "#e74c3c";
                                         ds.PointBorderColor = "#fff";
                                         ds.PointBorderWidth = 2;
                                         ds.Tension = 0.4;
                                     })
                                     .BeginAtZero()
                                     .Configure(opt => {
                                         opt.Scales ??= new ChartJsScales();
                                         opt.Scales.Y ??= new ChartJsAxis();
                                         opt.Scales.Y.Title = new ChartJsAxisTitle { Display = true, Text = "Conversion Rate %" };
                                     });
                            });
                        });
                    });
                });
                row.Column(TablerColumnNumber.Four, col => {
                    col.Card(card => {
                        card.Header(header => header.Title("Manufacturing KPIs"));
                        card.Body(body => {
                            body.ChartJs(chart => {
                                chart.Bar()
                                     .Title("Production Efficiency")
                                     .AddLabels("Line 1", "Line 2", "Line 3", "Line 4", "Line 5")
                                     .AddDataset(ds => {
                                         ds.Label = "Efficiency %";
                                         ds.Data = new List<double> { 87, 92, 78, 95, 89 };
                                         ds.BackgroundColor = new[] { "#f39c12", "#27ae60", "#e74c3c", "#27ae60", "#f39c12" };
                                         ds.BorderColor = new[] { "#d68910", "#229954", "#c0392b", "#229954", "#d68910" };
                                         ds.BorderWidth = 2;
                                     })
                                     .Configure(opt => {
                                         opt.Plugins ??= new ChartJsPlugins();
                                         opt.Plugins.Legend ??= new ChartJsLegend();
                                         opt.Plugins.Legend.Display = false;
                                         opt.Scales ??= new ChartJsScales();
                                         opt.Scales.Y ??= new ChartJsAxis();
                                         opt.Scales.Y.Min = 70;
                                         opt.Scales.Y.Max = 100;
                                         opt.Scales.Y.Title = new ChartJsAxisTitle { Display = true, Text = "Efficiency %" };
                                     });
                            });
                        });
                    });
                });
            });
            
            // Summary Statistics
            page.Divider("Summary & Insights");
            page.Row(row => {
                row.Column(TablerColumnNumber.Twelve, col => {
                    col.Card(card => {
                        card.Header(header => header.Title("Executive Dashboard Summary"));
                        card.Body(body => {
                            body.ChartJs(chart => {
                                chart.Line()
                                     .Title("Key Performance Indicators Trend")
                                     .AddLabels("Q1 2023", "Q2 2023", "Q3 2023", "Q4 2023", "Q1 2024", "Q2 2024", "Q3 2024", "Q4 2024")
                                     .AddDataset(ds => {
                                         ds.Label = "Revenue Growth %";
                                         ds.Data = new List<double> { 15, 18, 22, 25, 28, 32, 35, 38 };
                                         ds.BorderColor = "#27ae60";
                                         ds.BackgroundColor = "rgba(39, 174, 96, 0.1)";
                                         ds.BorderWidth = 3;
                                         ds.PointRadius = 6;
                                         ds.PointBackgroundColor = "#27ae60";
                                         ds.PointBorderColor = "#fff";
                                         ds.PointBorderWidth = 2;
                                         ds.Tension = 0.4;
                                     })
                                     .AddDataset(ds => {
                                         ds.Label = "Customer Satisfaction";
                                         ds.Data = new List<double> { 78, 82, 85, 87, 89, 91, 93, 95 };
                                         ds.BorderColor = "#3498db";
                                         ds.BackgroundColor = "rgba(52, 152, 219, 0.1)";
                                         ds.BorderWidth = 3;
                                         ds.PointRadius = 6;
                                         ds.PointBackgroundColor = "#3498db";
                                         ds.PointBorderColor = "#fff";
                                         ds.PointBorderWidth = 2;
                                         ds.Tension = 0.4;
                                     })
                                     .AddDataset(ds => {
                                         ds.Label = "Market Share %";
                                         ds.Data = new List<double> { 12, 13, 15, 16, 18, 20, 22, 24 };
                                         ds.BorderColor = "#e74c3c";
                                         ds.BackgroundColor = "rgba(231, 76, 60, 0.1)";
                                         ds.BorderWidth = 3;
                                         ds.PointRadius = 6;
                                         ds.PointBackgroundColor = "#e74c3c";
                                         ds.PointBorderColor = "#fff";
                                         ds.PointBorderWidth = 2;
                                         ds.Tension = 0.4;
                                     })
                                     .BeginAtZero()
                                     .Configure(opt => {
                                         opt.Scales ??= new ChartJsScales();
                                         opt.Scales.Y ??= new ChartJsAxis();
                                         opt.Scales.Y.Title = new ChartJsAxisTitle { Display = true, Text = "Performance Metrics" };
                                         opt.Plugins ??= new ChartJsPlugins();
                                         opt.Plugins.Legend ??= new ChartJsLegend();
                                         opt.Plugins.Legend.Position = ChartJsPosition.Top;
                                         opt.Plugins.Legend.Labels = new ChartJsLegendLabels {
                                             UsePointStyle = true,
                                             Font = new ChartJsFont { Size = 12, Weight = "bold" }
                                         };
                                     });
                            });
                        });
                    });
                });
            });
        });

        document.Save("ChartJsDemoEnhanced.html", openInBrowser);
        
        Console.WriteLine("📊 ChartJs Enhanced Demo created successfully!");
        Console.WriteLine("✨ Features demonstrated:");
        Console.WriteLine("   • All chart types: Line, Bar, Pie, Doughnut, Radar, Polar Area, Scatter, Bubble");
        Console.WriteLine("   • Multiple datasets with custom colors and styling");
        Console.WriteLine("   • Advanced configuration: titles, legends, tooltips, animations");
        Console.WriteLine("   • Stacked charts and custom scales");
        Console.WriteLine("   • Fluent API with full type safety");
        Console.WriteLine("   • Zero HTML/CSS/JS required from the user");
    }
}