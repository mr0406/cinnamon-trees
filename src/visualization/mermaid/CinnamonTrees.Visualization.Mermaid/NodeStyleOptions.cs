namespace CinnamonTrees.Visualizer.Mermaid;

/// <summary>
/// Represents individual style properties for a Mermaid node or edge.
/// </summary>
public record NodeStyleOptions(
    string? Fill = null,
    string? Stroke = null,
    string? StrokeWidth = null,
    string? Color = null
)
{
    /// <summary>
    /// Converts the properties to Mermaid CSS style string.
    /// </summary>
    public override string ToString()
    {
        var parts = new List<string>();
        if (!string.IsNullOrEmpty(Fill))
        {
            parts.Add($"fill:{Fill}");
        }
        if (!string.IsNullOrEmpty(Stroke))
        {
            parts.Add($"stroke:{Stroke}");
        }
        if (!string.IsNullOrEmpty(StrokeWidth))
        {
            parts.Add($"stroke-width:{StrokeWidth}");
        }
        if (!string.IsNullOrEmpty(Color))
        {
            parts.Add($"color:{Color}");
        }
        return string.Join(",", parts);
    }
}