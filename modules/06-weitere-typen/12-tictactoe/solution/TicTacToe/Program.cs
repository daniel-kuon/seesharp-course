var sf = new Spielfeld();
sf.Setze(1, 1);   // X
sf.Setze(0, 0);   // O
sf.Setze(0, 2);   // X
sf.Setze(2, 2);   // O
sf.Setze(2, 0);   // X gewinnt über die Nebendiagonale

for (int z = 0; z < 3; z++) {
    for (int s = 0; s < 3; s++)
        Console.Write(sf[z, s] == Feld.Leer ? '.' : sf[z, s].ToString()[0]);
    Console.WriteLine();
}
Console.WriteLine($"Status: {sf.Spielstand()}");
