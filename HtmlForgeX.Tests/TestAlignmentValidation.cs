using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

/// <summary>
/// Verifies that alignment helper methods correctly assign CSS alignment values.
/// </summary>
[TestClass]
public class TestAlignmentValidation
{
    [TestMethod]
    public void WithAlignment_ShouldSetAlignment()
    {
        var image = new EmailImage().WithAlignment(Alignment.Center);
        Assert.AreEqual("center", image.Alignment);

        var text = new EmailText("demo").WithAlignment(Alignment.Left);
        Assert.AreEqual("left", text.TextAlign);

        var link = new EmailLink("demo", "#").WithAlignment(Alignment.Right);
        Assert.AreEqual("right", link.TextAlign);

        var textBox = new EmailTextBox().WithAlignment(Alignment.Center);
        Assert.AreEqual("center", textBox.TextAlign);

        var column = new EmailColumn().SetAlignment(Alignment.Right).ToString();
        StringAssert.Contains(column, "text-align: right");

        var content = new EmailContent().WithAlignment(Alignment.Right).ToString();
        StringAssert.Contains(content, "text-align: right");
    }

    [TestMethod]
    public void WithAlignment_InvalidValue_Throws()
    {
        Assert.ThrowsException<ArgumentException>(() => new EmailImage().WithAlignment(Alignment.Justify));
        Assert.ThrowsException<ArgumentException>(() => new EmailText("demo").WithAlignment(Alignment.Justify));
        Assert.ThrowsException<ArgumentException>(() => new EmailLink("demo", "#").WithAlignment(Alignment.Justify));
        Assert.ThrowsException<ArgumentException>(() => new EmailTextBox().WithAlignment(Alignment.Justify));
        Assert.ThrowsException<ArgumentException>(() => new EmailColumn().SetAlignment(Alignment.Justify));
        Assert.ThrowsException<ArgumentException>(() => new EmailContent().WithAlignment(Alignment.Justify));
    }
}