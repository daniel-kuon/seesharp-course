public class AlarmzentraleTests
{
    [Fact]
    public void Zaehlt_Alarme_je_Sensor()
    {
        var z = new Alarmzentrale();
        var a = new Sensor("A");
        var b = new Sensor("B");
        z.Ueberwache(a);
        z.Ueberwache(b);

        a.Ausloesen(1);
        a.Ausloesen(2);
        b.Ausloesen(3);

        Assert.Equal(2, z.Anzahl("A"));
        Assert.Equal(1, z.Anzahl("B"));
    }

    [Fact]
    public void Merkt_den_hoechsten_Wert()
    {
        var z = new Alarmzentrale();
        var a = new Sensor("A");
        z.Ueberwache(a);
        Assert.Null(z.HoechsterWert);

        a.Ausloesen(5);
        a.Ausloesen(-3);
        a.Ausloesen(9);
        a.Ausloesen(7);

        Assert.Equal(9, z.HoechsterWert);
    }

    [Fact]
    public void Hoechster_Wert_kann_negativ_sein()
    {
        var z = new Alarmzentrale();
        var a = new Sensor("A");
        z.Ueberwache(a);

        a.Ausloesen(-8);
        a.Ausloesen(-5);

        Assert.Equal(-5, z.HoechsterWert);
    }

    [Fact]
    public void Nach_Entferne_wird_nicht_mehr_gezaehlt()
    {
        var z = new Alarmzentrale();
        var a = new Sensor("A");
        z.Ueberwache(a);
        a.Ausloesen(1);

        z.Entferne(a);
        a.Ausloesen(2);

        Assert.Equal(1, z.Anzahl("A"));
        Assert.Equal(1, z.HoechsterWert);
    }

    [Fact]
    public void Zweimal_ueberwachen_zaehlt_zweimal()
    {
        var z = new Alarmzentrale();
        var a = new Sensor("A");
        z.Ueberwache(a);
        z.Ueberwache(a);

        a.Ausloesen(1);

        Assert.Equal(2, z.Anzahl("A"));
    }

    [Fact]
    public void Entferne_meldet_nur_ein_Abonnement_ab()
    {
        var z = new Alarmzentrale();
        var a = new Sensor("A");
        z.Ueberwache(a);
        z.Ueberwache(a);

        z.Entferne(a);
        a.Ausloesen(1);

        Assert.Equal(1, z.Anzahl("A"));
    }

    [Fact]
    public void Unbekannter_Sensor_hat_Anzahl_null()
    {
        var z = new Alarmzentrale();

        Assert.Equal(0, z.Anzahl("gibt es nicht"));
    }

    [Fact]
    public void Fremder_Absender_wird_ignoriert()
    {
        var z = new Alarmzentrale();

        z.BeiAlarm("kein Sensor", new AlarmEventArgs(99));
        z.BeiAlarm(null, new AlarmEventArgs(99));

        Assert.Null(z.HoechsterWert);
    }

    [Fact]
    public void Hohe_Alarme_werden_gezaehlt()
    {
        var z = new Alarmzentrale();
        var a = new Sensor("A");
        z.UeberwacheHohe(a, 10);

        a.Ausloesen(9);
        a.Ausloesen(10);
        a.Ausloesen(50);

        Assert.Equal(2, z.HoheAlarme);
        Assert.Equal(0, z.Anzahl("A"));   // BeiAlarm ist nicht angemeldet
    }

    [Fact]
    public void EntferneHohe_meldet_das_Lambda_wirklich_ab()
    {
        var z = new Alarmzentrale();
        var a = new Sensor("A");
        z.UeberwacheHohe(a, 10);
        a.Ausloesen(11);

        z.EntferneHohe(a);
        a.Ausloesen(12);
        a.Ausloesen(13);

        Assert.Equal(1, z.HoheAlarme);
    }

    [Fact]
    public void EntferneHohe_ohne_Anmeldung_ist_harmlos()
    {
        var z = new Alarmzentrale();
        var a = new Sensor("A");

        z.EntferneHohe(a);
        a.Ausloesen(1);

        Assert.Equal(0, z.HoheAlarme);
    }
}
