using Spectre.Console;

namespace HtmlForgeX.Examples;

internal static class HelpersSpectre {
    public static void PrintTitle(string title) {
        var panel = new Panel(new Markup($"[bold yellow]{title}[/]")) {
            Border = BoxBorder.Double,
            Padding = new Padding(1, 0),
            Expand = true
        };
        AnsiConsole.Write(panel);
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

    public static void Success(string message) {
        var markup = Markup.Escape(message);
        AnsiConsole.MarkupLine($"[green]{markup}[/]");
    }

    public static void Info(string message) {
        var markup = Markup.Escape(message);
        AnsiConsole.MarkupLine(markup);
    }

    public static void Break() {
        AnsiConsole.WriteLine();
    }
}
