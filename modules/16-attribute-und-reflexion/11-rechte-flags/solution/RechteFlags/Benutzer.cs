public class Benutzer
{
    public Rolle Rollen { get; private set; }

    public bool Darf(Rolle benoetigt) => (Rollen & benoetigt) == benoetigt;

    public void Vergib(Rolle rolle) => Rollen |= rolle;

    public void Entziehe(Rolle rolle) => Rollen &= ~rolle;

    public string Beschreibung() => Rollen.ToString();

    public static Rolle Parse(string text) => Enum.Parse<Rolle>(text, ignoreCase: true);
}
