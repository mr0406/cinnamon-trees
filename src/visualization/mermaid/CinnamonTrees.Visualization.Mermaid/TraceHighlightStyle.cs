namespace CinnamonTrees.Visualizer.Mermaid;

/// <summary>
/// Defines the styling options for trace highlighting in Mermaid diagrams.
/// </summary>
/// <param name="HighlightStyle">Style properties for highlighted path nodes (default: uses green highlight)</param>
/// <param name="InputNodeStyle">Style properties for input display node (default: uses blue style)</param>
public record TraceHighlightStyle(
    StyleProperties? HighlightStyle = null,
    StyleProperties? InputNodeStyle = null)
{
    /// <summary>
    /// Default style properties for highlighted path nodes.
    /// </summary>
    public static StyleProperties DefaultHighlightStyle => new(
        Fill: "#013300", 
        StrokeWidth: "2px", 
        Color: "#fff");
    
    /// <summary>
    /// Default style properties for input display node.
    /// </summary>
    public static StyleProperties DefaultInputNodeStyle => new(
        Fill: "#013366", 
        StrokeWidth: "2px", 
        Color: "#fff");
    
    /// <summary>
    /// Default trace highlight style configuration.
    /// </summary>
    public static TraceHighlightStyle Default => new(DefaultHighlightStyle, DefaultInputNodeStyle);
}