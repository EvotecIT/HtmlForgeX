namespace HtmlForgeX;

public abstract partial class Element {
    // Email Extension Methods for Natural Builder Pattern
    public EmailText EmailText(string content = "") {
        var emailText = new EmailText(content);
        this.Add(emailText);
        return emailText;
    }

    public Element EmailText(Action<EmailText> config) {
        var emailText = new EmailText();
        config(emailText);
        this.Add(emailText);
        return this;
    }

    public Element EmailTable(Action<EmailTable> config) {
        var emailTable = new EmailTable();
        config(emailTable);
        this.Add(emailTable);
        return this;
    }

    public EmailTable EmailTable<T>(IEnumerable<T> data) where T : class {
        var emailTable = new EmailTable();
        emailTable.PopulateFromData(data);
        this.Add(emailTable);
        return emailTable;
    }

    public Element EmailList(Action<EmailList> config) {
        var emailList = new EmailList();
        config(emailList);
        this.Add(emailList);
        return this;
    }

    public Element EmailRow(Action<EmailRow> config) {
        var emailRow = new EmailRow();
        emailRow.Email = this.Email;
        config(emailRow);
        this.Add(emailRow);
        return this;
    }

    public Element EmailColumn(Action<EmailColumn> config) {
        var emailColumn = new EmailColumn();
        emailColumn.Email = this.Email;
        config(emailColumn);
        this.Add(emailColumn);
        return this;
    }

    public Element EmailBox(Action<EmailBox> config) {
        var emailBox = new EmailBox();
        emailBox.Email = this.Email;
        config(emailBox);
        this.Add(emailBox);
        return this;
    }

    public Element EmailTextBox(Action<EmailTextBox> config) {
        var emailTextBox = new EmailTextBox();
        config(emailTextBox);
        this.Add(emailTextBox);
        return this;
    }

    public Element EmailImage(Action<EmailImage> config) {
        var emailImage = new EmailImage();
        config(emailImage);
        this.Add(emailImage);
        return this;
    }

    public EmailImage EmailImage(string source) {
        var emailImage = new EmailImage(source);
        this.Add(emailImage);
        return emailImage;
    }

    public EmailImage EmailImage(string source, string width) {
        var emailImage = new EmailImage(source, width);
        this.Add(emailImage);
        return emailImage;
    }

    public EmailLineBreak EmailLineBreak() {
        var lineBreak = new EmailLineBreak();
        this.Add(lineBreak);
        return lineBreak;
    }

    public EmailLineBreak EmailLineBreak(string height) {
        var lineBreak = new EmailLineBreak(height);
        this.Add(lineBreak);
        return lineBreak;
    }

    public EmailLink EmailLink(string content, string href) {
        var emailLink = new EmailLink(content, href);
        this.Add(emailLink);
        return emailLink;
    }

    public EmailLink EmailLink(string content, string href, bool openInNewWindow) {
        var emailLink = new EmailLink(content, href, openInNewWindow);
        this.Add(emailLink);
        return emailLink;
    }

    public Element EmailLink(Action<EmailLink> config) {
        var emailLink = new EmailLink();
        config(emailLink);
        this.Add(emailLink);
        return this;
    }

    public Element EmailContent(Action<EmailContent> config) {
        var emailContent = new EmailContent();
        emailContent.Email = this.Email;
        config(emailContent);
        this.Add(emailContent);
        return this;
    }
}
