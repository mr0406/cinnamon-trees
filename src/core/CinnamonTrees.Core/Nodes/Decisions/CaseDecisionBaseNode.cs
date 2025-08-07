// ReSharper disable once CheckNamespace
namespace CinnamonTrees;

public record CaseBranch<TInput, TResult>(
    Func<TInput, bool> Condition,
    BaseNode<TInput, TResult> Node,
    string Description)
    where TResult : Enum
    where TInput : class;

public abstract class CaseDecisionBaseNode<TInput, TResult> : BaseNode<TInput, TResult>
    where TResult : Enum
    where TInput : class
{
    private readonly List<CaseBranch<TInput, TResult>> _casesWithConditions;
    private readonly List<BaseNode<TInput, TResult>> _cases;
    private readonly BaseNode<TInput, TResult> _default;

    public IReadOnlyList<BaseNode<TInput, TResult>> Cases => _cases.ToList();
    public BaseNode<TInput, TResult> Default => _default;

    public IReadOnlyList<string> CaseDescriptions { get; }
    public abstract string Description { get; }

    private CaseDecisionBaseNode(
        List<CaseBranch<TInput, TResult>> cases,
        BaseNode<TInput, TResult> defaultNode)
    {
        _casesWithConditions = cases;
        _cases = cases.Select(c => c.Node).ToList();
        CaseDescriptions = cases.Select(c => c.Description).ToList();
        _default = defaultNode;
    }
    
    protected CaseDecisionBaseNode(
        CaseBranch<TInput, TResult> case1,
        CaseBranch<TInput, TResult> case2,
        BaseNode<TInput, TResult> defaultNode)
        : this([case1, case2], defaultNode) { }

    protected CaseDecisionBaseNode(
        CaseBranch<TInput, TResult> case1,
        CaseBranch<TInput, TResult> case2,
        CaseBranch<TInput, TResult> case3,
        BaseNode<TInput, TResult> defaultNode)
        : this([case1, case2, case3], defaultNode) { }

    protected CaseDecisionBaseNode(
        CaseBranch<TInput, TResult> case1,
        CaseBranch<TInput, TResult> case2,
        CaseBranch<TInput, TResult> case3,
        CaseBranch<TInput, TResult> case4,
        BaseNode<TInput, TResult> defaultNode)
        : this([case1, case2, case3, case4], defaultNode) { }

    protected CaseDecisionBaseNode(
        CaseBranch<TInput, TResult> case1,
        CaseBranch<TInput, TResult> case2,
        CaseBranch<TInput, TResult> case3,
        CaseBranch<TInput, TResult> case4,
        CaseBranch<TInput, TResult> case5,
        BaseNode<TInput, TResult> defaultNode)
        : this([case1, case2, case3, case4, case5], defaultNode) { }

    protected CaseDecisionBaseNode(
        CaseBranch<TInput, TResult> case1,
        CaseBranch<TInput, TResult> case2,
        CaseBranch<TInput, TResult> case3,
        CaseBranch<TInput, TResult> case4,
        CaseBranch<TInput, TResult> case5,
        CaseBranch<TInput, TResult> case6,
        BaseNode<TInput, TResult> defaultNode)
        : this([case1, case2, case3, case4, case5, case6], defaultNode) { }

    protected CaseDecisionBaseNode(
        CaseBranch<TInput, TResult> case1,
        CaseBranch<TInput, TResult> case2,
        CaseBranch<TInput, TResult> case3,
        CaseBranch<TInput, TResult> case4,
        CaseBranch<TInput, TResult> case5,
        CaseBranch<TInput, TResult> case6,
        CaseBranch<TInput, TResult> case7,
        BaseNode<TInput, TResult> defaultNode)
        : this([case1, case2, case3, case4, case5, case6, case7], defaultNode) { }

    protected CaseDecisionBaseNode(
        CaseBranch<TInput, TResult> case1,
        CaseBranch<TInput, TResult> case2,
        CaseBranch<TInput, TResult> case3,
        CaseBranch<TInput, TResult> case4,
        CaseBranch<TInput, TResult> case5,
        CaseBranch<TInput, TResult> case6,
        CaseBranch<TInput, TResult> case7,
        CaseBranch<TInput, TResult> case8,
        BaseNode<TInput, TResult> defaultNode)
        : this([case1, case2, case3, case4, case5, case6, case7, case8], defaultNode) { }

    public override DecisionTreeResult<TResult> Evaluate(TInput input, DecisionTreeEvaluationContext context)
    {
        var key = SelectIndex(input);
        context.AddDecision(key);

        return key == 0 
            ? _default.Evaluate(input, context) 
            : _cases[key - 1].Evaluate(input, context);
    }

    private int SelectIndex(TInput input)
    {
        for (var i = 0; i < _casesWithConditions.Count; i++)
        {
            if (_casesWithConditions[i].Condition(input))
            {
                return i + 1;   
            }
        }

        return 0;
    }
}
