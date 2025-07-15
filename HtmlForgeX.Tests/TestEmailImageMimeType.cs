using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestEmailImageMimeType
{
    [TestMethod]
    public void GetExtensionFromMimeType_ShouldHandleImageJpg()
    {
        var method = typeof(EmailImage).GetMethod("GetExtensionFromMimeType", BindingFlags.NonPublic | BindingFlags.Static);
        Assert.IsNotNull(method);
        var result = (string?)method!.Invoke(null, new object[] { "image/jpg" });
        Assert.AreEqual(".jpg", result);
    }
}
