public static class Suche
{
    public static int? ErstenTreffer(IEnumerable<int> folge, Predicate<int> passt, CancellationToken token)
    {
        foreach (int element in folge)
        {
            token.ThrowIfCancellationRequested();

            if (passt(element))
                return element;
        }
        return null;
    }
}
