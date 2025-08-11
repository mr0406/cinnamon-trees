using CinnamonTrees.Visualizer.Mermaid;
using Shouldly;

namespace CinnamonTrees.Samples.Discounts.Tests.MermaidVisualization;

public class MermaidVisualizeTreeTests
{
    [Test]
    public void WhenRenderMermaidDiagram_WithoutConfiguration_ThenShouldMatchSnapshot()
    {
        // Given
        var snapshotPath = "MermaidVisualization/Snapshots/tree.mmd";
        
        var tree = DiscountTreeBuilder.Build();
        
        // When
        var diagram = MermaidVisualizeTree.VisualizeTree(tree);

        // Then
        var expectedDiagram = File.ReadAllText(snapshotPath);
        
        diagram.ShouldBe(expectedDiagram);
    }
    
    [Test]
    public void WhenRenderMermaidDiagram_WithConfiguration_ThenShouldMatchSnapshot()
    {
        // Given
        var snapshotPath = "MermaidVisualization/Snapshots/tree_with_configuration.mmd";
        
        var tree = DiscountTreeBuilder.Build();
        
        // When
        var diagramConfiguration = new DiagramConfiguration(
            TrueLabel: "True", FalseLabel: "False");
        
        var diagram = MermaidVisualizeTree.VisualizeTree(tree, diagramConfiguration);

        // Then
        var expectedDiagram = File.ReadAllText(snapshotPath);
        
        diagram.ShouldBe(expectedDiagram);
    }
}