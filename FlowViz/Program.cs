// See https://aka.ms/new-console-template for more information
using FlowViz;
using FlowViz.FlowTypes;
using FlowViz.LpeTypes;
using System.IO;
using System.Reflection.Metadata;
using System.Text.Json;

// https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/program-structure/top-level-statements
//if (args.Length > 0)
//{
//    foreach (var arg in args)
//    {
//        Console.WriteLine($"Argument={arg}");
//    }
//}
//else
//{
//    Console.WriteLine("No arguments");
//}


FlowDocument? flowDocument = null;

string readText = File.ReadAllText(args[0]);

Root? root = JsonSerializer.Deserialize(readText, typeof(Root)) as Root;

if (root != null)
{
    flowDocument = LpeConverter.ToFlowDocument(root);
    string pub = FlowPublisher.Publish(flowDocument);

    string pub2 = HtmlGenerator.WrapMermaid(pub);

    File.WriteAllText(args[1], pub2);
}

