using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestEmailBoxBuilder
{
    [TestMethod]
    public void BuilderProducesSameOutputAsDirectConstruction()
    {
        var direct = new EmailBox();
        direct.WithPadding("20px");
        direct.WithBackground("#ffffff");
        direct.Add(new BasicElement("Inner"));

        var built = new EmailBoxBuilder()
            .WithPadding("20px")
            .WithBackground("#ffffff")
            .Build();
        built.Add(new BasicElement("Inner"));

        Assert.AreEqual(direct.ToString(), built.ToString());
    }

    [TestMethod]
    public void ElementEmailBoxBuilderAddsConfiguredBox()
    {
        var container = new BasicElement();
        container.EmailBox((EmailBoxBuilder b) => b
            .WithPadding("8px")
            .WithBackground("#eee"));

        Assert.AreEqual(1, container.Children.Count);
        var box = container.Children[0] as EmailBox;
        Assert.IsNotNull(box);
        Assert.AreEqual("8px", box!.Padding);
        Assert.AreEqual("#eee", box.BackgroundColor);
    }
}
