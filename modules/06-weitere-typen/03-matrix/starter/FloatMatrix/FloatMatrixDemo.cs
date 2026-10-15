const int zeilen = 3, spalten = 5;
var matrix = new FloatMatrix(zeilen, spalten);

for (int i = 0; i < zeilen; i++)
    for (int j = 0; j < spalten; j++)
        matrix[i, j] = i * spalten + j + 1;

Console.WriteLine($"Original ({matrix.Zeilen} x {matrix.Spalten}):\n{matrix.Anzeigen()}");
matrix.Transponieren();
Console.WriteLine($"Transponiert ({matrix.Zeilen} x {matrix.Spalten}):\n{matrix.Anzeigen()}");
