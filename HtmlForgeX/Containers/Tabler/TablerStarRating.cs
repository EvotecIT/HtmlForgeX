namespace HtmlForgeX;

public class TablerStarRating : Element {
    public string Id { get; set; } = GlobalStorage.GenerateRandomId("rating");
    public string? Class { get; set; }
    public string DefaultOptionText { get; set; } = "Select a rating";
    public List<(int Value, string Text)> Options { get; } = new();
    public int? SelectedValue { get; set; }

    protected internal override void RegisterLibraries() {
        Document?.Configuration.Libraries.TryAdd(Libraries.StarRating, 0);
        Document?.Configuration.Libraries.TryAdd(Libraries.TablerIcon, 0);
    }

    public TablerStarRating Option(int value, string text, bool selected = false) {
        Options.Add((value, text));
        if (selected) {
            SelectedValue = value;
        }
        return this;
    }

    public override string ToString() {
        var selectTag = new HtmlTag("select").Id(Id);
        if (!string.IsNullOrEmpty(Class)) {
            selectTag.Class(Class);
        }
        selectTag.Value(new HtmlTag("option").Attribute("value", "").Value(DefaultOptionText));
        foreach (var (value, text) in Options) {
            var option = new HtmlTag("option").Attribute("value", value.ToString()).Value(text);
            if (SelectedValue.HasValue && SelectedValue.Value == value) {
                option.Attribute("selected", "");
            }
            selectTag.Value(option);
        }
        return selectTag.ToString();
    }
}
