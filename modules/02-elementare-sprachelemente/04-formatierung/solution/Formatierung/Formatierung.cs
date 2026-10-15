public class Formatierung {
    public static string SummeText() => "3 + 2 = " + (3 + 2);
    public static string Bruchzeile(int zaehler, int nenner) => $"{zaehler}/{nenner}";
    public static string Ausgerichtet(int i, int j, int k, int m) =>
        $"Rechtsbündig:\n\ti = {i,4}\n\tj = {j,4}\n\tk = {k,4}\n\tm = {m,4}" +
        $"\n\nLinksbündig:\n\t{i,-4} (i)\n\t{j,-4} (j)\n\t{k,-4} (k)\n\t{m,-4} (m)";
}
