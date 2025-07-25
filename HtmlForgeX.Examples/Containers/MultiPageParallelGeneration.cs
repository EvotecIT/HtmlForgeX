using System;
using System.Diagnostics;
using System.Threading.Tasks;
using HtmlForgeX.Tags;

namespace HtmlForgeX.Examples.Containers;

internal class MultiPageParallelGeneration {
    public static void Create(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("Multi-Page Parallel Generation");

        // Example 1: Sequential Generation (Traditional)
        Console.WriteLine("\n📋 Example 1: Sequential Page Generation");
        Console.WriteLine("========================================");
        SequentialExample();

        Console.WriteLine("\n");

        // Example 2: Parallel Generation (Performance)
        Console.WriteLine("⚡ Example 2: Parallel Page Generation");
        Console.WriteLine("========================================");
        ParallelExample().Wait();

        Console.WriteLine("\n");

        // Example 3: Benchmark Comparison
        Console.WriteLine("📊 Example 3: Performance Benchmark (10 pages)");
        Console.WriteLine("========================================");
        BenchmarkExample().Wait();
    }

    private static void SequentialExample() {
        Console.WriteLine("Creating a 3-page site sequentially...");
        var stopwatch = Stopwatch.StartNew();

        var multiPageDoc = new MultiPageDocument(LibraryMode.Online, ThemeMode.Light);

        multiPageDoc.WithSharedNavigation(nav => nav
            .WithBrand("Sequential Demo", "index.html")
            .AddItem("Home", "index.html")
            .AddItem("Services", "services.html")
            .AddItem("Contact", "contact.html"));

        // Add pages one by one
        multiPageDoc.AddPageWithLayout("home", "index.html", "Home", page => {
            page.H1("Welcome to Sequential Demo");
            page.Add(new TablerText("This page was generated sequentially."));
            // Simulate some processing time
            System.Threading.Thread.Sleep(100);
        });

        multiPageDoc.AddPageWithLayout("services", "services.html", "Services", page => {
            page.H1("Our Services");
            page.Add(new TablerText("Service page content generated sequentially."));
            System.Threading.Thread.Sleep(100);
        });

        multiPageDoc.AddPageWithLayout("contact", "contact.html", "Contact", page => {
            page.H1("Contact Us");
            page.Add(new TablerText("Contact page content generated sequentially."));
            System.Threading.Thread.Sleep(100);
        });

        // Sequential save
        multiPageDoc.SaveAll("MultiPageParallelGeneration_Sequential", false);
        multiPageDoc.Dispose();

        stopwatch.Stop();
        Console.WriteLine($"✅ Sequential generation completed in: {stopwatch.ElapsedMilliseconds}ms");
        Console.WriteLine($"   Average time per page: {stopwatch.ElapsedMilliseconds / 3}ms");

    }

    private static async Task ParallelExample() {
        Console.WriteLine("Creating a 3-page site in parallel...");
        var stopwatch = Stopwatch.StartNew();

        var multiPageDoc = new MultiPageDocument(LibraryMode.Online, ThemeMode.Light);

        multiPageDoc.WithSharedNavigation(nav => nav
            .WithBrand("Parallel Demo", "index.html")
            .AddItem("Home", "index.html")
            .AddItem("Services", "services.html")
            .AddItem("Contact", "contact.html"));

        // Add all pages (configuration is still sequential)
        multiPageDoc.AddPageWithLayout("home", "index.html", "Home", page => {
            page.H1("Welcome to Parallel Demo");
            page.Add(new TablerText("This page was generated in parallel with others."));
            // Simulate some processing time
            System.Threading.Thread.Sleep(100);
        });

        multiPageDoc.AddPageWithLayout("services", "services.html", "Services", page => {
            page.H1("Our Services");
            page.Add(new TablerText("Service page content generated in parallel."));
            System.Threading.Thread.Sleep(100);
        });

        multiPageDoc.AddPageWithLayout("contact", "contact.html", "Contact", page => {
            page.H1("Contact Us");
            page.Add(new TablerText("Contact page content generated in parallel."));
            System.Threading.Thread.Sleep(100);
        });

        // Parallel save - pages are written to disk simultaneously
        await multiPageDoc.SaveAllAsync("MultiPageParallelGeneration_Parallel", false);
        multiPageDoc.Dispose();

        stopwatch.Stop();
        Console.WriteLine($"✅ Parallel generation completed in: {stopwatch.ElapsedMilliseconds}ms");
        Console.WriteLine($"   Average time per page: {stopwatch.ElapsedMilliseconds / 3}ms");
        Console.WriteLine($"   Note: Pages were written to disk simultaneously!");
    }

