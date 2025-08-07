using System.Text;
using CinnamonTrees.Visualizer.Mermaid.Internal;

namespace CinnamonTrees.Visualizer.Mermaid;

public static class MermaidVisualizeTree
{
    public static string VisualizeTree<TInput, TResult>(BaseNode<TInput, TResult> root)
        where TResult : Enum
        where TInput : class
    {
        return new DiagramRenderer<TInput, TResult>().GenerateDiagram(root);
    }

    public static string VisualizeTreeWithTrace(string diagram, List<int> decisionHistory, object? input = null)
    {
        return TraceRenderer.RenderTrace(diagram, decisionHistory, input);
    }
}