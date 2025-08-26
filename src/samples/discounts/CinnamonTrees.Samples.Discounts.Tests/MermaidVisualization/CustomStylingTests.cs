using CinnamonTrees.Visualizer.Mermaid;
using Shouldly;

namespace CinnamonTrees.Samples.Discounts.Tests.MermaidVisualization;

public class CustomStylingTests
{
    [Test]
    public void WhenRenderMermaidDiagram_WithCustomDiagramStyle_ThenShouldIncludeCustomColors()
    {
        var tree = DiscountTreeBuilder.Build();
        var customStyle = new DiagramStyle("#ff5722", "#ffffff", "#d84315");
        
        var diagram = MermaidVisualizeTree.VisualizeTree(tree, style: customStyle);
        
        diagram.ShouldContain("classDef default fill:#ff5722,stroke:#d84315,color:#ffffff;");
    }
    
    [Test]
    public void WhenRenderTraceWithCustomHighlightStyle_ThenShouldIncludeCustomHighlightColors()
    {
        var tree = DiscountTreeBuilder.Build();
        var diagram = MermaidVisualizeTree.VisualizeTree(tree);
        var customHighlightStyle = new HighlightStyle("#9c27b0", "#ffffff", "#7b1fa2");
        var decisionHistory = new List<int> { 1, 1 };
        
        var tracedDiagram = MermaidVisualizeTree.VisualizeTreeWithTrace(diagram, decisionHistory, highlightStyle: customHighlightStyle);
        
        tracedDiagram.ShouldContain("classDef highlight fill:#9c27b0,stroke:#7b1fa2,color:#ffffff;");
    }
}