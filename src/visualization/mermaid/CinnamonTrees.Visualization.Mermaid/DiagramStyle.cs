namespace CinnamonTrees.Visualizer.Mermaid;

/// <summary>
/// Defines the styling options for decision tree visualization in Mermaid diagrams.
/// </summary>
/// <param name="DecisionNodeStyle">CSS style for decision nodes (default: null for Mermaid default)</param>
/// <param name="LeafNodeStyle">CSS style for leaf nodes (default: null for Mermaid default)</param>
/// <param name="EdgeStyle">CSS style for edges/connections (default: null for Mermaid default)</param>
public record DiagramStyle(
    string? DecisionNodeStyle = null,
    string? LeafNodeStyle = null, 
    string? EdgeStyle = null)
{
    /// <summary>
    /// Default diagram style configuration (uses Mermaid defaults).
    /// </summary>
    public static DiagramStyle Default => new();
}