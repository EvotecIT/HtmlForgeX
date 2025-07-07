namespace HtmlForgeX;

/// <summary>
/// Represents a table-based row layout for email compatibility.
/// Uses HTML tables instead of CSS flexbox/grid for maximum email client support.
/// </summary>
public class EmailRow : Element {
    /// <summary>
    /// Gets or sets additional CSS classes for the row.
    /// </summary>
    public string CssClass { get; set; } = "row";

    /// <summary>
    /// Gets or sets the table layout mode.
    /// </summary>
    public string TableLayout { get; set; } = "fixed";

    /// <summary>
    /// Gets or sets the spacing between columns.
    /// </summary>
    public string ColumnSpacing { get; set; } = "16px";

    /// <summary>
    /// Gets or sets whether to automatically add spacing between columns.
    /// </summary>
    public bool AutoSpaceColumns { get; set; } = true;

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailRow"/> class.
    /// </summary>
    public EmailRow() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailRow"/> class with a custom CSS class.
    /// </summary>
    /// <param name="cssClass">The CSS class to apply.</param>
    public EmailRow(string cssClass) {
        CssClass = cssClass;
    }

    /// <summary>
    /// Adds a column to the row.
    /// </summary>
    /// <param name="column">The column to add.</param>
    /// <returns>The EmailRow object, allowing for method chaining.</returns>
    public EmailRow Add(EmailColumn column) {
        column.Email = this.Email;
        Children.Add(column);
        return this;
    }

    /// <summary>
    /// Adds a column to the row using a configuration action.
    /// </summary>
    /// <param name="config">The configuration action for the column.</param>
    /// <returns>The EmailColumn that was added.</returns>
    public EmailColumn AddColumn(Action<EmailColumn> config) {
        var column = new EmailColumn();
        column.Email = this.Email;
        config(column);
        this.Add(column);
        return column;
    }

    /// <summary>
    /// Adds a spacer column to create spacing between content columns.
    /// </summary>
    /// <param name="width">The width of the spacer in pixels.</param>
    /// <returns>The EmailRow object, allowing for method chaining.</returns>
    public EmailRow AddSpacer(int width = 24) {
        var spacer = new EmailColumn();
        spacer.Email = this.Email;
        spacer.SetWidth($"{width}px");
        spacer.CssClass = "col-spacer";
        Children.Add(spacer);
        return this;
    }

    /// <summary>
    /// Sets the spacing between columns.
    /// </summary>
    /// <param name="spacing">The spacing value.</param>
    /// <returns>The EmailRow object, allowing for method chaining.</returns>
    public EmailRow SetColumnSpacing(string spacing) {
        ColumnSpacing = spacing;
        AutoSpaceColumns = true;
        return this;
    }

    /// <summary>
    /// Disables automatic spacing between columns.
    /// </summary>
    /// <returns>The EmailRow object, allowing for method chaining.</returns>
    public EmailRow DisableAutoSpacing() {
        AutoSpaceColumns = false;
        return this;
    }

    /// <summary>
    /// Converts the EmailRow to its HTML table representation.
    /// </summary>
    /// <returns>HTML string representing the email row as a table.</returns>
    public override string ToString() {
        var html = StringBuilderCache.Acquire();

        // Create table element with row styling
        var tableStyle = $"font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif; border-collapse: collapse; width: 100%; table-layout: {TableLayout};";

        html.AppendLine($"\t\t\t\t\t\t\t\t<table class=\"{CssClass}\" cellspacing=\"0\" cellpadding=\"0\" style=\"{tableStyle}\">");
        html.AppendLine("\t\t\t\t\t\t\t\t\t<tr>");

                // Render child columns
        for (int i = 0; i < Children.Count; i++) {
            var child = Children[i];
            var isLastChild = i == Children.Count - 1;

            if (child is EmailColumn column) {
                // Render column as table cell
                var cellStyle = "font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif;";
                if (!string.IsNullOrEmpty(column.Width)) {
                    cellStyle += $" width: {column.Width};";
                }

                // Add spacing between columns if enabled
                if (AutoSpaceColumns && !isLastChild) {
                    cellStyle += $" padding-right: {ColumnSpacing};";
                }

                html.AppendLine($"\t\t\t\t\t\t\t\t\t\t<td class=\"{column.CssClass}\" style=\"{cellStyle}\" valign=\"top\">");

                // Render column content
                var columnContent = column.GetContentString();
                if (!string.IsNullOrEmpty(columnContent)) {
                    html.AppendLine(columnContent);
                }

                html.AppendLine("\t\t\t\t\t\t\t\t\t\t</td>");
            } else {
                // For non-column children, wrap in a single cell spanning all columns
                html.AppendLine("\t\t\t\t\t\t\t\t\t\t<td style=\"font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif;\">");
                var childContent = child.ToString();
                if (!string.IsNullOrEmpty(childContent)) {
                    html.AppendLine(childContent);
                }
                html.AppendLine("\t\t\t\t\t\t\t\t\t\t</td>");
            }
        }

        html.AppendLine("\t\t\t\t\t\t\t\t\t</tr>");
        html.AppendLine("\t\t\t\t\t\t\t\t</table>");

        return StringBuilderCache.GetStringAndRelease(html);
    }
}