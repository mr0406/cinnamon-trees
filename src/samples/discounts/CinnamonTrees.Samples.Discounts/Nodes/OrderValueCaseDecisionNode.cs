namespace CinnamonTrees.Samples.Discounts.Nodes;

public class OrderValueCaseDecisionNode(
    BaseNode<DiscountInput, DiscountType> greaterThan500Node,
    BaseNode<DiscountInput, DiscountType> greaterThan200Node,
    BaseNode<DiscountInput, DiscountType> defaultNode)
    : CaseDecisionBaseNode<DiscountInput, DiscountType>(
        case1: GreaterThan500Case(greaterThan500Node),
        case2: GreaterThan200Case(greaterThan200Node),
        defaultNode: defaultNode)
{
    public override string Description => "Check order value";
    
    private static CaseBranch<DiscountInput, DiscountType> GreaterThan500Case(
        BaseNode<DiscountInput, DiscountType> node) =>
        new(
            Condition: input => input.OrderValue > 500,
            Node: node,
            Description: "OrderValue > 500"
        );

    private static CaseBranch<DiscountInput, DiscountType> GreaterThan200Case(
        BaseNode<DiscountInput, DiscountType> node) =>
        new(
            Condition: input => input.OrderValue > 200,
            Node: node,
            Description: "OrderValue > 200"
        );
}