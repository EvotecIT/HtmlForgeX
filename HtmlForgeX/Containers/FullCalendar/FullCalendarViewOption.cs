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
    /// <summary>List events for a week.</summary>
    [Description("listWeek")]
    ListWeek,

    /// <summary>List events for a month.</summary>
    [Description("listMonth")]
    ListMonth,

    /// <summary>List events for an entire year.</summary>
    [Description("listYear")]
    ListYear,

    /// <summary>List events for a single day.</summary>
    [Description("listDay")]
    ListDay
}

/// <summary>
/// Defines settings for how a view is presented within FullCalendar.
/// </summary>
public class FullCalendarView {
    /// <summary>
    /// Gets or sets the text shown on the corresponding toolbar button.
    /// </summary>
    [JsonPropertyName("buttonText")]
    public string ButtonText { get; set; } = string.Empty;
}