namespace HtmlForgeX;

/// <summary>
/// Renders a countdown timer that updates every second and triggers a callback when finished.
/// </summary>
public class TablerCountdown : Element {
    private string Id { get; } = GlobalStorage.GenerateRandomId("countdown");
    private DateTime End { get; set; } = DateTime.UtcNow;
    private string FormatString { get; set; } = "HH:mm:ss";
    private string? CompletionCallback { get; set; }
    /// <summary>
    /// Sets the end time for the countdown.
    /// </summary>
    public TablerCountdown EndTime(DateTime endTime) {
        End = endTime;
        return this;
    }

    /// <summary>
    /// Sets the display format using tokens DD, HH, MM and SS.
    /// </summary>
    public TablerCountdown Format(string format) {
        FormatString = format;
        return this;
    }

    /// <summary>
    /// Specifies a JavaScript callback to invoke when the countdown completes.
    /// </summary>
    public TablerCountdown OnComplete(string callback) {
        CompletionCallback = callback;
        return this;
    }

    /// <inheritdoc />
    public override string ToString() {
        var span = new HtmlTag("span").Id(Id);
        string callback = string.IsNullOrWhiteSpace(CompletionCallback) ? string.Empty : $"{CompletionCallback}();";
        var script = new HtmlTag("script").Value($@"
        document.addEventListener('DOMContentLoaded', function() {{
            var end = new Date('{End:o}');
            var el = document.getElementById('{Id}');
            function pad(n) {{ return n.toString().padStart(2,'0'); }}
            function format(d,h,m,s) {{
                return '{FormatString}'
                    .replace('DD', pad(d))
                    .replace('HH', pad(h))
                    .replace('MM', pad(m))
                    .replace('SS', pad(s));
            }}
            function update() {{
                var now = new Date();
                var diff = Math.floor((end - now) / 1000);
                if (diff <= 0) {{
                    el.textContent = format(0,0,0,0);
                    clearInterval(timer);
                    {callback}
                    return;
                }}
                var d = Math.floor(diff / 86400);
                var h = Math.floor((diff % 86400) / 3600);
                var m = Math.floor((diff % 3600) / 60);
                var s = diff % 60;
                el.textContent = format(d,h,m,s);
            }}
            update();
            var timer = setInterval(update, 1000);
        }});
        ");
        return span + script.ToString();
    }
}
