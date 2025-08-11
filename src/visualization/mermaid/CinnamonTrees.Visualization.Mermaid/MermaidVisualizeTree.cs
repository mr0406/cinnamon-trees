using CinnamonTrees.Visualizer.Mermaid.Internal;

namespace CinnamonTrees.Visualizer.Mermaid;

public static class MermaidVisualizeTree
{
    public static string VisualizeTree<TInput, TResult>(
        DecisionTree<TInput, TResult> tree,
        DiagramConfiguration? configuration = null)
        where TResult : Enum
        where TInput : class
    {
        configuration ??= DiagramConfiguration.Default;
        
        return new DiagramRenderer<TInput, TResult>().GenerateDiagram(tree, configuration);
    }

    public static string VisualizeTreeWithTrace(string diagram, List<int> decisionHistory, object? input = null)
    {
        return TraceRenderer.RenderTrace(diagram, decisionHistory, input);
    }
}