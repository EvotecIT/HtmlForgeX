using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestAlignmentValidation
{
    [TestMethod]
    public void WithAlignment_ShouldSetAlignment()
    {
        var image = new EmailImage().WithAlignment(FontAlignment.Center);
        Assert.AreEqual("center", image.Alignment);

        var text = new EmailText("demo").WithAlignment(FontAlignment.Left);
        Assert.AreEqual("left", text.TextAlign);

        var link = new EmailLink("demo", "#").WithAlignment(FontAlignment.Right);
        Assert.AreEqual("right", link.TextAlign);

        var textBox = new EmailTextBox().WithAlignment(FontAlignment.Center);
        Assert.AreEqual("center", textBox.TextAlign);

        var column = new EmailColumn().SetAlignment(FontAlignment.Right).ToString();
        StringAssert.Contains(column, "text-align: right");

        var content = new EmailContent().SetAlignment(FontAlignment.Right).ToString();
        StringAssert.Contains(content, "text-align: right");
    }

    [TestMethod]
    public void WithAlignment_InvalidValue_Throws()
    {
        Assert.ThrowsException<ArgumentException>(() => new EmailImage().WithAlignment(FontAlignment.Justify));
        Assert.ThrowsException<ArgumentException>(() => new EmailText("demo").WithAlignment(FontAlignment.Justify));
        Assert.ThrowsException<ArgumentException>(() => new EmailLink("demo", "#").WithAlignment(FontAlignment.Justify));
        Assert.ThrowsException<ArgumentException>(() => new EmailTextBox().WithAlignment(FontAlignment.Justify));
        Assert.ThrowsException<ArgumentException>(() => new EmailColumn().SetAlignment(FontAlignment.Justify));
        Assert.ThrowsException<ArgumentException>(() => new EmailContent().SetAlignment(FontAlignment.Justify));
    }
}