// Ein Befehl verändert einen Wert und kann die Änderung wieder zurücknehmen.
public interface IBefehl {
    string Name { get; }
    int Ausfuehren(int wert);
    int Rueckgaengig(int wert);
}

public class Addiere(int summand) : IBefehl {
    public string Name => $"Addiere {summand}";
    public int Ausfuehren(int wert) => wert + summand;
    public int Rueckgaengig(int wert) => wert - summand;
}

public class Multipliziere : IBefehl {
    readonly int faktor;

    public Multipliziere(int faktor) {
        if (faktor == 0)
            throw new ArgumentOutOfRangeException(nameof(faktor), "Mal 0 lässt sich nicht zurücknehmen.");
        this.faktor = faktor;
    }

    public string Name => $"Multipliziere {faktor}";
    public int Ausfuehren(int wert) => wert * faktor;
    public int Rueckgaengig(int wert) => wert / faktor;
}

public class Negiere : IBefehl {
    public string Name => "Negiere";
    public int Ausfuehren(int wert) => -wert;
    public int Rueckgaengig(int wert) => -wert;
}

// Mehrere Befehle als einer; zurückgenommen wird in umgekehrter Reihenfolge.
public class Makro(params IBefehl[] befehle) : IBefehl {
    public string Name {
        get {
            var namen = new string[befehle.Length];
            for (int i = 0; i < befehle.Length; i++)
                namen[i] = befehle[i].Name;
            return $"Makro({string.Join(", ", namen)})";
        }
    }

    public int Ausfuehren(int wert) {
        foreach (IBefehl b in befehle)
            wert = b.Ausfuehren(wert);
        return wert;
    }

    public int Rueckgaengig(int wert) {
        for (int i = befehle.Length - 1; i >= 0; i--)
            wert = befehle[i].Rueckgaengig(wert);
        return wert;
    }
}

public class Rechner {
    readonly IBefehl[] verlauf = new IBefehl[100];
    int anzahlVerlauf;
    readonly IBefehl[] zurueckgenommen = new IBefehl[100];
    int anzahlZurueckgenommen;

    public int Wert { get; private set; }

    // Führt den Befehl aus, merkt ihn im Verlauf und vergisst alles Zurückgenommene.
    public void Ausfuehren(IBefehl befehl) {
        Anwenden(befehl);
        anzahlZurueckgenommen = 0;
    }

    void Anwenden(IBefehl befehl) {
        if (anzahlVerlauf == verlauf.Length)
            throw new InvalidOperationException("Verlauf voll");
        Wert = befehl.Ausfuehren(Wert);
        verlauf[anzahlVerlauf++] = befehl;
    }

    public bool Rueckgaengig() {
        if (anzahlVerlauf == 0)
            return false;
        IBefehl befehl = verlauf[--anzahlVerlauf];
        Wert = befehl.Rueckgaengig(Wert);
        zurueckgenommen[anzahlZurueckgenommen++] = befehl;
        return true;
    }

    public bool Wiederholen() {
        if (anzahlZurueckgenommen == 0)
            return false;
        Anwenden(zurueckgenommen[--anzahlZurueckgenommen]);
        return true;
    }

    // Namen der Befehle im Verlauf, mit ", " verbunden.
    public string Protokoll() {
        var namen = new string[anzahlVerlauf];
        for (int i = 0; i < anzahlVerlauf; i++)
            namen[i] = verlauf[i].Name;
        return string.Join(", ", namen);
    }
}
