namespace CinnamonTrees.Visualizer.Mermaid;

/// <summary>
/// Defines the styling options for trace highlighting in Mermaid diagrams.
/// </summary>
/// <param name="HighlightStyle">CSS style for highlighted path nodes (default: uses green highlight)</param>
/// <param name="InputNodeStyle">CSS style for input display node (default: uses blue style)</param>
public record TraceHighlightStyle(
    string HighlightStyle = TraceHighlightStyle.DefaultHighlightStyle,
    string InputNodeStyle = TraceHighlightStyle.DefaultInputNodeStyle)
{
    /// <summary>
    /// Default CSS style for highlighted path nodes.
    /// </summary>
    public const string DefaultHighlightStyle = "fill:#013300,stroke-width:2px,color:#fff";
    
    /// <summary>
    /// Default CSS style for input display node.
    /// </summary>
    public const string DefaultInputNodeStyle = "fill:#013366,stroke-width:2px,color:#fff";
    
    /// <summary>
    /// Default trace highlight style configuration.
    /// </summary>
    public static TraceHighlightStyle Default => new();
}