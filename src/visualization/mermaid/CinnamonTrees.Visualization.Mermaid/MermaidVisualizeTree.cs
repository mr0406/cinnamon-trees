using CinnamonTrees.Visualizer.Mermaid.Internal;

namespace CinnamonTrees.Visualizer.Mermaid;

public static class MermaidVisualizeTree
{
    /// <summary>
    /// Generates a Mermaid diagram for the decision tree with configurable labels and styling.
    /// </summary>
    /// <typeparam name="TInput">The input type for the decision tree</typeparam>
    /// <typeparam name="TResult">The result enum type for the decision tree</typeparam>
    /// <param name="tree">The decision tree to visualize</param>
    /// <param name="labels">Labels configuration (defaults to "Yes"/"No" if not provided)</param>
    /// <param name="style">Style configuration (uses Mermaid defaults if not provided)</param>
    /// <returns>A Mermaid diagram string</returns>
    public static string VisualizeTree<TInput, TResult>(
        DecisionTree<TInput, TResult> tree,
        DiagramLabels? labels = null,
        DiagramStyle? style = null)
        where TResult : Enum
        where TInput : class
    {
        labels ??= DiagramLabels.Default;
        style ??= DiagramStyle.Default;
        
        return new DiagramRenderer<TInput, TResult>().GenerateDiagram(tree, labels, style);
    }

    /// <summary>
    /// Backward compatibility method that accepts the legacy DiagramConfiguration.
    /// </summary>
    /// <typeparam name="TInput">The input type for the decision tree</typeparam>
    /// <typeparam name="TResult">The result enum type for the decision tree</typeparam>
    /// <param name="tree">The decision tree to visualize</param>
    /// <param name="configuration">Legacy configuration object</param>
    /// <returns>A Mermaid diagram string</returns>
    [Obsolete("Use VisualizeTree(tree, labels, style) instead. This method will be removed in a future version.")]
    public static string VisualizeTree<TInput, TResult>(
        DecisionTree<TInput, TResult> tree,
        DiagramConfiguration? configuration)
        where TResult : Enum
        where TInput : class
    {
        configuration ??= DiagramConfiguration.Default;
        var labels = new DiagramLabels(configuration.TrueLabel, configuration.FalseLabel);
        return VisualizeTree(tree, labels);
    }

    /// <summary>
    /// Adds trace highlighting to an existing diagram with configurable highlight styling.
    /// </summary>
    /// <param name="diagram">The base diagram to add trace highlighting to</param>
    /// <param name="decisionHistory">The decision path history to highlight</param>
    /// <param name="input">Optional input object to display</param>
    /// <param name="highlightStyle">Highlight style configuration (uses defaults if not provided)</param>
    /// <returns>A Mermaid diagram string with trace highlighting</returns>
    public static string VisualizeTreeWithTrace(
        string diagram, 
        List<int> decisionHistory, 
        object? input = null,
        TraceHighlightStyle? highlightStyle = null)
    {
        highlightStyle ??= TraceHighlightStyle.Default;
        return TraceRenderer.RenderTrace(diagram, decisionHistory, input, highlightStyle);
    }
}