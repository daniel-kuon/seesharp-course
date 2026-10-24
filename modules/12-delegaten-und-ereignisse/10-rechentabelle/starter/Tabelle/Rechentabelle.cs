public class Rechentabelle
{
    private readonly Dictionary<string, Func<double, double, double>> _operationen = new();

    // TODO: Operation unter dem Namen ablegen (überschreibt einen vorhandenen Eintrag)
    public void Registriere(string name, Func<double, double, double> operation) => throw new NotImplementedException();

    // TODO: Operation suchen (TryGetValue) und aufrufen; unbekannter Name: double.NaN
    public double Berechne(string name, double a, double b) => throw new NotImplementedException();

    // TODO: Gitter mit n = bis - von + 1 Zeilen und Spalten (n nie negativ); Zelle [i, j] = Berechne(name, von + i, von + j)
    public double[,] Tabelle(string name, int von, int bis) => throw new NotImplementedException();
}
