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

    [Description("listMonth")]
    ListMonth,

    [Description("listYear")]
    ListYear,

    [Description("listDay")]
    ListDay
}

public class FullCalendarView {
    /// <summary>
    /// Gets or sets the text shown on the corresponding toolbar button.
    /// </summary>
    [JsonPropertyName("buttonText")]
    public string ButtonText { get; set; }
}