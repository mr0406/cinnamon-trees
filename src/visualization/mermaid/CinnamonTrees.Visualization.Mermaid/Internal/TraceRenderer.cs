using System.Text;

namespace CinnamonTrees.Visualizer.Mermaid.Internal;

internal static class TraceRenderer
{
    internal static string RenderTrace(string diagram, List<int> decisionHistory, string? input, HighlightStyle highlightStyle)
    {
        var sb = new StringBuilder();
        sb.AppendLine(diagram.Trim());
        sb.AppendLine();

        sb.AppendLine($"classDef highlight fill:{highlightStyle.Fill},stroke:{highlightStyle.Stroke},color:{highlightStyle.Color};");

        if (!string.IsNullOrEmpty(input))
        {
            var inputStr = input.Replace("\n", "<br>");
                
            var rootNodeId = NodeIdHelper.RootNodeId;
            var inputNodeId = "NInput";
                
            sb.AppendLine($"{inputNodeId}[\"{inputStr}\"]");
            sb.AppendLine($"{inputNodeId} --> {rootNodeId}");
        }

        var pathNodes = NodeIdHelper.GetNodesOnPath(decisionHistory);
        var allHighlightNodes = !string.IsNullOrEmpty(input) ? $"NInput,{string.Join(",", pathNodes)}" : string.Join(",", pathNodes);
        sb.AppendLine($"class {allHighlightNodes} highlight;");

        return sb.ToString();
    }
}