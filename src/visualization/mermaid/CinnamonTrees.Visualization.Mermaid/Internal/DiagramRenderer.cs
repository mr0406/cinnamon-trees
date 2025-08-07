using System.Text;

namespace CinnamonTrees.Visualizer.Mermaid.Internal;

internal class DiagramRenderer<TInput, TResult>
    where TResult : Enum
    where TInput : class
{
    private readonly StringBuilder _sb = new();

    internal string GenerateDiagram(BaseNode<TInput, TResult> root)
    {
        _sb.Clear();
        _sb.AppendLine("graph TD");
        VisitNode(root, "N1");
        return _sb.ToString();
    }

    private void VisitNode(BaseNode<TInput, TResult> node, string nodeId)
    {
        switch (node)
        {
            case BinaryDecisionBaseNode<TInput, TResult> binaryNode:
                RenderBinaryNode(binaryNode, nodeId);
                break;

            case CaseDecisionBaseNode<TInput, TResult> caseNode:
                RenderCaseNode(caseNode, nodeId);
                break;

            case LeafNode<TInput, TResult> leafNode:
                RenderLeafNode(leafNode, nodeId);
                break;

            default:
                throw new InvalidOperationException("Unknown node type");
        }
    }

    private void RenderBinaryNode(BinaryDecisionBaseNode<TInput, TResult> decisionBaseNode, string nodeId)
    {
        _sb.AppendLine($"{nodeId}{{\"{Escape(decisionBaseNode.Description)}\"}}");

        var trueId = NodeIdHelper.GetChildNodeId(nodeId, 1);
        _sb.AppendLine($"{nodeId} -->|Yes| {trueId}");
        VisitNode(decisionBaseNode.TrueNode, trueId);

        var falseId = NodeIdHelper.GetChildNodeId(nodeId, 0);
        _sb.AppendLine($"{nodeId} -->|No| {falseId}");
        VisitNode(decisionBaseNode.FalseNode, falseId);
    }

    private void RenderCaseNode(CaseDecisionBaseNode<TInput, TResult> decisionBaseNode, string nodeId)
    {
        _sb.AppendLine($"{nodeId}{{\"{Escape(decisionBaseNode.Description)}\"}}");

        for (var i = 0; i < decisionBaseNode.Cases.Count; i++)
        {
            var childId = NodeIdHelper.GetChildNodeId(nodeId, i + 1);
            var label = Escape(decisionBaseNode.CaseDescriptions[i]);
            _sb.AppendLine($"{nodeId} -->|{label}| {childId}");
            VisitNode(decisionBaseNode.Cases[i], childId);
        }

        var defaultId = NodeIdHelper.GetChildNodeId(nodeId, 0);
        _sb.AppendLine($"{nodeId} -->|Default| {defaultId}");
        VisitNode(decisionBaseNode.Default, defaultId);
    }

    private void RenderLeafNode(LeafNode<TInput, TResult> leafNode, string nodeId)
    {
        var label = leafNode.Description;
        _sb.AppendLine($"{nodeId}[\"{Escape(label)}\"]");
    }

    private static string Escape(string input) => input.Replace("\"", "\\\"");
}