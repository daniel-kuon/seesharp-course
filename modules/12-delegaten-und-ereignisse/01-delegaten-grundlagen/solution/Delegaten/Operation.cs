// Ein Delegatentyp beschreibt eine Methodensignatur: zwei double-Parameter, Rückgabe double.
// Delegatenobjekte dieses Typs verweisen auf jede Methode mit genau dieser Signatur.
public delegate double Operation(double a, double b);

public delegate bool Bedingung(double wert);
