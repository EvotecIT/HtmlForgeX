using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HtmlForgeX.Examples.Experimenting;

internal static class ExampleThreadSafeErrors {
    public static void Create() {
        using var document = new Document();
        var tasks = new List<Task>();
        for (int i = 0; i < 5; i++) {
            int copy = i;
            tasks.Add(Task.Run(() => document.Configuration.Errors.Add($"error {copy}")));
        }
        Task.WaitAll(tasks.ToArray());
        HelpersSpectre.Success($"Total errors: {document.Configuration.Errors.Count}");
    }
}