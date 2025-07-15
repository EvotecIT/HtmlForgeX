using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestPrismJs
{
    [TestMethod]
    public void PrismJs_CodeBlock_GeneratesExpectedHtml()
    {
        var doc = new Document();
        doc.Body.Add(element =>
        {
            element.CSharpCode("Console.WriteLine(\"Hi\");", config => config
                .EnableLineNumbers()
                .EnableCopyButton()
                .SetTitle("Sample"));
        });

        var html = doc.ToString();

        Assert.IsTrue(html.Contains("prism-core.min.js"), "Prism core library should be included");
        Assert.IsTrue(doc.Configuration.Libraries.ContainsKey(Libraries.PrismJs), "PrismJs library should be registered");

        var preIndex = html.IndexOf("<pre");
        Assert.IsTrue(preIndex >= 0 && html.IndexOf("data-prismjs-copy", preIndex) > preIndex, "Copy attribute should be present");
        Assert.IsTrue(html.Contains("line-numbers"), "Line numbers class should be present");

        var toolbarIndex = html.IndexOf("prism-toolbar.min.js");
        var copyIndex = html.IndexOf("prism-copy-to-clipboard.min.js");
        Assert.IsTrue(toolbarIndex < copyIndex, "Toolbar script should come before copy-to-clipboard script");
    }
}
