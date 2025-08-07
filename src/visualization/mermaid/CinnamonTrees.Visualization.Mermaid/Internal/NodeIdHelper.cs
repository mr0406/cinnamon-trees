namespace CinnamonTrees.Visualizer.Mermaid.Internal;

internal static class NodeIdHelper
{
    internal static string RootNodeId => "N1";
    
    internal static string GetChildNodeId(string parentId, int decision)
    {
        return parentId + decision;
    }
    
    internal static List<string> GetNodesOnPath(List<int> decisionHistory)
    {
        var pathNodes = new List<string> { RootNodeId };
        var currentId = RootNodeId;

        foreach (var decision in decisionHistory)
        {
            currentId = GetChildNodeId(currentId, decision);
            pathNodes.Add(currentId);
        }

        return pathNodes;
    }
}