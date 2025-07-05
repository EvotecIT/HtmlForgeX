using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HtmlForgeX.Resources;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestFontLoader {

    [TestMethod]
    public void LoadFontFromStreamMatchesFile() {
        var fontFamily = "Test Font";
        var bytes = new byte[] { 1, 2, 3, 4, 5, 6 };
        var tempDir = TestUtilities.GetFrameworkSpecificTempPath();
        var path = Path.Combine(tempDir, $"{Guid.NewGuid():N}.ttf");
        File.WriteAllBytes(path, bytes);
        var expected = FontLoader.LoadFontAsStyle(fontFamily, path);
        using var stream = new MemoryStream(bytes);
        var actual = FontLoader.LoadFontAsStyle(fontFamily, stream, ".ttf");
        File.Delete(path);
        Assert.AreEqual(expected.Properties["font-family"], actual.Properties["font-family"]);
        Assert.AreEqual(expected.Properties["src"], actual.Properties["src"]);
    }
}
