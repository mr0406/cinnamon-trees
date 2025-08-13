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

        [Test]
        public void RenderDiagramWithPathHighlight_WithDefaultHighlightStyle_ShouldMatchSnapshot()
        {
            // Given
            var snapshotPath = "MermaidVisualization/Snapshots/tree_with_trace.mmd";
            
            var tree = DiscountTreeBuilder.Build();
            var diagram = MermaidVisualizeTree.VisualizeTree(tree);
            var decisionHistory = new List<int> { 1, 1 };

            // When
            var diagramWithTrace = MermaidVisualizeTree.VisualizeTreeWithTrace(diagram, decisionHistory, null, TraceHighlightStyle.Default);

            // Then
            var expectedDiagramWithTrace = File.ReadAllText(snapshotPath);
        
            diagramWithTrace.ShouldBe(expectedDiagramWithTrace);
        }

        [Test]
        public void RenderDiagramWithPathHighlight_WithCustomHighlightStyle_ShouldContainCustomStyles()
        {
            // Given
            var tree = DiscountTreeBuilder.Build();
            var diagram = MermaidVisualizeTree.VisualizeTree(tree);
            var decisionHistory = new List<int> { 1, 1 };
            var customHighlightStyle = new TraceHighlightStyle(
                HighlightStyle: new StyleProperties(Fill: "#ff0000", StrokeWidth: "3px", Color: "#fff"),
                InputNodeStyle: new StyleProperties(Fill: "#0000ff", StrokeWidth: "3px", Color: "#fff"));

            // When
            var diagramWithTrace = MermaidVisualizeTree.VisualizeTreeWithTrace(diagram, decisionHistory, null, customHighlightStyle);

            // Then
            diagramWithTrace.ShouldContain("classDef highlight fill:#ff0000,stroke-width:3px,color:#fff;");
        }

        [Test]
        public void RenderDiagramWithPathHighlight_WithCustomInputStyle_ShouldContainCustomInputStyle()
        {
            // Given
            var tree = DiscountTreeBuilder.Build();
            var diagram = MermaidVisualizeTree.VisualizeTree(tree);
            var decisionHistory = new List<int> { 1, 1 };
            var input = new DiscountInput(OrderValue: 300, Status: CustomerStatus.Loyal);
            var customHighlightStyle = new TraceHighlightStyle(
                InputNodeStyle: new StyleProperties(Fill: "#0000ff", StrokeWidth: "3px", Color: "#fff"));

            // When
            var diagramWithTrace = MermaidVisualizeTree.VisualizeTreeWithTrace(diagram, decisionHistory, input, customHighlightStyle);

            // Then
            diagramWithTrace.ShouldContain("style NInput fill:#0000ff,stroke-width:3px,color:#fff;");
        }
    }
}