using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.Text;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestStringBuilderCache {
    [TestMethod]
    public void AcquireRelease_ReusesInstance() {
        var cache = typeof(Document).Assembly.GetType("HtmlForgeX.StringBuilderCache")!;
        var acquire = cache.GetMethod("Acquire", BindingFlags.Public | BindingFlags.Static)!;
        var release = cache.GetMethod("Release", BindingFlags.Public | BindingFlags.Static)!;
        var get = cache.GetMethod("GetStringAndRelease", BindingFlags.Public | BindingFlags.Static)!;

        var sb1 = (StringBuilder)acquire.Invoke(null, null)!;
        sb1.Append("data");
        release.Invoke(null, new object?[] { sb1 });

        var sb2 = (StringBuilder)acquire.Invoke(null, null)!;
        Assert.AreSame(sb1, sb2);

        sb2.Clear();
        sb2.Append("abc");
        var result = (string)get.Invoke(null, new object[] { sb2 })!;
        Assert.AreEqual("abc", result);
    }
}
