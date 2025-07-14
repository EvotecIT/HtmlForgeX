using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace HtmlForgeX.Tests;

/// <summary>
/// Tests document saving when a synchronization context is present.
/// </summary>
[TestClass]
public class TestDocumentSaveUIContext {
    private sealed class NoOpSynchronizationContext : SynchronizationContext {
        public override void Post(SendOrPostCallback d, object? state) {
            // Intentionally do nothing to simulate blocked UI thread
        }
    }

    [TestMethod]
    public void SaveAsync_DoesNotDeadlockInUIContext() {
        var previous = SynchronizationContext.Current;
        SynchronizationContext.SetSynchronizationContext(new NoOpSynchronizationContext());
        try {
            var doc = new Document();
            var path = Path.Combine(TestUtilities.GetFrameworkSpecificTempPath(), $"ui_{Guid.NewGuid():N}.html");
            doc.SaveAsync(path).GetAwaiter().GetResult();
            Assert.IsTrue(File.Exists(path));
            File.Delete(path);
        } finally {
            SynchronizationContext.SetSynchronizationContext(previous);
        }
    }
}
