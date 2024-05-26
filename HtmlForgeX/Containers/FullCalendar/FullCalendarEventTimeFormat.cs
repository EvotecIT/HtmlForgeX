namespace HtmlForgeX;

/// <summary>
/// Event time format options.
///
/// Links:
/// - https://fullcalendar.io/docs/eventTimeFormat
/// </summary>
public class FullCalendarEventTimeFormat {
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("hour")]
    public string Hour { get; set; } = "2-digit";

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("minute")]
    public string Minute { get; set; } = "2-digit";

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("second")]
    public string Second { get; set; }

    [JsonPropertyName("omitZeroMinute")]
    public bool OmitZeroMinute { get; set; } = false;

    [JsonPropertyName("hour12")]
    public bool Hour12 { get; set; } = false;

    [JsonPropertyName("meridiem")]
    public bool Meridiem { get; set; } = false;
}