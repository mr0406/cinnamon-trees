namespace CinnamonTrees.Visualizer.Mermaid;

public record DiagramConfiguration(string TrueLabel, string FalseLabel)
{
    public static DiagramConfiguration Default => new("Yes", "No");
}