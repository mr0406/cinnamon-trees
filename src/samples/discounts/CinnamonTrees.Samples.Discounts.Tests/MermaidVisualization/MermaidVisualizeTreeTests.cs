using CinnamonTrees.Visualizer.Mermaid;
using Shouldly;

namespace CinnamonTrees.Samples.Discounts.Tests.MermaidVisualization;

public class MermaidVisualizeTreeTests
{
    [Test]
    public void MermaidDiagram_ShouldMatchSnapshot()
    {
        // Given
        var snapshotPath = "MermaidVisualization/Snapshots/tree.mmd";
        
        var tree = DiscountTreeBuilder.Build();
        
        // When
        var diagram = MermaidVisualizeTree.VisualizeTree(tree.Root);

        // Then
        var expectedDiagram = File.ReadAllText(snapshotPath);
        
        diagram.ShouldBe(expectedDiagram);
    }

}