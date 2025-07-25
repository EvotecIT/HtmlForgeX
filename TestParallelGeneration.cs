using System;
using System.Diagnostics;
using System.Threading.Tasks;
using HtmlForgeX;
using HtmlForgeX.Tags;

public class TestParallelGeneration
{
    public static async Task Main()
    {
        Console.WriteLine("Testing Parallel Page Generation...\n");
        
        // Test 1: Sequential generation
        Console.WriteLine("1. Sequential Generation Test:");
        var seqStopwatch = Stopwatch.StartNew();
        
        var seqDoc = new MultiPageDocument(LibraryMode.Online, ThemeMode.Light);
        seqDoc.WithSharedNavigation(nav => nav.WithBrand("Test", "index.html"));
        
        for (int i = 0; i < 5; i++)
        {
            seqDoc.AddPageWithLayout($"page{i}", $"page{i}.html", $"Page {i}", page => {
                page.H1($"Test Page {i}");
                page.Add(new TablerText($"Content for page {i}"));
                System.Threading.Thread.Sleep(100); // Simulate work
            });
        }
        
        seqDoc.SaveAll("TestSequential", false);
        seqDoc.Dispose();
        seqStopwatch.Stop();
        
        Console.WriteLine($"Sequential: {seqStopwatch.ElapsedMilliseconds}ms for 5 pages");
        
        // Test 2: Parallel generation
        Console.WriteLine("\n2. Parallel Generation Test:");
        var parStopwatch = Stopwatch.StartNew();
        
        var parDoc = new MultiPageDocument(LibraryMode.Online, ThemeMode.Light);
        parDoc.WithSharedNavigation(nav => nav.WithBrand("Test", "index.html"));
        
        for (int i = 0; i < 5; i++)
        {
            parDoc.AddPageWithLayout($"page{i}", $"page{i}.html", $"Page {i}", page => {
                page.H1($"Test Page {i}");
                page.Add(new TablerText($"Content for page {i}"));
                System.Threading.Thread.Sleep(100); // Simulate work
            });
        }
        
        await parDoc.SaveAllAsync("TestParallel", false);
        parDoc.Dispose();
        parStopwatch.Stop();
        
        Console.WriteLine($"Parallel: {parStopwatch.ElapsedMilliseconds}ms for 5 pages");
        
        // Results
        var improvement = ((double)seqStopwatch.ElapsedMilliseconds - parStopwatch.ElapsedMilliseconds) 
                          / seqStopwatch.ElapsedMilliseconds * 100;
        Console.WriteLine($"\nImprovement: {improvement:F1}% faster");
        Console.WriteLine($"Time saved: {seqStopwatch.ElapsedMilliseconds - parStopwatch.ElapsedMilliseconds}ms");
        
        Console.WriteLine("\nTest completed! Check TestSequential and TestParallel directories.");
    }
}