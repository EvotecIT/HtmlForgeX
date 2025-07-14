using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestTablerTimeline {
    [TestMethod]
    public void Timeline_GeneratesHtml() {
        var timeline = new TablerTimeline();
        timeline.Item(item => {
            item.Time("now")
                .Icon(TablerIconType.TimelineEventPlus)
                .Color(TablerColor.Success)
                .Title("Added")
                .Description("Created entry");
        });
        var html = timeline.ToString();
        Assert.IsTrue(html.Contains("timeline-event"));
        Assert.IsTrue(html.Contains("timeline-event-icon"));
        Assert.IsTrue(html.Contains("bg-success"));
    }
}
