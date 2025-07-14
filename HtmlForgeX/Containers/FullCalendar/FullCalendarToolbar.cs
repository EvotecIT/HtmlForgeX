using System.ComponentModel;
using System.Reflection;

namespace HtmlForgeX;
/// <summary>
/// Toolbar configuration for FullCalendar.
/// </summary>
public class FullCalendarToolbar {
    /// <summary>Options on the left side.</summary>
    [JsonPropertyName("left")]
    public List<FullCalendarToolbarOption> LeftOptions { get; set; } = new List<FullCalendarToolbarOption>();
    /// <summary>Options displayed in the center.</summary>
    [JsonPropertyName("center")]
    public List<FullCalendarToolbarOption> CenterOptions { get; set; } = new List<FullCalendarToolbarOption>();
    /// <summary>Options on the right side.</summary>
    [JsonPropertyName("right")]
    public List<FullCalendarToolbarOption> RightOptions { get; set; } = new List<FullCalendarToolbarOption>();

    /// <summary>
    /// Adds a single option to the left side of the toolbar.
    /// </summary>
    public FullCalendarToolbar Left(FullCalendarToolbarOption option) {
        LeftOptions.Add(option);
        return this;
    }

    /// <summary>
    /// Adds a single option to the center of the toolbar.
    /// </summary>
    public FullCalendarToolbar Center(FullCalendarToolbarOption option) {
        CenterOptions.Add(option);
        return this;
    }

    /// <summary>
    /// Adds a single option to the right side of the toolbar.
    /// </summary>
    public FullCalendarToolbar Right(FullCalendarToolbarOption option) {
        RightOptions.Add(option);
        return this;
    }

    /// <summary>
    /// Adds multiple options to the left side of the toolbar.
    /// </summary>
    public FullCalendarToolbar Left(params FullCalendarToolbarOption[] options) {
        LeftOptions.AddRange(options);
        return this;
    }

    /// <summary>
    /// Adds multiple options to the center of the toolbar.
    /// </summary>
    public FullCalendarToolbar Center(params FullCalendarToolbarOption[] options) {
        CenterOptions.AddRange(options);
        return this;
    }

    /// <summary>
    /// Adds multiple options to the right side of the toolbar.
    /// </summary>
    public FullCalendarToolbar Right(params FullCalendarToolbarOption[] options) {
        RightOptions.AddRange(options);
        return this;
    }
}