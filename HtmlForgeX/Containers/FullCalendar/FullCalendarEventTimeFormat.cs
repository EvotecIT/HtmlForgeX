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
    /// <summary>
    /// The hour format used when displaying event times.
    /// </summary>
    public string Hour { get; set; } = "2-digit";

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("minute")]
    /// <summary>
    /// The minute format.
    /// </summary>
    public string Minute { get; set; } = "2-digit";

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("second")]
    /// <summary>
    /// Optional seconds format.
    /// </summary>
    public string Second { get; set; }

    [JsonPropertyName("omitZeroMinute")]
    /// <summary>
    /// Gets or sets a value indicating whether minutes should be omitted when zero.
    /// </summary>
    public bool OmitZeroMinute { get; set; } = false;

    [JsonPropertyName("hour12")]
    /// <summary>
    /// Gets or sets whether to use 12-hour time.
    /// </summary>
    public bool Hour12 { get; set; } = false;

    [JsonPropertyName("meridiem")]
    /// <summary>
    /// Gets or sets whether to display AM/PM designations.
    /// </summary>
    public bool Meridiem { get; set; } = false;
}