using CinnamonTrees.Samples.Discounts.Nodes;

namespace CinnamonTrees.Samples.Discounts;

public static class DiscountTreeBuilder
{
    public static DecisionTree<DiscountInput, DiscountType> Build()
    {
        var bigDiscountLeafNode = new LeafNode<DiscountInput, DiscountType>(
            DiscountType.BigDiscount, "Big discount");

        var smallDiscountLeafNode = new LeafNode<DiscountInput, DiscountType>(
            DiscountType.SmallDiscount, "Small discount");

        var noDiscountLeafNode = new LeafNode<DiscountInput, DiscountType>(
            DiscountType.NoDiscount, "No discount");
        
        var orderValueCaseDecisionNode = new OrderValueCaseDecisionNode(
            greaterThan500Node: bigDiscountLeafNode,
            greaterThan200Node: smallDiscountLeafNode,
            defaultNode: noDiscountLeafNode
        );
        
        var rootNode = new CustomerIsLoyalBinaryDecisionNode(
            trueNode: orderValueCaseDecisionNode,
            falseNode: noDiscountLeafNode
        );

        return new DecisionTree<DiscountInput, DiscountType>(rootNode);
    }
}