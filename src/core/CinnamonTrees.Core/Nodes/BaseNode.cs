// ReSharper disable once CheckNamespace
namespace CinnamonTrees;

public abstract class BaseNode<TInput, TResult>
    where TResult : Enum
    where TInput : class
{
    public abstract DecisionTreeResult<TResult> Evaluate(TInput input, DecisionTreeEvaluationContext context);
}
