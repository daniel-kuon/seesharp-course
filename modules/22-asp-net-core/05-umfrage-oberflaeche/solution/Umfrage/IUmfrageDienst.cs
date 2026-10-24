// Abhängigkeit des PageModels: Das Modell kennt nur diese Schnittstelle, nicht die Speicherung.
public interface IUmfrageDienst
{
    IReadOnlyList<Stimme> Stimmen();
    void Abgeben(Stimme stimme);
}
