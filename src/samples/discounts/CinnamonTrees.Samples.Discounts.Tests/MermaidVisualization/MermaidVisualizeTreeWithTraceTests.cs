using CinnamonTrees.Visualizer.Mermaid;
using Shouldly;

namespace CinnamonTrees.Samples.Discounts.Tests.MermaidVisualization
{
    public class MermaidVisualizeTreeWithTraceTests
    {
        [Test]
        public void RenderDiagramWithPathHighlight_ShouldMarkCorrectNodes()
        {
            // Given
            var snapshotPath = "MermaidVisualization/Snapshots/tree_with_trace.mmd";
            
            var tree = DiscountTreeBuilder.Build();
            var diagram = MermaidVisualizeTree.VisualizeTree(tree);

            var decisionHistory = new List<int> { 1, 1 };

            // When
            var diagramWithTrace = MermaidVisualizeTree.VisualizeTreeWithTrace(diagram, decisionHistory);

            // Then
            var expectedDiagramWithTrace = File.ReadAllText(snapshotPath);
        
            diagramWithTrace.ShouldBe(expectedDiagramWithTrace);
        }
        
        [Test]
        public void RenderDiagramWithPathHighlight_WithInput_ShouldMarkCorrectNodes()
        {
            // Given
            var snapshotPath = "MermaidVisualization/Snapshots/tree_with_trace_with_input.mmd";
            
            var tree = DiscountTreeBuilder.Build();
            var diagram = MermaidVisualizeTree.VisualizeTree(tree);
            var input = new DiscountInput(OrderValue: 300, Status: CustomerStatus.Loyal);

            var decisionHistory = new List<int> { 1, 1 };

            // When
            var diagramWithTrace = MermaidVisualizeTree.VisualizeTreeWithTrace(diagram, decisionHistory, input);

            // Then
            var expectedDiagramWithTrace = File.ReadAllText(snapshotPath);
        
            diagramWithTrace.ShouldBe(expectedDiagramWithTrace);
        }
    }
}