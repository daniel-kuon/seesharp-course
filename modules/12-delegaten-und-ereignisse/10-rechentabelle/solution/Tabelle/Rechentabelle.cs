public class Rechentabelle
{
    private readonly Dictionary<string, Func<double, double, double>> _operationen = new();

    public void Registriere(string name, Func<double, double, double> operation) =>
        _operationen[name] = operation;

    public double Berechne(string name, double a, double b) =>
        _operationen.TryGetValue(name, out var operation) ? operation(a, b) : double.NaN;

    public double[,] Tabelle(string name, int von, int bis)
    {
        int n = Math.Max(0, bis - von + 1);
        var gitter = new double[n, n];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                gitter[i, j] = Berechne(name, von + i, von + j);
        return gitter;
    }
}
