namespace CinnamonTrees;

public class DecisionTreeEvaluationContext
{
    private readonly List<int> _path = new();
    
    public void AddDecision(int decision) => _path.Add(decision);
    
    public List<int> Path => _path.ToList();
}