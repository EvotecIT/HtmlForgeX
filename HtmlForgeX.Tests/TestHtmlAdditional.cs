using HtmlForgeX.Tags;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestHtmlAdditional {
    [TestMethod]
    public void BuildTableStylesReturnsExpectedClasses() {
        var styles = new[] { BootStrapTableStyle.Responsive, BootStrapTableStyle.Striped, BootStrapTableStyle.Hover };
        var result = styles.BuildTableStyles();
        Assert.AreEqual("table table-responsive table-striped table-hover", result);
    }

    [TestMethod]
    public void BuildTableStylesWithoutExtrasReturnsTable() {
        var styles = Array.Empty<BootStrapTableStyle>();
        var result = styles.BuildTableStyles();
        Assert.AreEqual("table", result);
    }

    [TestMethod]
    public void HtmlTagClassAndStyleChainingProducesCorrectOutput() {
        var tag = new HtmlTag("p").Style("color", "red").Style("font-size", "12px")
            .Class(null).Class(string.Empty).Class("first").Class("second");
        Assert.AreEqual("<p style=\"color: red; font-size: 12px\" class=\"first second\"></p>", tag.ToString());
    }

    [TestMethod]
    public void HtmlTagStyleShouldNotHaveTrailingSemicolonOrSpace() {
        var tag = new HtmlTag("div").Style("margin", "10px").Style("padding", "5px");
        var html = tag.ToString();
        Assert.IsFalse(html.Contains(";\""));
        Assert.AreEqual("<div style=\"margin: 10px; padding: 5px\"></div>", html);
    }

    [TestMethod]
    public void MapLibraryEnumToLibraryObjectWorksAndThrows() {
        var bootstrap = LibrariesConverter.MapLibraryEnumToLibraryObject(Libraries.Bootstrap);
        Assert.IsInstanceOfType(bootstrap, typeof(HtmlForgeX.Resources.Bootstrap));

        Assert.ThrowsException<ArgumentException>(() => LibrariesConverter.MapLibraryEnumToLibraryObject(Libraries.None));
    }
}
