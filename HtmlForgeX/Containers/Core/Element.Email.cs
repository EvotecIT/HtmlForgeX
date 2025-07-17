namespace HtmlForgeX;

public abstract partial class Element {
    // Email Extension Methods for Natural Builder Pattern
    /// <summary>
    /// Adds an <see cref="T:HtmlForgeX.EmailText"/> element with optional content.
    /// </summary>
    /// <param name="content">Initial text content.</param>
    /// <returns>The created element.</returns>
    public EmailText EmailText(string content = "") {
        var emailText = new EmailText(content);
        this.Add(emailText);
        return emailText;
    }

    /// <summary>
    /// Adds and configures an <see cref="T:HtmlForgeX.EmailText"/> element using the provided action.
    /// </summary>
    /// <param name="config">Configuration action.</param>
    /// <returns>The current element for chaining.</returns>
    public Element EmailText(Action<EmailText> config) {
        var emailText = new EmailText();
        config(emailText);
        this.Add(emailText);
        return this;
    }

    /// <summary>
    /// Adds and configures an <see cref="T:HtmlForgeX.EmailTable"/> element.
    /// </summary>
    /// <param name="config">Configuration action.</param>
    /// <returns>The current element for chaining.</returns>
    public Element EmailTable(Action<EmailTable> config) {
        var emailTable = new EmailTable();
        config(emailTable);
        this.Add(emailTable);
        return this;
    }

    /// <summary>
    /// Adds an <see cref="T:HtmlForgeX.EmailTable"/> populated from a collection.
    /// </summary>
    /// <typeparam name="T">Type of items in the collection.</typeparam>
    /// <param name="data">Data used to populate the table.</param>
    /// <returns>The created table element.</returns>
    public EmailTable EmailTable<T>(IEnumerable<T> data) where T : class {
        var emailTable = new EmailTable();
        emailTable.PopulateFromData(data);
        this.Add(emailTable);
        return emailTable;
    }

    /// <summary>
    /// Adds and configures an <see cref="T:HtmlForgeX.EmailList"/> element.
    /// </summary>
    /// <param name="config">Configuration action.</param>
    /// <returns>The current element for chaining.</returns>
    public Element EmailList(Action<EmailList> config) {
        var emailList = new EmailList();
        config(emailList);
        this.Add(emailList);
        return this;
    }

    /// <summary>
    /// Adds and configures an <see cref="T:HtmlForgeX.EmailRow"/> element.
    /// </summary>
    /// <param name="config">Configuration action.</param>
    /// <returns>The current element for chaining.</returns>
    public Element EmailRow(Action<EmailRow> config) {
        var emailRow = new EmailRow();
        emailRow.Email = this.Email;
        config(emailRow);
        this.Add(emailRow);
        return this;
    }

    /// <summary>
    /// Adds and configures an <see cref="T:HtmlForgeX.EmailColumn"/> element.
    /// </summary>
    /// <param name="config">Configuration action.</param>
    /// <returns>The current element for chaining.</returns>
    public Element EmailColumn(Action<EmailColumn> config) {
        var emailColumn = new EmailColumn();
        emailColumn.Email = this.Email;
        config(emailColumn);
        this.Add(emailColumn);
        return this;
    }

    /// <summary>
    /// Adds and configures an <see cref="T:HtmlForgeX.EmailBox"/> element.
    /// </summary>
    /// <param name="config">Configuration action.</param>
    /// <returns>The current element for chaining.</returns>
    public Element EmailBox(Action<EmailBox> config) {
        var emailBox = new EmailBox();
        emailBox.Email = this.Email;
        config(emailBox);
        this.Add(emailBox);
        return this;
    }

    /// <summary>
    /// Adds and configures an <see cref="T:HtmlForgeX.EmailBox"/> element using a fluent builder.
    /// </summary>
    /// <param name="config">Builder configuration action.</param>
    /// <returns>The current element for chaining.</returns>
    public Element EmailBox(Action<EmailBoxBuilder> config) {
        var builder = new EmailBoxBuilder();
        config(builder);
        var emailBox = builder.Build();
        emailBox.Email = this.Email;
        this.Add(emailBox);
        return this;
    }

