using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestQuillEditor {
    [TestMethod]
    public void QuillEditor_GeneratesBasicHtml() {
        var editor = new QuillEditor();
        editor.Options.Placeholder = "Type here";
        var html = editor.ToString();
        Assert.IsTrue(html.Contains("new Quill"));
        Assert.IsTrue(html.Contains("Type here"));
    }

    [TestMethod]
    public void QuillEditor_RegistersLibrary() {
        var doc = new Document();
        doc.Body.Add(el => {
            el.QuillEditor();
        });
        var _ = doc.ToString();
        Assert.IsTrue(doc.Configuration.Libraries.ContainsKey(Libraries.Quill));
    }
}
