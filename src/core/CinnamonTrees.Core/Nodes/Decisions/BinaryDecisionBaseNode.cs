// ReSharper disable once CheckNamespace
namespace CinnamonTrees;

public abstract class BinaryDecisionBaseNode<TInput, TResult>(
    BaseNode<TInput, TResult> trueNode,
    BaseNode<TInput, TResult> falseNode)
    : BaseNode<TInput, TResult>
    where TResult : Enum
    where TInput : class
{
    protected abstract Func<TInput, bool> Predicate { get; }
    public abstract string Description { get; }

    public BaseNode<TInput, TResult> TrueNode { get; } = trueNode;
    public BaseNode<TInput, TResult> FalseNode { get; } = falseNode;

    public override DecisionTreeResult<TResult> Evaluate(TInput input, DecisionTreeEvaluationContext context)
    {
        var conditionResult = Predicate(input);

        context.AddDecision(conditionResult ? 1 : 0);

        return conditionResult
            ? TrueNode.Evaluate(input, context)
            : FalseNode.Evaluate(input, context);
    }
}