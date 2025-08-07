namespace CinnamonTrees;

public record DecisionTreeResult<TResult>(
    TResult Result,
    List<int> Path
) where TResult : Enum;