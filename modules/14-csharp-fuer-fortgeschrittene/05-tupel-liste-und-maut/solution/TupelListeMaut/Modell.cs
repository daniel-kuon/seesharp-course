namespace TupelListeMaut;

public enum Geste { Schere, Stein, Papier }

public enum Ergebnis { Unentschieden, Erster, Zweiter }

public enum Zeitband { Nacht, Morgen, Tag, Abend }

public abstract record Fahrzeug;

public record Auto(int Passagiere) : Fahrzeug;

public record Taxi(int Fahrgaeste) : Fahrzeug;

public record Bus(int Fahrgaeste, int Kapazitaet) : Fahrzeug;

public record Lieferwagen(int Gewicht) : Fahrzeug;
