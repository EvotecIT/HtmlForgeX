namespace HtmlForgeX;

/// <summary>
/// Configuration options for the FullCalendar component.
/// </summary>
public class FullCalendarOptions {
    [JsonConverter(typeof(FullCalendarToolbarConverter))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("headerToolbar")]
    /// <summary>Toolbar displayed at the top.</summary>
    public FullCalendarToolbar HeaderToolbar { get; set; }

    [JsonConverter(typeof(FullCalendarToolbarConverter))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("footerToolbar")]
    public FullCalendarToolbar FooterToolbar { get; set; }

    [JsonConverter(typeof(Iso8601DateConverter))]
    [JsonPropertyName("initialDate")]
    public DateTime InitialDate { get; set; } = DateTime.Now;

    [JsonPropertyName("nowIndicator")] public bool NowIndicator { get; set; }

    [JsonPropertyName("navLinks")] public bool NavLinks { get; set; }

    [JsonPropertyName("businessHours")] public bool BusinessHours { get; set; }

    [JsonPropertyName("editable")] public bool Editable { get; set; }

    [JsonPropertyName("dayMaxEventRows")] public bool DayMaxEventRows { get; set; }

    [JsonPropertyName("weekNumbers")] public bool WeekNumbers { get; set; }

    [JsonPropertyName("weekNumberCalculation")]
    public string WeekNumberCalculation { get; set; } = "ISO";

    [JsonPropertyName("selectable")] public bool Selectable { get; set; }

    [JsonPropertyName("selectMirror")] public bool SelectMirror { get; set; }

    [JsonPropertyName("buttonIcons")] public bool ButtonIcons { get; set; }

    [JsonConverter(typeof(ViewOptionDictionaryConverter))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("views")]
    public Dictionary<FullCalendarViewOption, FullCalendarView> Views { get; set; } = new Dictionary<FullCalendarViewOption, FullCalendarView> {
        [FullCalendarViewOption.ListWeek] = new FullCalendarView { ButtonText = "list week" },
        [FullCalendarViewOption.ListMonth] = new FullCalendarView { ButtonText = "list month" },
        [FullCalendarViewOption.ListYear] = new FullCalendarView { ButtonText = "list year" },
        [FullCalendarViewOption.ListDay] = new FullCalendarView { ButtonText = "list day" }
    };

    [JsonPropertyName("events")]
    public List<FullCalendarEvent> Events { get; set; } = new List<FullCalendarEvent>();

    [JsonPropertyName("eventTimeFormat")]
    public FullCalendarEventTimeFormat EventTimeFormat { get; set; } = new FullCalendarEventTimeFormat();

    [JsonPropertyName("slotLabelFormat")]
    public FullCalendarEventTimeFormat TimeFormat { get; set; } = new FullCalendarEventTimeFormat();

    [JsonConverter(typeof(JavaScriptFunctionConverter))]
    [JsonPropertyName("eventDidMount")]
    public string EventDidMount { get; set; } = @"
        function (info) {
            var tooltip = new Tooltip(info.el, {
                title: info.event.extendedProps.description,
                placement: 'top',
                trigger: 'hover',
                container: 'body'
            });
        }
    ";

    [JsonConverter(typeof(JavaScriptFunctionConverter))]
    [JsonPropertyName("eventClick")]
    public string EventClick { get; set; } = @"
        function (info) {
            var eventObj = info.event;
            if (eventObj.extendedProps.targetName) {
                window.open(eventObj.url, eventObj.extendedProps.targetName);
                info.jsEvent.preventDefault(); // prevents browser from following link in current tab.
            }
        }
    ";
}