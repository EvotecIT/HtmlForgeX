namespace HtmlForgeX;

/// <summary>
/// Event time format options.
///
/// Links:
/// - https://fullcalendar.io/docs/eventTimeFormat
/// </summary>
public class FullCalendarEventTimeFormat {
    /// <summary>
    /// The hour format used when displaying event times.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("hour")]
    public string Hour { get; set; } = "2-digit";

    /// <summary>
    /// The minute format.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("minute")]
    public string Minute { get; set; } = "2-digit";

    /// <summary>
    /// Optional seconds format.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("second")]
    public string Second { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether minutes should be omitted when zero.
    /// </summary>
    [JsonPropertyName("omitZeroMinute")]
    public bool OmitZeroMinute { get; set; } = false;

    /// <summary>
    /// Gets or sets whether to use 12-hour time.
    /// </summary>
    [JsonPropertyName("hour12")]
    public bool Hour12 { get; set; } = false;

    /// <summary>
    /// Gets or sets whether to display AM/PM designations.
    /// </summary>
    [JsonPropertyName("meridiem")]
    public bool Meridiem { get; set; } = false;
}