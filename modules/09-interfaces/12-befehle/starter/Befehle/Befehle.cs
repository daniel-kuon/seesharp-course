// Ein Befehl verändert einen Wert und kann die Änderung wieder zurücknehmen.
public interface IBefehl {
    string Name { get; }
    int Ausfuehren(int wert);
    int Rueckgaengig(int wert);
}

// Fertiges Beispiel.
public class Addiere(int summand) : IBefehl {
    public string Name => $"Addiere {summand}";
    public int Ausfuehren(int wert) => wert + summand;
    public int Rueckgaengig(int wert) => wert - summand;
}

public class Multipliziere : IBefehl {
    readonly int faktor;

    public Multipliziere(int faktor) {
        // TODO: faktor 0 -> ArgumentOutOfRangeException (Mal 0 lässt sich nicht zurücknehmen)
        throw new NotImplementedException();
    }

    // TODO: "Multipliziere 3"; Rückgängig teilt durch den Faktor
    public string Name => throw new NotImplementedException();
    public int Ausfuehren(int wert) => throw new NotImplementedException();
    public int Rueckgaengig(int wert) => throw new NotImplementedException();
}

public class Negiere : IBefehl {
    // TODO: "Negiere"; beide Richtungen drehen das Vorzeichen
    public string Name => throw new NotImplementedException();
    public int Ausfuehren(int wert) => throw new NotImplementedException();
    public int Rueckgaengig(int wert) => throw new NotImplementedException();
}

// Mehrere Befehle als einer; zurückgenommen wird in umgekehrter Reihenfolge.
public class Makro(params IBefehl[] befehle) : IBefehl {
    // TODO: "Makro(Addiere 2, Multipliziere 3)"
    public string Name => throw new NotImplementedException();

    // TODO: alle Befehle der Reihe nach anwenden
    public int Ausfuehren(int wert) => throw new NotImplementedException();

    // TODO: alle Befehle in umgekehrter Reihenfolge zurücknehmen
    public int Rueckgaengig(int wert) => throw new NotImplementedException();
}

public class Rechner {
    readonly IBefehl[] verlauf = new IBefehl[100];
    int anzahlVerlauf;
    readonly IBefehl[] zurueckgenommen = new IBefehl[100];
    int anzahlZurueckgenommen;

    public int Wert { get; private set; }

    // Führt den Befehl aus, merkt ihn im Verlauf und leert den Stapel zurueckgenommen.
    public void Ausfuehren(IBefehl befehl) {
        // TODO
        throw new NotImplementedException();
    }

    // Letzten Befehl zurücknehmen; false, wenn der Verlauf leer ist.
    public bool Rueckgaengig() {
        // TODO
        throw new NotImplementedException();
    }

    // Zuletzt zurückgenommenen Befehl erneut ausführen; false, wenn es keinen gibt.
    public bool Wiederholen() {
        // TODO
        throw new NotImplementedException();
    }

    // Namen der Befehle im Verlauf, mit ", " verbunden.
    public string Protokoll() {
        // TODO: string.Join
        throw new NotImplementedException();
    }
}
