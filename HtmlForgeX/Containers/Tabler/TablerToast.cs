namespace HtmlForgeX;

public class TablerToast : Element {
    private string Id { get; } = GlobalStorage.GenerateRandomId("toast");
    private string PrivateTitle { get; set; } = string.Empty;
    private string PrivateMessage { get; set; } = string.Empty;
    private TablerToastType ToastType { get; set; } = TablerToastType.Default;
    private TablerToastPosition ToastPosition { get; set; } = TablerToastPosition.BottomRight;
    private int AutoDismissDelay { get; set; }

    /// <summary>
    /// Initializes or configures TablerToast.
    /// </summary>
    public TablerToast() {
    }

    /// <summary>
    /// Initializes or configures TablerToast.
    /// </summary>
    public TablerToast(string title, string message, TablerToastType type = TablerToastType.Default) {
        PrivateTitle = title;
        PrivateMessage = message;
        ToastType = type;
    }

    /// <summary>
    /// Initializes or configures Title.
    /// </summary>
    public TablerToast Title(string title) {
        PrivateTitle = title;
        return this;
    }

    /// <summary>
    /// Initializes or configures Message.
    /// </summary>
    public TablerToast Message(string message) {
        PrivateMessage = message;
        return this;
    }

    /// <summary>
    /// Initializes or configures Type.
    /// </summary>
    public TablerToast Type(TablerToastType type) {
        ToastType = type;
        return this;
    }

    /// <summary>
    /// Initializes or configures Position.
    /// </summary>
    public TablerToast Position(TablerToastPosition position) {
        ToastPosition = position;
        return this;
    }

    /// <summary>
    /// Initializes or configures AutoDismiss.
    /// </summary>
    public TablerToast AutoDismiss(int milliseconds) {
        AutoDismissDelay = milliseconds;
        return this;
    }

    private static string PositionClass(TablerToastPosition position) {
        return position switch {
            TablerToastPosition.TopLeft => "top-0 start-0",
            TablerToastPosition.TopCenter => "top-0 start-50 translate-middle-x",
            TablerToastPosition.TopRight => "top-0 end-0",
            TablerToastPosition.BottomLeft => "bottom-0 start-0",
            TablerToastPosition.BottomCenter => "bottom-0 start-50 translate-middle-x",
            TablerToastPosition.BottomRight => "bottom-0 end-0",
            _ => "bottom-0 end-0"
        };
    }

    private static string TypeClass(TablerToastType type) {
        return type switch {
            TablerToastType.Success => "text-bg-success",
            TablerToastType.Warning => "text-bg-warning",
            TablerToastType.Danger => "text-bg-danger",
            TablerToastType.Info => "text-bg-info",
            _ => string.Empty
        };
    }

    /// <summary>
    /// Initializes or configures ToString.
    /// </summary>
    public override string ToString() {
        var container = new HtmlTag("div")
            .Class("toast-container position-fixed p-3")
            .Class(PositionClass(ToastPosition));

        var toast = new HtmlTag("div")
            .Id(Id)
            .Class("toast")
            .Class(TypeClass(ToastType))
            .Attribute("role", "alert")
            .Attribute("aria-live", "assertive")
            .Attribute("aria-atomic", "true");

        var header = new HtmlTag("div")
            .Class("toast-header")
            .Value(new HtmlTag("strong").Class("me-auto").Value(PrivateTitle))
            .Value(new HtmlTag("button")
                .Class("ms-2 btn-close")
                .Attribute("data-bs-dismiss", "toast")
                .Attribute("aria-label", "Close"));

        var body = new HtmlTag("div")
            .Class("toast-body")
            .Value(PrivateMessage);

        toast.Value(header);
        toast.Value(body);
        container.Value(toast);

        var script = new HtmlTag("script").Value($@"
        document.addEventListener('DOMContentLoaded', function () {{
            var toastEl = document.getElementById('{Id}');
            if (toastEl) {{
                var toast = new bootstrap.Toast(toastEl, {{ delay: {AutoDismissDelay}, autohide: {(AutoDismissDelay > 0).ToString().ToLower()} }});
                toast.show();
            }}
        }});
    ");

        return container.ToString() + script.ToString();
    }
}