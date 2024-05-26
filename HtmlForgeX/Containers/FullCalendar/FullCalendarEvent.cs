namespace HtmlForgeX;

/// <summary>
/// Represents an event in the FullCalendar library.
/// </summary>
public class FullCalendarEvent {
    /// <summary>
    /// Initializes a new instance of the <see cref="FullCalendarEvent"/> class with the specified title and start date.
    /// </summary>
    /// <param name="title">The title of the event.</param>
    /// <param name="start">The start date of the event.</param>
    public FullCalendarEvent(string title, DateTime start) {
        TitleValue = title;
        StartValue = start;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FullCalendarEvent"/> class with the specified title, description, start date, and end date.
    /// </summary>
    /// <param name="title">The title of the event.</param>
    /// <param name="description">The description of the event.</param>
    /// <param name="start">The start date of the event.</param>
    /// <param name="end">The end date of the event. If null, the event is considered to last one day.</param>
    public FullCalendarEvent(string title, string description, DateTime start, DateTime? end = null) {
        TitleValue = title;
        DescriptionValue = description;
        StartValue = start;
        EndValue = end;
    }

    /// <summary>
    /// Gets or sets the title of the event.
    /// </summary>
    [JsonPropertyName("title")]
    public string TitleValue { get; set; }

    /// <summary>
    /// Gets or sets the URL of the event.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("url")]
    public string UrlValue { get; set; }

    /// <summary>
    /// Gets or sets the description of the event.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("description")]
    public string DescriptionValue { get; set; }

    /// <summary>
    /// Gets or sets the start date of the event.
    /// </summary>
    [JsonPropertyName("start")]
    public DateTime StartValue { get; set; }

    /// <summary>
    /// Gets or sets the end date of the event.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("end")]
    public DateTime? EndValue { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the event lasts all day.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("allDay")]
    public bool? AllDayValue { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the event is interactive.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("interactive")]
    public bool? InteractiveValue { get; set; }

    /// <summary>
    /// Gets or sets the color of the event.
    /// </summary>
    [JsonConverter(typeof(RGBColorConverter))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("color")]
    public RGBColor ColorValue { get; set; }

    /// <summary>
    /// Gets or sets the background color of the event.
    /// </summary>
    [JsonConverter(typeof(RGBColorConverter))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("backgroundColor")]
    public RGBColor BackgroundColorValue { get; set; }

    /// <summary>
    /// Gets or sets the border color of the event.
    /// </summary>
    [JsonConverter(typeof(RGBColorConverter))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("borderColor")]
    public RGBColor BorderColorValue { get; set; }

    /// <summary>
    /// Gets or sets the text color of the event.
    /// </summary>
    [JsonConverter(typeof(RGBColorConverter))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("textColor")]
    public RGBColor TextColorValue { get; set; }

    public FullCalendarEvent AllDay(bool value) {
        AllDayValue = value;
        return this;
    }
    public FullCalendarEvent Title(string value) {
        TitleValue = value;
        return this;
    }

    public FullCalendarEvent Url(string value) {
        UrlValue = value;
        return this;
    }

    public FullCalendarEvent Description(string value) {
        DescriptionValue = value;
        return this;
    }

    public FullCalendarEvent Start(DateTime value) {
        StartValue = value;
        return this;
    }

    public FullCalendarEvent End(DateTime? value) {
        EndValue = value;
        return this;
    }

    public FullCalendarEvent Color(RGBColor value) {
        ColorValue = value;
        return this;
    }

    public FullCalendarEvent BackgroundColor(RGBColor value) {
        BackgroundColorValue = value;
        return this;
    }

    public FullCalendarEvent BorderColor(RGBColor value) {
        BorderColorValue = value;
        return this;
    }

    public FullCalendarEvent TextColor(RGBColor value) {
        TextColorValue = value;
        return this;
    }

    public FullCalendarEvent Interactive(bool value) {
        InteractiveValue = value;
        return this;
    }
}