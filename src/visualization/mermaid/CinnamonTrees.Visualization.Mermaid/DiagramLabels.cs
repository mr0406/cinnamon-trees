namespace CinnamonTrees.Visualizer.Mermaid;

/// <summary>
/// Defines the labels used for decision tree visualization in Mermaid diagrams.
/// </summary>
/// <param name="TrueLabel">Label to display for 'true' branches (default: "Yes")</param>
/// <param name="FalseLabel">Label to display for 'false' branches (default: "No")</param>
public record DiagramLabels(string TrueLabel = DiagramLabels.DefaultTrueLabel, string FalseLabel = DiagramLabels.DefaultFalseLabel)
{
    /// <summary>
    /// Default label for 'true' branches.
    /// </summary>
    public const string DefaultTrueLabel = "Yes";
    
    /// <summary>
    /// Default label for 'false' branches.
    /// </summary>
    public const string DefaultFalseLabel = "No";
    
    /// <summary>
    /// Default diagram labels configuration.
    /// </summary>
    public static DiagramLabels Default => new();
}