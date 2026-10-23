public class Buch : Medium {
    public string Autor { get; }

    public Buch(string titel, string autor) : base(titel) {
        Autor = autor;
    }

    public override string Info() => base.Info() + ", " + Autor;
}

// Gefragte Bücher: kürzere Leihfrist, doppelte Mahngebühr.
public class Bestseller : Buch {
    public Bestseller(string titel, string autor) : base(titel, autor) { }

    public override int Leihfrist => 14;

    public override decimal Mahngebuehr(int tageZuSpaet) => 2 * base.Mahngebuehr(tageZuSpaet);

    public override string Info() => base.Info() + " [Bestseller]";

    // Mindestens dreimal ausgeliehen?
    public bool IstGefragt => ausleihen >= 3;
}
