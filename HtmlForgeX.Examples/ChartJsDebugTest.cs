using System;
using System.IO;
using HtmlForgeX.Examples.Containers;

namespace HtmlForgeX.Examples
{
    public class ChartJsDebugTest
    {
        public static void RunWithDebug()
        {
            Console.WriteLine("🔍 ChartJs Debug Test Starting...");
            
            try
            {
                // First, let's test if we can create a simple document
                Console.WriteLine("\n1️⃣ Testing simple document creation...");
                using (var testDoc = new Document {
                    Head = { Title = "Debug Test", Author = "Test" },
                    LibraryMode = LibraryMode.Online,
                    ThemeMode = ThemeMode.Light
                })
                {
                    testDoc.Body.Add(new HtmlTag("p").Value("Test"));
                    var html = testDoc.ToString();
                    Console.WriteLine($"   ✓ HTML generated: {html.Length} characters");
                    
                    // Test save
                    try
                    {
                        testDoc.Save("DebugTest.html", false);
                        Console.WriteLine("   ✓ Save method completed");
                        
                        if (File.Exists("DebugTest.html"))
                        {
                            Console.WriteLine("   ✓ File exists!");
                            File.Delete("DebugTest.html");
                        }
                        else
                        {
                            Console.WriteLine("   ✗ File not found after save");
                        }
                    }
                    catch (Exception saveEx)
                    {
                        Console.WriteLine($"   ✗ Save failed: {saveEx.GetType().Name}: {saveEx.Message}");
                        Console.WriteLine($"     Stack: {saveEx.StackTrace}");
                    }
                }
                
                // Now test ChartJs specifically
                Console.WriteLine("\n2️⃣ Testing ChartJs document...");
                using (var chartDoc = new Document {
                    Head = { Title = "ChartJs Debug", Author = "Test" },
                    LibraryMode = LibraryMode.Online,
                    ThemeMode = ThemeMode.Light
                })
                {
                    chartDoc.Body.Page(page => {
                        page.Layout = TablerLayout.Fluid;
                        
                        // Simple chart
                        page.ChartJs(chart => {
                            chart.Line()
                                 .AddData("Jan", 30)
                                 .AddData("Feb", 70)
                                 .AddData("Mar", 40);
                        });
                    });
                    
                    var chartHtml = chartDoc.ToString();
                    Console.WriteLine($"   ✓ Chart HTML generated: {chartHtml.Length} characters");
                    
                    // Check for Chart.js script
                    if (chartHtml.Contains("chart.js"))
                    {
                        Console.WriteLine("   ✓ Chart.js library included");
                    }
                    else
                    {
                        Console.WriteLine("   ✗ Chart.js library NOT included!");
                    }
                    
                    // Check for canvas element
                    if (chartHtml.Contains("<canvas"))
                    {
                        Console.WriteLine("   ✓ Canvas element found");
                    }
                    else
                    {
                        Console.WriteLine("   ✗ Canvas element NOT found!");
                    }
                    
                    // Try to save
                    try
                    {
                        var outputPath = Path.Combine(Directory.GetCurrentDirectory(), "ChartJsDebug.html");
                        Console.WriteLine($"   Saving to: {outputPath}");
                        chartDoc.Save(outputPath, false);
                        Console.WriteLine("   ✓ Save method completed");
                        
                        if (File.Exists(outputPath))
                        {
                            var info = new FileInfo(outputPath);
                            Console.WriteLine($"   ✓ File created: {info.Length} bytes");
                            
                            // Show first bit of content
                            var content = File.ReadAllText(outputPath);
                            Console.WriteLine($"   First 300 chars:\n{content.Substring(0, Math.Min(300, content.Length))}...");
                        }
                        else
                        {
                            Console.WriteLine("   ✗ File not created!");
                        }
                    }
                    catch (Exception saveEx)
                    {
                        Console.WriteLine($"   ✗ Save failed: {saveEx.GetType().Name}: {saveEx.Message}");
                        Console.WriteLine($"     Stack: {saveEx.StackTrace}");
                    }
                }
                
                // Now run the actual BasicChartJs.Demo with exception handling
                Console.WriteLine("\n3️⃣ Running BasicChartJs.Demo with full exception handling...");
                try
                {
                    BasicChartJs.Demo(false); // Don't open browser
                    Console.WriteLine("   ✓ BasicChartJs.Demo completed");
                }
                catch (Exception demoEx)
                {
                    Console.WriteLine($"   ✗ Demo failed: {demoEx.GetType().Name}: {demoEx.Message}");
                    Console.WriteLine($"     Stack: {demoEx.StackTrace}");
                    
                    // Check inner exceptions
                    var inner = demoEx.InnerException;
                    while (inner != null)
                    {
                        Console.WriteLine($"     Inner: {inner.GetType().Name}: {inner.Message}");
                        inner = inner.InnerException;
                    }
                }
                
                // List any HTML files in current directory
                Console.WriteLine("\n4️⃣ HTML files in current directory:");
                var htmlFiles = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.html");
                foreach (var file in htmlFiles)
                {
                    var info = new FileInfo(file);
                    Console.WriteLine($"   - {Path.GetFileName(file)} ({info.Length} bytes, modified: {info.LastWriteTime})");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n❌ Unexpected error: {ex.GetType().Name}: {ex.Message}");
                Console.WriteLine($"   Stack: {ex.StackTrace}");
            }
            
            Console.WriteLine("\n✅ Debug test completed");
        }
    }
}