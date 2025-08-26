namespace CinnamonTrees.Visualizer.Mermaid;

public record DiagramStyle(
    string Fill = Colors.DarkBlue, 
    string Color = Colors.White, 
    string Stroke = Colors.White);