// ReSharper disable once CheckNamespace
namespace CinnamonTrees;

public class LeafNode<TInput, TResult>(TResult result, string description) : BaseNode<TInput, TResult>
    where TResult : Enum
    where TInput : class
{
    private TResult Result { get; } = result;
    public string Description { get; } = description;

    public override DecisionTreeResult<TResult> Evaluate(TInput input, DecisionTreeEvaluationContext context)
    {
        return new DecisionTreeResult<TResult>(Result, context.Path);
    }
}
