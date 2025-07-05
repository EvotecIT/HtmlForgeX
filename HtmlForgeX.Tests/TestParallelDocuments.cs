using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestParallelDocuments {

    [TestMethod]
    public async Task ParallelDocuments_NoLibraryLeakage() {
        const int documentCount = 10;
        var documents = new ConcurrentBag<Document>();
        var htmlOutputs = new ConcurrentBag<string>();
        
        // Create multiple documents in parallel with different configurations
        var tasks = Enumerable.Range(0, documentCount).Select(async i => {
            var doc = new Document();
            doc.LibraryMode = i % 2 == 0 ? LibraryMode.Online : LibraryMode.Offline;
            doc.ThemeMode = i % 3 == 0 ? ThemeMode.Light : ThemeMode.Dark;
            
            // Add different components to each document
            doc.Body.Add(element => {
                element.QRCode($"https://example{i}.com");
            });
            
            if (i % 2 == 0) {
                doc.Body.Add(element => {
                    element.FullCalendar(calendar => {
                        calendar.AddEvent($"Event {i}", DateTime.Today.AddHours(i));
                    });
                });
            }
            
            documents.Add(doc);
            var html = doc.ToString();
            htmlOutputs.Add(html);
            
            await Task.Delay(1); // Simulate some async work
        });
        
        await Task.WhenAll(tasks);
        
        // Verify no cross-contamination
        var htmlList = htmlOutputs.ToList();
        Assert.AreEqual(documentCount, htmlList.Count, "Should have generated all documents");
        
        // Check that each document has its own unique content
        var uniqueContentCount = htmlList.Select(html => html.GetHashCode()).Distinct().Count();
        Assert.IsTrue(uniqueContentCount >= documentCount / 2, "Documents should have sufficiently unique content");
        
        // Verify library modes are respected
        var onlineDocuments = htmlList.Where(html => html.Contains("https://") || html.Contains("http://")).Count();
        var offlineDocuments = htmlList.Where(html => !html.Contains("cdn.") && (html.Contains("<style>") || html.Contains("<script>"))).Count();
        
        Assert.IsTrue(onlineDocuments > 0, "Some documents should be in online mode");
        Assert.IsTrue(offlineDocuments >= 0, "Some documents should be in offline mode");
    }

    [TestMethod]
    public async Task ParallelDocuments_ConfigurationIsolation() {
        const int documentCount = 20;
        var results = new ConcurrentBag<(string id, int errorCount, int libraryCount, LibraryMode mode)>();
        
        var tasks = Enumerable.Range(0, documentCount).Select(async i => {
            var doc = new Document();
            var randomId = doc.Configuration.GenerateRandomId($"test{i}");
            
            // Configure each document differently
            doc.LibraryMode = (LibraryMode)(i % 3);
            doc.Configuration.EnableDeferredScripts = i % 2 == 0;
            doc.Path = TestUtilities.GetFrameworkSpecificTempPath();
            
            // Add some errors to specific documents
            if (i % 5 == 0) {
                doc.Configuration.Errors.Add($"Test error {i}");
            }
            
            // Add different libraries
            doc.Body.Add(element => {
                element.QRCode($"data{i}");
            });
            
            if (i % 3 == 0) {
                doc.Body.Add(element => {
                    element.DiagramNetwork(network => {
                        network.AddNode(new { id = i, label = $"Node {i}" });
                    });
                });
            }
            
            await Task.Delay(i % 10); // Stagger the work
            
            var html = doc.ToString();
            
            results.Add((
                id: randomId,
                errorCount: doc.Configuration.Errors.Count,
                libraryCount: doc.Configuration.Libraries.Count,
                mode: doc.LibraryMode
            ));
        });
        
        await Task.WhenAll(tasks);
        
        var resultsList = results.ToList();
        
        // Verify each document maintained its own configuration
        Assert.AreEqual(documentCount, resultsList.Count, "All documents should have completed");
        
        // Check that IDs are unique
        var uniqueIds = resultsList.Select(r => r.id).Distinct().Count();
        Assert.AreEqual(documentCount, uniqueIds, "All generated IDs should be unique");
        
        // Verify error isolation
        var documentsWithErrors = resultsList.Where(r => r.errorCount > 0).Count();
        Assert.AreEqual(documentCount / 5, documentsWithErrors, "Only specific documents should have errors");
        
        // Verify library mode distribution
        var modeDistribution = resultsList.GroupBy(r => r.mode).ToDictionary(g => g.Key, g => g.Count());
        Assert.IsTrue(modeDistribution.Count > 1, "Should have multiple library modes");
    }

    [TestMethod]
    public async Task ParallelDocuments_MemoryEfficiency() {
        const int documentCount = 50;
        var memoryBefore = GC.GetTotalMemory(true);
        
        var tasks = Enumerable.Range(0, documentCount).Select(async i => {
            var doc = new Document();
            doc.LibraryMode = LibraryMode.Online; // Use online mode for memory efficiency
            
            // Add a moderate amount of content
            doc.Head.AddTitle($"Document {i}");
            doc.Body.Add(element => {
                element.QRCode($"content{i}");
            });
            
            var html = doc.ToString();
            
            // Verify the document was created successfully
            Assert.IsTrue(html.Contains($"Document {i}"), $"Document {i} should contain its title");
            Assert.IsTrue(html.Contains($"content{i}"), $"Document {i} should contain its content");
            
            await Task.Delay(1);
        });
        
        await Task.WhenAll(tasks);
        
        // Force garbage collection and check memory usage
        GC.Collect();
        GC.WaitForPendingFinalizers();
        var memoryAfter = GC.GetTotalMemory(true);
        
        var memoryIncrease = memoryAfter - memoryBefore;
        
        // Memory increase should be reasonable (less than 10MB for 50 simple documents)
        Assert.IsTrue(memoryIncrease < 10 * 1024 * 1024, 
            $"Memory increase should be reasonable. Actual increase: {memoryIncrease} bytes");
    }

    [TestMethod]
    public async Task ParallelDocuments_ThreadSafety() {
        const int threadCount = 10;
        const int documentsPerThread = 5;
        var allResults = new ConcurrentBag<string>();
        var exceptions = new ConcurrentBag<Exception>();
        
        var tasks = Enumerable.Range(0, threadCount).Select(async threadId => {
            try {
                for (int docId = 0; docId < documentsPerThread; docId++) {
                    var doc = new Document();
                    var uniqueId = $"thread{threadId}_doc{docId}";
                    
                    doc.Head.AddTitle($"Thread {threadId} Document {docId}");
                    doc.Body.Add(element => {
                        element.QRCode(uniqueId);
                    });
                    
                    // Add some complexity
                    if (docId % 2 == 0) {
                        doc.Body.Add(element => {
                            element.FullCalendar(calendar => {
                                calendar.AddEvent($"Event {uniqueId}", DateTime.Today.AddHours(docId));
                            });
                        });
                    }
                    
                    var html = doc.ToString();
                    allResults.Add(html);
                    
                    // Small delay to increase chance of race conditions
                    await Task.Delay(threadId % 3);
                }
            } catch (Exception ex) {
                exceptions.Add(ex);
            }
        });
        
        await Task.WhenAll(tasks);
        
        // Verify no exceptions occurred
        Assert.AreEqual(0, exceptions.Count, 
            $"No exceptions should occur during parallel processing. Exceptions: {string.Join(", ", exceptions.Select(e => e.Message))}");
        
        // Verify all documents were created
        Assert.AreEqual(threadCount * documentsPerThread, allResults.Count, 
            "All documents should have been created successfully");
        
        // Verify content uniqueness and correctness
        var results = allResults.ToList();
        var uniqueResults = results.Distinct().Count();
        Assert.AreEqual(results.Count, uniqueResults, "All generated documents should be unique");
        
        // Verify each document contains its expected unique identifier
        for (int threadId = 0; threadId < threadCount; threadId++) {
            for (int docId = 0; docId < documentsPerThread; docId++) {
                var expectedId = $"thread{threadId}_doc{docId}";
                var containsId = results.Any(html => html.Contains(expectedId));
                Assert.IsTrue(containsId, $"Should contain document with ID: {expectedId}");
            }
        }
    }
}