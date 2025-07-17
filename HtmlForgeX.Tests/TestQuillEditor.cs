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
        Assert.IsTrue(html.Contains("style=\"height:"));
    }

    [TestMethod]
    public void QuillEditor_ThemeSerialized() {
        var editor = new QuillEditor();
        editor.Options.Theme = QuillTheme.Bubble;
        var html = editor.ToString();
        Assert.IsTrue(html.Contains("\"theme\": \"bubble\""));
    }

    [TestMethod]
    public void QuillEditor_ModulesToolbarSerialized() {
        var editor = new QuillEditor();
        editor.Options.Modules.Toolbar = new List<QuillFormat> { QuillFormat.Bold };
        var html = editor.ToString();
        Assert.IsTrue(html.Contains("toolbar"));
    }

    [TestMethod]
    public void QuillEditor_DefaultModulesIncluded() {
        var editor = new QuillEditor();
        var html = editor.ToString();
        Assert.IsTrue(html.Contains("\"modules\""));
    }

    [TestMethod]
    public void QuillEditor_RegistersLibrary() {
        using var doc = new Document();
        doc.Body.Add(el => {
            el.QuillEditor();
        });
        var _ = doc.ToString();
        Assert.IsTrue(doc.Configuration.Libraries.ContainsKey(Libraries.Quill));
    }
}
