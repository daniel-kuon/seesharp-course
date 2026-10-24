Console.WriteLine(Protokoll.Log("Start"));
Console.WriteLine(Rechte.Lesen | Rechte.Schreiben);
Console.WriteLine(Rechtepruefung.Hat(Rechte.Lesen | Rechte.Schreiben, Rechte.Lesen));
