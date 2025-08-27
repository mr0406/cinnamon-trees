using System.Text;
using System.Text.Json;

namespace CinnamonTrees.Visualizer.Mermaid.Internal;

internal static class TraceRenderer
{
    internal static string RenderTrace(string diagram, List<int> decisionHistory, object? input, HighlightStyle? highlightStyle = null)
    {
        highlightStyle ??= new HighlightStyle();
        
        var sb = new StringBuilder();
        sb.AppendLine(diagram.Trim());
        sb.AppendLine();

        sb.AppendLine($"classDef highlight fill:{highlightStyle.Fill},stroke:{highlightStyle.Stroke},color:{highlightStyle.Color};");

        if (input != null)
        {
            var inputStr = JsonSerializer.Serialize(input, new JsonSerializerOptions { WriteIndented = true });
            inputStr = inputStr.Replace("\n", "<br>");
            inputStr = inputStr.Replace("\"", "&quot;");
                
            var rootNodeId = NodeIdHelper.RootNodeId;
            var inputNodeId = "NInput";
                
            sb.AppendLine($"{inputNodeId}[\"Input:<br><div style='text-align:left; font-size:0.8em; white-space:pre-wrap;'>{inputStr}</div>\"]");
            sb.AppendLine($"{inputNodeId} --> {rootNodeId}");
        }

        var pathNodes = NodeIdHelper.GetNodesOnPath(decisionHistory);
        var allHighlightNodes = input != null ? $"NInput,{string.Join(",", pathNodes)}" : string.Join(",", pathNodes);
        sb.AppendLine($"class {allHighlightNodes} highlight;");

        return sb.ToString();
    }
}