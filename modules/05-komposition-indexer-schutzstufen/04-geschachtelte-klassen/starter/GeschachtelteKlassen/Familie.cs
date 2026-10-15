public class Familie {
    readonly string name;
    readonly Tochter t;
    readonly Sohn s;

    public Familie(string nafa, string nato, int alto, string naso, int also) {
        name = nafa;
        t = new Tochter(this, nato, alto);
        s = new Sohn(this, naso, also);
    }

    public string Informiere() {
        // TODO: Überschrift "Die Kinder von Familie <name>:" und darunter je eine Zeile pro Kind,
        //       getrennt durch "\n" (Reihenfolge: Tochter, Sohn)
        throw new NotImplementedException();
    }

    // TODO: geschachtelte Klasse Tochter nach dem Vorbild von Sohn schreiben (privat, Primärkonstruktor
    //       mit Familie, Name und Alter). Informiere() liefert
    //       "Ich bin die <alter>-jährige Tochter <name> von Familie <Familienname>."
    class Tochter(Familie f, string name, int alter) {
        public string Informiere() {
            throw new NotImplementedException();
        }
    }

    public class Sohn(Familie f, string name, int alter) {
        readonly Familie f = f;
        readonly string name = name;
        readonly int alter = alter;

        public string Informiere() {
            // Die geschachtelte Klasse darf das private Feld name der Familie lesen.
            return $"Ich bin der {alter}-jährige Sohn {name} von Familie {f.name}.";
        }
    }
}
