using System.Text;

namespace CinnamonTrees.Visualizer.Mermaid.Internal;

internal class DiagramRenderer<TInput, TResult>
    where TResult : Enum
    where TInput : class
{
    private readonly StringBuilder _sb = new();

    internal string GenerateDiagram(DecisionTree<TInput, TResult> tree, DiagramConfiguration configuration)
    {
        _sb.Clear();
        _sb.AppendLine("graph TD");
        VisitNode(tree.Root, "N1", configuration.TrueLabel, configuration.FalseLabel);
        return _sb.ToString();
    }

    private void VisitNode(
        BaseNode<TInput, TResult> node, 
        string nodeId,
        string trueLabel,
        string falseLabel)
    {
        switch (node)
        {
            case BinaryDecisionBaseNode<TInput, TResult> binaryNode:
                RenderBinaryNode(binaryNode, nodeId, trueLabel, falseLabel);
                break;

            case CaseDecisionBaseNode<TInput, TResult> caseNode:
                RenderCaseNode(caseNode, nodeId, trueLabel, falseLabel);
                break;

            case LeafNode<TInput, TResult> leafNode:
                RenderLeafNode(leafNode, nodeId);
                break;

            default:
                throw new InvalidOperationException("Unknown node type");
        }
    }

    private void RenderBinaryNode(
        BinaryDecisionBaseNode<TInput, TResult> decisionBaseNode, 
        string nodeId,
        string trueLabel,
        string falseLabel)
    {
        _sb.AppendLine($"{nodeId}{{\"{Escape(decisionBaseNode.Description)}\"}}");

        var trueId = NodeIdHelper.GetChildNodeId(nodeId, 1);
        _sb.AppendLine($"{nodeId} -->|{trueLabel}| {trueId}");
        VisitNode(decisionBaseNode.TrueNode, trueId, trueLabel, falseLabel);

        var falseId = NodeIdHelper.GetChildNodeId(nodeId, 0);
        _sb.AppendLine($"{nodeId} -->|{falseLabel}| {falseId}");
        VisitNode(decisionBaseNode.FalseNode, falseId, trueLabel, falseLabel);
    }

    private void RenderCaseNode(
        CaseDecisionBaseNode<TInput, TResult> decisionBaseNode, 
        string nodeId,
        string trueLabel,
        string falseLabel)
    {
        _sb.AppendLine($"{nodeId}{{\"{Escape(decisionBaseNode.Description)}\"}}");

        for (var i = 0; i < decisionBaseNode.Cases.Count; i++)
        {
            var childId = NodeIdHelper.GetChildNodeId(nodeId, i + 1);
            var label = Escape(decisionBaseNode.CaseDescriptions[i]);
            _sb.AppendLine($"{nodeId} -->|{label}| {childId}");
            VisitNode(decisionBaseNode.Cases[i], childId, trueLabel, falseLabel);
        }

        var defaultId = NodeIdHelper.GetChildNodeId(nodeId, 0);
        _sb.AppendLine($"{nodeId} -->|Default| {defaultId}");
        VisitNode(decisionBaseNode.Default, defaultId, trueLabel, falseLabel);
    }

    private void RenderLeafNode(LeafNode<TInput, TResult> leafNode, string nodeId)
    {
        var label = leafNode.Description;
        _sb.AppendLine($"{nodeId}[\"{Escape(label)}\"]");
    }

    private static string Escape(string input) => input.Replace("\"", "\\\"");
}