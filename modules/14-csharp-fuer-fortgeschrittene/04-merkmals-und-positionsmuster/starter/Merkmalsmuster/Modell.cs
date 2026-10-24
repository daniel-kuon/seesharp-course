namespace Merkmalsmuster;

public record PKW(int Passagiere, bool Elektro);

public record Halter(string Land);

public record Fahrzeug(Halter? Halter, bool Elektro, int Baujahr);

public record Punkt(int X, int Y);
