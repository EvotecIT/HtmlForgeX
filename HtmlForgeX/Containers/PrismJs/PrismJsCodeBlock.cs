using System.Text;

namespace HtmlForgeX;

/// <summary>
/// PrismJS syntax-highlighted code block with fluent API
/// </summary>
public class PrismJsCodeBlock : Element
{
    /// <summary>Programming language for syntax highlighting</summary>
    public PrismJsLanguage Language { get; set; } = PrismJsLanguage.None;

    /// <summary>Theme for syntax highlighting</summary>
    public PrismJsTheme Theme { get; set; } = PrismJsTheme.Default;

    /// <summary>Code content to highlight</summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>Optional title/caption for the code block</summary>
    public string? Title { get; set; }

    /// <summary>Enable line numbers</summary>
    public bool ShowLineNumbers { get; set; } = false;

    /// <summary>Enable copy to clipboard button</summary>
    public bool ShowCopyButton { get; set; } = true;

    /// <summary>Highlight specific lines (1-based)</summary>
    public List<int> HighlightLines { get; set; } = new List<int>();

    /// <summary>Starting line number (default: 1)</summary>
    public int StartLineNumber { get; set; } = 1;

    /// <summary>Maximum height of the code block</summary>
    public string? MaxHeight { get; set; }

    /// <summary>Enable word wrap</summary>
    public bool WordWrap { get; set; } = false;

    /// <summary>Custom CSS classes</summary>
    public List<string> CssClasses { get; set; } = new List<string>();

    /// <summary>Initializes a new PrismJS code block</summary>
    public PrismJsCodeBlock()
    {

    }

    /// <summary>Initializes a new PrismJS code block with code content</summary>
    public PrismJsCodeBlock(string code, PrismJsLanguage language = PrismJsLanguage.None)
    {
        Code = code;
        Language = language;
    }

    #region Fluent API Methods

    /// <summary>Set the programming language for syntax highlighting</summary>
    public PrismJsCodeBlock SetLanguage(PrismJsLanguage language)
    {
        Language = language;
        return this;
    }

    /// <summary>Set the theme for syntax highlighting</summary>
    public PrismJsCodeBlock SetTheme(PrismJsTheme theme)
    {
        Theme = theme;
        return this;
    }

    /// <summary>Set the code content</summary>
    public PrismJsCodeBlock SetCode(string code)
    {
        Code = code;
        return this;
    }

    /// <summary>Set a title/caption for the code block</summary>
    public PrismJsCodeBlock SetTitle(string title)
    {
        Title = title;
        return this;
    }

    /// <summary>Enable or disable line numbers</summary>
    public PrismJsCodeBlock EnableLineNumbers(bool enable = true)
    {
        ShowLineNumbers = enable;
        return this;
    }

    /// <summary>Enable or disable copy to clipboard button</summary>
    public PrismJsCodeBlock EnableCopyButton(bool enable = true)
    {
        ShowCopyButton = enable;
        return this;
    }

    /// <summary>Highlight specific lines (1-based line numbers)</summary>
    public PrismJsCodeBlock HighlightLine(params int[] lineNumbers)
    {
        HighlightLines.AddRange(lineNumbers);
        return this;
    }

    /// <summary>Set the starting line number</summary>
    public PrismJsCodeBlock SetStartLineNumber(int startLine)
    {
        StartLineNumber = startLine;
        return this;
    }

    /// <summary>Set maximum height with scrolling</summary>
    public PrismJsCodeBlock SetMaxHeight(string height)
    {
        MaxHeight = height;
        return this;
    }

    /// <summary>Enable word wrapping</summary>
    public PrismJsCodeBlock EnableWordWrap(bool enable = true)
    {
        WordWrap = enable;
        return this;
    }

    /// <summary>Add custom CSS classes</summary>
    public PrismJsCodeBlock AddCssClass(params string[] classes)
    {
        CssClasses.AddRange(classes);
        return this;
    }

    #endregion

    #region Language-Specific Convenience Methods

    /// <summary>Set language to C#</summary>
    public PrismJsCodeBlock CSharp() => SetLanguage(PrismJsLanguage.CSharp);

    /// <summary>Set language to JavaScript</summary>
    public PrismJsCodeBlock JavaScript() => SetLanguage(PrismJsLanguage.JavaScript);

