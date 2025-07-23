namespace HtmlForgeX;

/// <summary>
/// Interactive star rating control using star-rating.js.
/// </summary>
public class TablerStarRating : Element {
    private readonly string _id;
    private double? _value;
    private int _maxStars = 5;
    private string? _onChange;

    /// <summary>
    /// Initializes the control with the specified identifier.
    /// </summary>
    public TablerStarRating(string id) {
        _id = id;
    }

    /// <summary>
    /// Sets the initial rating value.
    /// </summary>
    public TablerStarRating Value(double value) {
        _value = value;
        return this;
    }

    /// <summary>
    /// Sets the maximum number of stars.
    /// </summary>
    public TablerStarRating MaxStars(int stars) {
        _maxStars = stars;
        return this;
    }

    /// <summary>
    /// Registers a JavaScript function to call when the rating changes.
    /// </summary>
    public TablerStarRating OnChange(string jsFunction) {
        _onChange = jsFunction;
        return this;
    }

    /// <inheritdoc />
    protected internal override void RegisterLibraries() {
        Document?.AddLibrary(Libraries.StarRating);
    }

    /// <inheritdoc />
    public override string ToString() {
        var select = new HtmlTag("select").Id(_id);
        for (var i = _maxStars; i >= 1; i--) {
            var option = new HtmlTag("option")
                .Attribute("value", i.ToString())
                .Value(i.ToString());
            if (_value.HasValue && (int)System.Math.Round(_value.Value) == i) {
                option.Attribute("selected", "selected");
            }
            select.Value(option);
        }

        var lines = new List<string> {
            $"document.addEventListener('DOMContentLoaded', function(){{",
            $"    new StarRating('#{_id}', {{ maxStars: {_maxStars} }});"
        };
        if (!string.IsNullOrEmpty(_onChange)) {
            lines.Add($"    document.getElementById('{_id}').addEventListener('change', {_onChange});");
        }
        lines.Add("});");
        var script = new HtmlTag("script").Value(string.Join('\n', lines));
        return select.ToString() + script.ToString();
    }
}