using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HtmlForgeX;

/// <summary>
/// Built-in calendar view options.
/// </summary>
[JsonConverter(typeof(DescriptionEnumConverter<FullCalendarViewOption>))]
public enum FullCalendarViewOption {
    [Description("listWeek")]
    /// <summary>List events for a week.</summary>
    ListWeek,

    [Description("listMonth")]
    ListMonth,

    [Description("listYear")]
    ListYear,

    [Description("listDay")]
    ListDay
}

public class FullCalendarView {
    [JsonPropertyName("buttonText")]
    public string ButtonText { get; set; }
}