namespace CinnamonTrees.Samples.Discounts.Nodes;

public class CustomerIsLoyalBinaryDecisionNode(
    BaseNode<DiscountInput, DiscountType> trueNode,
    BaseNode<DiscountInput, DiscountType> falseNode)
    : BinaryDecisionBaseNode<DiscountInput, DiscountType>(trueNode, falseNode)
{
    protected override Func<DiscountInput, bool> Predicate => input => input.Status == CustomerStatus.Loyal;

    public override string Description => "Customer is loyal?";
}