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

    /// <summary>Button to navigate to the previous period.</summary>
    [Description("prev")]
    Prev,

    /// <summary>Button to navigate to the next period.</summary>
    [Description("next")]
    Next,

    /// <summary>Button to go to the previous year.</summary>
    [Description("prevYear")]
    PrevYear,

    /// <summary>Button to go to the next year.</summary>
    [Description("nextYear")]
    NextYear,

    /// <summary>Button to navigate to today.</summary>
    [Description("today")]
    Today,

    /// <summary>Switch to month view.</summary>
    [Description("dayGridMonth")]
    DayGridMonth,

    /// <summary>Switch to week view.</summary>
    [Description("timeGridWeek")]
    TimeGridWeek,

    /// <summary>Switch to day view.</summary>
    [Description("timeGridDay")]
    TimeGridDay,

    /// <summary>Switch to agenda list for the month.</summary>
    [Description("listMonth")]
    ListMonth
}
