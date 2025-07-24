using System.Reflection;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestEmailImageMimeType {
    [TestMethod]
    public void GetExtensionFromMimeType_ShouldHandleImageJpg() {
        var result = ImageUtilities.GetExtensionFromMimeType("image/jpg");
        Assert.AreEqual(".jpg", result);
    }
}