    /// <summary>Set language to TypeScript</summary>
    public PrismJsCodeBlock TypeScript() => SetLanguage(PrismJsLanguage.TypeScript);

    /// <summary>Set language to HTML</summary>
    public PrismJsCodeBlock Html() => SetLanguage(PrismJsLanguage.Html);

    /// <summary>Set language to CSS</summary>
    public PrismJsCodeBlock Css() => SetLanguage(PrismJsLanguage.Css);

    /// <summary>Set language to JSON</summary>
    public PrismJsCodeBlock Json() => SetLanguage(PrismJsLanguage.Json);

    /// <summary>Set language to SQL</summary>
    public PrismJsCodeBlock Sql() => SetLanguage(PrismJsLanguage.Sql);

    /// <summary>Set language to Python</summary>
    public PrismJsCodeBlock Python() => SetLanguage(PrismJsLanguage.Python);

    /// <summary>Set language to Java</summary>
    public PrismJsCodeBlock Java() => SetLanguage(PrismJsLanguage.Java);

    /// <summary>Set language to PHP</summary>
    public PrismJsCodeBlock Php() => SetLanguage(PrismJsLanguage.Php);

    /// <summary>Set language to Bash</summary>
    public PrismJsCodeBlock Bash() => SetLanguage(PrismJsLanguage.Bash);

    /// <summary>Set language to PowerShell</summary>
    public PrismJsCodeBlock PowerShell() => SetLanguage(PrismJsLanguage.PowerShell);

    #endregion

    #region Theme Convenience Methods

    /// <summary>Use dark theme</summary>
    public PrismJsCodeBlock DarkTheme() => SetTheme(PrismJsTheme.Dark);

    /// <summary>Use Okaidia theme (popular dark theme)</summary>
    public PrismJsCodeBlock OkaidiaTheme() => SetTheme(PrismJsTheme.Okaidia);

    /// <summary>Use Tomorrow Night theme</summary>
    public PrismJsCodeBlock TomorrowNightTheme() => SetTheme(PrismJsTheme.TomorrowNight);

    /// <summary>Use GitHub theme</summary>
    public PrismJsCodeBlock GitHubTheme() => SetTheme(PrismJsTheme.GitHub);

    /// <summary>Use VS theme (Visual Studio)</summary>
    public PrismJsCodeBlock VsTheme() => SetTheme(PrismJsTheme.Vs);

    #endregion

    #region Library Registration

    /// <summary>Registers the PrismJS library and theme-specific resources</summary>
    protected internal override void RegisterLibraries()
    {
        // Register base PrismJS library
        Document?.Configuration.Libraries.TryAdd(Libraries.PrismJs, 0);

        // Register theme-specific library if not default
        if (Theme != PrismJsTheme.Default)
        {
            RegisterThemeLibrary();
        }
        
        // Debug output
        if (Document == null)
        {
            Console.WriteLine("ERROR: PrismJS element has no Document reference!");
        }
        else
        {
            Console.WriteLine($"SUCCESS: PrismJS registered: Base={Document.Configuration.Libraries.ContainsKey(Libraries.PrismJs)}, Theme={Theme}");
        }
    }

    /// <summary>Registers theme-specific library resources</summary>
    private void RegisterThemeLibrary()
    {
        var themeLibrary = GetThemeLibrary();
        if (themeLibrary.HasValue)
        {
            Document?.Configuration.Libraries.TryAdd(themeLibrary.Value, 0);
        }
    }

    /// <summary>Gets the appropriate theme library enum for the current theme</summary>
    private Libraries? GetThemeLibrary()
    {
        return Theme switch
        {
            PrismJsTheme.Dark => Libraries.PrismJsDarkTheme,
            PrismJsTheme.Okaidia => Libraries.PrismJsOkaidiaTheme,
            PrismJsTheme.GitHub => Libraries.PrismJsGitHubTheme,
            PrismJsTheme.TomorrowNight => Libraries.PrismJsTomorrowNightTheme,
            PrismJsTheme.Vs => Libraries.PrismJsVsTheme,
            // Add more themes as needed
            _ => null
        };
    }



    #endregion

    #region Build Methods

