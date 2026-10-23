using System;

public class Bruchlabor {
    public static string KuerzeVierAchtel() {
        Bruch b = new Bruch();
        b.Zaehler = 4;
        b.Nenner = 8;
        b.Kuerze();
        return b.Text();
    }

    public static string NennerNull() {
        Bruch b = new Bruch();
        b.Zaehler = 3;
        b.Nenner = 0;
        return b.Text();
    }

    public static string EinHalbPlusEinDrittel() {
        Bruch b1 = new Bruch();
        b1.Zaehler = 1;
        b1.Nenner = 2;
        Bruch b2 = new Bruch();
        b2.Zaehler = 1;
        b2.Nenner = 3;
        b1.Addiere(b2);
        return b1.Text();
    }
}
