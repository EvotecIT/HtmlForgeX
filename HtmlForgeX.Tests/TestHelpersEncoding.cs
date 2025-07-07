using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestHelpersEncoding {
    [TestMethod]
    public void HtmlEncode_EncodesSpecialCharacters() {
        var helpers = typeof(Document).Assembly.GetType("HtmlForgeX.Helpers")!;
        var method = helpers.GetMethod("HtmlEncode", BindingFlags.Public | BindingFlags.Static)!;
        var encoded = (string)method.Invoke(null, new object[] { "<div class=\"t\">&</div>" })!;
        Assert.AreEqual("&lt;div class=&quot;t&quot;&gt;&amp;&lt;/div&gt;", encoded);
    }

    [TestMethod]
    public void Open_ReturnsTrueWhenDisabled() {
        var helpers = typeof(Document).Assembly.GetType("HtmlForgeX.Helpers")!;
        var method = helpers.GetMethod("Open", BindingFlags.Public | BindingFlags.Static)!;
        var result = (bool)method.Invoke(null, new object?[] { "dummy", false })!;
        Assert.IsTrue(result);
    }
}
