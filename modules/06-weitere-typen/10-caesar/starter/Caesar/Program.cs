string klar = "Treffen wir uns heute Abend vor dem Theater?";
string geheim = Caesar.Verschluessele(klar, 3);

Console.WriteLine(geheim);
Console.WriteLine(Caesar.Entschluessele(geheim, 3));

int geraten = Caesar.Knacke(geheim);
Console.WriteLine($"Geknackter Schlüssel: {geraten}");
Console.WriteLine(Caesar.Entschluessele(geheim, geraten));
