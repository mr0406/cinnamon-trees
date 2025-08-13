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

    [Test]
    public void WhenRenderMermaidDiagram_WithDefaultLabels_ThenShouldMatchSnapshot()
    {
        // Given
        var snapshotPath = "MermaidVisualization/Snapshots/tree.mmd";
        
        var tree = DiscountTreeBuilder.Build();
        
        // When
        var diagram = MermaidVisualizeTree.VisualizeTree(tree, DiagramLabels.Default, DiagramStyle.Default);

        // Then
        var expectedDiagram = File.ReadAllText(snapshotPath);
        
        diagram.ShouldBe(expectedDiagram);
    }

    [Test]
    public void WhenRenderMermaidDiagram_WithCustomLabels_ThenShouldMatchSnapshot()
    {
        // Given
        var snapshotPath = "MermaidVisualization/Snapshots/tree_with_configuration.mmd";
        
        var tree = DiscountTreeBuilder.Build();
        
        // When
        var labels = new DiagramLabels("True", "False");
        var diagram = MermaidVisualizeTree.VisualizeTree(tree, labels, DiagramStyle.Default);

        // Then
        var expectedDiagram = File.ReadAllText(snapshotPath);
        
        diagram.ShouldBe(expectedDiagram);
    }

    [Test]
    public void WhenRenderMermaidDiagram_WithCustomStyle_ThenShouldContainStyleDefinitions()
    {
        // Given
        var tree = DiscountTreeBuilder.Build();
        var style = new DiagramStyle(
            DecisionNodeStyle: "fill:#f9f,stroke:#333,stroke-width:2px",
            LeafNodeStyle: "fill:#bbf,stroke:#333,stroke-width:2px");
        
        // When
        var diagram = MermaidVisualizeTree.VisualizeTree(tree, DiagramLabels.Default, style);

        // Then
        diagram.ShouldContain("classDef decisionNode fill:#f9f,stroke:#333,stroke-width:2px;");
        diagram.ShouldContain("classDef leafNode fill:#bbf,stroke:#333,stroke-width:2px;");
    }

    [Test]
    public void WhenRenderMermaidDiagram_WithNullStyle_ThenShouldNotContainStyleDefinitions()
    {
        // Given
        var tree = DiscountTreeBuilder.Build();
        
        // When
        var diagram = MermaidVisualizeTree.VisualizeTree(tree);

        // Then
        diagram.ShouldNotContain("classDef");
    }

    [Test]
    public void WhenRenderMermaidDiagram_WithPartialStyle_ThenShouldOnlyContainProvidedStyles()
    {
        // Given
        var tree = DiscountTreeBuilder.Build();
        var style = new DiagramStyle(DecisionNodeStyle: "fill:#f9f,stroke:#333,stroke-width:2px");
        
        // When
        var diagram = MermaidVisualizeTree.VisualizeTree(tree, DiagramLabels.Default, style);

        // Then
        diagram.ShouldContain("classDef decisionNode fill:#f9f,stroke:#333,stroke-width:2px;");
        diagram.ShouldNotContain("classDef leafNode");
        diagram.ShouldNotContain("linkStyle");
    }
}