using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestStringBuilderCache {
    [TestMethod]
    public void AcquireRelease_ReusesInstance() {
        var sb1 = StringBuilderCache.Acquire();
        sb1.Append("data");
        StringBuilderCache.Release(sb1);

        var sb2 = StringBuilderCache.Acquire();
        Assert.AreSame(sb1, sb2);

        sb2.Clear();
        sb2.Append("abc");
        var result = StringBuilderCache.GetStringAndRelease(sb2);
        Assert.AreEqual("abc", result);
    }

    [TestMethod]
    public void Acquire_EnsuresMinimumCapacity() {
        var sb1 = StringBuilderCache.Acquire();
        sb1.Clear();
        sb1.Capacity = 16;
        StringBuilderCache.Release(sb1);

        var sb2 = StringBuilderCache.Acquire();
        Assert.AreSame(sb1, sb2);
        Assert.IsTrue(sb2.Capacity >= StringBuilderCache.DefaultCapacity);
        StringBuilderCache.Release(sb2);
    }

    [TestMethod]
    public void Release_DoesNotCacheWhenOverThreshold() {
        var sb1 = StringBuilderCache.Acquire();
        sb1.EnsureCapacity(StringBuilderCache.MaxBuilderSize + 1);
        StringBuilderCache.Release(sb1);

        var sb2 = StringBuilderCache.Acquire();
        Assert.AreNotSame(sb1, sb2);
        StringBuilderCache.Release(sb2);
    }
}