    /// <summary>
    /// Adds and configures an <see cref="T:HtmlForgeX.EmailTextBox"/> element.
    /// </summary>
    /// <param name="config">Configuration action.</param>
    /// <returns>The current element for chaining.</returns>
    public Element EmailTextBox(Action<EmailTextBox> config) {
        var emailTextBox = new EmailTextBox();
        config(emailTextBox);
        this.Add(emailTextBox);
        return this;
    }

    /// <summary>
    /// Adds and configures an <see cref="T:HtmlForgeX.EmailImage"/> element.
    /// </summary>
    /// <param name="config">Configuration action.</param>
    /// <returns>The current element for chaining.</returns>
    public Element EmailImage(Action<EmailImage> config) {
        var emailImage = new EmailImage();
        config(emailImage);
        this.Add(emailImage);
        return this;
    }

    /// <summary>
    /// Adds an <see cref="T:HtmlForgeX.EmailImage"/> element with the specified source.
    /// </summary>
    /// <param name="source">Image source path or URL.</param>
    /// <returns>The created image element.</returns>
    public EmailImage EmailImage(string source) {
        var emailImage = new EmailImage(source);
        this.Add(emailImage);
        return emailImage;
    }

    /// <summary>
    /// Adds an <see cref="T:HtmlForgeX.EmailImage"/> element with specified source and width.
    /// </summary>
    /// <param name="source">Image source path or URL.</param>
    /// <param name="width">Width value.</param>
    /// <returns>The created image element.</returns>
    public EmailImage EmailImage(string source, string width) {
        var emailImage = new EmailImage(source, width);
        this.Add(emailImage);
        return emailImage;
    }

    /// <summary>
    /// Adds an empty line break.
    /// </summary>
    /// <returns>The created line break element.</returns>
    public EmailLineBreak EmailLineBreak() {
        var lineBreak = new EmailLineBreak();
        this.Add(lineBreak);
        return lineBreak;
    }

    /// <summary>
    /// Adds a line break with a specific height.
    /// </summary>
    /// <param name="height">CSS height value.</param>
    /// <returns>The created line break element.</returns>
    public EmailLineBreak EmailLineBreak(string height) {
        var lineBreak = new EmailLineBreak(height);
        this.Add(lineBreak);
        return lineBreak;
    }

    /// <summary>
    /// Adds a hyperlink element with text and target URL.
    /// </summary>
    /// <param name="content">Link text.</param>
    /// <param name="href">Target URL.</param>
    /// <returns>The created link element.</returns>
    public EmailLink EmailLink(string content, string href) {
        var emailLink = new EmailLink(content, href);
        this.Add(emailLink);
        return emailLink;
    }

    /// <summary>
    /// Adds a hyperlink element with an option to open in a new window.
    /// </summary>
    /// <param name="content">Link text.</param>
    /// <param name="href">Target URL.</param>
    /// <param name="openInNewWindow">If set to <c>true</c>, the link opens in a new window.</param>
    /// <returns>The created link element.</returns>
    public EmailLink EmailLink(string content, string href, bool openInNewWindow) {
        var emailLink = new EmailLink(content, href, openInNewWindow);
        this.Add(emailLink);
        return emailLink;
    }

    /// <summary>
    /// Adds and configures an <see cref="T:HtmlForgeX.EmailLink"/> element.
    /// </summary>
    /// <param name="config">Configuration action.</param>
    /// <returns>The current element for chaining.</returns>
    public Element EmailLink(Action<EmailLink> config) {
        var emailLink = new EmailLink();
        config(emailLink);
        this.Add(emailLink);
        return this;
    }

    /// <summary>
    /// Adds and configures an <see cref="EmailContent"/> element.
    /// </summary>
    /// <param name="config">Configuration action.</param>
    /// <returns>The current element for chaining.</returns>
    public Element EmailContent(Action<EmailContent> config) {
        var emailContent = new EmailContent();
        emailContent.Email = this.Email;
        config(emailContent);
        this.Add(emailContent);
        return this;
    }
}
