namespace HtmlForgeX;

public class FullCalendarEvent {
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("start")]
    public DateTime Start { get; set; }

    [JsonPropertyName("end")]
    public DateTime? End { get; set; }

    public FullCalendarEvent(string title, string description, DateTime start, DateTime? end = null) {
        Title = title;
        Description = description;
        Start = start;
        End = end;
    }
}