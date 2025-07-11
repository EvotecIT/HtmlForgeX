using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestStringBuilderLeak {
    [TestMethod]
    public void BasicElement_Empty_NoStringBuilderLeak() {
        // Warm up GC and ensure clean state
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        long before = GC.GetAllocatedBytesForCurrentThread();
        for (int i = 0; i < 1000; i++) {
            var element = new BasicElement();
            _ = element.ToString();
        }
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        long after = GC.GetAllocatedBytesForCurrentThread();

        // Ensure allocations stay reasonably low indicating the cached builder was reused
        Assert.IsTrue(after - before < 150_000, $"Too many bytes allocated: {after - before}");
    }
}
