namespace CinnamonTrees;

public class DecisionTree<TInput, TResult>(BaseNode<TInput, TResult> root)
    where TResult : Enum
    where TInput : class
{
    public BaseNode<TInput, TResult> Root { get; } = root;

    public DecisionTreeResult<TResult> Evaluate(TInput input)
    {
        var context = new DecisionTreeEvaluationContext();
        var result = Root.Evaluate(input, context);
        
        return result;
    }
}
