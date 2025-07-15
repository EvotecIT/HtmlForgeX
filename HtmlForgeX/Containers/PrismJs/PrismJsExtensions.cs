namespace HtmlForgeX;

/// <summary>
/// Extension methods for adding PrismJS code blocks to pages and containers
/// </summary>
public static class PrismJsExtensions
{
    /// <summary>Add a PrismJS code block to the page</summary>
    public static T CodeBlock<T>(this T container, string code, Action<PrismJsCodeBlock>? configure = null)
        where T : Element
    {
        var codeBlock = new PrismJsCodeBlock(code);
        configure?.Invoke(codeBlock);
        container.Add(codeBlock);
        return container;
    }

    /// <summary>Add a PrismJS code block with specified language</summary>
    public static T CodeBlock<T>(this T container, string code, PrismJsLanguage language, Action<PrismJsCodeBlock>? configure = null)
        where T : Element
    {
        var codeBlock = new PrismJsCodeBlock(code, language);
        configure?.Invoke(codeBlock);
        container.Add(codeBlock);
        return container;
    }

    /// <summary>Add a C# code block</summary>
    public static T CSharpCode<T>(this T container, string code, Action<PrismJsCodeBlock>? configure = null)
        where T : Element
    {
        var codeBlock = new PrismJsCodeBlock(code, PrismJsLanguage.CSharp);
        configure?.Invoke(codeBlock);
        container.Add(codeBlock);
        return container;
    }

    /// <summary>Add a JavaScript code block</summary>
    public static T JavaScriptCode<T>(this T container, string code, Action<PrismJsCodeBlock>? configure = null)
        where T : Element
    {
        var codeBlock = new PrismJsCodeBlock(code, PrismJsLanguage.JavaScript);
        configure?.Invoke(codeBlock);
        container.Add(codeBlock);
        return container;
    }

    /// <summary>Add a TypeScript code block</summary>
    public static T TypeScriptCode<T>(this T container, string code, Action<PrismJsCodeBlock>? configure = null)
        where T : Element
    {
        var codeBlock = new PrismJsCodeBlock(code, PrismJsLanguage.TypeScript);
        configure?.Invoke(codeBlock);
        container.Add(codeBlock);
        return container;
    }

    /// <summary>Add an HTML code block</summary>
    public static T HtmlCode<T>(this T container, string code, Action<PrismJsCodeBlock>? configure = null)
        where T : Element
    {
        var codeBlock = new PrismJsCodeBlock(code, PrismJsLanguage.Html);
        configure?.Invoke(codeBlock);
        container.Add(codeBlock);
        return container;
    }

    /// <summary>Add a CSS code block</summary>
    public static T CssCode<T>(this T container, string code, Action<PrismJsCodeBlock>? configure = null)
        where T : Element
    {
        var codeBlock = new PrismJsCodeBlock(code, PrismJsLanguage.Css);
        configure?.Invoke(codeBlock);
        container.Add(codeBlock);
        return container;
    }

    /// <summary>Add a JSON code block</summary>
    public static T JsonCode<T>(this T container, string code, Action<PrismJsCodeBlock>? configure = null)
        where T : Element
    {
        var codeBlock = new PrismJsCodeBlock(code, PrismJsLanguage.Json);
        configure?.Invoke(codeBlock);
        container.Add(codeBlock);
        return container;
    }

    /// <summary>Add a SQL code block</summary>
    public static T SqlCode<T>(this T container, string code, Action<PrismJsCodeBlock>? configure = null)
        where T : Element
    {
        var codeBlock = new PrismJsCodeBlock(code, PrismJsLanguage.Sql);
        configure?.Invoke(codeBlock);
        container.Add(codeBlock);
        return container;
    }

    /// <summary>Add a Python code block</summary>
    public static T PythonCode<T>(this T container, string code, Action<PrismJsCodeBlock>? configure = null)
        where T : Element
    {
        var codeBlock = new PrismJsCodeBlock(code, PrismJsLanguage.Python);
        configure?.Invoke(codeBlock);
        container.Add(codeBlock);
        return container;
    }

    /// <summary>Add a Bash code block</summary>
    public static T BashCode<T>(this T container, string code, Action<PrismJsCodeBlock>? configure = null)
        where T : Element
    {
        var codeBlock = new PrismJsCodeBlock(code, PrismJsLanguage.Bash);
        configure?.Invoke(codeBlock);
        container.Add(codeBlock);
        return container;
    }

    /// <summary>Add a PowerShell code block</summary>
    public static T PowerShellCode<T>(this T container, string code, Action<PrismJsCodeBlock>? configure = null)
        where T : Element
    {
        var codeBlock = new PrismJsCodeBlock(code, PrismJsLanguage.PowerShell);
        configure?.Invoke(codeBlock);
        container.Add(codeBlock);
        return container;
    }
}