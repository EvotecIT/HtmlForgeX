using System.ComponentModel;

namespace HtmlForgeX;

[JsonConverter(typeof(DescriptionEnumConverter<FullCalendarToolbarOption>))]
public enum FullCalendarToolbarOption {
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
