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
        return $"Die Kinder von Familie {name}:\n{t.Informiere()}\n{s.Informiere()}";
    }

    class Tochter(Familie f, string name, int alter) {
        readonly Familie f = f;
        readonly string name = name;
        readonly int alter = alter;

        public string Informiere() {
            return $"Ich bin die {alter}-jährige Tochter {name} von Familie {f.name}.";
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
