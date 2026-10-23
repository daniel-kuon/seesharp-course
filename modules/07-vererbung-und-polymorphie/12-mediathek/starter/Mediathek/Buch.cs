public class Buch : Medium {
    public string Autor { get; }

    public Buch(string titel, string autor) : base(titel) {
        // TODO: Autor übernehmen (den Titel hat der Basiskonstruktor schon)
        throw new NotImplementedException();
    }

    // TODO: Info() überschreiben: base.Info() + ", " + Autor
}

// Gefragte Bücher: kürzere Leihfrist, doppelte Mahngebühr.
public class Bestseller : Buch {
    public Bestseller(string titel, string autor) : base(titel, autor) { }

    // TODO: Leihfrist 14 Tage
    // TODO: Mahngebuehr doppelt so hoch wie beim Buch (base.Mahngebuehr)
    // TODO: Info() hängt " [Bestseller]" an

    // Mindestens dreimal ausgeliehen? Braucht den Ausleihzähler aus Medium.
    public bool IstGefragt => throw new NotImplementedException();
}