    private static async Task BenchmarkExample() {
        const int pageCount = 10;

        // Sequential benchmark
        Console.WriteLine($"\nGenerating {pageCount} pages sequentially...");
        var seqStopwatch = Stopwatch.StartNew();

        var seqDoc = new MultiPageDocument(LibraryMode.Online, ThemeMode.Light);
        seqDoc.WithSharedNavigation(nav => nav.WithBrand("Benchmark", "index.html"));

        for (int i = 0; i < pageCount; i++) {
            var pageNum = i;
            seqDoc.AddPageWithLayout($"page{pageNum}", $"page{pageNum}.html", $"Page {pageNum}", page => {
                page.H1($"Page {pageNum}");
                page.Row(row => {
                    row.Column(TablerColumnNumber.Twelve, col => {
                        col.Card(card => {
                            card.Header(h => h.Title($"Content for Page {pageNum}"));
                            // Simulate complex page generation
                            for (int j = 0; j < 5; j++) {
                                card.Add(new TablerText($"Paragraph {j + 1} with some content..."));
                            }
                            card.Add(new TablerTable(GenerateSampleData(20), TableType.Tabler));
                        });
                    });
                });
                // Simulate processing time
                System.Threading.Thread.Sleep(50);
            });
        }

        seqDoc.SaveAll("MultiPageParallelGeneration_BenchmarkSequential", false);
        seqDoc.Dispose();
        seqStopwatch.Stop();

        Console.WriteLine($"✅ Sequential: {seqStopwatch.ElapsedMilliseconds}ms total ({seqStopwatch.ElapsedMilliseconds / pageCount}ms per page)");

        // Parallel benchmark
        Console.WriteLine($"\nGenerating {pageCount} pages in parallel...");
        var parStopwatch = Stopwatch.StartNew();

        var parDoc = new MultiPageDocument(LibraryMode.Online, ThemeMode.Light);
        parDoc.WithSharedNavigation(nav => nav.WithBrand("Benchmark", "index.html"));

        for (int i = 0; i < pageCount; i++) {
            var pageNum = i;
            parDoc.AddPageWithLayout($"page{pageNum}", $"page{pageNum}.html", $"Page {pageNum}", page => {
                page.H1($"Page {pageNum}");
                page.Row(row => {
                    row.Column(TablerColumnNumber.Twelve, col => {
                        col.Card(card => {
                            card.Header(h => h.Title($"Content for Page {pageNum}"));
                            // Simulate complex page generation
                            for (int j = 0; j < 5; j++) {
                                card.Add(new TablerText($"Paragraph {j + 1} with some content..."));
                            }
                            card.Add(new TablerTable(GenerateSampleData(20), TableType.Tabler));
                        });
                    });
                });
                // Simulate processing time
                System.Threading.Thread.Sleep(50);
            });
        }

        await parDoc.SaveAllAsync("MultiPageParallelGeneration_BenchmarkParallel", false);
        parDoc.Dispose();
        parStopwatch.Stop();

        Console.WriteLine($"✅ Parallel: {parStopwatch.ElapsedMilliseconds}ms total ({parStopwatch.ElapsedMilliseconds / pageCount}ms per page)");

        // Results
        var improvement = ((double)seqStopwatch.ElapsedMilliseconds - parStopwatch.ElapsedMilliseconds)
                          / seqStopwatch.ElapsedMilliseconds * 100;
        Console.WriteLine($"\n📈 Results:");
        Console.WriteLine($"   Sequential: {seqStopwatch.ElapsedMilliseconds}ms");
        Console.WriteLine($"   Parallel: {parStopwatch.ElapsedMilliseconds}ms");
        Console.WriteLine($"   Improvement: {improvement:F1}% faster");
        Console.WriteLine($"   Time saved: {seqStopwatch.ElapsedMilliseconds - parStopwatch.ElapsedMilliseconds}ms");
    }

    private static dynamic[] GenerateSampleData(int count) {
        var data = new dynamic[count];
        for (int i = 0; i < count; i++) {
            data[i] = new {
                Id = i + 1,
                Name = $"Item {i + 1}",
                Value = $"${(i + 1) * 100}",
                Status = i % 2 == 0 ? "Active" : "Inactive"
            };
        }
        return data;
    }
}