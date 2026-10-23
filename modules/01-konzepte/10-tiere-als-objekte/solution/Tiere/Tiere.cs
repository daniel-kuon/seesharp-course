using System;

public class Hund {
    public string Name() {
        return "Bello";
    }

    public string Laut() {
        return "Wuff";
    }

    public string StellDichVor() {
        return Name() + " sagt " + Laut();
    }
}

public class Katze {
    public string Name() {
        return "Minka";
    }

    public string Laut() {
        return "Miau";
    }

    public string StellDichVor() {
        return Name() + " sagt " + Laut();
    }
}

public class Zoo {
    public static string Konzert() {
        Hund hund = new Hund();
        Katze katze = new Katze();
        return hund.StellDichVor() + ", " + katze.StellDichVor();
    }
}
