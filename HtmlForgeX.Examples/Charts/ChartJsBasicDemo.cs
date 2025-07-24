using System.Collections.Generic;
using HtmlForgeX;

namespace HtmlForgeX.Examples.Charts;

internal class ChartJsBasicDemo {
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
            page.H1("📊 ChartJs Enhanced Demo");
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
                                 .Legend(true, ChartJsPosition.Right);
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
                                 .RAxis(axis => {
                                     axis.SuggestedMin = 0;
                                     axis.SuggestedMax = 100;
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
                                 .XAxis(axis => {
                                     axis.Title = new ChartJsAxisTitle { Display = true, Text = "X Values" };
                                 })
                                 .YAxis(axis => {
                                     axis.Title = new ChartJsAxisTitle { Display = true, Text = "Y Values" };
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
                                 .XAxisTitle("Price ($)")
                                 .YAxisTitle("Sales")
                                 .Tooltip(ChartJsInteractionMode.Point);
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
                                     .AddDataset(ds => ds
                                         .SetLabel("Sales")
                                         .SetData(12, 19, 3, 17, 6)
                                         .SetBackgroundColor(new RGBColor("rgba(255, 99, 132, 0.4)"))
                                         .SetBorderColor(RGBColor.IndianRed)
                                         .SetBorderWidth(3)
                                         .SetPointBackgroundColor(RGBColor.White)
                                         .SetPointBorderColor(RGBColor.IndianRed)
                                         .SetPointBorderWidth(2)
                                         .SetPointRadius(6)
                                         .SetPointHoverRadius(8)
                                         .SetPointHoverBackgroundColor(RGBColor.IndianRed)
                                         .SetPointHoverBorderColor(RGBColor.White)
                                         .SetPointHoverBorderWidth(2)
                                         .SetTension(0.4)
                                     )
                                     .TitleStyled("Sales Performance", 20, ChartJsFontWeight.Bold, RGBColor.MidnightBlue)
                                     .LegendLabels(14, ChartJsFontWeight.Bold, RGBColor.DarkSlateGray, 20)
                                     .XAxisGrid(new RGBColor("rgba(52, 73, 94, 0.1)"), 1)
                                     .XAxisTicks(RGBColor.SlateGray, 12)
                                     .YAxisGrid(new RGBColor("rgba(52, 73, 94, 0.1)"), 1)
                                     .YAxisTicks(RGBColor.SlateGray, 12)
                                     .BeginAtZero();
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
                                     .AddDataset("Sales", new RGBColor("#3498db"), 45, 37, 60, 70)
                                     .AddLabels("Product A", "Product B", "Product C", "Product D")
                                     .Tooltip(ChartJsInteractionMode.Index, false, 
                                              new RGBColor("rgba(0, 0, 0, 0.8)"), 
                                              new RGBColor("#fff"), 
                                              new RGBColor("#fff"), 
                                              new RGBColor("#ddd"), 1)
                                     .Interaction(ChartJsInteractionMode.Nearest, false);
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
                                     .AddDataset(ds => ds
                                         .SetLabel("High")
                                         .SetData(150, 152, 149, 153, 155, 154, 156, 158)
                                         .SetBorderColor(RGBColor.ForestGreen)
                                         .SetBackgroundColor(new RGBColor("rgba(39, 174, 96, 0.1)"))
                                         .SetBorderWidth(2)
                                         .SetFill(false)
                                     )
                                     .AddDataset(ds => ds
                                         .SetLabel("Low")
                                         .SetData(148, 149, 146, 150, 152, 151, 153, 155)
                                         .SetBorderColor(RGBColor.Crimson)
                                         .SetBackgroundColor(new RGBColor("rgba(231, 76, 60, 0.1)"))
                                         .SetBorderWidth(2)
                                         .SetFill(false)
                                     )
                                     .YAxis(axis => axis
                                         .SetBeginAtZero(false)
                                         .SetRange(140, 160)
                                     )
                                     .Legend(false, ChartJsPosition.Bottom);
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
                                     .AddDataset(ds => ds
                                         .SetLabel("Revenue")
                                         .SetData(45, 25, 20, 10)
                                         .SetBackgroundColors(RGBColor.DodgerBlue, RGBColor.Crimson, RGBColor.Orange, RGBColor.ForestGreen)
                                         .SetBorderColors(RGBColor.DodgerBlue, RGBColor.Crimson, RGBColor.Orange, RGBColor.ForestGreen)
                                         .SetBorderWidth(2)
                                     )
                                     .Legend(legend => {
                                         legend.Position = ChartJsPosition.Right;
                                         legend.Labels = new ChartJsLegendLabels {
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
                                     .AddDataset(ds => ds
                                         .SetLabel("Target")
                                         .SetData(100, 100, 100, 100)
                                         .SetBackgroundColor(new RGBColor("rgba(149, 165, 166, 0.3)"))
                                         .SetBorderColor(RGBColor.Gray)
                                         .SetBorderWidth(1)
                                     )
                                     .AddDataset(ds => ds
                                         .SetLabel("Actual")
                                         .SetData(95, 112, 87, 103)
                                         .SetBackgroundColors(RGBColor.Crimson, RGBColor.ForestGreen, RGBColor.Orange, RGBColor.ForestGreen)
                                         .SetBorderColors(RGBColor.Firebrick, RGBColor.DarkGreen, RGBColor.DarkOrange, RGBColor.DarkGreen)
                                         .SetBorderWidth(2)
                                     )
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
                                     .AddDataset(ds => ds
                                         .SetLabel("Distribution")
                                         .SetData(0.4, 5.4, 24.2, 39.9, 24.2, 5.4, 0.4)
                                         .SetBorderColor(RGBColor.MediumPurple)
                                         .SetBackgroundColor(new RGBColor("rgba(155, 89, 182, 0.2)"))
                                         .SetBorderWidth(3)
                                         .SetPointRadius(6)
                                         .SetPointBackgroundColor(RGBColor.Purple)
                                         .SetPointBorderColor(RGBColor.White)
                                         .SetPointBorderWidth(2)
                                         .SetTension(0.4)
                                         .SetFill(true)
                                     )
                                     .YAxis(axis => axis.SetTitle("Probability %", true))
                                     .XAxis(axis => axis.SetTitle("Standard Deviations", true));
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
                                     .AddDataset(ds => ds
                                         .SetLabel("Variant A")
                                         .SetData(12.3, 13.1, 12.8, 13.5)
                                         .SetBackgroundColor(RGBColor.DodgerBlue)
                                         .SetBorderColor(RGBColor.SteelBlue)
                                         .SetBorderWidth(2)
                                     )
                                     .AddDataset(ds => ds
                                         .SetLabel("Variant B")
                                         .SetData(14.2, 15.1, 14.9, 15.8)
                                         .SetBackgroundColor(RGBColor.Crimson)
                                         .SetBorderColor(RGBColor.Firebrick)
                                         .SetBorderWidth(2)
                                     )
                                     .BeginAtZero()
                                     .YAxis(axis => axis.SetTitle("Conversion Rate %", true))
                                     .Legend(false, ChartJsPosition.Top);
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
                                     .AddDataset(ds => ds
                                         .SetLabel("Core 1")
                                         .SetData(45, 52, 48, 61, 55, 67, 59)
                                         .SetBorderColor(RGBColor.Crimson)
                                         .SetBackgroundColor(new RGBColor("rgba(231, 76, 60, 0.1)"))
                                         .SetBorderWidth(2)
                                         .SetPointRadius(4)
                                         .SetTension(0.3)
                                         .SetFill(false)
                                     )
                                     .AddDataset(ds => ds
                                         .SetLabel("Core 2")
                                         .SetData(38, 45, 52, 58, 49, 63, 55)
                                         .SetBorderColor(RGBColor.DodgerBlue)
                                         .SetBackgroundColor(new RGBColor("rgba(52, 152, 219, 0.1)"))
                                         .SetBorderWidth(2)
                                         .SetPointRadius(4)
                                         .SetTension(0.3)
                                         .SetFill(false)
                                     )
                                     .AddDataset(ds => ds
                                         .SetLabel("Core 3")
                                         .SetData(42, 49, 45, 65, 51, 69, 62)
                                         .SetBorderColor(RGBColor.ForestGreen)
                                         .SetBackgroundColor(new RGBColor("rgba(46, 204, 113, 0.1)"))
                                         .SetBorderWidth(2)
                                         .SetPointRadius(4)
                                         .SetTension(0.3)
                                         .SetFill(false)
                                     )
                                     .AddDataset(ds => ds
                                         .SetLabel("Core 4")
                                         .SetData(39, 46, 43, 59, 47, 64, 56)
                                         .SetBorderColor(RGBColor.Orange)
                                         .SetBackgroundColor(new RGBColor("rgba(243, 156, 18, 0.1)"))
                                         .SetBorderWidth(2)
                                         .SetPointRadius(4)
                                         .SetTension(0.3)
                                         .SetFill(false)
                                     )
                                     .YAxis(axis => axis
                                         .SetRange(0, 100)
                                         .SetTitle("Usage %", true)
                                     )
                                     .Legend(false, ChartJsPosition.Top);
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
                                     .AddDataset(ds => ds
                                         .SetLabel("Memory %")
                                         .SetData(65, 20, 10, 5)
                                         .SetBackgroundColors(RGBColor.Crimson, RGBColor.Orange, RGBColor.DodgerBlue, RGBColor.ForestGreen)
                                         .SetBorderColors(RGBColor.Firebrick, RGBColor.DarkOrange, RGBColor.SteelBlue, RGBColor.DarkGreen)
                                         .SetBorderWidth(1)
                                     )
                                     .RAxis(axis => axis
                                         .SetRange(0, 100)
                                     )
                                     .Legend(false, ChartJsPosition.Bottom);
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
                                     .AddDataset(ds => ds
                                         .SetLabel("Upload (GB)")
                                         .SetData(12, 15, 18, 14, 20, 8, 6)
                                         .SetBackgroundColor(RGBColor.DodgerBlue)
                                         .SetBorderColor(RGBColor.SteelBlue)
                                         .SetBorderWidth(1)
                                     )
                                     .AddDataset(ds => ds
                                         .SetLabel("Download (GB)")
                                         .SetData(25, 30, 35, 28, 40, 18, 15)
                                         .SetBackgroundColor(RGBColor.Crimson)
                                         .SetBorderColor(RGBColor.Firebrick)
                                         .SetBorderWidth(1)
                                     )
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
                                     .XAxis(axis => axis.SetTitle("Marketing Spend ($)", true))
                                     .YAxis(axis => axis.SetTitle("Sales Revenue ($)", true));
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
                                     .XAxisTitle("Risk %")
                                     .YAxisTitle("Expected Return %")
                                     .Tooltip(ChartJsInteractionMode.Point);
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
                                     .AddDataset(ds => ds
                                         .SetLabel("Count")
                                         .SetData(10000, 2500, 500, 100)
                                         .SetBackgroundColors(RGBColor.DodgerBlue, RGBColor.Orange, RGBColor.DarkOrange, RGBColor.ForestGreen)
                                         .SetBorderColors(RGBColor.SteelBlue, RGBColor.DarkOrange, RGBColor.OrangeRed, RGBColor.DarkGreen)
                                         .SetBorderWidth(2)
                                     )
                                     .Legend(false)
                                     .YAxis(axis => axis.SetType("logarithmic"));
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
                                     .AddDataset(ds => ds
                                         .SetLabel("Q3 2024")
                                         .SetData(80, 65, 90, 70, 55, 75)
                                         .SetBorderColor(RGBColor.Crimson)
                                         .SetBackgroundColor(new RGBColor("rgba(231, 76, 60, 0.2)"))
                                         .SetBorderWidth(2)
                                         .SetPointBackgroundColor(RGBColor.Crimson)
                                         .SetPointBorderColor(RGBColor.White)
                                         .SetPointBorderWidth(2)
                                     )
                                     .AddDataset(ds => ds
                                         .SetLabel("Q4 2024")
                                         .SetData(85, 70, 85, 80, 65, 85)
                                         .SetBorderColor(RGBColor.DodgerBlue)
                                         .SetBackgroundColor(new RGBColor("rgba(52, 152, 219, 0.2)"))
                                         .SetBorderWidth(2)
                                         .SetPointBackgroundColor(RGBColor.DodgerBlue)
                                         .SetPointBorderColor(RGBColor.White)
                                         .SetPointBorderWidth(2)
                                     )
                                     .RAxisRange(0, 100);
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
                                     .AddDataset(ds => ds
                                         .SetLabel("2023 Cohort")
                                         .SetData(50, 120, 200, 350, 500)
                                         .SetBorderColor(RGBColor.MediumPurple)
                                         .SetBackgroundColor(new RGBColor("rgba(155, 89, 182, 0.1)"))
                                         .SetBorderWidth(3)
                                         .SetPointRadius(6)
                                         .SetTension(0.4)
                                     )
                                     .AddDataset(ds => ds
                                         .SetLabel("2024 Cohort")
                                         .SetData(60, 140, 230, 400, 580)
                                         .SetBorderColor(RGBColor.Turquoise)
                                         .SetBackgroundColor(new RGBColor("rgba(26, 188, 156, 0.1)"))
                                         .SetBorderWidth(3)
                                         .SetPointRadius(6)
                                         .SetTension(0.4)
                                     )
                                     .BeginAtZero()
                                     .YAxis(axis => axis.SetTitle("CLV ($)", true));
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
                                     .AddDataset(ds => ds
                                         .SetLabel("Daily Active Users")
                                         .SetData(85, 70, 60, 40, 25, 55)
                                         .SetBackgroundColors(RGBColor.ForestGreen, RGBColor.Orange, RGBColor.DarkOrange, RGBColor.Crimson, RGBColor.Firebrick, RGBColor.Orange)
                                         .SetBorderColors(RGBColor.DarkGreen, RGBColor.DarkOrange, RGBColor.OrangeRed, RGBColor.Firebrick, RGBColor.DarkRed, RGBColor.DarkOrange)
                                         .SetBorderWidth(2)
                                     )
                                     .Legend(false)
                                     .YAxisTitle("Usage %");
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
                                     .AddDataset(ds => ds
                                         .SetLabel("Drop-off Rate")
                                         .SetData(100, 85, 70, 60, 45, 30, 25)
                                         .SetBorderColor(RGBColor.Crimson)
                                         .SetBackgroundColor(new RGBColor("rgba(231, 76, 60, 0.2)"))
                                         .SetBorderWidth(3)
                                         .SetPointRadius(7)
                                         .SetPointBackgroundColor(RGBColor.Firebrick)
                                         .SetPointBorderColor(RGBColor.White)
                                         .SetPointBorderWidth(2)
                                         .SetTension(0.3)
                                         .SetFill(true)
                                     )
                                     .YAxisTitle("Retention %");
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
                                     .AddDataset(ds => ds
                                         .SetLabel("Sales %")
                                         .SetData(45, 30, 20, 5)
                                         .SetBackgroundColors(RGBColor.DodgerBlue, RGBColor.Crimson, RGBColor.Orange, RGBColor.ForestGreen)
                                         .SetBorderColors(RGBColor.SteelBlue, RGBColor.Firebrick, RGBColor.DarkOrange, RGBColor.DarkGreen)
                                         .SetBorderWidth(2)
                                     )
                                     .Legend(legend => {
                                         legend.Position = ChartJsPosition.Bottom;
                                         legend.Labels = new ChartJsLegendLabels {
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
                                     .AddDataset(ds => ds
                                         .SetLabel("Male")
                                         .SetData(15, 25, 30, 20, 8, 2)
                                         .SetBackgroundColor(RGBColor.DodgerBlue)
                                         .SetBorderColor(RGBColor.SteelBlue)
                                         .SetBorderWidth(1)
                                     )
                                     .AddDataset(ds => ds
                                         .SetLabel("Female")
                                         .SetData(12, 28, 32, 18, 7, 3)
                                         .SetBackgroundColor(RGBColor.Crimson)
                                         .SetBorderColor(RGBColor.Firebrick)
                                         .SetBorderWidth(1)
                                     )
                                     .BeginAtZero()
                                     .YAxisTitle("Percentage %");
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
                                     .AddDataset(ds => ds
                                         .SetLabel("Usage %")
                                         .SetData(55, 35, 10)
                                         .SetBackgroundColors(RGBColor.DimGray, RGBColor.DarkOrange, RGBColor.MediumPurple)
                                         .SetBorderColors(RGBColor.DarkSlateGray, RGBColor.OrangeRed, RGBColor.Purple)
                                         .SetBorderWidth(2)
                                     )
                                     .Legend(legend => {
                                         legend.Position = ChartJsPosition.Right;
                                         legend.Labels = new ChartJsLegendLabels {
                                             UsePointStyle = true,
                                             Font = new ChartJsFont { Size = 14, Weight = ChartJsFontWeight.Bold }
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
                                     .AddDataset(ds => ds
                                         .SetLabel("BTC/USD")
                                         .SetData(45000, 45200, 44800, 45100, 45500, 45300, 45800)
                                         .SetBorderColor(RGBColor.Orange)
                                         .SetBackgroundColor(new RGBColor("rgba(243, 156, 18, 0.1)"))
                                         .SetBorderWidth(2)
                                         .SetPointRadius(0)
                                         .SetTension(0.1)
                                         .SetFill(true)
                                     )
                                     .AddDataset(ds => ds
                                         .SetLabel("ETH/USD")
                                         .SetData(3200, 3250, 3180, 3220, 3280, 3240, 3300)
                                         .SetBorderColor(RGBColor.MediumPurple)
                                         .SetBackgroundColor(new RGBColor("rgba(155, 89, 182, 0.1)"))
                                         .SetBorderWidth(2)
                                         .SetPointRadius(0)
                                         .SetTension(0.1)
                                         .SetFill(true)
                                     )
                                     .YAxisFloat()
                                     .Legend(true, ChartJsPosition.Top);
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
                                     .AddDataset(ds => ds
                                         .SetLabel("Avg Response (ms)")
                                         .SetData(120, 250, 180, 300, 450)
                                         .SetBackgroundColors(RGBColor.ForestGreen, RGBColor.Orange, RGBColor.ForestGreen, RGBColor.DarkOrange, RGBColor.Crimson)
                                         .SetBorderColors(RGBColor.DarkGreen, RGBColor.DarkOrange, RGBColor.DarkGreen, RGBColor.OrangeRed, RGBColor.Firebrick)
                                         .SetBorderWidth(2)
                                     )
                                     .BeginAtZero()
                                     .Legend(false)
                                     .YAxisTitle("Response Time (ms)");
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
                                     .AddDataset(ds => ds
                                         .SetLabel("Hospital A")
                                         .SetData(85, 78, 92, 65, 88, 82)
                                         .SetBorderColor(RGBColor.Crimson)
                                         .SetBackgroundColor(new RGBColor("rgba(231, 76, 60, 0.2)"))
                                         .SetBorderWidth(2)
                                         .SetPointBackgroundColor(RGBColor.Crimson)
                                     )
                                     .AddDataset(ds => ds
                                         .SetLabel("Hospital B")
                                         .SetData(90, 85, 88, 75, 92, 86)
                                         .SetBorderColor(RGBColor.ForestGreen)
                                         .SetBackgroundColor(new RGBColor("rgba(39, 174, 96, 0.2)"))
                                         .SetBorderWidth(2)
                                         .SetPointBackgroundColor(RGBColor.ForestGreen)
                                     )
                                     .RAxisRange(0, 100);
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
                                     .AddDataset(ds => ds
                                         .SetLabel("Desktop")
                                         .SetData(3.2, 3.5, 3.8, 3.6, 4.1, 4.3)
                                         .SetBorderColor(RGBColor.DodgerBlue)
                                         .SetBackgroundColor(new RGBColor("rgba(52, 152, 219, 0.1)"))
                                         .SetBorderWidth(3)
                                         .SetPointRadius(6)
                                         .SetPointBackgroundColor(RGBColor.DodgerBlue)
                                         .SetPointBorderColor(RGBColor.White)
                                         .SetPointBorderWidth(2)
                                         .SetTension(0.4)
                                     )
                                     .AddDataset(ds => ds
                                         .SetLabel("Mobile")
                                         .SetData(2.1, 2.3, 2.5, 2.4, 2.8, 3.0)
                                         .SetBorderColor(RGBColor.Crimson)
                                         .SetBackgroundColor(new RGBColor("rgba(231, 76, 60, 0.1)"))
                                         .SetBorderWidth(3)
                                         .SetPointRadius(6)
                                         .SetPointBackgroundColor(RGBColor.Crimson)
                                         .SetPointBorderColor(RGBColor.White)
                                         .SetPointBorderWidth(2)
                                         .SetTension(0.4)
                                     )
                                     .BeginAtZero()
                                     .YAxisTitle("Conversion Rate %");
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
                                     .AddDataset(ds => ds
                                         .SetLabel("Efficiency %")
                                         .SetData(87, 92, 78, 95, 89)
                                         .SetBackgroundColors(RGBColor.Orange, RGBColor.ForestGreen, RGBColor.Crimson, RGBColor.ForestGreen, RGBColor.Orange)
                                         .SetBorderColors(RGBColor.DarkOrange, RGBColor.DarkGreen, RGBColor.Firebrick, RGBColor.DarkGreen, RGBColor.DarkOrange)
                                         .SetBorderWidth(2)
                                     )
                                     .Legend(false)
                                     .YAxisRange(70, 100)
                                     .YAxisTitle("Efficiency %");
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
                                     .AddDataset(ds => ds
                                         .SetLabel("Revenue Growth %")
                                         .SetData(15, 18, 22, 25, 28, 32, 35, 38)
                                         .SetBorderColor(RGBColor.ForestGreen)
                                         .SetBackgroundColor(new RGBColor("rgba(39, 174, 96, 0.1)"))
                                         .SetBorderWidth(3)
                                         .SetPointRadius(6)
                                         .SetPointBackgroundColor(RGBColor.ForestGreen)
                                         .SetPointBorderColor(RGBColor.White)
                                         .SetPointBorderWidth(2)
                                         .SetTension(0.4)
                                     )
                                     .AddDataset(ds => ds
                                         .SetLabel("Customer Satisfaction")
                                         .SetData(78, 82, 85, 87, 89, 91, 93, 95)
                                         .SetBorderColor(RGBColor.DodgerBlue)
                                         .SetBackgroundColor(new RGBColor("rgba(52, 152, 219, 0.1)"))
                                         .SetBorderWidth(3)
                                         .SetPointRadius(6)
                                         .SetPointBackgroundColor(RGBColor.DodgerBlue)
                                         .SetPointBorderColor(RGBColor.White)
                                         .SetPointBorderWidth(2)
                                         .SetTension(0.4)
                                     )
                                     .AddDataset(ds => ds
                                         .SetLabel("Market Share %")
                                         .SetData(12, 13, 15, 16, 18, 20, 22, 24)
                                         .SetBorderColor(RGBColor.Crimson)
                                         .SetBackgroundColor(new RGBColor("rgba(231, 76, 60, 0.1)"))
                                         .SetBorderWidth(3)
                                         .SetPointRadius(6)
                                         .SetPointBackgroundColor(RGBColor.Crimson)
                                         .SetPointBorderColor(RGBColor.White)
                                         .SetPointBorderWidth(2)
                                         .SetTension(0.4)
                                     )
                                     .BeginAtZero()
                                     .YAxisTitle("Performance Metrics")
                                     .Legend(true, ChartJsPosition.Top)
                                     .LegendLabels(12, ChartJsFontWeight.Bold, new RGBColor("#666"), 10, true);
                            });
                        });
                    });
                });
            });
        });

        document.Save("ChartJsDemoEnhanced.html", openInBrowser);
        
        HelpersSpectre.Success("📊 ChartJs Enhanced Demo created successfully!");
        HelpersSpectre.Success("✨ Features demonstrated:");
        HelpersSpectre.Success("   • All chart types: Line, Bar, Pie, Doughnut, Radar, Polar Area, Scatter, Bubble");
        HelpersSpectre.Success("   • Multiple datasets with custom colors and styling");
        HelpersSpectre.Success("   • Advanced configuration: titles, legends, tooltips, animations");
        HelpersSpectre.Success("   • Stacked charts and custom scales");
        HelpersSpectre.Success("   • Fluent API with full type safety");
        HelpersSpectre.Success("   • Zero HTML/CSS/JS required from the user");
    }
}