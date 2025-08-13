namespace CinnamonTrees.Visualizer.Mermaid;

/// <summary>
/// Defines individual CSS style properties that can be applied to diagram elements.
/// </summary>
/// <param name="Fill">Fill color (e.g., "#f9f", "#013300")</param>
/// <param name="Stroke">Stroke color (e.g., "#333", "#000")</param>
/// <param name="StrokeWidth">Stroke width (e.g., "2px", "3px")</param>
/// <param name="Color">Text color (e.g., "#fff", "#000")</param>
public record StyleProperties(
    string? Fill = null,
    string? Stroke = null,
    string? StrokeWidth = null,
    string? Color = null)
{
    /// <summary>
    /// Converts the style properties to a CSS string.
    /// </summary>
    /// <returns>CSS string representation of the properties</returns>
    public string ToCssString()
    {
        var properties = new List<string>();
        
        if (!string.IsNullOrEmpty(Fill))
            properties.Add($"fill:{Fill}");
            
        if (!string.IsNullOrEmpty(Stroke))
            properties.Add($"stroke:{Stroke}");
            
        if (!string.IsNullOrEmpty(StrokeWidth))
            properties.Add($"stroke-width:{StrokeWidth}");
            
        if (!string.IsNullOrEmpty(Color))
            properties.Add($"color:{Color}");
            
        return string.Join(",", properties);
    }
}