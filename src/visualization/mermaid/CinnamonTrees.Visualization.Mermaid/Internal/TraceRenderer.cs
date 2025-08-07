using System.Text;
using System.Text.Json;

namespace CinnamonTrees.Visualizer.Mermaid.Internal;

internal static class TraceRenderer
{
    internal static string RenderTrace(string diagram, List<int> decisionHistory, object? input)
    {
        var sb = new StringBuilder();
        sb.AppendLine(diagram.Trim());
        sb.AppendLine();

        sb.AppendLine("classDef highlight fill:#013300,stroke-width:2px,color:#fff;");

        if (input != null)
        {
            var inputStr = JsonSerializer.Serialize(input, new JsonSerializerOptions { WriteIndented = true });
            inputStr = inputStr.Replace("\n", "<br>");
            inputStr = inputStr.Replace("\"", "&quot;");
                
            var rootNodeId = NodeIdHelper.RootNodeId;
            var inputNodeId = "NInput";
                
            sb.AppendLine($"{inputNodeId}[\"Input:<br><div style='text-align:left; font-size:0.8em; white-space:pre-wrap;'>{inputStr}</div>\"]");
            sb.AppendLine($"{inputNodeId} --> {rootNodeId}");
            sb.AppendLine($"style {inputNodeId} fill:#013366,stroke-width:2px,color:#fff;");
        }

        var pathNodes = NodeIdHelper.GetNodesOnPath(decisionHistory);
        sb.AppendLine($"class {string.Join(",", pathNodes)} highlight;");

        return sb.ToString();
    }
}