namespace CinnamonTrees.Visualizer.Mermaid;

/// <summary>
/// Defines the styling options for decision tree visualization in Mermaid diagrams.
/// </summary>
/// <param name="DecisionNodeStyle">Style properties for decision nodes (default: null for Mermaid default)</param>
/// <param name="LeafNodeStyle">Style properties for leaf nodes (default: null for Mermaid default)</param>
/// <param name="EdgeStyle">Style properties for edges/connections (default: null for Mermaid default)</param>
public record DiagramStyle(
    StyleProperties? DecisionNodeStyle = null,
    StyleProperties? LeafNodeStyle = null, 
    StyleProperties? EdgeStyle = null)
{
    /// <summary>
    /// Default diagram style configuration (uses Mermaid defaults).
    /// </summary>
    public static DiagramStyle Default => new();
}