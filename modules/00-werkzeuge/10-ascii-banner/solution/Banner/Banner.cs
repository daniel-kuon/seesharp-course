using System;

public class Banner {
    public static string Rahmenlinie() {
        return "+---------------------+";
    }

    public static string Titelzeile() {
        return "|  Hallo, SeeSharp!   |";
    }

    public static string Komplett() {
        return Rahmenlinie() + "\n" + Titelzeile() + "\n" + Rahmenlinie();
    }
}
