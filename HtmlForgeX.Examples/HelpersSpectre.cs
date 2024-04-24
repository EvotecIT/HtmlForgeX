using Spectre.Console;

namespace HtmlForgeX.Examples;

internal static class HelpersSpectre {
    public static void PrintTitle(string title) {
        AnsiConsole.MarkupLine($"[bold yellow]{title}[/]");
        AnsiConsole.WriteLine();
    }

    public static void PrintHtmlTag(HtmlTag tag) {
        var markup = Markup.Escape(tag.ToString());
        AnsiConsole.MarkupLine($"[green]{markup}[/]");
    }

    public static void PrintHtmlTag(string title, Element tag) {
        AnsiConsole.MarkupLine($"[bold yellow]{title}[/]");
        AnsiConsole.WriteLine();
        var markup = Markup.Escape(tag.ToString());
        AnsiConsole.MarkupLine($"[green]{markup}[/]");
    }

    public static void PrintException(Exception ex) {
        AnsiConsole.WriteException(ex);
    }
}
