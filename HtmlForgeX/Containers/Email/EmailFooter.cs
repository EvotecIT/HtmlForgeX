namespace HtmlForgeX;

/// <summary>
/// Represents a flexible email footer section using EmailBox for custom layouts.
/// Users can build their own footer using EmailText, EmailLink, and other components.
/// </summary>
public class EmailFooter : Element {
    /// <summary>
    /// Gets the main footer box container.
    /// </summary>
    public EmailBox FooterBox { get; private set; } = new EmailBox();

    /// <summary>
    /// Gets or sets the padding for the footer section.
    /// </summary>
    public string Padding { get; set; } = "48px";

    /// <summary>
    /// Gets or sets the Email reference and propagates it to the FooterBox.
    /// </summary>
    public new Email? Email {
        get => base.Email;
        set {
            base.Email = value;
            if (FooterBox != null && value != null) {
                FooterBox.Email = value;
            }
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailFooter"/> class.
    /// </summary>
    public EmailFooter() {
        // Set up the footer box with structural mode (no visual styling)
        FooterBox.SetPadding(Padding)
                 .EnableStructuralMode()
                 .SetChildSpacing("16px")
                 .SetOuterMargin("0 auto 0 auto");
    }

    /// <summary>
    /// Provides access to build the footer content using EmailBox pattern.
    /// </summary>
    /// <param name="configure">Action to configure the footer content.</param>
    /// <returns>The EmailFooter object, allowing for method chaining.</returns>
    public EmailFooter EmailBox(Action<EmailBox> configure) {
        configure(FooterBox);
        return this;
    }

    /// <summary>
    /// Sets the footer padding.
    /// </summary>
    /// <param name="padding">The padding value.</param>
    /// <returns>The EmailFooter object, allowing for method chaining.</returns>
    public EmailFooter SetPadding(string padding) {
        Padding = padding;
        FooterBox.SetPadding(padding);
        return this;
    }

    /// <summary>
    /// Converts the EmailFooter to its HTML representation.
    /// </summary>
    /// <returns>HTML string representing the email footer.</returns>
    public override string ToString() {
        var html = StringBuilderCache.Acquire();

        html.AppendLine($@"<!-- FOOTER -->");
        html.AppendLine(FooterBox.ToString());
        html.AppendLine($@"<!-- /FOOTER -->");

        return StringBuilderCache.GetStringAndRelease(html);
    }
}