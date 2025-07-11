using System;

namespace HtmlForgeX.Examples.Containers;

internal class MermaidDiagramExample {
    public static void Create(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("Mermaid Diagrams");

        var document = new Document {
            Head = { Title = "Mermaid Diagrams", Author = "HtmlForgeX" },
            LibraryMode = LibraryMode.Online,
            ThemeMode = ThemeMode.Light
        };

        document.Body.Page(page => {
            page.DiagramMermaid(diagram => {
                diagram.SetType(MermaidDiagramType.SequenceDiagram);
                diagram.AddLink("Alice", "Bob", "Hello Bob");
                diagram.AddLink("Bob", "Alice", "Hi Alice");
            });

            page.DiagramMermaid(diagram => {
                diagram.SetType(MermaidDiagramType.Flowchart, MermaidFlowDirection.LeftRight);
                diagram.AddNode("A", "Start");
                diagram.AddNode("B", "Is it?");
                diagram.AddNode("C", "OK");
                diagram.AddNode("D", "Alert");
                diagram.AddLink("A", "B");
                diagram.AddLink("B", "C", "Yes");
                diagram.AddLink("B", "D", "No");
            });

            page.DiagramMermaid(@"gantt
dateFormat  YYYY-MM-DD
title Adding GANTT diagram to mermaid
excludes weekdays 2014-01-10

section A section
Completed task            :done,    des1, 2014-01-06,2014-01-08
Active task               :active,  des2, 2014-01-09, 3d
Future task               :         des3, after des2, 5d
Future task2              :         des4, after des3, 5d");
        });

        var path = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "mermaid_example.html");
        document.Save(path, openInBrowser);
    }
}
