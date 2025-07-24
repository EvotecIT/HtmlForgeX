using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestTempPath {
    [TestMethod]
    public void Get_ReturnsExistingFrameworkFolder() {
        var path = TempPath.Get();
        Assert.IsTrue(Directory.Exists(path));
        StringAssert.Contains(path, "HtmlForgeX");
#if NET472
        StringAssert.Contains(path, "net472");
#elif NET8_0
        StringAssert.Contains(path, "net8.0");
#elif NET9_0
        StringAssert.Contains(path, "net9.0");
#endif
    }
}