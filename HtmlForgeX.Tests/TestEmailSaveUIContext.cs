using System;
using System.IO;
using System.Threading;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

/// <summary>
/// Verifies email saving when a synchronization context is captured.
/// </summary>
[TestClass]
public class TestEmailSaveUIContext {
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
            var email = new Email();
            var path = Path.Combine(TempPath.Get(), $"ui_{Guid.NewGuid():N}.html");
            email.SaveAsync(path).GetAwaiter().GetResult();
            Assert.IsTrue(File.Exists(path));
            File.Delete(path);
        } finally {
            SynchronizationContext.SetSynchronizationContext(previous);
        }
    }
}