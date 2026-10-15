Figur[] fa = [new Figur(), new Kreis(150.0, 200.0, 50.0), new Rechteck(20.0, 20.0, 20.0, 30.0)];
foreach (Figur f in fa) {
    f.Skaliere(2.0);
    Console.WriteLine(f.Beschreibe());
    Console.WriteLine();
}
