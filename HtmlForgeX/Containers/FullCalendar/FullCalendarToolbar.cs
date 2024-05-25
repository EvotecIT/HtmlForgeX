using System.ComponentModel;
using System.Reflection;

namespace HtmlForgeX;
public class FullCalendarToolbar {
    [JsonPropertyName("left")]
    public List<FullCalendarToolbarOption> LeftOptions { get; set; } = new List<FullCalendarToolbarOption>();
    [JsonPropertyName("center")]
    public List<FullCalendarToolbarOption> CenterOptions { get; set; } = new List<FullCalendarToolbarOption>();
    [JsonPropertyName("right")]
    public List<FullCalendarToolbarOption> RightOptions { get; set; } = new List<FullCalendarToolbarOption>();

    public FullCalendarToolbar Left(FullCalendarToolbarOption option) {
        LeftOptions.Add(option);
        return this;
    }

    public FullCalendarToolbar Center(FullCalendarToolbarOption option) {
        CenterOptions.Add(option);
        return this;
    }

    public FullCalendarToolbar Right(FullCalendarToolbarOption option) {
        RightOptions.Add(option);
        return this;
    }

    public FullCalendarToolbar Left(params FullCalendarToolbarOption[] options) {
        LeftOptions.AddRange(options);
        return this;
    }

    public FullCalendarToolbar Center(params FullCalendarToolbarOption[] options) {
        CenterOptions.AddRange(options);
        return this;
    }

    public FullCalendarToolbar Right(params FullCalendarToolbarOption[] options) {
        RightOptions.AddRange(options);
        return this;
    }
}