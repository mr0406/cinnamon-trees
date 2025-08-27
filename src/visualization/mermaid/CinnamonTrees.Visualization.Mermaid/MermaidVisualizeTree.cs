using CinnamonTrees.Visualizer.Mermaid.Internal;

namespace CinnamonTrees.Visualizer.Mermaid;

public static class MermaidVisualizeTree
{
    public static string VisualizeTree<TInput, TResult>(
        DecisionTree<TInput, TResult> tree,
        DiagramConfiguration? configuration = null,
        DiagramStyle? style = null)
        where TResult : Enum
        where TInput : class
    {
        configuration ??= DiagramConfiguration.Default;
        style ??= new DiagramStyle();
        
        return new DiagramRenderer<TInput, TResult>().GenerateDiagram(tree, configuration, style);
    }

    public static string VisualizeTreeWithTrace(string diagram, List<int> decisionHistory, string? input = null, HighlightStyle? highlightStyle = null)
    {
        highlightStyle ??= new HighlightStyle();
        
        return TraceRenderer.RenderTrace(diagram, decisionHistory, input, highlightStyle);
    }
}