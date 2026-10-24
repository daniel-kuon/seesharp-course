public static class Suche
{
    // Liefert das erste Element der Folge, für das 'passt' wahr liefert, oder null, wenn es keines gibt.
    // Vor JEDEM Element wird token.ThrowIfCancellationRequested() aufgerufen, noch bevor 'passt' für
    // dieses Element läuft. Ist das Token schon beim Aufruf abgebrochen, wird 'passt' folglich kein
    // einziges Mal aufgerufen und die Methode wirft OperationCanceledException.
    public static int? ErstenTreffer(IEnumerable<int> folge, Predicate<int> passt, CancellationToken token)
    {
        // TODO
        throw new NotImplementedException();
    }
}
