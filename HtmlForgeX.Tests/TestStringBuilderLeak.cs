using System;

using HtmlForgeX;

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

        long before = GetAllocated();
        for (int i = 0; i < 1000; i++) {
            var element = new BasicElement();
            _ = element.ToString();
        }
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        long after = GetAllocated();

        // Ensure allocations stay reasonably low indicating the cached builder was reused
        Assert.IsTrue(after - before < 150_000, $"Too many bytes allocated: {after - before}");
    }

    private static long GetAllocated() {
#if NETFRAMEWORK
        return GC.GetTotalMemory(false);
#else
        return GC.GetAllocatedBytesForCurrentThread();
#endif
    }
}