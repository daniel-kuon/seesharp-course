// TODO: Aus der Aufzählung soll ein Bitfeld werden (Attribut [Flags]), damit sich Rollen
//       kombinieren lassen: Rolle.Leser | Rolle.Autor wird als "Leser, Autor" ausgegeben.
public enum Rolle
{
    Keine = 0,
    Leser = 1,
    Autor = 2,
    Pruefer = 4,
    Admin = 8,
}
