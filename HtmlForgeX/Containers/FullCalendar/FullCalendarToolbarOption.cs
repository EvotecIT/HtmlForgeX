using System.ComponentModel;

namespace HtmlForgeX;

/// <summary>
/// Options that can be placed on a FullCalendar toolbar.
/// </summary>
[JsonConverter(typeof(DescriptionEnumConverter<FullCalendarToolbarOption>))]
public enum FullCalendarToolbarOption {
    /// <summary>Displays the current view title.</summary>
    [Description("title")]
    Title,

    [Description("prev")]
    Prev,

    [Description("next")]
    Next,

    [Description("prevYear")]
    PrevYear,

    [Description("nextYear")]
    NextYear,

    [Description("today")]
    Today,

    [Description("dayGridMonth")]
    DayGridMonth,

    [Description("timeGridWeek")]
    TimeGridWeek,

    [Description("timeGridDay")]
    TimeGridDay,

    [Description("listMonth")]
    ListMonth
}
