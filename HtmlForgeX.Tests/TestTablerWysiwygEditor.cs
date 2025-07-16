using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestTablerWysiwygEditor {
    [TestMethod]
    public void WysiwygEditor_IncludesPlaceholder() {
        var form = new TablerForm();
        form.Wysiwyg("notes", e => e.Placeholder("Enter text"));
        var html = form.ToString();
        Assert.IsTrue(html.Contains("Enter text"));
        Assert.IsTrue(html.Contains("new Quill"));
    }

    [TestMethod]
    public void WysiwygEditor_ThemeSerialized() {
        var editor = new TablerWysiwygEditor("e");
        editor.Theme(QuillTheme.Bubble);
        var html = editor.ToString();
        Assert.IsTrue(html.Contains("\"theme\": \"bubble\""));
    }

    [TestMethod]
    public void WysiwygEditor_ToolbarSerialized() {
        var editor = new TablerWysiwygEditor("e");
        editor.Toolbar(new() { QuillFormat.Bold });
        var html = editor.ToString();
        Assert.IsTrue(html.Contains("toolbar"));
    }

    [TestMethod]
    public void WysiwygEditor_MultipleInstances() {
        var form = new TablerForm();
        form.Wysiwyg("first");
        form.Wysiwyg("second");
        var html = form.ToString();
        Assert.IsTrue(html.Contains("first"));
        Assert.IsTrue(html.Contains("second"));
        Assert.IsTrue(html.Contains("new Quill"));
    }
}