    /// <summary>Builds the HTML for the PrismJS code block</summary>
    public override string ToString()
    {
        var html = new StringBuilder();

        // Build wrapper div
        html.AppendLine("<div class=\"prism-code-block\">");

        // Add title if specified
        if (!string.IsNullOrEmpty(Title))
        {
            html.AppendLine($"<div class=\"code-title\">{Title}</div>");
        }

        // Build CSS classes
        var cssClasses = new List<string>();

        if (ShowLineNumbers)
        {
            cssClasses.Add("line-numbers");
        }

        if (WordWrap)
        {
            cssClasses.Add("wrap");
        }

        cssClasses.AddRange(CssClasses);

        var classAttribute = cssClasses.Any() ? $" class=\"{string.Join(" ", cssClasses)}\"" : "";

        // Build data attributes
        var dataAttributes = new List<string>();

        if (HighlightLines.Any())
        {
            var highlightData = string.Join(",", HighlightLines);
            dataAttributes.Add($"data-line=\"{highlightData}\"");
        }

        if (ShowLineNumbers && StartLineNumber != 1)
        {
            dataAttributes.Add($"data-start=\"{StartLineNumber}\"");
        }

        if (ShowCopyButton)
        {
            dataAttributes.Add("data-prismjs-copy=\"Copy\"");
        }

        var dataAttributeString = dataAttributes.Any() ? " " + string.Join(" ", dataAttributes) : "";

        // Build style attribute
        var styles = new List<string>();
        if (!string.IsNullOrEmpty(MaxHeight))
        {
            styles.Add($"max-height: {MaxHeight}");
            styles.Add("overflow-y: auto");
        }

        var styleAttribute = styles.Any() ? $" style=\"{string.Join("; ", styles)}\"" : "";

        // Get language class
        var languageClass = GetLanguageClass();

        // Build the pre and code elements
        html.AppendLine($"<pre{classAttribute}{dataAttributeString}{styleAttribute}>");
        html.AppendLine($"<code class=\"{languageClass}\">{EscapeHtml(Code)}</code>");
        html.AppendLine("</pre>");

        html.AppendLine("</div>");

        return html.ToString();
    }

    /// <summary>Gets the CSS class for the specified language</summary>
    private string GetLanguageClass()
    {
        return Language switch
        {
            PrismJsLanguage.Html => "language-html",
            PrismJsLanguage.Css => "language-css",
            PrismJsLanguage.JavaScript => "language-javascript",
            PrismJsLanguage.TypeScript => "language-typescript",
            PrismJsLanguage.CSharp => "language-csharp",
            PrismJsLanguage.C => "language-c",
            PrismJsLanguage.Cpp => "language-cpp",
            PrismJsLanguage.Java => "language-java",
            PrismJsLanguage.Python => "language-python",
            PrismJsLanguage.Php => "language-php",
            PrismJsLanguage.Ruby => "language-ruby",
            PrismJsLanguage.Go => "language-go",
            PrismJsLanguage.Rust => "language-rust",
            PrismJsLanguage.Swift => "language-swift",
            PrismJsLanguage.Kotlin => "language-kotlin",
            PrismJsLanguage.Sql => "language-sql",
            PrismJsLanguage.Json => "language-json",
            PrismJsLanguage.Xml => "language-xml",
            PrismJsLanguage.Yaml => "language-yaml",
            PrismJsLanguage.Markdown => "language-markdown",
            PrismJsLanguage.Bash => "language-bash",
            PrismJsLanguage.PowerShell => "language-powershell",
            PrismJsLanguage.Docker => "language-docker",
            PrismJsLanguage.Git => "language-git",
            PrismJsLanguage.Regex => "language-regex",
            PrismJsLanguage.GraphQL => "language-graphql",
            PrismJsLanguage.Scss => "language-scss",
            PrismJsLanguage.Less => "language-less",
            PrismJsLanguage.Jsx => "language-jsx",
            PrismJsLanguage.Tsx => "language-tsx",
            PrismJsLanguage.Vue => "language-vue",
            PrismJsLanguage.Angular => "language-typescript", // Angular uses TypeScript
            PrismJsLanguage.R => "language-r",
            PrismJsLanguage.Matlab => "language-matlab",
            PrismJsLanguage.Latex => "language-latex",
            _ => "language-none"
        };
    }

    /// <summary>Escapes HTML characters in code content</summary>
    private string EscapeHtml(string code)
    {
        return code
            .Replace("&", "&amp;")
            .Replace("<", "&lt;")
            .Replace(">", "&gt;")
            .Replace("\"", "&quot;")
            .Replace("'", "&#39;");
    }

    #endregion
}