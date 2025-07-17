using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.Json;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestFullCalendarToolbarConverter {
    [TestMethod]
    public void FullCalendarToolbar_SerializesAndDeserializes() {
        var toolbar = new FullCalendarToolbar()
            .Left(FullCalendarToolbarOption.Prev, FullCalendarToolbarOption.Next)
            .Center(FullCalendarToolbarOption.Title)
            .Right(FullCalendarToolbarOption.DayGridMonth, FullCalendarToolbarOption.TimeGridWeek);

        var opts = new JsonSerializerOptions();
        opts.Converters.Add(new FullCalendarToolbarConverter());

        var json = JsonSerializer.Serialize(toolbar, opts);
        var back = JsonSerializer.Deserialize<FullCalendarToolbar>(json, opts);

        Assert.IsNotNull(back);
        CollectionAssert.AreEqual(toolbar.LeftOptions, back.LeftOptions);
        CollectionAssert.AreEqual(toolbar.CenterOptions, back.CenterOptions);
        CollectionAssert.AreEqual(toolbar.RightOptions, back.RightOptions);
    }

    [TestMethod]
    public void FullCalendarToolbar_DeserializesFromString() {
        const string json = "{\"left\":\"prev,next\",\"center\":\"title\",\"right\":\"dayGridMonth\"}";
        var opts = new JsonSerializerOptions();
        opts.Converters.Add(new FullCalendarToolbarConverter());

        var toolbar = JsonSerializer.Deserialize<FullCalendarToolbar>(json, opts);

        Assert.IsNotNull(toolbar);
        CollectionAssert.AreEqual(
            new List<FullCalendarToolbarOption> { FullCalendarToolbarOption.Prev, FullCalendarToolbarOption.Next },
            toolbar!.LeftOptions);
        CollectionAssert.AreEqual(
            new List<FullCalendarToolbarOption> { FullCalendarToolbarOption.Title },
            toolbar.CenterOptions);
        CollectionAssert.AreEqual(
            new List<FullCalendarToolbarOption> { FullCalendarToolbarOption.DayGridMonth },
            toolbar.RightOptions);
    }
}
